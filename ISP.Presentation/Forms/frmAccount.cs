using DataIntegrationHub.Business.Entities;

using ISP.Business.Entities;
using ISP.Presentation;
using ISP.Presentation.Utilities;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
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
        public Relational_Funds_Plans CurrentRelational_Funds_Plans;
        public PlanDetail CurrentPlanDetail;
        public Observations CurrentObservation;

        public frmAccount(frmMain mf, Guid accountId, FormClosedEventHandler Close = null)
        {
            frmSplashScreen ss = new frmSplashScreen();
            ss.Show();
            Application.DoEvents();

            InitializeComponent();

            frmMain_Parent = mf;

            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.pnlSummaryTabHeader);
            controlsToMove.Add(this.pnlInvestmentTabHeader);
            controlsToMove.Add(this.pnlObservationsTabHeader);
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

            foreach (DataRow dr in PlanDetail.GetAssociatedFromAccount(accountId).Rows)
            {
                cboSelectedPlan.Items.Add(new ListItem(dr["Name"].ToString(), dr["ID"].ToString()));
            }

            if (cboSelectedPlan.Items.Count > 0)
                cboSelectedPlan.SelectedIndex = 0;

            if (txtPrimaryContactName.Text == "" || txtPrimaryContactName.Text == null)
                txtPrimaryContactName.Cursor = System.Windows.Forms.Cursors.Arrow;

            cboBenchMarkSecondary.Items.Clear();

            cboBenchMarkSecondary.Items.Add(new ListItem("No Instructions On File", null));

            foreach (DataRow dr in Benchmarks.Get().Rows)
            {
                cboBenchMarkSecondary.Items.Add(new ListItem(dr["FundName"].ToString(), dr["FundID"].ToString()));
            }

            LoadAssetClassCbo();

            ss.Close();
            this.Show();
		}

        private Guid PlanId;
        private Guid _relationalFundsPlansId;
        private Guid? benchMarkPrimaryId;
        private Guid? benchMarkSecondaryId;

        /// <summary>
        /// Indicates whether the IPS Monitoring Criteria section of the form has any unsaved changes.
        /// </summary>
        private bool UnsavedChangesIps = false;

        /// <summary>
        /// Indicates whether the Selected Fund section of the form has any unsaved changes.
        /// </summary>
        private bool UnsavedChangesFund = false;

        /// <summary>
        /// Indicates whether the typical behaviour associated with the event SelectedIndexChanged in <see cref="cboSelectedPlan"/>
        /// should be ignored.
        /// </summary>
        /// <remarks>
        /// This is a member used for reverting behaviour on the form.
        /// </remarks>
        private bool CancelSelectedPlanCboIndexChanged = false;

        /// <summary>
        /// Indicates whether the typical behaviour associated with the event SelectedIndexChanged in <see cref="cboPlanFundViews"/>
        /// should be ignored.
        /// </summary>
        /// <remarks>
        /// This is a member used for reverting behaviour on the form.
        private bool CancelSelectedPlanFundCboIndexChanged = false;

        /// <summary>
        /// Indicates whether the typical behaviour associated with the event CellEnter in <see cref="cboPlanFundViews"/>
        /// should be ignored.
        /// </summary>
        /// <remarks>
        /// This is a member used for reverting behaviour on the form.
        private bool CancelFundsDgvCellEnter = false;

        /// <summary>
        /// Filters out a message before it is dispatched.
        /// </summary>
        /// <param name="m">The message to be dispatched. You cannot modify this message.</param>
        /// <returns>
        /// true to filter the message and stop it from being dispatched; false to allow the message to continue to the next filter or control.
        /// </returns>
        /// <remarks>
        /// Use <see cref="PreFilterMessage"/> to filter out a message before it is dispatched to a control or form.
        /// For example, to stop the Click event of a Button control from being dispatched to the control, you implement
        /// the <see cref="PreFilterMessage"/> method and return a true value when the Click message occurs. You can
        /// also use this method to perform code work that you might need to do before the message is dispatched.
        /// </remarks>
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

		private void btnOpenFund_Click(object sender, EventArgs e)
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

        private void LoadAssetClassCbo()
        {
            cboAssetClass.Items.Clear();

            cboAssetClass.Items.Add("");

            foreach (DataRow dr in StringMap.GetAssociatedFromTableColumn("Funds", "AssetClassId").Rows)
            {
                cboAssetClass.Items.Add(new ListItem(dr["Name"].ToString(), dr["StringMapId"].ToString()));
            }
        }

        private void SelectBenchmarkPrimary()
        {
            Forms.frmSelectRecord.RecordType selectType = Forms.frmSelectRecord.RecordType.Fund;
            DataTable dataTable = Fund.GetByFundName();
            Fund fund = new Fund(CurrentRelational_Funds_Plans.FundId);
            frmSelectRecord frmSelectFund = new frmSelectRecord(frmMain_Parent, selectType, fund, dataTable);
            frmSelectFund.RecordSelected += frmSelectFund_BenchmarkPrimarySelected;
        }

        private void frmSelectFund_BenchmarkPrimarySelected(object sender, EventArgs e)
        {
            Guid fundId = (Guid)sender;
            CurrentRelational_Funds_Plans.BenchMarkPrimary = fundId;

            Fund fund = new Fund(fundId);
            lblSelectedBenchmarkPrimary.Text = fund.FundName;

            int index = dgvFunds.CurrentRow.Index;
            _relationalFundsPlansId = new Guid(dgvFunds.Rows[index].Cells[0].Value.ToString());
            SetFundFields(CurrentRelational_Funds_Plans, dgvFunds.Rows[index].Cells[4].Value.ToString());
        }

        public void loadObservationFields()
        {
            comboBox9.Items.Clear();
            comboBox10.Items.Clear();

            foreach (DataRow dr in TimeTable.GetPast10Years().Rows)
            {
                comboBox9.Items.Add(new ListItem(dr["Month"].ToString(), dr["TimeTableId"].ToString()));
            }

            foreach (User _user in User.ActiveUsers())
            {
                comboBox10.Items.Add(new ListItem(_user.FullName, _user.UserId.ToString()));
            }
        }

        private void savePlanDetails()
        {
            if (PlanId == null || cboSelectedPlan.SelectedIndex == -1)
            {
                return;
            }

            decimal? return1Yr = null;
            decimal? return3Yr = null;
            decimal? risk3Yr = null;
            decimal? expenseRatio = null;
            SqlBoolean? trackManagers = null;

            Guid userId = frmMain_Parent.CurrentUser.UserId;

            if (String.IsNullOrEmpty(txtExpenseRatio.Text) == false)
            {
                Decimal decText;

                try
                {
                    decText = Decimal.Parse(txtExpenseRatio.Text);
                }
                catch
                {
                    MessageBox.Show("Expense Ratio is not in a number format.", "Error");
                    txtExpenseRatio.Select();
                    return;
                }

                expenseRatio = decText;
            }

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
            {
                trackManagers = SqlBoolean.True;
            }
            else if (cboTrackManagers.SelectedIndex == 2)
            {
                trackManagers = SqlBoolean.False;
            }

            ISP.Business.Entities.PlanDetail plan = new ISP.Business.Entities.PlanDetail(PlanId);
            CurrentPlanDetail.ReturnAllowance1Yr = return1Yr;
            CurrentPlanDetail.ReturnAllowance3Yr = return3Yr;
            CurrentPlanDetail.RiskAllowance3Yr = risk3Yr;
            CurrentPlanDetail.ExpenseRatio = expenseRatio;
            CurrentPlanDetail.TrackManagerChanges = trackManagers;
            CurrentPlanDetail.SaveRecordToDatabase(userId);
        }

        private void SaveFundDetails()
        {
            if (cboSelectedPlan.SelectedIndex != -1 && _relationalFundsPlansId != null)
            {
                Guid relational_Funds_PlansId = _relationalFundsPlansId;
                Guid userId = frmMain_Parent.CurrentUser.UserId;

                Guid? analystId = null;
                if (cboAnalyst.SelectedIndex != -1 && cboAnalyst.SelectedIndex != 0)
                {
                    analystId = new Guid(((Utilities.ListItem)cboAnalyst.SelectedItem).HiddenValue); ;
                }

                Guid? benchMarkSecondaryId = null;
                if (cboBenchMarkSecondary.SelectedIndex != -1 && cboBenchMarkSecondary.SelectedIndex != 0)
                {
                    benchMarkSecondaryId = new Guid(((Utilities.ListItem)cboBenchMarkSecondary.SelectedItem).HiddenValue);
                }

                Guid? assetClassId = null;
                if (cboAssetClass.SelectedIndex != -1 && cboAssetClass.SelectedIndex != 0)
                {
                    assetClassId = new Guid(((Utilities.ListItem)cboAssetClass.SelectedItem).HiddenValue);
                }

                bool? isMonitored = null;
                if (cboIsMonitored.Text.ToUpper() == "TRUE")
                {
                    isMonitored = true;
                }
                else if (cboIsMonitored.Text.ToUpper() == "FALSE")
                {
                    isMonitored = false;
                }

                bool? isPerformanceCalculated = null;
                if (cboIsPerformanceCalculated.Text.ToUpper() == "TRUE")
                {
                    isPerformanceCalculated = true;
                }
                else if (cboIsPerformanceCalculated.Text.ToUpper() == "FALSE")
                {
                    isPerformanceCalculated = false;
                }

                try
                {
                    StringParser.Parse(txtDateAdded.Text, out CurrentRelational_Funds_Plans.DateAdded);
                }
                catch
                {
                    MessageBox.Show("Date Added field is not in a recognizable date format. Please correct and try again.", "Error");
                    return;
                }
                
                try
                {
                    StringParser.Parse(txtDateRemoved.Text, out CurrentRelational_Funds_Plans.DateRemoved);
                }
                catch
                {
                    MessageBox.Show("Date Removed field is not in a recognizable date format. Please correct and try again.", "Error");
                    return;
                }
                
                try
                {
                    StringParser.Parse(txtAssetValue.Text.Replace("$", ""), out CurrentRelational_Funds_Plans.AssetValue);
                }
                catch
                {
                    MessageBox.Show("Asset Value field is not in a recognizable money/decimal format. Please correct and try again.", "Error");
                    return;
                }
                
                try
                {
                    StringParser.Parse(txtAssetValueAsOf.Text, out CurrentRelational_Funds_Plans.AssetValueAsOf);
                }
                catch
                {
                    MessageBox.Show("Asset Value As Of field is not in a recognizable date format. Please correct and try again.", "Error");
                    return;
                }

                try
                {
                    StringParser.Parse(txtOrdinal.Text, out CurrentRelational_Funds_Plans.Ordinal);
                }
                catch
                {
                    MessageBox.Show("Ordinal field is not in a recognizable integer format. Please correct and try again.", "Error");
                    return;
                }

                if (CurrentRelational_Funds_Plans.AssetValue != null && CurrentRelational_Funds_Plans.AssetValueAsOf == null)
                {
                    MessageBox.Show("Asset Value As Of cannot be blank. Please correct and try again.", "Error");
                    return;
                }

                CurrentRelational_Funds_Plans.BenchMarkSecondary = benchMarkSecondaryId;
                CurrentRelational_Funds_Plans.AssetClassId = assetClassId;
                CurrentRelational_Funds_Plans.AnalystId = analystId;
                CurrentRelational_Funds_Plans.IsMonitored = isMonitored;
                CurrentRelational_Funds_Plans.IsPerformanceCalculated = isPerformanceCalculated;
                CurrentRelational_Funds_Plans.StateCode = cboStateCode.SelectedIndex;
                CurrentRelational_Funds_Plans.SaveRecordToDatabase(userId);
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

            foreach (DataRow dr in Observations.GetAssociatedFromAccount(CurrentAccount.AccountId).Rows)
            {
                if (!String.IsNullOrWhiteSpace(dr["OwnerId"].ToString()))
                {
                    User _user = new User(new Guid(dr["OwnerId"].ToString()));
                    string s = dr["TimeTableValue"].ToString() + " - " + _user.FullName;
                    comboBox8.Items.Add(new ListItem(s, dr["ObservationId"].ToString()));
                }
                else
                {
                    string s = dr["TimeTableValue"].ToString();
                    comboBox8.Items.Add(new ListItem(s, dr["ObservationId"].ToString()));
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
            label.BackColor = System.Drawing.Color.Transparent;
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

            // We have to refresh ComboBoxes because they don't draw well after performing this function.
            foreach (ComboBox comboBox in GetAll(this, typeof(ComboBox)))
            {
                comboBox.Refresh();
            }

            Application.DoEvents();
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
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
            label.BackColor = System.Drawing.Color.Transparent;
        }

        /// <summary>
        /// Reverts the current cell in <see cref="dgvFunds"/> to the previously selected current cell without invoking the
        /// usual behaviour associated with it's CellEnter event.
        /// </summary>
        private void RevertDgvFundCellFocus()
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
        }

        private void dgvFunds_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (UnsavedChangesFund)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes to the details of the selected fund in the current plan. "
                    + "Continuing will cause you to lose those changes. Are you sure you wish to continue?", "Attention", MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes)
                {
                    RevertDgvFundCellFocus();
                    return;
                }
            }

            if (PlanId != null && cboSelectedPlan.SelectedIndex != -1 && !CancelFundsDgvCellEnter)
            {
                int index = dgvFunds.CurrentRow.Index;
                _relationalFundsPlansId = new Guid(dgvFunds.Rows[index].Cells[0].Value.ToString());
                CurrentRelational_Funds_Plans = new Relational_Funds_Plans(_relationalFundsPlansId);
                SetFundFields(CurrentRelational_Funds_Plans, dgvFunds.Rows[index].Cells[4].Value.ToString());

                UnsavedChangesFund = false;
            }
        }

        private void SelectFundInFundsDgv(Guid relational_Funds_PlansId)
        {
            foreach (DataGridViewRow dataRow in dgvFunds.Rows)
            {
                if (new Guid(dataRow.Cells["Relational_Funds_PlansId"].Value.ToString()) == relational_Funds_PlansId)
                {
                    dgvFunds.CurrentCell = dgvFunds.Rows[dataRow.Index].Cells["Ordinal"];
                }
            }
        }

        private void SetFundFields(Relational_Funds_Plans relational_Funds_Plans, string fundName)
        {
            lblRecordSaved.Visible = false;

            lblSelectedBenchmarkPrimary.Text = fundName;

            if (relational_Funds_Plans.AssetValue != null)
            {
                txtAssetValue.Text = ((decimal)relational_Funds_Plans.AssetValue).ToString("C2");
            }
            else
            {
                txtAssetValue.Text = null;
            }

            if (relational_Funds_Plans.AssetValueAsOf != null)
            {
                txtAssetValueAsOf.Text = ((DateTime)relational_Funds_Plans.AssetValueAsOf).ToString("MM/dd/yyyy");
            }
            else
            {
                txtAssetValueAsOf.Text = null;
            }

            if (relational_Funds_Plans.AssetClassId != null)
            {
                StringMap assetClass = new StringMap((Guid)relational_Funds_Plans.AssetClassId);
                cboAssetClass.Text = assetClass.Value;
            }
            else
            {
                cboAssetClass.SelectedIndex = -1;
            }

            if (relational_Funds_Plans.DateAdded != null)
            {
                txtDateAdded.Text = ((DateTime)relational_Funds_Plans.DateAdded).ToString("MM/dd/yyyy");
            }
            else
            {
                txtDateAdded.Text = null;
            }

            if (relational_Funds_Plans.DateRemoved != null)
            {
                txtDateRemoved.Text = ((DateTime)relational_Funds_Plans.DateRemoved).ToString("MM/dd/yyyy");
            }
            else
            {
                txtDateRemoved.Text = null;
            }

            if (relational_Funds_Plans.BenchMarkPrimary != null)
            {
                Fund benchMarkPrimary = new Fund((Guid)relational_Funds_Plans.BenchMarkPrimary);
                lblBenchmarkPrimary.Text = benchMarkPrimary.FundName;
            }
            else
            {
                lblBenchmarkPrimary.Text = "Select a fund...";
            }

            if (relational_Funds_Plans.BenchMarkSecondary != null)
            {
                Fund benchMarkSecondary = new Fund((Guid)relational_Funds_Plans.BenchMarkSecondary);
                cboBenchMarkSecondary.Text = benchMarkSecondary.FundName;
            }
            else
            {
                cboBenchMarkSecondary.Text = "No Instructions On File";
            }

            if (relational_Funds_Plans.AnalystId != null)
            {
                User analyst = new User((Guid)relational_Funds_Plans.AnalystId);
                cboAnalyst.Text = analyst.FullName;
            }
            else
            {
                cboAnalyst.SelectedIndex = -1;
            }

            if (relational_Funds_Plans.IsMonitored == null)
            {
                cboIsMonitored.SelectedIndex = 0;
            }
            else if ((SqlBoolean)relational_Funds_Plans.IsMonitored == SqlBoolean.False)
            {
                cboIsMonitored.SelectedIndex = 2;
            }
            else if ((SqlBoolean)relational_Funds_Plans.IsMonitored == SqlBoolean.True)
            {
                cboIsMonitored.SelectedIndex = 1;
            }

            if (relational_Funds_Plans.IsPerformanceCalculated == null)
            {
                cboIsPerformanceCalculated.SelectedIndex = 0;
            }
            else if ((SqlBoolean)relational_Funds_Plans.IsPerformanceCalculated == SqlBoolean.False)
            {
                cboIsPerformanceCalculated.SelectedIndex = 2;
            }
            else if ((SqlBoolean)relational_Funds_Plans.IsPerformanceCalculated == SqlBoolean.True)
            {
                cboIsPerformanceCalculated.SelectedIndex = 1;
            }

            if (relational_Funds_Plans.Ordinal != null)
            {
                txtOrdinal.Text = relational_Funds_Plans.Ordinal.ToString();
            }
            else
            {
                txtOrdinal.Text = null;
            }

            if (relational_Funds_Plans.StateCode == 0)
            {
                cboStateCode.Text = "Active";
            }
            else
            {
                cboStateCode.Text = "Inactive";
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

        private void txtPrimaryContactEmail_DoubleClick(object sender, EventArgs e)
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
                LoadFundsDgv();

                Guid planId = new Guid(((Utilities.ListItem)cboSelectedPlan.SelectedItem).HiddenValue);

                if (!PlanDetail.IsExistingRecord(planId))
                {
                    PlanDetail.InsertNewPlan(planId, frmMain_Parent.CurrentUser.UserId);
                }

                CurrentPlanDetail = new PlanDetail(planId);

                if (CurrentPlanDetail.ExpenseRatio != null)
                    txtExpenseRatio.Text = ((decimal)CurrentPlanDetail.ExpenseRatio).ToString("#.##");
                else
                    txtExpenseRatio.Text = String.Empty;

                if (CurrentPlanDetail.ReturnAllowance1Yr != null)
                    cboIpsReturn1Yr.Text = ((int)(CurrentPlanDetail.ReturnAllowance1Yr * 100)).ToString() + "%";
                else
                    cboIpsReturn1Yr.SelectedIndex = 0;

                if (CurrentPlanDetail.ReturnAllowance3Yr != null)
                    cboIpsReturn3Yr.Text = ((int)(CurrentPlanDetail.ReturnAllowance3Yr * 100)).ToString() + "%";
                else
                    cboIpsReturn3Yr.SelectedIndex = 0;

                if (CurrentPlanDetail.RiskAllowance3Yr != null)
                    cboIpsRisk3Yr.Text = ((int)(CurrentPlanDetail.RiskAllowance3Yr * 100)).ToString() + "%";
                else
                    cboIpsRisk3Yr.SelectedIndex = 0;

                if (CurrentPlanDetail.TrackManagerChanges == null)
                {
                    cboTrackManagers.SelectedIndex = 0;
                }
                else if ((SqlBoolean)CurrentPlanDetail.TrackManagerChanges == SqlBoolean.True)
                {
                    cboTrackManagers.SelectedIndex = 1;
                }
                else if ((SqlBoolean)CurrentPlanDetail.TrackManagerChanges == SqlBoolean.False)
                {
                    cboTrackManagers.SelectedIndex = 2;
                }

                cboAnalyst.Items.Clear();
                cboAnalyst.Items.Add(new ListItem("", null));

                foreach (User _user in User.ActiveUsers())
                {
                    cboAnalyst.Items.Add(new ListItem(_user.FullName, _user.UserId.ToString()));
                }

                lblTotalPlanValue.Text = "Total plan value: " + CurrentPlanDetail.TotalAssets().ToString("C2");

                UnsavedChangesIps = false;
            }
        }

        private void cboBenchMarkSecondary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBenchMarkSecondary.SelectedIndex != -1)
            {
                if (((Utilities.ListItem)cboBenchMarkSecondary.SelectedItem).HiddenValue != null)
                {
                    benchMarkSecondaryId = new Guid(((Utilities.ListItem)cboBenchMarkSecondary.SelectedItem).HiddenValue);
                }
                else
                {
                    benchMarkSecondaryId = null;
                }
            }
        }

        private void btnAddFund_Click(object sender, EventArgs e)
        {
            frmSelectRecord.RecordType recordType = frmSelectRecord.RecordType.Fund;
            DataTable dataTable = Fund.GetAllTickers();
            frmSelectRecord frm = new frmSelectRecord(frmMain_Parent, recordType, cboSelectedPlan.Text, dataTable);
            frm.RecordSelected += frmSelectRecord_RecordSelected;
        }

        private void frmSelectRecord_RecordSelected(object sender, EventArgs e)
        {
            Guid fundId = (Guid)sender;
            Guid planId = new Guid(((Utilities.ListItem)cboSelectedPlan.SelectedItem).HiddenValue);
            Guid userId = frmMain_Parent.CurrentUser.UserId;

            CurrentRelational_Funds_Plans = new Relational_Funds_Plans();
            CurrentRelational_Funds_Plans.FundId = fundId;
            CurrentRelational_Funds_Plans.PlanId = planId;
            CurrentRelational_Funds_Plans.SaveRecordToDatabase(userId);

            LoadFundsDgv();
        }
        
        private void LoadFundsDgv()
        {
            if (cboSelectedPlan.SelectedIndex != -1)
            {
                if (cboPlanFundViews.SelectedIndex == -1)
                {
                    cboPlanFundViews.SelectedIndex = 0;
                }

                if (cboPlanFundViews.Text == "Active Associated Funds")
                {
                    ClearAllFundFields();

                    PlanId = new Guid(((Utilities.ListItem)cboSelectedPlan.SelectedItem).HiddenValue);
                    dgvFunds.DataSource = Fund.GetActiveAssociatedFromPlan(PlanId);
                    dgvFunds.Columns["Relational_Funds_PlansId"].Visible = false;
                    dgvFunds.Columns["FundId"].Visible = false;
                    dgvFunds.Columns["Ordinal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvFunds.Columns["Ticker"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvFunds.Columns["Fund Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else if (cboPlanFundViews.Text == "Inactive Associated Funds")
                {
                    ClearAllFundFields();

                    PlanId = new Guid(((Utilities.ListItem)cboSelectedPlan.SelectedItem).HiddenValue);
                    dgvFunds.DataSource = Fund.GetInactiveAssociatedFromPlan(PlanId);
                    dgvFunds.Columns["Relational_Funds_PlansId"].Visible = false;
                    dgvFunds.Columns["FundId"].Visible = false;
                    dgvFunds.Columns["Ordinal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvFunds.Columns["Ticker"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvFunds.Columns["Fund Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private void ClearAllFundFields()
        {
            lblSelectedBenchmarkPrimary.Text = "Select a fund";
            cboIsMonitored.SelectedIndex = -1;
            cboIsPerformanceCalculated.SelectedIndex = -1;
            lblBenchmarkPrimary.Text = "Select a fund...";
            cboBenchMarkSecondary.SelectedIndex = -1;
            txtDateAdded.Text = null;
            txtDateRemoved.Text = null;
            txtAssetValue.Text = null;
            txtAssetValueAsOf.Text = null;
            cboAssetClass.SelectedIndex = -1;
            txtOrdinal.Text = null;
            cboAnalyst.SelectedIndex = -1;
            cboStateCode.SelectedIndex = -1;

            UnsavedChangesFund = false;
        }

        private void btnRemoveFund_Click(object sender, EventArgs e)
        {
            if (dgvFunds.CurrentRow == null)
            {
                return;
            }

            int index = dgvFunds.CurrentRow.Index;

            string planName = cboSelectedPlan.Text;
            string fundName = dgvFunds.Rows[index].Cells[3].Value.ToString();

            DialogResult result = MessageBox.Show("Are you sure you wish to delete " + fundName + " from " + planName + "? This action cannot be undone!", "Attention", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Guid relational_Funds_PlansId = new Guid(dgvFunds.Rows[index].Cells[0].Value.ToString());
                Guid userId = frmMain_Parent.CurrentUser.UserId;

                CurrentRelational_Funds_Plans = new Relational_Funds_Plans(relational_Funds_PlansId);
                CurrentRelational_Funds_Plans.DeleteRecordFromDatabase();
            }

            LoadFundsDgv();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.Text == "< New Observation >")
            {
                return;
            }

            Guid id = new Guid(((ListItem)comboBox8.SelectedItem).HiddenValue);
            CurrentObservation = new Observations(id);

            string _ownerName = null;
            User modifiedBy = new User((Guid)CurrentObservation.ModifiedBy);
            User createdBy = new User((Guid)CurrentObservation.CreatedBy);
            TimeTable timeTable = new TimeTable(CurrentObservation.TimeTableId);

            if (CurrentObservation.OwnerId != null)
            {
                User owner = new User((Guid)CurrentObservation.OwnerId);
                _ownerName = owner.FullName;
            }

            richTextBox4.Text = CurrentObservation.Text;
            comboBox9.Text = timeTable.StartDate.ToString("MMMM yyyy");
            comboBox10.Text = _ownerName;
            label50.Text = modifiedBy.FullName;
            label51.Text = CurrentObservation.ModifiedOn.ToString();
            label54.Text = createdBy.FullName;
            label55.Text = CurrentObservation.CreatedOn.ToString();
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
            string text = richTextBox4.Text;

            int selectedIndex = comboBox8.SelectedIndex;

            if (comboBox8.Text == "< New Observation >") //Insert new observation
            {
                CurrentObservation = new Observations();
                CurrentObservation.TimeTableId = timeTableId;
                CurrentObservation.AccountId = CurrentAccount.AccountId;
                CurrentObservation.OwnerId = ownerId;
                CurrentObservation.Text = text;
                CurrentObservation.SaveRecordToDatabase(frmMain_Parent.CurrentUser.UserId);
            }
            else //update existing observation
            {
                CurrentObservation.TimeTableId = timeTableId;
                CurrentObservation.AccountId = CurrentAccount.AccountId;
                CurrentObservation.OwnerId = ownerId;
                CurrentObservation.Text = text;
                CurrentObservation.SaveRecordToDatabase(frmMain_Parent.CurrentUser.UserId);
            }

            loadObservations();
            comboBox8.SelectedIndex = selectedIndex;

            MessageBox.Show("Observation saved successfully!", "Success!", MessageBoxButtons.OK);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (((Utilities.ListItem)comboBox8.SelectedItem).HiddenValue == null)
            {
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you're wish to remove the current observation? This action is not permanent.", "Attention", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                Guid id = new Guid(((Utilities.ListItem)comboBox8.SelectedItem).HiddenValue);
                Observations observation = new Observations(id);
                observation.SetInactive();
                observation.SaveRecordToDatabase(frmMain_Parent.CurrentUser.UserId);

                loadObservations();
            }
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
                    Relational_Funds_Plans.UpdateOrdinal(relationalFundsPlansId, frmMain_Parent.CurrentUser.UserId, null);
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
                    Relational_Funds_Plans.UpdateOrdinal(relationalFundsPlansId, frmMain_Parent.CurrentUser.UserId, newOrdinal);
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

            Relational_Funds_Plans.UpdateOrdinal(relationalFundsPlansId, frmMain_Parent.CurrentUser.UserId, newOrdinal);

            SortFundDataGridViewAscending();
            SelectRowWithGuid(relationalFundsPlansId);
        }

        private void btnSaveFund_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFundDetails();
                Relational_Funds_Plans savedRecord = CurrentRelational_Funds_Plans;
                UnsavedChangesFund = false;
                LoadFundsDgv();
                SelectFundInFundsDgv(savedRecord.Id);
                lblRecordSaved.Visible = true;
            }
            catch (Exception ex)
            {
                frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
            }
        }

        private void btnOpenParHistory_Click(object sender, EventArgs e)
        {
            if (dgvFunds.DataSource == null || dgvFunds.Rows.Count == 0)
            {
                return;
            }

            int index = dgvFunds.CurrentRow.Index;
            Guid fundId = new Guid(dgvFunds.Rows[index].Cells[1].Value.ToString());
            Guid planId = new Guid(((Utilities.ListItem)cboSelectedPlan.SelectedItem).HiddenValue);
            frmProbationAnalysis frmProbationAnalysis = new frmProbationAnalysis(frmMain_Parent, fundId, planId);
        }

        private void cboIpsReturn1Yr_TextChanged(object sender, EventArgs e)
        {
            UnsavedChangesIps = true;
        }

        private void cboIsMonitored_TextChanged(object sender, EventArgs e)
        {
            UnsavedChangesFund = true;
        }

        private void cboIsPerformanceCalculated_TextChanged(object sender, EventArgs e)
        {
            UnsavedChangesFund = true;
        }

        private void cboPlanFundViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UnsavedChangesFund && !CancelSelectedPlanFundCboIndexChanged)
            {
                DialogResult result = MessageBox.Show("There are unsaved fund detail changes. Are you sure you wish to continue?", "Attention", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    LoadFundsDgv();
                }
                else
                {
                    CancelSelectedPlanFundCboIndexChanged = true;

                    if (cboPlanFundViews.SelectedIndex == 0)
                    {
                        cboPlanFundViews.SelectedIndex = 1;
                    }
                    else if (cboPlanFundViews.SelectedIndex == 1)
                    {
                        cboPlanFundViews.SelectedIndex = 0;
                    }

                    CancelSelectedPlanFundCboIndexChanged = false;
                }
            }
            else if (!CancelSelectedPlanFundCboIndexChanged)
            {
                LoadFundsDgv();
            }
        }

        private void dgvFunds_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void lblToIpsMonitoringCriteria_Click(object sender, EventArgs e)
        {
            tabControlInvestments.SelectedTab = tabControlInvestments.TabPages["tabIpsMonitoringCriteria"];
            lblToIpsMonitoringCriteria.Visible = false;
            lblToFunds.Visible = true;
        }

        private void lblToFunds_Click(object sender, EventArgs e)
        {
            tabControlInvestments.SelectedTab = tabControlInvestments.TabPages["tabFunds"];
            lblToIpsMonitoringCriteria.Visible = true;
            lblToFunds.Visible = false;
        }

        private void lblToIpsMonitoringCriteria_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Font = new Font(label.Font.Name, label.Font.SizeInPoints, FontStyle.Bold | FontStyle.Underline);
        }

        private void lblToIpsMonitoringCriteria_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Font = new Font(label.Font.Name, label.Font.SizeInPoints, FontStyle.Bold);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            if (CurrentRelational_Funds_Plans.BenchMarkPrimary == null)
            {
                SelectBenchmarkPrimary();
            }
            else
            {
                Guid fundId = (Guid)CurrentRelational_Funds_Plans.BenchMarkPrimary;
                frmFund frmFund = new frmFund(frmMain_Parent, fundId);
            }
        }

        private void btnClearFund_Click(object sender, EventArgs e)
        {
            CurrentRelational_Funds_Plans.BenchMarkPrimary = null;
            UnsavedChangesFund = true;

            if (PlanId != null && cboSelectedPlan.SelectedIndex != -1 && !CancelFundsDgvCellEnter)
            {
                int index = dgvFunds.CurrentRow.Index;
                _relationalFundsPlansId = new Guid(dgvFunds.Rows[index].Cells[0].Value.ToString());
                SetFundFields(CurrentRelational_Funds_Plans, dgvFunds.Rows[index].Cells[4].Value.ToString());

                UnsavedChangesFund = false;
            }
        }
	}
}
