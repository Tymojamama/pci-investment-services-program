using DataIntegrationHub.Business.Entities;
using DataIntegrationHub.Business.Components;

using ISP;
using ISP.Business.Components;
using ISP.Business.Entities;
using ISP.Presentation;
using ISP.Presentation.Utilities;
using ISP.Security;
using ISP.Xml;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ISP.Presentation.Forms
{
    public partial class frmMain : Form, IMessageFilter
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

        public bool StopTaskCheck = false;
        public SecurityComponent Security;

        internal int openTaskNotifications = 0;
        internal User CurrentUser;
        internal UserLogin CurrentLoginSession;
        internal ISP.Business.Entities.UserSecurityRole CurrentUserSecurityRole;

        private Stopwatch stopWatch = new Stopwatch();
        private XmlParser xmlParser;
        private Pagination paginationAdvisors;
        private Pagination paginationFunds;
        private Pagination paginationManagers;
        private Pagination paginationTasks;
        private Pagination paginationMissingValues;
        private Pagination paginationDuplicateRecords;
        //private OpenFileDialog importFilesDialog;
        private FolderBrowserDialog importFilesDialog;

        /// <summary>
        /// Represents the main form of the ISP application.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            #region IMessageFilter Methods

            //Add controls to move the form
            Application.AddMessageFilter(this);
            controlsToMove.Add(this.lblFormHeader);
            controlsToMove.Add(this.pnlClntHeader);
            controlsToMove.Add(this.panel2);
            controlsToMove.Add(this.pnlFundHeader);
            controlsToMove.Add(this.panel6);
            controlsToMove.Add(this.panel7);
            controlsToMove.Add(this.panel8);
            controlsToMove.Add(this.panel9);
            controlsToMove.Add(this.panel10);
            controlsToMove.Add(this.pnlMainHeader);
            controlsToMove.Add(this.panel29);
            controlsToMove.Add(this.panel42);

            #endregion

            if (!ConnectionSucceeded())
            {
                return;
            }

            bool isAccessUser = LoginCurrentUser();

            if (isAccessUser == false)
            {
                this.Enabled = false;
                this.Hide();
                return;
            }

            // Initialize user controls. This has to be done after the user has been logged in.
            ucClients.Initialize(this);
            ucSettings.Initialize(this);

            LoadAutoCompleteAdvisors();
            LoadAutoCompleteFunds();
            LoadAssetGroupsDgv();

            DrawTaskNotification();

            HandleAppVersion();
            HandleDashboardTasks();

            //Start app with the dashboard tab
            tabMain.SelectedIndex = 8;

            SetDefaultComboBoxValues();

            //Start the timer that checks for new tasks
            tmrTaskNotification.Start();

            // Instantiate XmlParser so that we can add files to it
            try
            {
                xmlParser = new XmlParser(CurrentUser.UserId);
            }
            catch (Exception ex)
            {
                frmError _frmError = new frmError(this, ex);
            }
        }

        /// <summary>
        /// Sets the default values for all ComboBoxes within the ISP.
        /// </summary>
        private void SetDefaultComboBoxValues()
        {
            cboTaskViews.SelectedIndex = 0;
            cboFundViews.SelectedIndex = 0;
            cboAdvisorViews.SelectedIndex = 0;
            cboManagerViews.SelectedIndex = 0;
            cboViewsCategory.SelectedIndex = 0;
        }

        /// <summary>
        /// Checks the version of the application and sets <see cref="lblFormHeader"/>.
        /// </summary>
        private void HandleAppVersion()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                string version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                lblFormHeader.Text = lblFormHeader.Text + " - v" + version;
            }
        }

        /// <summary>
        /// Sets <see cref="lblOpenTasks"/> with the number of open tasks and draws an elipse around the number.
        /// </summary>
        /// <param name="num">The number of open tasks.</param>
        private void DrawTaskNotification(int num = -1)
        {
            //If number was not set
            if (num == -1)
            {
                num = Task.GetActiveAssociatedFromUser(CurrentUser.UserId).Rows.Count;
            }

            //Draw notification if new notification exists
            if (num > 0 && num.ToString().Length > 0)
            {
                openTaskNotifications = num;

                string text = num.ToString();
                lblOpenTasks.Text = text;

                GraphicsPath graphicsPath = new GraphicsPath();

                if (text.ToString().Length == 1)
                {
                    graphicsPath.AddEllipse(-1, (float)0.5, 13, 13);
                }
                else if (text.ToString().Length == 2)
                {
                    graphicsPath.AddEllipse(-1, 0, 19, 14);
                }
                else if (text.ToString().Length > 2)
                {
                    graphicsPath.AddEllipse((float)-1.0, (float)1.5, 11, 11);
                    lblOpenTasks.Text = "!";
                }

                this.lblOpenTasks.Region = new Region(graphicsPath);

                lblOpenTasks.Visible = true;
            }
        }
        /// <summary>
        /// Gets the security status of the current user and enables features based on their status.
        /// </summary>
        /// <returns>true if the current user has sufficient permission to use the application.</returns>
        /// <remarks>
        /// This method uses the <see cref="SecurityComponent(User)"/> to grab security roles from the
        /// Data Integration Hub on PCI-DB. It closes frmMain if an error occurs.
        /// </remarks>
        private bool LoginCurrentUser()
        {
            // Attempt to log the user in
            try
            {
                CurrentUser = new User(Environment.UserDomainName + "\\" + Environment.UserName);
                Security = new SecurityComponent(CurrentUser);
                lblLoginStatus.Text = "You are logged in as: " + CurrentUser.DomainName;

                if (Security.IsAdmin() == false)
                {
                    lblSettings.Enabled = false;
                    lblSettings.Visible = false;
                }

                if (Security.IsAdmin() == false && Security.IsDataAdmin() == false)
                {
                    lblTools.Enabled = false;
                    lblTools.Visible = false;
                }

                if (Security.IsUser() == false && Security.IsAdmin() == false)
                {
                    MessageBox.Show("You do not sufficient security privileges to user this application. Please see your system administrator.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                lblLoginStatus.Text = "An error occurred while logging you in.";
                frmError frmError = new frmError(this, ex);
                frmError.FormClosed += frmError_FormClosedEventHandler;
                return false;
            }

            BeginCurrentSession();

            return true;
        }

        private void BeginCurrentSession()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                string publishVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();

                CurrentLoginSession = new UserLogin();
                CurrentLoginSession.UserId = CurrentUser.UserId;
                CurrentLoginSession.PublishVersion = publishVersion;
                CurrentLoginSession.SessionStart = DateTime.Now;
                CurrentLoginSession.SaveRecordToDatabase(CurrentUser.UserId);
            }
        }

        private void UpdateCurrentSessionLength()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                CurrentLoginSession.SessionEnd = DateTime.Now;
                CurrentLoginSession.SaveRecordToDatabase(CurrentUser.UserId);
            }
        }

        private void EndCurrentSession()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                CurrentLoginSession.SessionEnd = DateTime.Now;
                CurrentLoginSession.SaveRecordToDatabase(CurrentUser.UserId);
            }
        }

        /// <summary>
        /// Closes <see cref="frmMain"/> when <see cref="frmError"/> is closed.
        /// </summary>
        /// <param name="sender">Provides a reference to the frmError sender instance.</param>
        /// <param name="e">Provides data for the System.Windows.Forms.Form.FormClosed event.</param>
        /// <remarks>
        /// This should only be used when the thrown exception would prevent the user from using the application.
        /// For example, if the application could not connect to the database or if the current user could
        /// not be logged in, then the form should be closed because it would be unusable.
        /// </remarks>
        private void frmError_FormClosedEventHandler(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Clears and adds string values to the AutoCompleteCustomSource of <see cref="txtAdvisorSearch"/>.
        /// </summary>
        private void LoadAutoCompleteAdvisors()
        {
            txtAdvisorSearch.AutoCompleteCustomSource.Clear();

            foreach (DataRow dr in UserSearches.GetAssociatedFromTable(CurrentUser.UserId, "Advisors").Rows)
            {
                txtAdvisorSearch.AutoCompleteCustomSource.Add(dr["SearchText"].ToString());
            }
        }

        /// <summary>
        /// Clears and adds string values to the AutoCompleteCustomSource of <see cref="txtFundsSearch"/>.
        /// </summary>
        private void LoadAutoCompleteFunds()
        {
            txtFundsSearch.AutoCompleteCustomSource.Clear();

            foreach (DataRow dr in UserSearches.GetAssociatedFromTable(CurrentUser.UserId, "Funds").Rows)
            {
                txtFundsSearch.AutoCompleteCustomSource.Add(dr["SearchText"].ToString());
            }
        }

        private void DataGridViewFunds_Focus(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvFunds.CurrentRow.Index;
            lblSelectedFund.Text = dgvFunds.Rows[index].Cells[1].Value.ToString();
        }

        private void txtFundsSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                FundSearch(txtFundsSearch.Text);
            }
        }

        /// <summary>
        /// Searches the database for matching records.
        /// </summary>
        /// <param name="searchValue">Used to find matching records.</param>
        private void FundSearch(string searchValue)
        {
            paginationFunds = new Pagination(dgvFunds, Fund.SearchByFundNameAndTicker(searchValue));
            dgvFunds.Columns[0].Visible = false;

            if (!String.IsNullOrEmpty(txtFundsSearch.Text))
            {
                UserSearches userSearch = new UserSearches();
                userSearch.SearchText = txtFundsSearch.Text;
                userSearch.SearchTable = "Funds";
                userSearch.SaveRecordToDatabase(CurrentUser.UserId);

                txtFundsSearch.AutoCompleteCustomSource.Clear();
                LoadAutoCompleteFunds();
            }
        }

        /// <summary>
        /// Checks if the application can connect to the relevant databases and servers.
        /// </summary>
        /// <returns>Returns true if the connection did succeed.</returns>
        private bool ConnectionSucceeded()
        {
            this.Enabled = false;

            if (Access.ConnectionSucceeded())
            {
                this.Enabled = true;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Creates a new instance of <see cref="frmFund"/> using the current row index of <see cref="dgvFunds"/>.
        /// </summary>
        private void OpenSelectedFundForm()
        {
            int index = dgvFunds.CurrentRow.Index;
            Guid fundId = new Guid(dgvFunds.Rows[index].Cells[0].Value.ToString());
            frmFund fundForm = new frmFund(this, fundId);

        }

        /// <summary>
        /// Sets <see cref="dgvTasks"/> based on the SelectedIndex of <see cref="cboTaskViews"/>.
        /// </summary>
        /// <remarks>
        /// Since we aren't storing users in the ISP database, we must use the
        /// DataIntegrationHub.Business API to match the Guid values of <see cref="dgvTasks"/>
        /// </remarks>
        private void LoadTasksDgv()
        {
            DataTable dataTable = new DataTable();

            /// Set the datatable based on the SelectedIndex of <see cref="cboTaskViews"/>.
            switch (cboTaskViews.SelectedIndex)
            {
                case 0:
                    dataTable = Task.GetActiveAssociatedFromUser(CurrentUser.UserId);
                    break;
                case 1:
                    dataTable = Task.GetInactiveAssociatedFromUser(CurrentUser.UserId);
                    break;
                case 2:
                    dataTable = Task.GetActive();
                    break;
                case 3:
                    dataTable = Task.GetInactive();
                    break;
                default:
                    return;
            }

            // Create and set the owner column values.
            DataColumn column = new DataColumn();
            column.ColumnName = "Owner";
            dataTable.Columns.Add(column);

            foreach (DataRow _row in dataTable.Rows)
            {
                Guid _userId = new Guid(_row["OwnerId"].ToString());
                User _user = new User(_userId);
                _row["Owner"] = _user.FullName;
            }

            // Set the datagridview to the datatable and instantiate the pagination object.
            paginationTasks = new Pagination(dgvTasks, dataTable);

            // Display/order the columns.
            dgvTasks.Columns["TaskId"].Visible = false;
            dgvTasks.Columns["OwnerId"].Visible = false;
            dgvTasks.Columns["FundId"].Visible = false;
            dgvTasks.Columns["AccountId"].Visible = false;
            dgvTasks.Columns["ManagerId"].Visible = false;

            dgvTasks.Columns["Owner"].DisplayIndex = 0;
            dgvTasks.Columns["Task"].DisplayIndex = 1;
            dgvTasks.Columns["Description"].DisplayIndex = 2;
            dgvTasks.Columns["Due On"].DisplayIndex = 3;
            dgvTasks.Columns["Regarding Fund"].DisplayIndex = 4;
            dgvTasks.Columns["Total Hours"].DisplayIndex = 5;
            dgvTasks.Columns["Status"].DisplayIndex = 6;
        }

        /// <summary>
        /// Enables, disables and sets values of task-related controls based on their intrinsic availability.
        /// </summary>
        /// <remarks>
        /// We have this because we don't want users to attempt to do intrinsically irrational actions.
        /// For example, if CurrentCell is null and no record is selected, we don't want users to be able
        /// to click on a button that allows the user to edit that record.
        /// </remarks>
        private void LoadTasksControls()
        {
            btnTaskComplete.Enabled = true;

            if (cboTaskViews.SelectedIndex == 0 || cboTaskViews.SelectedIndex == 2)
            {
                btnTaskComplete.Text = "Complete";

                if (dgvTasks.Rows.Count == 0)
                {
                    btnTaskComplete.Enabled = false;
                }
            }
            else
            {
                btnTaskComplete.Text = "Re-open";

                if (dgvTasks.Rows.Count == 0)
                {
                    btnTaskComplete.Enabled = false;
                }
            }
        }

        private void cboTaskViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTasksDgv();
            LoadTasksControls();
        }

        private void btnTaskNew_Click(object sender, EventArgs e)
        {
            frmTask _frmTask = new frmTask(this);
            _frmTask.FormClosed += frmTask_FormClosed;
        }

        private void frmTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadTasksDgv();
        }

        void cboClientViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucClients.LoadAccountDgv();
        }

        void cboFundViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFundDgv();
        }

        private void LoadFundDgv()
        {
            if (cboFundViews.SelectedIndex == 0)
            {
                paginationFunds = new Pagination(dgvFunds, Business.Entities.Fund.GetByFundName());
                dgvFunds.Columns[0].Visible = false;
            }
        }

        private void btnTaskDelete_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null)
            {
                return;
            }

            int index = dgvTasks.CurrentRow.Index;
            Guid taskId = new Guid(dgvTasks.Rows[index].Cells[0].Value.ToString());
            string userName = dgvTasks.Rows[index].Cells[4].Value.ToString();
            string taskName = dgvTasks.Rows[index].Cells[5].Value.ToString();

            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to permanently delete task " + taskName + "?", "Attention", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Task task = new Task(taskId);
                task.DeleteRecordFromDatabase();
                LoadTasksDgv();
            }
        }

        private void dataGridViewTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Setup local variables
            int index = dgvTasks.CurrentRow.Index;
            Guid taskId = new Guid(dgvTasks.Rows[index].Cells["TaskId"].Value.ToString());
            Guid FundId = Guid.Empty;
            Guid AccountId = Guid.Empty;
            Guid ManagerId = Guid.Empty;
            string taskName = dgvTasks.Rows[index].Cells[5].Value.ToString();
            string fundName = dgvTasks.Rows[index].Cells[8].Value.ToString();

            //Set IDs if they exist
            if (String.IsNullOrEmpty(dgvTasks.Rows[index].Cells["FundId"].Value.ToString()) == false)
            {
                FundId = new Guid(dgvTasks.Rows[index].Cells["FundId"].Value.ToString());
            }
            if (String.IsNullOrEmpty(dgvTasks.Rows[index].Cells["AccountId"].Value.ToString()) == false)
            {
                AccountId = new Guid(dgvTasks.Rows[index].Cells["AccountId"].Value.ToString());
            }
            if (String.IsNullOrEmpty(dgvTasks.Rows[index].Cells["ManagerId"].Value.ToString()) == false)
            {
                ManagerId = new Guid(dgvTasks.Rows[index].Cells["ManagerId"].Value.ToString());
            }

            lblSelectedTask.Text = taskName;
        }

        private void cboAdvViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            paginationAdvisors = new Pagination(dgvAdvisors, Business.Entities.Advisors.GetActive());
            dgvAdvisors.Columns[0].Visible = false;
        }

        private void cboMgrViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadManagersDgv();
        }

        /// <summary>
        /// Loads <see cref="dgvManagers"/> based on the selected item in <see cref="cboManagerViews"/>.
        /// </summary>
        private void LoadManagersDgv()
        {
            if (cboManagerViews.SelectedIndex == 0)
            {
                paginationManagers = new Pagination(dgvManagers, Business.Entities.Manager.GetActive());
                dgvManagers.Columns[0].Visible = false;
            }
        }

        private void dgvManagers_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvManagers.CurrentRow.Index;
            lblSelectedManager.Text = dgvManagers.Rows[index].Cells[1].Value.ToString();
        }

        private void dgvAdvisors_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvAdvisors.CurrentRow.Index;
            lblSelectedAdvisor.Text = dgvAdvisors.Rows[index].Cells[1].Value.ToString();
        }

        private void btnTaskComplete_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null)
            {
                return;
            }

            int index = dgvTasks.CurrentRow.Index;
            Guid taskId = new Guid(dgvTasks.Rows[index].Cells[0].Value.ToString());
            string name = dgvTasks.Rows[index].Cells[5].Value.ToString();

            if (btnTaskComplete.Text == "Complete")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to mark " + name + " complete?", "Attention", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Task task = new Task(taskId);
                    task.SetComplete();
                    task.SaveRecordToDatabase(CurrentUser.UserId);

                    LoadTasksDgv();
                    LoadTasksControls();
                }
            }
            else if (btnTaskComplete.Text == "Re-open")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to reopen " + name + "?", "Attention", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Task task = new Task(taskId);
                    task.SetOpen();
                    task.SaveRecordToDatabase(CurrentUser.UserId);

                    LoadTasksDgv();
                    LoadTasksControls();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int index = dgvTasks.CurrentRow.Index;
            Guid fundId = new Guid(dgvTasks.Rows[index].Cells["FundId"].Value.ToString());
            frmFund frmFund = new frmFund(this, fundId);
        }

        private void frmAdvisor_FormClosed(object sender, FormClosedEventArgs e)
        {
            paginationAdvisors = new Pagination(dgvAdvisors, Business.Entities.Advisors.GetActive());
            dgvAdvisors.Columns[0].Visible = false;
        }

        private void NewAdvisor(object sender, EventArgs e)
        {
            frmAdvisor frmAdvisor = new frmAdvisor(this);
            frmAdvisor.FormClosed += frmAdvisor_FormClosed;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index = dgvAdvisors.CurrentRow.Index;
            Guid advisorId = new Guid(dgvAdvisors.Rows[index].Cells[0].Value.ToString());
            frmAdvisor frmAdvisor = new frmAdvisor(this, advisorId);
            frmAdvisor.FormClosed += frmAdvisor_FormClosed;
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvAdvisors.CurrentRow.Index;
            Guid advisorId = new Guid(dgvAdvisors.Rows[index].Cells[0].Value.ToString());
            frmAdvisor frmAdvisor = new frmAdvisor(this, advisorId);
            frmAdvisor.FormClosed += frmAdvisor_FormClosed;
        }

        private void btnManagersOpen_Click(object sender, EventArgs e)
        {
            ManagersOpen();
        }

        private void dgvManagers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ManagersOpen();
        }

        private void ManagersOpen()
        {
            int index = dgvManagers.CurrentRow.Index;
            Guid managerId = new Guid(dgvManagers.Rows[index].Cells[0].Value.ToString());
            frmManager frmManager = new frmManager(this, managerId);
            frmManager.FormClosed += frmManager_FormClosed;
        }

        private void frmTaskTime_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadTasksDgv();
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

        private void ReportTypeMenuItem_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.SystemColors.HotTrack;
            label.BackColor = System.Drawing.Color.Silver;
        }

        private void ReportTypeMenuItem_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.SystemColors.ControlText;
            label.BackColor = System.Drawing.Color.DarkGray;
        }

        private void ReportTypeSubMenuItem_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.SystemColors.HotTrack;
            label.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void ReportTypeSubMenuItem_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.Color.White;
            label.BackColor = System.Drawing.Color.LightSlateGray;
        }

        /// <summary>
        /// Loads <see cref="dgvDshTasks"/> and sets <see cref="lblDashboardOpenTasks"/> based on open tasks.
        /// </summary>
        private void HandleDashboardTasks()
        {
            LoadDshTasksDgv();

            if (dgvDshTasks.Rows.Count == 0)
            {
                dgvDshTasks.Visible = false;
                btnToTasks.Visible = false;
                lblDashboardOpenTasks.Text = "All tasks completed";
                lblDshTaskStatus.Visible = true;
            }
            else
            {
                if (dgvDshTasks.Rows.Count == 1)
                {
                    lblDashboardOpenTasks.Text = "You have 1 open task";
                }
                else
                {
                    lblDashboardOpenTasks.Text = "You have " + dgvDshTasks.Rows.Count + " open tasks";
                }

                dgvDshTasks.Visible = true;
                btnToTasks.Visible = true;
                lblDshTaskStatus.Visible = false;
            }
        }

        private void LoadDshTasksDgv()
        {
            DataTable _dataTable = Task.GetActiveAssociatedFromUser(CurrentUser.UserId);

            DataColumn _column = new DataColumn();
            _column.ColumnName = "Owner";
            _dataTable.Columns.Add(_column);

            foreach (DataRow _row in _dataTable.Rows)
            {
                Guid _userId = new Guid(_row[1].ToString());
                User _user = new User(_userId);
                _row["Owner"] = _user.FullName;
            }

            dgvDshTasks.DataSource = _dataTable;

            dgvDshTasks.Columns["TaskId"].Visible = false;
            dgvDshTasks.Columns["OwnerId"].Visible = false;
            dgvDshTasks.Columns["FundId"].Visible = false;
            dgvDshTasks.Columns["AccountId"].Visible = false;
            dgvDshTasks.Columns["ManagerId"].Visible = false;

            dgvDshTasks.Columns["Owner"].DisplayIndex = 0;
            dgvDshTasks.Columns["Task"].DisplayIndex = 1;
            dgvDshTasks.Columns["Description"].DisplayIndex = 2;
            dgvDshTasks.Columns["Due On"].DisplayIndex = 3;
            dgvDshTasks.Columns["Regarding Fund"].DisplayIndex = 4;
            dgvDshTasks.Columns["Total Hours"].DisplayIndex = 5;
            dgvDshTasks.Columns["Status"].DisplayIndex = 6;
        }

        private void label78_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 8;
            HandleDashboardTasks();

            menuUnderlineHandler(lblDashboard);
        }

        private void label46_Click(object sender, EventArgs e)
        {
            menuUnderlineHandler(lblAccounts);
            tabMain.SelectedIndex = 9;
        }

        private void label47_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 1;

            menuUnderlineHandler(lblFunds);
        }

        private void lblAdvisorsClients_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 2;
        }

        private void label49_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 4;
        }

        private void label50_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 4;
            lblOpenTasks.Visible = false;

            menuUnderlineHandler(lblTasks);
        }

        private void label51_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 5;

            menuUnderlineHandler(lblReports);

            PopulateSelectedReviewCbo();

            // Add values to Quarter ComboBox
            cboSelectedQuarter.Items.Clear();
            List<Business.Entities.TimeTable> timeTableList = Business.Entities.TimeTable.PastFourtyQuarters();
            foreach (Business.Entities.TimeTable timeTable in timeTableList)
            {
                string s = timeTable.YearValue.ToString() + " - Q" + timeTable.QuarterValue.ToString();
                cboSelectedQuarter.Items.Add(new Utilities.ListItem(s, timeTable));
            }

            if (cboSelectedQuarter.Items.Count > 0 && cboSelectedQuarter.SelectedIndex == -1)
                cboSelectedQuarter.SelectedIndex = 0;
        }

        private void label52_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 6;

            menuUnderlineHandler(lblTools);
        }

        private void menuUnderlineHandler(Label label)
        {
            lblDashboard.Font = new Font(lblDashboard.Font.Name, lblDashboard.Font.SizeInPoints, FontStyle.Regular);
            lblAccounts.Font = new Font(lblAccounts.Font.Name, lblAccounts.Font.SizeInPoints, FontStyle.Regular);
            lblFunds.Font = new Font(lblFunds.Font.Name, lblFunds.Font.SizeInPoints, FontStyle.Regular);
            lblTasks.Font = new Font(lblTasks.Font.Name, lblTasks.Font.SizeInPoints, FontStyle.Regular);
            lblReports.Font = new Font(lblReports.Font.Name, lblReports.Font.SizeInPoints, FontStyle.Regular);
            lblTools.Font = new Font(lblTools.Font.Name, lblTools.Font.SizeInPoints, FontStyle.Regular);
            lblSettings.Font = new Font(lblSettings.Font.Name, lblSettings.Font.SizeInPoints, FontStyle.Regular);

            label.Font = new Font(label.Font.Name, label.Font.SizeInPoints, FontStyle.Underline);
        }

        private void lblSettings_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 7;

            menuUnderlineHandler(lblSettings);
        }

        private void CloseFormButton_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.Color.Black;
            label.BackColor = System.Drawing.Color.LightSalmon;
        }

        private void CloseFormButton_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.Color.White;
            label.BackColor = System.Drawing.Color.IndianRed;
        }

        private void CloseForm(object sender, EventArgs e)
        {
            EndCurrentSession();
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

        private void label43_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void label42_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                label30.Text = "Investment Search Report";
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                label30.Text = "Investment Monitoring Report";
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label76_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 0;
        }

        private void label77_Click(object sender, EventArgs e)
        {
            tabControlSettings.SelectedIndex = 0;
        }

        private void btnAddImportFile_Click(object sender, EventArgs e)
        {
            importFilesDialog = new FolderBrowserDialog();
            importFilesDialog.SelectedPath = @"\\PCIHost1\TricensionBackups\Morningstar Files";
            importFilesDialog.Description = "Select a folder of xml data to import.";

            DialogResult openFileResult = importFilesDialog.ShowDialog();

            if (openFileResult == DialogResult.OK)
            {
                btnStartImport.Enabled = true;

                foreach (string fileName in Directory.GetFiles(importFilesDialog.SelectedPath, "*.xml", SearchOption.AllDirectories))
                {
                    string safeFileName = Path.GetFileName(fileName);

                    XmlParser.Utilities.ImportFileItem selectedItem = new XmlParser.Utilities.ImportFileItem(fileName, safeFileName);
                    xmlParser.FilesToImport.Add(selectedItem);
                }

                if (xmlParser.FilesToImport.Count == 0)
                {
                    txtImportLog.Text = null;
                    lstFilesToImport.Items.Clear();
                }
                else
                {
                    xmlParser.FilesToImport.Sort((x, y) => x.FileName.CompareTo(y.FileName));
                    LoadFilesToImportLst();
                }
            }
        }

        private void LoadFilesToImportLst()
        {
            lstFilesToImport.Items.Clear();

            if (xmlParser.ProcessIsRunning)
            {
                int itemIndex = 0;
                foreach (XmlParser.Utilities.ImportFileItem item in xmlParser.FilesToImport)
                {
                    if (itemIndex >= xmlParser.CurrentFileIndex)
                    {
                        lstFilesToImport.Items.Add(new ListItem(item.SafeName, item.FileName));
                    }

                    itemIndex++;
                }
            }
            else
            {
                foreach (XmlParser.Utilities.ImportFileItem item in xmlParser.FilesToImport)
                {
                    lstFilesToImport.Items.Add(new ListItem(item.SafeName, item.FileName));
                }

                lblTotalImportProgress.Text = "(0 of " + xmlParser.FilesToImport.Count.ToString() + ")";
            }
        }

        private void btnRemoveImportFile_Click(object sender, EventArgs e)
        {
            if (xmlParser.FilesToImport.Count == 0)
            {
                txtImportLog.Text = null;
                lstFilesToImport.Items.Clear();
                btnStartImport.Enabled = false;
                return;
            }

            if (lstFilesToImport.SelectedItem != null)
            {
                foreach(XmlParser.Utilities.ImportFileItem importFileItem in xmlParser.FilesToImport)
                {
                    string lstSelectedFile = ((ListItem)lstFilesToImport.SelectedItem).HiddenValue;
                    if (importFileItem.FileName == lstSelectedFile)
                    {
                        xmlParser.FilesToImport.Remove(importFileItem);
                        break;
                    }
                }
            }

            LoadFilesToImportLst();
        }

        private bool containsDailyAndMonthlyFiles()
        {
            bool containsDailyFiles = false;
            bool containsMonthlyFiles = false;

            foreach (XmlParser.Utilities.ImportFileItem importFileItem in xmlParser.FilesToImport)
            {
                if (!containsDailyFiles && importFileItem.SafeName.Contains("_D_"))
                {
                    containsDailyFiles = true;
                }
                else if (!containsMonthlyFiles && importFileItem.SafeName.Contains("_M_"))
                {
                    containsMonthlyFiles = true;
                }
            }

            return (containsDailyFiles && containsMonthlyFiles);
        }

        private void btnStartImport_Click(object sender, EventArgs e)
        {
            if (containsDailyAndMonthlyFiles())
            {
                MessageBox.Show("You may not import both Daily and Monthly files at the same time. Please import monthly files of a given month first before importing daily files.", "Error!", MessageBoxButtons.OK);
                return;
            }

            // Setup global variables
            int totalFilesCount = xmlParser.FilesToImport.Count;

            // Setup UI controls
            btnAddImportFile.Enabled = false;
            btnRemoveImportFile.Enabled = false;
            btnClearImportFiles.Enabled = false;
            btnCancelImport.Enabled = true;
            btnStartImport.Enabled = false;

            string _errorLog = null;

            try
            {
                xmlParser.Process();

                BackgroundWorker backgroundWorker = new BackgroundWorker();
                backgroundWorker.WorkerReportsProgress = true;

                backgroundWorker.DoWork += new DoWorkEventHandler(
                delegate(object o, DoWorkEventArgs args)
                {
                    BackgroundWorker b = o as BackgroundWorker;

                    while (xmlParser.ProcessIsRunning)
                    {
                        if (_errorLog != xmlParser.ErrorLog)
                        {
                            _errorLog = xmlParser.ErrorLog;
                            MessageBox.Show("An error occurred during file import: " + _errorLog, "Error", MessageBoxButtons.OK);
                            xmlParser.ContinueProcess = false;
                            break;
                        }

                        if (progressBar.Value != Decimal.ToInt32(xmlParser.PercentComplete * 100))
                            b.ReportProgress(0);
                        else if (txtImportLog.Text != xmlParser.EventLog)
                            b.ReportProgress(0);
                        else if (lblTotalImportProgress.Text != "(" + (xmlParser.CurrentFileIndex + 1).ToString() + " of " + totalFilesCount.ToString() + ")")
                            b.ReportProgress(0);
                        else if (txtImportFileName.Text != xmlParser.CurrentFile.SafeName)
                            b.ReportProgress(0);

                        Thread.Sleep(50);
                    }
                });

                backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(
                delegate(object o, ProgressChangedEventArgs args)
                {
                    BackgroundWorker b = o as BackgroundWorker;

                    if (_errorLog != xmlParser.ErrorLog)
                    {
                        _errorLog = xmlParser.ErrorLog;
                        MessageBox.Show("An error occurred during file import: " + _errorLog, "Error", MessageBoxButtons.OK);
                    }

                    if (progressBar.Value != Decimal.ToInt32(xmlParser.PercentComplete * 100))
                        progressBar.Value = Decimal.ToInt32(xmlParser.PercentComplete * 100);

                    if (txtImportLog.Text != xmlParser.EventLog)
                        txtImportLog.Text = xmlParser.EventLog;

                    if (lblTotalImportProgress.Text != "(" + (xmlParser.CurrentFileIndex + 1).ToString() + " of " + totalFilesCount.ToString() + ")")
                        lblTotalImportProgress.Text = "(" + (xmlParser.CurrentFileIndex + 1).ToString() + " of " + totalFilesCount.ToString() + ")";

                    if (txtImportFileName.Text != xmlParser.CurrentFile.SafeName)
                    {
                        txtImportFileName.Text = xmlParser.CurrentFile.SafeName;
                        LoadFilesToImportLst();
                    }
                });

                backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate(object o, RunWorkerCompletedEventArgs args)
                {
                    if (_errorLog != xmlParser.ErrorLog)
                    {
                        _errorLog = xmlParser.ErrorLog;
                        MessageBox.Show("An error occurred during file import: " + _errorLog, "Error", MessageBoxButtons.OK);
                    }

                    progressBar.Value = 100;
                    txtImportLog.Text = xmlParser.EventLog;
                    lblTotalImportProgress.Text = "Files successfully imported!";
                    txtImportFileName.Text = "-";
                    lstFilesToImport.Items.Clear();

                    xmlParser = new XmlParser(CurrentUser.UserId);

                    btnAddImportFile.Enabled = true;
                    btnRemoveImportFile.Enabled = true;
                    btnClearImportFiles.Enabled = true;
                    btnCancelImport.Enabled = false;
                    btnStartImport.Enabled = true;
                });

                backgroundWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                frmError _frmError = new frmError(this, ex);
                StopTaskCheck = false;
                return;
            }

            progressBar.Value = 100;
        }

        private void btnCancelImport_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to cancel?", "Attention", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                xmlParser.ContinueProcess = false;
                btnStartImport.Enabled = true;
                btnCancelImport.Enabled = false;
            }
        }

        private void label89_Click(object sender, EventArgs e)
        {
            tabControlSettings.SelectedIndex = 0;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            int index = dgvTasks.CurrentRow.Index;
            Guid managerId = new Guid(dgvTasks.Rows[index].Cells["ManagerId"].Value.ToString());
            frmManager _frmManager = new frmManager(this, managerId);
            _frmManager.FormClosed += frmManager_FormClosed;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            int index = dgvTasks.CurrentRow.Index;
            Guid accountId = new Guid(dgvTasks.Rows[index].Cells["AccountId"].Value.ToString());

            Presentation.Forms.frmAccount accountForm = new Presentation.Forms.frmAccount(this, accountId);
        }

        private void AccountsSubMenuItem_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.SystemColors.HotTrack;
            label.BackColor = System.Drawing.Color.Gainsboro;
            panel33.Visible = true;
        }

        private void AccountsSubMenuItem_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.SystemColors.ControlText;
            label.BackColor = System.Drawing.Color.LightGray;
            panel33.Visible = true;
        }

        private void label33_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 3;
        }

        private void label29_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 1;

            cboClntFundValues.Items.Clear();

            foreach (DataRow dr in ISP.Business.Entities.Account.GetActiveCustomersWithFunds().Rows)
            {
                cboClntFundValues.Items.Add(new Utilities.ListItem(dr["Account"].ToString(), dr["AccountId"].ToString()));
            }

            if (cboClntFundValues.Items.Count > 0)
            {
                cboClntFundValues.SelectedIndex = 0;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (dgvFundValues.DataSource == null)
            {
                return;
            }

            try
            {
                foreach (DataGridViewRow row in this.dgvFundValues.Rows)
                {
                    Guid rfpId = new Guid(row.Cells[0].Value.ToString());
                    string account = ((Utilities.ListItem)cboClntFundValues.SelectedItem).ToString();
                    string plan = row.Cells[1].Value.ToString();
                    string fundname = row.Cells[3].Value.ToString();
                    decimal? assetValue;
                    DateTime? assetValueAsOf;

                    try
                    {
                        if (String.IsNullOrEmpty(row.Cells[4].Value.ToString()))
                        {
                            assetValue = null;
                        }
                        else
                        {
                            assetValue = Decimal.Parse(row.Cells[4].Value.ToString());
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error parsing asset value for " + fundname + " in plan " + plan + ", " + account + ". Please correct.", "Error");
                        return;
                    }
                    try
                    {
                        if (String.IsNullOrEmpty(row.Cells[5].Value.ToString()))
                        {
                            assetValueAsOf = null;
                        }
                        else
                        {
                            assetValueAsOf = DateTime.Parse(row.Cells[5].Value.ToString());
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error parsing asset value for " + fundname + " in plan " + plan + ", " + account + ". Please correct.", "Error");
                        return;
                    }

                    Relational_Funds_Plans relational_Funds_Plans = new Relational_Funds_Plans(rfpId);
                    relational_Funds_Plans.AssetValue = assetValue;
                    relational_Funds_Plans.AssetValueAsOf = assetValueAsOf;
                    relational_Funds_Plans.SaveRecordToDatabase(CurrentUser.UserId);
                }

                MessageBox.Show("Task completed successfully.");

                cboClntFundValues.Enabled = true;
                btnCancelValues.Enabled = false;
                btnSaveValues.Enabled = false;
            }
            catch (Exception ex)
            {
                frmError _frmError = new Presentation.Forms.frmError(this, ex);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to cancel? Any unsaved data will be lost.", "Attention!", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                Guid accountId = new Guid(((Utilities.ListItem)cboClntFundValues.SelectedItem).HiddenValue);
                dgvFundValues.DataSource = ISP.Business.Entities.Fund.GetAllAssetValues(accountId);

                cboClntFundValues.Enabled = true;
                btnCancelValues.Enabled = false;
                btnSaveValues.Enabled = false;
            }
        }

        private void dataGridView5_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            cboClntFundValues.Enabled = false;
            btnCancelValues.Enabled = true;
            btnSaveValues.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid accountId = new Guid(((Utilities.ListItem)cboClntFundValues.SelectedItem).HiddenValue);

            dgvFundValues.DataSource = ISP.Business.Entities.Fund.GetAllAssetValues(accountId);
            dgvFundValues.Columns[0].Visible = false;

            dgvFundValues.Columns[0].ReadOnly = true;
            dgvFundValues.Columns[1].ReadOnly = true;
            dgvFundValues.Columns[2].ReadOnly = true;
            dgvFundValues.Columns[3].ReadOnly = true;
            dgvFundValues.Columns[4].ReadOnly = false;
            dgvFundValues.Columns[5].ReadOnly = false;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            paginationFunds.PageBackward();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            paginationFunds.PageForward();
        }

        private void dataGridViewFunds_Sorted(object sender, EventArgs e)
        {
            DataGridViewColumn column = dgvFunds.SortedColumn;
            System.Windows.Forms.SortOrder sortOrder = dgvFunds.SortOrder;
            paginationFunds.Sort(column.Name, sortOrder.ToString());
        }

        private void tmrTaskNotification_Tick(object sender, EventArgs e)
        {
            if (StopTaskCheck)
                return;

            int num = 0;

            try
            {
                BackgroundWorker _backgroundWorker = new BackgroundWorker();

                _backgroundWorker.DoWork += new DoWorkEventHandler(
                delegate(object o, DoWorkEventArgs args)
                {
                    // Update the end time of the current session in case they
                    // don't close the program normally. I want good user data!
                    UpdateCurrentSessionLength();

                    //Get number of open tasks
                    num = Task.GetActiveAssociatedFromUser(CurrentUser.UserId).Rows.Count;
                });

                _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate(object o, RunWorkerCompletedEventArgs args)
                {
                    //New tasks exist
                    if (num > openTaskNotifications)
                    {
                        //Draw label with number of unchecked, open tasks
                        DrawTaskNotification(num - openTaskNotifications);
                        openTaskNotifications = num;
                    }
                    //No new tasks exist
                    else if (num < openTaskNotifications)
                    {
                        //Write over variable with number of open tasks
                        openTaskNotifications = num;
                    }
                });

                _backgroundWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                frmError _frmError = new frmError(this, ex);
            }
        }

        private void dgvAdvBack_Click(object sender, EventArgs e)
        {
            paginationAdvisors.PageBackward();
        }

        private void dgvAdvForward_Click(object sender, EventArgs e)
        {
            paginationAdvisors.PageForward();
        }

        private void dgvAdvisors_Sorted(object sender, EventArgs e)
        {
            DataGridViewColumn column = dgvAdvisors.SortedColumn;
            System.Windows.Forms.SortOrder sortOrder = dgvAdvisors.SortOrder;

            paginationAdvisors.Sort(column.Name, sortOrder.ToString());
        }

        private void txtAdvSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                paginationAdvisors = new Pagination(dgvAdvisors, Business.Entities.Advisors.SearchActive(txtAdvisorSearch.Text));
                dgvAdvisors.Columns[0].Visible = false;

                if (!String.IsNullOrEmpty(txtAdvisorSearch.Text))
                {
                    UserSearches userSearch = new UserSearches();
                    userSearch.SearchText = txtAdvisorSearch.Text;
                    userSearch.SearchTable = "Advisors";
                    userSearch.SaveRecordToDatabase(CurrentUser.UserId);

                    txtAdvisorSearch.AutoCompleteCustomSource.Clear();

                    foreach (DataRow dr in Business.Entities.UserSearches.GetAssociatedFromTable(CurrentUser.UserId, "Advisors").Rows)
                        txtAdvisorSearch.AutoCompleteCustomSource.Add(dr["SearchText"].ToString());
                }
            }
        }

        private void pnlAccClient_MouseEnter(object sender, EventArgs e)
        {
            pnlAccClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void pnlAccClient_MouseLeave(object sender, EventArgs e)
        {
            pnlAccClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void pnlAccMgr_MouseEnter(object sender, EventArgs e)
        {
            pnlAccMgr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void pnlAccMgr_MouseLeave(object sender, EventArgs e)
        {
            pnlAccMgr.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void pnlAccAdv_MouseEnter(object sender, EventArgs e)
        {
            pnlAccAdv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void pnlAccAdv_MouseLeave(object sender, EventArgs e)
        {
            pnlAccAdv.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void buttonOpenFund_Click(object sender, EventArgs e)
        {
            OpenSelectedFundForm();
        }

        private void dgvFunds_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenSelectedFundForm();
        }

        public void frmManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadManagersDgv();
        }

        private void selectMgrCboIndex(int index)
        {
            cboManagerViews.SelectedIndex = index;
        }

        private void btnManagerNew_Click(object sender, EventArgs e)
        {
            frmManager frmManager = new frmManager(this);
            frmManager.FormClosed += frmManager_FormClosed;
        }

        private void btnManagerDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedManager();
        }

        private void DeleteSelectedManager()
        {
            int dgvIndex = dgvManagers.CurrentCell.RowIndex;
            Guid managerId = new Guid(dgvManagers.Rows[dgvIndex].Cells[0].Value.ToString());
            Manager manager = new Manager(managerId);

            DialogResult result = MessageBox.Show("Are you sure you wish to delete the following manager: " + manager.FullName + "?", "Attention", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                manager.DeleteRecordFromDatabase();
                LoadManagersDgv();
            }
        }

        private void txtMgrSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                paginationManagers = new Pagination(dgvManagers, Business.Entities.Manager.Search(txtMgrSearch.Text));

                if (!String.IsNullOrEmpty(txtMgrSearch.Text))
                {
                    UserSearches userSearch = new UserSearches();
                    userSearch.SearchText = txtMgrSearch.Text;
                    userSearch.SearchTable = "Managers";
                    userSearch.SaveRecordToDatabase(CurrentUser.UserId);

                    txtMgrSearch.AutoCompleteCustomSource.Clear();

                    foreach (DataRow dr in Business.Entities.UserSearches.GetAssociatedFromTable(CurrentUser.UserId, "Managers").Rows)
                        txtMgrSearch.AutoCompleteCustomSource.Add(dr["SearchText"].ToString());
                }
            }
        }

        private void btnMgrBack_Click(object sender, EventArgs e)
        {
            paginationManagers.PageBackward();
        }

        private void btnMgrForward_Click(object sender, EventArgs e)
        {
            paginationManagers.PageForward();
        }

        private void dgvManagers_Sorted(object sender, EventArgs e)
        {
            DataGridViewColumn column = dgvManagers.SortedColumn;
            System.Windows.Forms.SortOrder sortOrder = dgvManagers.SortOrder;
            paginationManagers.Sort(column.Name, sortOrder.ToString());
        }

        private void lblMinForm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label25_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 2;
        }

        private void timerMissingValues_Tick(object sender, EventArgs e)
        {
            string s = lblMissingValuesLoading.Text;

            if (s == "Loading...")
                lblMissingValuesLoading.Text = "Loading";
            else
                lblMissingValuesLoading.Text = s + ".";
        }

        /// <summary>
        /// Gets all missing records related to value in <see cref="cboMissingViews"/> and loads <see cref="dgvMissingValues"/> with records.
        /// </summary>
        /// <remarks>
        /// Utilizes background worker to get data from database since it takes a while.
        /// </remarks>
        private void LoadMissingValuesDgv()
        {
            if (cboMissingViews.SelectedIndex == -1)
            {
                MessageBox.Show("Please make a selection in the views drop-down box.", "Attention", MessageBoxButtons.OK);
                return;
            }

            lblMissingValuesLoading.Visible = true;
            lblMissingValuesLoading.BringToFront();

            System.Windows.Forms.Timer timerMissingValues = new System.Windows.Forms.Timer();
            timerMissingValues.Interval = 500;
            timerMissingValues.Tick += new EventHandler(timerMissingValues_Tick);
            timerMissingValues.Start();

            int cboIndex = cboMissingViews.SelectedIndex;

            DataTable dataTable = new DataTable();

            Application.DoEvents();

            BackgroundWorker bw = new BackgroundWorker();

            bw.DoWork += new DoWorkEventHandler(
            delegate(object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;

                if (cboIndex == 0)
                {
                    dataTable = Fund.GetClientMissingValues();
                }
                else if (cboIndex == 1)
                {
                    dataTable = Fund.GetAllMissingValues();
                }
                else
                {
                    dataTable = null;
                }

            });

            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate(object o, ProgressChangedEventArgs args)
            {

            });

            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate(object o, RunWorkerCompletedEventArgs args)
            {
                paginationMissingValues = new Pagination(dgvMissingValues, dataTable);

                if (paginationMissingValues.dataTable.Rows.Count > 0 && paginationMissingValues.dataTable.Rows.Count < 50000)
                {
                    label46.Text = paginationMissingValues.dataTable.Rows.Count.ToString("N0");
                    DataView view = new DataView(paginationMissingValues.dataTable);
                    DataTable distinctValues = view.ToTable(true, "FundId");
                    label48.Text = distinctValues.Rows.Count.ToString("N0");

                    dgvMissingValues.Columns[0].Visible = false;
                    dgvMissingValues.Columns[1].Visible = false;
                }
                else if (paginationMissingValues.dataTable.Rows.Count == 50000)
                {
                    label46.Text = paginationMissingValues.dataTable.Rows.Count.ToString("N0") + "+";
                    DataView view = new DataView(paginationMissingValues.dataTable);
                    DataTable distinctValues = view.ToTable(true, "FundId");
                    label48.Text = distinctValues.Rows.Count.ToString("N0") + "+";

                    dgvMissingValues.Columns[0].Visible = false;
                    dgvMissingValues.Columns[1].Visible = false;
                }

                lblMissingValuesLoading.Visible = false;
                lblMissingValuesLoading.SendToBack();
                timerMissingValues.Dispose();
            });

            bw.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paginationMissingValues.PageBackward();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paginationMissingValues.PageForward();
        }

        private void dgvMissingValues_Sorted(object sender, EventArgs e)
        {
            DataGridViewColumn column = dgvMissingValues.SortedColumn;
            System.Windows.Forms.SortOrder sortOrder = dgvMissingValues.SortOrder;
            paginationMissingValues.Sort(column.Name, sortOrder.ToString());
        }

        private void dgvMissingValues_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvMissingValues.CurrentRow.Index;
            string fundName = dgvMissingValues.Rows[index].Cells[2].Value.ToString();
            label29.Text = fundName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dgvMissingValues.CurrentRow.Index;
            Guid fundId = new Guid(dgvMissingValues.Rows[index].Cells[0].Value.ToString());
            frmFund fundForm = new frmFund(this, fundId);
        }

        private void dgvMissingValues_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvMissingValues.CurrentRow.Index;
            Guid fundId = new Guid(dgvMissingValues.Rows[index].Cells[0].Value.ToString());
            frmFund fundForm = new frmFund(this, fundId);
        }

        private void btnDeactivateFund_Click(object sender, EventArgs e)
        {
            int index = dgvMissingValues.CurrentRow.Index;
            Guid fundId = new Guid(dgvMissingValues.Rows[index].Cells[0].Value.ToString());
            string fundName = dgvMissingValues.Rows[index].Cells[2].Value.ToString();

            DialogResult result = MessageBox.Show("Are you sure you wish to deactivate " + fundName + "?", "Attention", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ISP.Business.Entities.Fund.Deactivate(fundId);

                LoadMissingValuesDgv();
            }
        }

        private void txtImportFileName_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                txtImportLog.Text = file;
            }
        }

        private void txtMarketUpdate_TextChanged(object sender, EventArgs e)
        {
            lblCharCount.Text = txtMarketUpdate.Text.ToString().Count().ToString();
        }

        private void PopulateSelectedReviewCbo()
        {
            List<Business.Entities.QuarterlyMarketsReview> list = Business.Entities.QuarterlyMarketsReview.Active();
            cboSelectedReview.Items.Clear();

            foreach (Business.Entities.QuarterlyMarketsReview qmr in list)
            {
                User _createdBy = new User((Guid)qmr.CreatedBy);
                TimeTable timeTable = new TimeTable(qmr.TimeTableId);
                string s = timeTable.YearValue + " - Q" + timeTable.QuarterValue + " -  " + _createdBy.FullName;
                cboSelectedReview.Items.Add(new Utilities.ListItem(s, qmr));
            }

            if (cboSelectedReview.Items.Count > 0 && cboSelectedReview.SelectedIndex == -1)
                cboSelectedReview.SelectedIndex = 0;
        }

        private void cboSelectedReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSelectedReview.SelectedIndex == -1)
                return;

            QuarterlyMarketsReview review = (QuarterlyMarketsReview)((ListItem)cboSelectedReview.SelectedItem).HiddenObject;
            txtMarketUpdate.Text = review.ReviewText;

            // Automatically selects the quarter value in the quarter cbo based on review's timetableid value
            foreach (ListItem item in cboSelectedQuarter.Items)
            {
                if (((TimeTable)item.HiddenObject).Id == review.TimeTableId)
                {
                    cboSelectedQuarter.SelectedItem = item;
                    break;
                }
            }
        }

        private void SelectReviewFromReviewCbo(Guid quarterlyMarketsUpdateId)
        {
            foreach (ListItem item in cboSelectedReview.Items)
            {
                if (((QuarterlyMarketsReview)item.HiddenObject).Id == quarterlyMarketsUpdateId)
                {
                    cboSelectedReview.SelectedItem = item;
                    break;
                }
            }
        }

        private void SelectReviewFromReviewCbo(string reviewText)
        {
            foreach (ListItem item in cboSelectedReview.Items)
            {
                if (((QuarterlyMarketsReview)item.HiddenObject).ReviewText == reviewText)
                {
                    cboSelectedReview.SelectedItem = item;
                    break;
                }
            }
        }

        private void btnSaveMarketUpdate_Click(object sender, EventArgs e)
        {
            if (cboSelectedReview.SelectedIndex == -1)
                return;

            QuarterlyMarketsReview review = (QuarterlyMarketsReview)((ListItem)cboSelectedReview.SelectedItem).HiddenObject;

            try
            {
                review.ReviewText = txtMarketUpdate.Text;
                review.TimeTableId = ((TimeTable)((ListItem)cboSelectedQuarter.SelectedItem).HiddenObject).Id;
                review.SaveRecordToDatabase(CurrentUser.UserId);
                MessageBox.Show("Record successfully saved!", "Success!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                frmError frmError = new frmError(this, ex);
            }

            PopulateSelectedReviewCbo();
            SelectReviewFromReviewCbo(review.Id);
        }

        private void btnDeleteMarketUpdate_Click(object sender, EventArgs e)
        {
            if (cboSelectedReview.SelectedIndex == -1)
                return;

            QuarterlyMarketsReview review = (QuarterlyMarketsReview)((ListItem)cboSelectedReview.SelectedItem).HiddenObject;

            TimeTable timeTable = new TimeTable(review.TimeTableId);
            DialogResult result = MessageBox.Show("Are you sure you wish to permanantly delete the review for " + timeTable.YearValue + ", Q" + timeTable.QuarterValue
                + " from the database?", "Attention!", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                try
                {
                    review.ReviewText = txtMarketUpdate.Text;
                    review.DeleteRecordFromDatabase();
                    MessageBox.Show("Record successfully deleted!", "Success!", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    frmError frmError = new frmError(this, ex);
                }
            }

            PopulateSelectedReviewCbo();
        }

        private void btnSaveAsNewMarketUpdate_Click(object sender, EventArgs e)
        {
            string reviewText = txtMarketUpdate.Text;

            try
            {
                Guid timeTableId = ((TimeTable)((ListItem)cboSelectedQuarter.SelectedItem).HiddenObject).Id;

                QuarterlyMarketsReview quarterlyMarketsReview = new QuarterlyMarketsReview();
                quarterlyMarketsReview.ReviewText = reviewText;
                quarterlyMarketsReview.TimeTableId = timeTableId;
                quarterlyMarketsReview.SaveRecordToDatabase(CurrentUser.UserId);

                MessageBox.Show("Record successfully saved!", "Success!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                frmError frmError = new frmError(this, ex);
            }

            PopulateSelectedReviewCbo();
            SelectReviewFromReviewCbo(reviewText);
        }

        private void btnGetMissingValues_Click(object sender, EventArgs e)
        {
            LoadMissingValuesDgv();
        }

        private void btnRunDuplicateRecords_Click(object sender, EventArgs e)
        {
            lblDuplicateRecordsCurrentFund.Text = "Select a fund";
            LoadDuplicateRecordsDgv();
        }

        private void timerDuplicateRecords_Tick(object sender, EventArgs e)
        {
            CalculateLoadingAnimation(lblMissingValuesLoading);
        }

        /// <summary>
        /// Recursively sets the text of a control with the text "Loading".
        /// </summary>
        /// <param name="label">Used to get and set loading text.</param>
        /// <remarks>
        /// Will automatically set the text of the control to "Loading" if
        /// it does not already start with "Loading".
        /// </remarks>
        private void CalculateLoadingAnimation(Label label)
        {
            if (label.Text == "Loading..." || label.Text.StartsWith("Loading") == false)
            {
                label.Text = "Loading";
            }
            else
            {
                label.Text = label.Text + ".";
            }
        }

        /// <summary>
        /// Gets all duplicate records related to value in <see cref="cboDuplicateViews"/> and loads <see cref="dgvDuplicateRecords"/> with records.
        /// </summary>
        public void LoadDuplicateRecordsDgv()
        {
            if (cboDuplicateViews.SelectedIndex == -1)
            {
                MessageBox.Show("Please make a selection in the views drop-down box.", "Attention", MessageBoxButtons.OK);
                return;
            }

            lblDuplicateRecordsLoading.Visible = true;
            lblDuplicateRecordsLoading.BringToFront();

            System.Windows.Forms.Timer timerDuplicateRecords = new System.Windows.Forms.Timer();
            timerDuplicateRecords.Interval = 500;
            timerDuplicateRecords.Tick += new EventHandler(timerDuplicateRecords_Tick);
            timerDuplicateRecords.Start();

            DataTable dataTable = new DataTable();

            int cboIndex = cboDuplicateViews.SelectedIndex;

            Application.DoEvents();

            BackgroundWorker bw = new BackgroundWorker();

            bw.DoWork += new DoWorkEventHandler(
            delegate(object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;

                if (cboIndex == 0)
                {
                    dataTable = Fund.GetDuplicateRecordsByMorningstarFundId();
                }
                else if (cboIndex == 1)
                {
                    dataTable = Fund.GetDuplicateRecordsByTicker();
                }
                else if (cboIndex == 2)
                {
                    dataTable = Fund.GetDuplicateRecordsByFundName();
                }

            });

            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate(object o, ProgressChangedEventArgs args)
            {

            });

            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate(object o, RunWorkerCompletedEventArgs args)
            {
                paginationDuplicateRecords = new Pagination(dgvDuplicateRecords, dataTable);
                dgvDuplicateRecords.Columns[0].Visible = false;

                lblTotalDuplicateRecords.Text = paginationDuplicateRecords.dataTable.Rows.Count.ToString("N0");

                lblDuplicateRecordsLoading.Visible = false;
                lblDuplicateRecordsLoading.SendToBack();
                timerDuplicateRecords.Dispose();
            });

            bw.RunWorkerAsync();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 3;
        }

        private void btnDuplicateRecordsBack_Click(object sender, EventArgs e)
        {
            paginationDuplicateRecords.PageBackward();
        }

        private void btnDuplicateRecordsForward_Click(object sender, EventArgs e)
        {
            paginationDuplicateRecords.PageForward();
        }

        private void btnDisableRecord_Click(object sender, EventArgs e)
        {
            if (dgvDuplicateRecords.DataSource == null || dgvDuplicateRecords.Rows.Count == 0)
                return;

            string details = "Are you sure you wish to disable the selected funds?";
            List<Guid> fundIds = new List<Guid>();
            List<string> fundNames = new List<string>();

            foreach (DataGridViewRow dr in dgvDuplicateRecords.Rows)
            {
                if (dr.Selected == true)
                {
                    fundIds.Add(new Guid(dr.Cells[0].Value.ToString()));
                    fundNames.Add(dr.Cells[2].Value.ToString());

                    details = details + Environment.NewLine + "    - " + dr.Cells[2].Value.ToString();
                }
            }

            DialogResult result = MessageBox.Show(details, "Attention", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    foreach (Guid guid in fundIds)
                    {
                        ISP.Business.Entities.Fund.Disable(guid, CurrentUser.UserId);
                    }

                    MessageBox.Show("Record(s) successfully disabled!", "Success!", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    frmError _frmError = new Presentation.Forms.frmError(this, ex);
                }

                LoadDuplicateRecordsDgv();
            }
        }

        private void btnMergeRecords_Click(object sender, EventArgs e)
        {
            List<Guid> fundIds = new List<Guid>();

            int i = 0;

            foreach (DataGridViewRow dr in dgvDuplicateRecords.Rows)
            {
                if (dr.Selected == true)
                {
                    fundIds.Add(new Guid(dr.Cells[0].Value.ToString()));
                    i++;
                }

                if (i >= 3)
                {
                    MessageBox.Show("You may only merge two funds at a time. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                    return;
                }
            }

            if (fundIds.Count == 0)
                return;

            if (fundIds.Count != 2)
            {
                MessageBox.Show("You must select 2 funds to use the merge tool. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                return;
            }

            Fund fund1 = new Fund(fundIds[0]);
            Fund fund2 = new Fund(fundIds[1]);

            frmSplashScreen ss = new frmSplashScreen();
            ss.Show();

            frmMergeFunds mergeFunds = new frmMergeFunds(this, fund1, fund2);

            ss.Close();
        }

        private void dgvDuplicateRecords_Sorted(object sender, EventArgs e)
        {
            DataGridViewColumn column = dgvDuplicateRecords.SortedColumn;
            System.Windows.Forms.SortOrder sortOrder = dgvDuplicateRecords.SortOrder;
            paginationDuplicateRecords.Sort(column.Name, sortOrder.ToString());
        }

        private void btnDuplicateRecordsOpenFund_Click(object sender, EventArgs e)
        {
            List<Guid> fundIds = new List<Guid>();

            int i = 0;

            foreach (DataGridViewRow dr in dgvDuplicateRecords.Rows)
            {
                if (dr.Selected == true)
                {
                    fundIds.Add(new Guid(dr.Cells[0].Value.ToString()));
                    i++;
                }
            }

            if (fundIds.Count == 0)
                return;

            if (fundIds.Count != 1)
            {
                MessageBox.Show("You may only select one fund to be opened at a time.", "Error!", MessageBoxButtons.OK);
                return;
            }

            frmFund fundForm = new frmFund(this, fundIds[0]);
        }

        private void dgvDuplicateRecords_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            List<string> fundNames = new List<string>();

            int i = 0;

            foreach (DataGridViewRow dr in dgvDuplicateRecords.Rows)
            {
                if (dr.Selected == true)
                {
                    fundNames.Add(dr.Cells[2].Value.ToString());
                    i++;
                }
            }

            if (i == 0)
            {
                lblDuplicateRecordsCurrentFund.Text = "Select a fund";
            }
            else if (i == 1)
            {
                lblDuplicateRecordsCurrentFund.Text = fundNames[0];
            }
            else if (i > 1)
            {
                lblDuplicateRecordsCurrentFund.Text = "Multiple funds selected";
            }
        }

        private void btnDeactivateRecord_Click(object sender, EventArgs e)
        {
            if (dgvDuplicateRecords.DataSource == null || dgvDuplicateRecords.Rows.Count == 0)
            {
                return;
            }

            string details = "Are you sure you wish to deactivate the selected funds?";
            List<Guid> fundIds = new List<Guid>();
            List<string> fundNames = new List<string>();

            foreach (DataGridViewRow dr in dgvDuplicateRecords.Rows)
            {
                if (dr.Selected == true)
                {
                    fundIds.Add(new Guid(dr.Cells[0].Value.ToString()));
                    fundNames.Add(dr.Cells[2].Value.ToString());

                    details = details + Environment.NewLine + "    - " + dr.Cells[2].Value.ToString();
                }
            }

            DialogResult result = MessageBox.Show(details, "Attention", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    foreach (Guid fundId in fundIds)
                    {
                        Fund.Deactivate(fundId);
                    }

                    MessageBox.Show("Record(s) successfully deactivated!", "Success!", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    frmError frmError = new frmError(this, ex);
                }

                LoadDuplicateRecordsDgv();
            }
        }

        private void btnNewTaskTime_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentCell == null)
            {
                MessageBox.Show("No task is selected. Please correct and try again.", "Error", MessageBoxButtons.OK);
                return;
            }

            Guid taskId = new Guid(dgvTasks.Rows[dgvTasks.CurrentRow.Index].Cells[0].Value.ToString());
            frmTaskTime frmTaskTime = new frmTaskTime(this, taskId);
            frmTaskTime.FormClosed += frmTaskTime_FormClosed;
        }

        private void lblManagers_Click(object sender, EventArgs e)
        {
            tabMain.SelectedTab = tabMain.TabPages["tabManagers"];
        }

        private void lblAdvisors_Click(object sender, EventArgs e)
        {
            tabMain.SelectedTab = tabMain.TabPages["tabAdvisors"];
        }

        private void btnNewFund_Click(object sender, EventArgs e)
        {
            frmNewFund frmNewFund = new frmNewFund(this);
        }

        private void btnDeleteFund_Click(object sender, EventArgs e)
        {
            if (!Security.IsAdmin())
            {
                MessageBox.Show("You do not have the security permissions required to delete funds. Please contact your system administrator for more information", "Attention", MessageBoxButtons.OK);
                return;
            }

            int _index = dgvFunds.CurrentRow.Index;
            Guid fundId = new Guid(dgvFunds.Rows[_index].Cells["FundId"].Value.ToString());
            Fund fund;

            try
            {
                fund = new Fund(fundId);
            }
            catch (Exception exception)
            {
                frmError frmError = new frmError(this, exception);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to permanently delete the selected fund: " + fund.FundName + "?", "Attention", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    fund.DeleteRecordFromDatabase();
                    MessageBox.Show("Fund successfully deleted from the database.", "Success!", MessageBoxButtons.OK);
                    LoadFundDgv();
                }
                catch (Exception exception)
                {
                    frmError frmError = new frmError(this, exception);
                    return;
                }
            }
        }

        private void btnClearImportFiles_Click(object sender, EventArgs e)
        {
            txtImportLog.Text = null;
            xmlParser.FilesToImport.Clear();
            LoadFilesToImportLst();
            btnStartImport.Enabled = false;
        }

        private void lblSettingsAssetGroup_Click(object sender, EventArgs e)
        {
            tabControlSettings.SelectedIndex = 1;
        }

        private void LoadAssetGroupsDgv()
        {
            cboAssetGroup.Items.Clear();

            cboAssetGroup.Items.Add(new ListItem("", null));

            foreach (AssetGroup assetGroup in AssetGroup.All())
            {
                ListItem listItem = new ListItem(assetGroup.Name, assetGroup);
                cboAssetGroup.Items.Add(listItem);
            }
        }

        private void cboViewsCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategoriesDgv();
        }

        private void LoadCategoriesDgv()
        {
            if (cboViewsCategory.Text == "Active Categories")
            {
                dgvCategories.DataSource = Relational_AssetGroup_Category.GetActive();
                dgvCategories.Columns["Relational_AssetGroup_CategoryId"].Visible = false;
            }
            else if (cboViewsCategory.Text == "Active Categories without Asset Groups")
            {
                dgvCategories.DataSource = Relational_AssetGroup_Category.GetMissingValues();
                dgvCategories.Columns["CategoryId"].Visible = false;
            }
        }

        private void dgvCategories_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            lblRecordSaved.Visible = false;

            if (cboViewsCategory.Text == "Active Categories")
            {
                int index = dgvCategories.CurrentRow.Index;
                Guid relational_AssetGroup_CategoryId = new Guid(dgvCategories.Rows[index].Cells["Relational_AssetGroup_CategoryId"].Value.ToString());
                Relational_AssetGroup_Category relational_AssetGroup_Category = new Relational_AssetGroup_Category(relational_AssetGroup_CategoryId);

                txtCategory.Text = dgvCategories.Rows[index].Cells["Category"].Value.ToString();
                cboAssetGroup.Text = dgvCategories.Rows[index].Cells["AssetGroup"].Value.ToString();
            }
            else if (cboViewsCategory.Text == "Active Categories without Asset Groups")
            {
                int index = dgvCategories.CurrentRow.Index;
                Guid categoryId = new Guid(dgvCategories.Rows[index].Cells["CategoryId"].Value.ToString());
                StringMap stringMap = new StringMap(categoryId);

                txtCategory.Text = stringMap.Value;
                cboAssetGroup.SelectedIndex = 0;
            }
        }

        private void btnSaveAssetGroup_Click(object sender, EventArgs e)
        {
            if (cboAssetGroup.SelectedIndex == -1 || cboAssetGroup.SelectedIndex ==  0)
            {
                MessageBox.Show("You must select an asset group in order to save the record. Please correct and try again.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (cboViewsCategory.Text == "Active Categories")
            {
                int index = dgvCategories.CurrentRow.Index;
                Guid relational_AssetGroup_CategoryId = new Guid(dgvCategories.Rows[index].Cells["Relational_AssetGroup_CategoryId"].Value.ToString());
                Relational_AssetGroup_Category relational_AssetGroup_Category = new Relational_AssetGroup_Category(relational_AssetGroup_CategoryId);

                AssetGroup assetGroup = (AssetGroup)((ListItem)cboAssetGroup.SelectedItem).HiddenObject;
                relational_AssetGroup_Category.AssetGroupId = assetGroup.Id;
                relational_AssetGroup_Category.SaveRecordToDatabase(CurrentUser.UserId);

                lblRecordSaved.Visible = true;
            }
            else if (cboViewsCategory.Text == "Active Categories without Asset Groups")
            {
                int index = dgvCategories.CurrentRow.Index;
                Guid categoryId = new Guid(dgvCategories.Rows[index].Cells["CategoryId"].Value.ToString());
                StringMap stringMap = new StringMap(categoryId);

                Relational_AssetGroup_Category relational_AssetGroup_Category = new Relational_AssetGroup_Category();
                relational_AssetGroup_Category.CategoryId = stringMap.Id;

                AssetGroup assetGroup = (AssetGroup)((ListItem)cboAssetGroup.SelectedItem).HiddenObject;
                relational_AssetGroup_Category.AssetGroupId = assetGroup.Id;

                relational_AssetGroup_Category.SaveRecordToDatabase(CurrentUser.UserId);
            }

            LoadCategoriesDgv();
        }

        private void dgvTasks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvTasks.CurrentRow.Index;
            Guid taskId = new Guid(dgvTasks.Rows[index].Cells["TaskId"].Value.ToString());
            Task task = new Task(taskId);
            frmTask frmTask = new frmTask(this, task);
            frmTask.FormClosed += frmTask_FormClosed;
        }

        private void lblSettingsUsers_Click(object sender, EventArgs e)
        {
            tabControlSettings.SelectedTab = tabControlSettings.TabPages["tabPageUsers"];
            LoadCboSecurityRole();
            LoadCboSecurityUsers();
            LoadUserSettings();
        }

        private void LoadCboSecurityUsers()
        {
            cboSettingsUsers.Items.Clear();

            foreach (var user in DataIntegrationHub.Business.Entities.User.ActiveUsers())
            {
                ListItem listItem = new ListItem(user.FullName, user);
                cboSettingsUsers.Items.Add(listItem);
            }
        }

        private void LoadCboSecurityRole()
        {
            cboSecurityRole.Items.Clear();

            foreach (ISP.Business.Entities.SecurityRole securityRole in ISP.Business.Entities.SecurityRole.ActiveSecurityRoles())
            {
                ListItem listItem = new ListItem(securityRole.Name, securityRole);
                cboSecurityRole.Items.Add(listItem);
            }
        }

        private void LoadUserSettings()
        {
            cboUserViews.SelectedIndex = 0;
        }

        private void cboUserViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgvUserSecurity();
        }

        private void LoadDgvUserSecurity()
        {
            DataTable dataTable;

            if (cboUserViews.SelectedIndex == 0)
            {
                dataTable = ISP.Business.Entities.UserSecurityRole.GetActiveSecurityRoles();
            }
            else
            {
                dataTable = null;
            }

            dgvUserSecurity.DataSource = dataTable;

            dgvUserSecurity.Columns["UserSecurityRoleId"].Visible = false;
        }

        private void dgvUserSecurity_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            lblUserSecuritySaved.Visible = false;

            int index = dgvUserSecurity.CurrentRow.Index;
            Guid userSecurityRoleId = new Guid(dgvUserSecurity.Rows[index].Cells["UserSecurityRoleId"].Value.ToString());
            CurrentUserSecurityRole = new ISP.Business.Entities.UserSecurityRole(userSecurityRoleId);
            LoadUserSecurityRole();
        }

        private void SelectCboSettingUser(DataIntegrationHub.Business.Entities.User user)
        {
            foreach (ListItem item in cboSettingsUsers.Items)
            {
                if (item.HiddenObject is DataIntegrationHub.Business.Entities.User)
                {
                    Guid itemId = ((DataIntegrationHub.Business.Entities.User)item.HiddenObject).UserId;

                    if (itemId == user.UserId)
                    {
                        cboSettingsUsers.SelectedItem = item;
                        return;
                    }
                }
            }
        }

        private void SelectCboSecurityRole(ISP.Business.Entities.SecurityRole securityRole)
        {
            foreach (ListItem item in cboSecurityRole.Items)
            {
                if (item.HiddenObject is ISP.Business.Entities.SecurityRole)
                {
                    Guid itemId = ((ISP.Business.Entities.SecurityRole)item.HiddenObject).Id;

                    if (itemId == securityRole.Id)
                    {
                        cboSecurityRole.SelectedItem = item;
                        return;
                    }
                }
            }
        }

        private void LoadUserSecurityRole()
        {
            User user = new User(CurrentUserSecurityRole.UserId);
            lblSelectedUser.Text = user.FullName;
            
            ISP.Business.Entities.SecurityRole securityRole = new ISP.Business.Entities.SecurityRole(CurrentUserSecurityRole.SecurityRoleId);
            SelectCboSecurityRole(securityRole);
            SelectCboSettingUser(user);
        }

        private void btnSaveUserSecurity_Click(object sender, EventArgs e)
        {
            var user = (DataIntegrationHub.Business.Entities.User)((ListItem)cboSettingsUsers.SelectedItem).HiddenObject;
            var securityRole = (ISP.Business.Entities.SecurityRole)((ListItem)cboSecurityRole.SelectedItem).HiddenObject;

            ListItem item = (ListItem)cboSecurityRole.SelectedItem;
            CurrentUserSecurityRole.UserId = user.UserId;
            CurrentUserSecurityRole.SecurityRoleId = securityRole.Id;
            CurrentUserSecurityRole.SaveRecordToDatabase(CurrentUser.UserId);

            ISP.Business.Entities.UserSecurityRole savedUserSecurityRole = CurrentUserSecurityRole;

            LoadDgvUserSecurity();
            SelectDgvUserSecurityRole(savedUserSecurityRole);

            lblUserSecuritySaved.Visible = true;
        }

        private void SelectDgvUserSecurityRole(ISP.Business.Entities.UserSecurityRole userSecurityRole)
        {
            foreach (DataGridViewRow dataRow in dgvUserSecurity.Rows)
            {
                Guid userSecurityRoleId = new Guid(dataRow.Cells["UserSecurityRoleId"].Value.ToString());
                if (userSecurityRoleId == userSecurityRole.Id)
                {
                    dgvUserSecurity.CurrentCell = dgvUserSecurity.Rows[dataRow.Index].Cells[1];
                    return;
                }
            }
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            int index = dgvUserSecurity.CurrentRow.Index;
            Guid userSecurityRoleId = new Guid(dgvUserSecurity.Rows[index].Cells["UserSecurityRoleId"].Value.ToString());
            CurrentUserSecurityRole = new ISP.Business.Entities.UserSecurityRole(userSecurityRoleId);
            CurrentUserSecurityRole.DeleteRecordFromDatabase();

            LoadDgvUserSecurity();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var user = (DataIntegrationHub.Business.Entities.User)((ListItem)cboSettingsUsers.SelectedItem).HiddenObject;
            var securityRole = (ISP.Business.Entities.SecurityRole)((ListItem)cboSecurityRole.SelectedItem).HiddenObject;

            var userSecurityRole = new ISP.Business.Entities.UserSecurityRole();
            userSecurityRole.UserId = user.UserId;
            userSecurityRole.SecurityRoleId = securityRole.Id;
            userSecurityRole.SaveRecordToDatabase(CurrentUser.UserId);

            CurrentUserSecurityRole = userSecurityRole;

            LoadDgvUserSecurity();
            SelectDgvUserSecurityRole(userSecurityRole);
            lblUserSecuritySaved.Visible = true;
        }

        private void btnDgvTasksForward_Click(object sender, EventArgs e)
        {
            paginationTasks.PageForward();
        }

        private void btnDgvTasksBack_Click(object sender, EventArgs e)
        {
            paginationTasks.PageBackward();
        }

        private void dgvTasks_Sorted(object sender, EventArgs e)
        {
            DataGridViewColumn column = dgvTasks.SortedColumn;
            System.Windows.Forms.SortOrder sortOrder = dgvTasks.SortOrder;
            paginationTasks.Sort(column.Name, sortOrder.ToString());
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int index = dgvAdvisors.CurrentRow.Index;
            Guid advisorId = new Guid(dgvAdvisors.Rows[index].Cells[0].Value.ToString());
            Advisors advisor = new Advisors(advisorId);
            advisor.DeleteRecordFromDatabase();
            paginationAdvisors = new Pagination(dgvAdvisors, Business.Entities.Advisors.GetActive());
            dgvAdvisors.Columns[0].Visible = false;
        }
    }
}