using ISP;
using ISP.Business.Entities;
using ISP.Presentation;
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
    public partial class frmManager : Form, IMessageFilter
    {
        #region IMessageFilter Members

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

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

        #endregion

        private frmMain frmMain_Parent;

        public Manager Manager;
        private Relational_Managers_Funds relationalManagersFunds;

        public Pagination paginationAdvisors;
        public Pagination paginationFunds;

        private int dgvFundsIndex;

        public frmManager(frmMain _frmMain)
        {
            InitializeComponent();

            #region IMessageFilter Methods

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.pnlFormHeader);
            controlsToMove.Add(this.pnlHeader);
            controlsToMove.Add(this.lblHeader);

            #endregion

            frmMain_Parent = _frmMain;

            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            ManagerId = null;

            PopulateManagerCredentialsCbo();
            PopulateFundRoleCbo();
            PopulatePersonalAssetsCbo();
            PopulateManagerCredentialsLst();
            PopulateManagerEducationList();

            tabMain.SelectedIndex = 0;

            this.Show();
        }

        public frmManager(frmMain _frmMain, Guid managerId)
        {
            frmSplashScreen _frmSplashScreen = new frmSplashScreen();
            _frmSplashScreen.Show();
            Application.DoEvents();

            InitializeComponent();

            #region IMessageFilter Methods

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.pnlFormHeader);
            controlsToMove.Add(this.pnlHeader);
            controlsToMove.Add(this.lblHeader);

            #endregion

            frmMain_Parent = _frmMain;

            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            ManagerId = managerId;

            PopulateManagerCredentialsCbo();
            PopulateFundRoleCbo();
            PopulatePersonalAssetsCbo();

            tabMain.SelectedIndex = 0;

            try
            {
                Manager = new Manager(managerId);
                lblHeader.Text = Manager.FullName;
                Text = Manager.FullName;
                txtFirstName.Text = Manager.FirstName;
                txtMiddleName.Text = Manager.MiddleName;
                txtLastName.Text = Manager.LastName;
                txtBiography.Text = Manager.Biography;
                txtResponsibilities.Text = Manager.PortfolioResponsibilities;
                txtBeganAsPm.Text = Manager.BecamePortfolioManagerYear;
                txtBeganAsAnalyst.Text = Manager.BecameAnalystYear;

                PopulateManagerCredentialsLst();
                PopulateManagerEducationList();

                paginationAdvisors = new Pagination(dgvAdvisors, Advisors.GetAssociatedFromManager((Guid)managerId));
                dgvAdvisors.Columns[0].Visible = false;

                paginationFunds = new Pagination(dgvFunds, Fund.GetAssociatedFromManager((Guid)managerId));
                dgvFunds.Columns[0].Visible = false;
                dgvFunds.Columns[1].Visible = false;
            }
            catch (Exception _exception)
            {
                frmError _frmError = new frmError(frmMain_Parent, _exception);
            }

            this.Show();
            _frmSplashScreen.Close();
        }

        public Guid? ManagerId = null;

        private bool isEditingEducation = false;

        public void PopulateFundRoleCbo()
        {
            cboFundRole.Items.Clear();

            StringMap.ColumnValues _columnValues = new StringMap.ColumnValues("Relational_Managers_Funds", "ManagerRoleId");

            cboFundRole.Items.Add(new ListItem("", ""));

            foreach (StringMap _stringMap in _columnValues.Details)
            {
                cboFundRole.Items.Add(new ListItem(_stringMap.Value, _stringMap));
            }
        }

        public void PopulatePersonalAssetsCbo()
        {
            cboPersonalAssets.Items.Clear();

            StringMap.ColumnValues _columnValues = new StringMap.ColumnValues("Relational_Managers_Funds", "PersonalAssets");

            cboPersonalAssets.Items.Add(new ListItem("", ""));

            foreach (StringMap _stringMap in _columnValues.Details)
            {
                cboPersonalAssets.Items.Add(new ListItem(_stringMap.Value, _stringMap));
            }
        }

        public void PopulateManagerCredentialsLst()
        {
            lstCredentials.Items.Clear();

            if (ManagerId != null)
            {
                ManagerCredential.AssociateDetails(Manager);

                foreach (ManagerCredential _managerCredential in Manager.Credentials)
                {
                    lstCredentials.Items.Add(new ListItem(_managerCredential.Name, _managerCredential));
                }

                lstCredentials.Enabled = true;
                lstCredentials.BackColor = System.Drawing.Color.White;
                cboCredential.Enabled = true;
                btnCredentialsNew.Enabled = true;
                btnCredentialsDelete.Enabled = true;
            }
            else
            {
                lstCredentials.Enabled = false;
                lstCredentials.BackColor = System.Drawing.SystemColors.Control;
                lstCredentials.Items.Add("The manager record must exist before associating credentials to it. Please save the record to complete this action.");
                cboCredential.Enabled = false;
                btnCredentialsNew.Enabled = false;
                btnCredentialsDelete.Enabled = false;
            }
        }

        private void PopulateManagerCredentialsCbo()
        {
            cboCredential.Items.Clear();

            StringMap.ColumnValues _columnValues = new StringMap.ColumnValues("ManagersCredentials", "StringMapId");

            foreach (StringMap _stringMap in _columnValues.Details)
            {
                cboCredential.Items.Add(new ListItem(_stringMap.Value, _stringMap));
            }
        }

        public void PopulateManagerEducationList()
        {
            lstEducation.Items.Clear();

            if (ManagerId != null)
            {
                ManagerEducation.AssociateDetails(Manager);

                foreach (ManagerEducation _managerEducation in Manager.Education)
                {
                    lstEducation.Items.Add(new ListItem(_managerEducation.Institution, _managerEducation));
                }

                lstEducation.Enabled = true;
                lstEducation.BackColor = System.Drawing.Color.White;
                txtInstitution.Enabled = true;
                txtYear.Enabled = true;
                txtEmphasis.Enabled = true;
                txtDegree.Enabled = true;
                btnEduDelete.Enabled = true;
                btnEduNew.Enabled = true;
                btnEduSave.Enabled = true;
            }
            else
            {
                lstEducation.Enabled = false;
                lstEducation.BackColor = System.Drawing.SystemColors.Control;
                lstEducation.Items.Add("The manager record must exist before associating education records to it. Please save the record to complete this action.");
                txtInstitution.Enabled = false;
                txtYear.Enabled = false;
                txtEmphasis.Enabled = false;
                txtDegree.Enabled = false;
                btnEduDelete.Enabled = false;
                btnEduNew.Enabled = false;
                btnEduSave.Enabled = false;
            }
        }

        private void label38_Click(object sender, EventArgs e)
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

        private void pnlSummary_Click(object sender, EventArgs e)
        {
            pnlSummary.Focus();
        }

        private void UpdateHeaderLabel()
        {
            string first = txtFirstName.Text;
            string middle = txtMiddleName.Text;
            string last = txtLastName.Text;

            if (!String.IsNullOrEmpty(middle))
                lblHeader.Text = first + " " + middle + " " + last;
            else
                lblHeader.Text = first + " " + last;
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            UpdateHeaderLabel();
        }

        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {
            UpdateHeaderLabel();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            UpdateHeaderLabel();
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

        private void lstEducation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isEditingEducation == true)
            {
                DialogResult result = MessageBox.Show("You have unsaved changes for this current education record. Are you sure you wish to continue without saving?", "Attention", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    isEditingEducation = false;
                }
                else
                {
                    return;
                }
            }

            if (lstEducation.SelectedIndex == -1 || lstEducation.SelectedItem == null)
            {
                txtInstitution.Text = null;
                txtDegree.Text = null;
                txtEmphasis.Text = null;
                txtYear.Text = null;
                return;
            }

            ManagerEducation _managerEducation = (ManagerEducation)((ListItem)lstEducation.SelectedItem).HiddenObject;
            txtInstitution.Text = _managerEducation.Institution;
            txtDegree.Text = _managerEducation.DegreeType;
            txtEmphasis.Text = _managerEducation.Emphasis;
            txtYear.Text = _managerEducation.Year.ToString();
        }

        private void btnCredentialsNew_Click(object sender, EventArgs e)
        {
            Guid stringMapId = new Guid(((ListItem)cboCredential.SelectedItem).HiddenValue);

            if (ManagerId != null)
                ManagerCredential.Insert((Guid)ManagerId, stringMapId, frmMain_Parent.CurrentUser.UserId);
            cboCredential.SelectedIndex = -1;

            PopulateManagerCredentialsLst();
        }

        private void btnCredentialsDelete_Click(object sender, EventArgs e)
        {
            if (lstCredentials.SelectedIndex == -1 || lstCredentials.SelectedItem == null)
            {
                MessageBox.Show("Error: No credential is selected for deletion. Please correct and try again.", "Error", MessageBoxButtons.OK);
                return;
            }

            ManagerCredential _managerCredential = (ManagerCredential)((ListItem)lstCredentials.SelectedItem).HiddenObject;
            _managerCredential.Delete();

            PopulateManagerCredentialsLst();
        }

        private void txtDegree_KeyPress(object sender, KeyPressEventArgs e)
        {
            isEditingEducation = true;
        }

        private void btnEduSave_Click(object sender, EventArgs e)
        {
            if (lstEducation.SelectedIndex == -1 || lstEducation.SelectedItem == null)
            {
                MessageBox.Show("Error: No education record is selected for deletion. Please correct and try again.", "Error", MessageBoxButtons.OK);
                return;
            }

            ManagerEducation _managerEducation = (ManagerEducation)((ListItem)lstEducation.SelectedItem).HiddenObject;

            Guid managerEducationId = _managerEducation.ManagerEducationId;
            string institution = txtInstitution.Text;
            string degree = txtDegree.Text;
            string emphasis = txtEmphasis.Text;
            int? year = null;

            try
            {
                year = int.Parse(txtYear.Text);
            }
            catch
            {
                MessageBox.Show("Error: Year field is not in an integer format. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                return;
            }
            
            isEditingEducation = false;

            ManagerEducation.Update(managerEducationId, frmMain_Parent.CurrentUser.UserId, institution, degree, emphasis, year);

            PopulateManagerEducationList();

            txtInstitution.Text = null;
            txtDegree.Text = null;
            txtEmphasis.Text = null;
            txtYear.Text = null;
        }

        private void btnEduNew_Click(object sender, EventArgs e)
        {
            string institution = txtInstitution.Text;
            string degree = txtDegree.Text;
            string emphasis = txtEmphasis.Text;
            int? year = null;

            try
            {
                year = int.Parse(txtYear.Text);
            }
            catch
            {
                MessageBox.Show("Error: Year field is not in an integer format. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                return;
            }

            isEditingEducation = false;

            if (ManagerId != null)
                ManagerEducation.Insert((Guid)ManagerId, frmMain_Parent.CurrentUser.UserId, institution, degree, emphasis, year);

            PopulateManagerEducationList();

            txtInstitution.Text = null;
            txtDegree.Text = null;
            txtEmphasis.Text = null;
            txtYear.Text = null;
        }

        private void btnEduDelete_Click(object sender, EventArgs e)
        {
            if (lstEducation.SelectedIndex == -1 || lstEducation.SelectedItem == null)
            {
                MessageBox.Show("Error: No education record is selected for deletion. Please correct and try again.", "Error", MessageBoxButtons.OK);
                return;
            }

            isEditingEducation = false;

            Guid _managerEducationId = ((ManagerEducation)((ListItem)lstEducation.SelectedItem).HiddenObject).ManagerEducationId;
            ManagerEducation _managerEducation = new ManagerEducation(_managerEducationId);
            _managerEducation.DeleteFromDatabase();

            PopulateManagerEducationList();

            txtInstitution.Text = null;
            txtDegree.Text = null;
            txtEmphasis.Text = null;
            txtYear.Text = null;
        }

        private bool Save()
        {
            string firstName = txtFirstName.Text;
            string middleName = txtMiddleName.Text;
            string lastName = txtLastName.Text;
            string biography = txtBiography.Text;
            string portfolioResponsibilities = txtResponsibilities.Text;
            int? becamePortfolioManagerYear = null;
            int? becameAnalystYear = null;

            try
            {
                if (!String.IsNullOrEmpty(txtBeganAsPm.Text))
                    becamePortfolioManagerYear = int.Parse(txtBeganAsPm.Text);
            }
            catch
            {
                MessageBox.Show("Error: Porfolio Manager experience field is not in an integer format. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                return false;
            }

            try
            {
                if (!String.IsNullOrEmpty(txtBeganAsAnalyst.Text))
                    becameAnalystYear = int.Parse(txtBeganAsAnalyst.Text);
            }
            catch
            {
                MessageBox.Show("Error: Analyst experience field is not in an integer format. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                return false;
            }

            if (ManagerId != null)
            {
                Manager.Update((Guid)ManagerId, frmMain_Parent.CurrentUser.UserId, firstName, middleName, lastName, biography, portfolioResponsibilities, becamePortfolioManagerYear, becameAnalystYear);
            }
            else
            {
                ManagerId = Guid.NewGuid();
                Manager.Insert(ManagerId, frmMain_Parent.CurrentUser.UserId, firstName, middleName, lastName, biography, portfolioResponsibilities, becamePortfolioManagerYear, becameAnalystYear);
                PopulateManagerCredentialsLst();
                PopulateManagerEducationList();
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            isEditingEducation = false;

            DialogResult result = MessageBox.Show("Are you sure you want to save?", "Attention", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                Save();
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            isEditingEducation = false;

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

        private void dgvFunds_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvFundsIndex = dgvFunds.CurrentCell.RowIndex;
            Guid relationalManagersFundsId = new Guid(dgvFunds.Rows[dgvFundsIndex].Cells[0].Value.ToString());
            Guid fundId = new Guid(dgvFunds.Rows[dgvFundsIndex].Cells[1].Value.ToString());
            lblSelectedFund.Text = dgvFunds.Rows[dgvFundsIndex].Cells[2].Value.ToString();

            relationalManagersFunds = new Relational_Managers_Funds(relationalManagersFundsId);

            if (relationalManagersFunds.ManagerRole != null)
                cboFundRole.Text = relationalManagersFunds.ManagerRole.Value;
            else
                cboFundRole.Text = "";

            if (relationalManagersFunds.PersonalAssets != null)
                cboPersonalAssets.Text = relationalManagersFunds.PersonalAssets.Value;
            else
                cboPersonalAssets.Text = "";

            lblFundMgrSave.Visible = false;
        }

        private void dgvFunds_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvFunds.CurrentCell.RowIndex;
            Guid relationalManagersFundsId = new Guid(dgvFunds.Rows[index].Cells[0].Value.ToString());
            Guid fundId = new Guid(dgvFunds.Rows[index].Cells[1].Value.ToString());
            lblSelectedFund.Text = dgvFunds.Rows[index].Cells[2].Value.ToString();
            frmFund _frmFund = new frmFund(frmMain_Parent, fundId);
        }

        private void btnOpenFund_Click(object sender, EventArgs e)
        {
            int index = dgvFunds.CurrentCell.RowIndex;
            Guid relationalManagersFundsId = new Guid(dgvFunds.Rows[index].Cells[0].Value.ToString());
            Guid fundId = new Guid(dgvFunds.Rows[index].Cells[1].Value.ToString());
            lblSelectedFund.Text = dgvFunds.Rows[index].Cells[2].Value.ToString();
            frmFund _frmFund = new frmFund(frmMain_Parent, fundId);
        }

        private void dgvAdvisors_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvAdvisors.CurrentCell.RowIndex;
            lblSelectedAdvisor.Text = dgvAdvisors.Rows[index].Cells[1].Value.ToString();
        }

        private void dgvAdvisors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvAdvisors.CurrentCell.RowIndex;
            Guid advisorId = new Guid(dgvAdvisors.Rows[index].Cells[0].Value.ToString());
            frmAdvisor _frmAdvisor = new frmAdvisor(frmMain_Parent, advisorId, advisorForm_FormClosed);
        }

        private void btnOpenMgr_Click(object sender, EventArgs e)
        {
            int index = dgvAdvisors.CurrentCell.RowIndex;
            Guid advisorId = new Guid(dgvAdvisors.Rows[index].Cells[0].Value.ToString());
            frmAdvisor _frmAdvisor = new frmAdvisor(frmMain_Parent, advisorId, advisorForm_FormClosed);
        }

        private void advisorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            paginationAdvisors = new Pagination(dgvAdvisors, Advisors.GetAssociatedFromManager((Guid)ManagerId));
            dgvAdvisors.Columns[0].Visible = false;
        }

        private void btnFundMgrSave_Click(object sender, EventArgs e)
        {
            if (relationalManagersFunds.RelationalManagerFundsId == null)
            {
                MessageBox.Show("Error: No manager is selected. Please select a manager and try again.", "Error!", MessageBoxButtons.OK);
                return;
            }

            if (cboPersonalAssets.SelectedItem == null || String.IsNullOrEmpty(((Utilities.ListItem)cboPersonalAssets.SelectedItem).ToString()))
            {
                relationalManagersFunds.PersonalAssets = null;
            }
            else
            {
                StringMap _stringMap = (StringMap)((ListItem)cboPersonalAssets.SelectedItem).HiddenObject;
                relationalManagersFunds.PersonalAssets = _stringMap;
            }

            if (cboFundRole.SelectedItem == null || String.IsNullOrEmpty(((ListItem)cboFundRole.SelectedItem).ToString()))
            {
                relationalManagersFunds.ManagerRole = null;
            }
            else
            {
                StringMap _stringMap = (StringMap)((ListItem)cboFundRole.SelectedItem).HiddenObject;
                relationalManagersFunds.ManagerRole = _stringMap;
            }

            relationalManagersFunds.UpdateDatabaseRecord(frmMain_Parent.CurrentUser.UserId);
            lblFundMgrSave.Visible = true;
        }
    }
}
