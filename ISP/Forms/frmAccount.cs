using DataIntegrationHub.Business.Entities;

using ISP.Business.Entities;
using ISP.Presentation;
using ISP.Presentation.Utilities;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ISP.Presentation.Forms
{
	public partial class frmAccount : Form, IMessageFilter
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

        private frmMain frmMain_Parent;
        public Account CurrentAccount;

        public frmAccount(frmMain mf, Guid accountId, FormClosedEventHandler Close = null)
        {
            frmSplashScreen ss = new frmSplashScreen();
            ss.Show();
            Application.DoEvents();

            InitializeComponent();

            frmMain_Parent = mf;

            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.panel1);
            controlsToMove.Add(this.panel7);
            controlsToMove.Add(this.panel12);
            controlsToMove.Add(this.panel16);
            controlsToMove.Add(this.label1);
            controlsToMove.Add(this.label23);
            controlsToMove.Add(this.label30);
            controlsToMove.Add(this.label39);

            FormClosed += Close;

            loadObservationFields();

            CurrentAccount = new Account(accountId);
            txtName.Text = CurrentAccount.Name;
            this.Text = CurrentAccount.Name;
            label18.Text = CurrentAccount.Name;
            label23.Text = CurrentAccount.Name;
            label30.Text = CurrentAccount.Name;
            txtEngagements.Text = CurrentAccount.Engagements;
            txtPrimaryContactName.Text = CurrentAccount.PrimaryContact.Name;
            txtPrimaryContactEmail.Text = CurrentAccount.PrimaryContact.Email;
            assetvalue.Text = CurrentAccount.Revenue;
            txtPhone.Text = CurrentAccount.Telephone;
            txtFax.Text = CurrentAccount.Fax;
            txtAddressLine1.Text = CurrentAccount.PrimaryAddress.Line1;
            txtAddressLine2.Text = CurrentAccount.PrimaryAddress.Line2;
            txtAddressCity.Text = CurrentAccount.PrimaryAddress.City;
            txtAddressState.Text = CurrentAccount.PrimaryAddress.State;
            txtAddressZip.Text = CurrentAccount.PrimaryAddress.Zip;
            txtCommitteeMembers.Text = CurrentAccount.CommitteeMembers;
            txtRecordKeepers.Text = CurrentAccount.RecordKeepers;
            txtCustodians.Text = CurrentAccount.Custodians;

            foreach (DataRow dr in ISP.Business.Entities.Plan.GetAssociatedFromAccount(accountId).Rows)
                cboSelectedPlan.Items.Add(new Utilities.ListItem(dr["Name"].ToString(), dr["ID"].ToString()));

            if (cboSelectedPlan.Items.Count > 0)
                cboSelectedPlan.SelectedIndex = 0;

            if (txtPrimaryContactName.Text == "" || txtPrimaryContactName.Text == null)
                txtPrimaryContactName.Cursor = System.Windows.Forms.Cursors.Arrow;

            comboBox5.Items.Clear();
            comboBox6.Items.Clear();

            comboBox5.Items.Add(new ListItem("No Instructions On File", null));
            comboBox6.Items.Add(new ListItem("No Instructions On File", null));

            foreach (DataRow dr in Benchmarks.Get().Rows)
            {
                comboBox5.Items.Add(new ListItem(dr["FundName"].ToString(), dr["FundID"].ToString()));
                comboBox6.Items.Add(new ListItem(dr["FundName"].ToString(), dr["FundID"].ToString()));
            }

            ss.Close();
            this.Show();
		}

        private Guid PlanId;
        private Guid _relationalFundsPlansId;
        private Guid? benchMarkPrimaryId;
        private Guid? benchMarkSecondaryId;

        private bool UnsavedChangesIps = false;
        private bool UnsavedChangesFund = false;
        private bool CancelSelectedPlanCboIndexChanged = false;
        private bool CancelFundsDgvCellEnter = false;

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN &&
                 controlsToMove.Contains(Control.FromHandle(m.HWnd)))
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                return true;
            }
            return false;
        }

		void openFund(object sender, EventArgs e)
		{
            int index = dgvFunds.CurrentRow.Index;
            _relationalFundsPlansId = new Guid(dgvFunds.Rows[index].Cells[0].Value.ToString());
            Guid fundId = new Guid(dgvFunds.Rows[index].Cells[1].Value.ToString());

            string benchMark = null;

            foreach (DataRow dr in ISP.Business.Entities.Benchmarks.GetAssociatedFromRelational_Funds_Plans(_relationalFundsPlansId).Rows)
            {
                benchMark = dr["BenchMark"].ToString();
            }

            frmFund fundForm = new frmFund(frmMain_Parent, fundId, benchMark);
		}

        public void loadObservationFields()
        {
            comboBox9.Items.Clear();
            comboBox10.Items.Clear();

            foreach (DataRow dr in ISP.Business.Entities.TimeTable.GetPast10Years().Rows)
            {
                comboBox9.Items.Add(new Utilities.ListItem(dr["Month"].ToString(), dr["TimeTableId"].ToString()));
            }

            foreach (User _user in User.ActiveUsers())
            {
                comboBox10.Items.Add(new Utilities.ListItem(_user.FullName, _user.UserId.ToString()));
            }
        }

        private void savePlanDetails()
        {
            if (PlanId == null || cboSelectedPlan.SelectedIndex == -1)
            {
                return;
            }

            if (String.IsNullOrEmpty(cboIpsReturn1Yr.Text) && String.IsNullOrEmpty(cboIpsReturn3Yr.Text) && String.IsNullOrEmpty(cboIpsRisk3Yr.Text))
            {
                return;
            }

            decimal? return1Yr = null;
            decimal? return3Yr = null;
            decimal? risk3Yr = null;
            bool? trackManagers = null;

            Guid userId = frmMain_Parent.CurrentUser.UserId;

            if (String.IsNullOrEmpty(cboIpsReturn1Yr.Text) == false)
            {
                ComboBox cbo = cboIpsReturn1Yr;

                Decimal decText;
                string text;

                if (cbo.Text.Substring(cbo.Text.Length - 1) == "%")
                {
                    text = cbo.Text.Remove(cbo.Text.Length - 1);
                }
                else
                {
                    text = cbo.Text;
                }

                try
                {
                    decText = Decimal.Parse(text);
                }
                catch
                {
                    MessageBox.Show("Return 1 YR is not in a percentage or number format.", "Error");
                    cbo.Select();
                    return;
                }

                return1Yr = decText / 100;
            }

            if (String.IsNullOrEmpty(cboIpsReturn3Yr.Text) == false)
            {
                ComboBox cbo = cboIpsReturn3Yr;

                Decimal decText;
                string text;

                if (cbo.Text.Substring(cbo.Text.Length - 1) == "%")
                {
                    text = cbo.Text.Remove(cbo.Text.Length - 1);
                }
                else
                {
                    text = cbo.Text;
                }

                try
                {
                    decText = Decimal.Parse(text);
                }
                catch
                {
                    MessageBox.Show("Return 3 YR is not in a percentage or number format.", "Error");
                    cbo.Select();
                    return;
                }

                return3Yr = decText / 100;
            }

            if (String.IsNullOrEmpty(cboIpsRisk3Yr.Text) == false)
            {
                ComboBox cbo = cboIpsRisk3Yr;

                Decimal decText;
                string text;

                if (cbo.Text.Substring(cbo.Text.Length - 1) == "%")
                {
                    text = cbo.Text.Remove(cbo.Text.Length - 1);
                }
                else
                {
                    text = cbo.Text;
                }

                try
                {
                    decText = Decimal.Parse(text);
                }
                catch
                {
                    MessageBox.Show("Risk 3 YR is not in a percentage or number format.", "Error");
                    cbo.Select();
                    return;
                }

                risk3Yr = decText / 100;
            }

            if (cboTrackManagers.SelectedIndex == 1)
                trackManagers = true;
            else if (cboTrackManagers.SelectedIndex == 2)
                trackManagers = false;

            ISP.Business.Entities.Plan.SavePlanDetails(PlanId, userId, return1Yr, return3Yr, risk3Yr, trackManagers);
        }

        private void SaveFundDetails()
        {
            if (cboSelectedPlan.SelectedIndex != -1 && _relationalFundsPlansId != null)
            {
                Guid rfpId = _relationalFundsPlansId;
                Guid userId = frmMain_Parent.CurrentUser.UserId;
                Guid? bmpId = null;
                Guid? bmsId = null;
                DateTime? authorizedOn = null;
                bool? isMonitored = null;
                Decimal? assetValue = null;
                DateTime? assetValueAsOf = null;
                Guid? recommendedBy = null;

                if (benchMarkPrimaryId != new Guid("00000000-0000-0000-0000-000000000000") && benchMarkPrimaryId != null)
                {
                    bmpId = benchMarkPrimaryId;
                }

                if (benchMarkSecondaryId != new Guid("00000000-0000-0000-0000-000000000000") && benchMarkSecondaryId != null)
                {
                    bmsId = benchMarkSecondaryId;
                }

                if (String.IsNullOrEmpty(textBox1.Text) == false)
                {
                    try
                    {
                        authorizedOn = DateTime.Parse(textBox1.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Date Added field is not in a propper date format.", "Error");
                        textBox1.Select();
                        return;
                    }
                }

                if (String.IsNullOrEmpty(txtAssetValue.Text) == false)
                {
                    try
                    {
                        string assetValueString = txtAssetValue.Text;
                        if (assetValueString.StartsWith("$"))
                            assetValueString = assetValueString.Substring(1);
                        assetValue = Decimal.Parse(assetValueString);
                    }
                    catch
                    {
                        MessageBox.Show("Asset Value field is not in a propper numeric format.", "Error");
                        txtAssetValue.Select();
                        return;
                    }
                }

                if (String.IsNullOrEmpty(textBox4.Text) == false)
                {
                    try
                    {
                        assetValueAsOf = DateTime.Parse(textBox4.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Asset Value As Of field is not in a propper date format.", "Error");
                        textBox4.Select();
                        return;
                    }
                }

                if (String.IsNullOrEmpty(comboBox7.Text) == false)
                {
                    recommendedBy = new Guid(((Utilities.ListItem)comboBox7.SelectedItem).HiddenValue);
                }

                if (cboIsMonitored.SelectedIndex == 1)
                    isMonitored = true;
                else if (cboIsMonitored.SelectedIndex == 2)
                    isMonitored = false;

                ISP.Business.Entities.Relational_Funds_Plans.SaveFundDetails(rfpId, userId, bmpId, bmsId, authorizedOn, isMonitored, assetValue, assetValueAsOf, recommendedBy);
            }
        }

        void pictureBox1Click(object sender, EventArgs e)
        {
            tabControlClientDetail.SelectedIndex = 0;
        }

        void pictureBox1MouseEnter(object sender, EventArgs e)
        {
            label25.Text = "Account Details";
        }

        void pictureBox1MouseLeave(object sender, EventArgs e)
        {
            label25.Text = "Ready";
        }

        void pictureBox2Click(object sender, EventArgs e)
        {
            tabControlClientDetail.SelectedIndex = 1;
        }

        private void label23_TextChanged(object sender, EventArgs e)
        {
            string CompanyName = label23.Text;
            label30.Text = CompanyName;
            label39.Text = CompanyName;
        }

        private void label46_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            tabControlClientDetail.SelectedIndex = 0;

        }

        private void label47_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            tabControlClientDetail.SelectedIndex = 1;
        }

        private void label49_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            tabControlClientDetail.SelectedIndex = 2;
            loadObservations();
        }

        private void loadObservations()
        {
            comboBox8.Items.Clear();

            foreach (DataRow dr in ISP.Business.Entities.Observations.GetAssociatedFromAccount(CurrentAccount.AccountId).Rows)
            {
                if (!String.IsNullOrWhiteSpace(dr["OwnerId"].ToString()))
                {
                    User _user = new User(new Guid(dr["OwnerId"].ToString()));
                    string s = dr["TimeTableValue"].ToString() + " - " + _user.FullName;
                    comboBox8.Items.Add(new Utilities.ListItem(s, dr["ObservationId"].ToString()));
                }
                else
                {
                    string s = dr["TimeTableValue"].ToString();
                    comboBox8.Items.Add(new Utilities.ListItem(s, dr["ObservationId"].ToString()));
                }
                
            }

            if (comboBox8.Items.Count > 0)
            {
                comboBox8.SelectedIndex = 0;

                button4.Enabled = true;
                button7.Enabled = true;
                comboBox8.Enabled = true;
                comboBox9.Enabled = true;
                comboBox10.Enabled = true;
                richTextBox4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
                button7.Enabled = false;
                comboBox8.Enabled = false;
                comboBox9.Enabled = false;
                comboBox10.Enabled = false;
                richTextBox4.Enabled = false;
            }
        }

        private void CloseFormButton_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.Color.Black;
            label.BackColor = System.Drawing.Color.Lavender;
        }

        private void CloseFormButton_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.Color.White;
            label.BackColor = System.Drawing.Color.SteelBlue;
        }

        private void CloseForm(object sender, EventArgs e)
        {
            if (UnsavedChangesIps)
            {
                DialogResult result = MessageBox.Show("There are unsaved IPS Monitoring Criteria changes. Are you sure you wish to continue?", "Attention", MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes)
                    return;
            }
            else if (UnsavedChangesFund)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes to the selected fund. Are you sure you wish to continue?", "Attention", MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes)
                    return;
            }

            this.Close();
        }

        private void MaximizeForm(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void MenuItem_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.SystemColors.HotTrack;
            label.BackColor = System.Drawing.Color.Gainsboro;
        }

        private void MenuItem_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.SystemColors.ControlText;
            label.BackColor = System.Drawing.Color.Silver;
        }

        private void dgvFunds_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (UnsavedChangesFund)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes to the fund's details. Are you sure you wish to continue?", "Attention", MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes)
                {
                    foreach (DataGridViewRow dr in dgvFunds.Rows)
                    {
                        if (new Guid(dr.Cells[0].Value.ToString()) == _relationalFundsPlansId)
                        {
                            int index = dr.Index;

                            if (dgvFunds.CurrentRow.Index == index)
                                return;

                            UnsavedChangesFund = false;
                            CancelFundsDgvCellEnter = true;

                            this.BeginInvoke(new MethodInvoker(() =>
                            {
                                dgvFunds.CurrentCell = dgvFunds.Rows[index].Cells[2];
                                UnsavedChangesFund = true;
                                CancelFundsDgvCellEnter = false;
                            }));

                            break;
                        }
                    }

                    return;
                }
            }

            if (PlanId != null && cboSelectedPlan.SelectedIndex != -1 && !CancelFundsDgvCellEnter)
            {
                int index = dgvFunds.CurrentRow.Index;
                _relationalFundsPlansId = new Guid(dgvFunds.Rows[index].Cells[0].Value.ToString());
                lblSelectedFund.Text = dgvFunds.Rows[index].Cells[4].Value.ToString();

                DataRow dr = ISP.Business.Entities.Relational_Funds_Plans.GetFundDetails(_relationalFundsPlansId).Rows[0];

                try
                {
                    txtAssetValue.Text = Decimal.Parse(dr["AssetValue"].ToString()).ToString("C2");
                }
                catch
                {
                    txtAssetValue.Text = dr["AssetValue"].ToString();
                }

                if (String.IsNullOrEmpty(dr["AuthorizedOn"].ToString()) == false)
                {
                    DateTime date = DateTime.Parse(dr["AuthorizedOn"].ToString());
                    textBox1.Text = date.Date.Month.ToString() + "/" + date.Date.Day.ToString() + "/" + date.Date.Year.ToString();
                }
                else
                {
                    textBox1.Text = null;
                }

                if (String.IsNullOrEmpty(dr["AssetValueAsOf"].ToString()) == false)
                {
                    DateTime date = DateTime.Parse(dr["AssetValueAsOf"].ToString());
                    textBox4.Text = date.Date.Month.ToString() + "/" + date.Date.Day.ToString() + "/" + date.Date.Year.ToString();
                }
                else
                {
                    textBox4.Text = null;
                }

                if (String.IsNullOrEmpty(dr["BenchMarkPrimaryId"].ToString()))
                {
                    comboBox5.SelectedIndex = 0;
                    comboBox5.Text = "No Instructions On File";
                }
                else
                {
                    comboBox5.Text = dr["BenchMarkPrimaryName"].ToString();
                }

                if (String.IsNullOrEmpty(dr["BenchMarkSecondaryId"].ToString()))
                {
                    comboBox6.SelectedIndex = 0;
                    comboBox6.Text = "No Instructions On File";
                }
                else
                {
                    comboBox6.Text = dr["BenchMarkSecondaryName"].ToString();
                }

                if (String.IsNullOrEmpty(dr["RecommendedBy"].ToString()))
                {
                    comboBox7.SelectedIndex = -1;
                }
                else
                {
                    User _user = new User(new Guid(dr["RecommendedBy"].ToString()));
                    comboBox7.Text = _user.FullName;
                }

                if (dr["IsMonitored"].ToString() == "True")
                    cboIsMonitored.SelectedIndex = 1;
                else if (dr["IsMonitored"].ToString() == "False")
                    cboIsMonitored.SelectedIndex = 2;
                else
                    cboIsMonitored.SelectedIndex = 0;

                comboBox5.Select(0, 0);
                comboBox6.Select(0, 0);
                comboBox7.Select(0, 0);

                UnsavedChangesFund = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dgvFunds.CurrentRow.Index;

            _relationalFundsPlansId = new Guid(dgvFunds.Rows[index].Cells[0].Value.ToString());
            Guid fundId = new Guid(dgvFunds.Rows[index].Cells[1].Value.ToString());

            string benchMark = null;

            foreach (DataRow dr in ISP.Business.Entities.Benchmarks.GetAssociatedFromRelational_Funds_Plans(_relationalFundsPlansId).Rows)
            {
                benchMark = dr["BenchMark"].ToString();
            }

            frmFund fundForm = new frmFund(frmMain_Parent, fundId, benchMark);
        }

        private void email_DoubleClick(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPrimaryContactEmail.Text) == false)
            {
                string enter = "%0D%0A";
                string emailString = "mailto:" + txtPrimaryContactEmail.Text + "?body=" + txtPrimaryContactName.Text + ", " + enter + enter;

                string emailTag = string.Format(emailString);
                System.Diagnostics.Process.Start(emailTag);
            }
        }

        private void cboSelectedPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UnsavedChangesIps)
            {
                DialogResult result = MessageBox.Show("There are unsaved IPS Monitoring Criteria changes. Are you sure you wish to continue?", "Attention", MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes)
                {
                    UnsavedChangesIps = false;
                    CancelSelectedPlanCboIndexChanged = true;

                    foreach (var item in cboSelectedPlan.Items)
                    {
                        if (new Guid(((Utilities.ListItem)item).HiddenValue) == PlanId)
                        {
                            cboSelectedPlan.SelectedItem = item;
                            break;
                        }
                    }

                    CancelSelectedPlanCboIndexChanged = false;
                    UnsavedChangesIps = true;

                    return;
                }
            }

            if (cboSelectedPlan.SelectedIndex != -1 && !CancelSelectedPlanCboIndexChanged)
            {
                loadFunds();

                Business.Entities.Plan plan = new Business.Entities.Plan(PlanId);

                if (plan.ReturnAllowance1Yr != null)
                    cboIpsReturn1Yr.Text = ((int)(plan.ReturnAllowance1Yr * 100)).ToString() + "%";
                else
                    cboIpsReturn1Yr.SelectedIndex = 0;

                if (plan.ReturnAllowance3Yr != null)
                    cboIpsReturn3Yr.Text = ((int)(plan.ReturnAllowance3Yr * 100)).ToString() + "%";
                else
                    cboIpsReturn3Yr.SelectedIndex = 0;

                if (plan.RiskAllowance3Yr != null)
                    cboIpsRisk3Yr.Text = ((int)(plan.RiskAllowance3Yr * 100)).ToString() + "%";
                else
                    cboIpsRisk3Yr.SelectedIndex = 0;

                if (plan.TrackManagerChanges == true)
                    cboTrackManagers.SelectedIndex = 1;
                else if (plan.TrackManagerChanges == false)
                    cboTrackManagers.SelectedIndex = 2;
                else
                    cboTrackManagers.SelectedIndex = 0;

                comboBox7.Items.Clear();
                comboBox7.Items.Add(new Utilities.ListItem("", null));

                foreach (User _user in User.ActiveUsers())
                {
                    comboBox7.Items.Add(new Utilities.ListItem(_user.FullName, _user.UserId.ToString()));
                }

                UnsavedChangesIps = false;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex != -1)
            {
                if (((Utilities.ListItem)comboBox5.SelectedItem).HiddenValue != null)
                {
                    benchMarkPrimaryId = new Guid(((Utilities.ListItem)comboBox5.SelectedItem).HiddenValue);
                }
                else
                {
                    benchMarkPrimaryId = null;
                }
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex != -1)
            {
                if (((Utilities.ListItem)comboBox6.SelectedItem).HiddenValue != null)
                {
                    benchMarkSecondaryId = new Guid(((Utilities.ListItem)comboBox6.SelectedItem).HiddenValue);
                }
                else
                {
                    benchMarkSecondaryId = null;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Presentation.Forms.frmAddExistingItem aei = new Presentation.Forms.frmAddExistingItem(frmMain_Parent, "Fund", PlanId, null, addExistingClosed);
        }

        private void addExistingClosed(object sender, FormClosedEventArgs e)
        {
            loadFunds();
        }
        
        private void loadFunds()
        {
            if (cboSelectedPlan.SelectedIndex != -1)
            {
                PlanId = new Guid(((Utilities.ListItem)cboSelectedPlan.SelectedItem).HiddenValue);
                dgvFunds.DataSource = ISP.Business.Entities.Fund.GetActiveAssociatedFromPlan(PlanId);
                dgvFunds.Columns[0].Visible = false;
                dgvFunds.Columns[1].Visible = false;
                dgvFunds.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Ticker
                dgvFunds.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //FundName
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = dgvFunds.CurrentRow.Index;
            Guid rfpID = new Guid(dgvFunds.Rows[index].Cells[0].Value.ToString());
            Guid userId = frmMain_Parent.CurrentUser.UserId;

            string planName = cboSelectedPlan.Text;
            string fundName = dgvFunds.Rows[index].Cells[3].Value.ToString();

            DialogResult result = MessageBox.Show("Are you sure you wish to remove " + fundName + " from " + planName + "?", "Attention", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ISP.Business.Entities.Relational_Funds_Plans.Remove(rfpID, userId);
            }

            loadFunds();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.Text == "< New Observation >")
            {
                return;
            }

            Guid observationId = new Guid(((Utilities.ListItem)comboBox8.SelectedItem).HiddenValue);

            foreach (DataRow dr in ISP.Business.Entities.Observations.GetDetails(observationId).Rows)
            {
                string _ownerName = null;
                string _modifiedByName = null;
                string _createdByName = null;

                if (!String.IsNullOrWhiteSpace(dr["OwnerId"].ToString()))
                    _ownerName = new User(new Guid(dr["OwnerId"].ToString())).FullName;

                if (!String.IsNullOrWhiteSpace(dr["ModifiedBy"].ToString()))
                    _modifiedByName = new User(new Guid(dr["ModifiedBy"].ToString())).FullName;

                if (!String.IsNullOrWhiteSpace(dr["CreatedBy"].ToString()))
                    _createdByName = new User(new Guid(dr["CreatedBy"].ToString())).FullName;

                richTextBox4.Text = dr["Text"].ToString();
                comboBox9.Text = dr["Month"].ToString();
                comboBox10.Text = _ownerName;
                label50.Text = _modifiedByName;
                label51.Text = dr["ModifiedOn"].ToString();
                label54.Text = _createdByName;
                label55.Text = dr["CreatedOn"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "New")
            {
                button2.Text = "Cancel";

                comboBox8.Items.Clear();
                comboBox9.SelectedIndex = -1;
                comboBox10.SelectedIndex = -1;
                richTextBox4.Text = null;
                label50.Text = null;
                label51.Text = null;
                label54.Text = null;
                label55.Text = null;

                comboBox8.Items.Add(new Utilities.ListItem("< New Observation >", null));
                comboBox8.SelectedIndex = 0;

                comboBox8.Enabled = false;

                button4.Enabled = true;
                button7.Enabled = true;
                comboBox9.Enabled = true;
                comboBox10.Enabled = true;
                richTextBox4.Enabled = true;
            }
            else if (button2.Text == "Cancel")
            {
                button2.Text = "New";

                comboBox8.Enabled = true;

                loadObservations();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox9.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a month value", "Error!", MessageBoxButtons.OK);
                return;
            }

            if (comboBox10.SelectedIndex == -1)
            {
                MessageBox.Show("You must select an owner for this observation", "Error!", MessageBoxButtons.OK);
                return;
            }

            Guid timeTableId = new Guid(((Utilities.ListItem)comboBox9.SelectedItem).HiddenValue);
            Guid ownerId = new Guid(((Utilities.ListItem)comboBox10.SelectedItem).HiddenValue);
            Guid userId = frmMain_Parent.CurrentUser.UserId;
            string text = richTextBox4.Text;

            int selectedIndex = comboBox8.SelectedIndex;

            if (comboBox8.Text == "< New Observation >") //Insert new observation
            {
                ISP.Business.Entities.Observations.Insert(CurrentAccount.AccountId, timeTableId, ownerId, userId, text);
            }
            else //update existing observation
            {
                Guid observationId = new Guid(((Utilities.ListItem)comboBox8.SelectedItem).HiddenValue);
                ISP.Business.Entities.Observations.Update(observationId, timeTableId, ownerId, userId, text);
            }

            loadObservations();
            comboBox8.SelectedIndex = selectedIndex;

            MessageBox.Show("Observation saved successfully!", "Success!", MessageBoxButtons.OK);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (((Utilities.ListItem)comboBox8.SelectedItem).HiddenValue == null)
                return;

            Guid observationId = new Guid(((Utilities.ListItem)comboBox8.SelectedItem).HiddenValue);
            Guid userId = frmMain_Parent.CurrentUser.UserId;
            ISP.Business.Entities.Observations.SetInactive(observationId, userId);
            loadObservations();
        }

        private void btnSaveIpsCriteria_Click(object sender, EventArgs e)
        {
            try
            {
                savePlanDetails();
                UnsavedChangesIps = false;
                MessageBox.Show("IPS Monitoring Criteria successfully saved!", "Success!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
            }
        }

        private void SelectRowWithGuid(Guid RelationalFundsPlansId)
        {
            int index = -1;
            foreach (DataGridViewRow row in dgvFunds.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(RelationalFundsPlansId.ToString()))
                {
                    index = row.Index;
                    break;
                }
            }

            dgvFunds.Rows[index].Cells[2].Selected = true;
        }

        private void SortFundDataGridViewAscending()
        {
            DataGridViewColumn sortColumn = dgvFunds.Columns[2];
            System.ComponentModel.ListSortDirection direction = System.ComponentModel.ListSortDirection.Ascending;
            dgvFunds.Sort(sortColumn, direction);
        }

        private void btnSortUp_Click(object sender, EventArgs e)
        {
            if (dgvFunds.Rows.Count == 0)
                return;

            int index = dgvFunds.CurrentRow.Index;
            Guid relationalFundsPlansId = new Guid(dgvFunds.Rows[index].Cells[0].Value.ToString());

            int oldOrdinal;

            try
            {
                oldOrdinal = Int32.Parse(dgvFunds.Rows[index].Cells[2].Value.ToString());
            }
            catch
            {
                oldOrdinal = -1;
            }

            if (index == 0 || oldOrdinal <= 0)
            {
                dgvFunds.Rows[index].Cells[2].Value = DBNull.Value;

                try
                {
                    ISP.Business.Entities.Relational_Funds_Plans.UpdateOrdinal(relationalFundsPlansId, frmMain_Parent.CurrentUser.UserId, null);
                }
                catch(Exception ex)
                {
                    frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
                }
            }
            else
            {
                int newOrdinal = oldOrdinal - 1;
                dgvFunds.Rows[index].Cells[2].Value = newOrdinal;

                try
                {
                    ISP.Business.Entities.Relational_Funds_Plans.UpdateOrdinal(relationalFundsPlansId, frmMain_Parent.CurrentUser.UserId, newOrdinal);
                }
                catch (Exception ex)
                {
                    frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
                }
            }

            SortFundDataGridViewAscending();
            SelectRowWithGuid(relationalFundsPlansId);
        }

        private void btnSortDown_Click(object sender, EventArgs e)
        {
            if (dgvFunds.Rows.Count == 0)
                return;

            int index = dgvFunds.CurrentRow.Index;
            Guid relationalFundsPlansId = new Guid(dgvFunds.Rows[index].Cells[0].Value.ToString());

            int oldOrdinal;
            Int32.TryParse(dgvFunds.Rows[index].Cells[2].Value.ToString(), out oldOrdinal);

            if (index == dgvFunds.Rows.Count || oldOrdinal >= dgvFunds.Rows.Count)
                return;

            int newOrdinal = oldOrdinal + 1;
            dgvFunds.Rows[index].Cells[2].Value = newOrdinal;

            ISP.Business.Entities.Relational_Funds_Plans.UpdateOrdinal(relationalFundsPlansId, frmMain_Parent.CurrentUser.UserId, newOrdinal);

            SortFundDataGridViewAscending();
            SelectRowWithGuid(relationalFundsPlansId);
        }

        private void btnSaveFund_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFundDetails();
                MessageBox.Show("Record successfully saved!", "Success!", MessageBoxButtons.OK);
                UnsavedChangesFund = false;
            }
            catch (Exception ex)
            {
                frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
            }
        }

        private void btnOpenParHistory_Click(object sender, EventArgs e)
        {
            if (dgvFunds.DataSource == null || dgvFunds.Rows.Count == 0)
                return;

            int index = dgvFunds.CurrentRow.Index;
            Guid fundId = new Guid(dgvFunds.Rows[index].Cells[1].Value.ToString());
            Guid planId = new Guid(((Utilities.ListItem)cboSelectedPlan.SelectedItem).HiddenValue);
            Presentation.Forms.frmProbationAnalysis _frmProbationAnalysis = new Presentation.Forms.frmProbationAnalysis(frmMain_Parent, fundId, planId);
        }

        private void cboIpsReturn1Yr_TextChanged(object sender, EventArgs e)
        {
            UnsavedChangesIps = true;
        }

        private void cboIsMonitored_TextChanged(object sender, EventArgs e)
        {
            UnsavedChangesFund = true;
        }
	}
}
