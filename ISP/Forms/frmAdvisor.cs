using ISP.Business.Entities;
using ISP.Presentation.Utilities;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ISP.Presentation.Forms
{
    public partial class frmAdvisor : Form, IMessageFilter
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

        private frmMain mf_parent;

        public frmAdvisor(frmMain mainForm, FormClosedEventHandler Close = null)
        {
            InitializeComponent();
            mf_parent = mainForm;

            LoadManagementRolesCbo();

            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            this.MouseWheel += new MouseEventHandler(pnlSummary_MouseWheel);

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.pnlFormHeader);
            controlsToMove.Add(this.pnlHeader);
            controlsToMove.Add(this.lblHeader);

            FormClosed += Close;
            tabMain.SelectedIndex = 0;

            AdvisorId = Guid.NewGuid();
            UserId = mainForm.CurrentUser.UserId;

            lblHeader.Text = "New Advisor";
            label1.Text = "Investment Services Program - New Advisor";

            DisableManagementArea();

            this.Show();
        }

        public frmAdvisor(frmMain frmMain_Parent, Guid advisorId, FormClosedEventHandler Close = null)
        {
            frmSplashScreen ss = new frmSplashScreen();
            ss.Show();
            Application.DoEvents();

            InitializeComponent();
            mf_parent = frmMain_Parent;

            LoadManagementRolesCbo();

            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            this.MouseWheel += new MouseEventHandler(pnlSummary_MouseWheel);

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.pnlFormHeader);
            controlsToMove.Add(this.pnlHeader);
            controlsToMove.Add(this.lblHeader);

            FormClosed += Close;
            tabMain.SelectedIndex = 0;

            AdvisorId = advisorId;
            UserId = frmMain_Parent.CurrentUser.UserId;

            try
            {
                UpdateResearchTypeCbo();
                LoadManagement();

                foreach (DataRow dr in ISP.Business.Entities.Advisors.GetAdvisorDetails(advisorId).Rows)
                {
                    decimal fixedIncome = -1;
                    decimal equity = -1;
                    decimal other = -1;

                    if (String.IsNullOrEmpty(dr["AssetsFixedIncome"].ToString()) == false)
                        Decimal.TryParse(dr["AssetsFixedIncome"].ToString(), out fixedIncome);

                    if (String.IsNullOrEmpty(dr["AssetsEquity"].ToString()) == false)
                        Decimal.TryParse(dr["AssetsEquity"].ToString(), out equity);

                    if (String.IsNullOrEmpty(dr["AssetsOther"].ToString()) == false)
                        Decimal.TryParse(dr["AssetsOther"].ToString(), out other);

                    lblHeader.Text = dr["Name"].ToString();
                    txtName.Text = dr["Name"].ToString();
                    Text = dr["Name"].ToString();
                    label1.Text = "Investment Services Program - " + dr["Name"].ToString();
                    txtFounded.Text = dr["CompanyFounded"].ToString();
                    txtPhilosophies.Text = dr["InvestmentPhilosophy"].ToString();
                    txtConflicts.Text = dr["InterestConflicts"].ToString();
                    txtRights.Text = dr["ShareHolderRights"].ToString();
                    txtCompensation.Text = dr["CompensationStructure"].ToString();
                    cboProfessional.Text = dr["IsCultureProfessional"].ToString();
                    cboTransparent.Text = dr["IsCultureTransparent"].ToString();
                    cboMoral.Text = dr["IsCultureMoralStandardsHigh"].ToString();
                    cboProprietary.Text = dr["IsResearchProprietary"].ToString();
                    cboQuantitative.Text = dr["IsResearchQuantitative"].ToString();
                    cboFundamental.Text = dr["IsResearchFundamental"].ToString();
                    cboResearchType.Text = dr["ResearchTypeIdName"].ToString();
                    txtSize.Text = dr["StaffSize"].ToString();
                    txtCredential.Text = dr["StaffCredentials"].ToString();
                    txtExperience.Text = dr["StaffExperience"].ToString();
                    txtAnalystRatio.Text = dr["AnalystRatio"].ToString();

                    if (fixedIncome != -1)
                        txtFixed.Text = fixedIncome.ToString("C");

                    if (equity != -1)
                        txtEquity.Text = equity.ToString("C");

                    if (other != -1)
                        txtOther.Text = other.ToString("C");
                }
            }
            catch (Exception ex)
            {
                frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
            }

            dgvFunds.DataSource = ISP.Business.Entities.Fund.GetAssociatedFromAdvisor(advisorId);
            dgvFunds.Columns[0].Visible = false;

            dgvMgrs.DataSource = ISP.Business.Entities.Manager.GetAssociatedFromAdvisor(advisorId);
            dgvMgrs.Columns[0].Visible = false;

            this.Show();
            ss.Close();
        }

        public Guid AdvisorId;
        public Guid UserId;
        private Guid? ManagerId;
        private Guid? FundId;

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

        private bool Save()
        {
            string Name = txtName.Text;
            int? CompanyFounded = null;
            string InvestmentPhilosophy = txtPhilosophies.Text;
            string InterestConflicts = txtConflicts.Text;
            string ShareholderRights = txtRights.Text;
            string CompensationStructure = txtCompensation.Text;
            SqlBoolean? IsCultureProfessional = null;
            SqlBoolean? IsCultureTransparent = null;
            SqlBoolean? IsCultureMoralStandardsHigh = null;
            SqlBoolean? IsResearchProprietary = null;
            SqlBoolean? IsResearchQuantitative = null;
            SqlBoolean? IsResearchFundamental = null;
            Guid? ResearchType = null;
            string StaffSize = txtSize.Text;
            string StaffCredentials = txtCredential.Text;
            string StaffExperience = txtExperience.Text;
            decimal? AnalystRatio = null;
            decimal? AssetsFixedIncome = null;
            decimal? AssetsEquity = null;
            decimal? AssetsOther = null;

            IsCultureProfessional = parseSqlBoolean(cboProfessional);
            IsCultureTransparent = parseSqlBoolean(cboTransparent);
            IsCultureMoralStandardsHigh = parseSqlBoolean(cboMoral);
            IsResearchProprietary = parseSqlBoolean(cboProprietary);
            IsResearchQuantitative = parseSqlBoolean(cboQuantitative);
            IsResearchFundamental = parseSqlBoolean(cboFundamental);

            if (!String.IsNullOrEmpty(((Utilities.ListItem)cboResearchType.SelectedItem).HiddenValue))
            {
                ResearchType = new Guid(((Utilities.ListItem)cboResearchType.SelectedItem).HiddenValue);
            }


            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("You must enter a name for the Advisor. Please fix and try again.", "Error", MessageBoxButtons.OK);
                txtName.Select();
                return false;
            }

            try
            {
                if (String.IsNullOrEmpty(txtFounded.Text) == false)
                {
                    CompanyFounded = int.Parse(txtFounded.Text);
                }
            }
            catch
            {
                MessageBox.Show("Error Saving: The field Company Founded is not an integer. Please fix and try again.", "Error", MessageBoxButtons.OK);
                txtFounded.Select();
                return false;
            }

            try
            {
                if (String.IsNullOrEmpty(txtAnalystRatio.Text) == false)
                {
                    AnalystRatio = decimal.Parse(txtAnalystRatio.Text);
                }
            }
            catch
            {
                MessageBox.Show("Error Saving: The field Analyst Ratio is not a decimal. Please fix and try again.", "Error", MessageBoxButtons.OK);
                txtAnalystRatio.Select();
                return false;
            }

            try
            {
                string txt = txtFixed.Text;

                if (txt.StartsWith("$"))
                {
                    txt = txt.Substring(1);
                }

                if (String.IsNullOrEmpty(txtFixed.Text) == false)
                {
                    AssetsFixedIncome = decimal.Parse(txt);
                }
            }
            catch
            {
                MessageBox.Show("Error Saving: The field Fixed Income is not a decimal. Please fix and try again.", "Error", MessageBoxButtons.OK);
                txtFixed.Select();
                return false;
            }

            try
            {
                string txt = txtEquity.Text;

                if (txt.StartsWith("$"))
                {
                    txt = txt.Substring(1);
                }

                if (String.IsNullOrEmpty(txtEquity.Text) == false)
                {
                    AssetsEquity = decimal.Parse(txt);
                }
            }
            catch
            {
                MessageBox.Show("Error Saving: The field Equity is not a decimal. Please fix and try again.", "Error", MessageBoxButtons.OK);
                txtEquity.Select();
                return false;
            }

            try
            {
                string txt = txtOther.Text;

                if (txt.StartsWith("$"))
                {
                    txt = txt.Substring(1);
                }

                if (String.IsNullOrEmpty(txtOther.Text) == false)
                {
                    AssetsOther = decimal.Parse(txt);
                }
            }
            catch
            {
                MessageBox.Show("Error Saving: The field Other is not a decimal. Please fix and try again.", "Error", MessageBoxButtons.OK);
                txtOther.Select();
                return false;
            }

            ISP.Business.Entities.Advisors.Update(AdvisorId, UserId, Name, CompanyFounded, InvestmentPhilosophy, InterestConflicts, ShareholderRights, CompensationStructure,
                IsCultureProfessional, IsCultureTransparent, IsCultureMoralStandardsHigh, IsResearchProprietary, IsResearchQuantitative, IsResearchFundamental,
                ResearchType, StaffSize, StaffCredentials, StaffExperience, AnalystRatio, AssetsFixedIncome, AssetsEquity, AssetsOther);

            MessageBox.Show("Record successfully saved");
            return true;
        }

        private SqlBoolean? parseSqlBoolean(ComboBox cbo)
        {
            if (cbo.SelectedIndex == -1 || String.IsNullOrEmpty(cbo.SelectedItem.ToString()))
            {
                return null;
            }
            else if (cbo.SelectedItem.ToString() == "Yes" || cbo.SelectedItem.ToString() == "True")
            {
                return new System.Data.SqlTypes.SqlBoolean(1);
            }
            else if (cbo.SelectedItem.ToString() == "No" || cbo.SelectedItem.ToString() == "False")
            {
                return new System.Data.SqlTypes.SqlBoolean(0);
            }
            else
            {
                throw new Exception("The Selected Item in the ComboBox Parameter does not have a supported value.");
            }
        }

        public void UpdateResearchTypeCbo()
        {
            cboResearchType.Items.Clear();
            cboResearchType.Items.Add(new ListItem("", ""));

            StringMap.ColumnValues columns = new StringMap.ColumnValues("Advisors", "ResearchType");

            foreach (StringMap _stringMap in columns.Details)
            {
                cboResearchType.Items.Add(new ListItem(_stringMap.Value, _stringMap.StringMapId.ToString()));
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

            Application.DoEvents();
        }

        private void pnlSummary_MouseWheel(object sender, MouseEventArgs e)
        {
            pnlSummary.Focus();
        }

        private void pnlSummary_Click(object sender, EventArgs e)
        {
            pnlSummary.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to save?", "Attention", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                Save();
                EnableManagementArea();
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to save?", "Attention", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                bool saveResult = Save();

                if (saveResult == true)
                {
                    this.Close();
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lblHeader.Text = txtName.Text;
        }

        private void label46_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 0;
        }

        private void label47_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 1;
        }

        private void label49_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 2;
        }

        private void dgvMgrs_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvMgrs.CurrentRow.Index;
            ManagerId = new Guid(dgvMgrs.Rows[index].Cells[0].Value.ToString());
            lblSelectedMgr.Text = dgvMgrs.Rows[index].Cells[1].Value.ToString();
        }

        private void dgvFunds_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvFunds.CurrentRow.Index;
            FundId = new Guid(dgvFunds.Rows[index].Cells[0].Value.ToString());
            lblSelectedFund.Text = dgvFunds.Rows[index].Cells[2].Value.ToString();
        }

        private void btnOpenMgr_Click(object sender, EventArgs e)
        {
            if (ManagerId == null)
            {
                MessageBox.Show("You have not selected a manager to open.", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Guid mgrId = new Guid(ManagerId.ToString());
                frmManager _frmManager = new frmManager(mf_parent);
                _frmManager.FormClosed += mf_parent.ManagerFormClosed;
            }
        }

        private void btnOpenFund_Click(object sender, EventArgs e)
        {
            if (FundId == null)
            {
                MessageBox.Show("You have not selected a fund to open.", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Guid fundId = new Guid(FundId.ToString());
                frmFund fundForm = new frmFund(mf_parent, fundId);
            }
        }

        public void DisableManagementArea()
        {
            lstMgmt.Enabled = false;
            btnMgmtNew.Enabled = false;
            btnMgmtUpdate.Enabled = false;
            btnMgmtDelete.Enabled = false;
            txtMgmt.Enabled = false;

            lstMgmtRoles.Enabled = false;
            btnMgmtRoleNew.Enabled = false;
            btnMgmtRoleUpdate.Enabled = false;
            btnMgmtRoleDelete.Enabled = false;
            cboMgmtRoles.Enabled = false;
        }

        public void EnableManagementArea()
        {
            lstMgmt.Enabled = true;
            btnMgmtNew.Enabled = true;
            btnMgmtUpdate.Enabled = true;
            btnMgmtDelete.Enabled = true;
            txtMgmt.Enabled = true;

            lstMgmtRoles.Enabled = true;
            btnMgmtRoleNew.Enabled = true;
            btnMgmtRoleUpdate.Enabled = true;
            btnMgmtRoleDelete.Enabled = true;
            cboMgmtRoles.Enabled = true;
        }

        public void LoadManagement()
        {
            lstMgmt.Items.Clear();
            foreach (DataRow dr in ISP.Business.Entities.AdvisorsManagement.GetAssociatedFromAdvisor(AdvisorId).Rows)
            {
                lstMgmt.Items.Add(new Utilities.ListItem(dr["FullName"].ToString(), dr["AdvisorsManagementId"].ToString()));
            }
        }

        public void LoadManagementRoles(Guid advisorManagementId)
        {
            lstMgmtRoles.Items.Clear();
            foreach (DataRow dr in ISP.Business.Entities.AdvisorsManagementRoles.GetAssociatedFromAdvisorsManagement(advisorManagementId).Rows)
            {
                lstMgmtRoles.Items.Add(new Utilities.ListItem(dr["Name"].ToString(), dr["AdvisorsManagementRoleId"].ToString()));
            }
        }

        private void btnMgmtUpdate_Click(object sender, EventArgs e)
        {
            if (lstMgmt.SelectedIndex == -1 || lstMgmt.SelectedItem == null)
            {
                MessageBox.Show("Error: No manager has been selected. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                return;
            }

            string fullName = txtMgmt.Text;
            Guid advisorManagementId = new Guid(((Utilities.ListItem)lstMgmt.SelectedItem).HiddenValue);

            ISP.Business.Entities.AdvisorsManagement.Update(advisorManagementId, mf_parent.CurrentUser.UserId, fullName);

            LoadManagement();
            txtMgmt.Text = null;
        }

        private void btnMgmtNew_Click(object sender, EventArgs e)
        {
            string fullName = txtMgmt.Text;
            ISP.Business.Entities.AdvisorsManagement.Insert(AdvisorId, mf_parent.CurrentUser.UserId, fullName);
            LoadManagement();
            txtMgmt.Text = null;
        }

        private void btnMgmtDelete_Click(object sender, EventArgs e)
        {
            if (lstMgmt.SelectedIndex == -1 || lstMgmt.SelectedItem == null)
            {
                MessageBox.Show("Error: No manager has been selected. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                return;
            }

            Guid advisorManagementId = new Guid(((Utilities.ListItem)lstMgmt.SelectedItem).HiddenValue);

            ISP.Business.Entities.AdvisorsManagement.Delete(advisorManagementId);

            LoadManagement();
        }

        private void lstMgmt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMgmt.SelectedIndex == -1)
            {
                btnMgmtUpdate.Enabled = false;
                return;
            }

            btnMgmtUpdate.Enabled = true;

            txtMgmt.Text = ((Utilities.ListItem)lstMgmt.SelectedItem).ToString();
            Guid advisorsManagementId = new Guid(((Utilities.ListItem)lstMgmt.SelectedItem).HiddenValue);

            cboMgmtRoles.SelectedIndex = -1;
            lstMgmtRoles.SelectedIndex = -1;

            LoadManagementRoles(advisorsManagementId);
        }

        private void LoadManagementRolesCbo()
        {
            cboMgmtRoles.Items.Clear();

            StringMap.ColumnValues _columnValues = new StringMap.ColumnValues("AdvisorsManagementRoles", "StringMapId");

            foreach (StringMap _stringMap in _columnValues.Details)
            {
                cboMgmtRoles.Items.Add(new ListItem(_stringMap.Value, _stringMap.StringMapId.ToString()));
            }
        }

        private void btnMgmtRoleUpdate_Click(object sender, EventArgs e)
        {
            if (lstMgmtRoles.SelectedIndex == -1 || lstMgmtRoles.SelectedItem == null)
            {
                MessageBox.Show("Error: No manager role has been selected. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                return;
            }

            Guid advisorsManagementId = new Guid(((Utilities.ListItem)lstMgmt.SelectedItem).HiddenValue);
            Guid advisorsManagementRoleId = new Guid(((Utilities.ListItem)lstMgmtRoles.SelectedItem).HiddenValue);
            Guid stringMapId = new Guid(((Utilities.ListItem)cboMgmtRoles.SelectedItem).HiddenValue);

            ISP.Business.Entities.AdvisorsManagementRoles.Update(advisorsManagementRoleId, mf_parent.CurrentUser.UserId, stringMapId);

            LoadManagementRoles(advisorsManagementId);

            cboMgmtRoles.SelectedIndex = -1;
            lstMgmtRoles.SelectedIndex = -1;
        }

        private void btnMgmtRoleNew_Click(object sender, EventArgs e)
        {
            Guid advisorsManagementId = new Guid(((Utilities.ListItem)lstMgmt.SelectedItem).HiddenValue);
            Guid stringMapId = new Guid(((Utilities.ListItem)cboMgmtRoles.SelectedItem).HiddenValue);

            ISP.Business.Entities.AdvisorsManagementRoles.Insert(advisorsManagementId, mf_parent.CurrentUser.UserId, stringMapId);

            LoadManagementRoles(advisorsManagementId);

            cboMgmtRoles.SelectedIndex = -1;
            lstMgmtRoles.SelectedIndex = -1;
        }

        private void btnMgmtRoleDelete_Click(object sender, EventArgs e)
        {
            if (lstMgmtRoles.SelectedIndex == -1 || lstMgmtRoles.SelectedItem == null)
            {
                MessageBox.Show("Error: No manager role has been selected. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                return;
            }

            Guid advisorsManagementId = new Guid(((Utilities.ListItem)lstMgmt.SelectedItem).HiddenValue);
            Guid advisorsManagementRoleId = new Guid(((Utilities.ListItem)lstMgmtRoles.SelectedItem).HiddenValue);

            ISP.Business.Entities.AdvisorsManagementRoles.Delete(advisorsManagementRoleId);

            LoadManagementRoles(advisorsManagementId);

            cboMgmtRoles.SelectedIndex = -1;
            lstMgmtRoles.SelectedIndex = -1;
        }

        private void lstMgmtRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMgmtRoles.SelectedIndex == -1 || lstMgmtRoles.SelectedItem == null)
            {
                btnMgmtRoleUpdate.Enabled = false;
                return;
            }

            btnMgmtRoleUpdate.Enabled = true;
        }

        private void dgvFunds_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (FundId == null)
            {
                MessageBox.Show("You have not selected a fund to open.", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Guid fundId = new Guid(FundId.ToString());
                frmFund fundForm = new frmFund(mf_parent, fundId);
            }
        }

        private void dgvMgrs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ManagerId == null)
            {
                MessageBox.Show("You have not selected a manager to open.", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Guid _managerId = new Guid(ManagerId.ToString());
                frmManager _frmManager = new frmManager(mf_parent, _managerId);
                _frmManager.FormClosed += mf_parent.ManagerFormClosed;
            }
        }
    }
}
