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

        private Stopwatch stopWatch = new Stopwatch();
        private XmlParser xmlParser;
        private Pagination paginationAdvisors;
        private Pagination paginationFunds;
        private Pagination paginationManagers;
        private Pagination paginationTasks;
        private Pagination paginationMissingValues;
        private Pagination paginationDuplicateRecords;
        private OpenFileDialog importFilesDialog;

        public frmMain()
		{
            InitializeComponent();

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

            //Check the connection and return if no connection exists.
            if (!ConnectionSucceeded()) return;

            //Check if user exists and create user if it doesn't
            LoginCurrentUser();

            // Initialize user controls. This has to be done after the user has been logged in.
            ucClients.Initialize(this);
            ucSettings.Initialize(this);

            //Set maximum size
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            //Load related cboBoxes and dgv's
            LoadAutoCompleteAdvisors();
            LoadAutoCompleteFunds();

            //Get number of open tasks and draw notification label
            HandleTaskNotifications();

            //Add the version number on the top pnl
            HandleAppVersion();

            //Setup lbl and dgv on dashboard
            HandleDashboardTasks();

            //Start app with the dashbaord tab
            tabMain.SelectedIndex = 8;

            //Set default view values
			cboTaskViews.SelectedIndex = 0;
			cboFundViews.SelectedIndex = 0;
            cboAdvisorViews.SelectedIndex = 0;
            cboManagerViews.SelectedIndex = 0;

            LoadTasksDgv();

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

        private void HandleAppVersion()
        {
            //Check if app is network deployed
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                //Get version number and set label
                string version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                lblFormHeader.Text = lblFormHeader.Text + " - v" + version;
            }
        }

        private void HandleTaskNotifications(int num = -1)
        {
            //If number was not set
            if (num == -1)
                num = Task.GetActiveAssociatedFromUser(CurrentUser.UserId).Rows.Count;

            //Draw notification if new notification exists
            if (num > 0 && num.ToString().Length > 0)
            {
                openTaskNotifications = num;

                string text = num.ToString();
                label106.Text = text;

                System.Drawing.Drawing2D.GraphicsPath label106Path;

                label106Path = new System.Drawing.Drawing2D.GraphicsPath();

                if (text.ToString().Length == 1)
                {
                    label106Path.AddEllipse(-1, (float)0.5, 13, 13);
                }
                else if (text.ToString().Length == 2)
                {
                    label106Path.AddEllipse(-1, 0, 19, 14);
                }
                else if (text.ToString().Length > 2)
                {
                    label106Path.AddEllipse((float)-1.0, (float)1.5, 11, 11);
                    label106.Text = "!";
                }

                this.label106.Region = new Region(label106Path);

                label106.Visible = true;
            }
        }

        private void LoginCurrentUser()
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
            }
            catch (Exception ex)
            {
                lblLoginStatus.Text = "An error occurred while logging you in.";
                frmError _frmError = new Presentation.Forms.frmError(this, ex);
                _frmError.FormClosed += frmMain_FormClosedEventHandler;
                return;
            }
        }

        void frmMain_FormClosedEventHandler(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void LoadAutoCompleteAdvisors()
        {
            txtAdvSearch.AutoCompleteCustomSource.Clear();

            foreach (DataRow dr in ISP.Business.Entities.UserSearches.Get(CurrentUser.UserId, "Advisors").Rows)
            {
                txtAdvSearch.AutoCompleteCustomSource.Add(dr["SearchText"].ToString());
            }
        }

        private void LoadAutoCompleteFunds()
        {
            txtFundsSearch.AutoCompleteCustomSource.Clear();

            foreach (DataRow dr in ISP.Business.Entities.UserSearches.Get(CurrentUser.UserId, "Funds").Rows)
            {
                txtFundsSearch.AutoCompleteCustomSource.Add(dr["SearchText"].ToString());
            }
		}
		
		void DataGridViewFunds_Focus(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvFunds.CurrentRow.Index;
            lblSelectedFund.Text = dgvFunds.Rows[index].Cells[1].Value.ToString();
		}
		
		void txtFundsSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                paginationFunds = new Pagination(dgvFunds, Business.Entities.Fund.SearchByFundNameAndTicker(txtFundsSearch.Text));
                dgvFunds.Columns[0].Visible = false;

                if (!String.IsNullOrEmpty(txtFundsSearch.Text))
                {
                    ISP.Business.Entities.UserSearches.Insert(CurrentUser.UserId, txtFundsSearch.Text, "Funds");
                    txtFundsSearch.AutoCompleteCustomSource.Clear();

                    foreach (DataRow dr in Business.Entities.UserSearches.Get(CurrentUser.UserId, "Funds").Rows)
                        txtFundsSearch.AutoCompleteCustomSource.Add(dr["SearchText"].ToString());
                }
	   		}			
		}

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
		
		void CloseAccount(object sender, FormClosedEventArgs e)
		{
            ucClients.LoadAccountDgv();
		}
		
		void OpenFund()
		{
			int index = dgvFunds.CurrentRow.Index;
            Guid fundId = new Guid(dgvFunds.Rows[index].Cells[0].Value.ToString());

            frmFund fundForm = new frmFund(this, fundId);
			
		}
        
        private void LoadTasksDgv()
        {
            DataTable _dataTable = new DataTable();

            // Set the datatable based on which view is selected
            switch (cboTaskViews.SelectedIndex)
            {
                case 0:
                    _dataTable = Business.Entities.Task.GetActiveAssociatedFromUser(CurrentUser.UserId);
                    break;
                case 1:
                    _dataTable = Business.Entities.Task.GetInactiveAssociatedFromUser(CurrentUser.UserId);
                    break;
                case 2:
                    _dataTable = Business.Entities.Task.GetActive();
                    break;
                case 3:
                    _dataTable = Business.Entities.Task.GetInactive();
                    break;
                default:
                    return;
            }

            // Create and set the owner column values
            DataColumn _column = new DataColumn();
            _column.ColumnName = "Owner";
            _dataTable.Columns.Add(_column);

            foreach (DataRow _row in _dataTable.Rows)
            {
                Guid _userId = new Guid(_row["OwnerId"].ToString());
                User _user = new User(_userId);
                _row["Owner"] = _user.FullName;
            }

            // Set the datagridview to the datatable and instantiate the pagination object
            paginationTasks = new Pagination(dgvTasks, _dataTable);

            // Display/order the columns
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

        private void LoadTasksControls()
        {

            btnTaskComplete.Enabled = true;
            btnTaskOpenFund.Enabled = true;

            if (dgvTaskTimes.CurrentCell == null)
                btnEditTaskTime.Enabled = false;
            else
                btnEditTaskTime.Enabled = true;

            if (dgvTasks.Rows.Count > 0)
            {
                dgvTasks.CurrentCell = dgvTasks[5, 0];
            }
            else
            {
                dgvTaskTimes.DataSource = null;
            }

            if (cboTaskViews.SelectedIndex == 0 || cboTaskViews.SelectedIndex == 2)
            {
                btnTaskComplete.Text = "Complete";

                if (dgvTasks.Rows.Count == 0)
                {
                    btnTaskComplete.Enabled = false;
                    btnTaskOpenFund.Enabled = false;
                    btnEditTaskTime.Enabled = false;
                }
            }
            else
            {
                btnTaskComplete.Text = "Re-open";

                if (dgvTasks.Rows.Count == 0)
                {
                    btnTaskComplete.Enabled = false;
                    btnTaskOpenFund.Enabled = false;
                    btnEditTaskTime.Enabled = false;
                }
            }
        }
		
        private void cboTaskViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTasksDgv();
            LoadTasksControls();
		}

        private void ButtonNewTaskClick(object sender, EventArgs e)
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
		
		void ButtonDeleteTaskClick(object sender, EventArgs e)
		{
			int index = dgvTasks.CurrentRow.Index;
            Guid taskId = new Guid(dgvTasks.Rows[index].Cells[0].Value.ToString());
			string userName = dgvTasks.Rows[index].Cells[4].Value.ToString();
			string taskName = dgvTasks.Rows[index].Cells[5].Value.ToString();
			
			DialogResult dialogResult = MessageBox.Show("Are you sure you wish to permanently delete task " + taskName + " for " + userName + "?", "Delete Task", MessageBoxButtons.OKCancel);
			
			if (dialogResult == DialogResult.OK)
            {
                ISP.Business.Entities.Task.Delete(taskId);
                LoadTasksDgv();
			}

            //HandleTaskView(dgvTasks, cboTaskViews);
		}

        private void dataGridViewTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Setup local variables
            int index = dgvTasks.CurrentRow.Index;
            Guid taskId = new Guid(dgvTasks.Rows[index].Cells[0].Value.ToString());
            Guid FundId = Guid.Empty;
            Guid AccountId = Guid.Empty;
            Guid ManagerId = Guid.Empty;
            string taskName = dgvTasks.Rows[index].Cells[5].Value.ToString();
            string fundName = dgvTasks.Rows[index].Cells[8].Value.ToString();
            
            //Set IDs if they exist
            if (String.IsNullOrEmpty(dgvTasks.Rows[index].Cells[1].Value.ToString()) == false)
                FundId = new Guid(dgvTasks.Rows[index].Cells[1].Value.ToString());
            if (String.IsNullOrEmpty(dgvTasks.Rows[index].Cells[2].Value.ToString()) == false)
                AccountId = new Guid(dgvTasks.Rows[index].Cells[2].Value.ToString());
            if (String.IsNullOrEmpty(dgvTasks.Rows[index].Cells[3].Value.ToString()) == false)
                ManagerId = new Guid(dgvTasks.Rows[index].Cells[3].Value.ToString());

            //Handle Open Fund button
            if (FundId == Guid.Empty)
            { btnTaskOpenFund.Enabled = false; }
            else
            { btnTaskOpenFund.Enabled = true; }

            //Handle Open Manager button
            if (ManagerId == Guid.Empty)
            { btnTaskOpenMgr.Enabled = false; }
            else
            { btnTaskOpenMgr.Enabled = true; }

            //Handle Open Account button
            if (AccountId == Guid.Empty)
            { btnTaskOpenAdv.Enabled = false; }
            else
            { btnTaskOpenAdv.Enabled = true; }

            //Load dgvTaskTimes
            dgvTaskTimes.DataSource = TaskTime.GetAssociatedFromTask(taskId);
            dgvTaskTimes.Columns[0].Visible = false;
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
            int index = dgvTasks.CurrentRow.Index;
            Guid taskId = new Guid(dgvTasks.Rows[index].Cells[0].Value.ToString());
            string name = dgvTasks.Rows[index].Cells[5].Value.ToString();

            if (btnTaskComplete.Text == "Complete")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to mark " + name + " complete?", "Attention", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    ISP.Business.Entities.Task.SetComplete(taskId, CurrentUser.UserId);

                    LoadTasksDgv();
                    LoadTasksControls();
                }
            }
            else if (btnTaskComplete.Text == "Re-open")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to reopen " + name + "?", "Attention", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    ISP.Business.Entities.Task.SetOpen(taskId, CurrentUser.UserId);

                    LoadTasksDgv();
                    LoadTasksControls();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int index = dgvTasks.CurrentRow.Index;
            Guid fundId = new Guid(dgvTasks.Rows[index].Cells[1].Value.ToString());

            frmFund fundForm = new frmFund(this, fundId);
        }

        private void AdvisorFormClosed(object sender, FormClosedEventArgs e)
        {
            paginationAdvisors = new Pagination(dgvAdvisors, Business.Entities.Advisors.GetActive());
            dgvAdvisors.Columns[0].Visible = false;
        }

        private void NewAdvisor(object sender, EventArgs e)
        {
            Presentation.Forms.frmAdvisor advisorForm = new Presentation.Forms.frmAdvisor(this, AdvisorFormClosed);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index = dgvAdvisors.CurrentRow.Index;
            Guid advisorId = new Guid(dgvAdvisors.Rows[index].Cells[0].Value.ToString());
            Presentation.Forms.frmAdvisor advisorForm = new Presentation.Forms.frmAdvisor(this, advisorId, AdvisorFormClosed);
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvAdvisors.CurrentRow.Index;
            Guid advisorId = new Guid(dgvAdvisors.Rows[index].Cells[0].Value.ToString());
            Presentation.Forms.frmAdvisor advisorForm = new Presentation.Forms.frmAdvisor(this, advisorId, AdvisorFormClosed);
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
            frmManager _frmManager = new frmManager(this, managerId);
            _frmManager.FormClosed += ManagerFormClosed;
        }

        private void btnEditTaskTime_Click(object sender, EventArgs e)
        {
            if (dgvTaskTimes.CurrentCell == null)
            {
                MessageBox.Show("No Time Entry is selected", "Error", MessageBoxButtons.OK);
            }
            else
            {
                Guid taskTimeId = new Guid(dgvTaskTimes.Rows[dgvTaskTimes.CurrentRow.Index].Cells[0].Value.ToString());
                Guid taskId = new Guid(dgvTasks.Rows[dgvTasks.CurrentRow.Index].Cells[0].Value.ToString());
                Presentation.Forms.frmTaskTime _frmTaskTime = new Presentation.Forms.frmTaskTime(this, taskId, taskTimeId, TaskTimeFormClosed);
            }
        }

        private void TaskTimeFormClosed(object sender, FormClosedEventArgs e)
        {
            LoadTasksDgv();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvTaskTimes.Rows.Count == 0)
            {
                btnEditTaskTime.Enabled = false;
            }
            else
            {
                if (dgvTaskTimes.CurrentCell != null)
                {
                    btnEditTaskTime.Enabled = true;
                }
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnEditTaskTime.Enabled = true;
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

        private void HandleDashboardTasks()
        {
            LoadDshTasksDgv();

            if (dgvDshTasks.Rows.Count == 0)
            {
                dgvDshTasks.Visible = false;
                btnToTasks.Visible = false;
                label84.Text = "All tasks completed";
                lblDshTaskStatus.Visible = true;
            }
            else
            {
                if (dgvDshTasks.Rows.Count == 1)
                    label84.Text = "You have 1 open task";
                else
                    label84.Text = "You have " + dgvDshTasks.Rows.Count + " open tasks";
                
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
            label106.Visible = false;

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
            tabControl3.SelectedIndex = 0;
        }

        private void btnAddImportFile_Click(object sender, EventArgs e)
        {
            importFilesDialog = new OpenFileDialog();

            importFilesDialog.Filter = "XML Files (*.xml)|*.xml";
            importFilesDialog.FilterIndex = 1;
            importFilesDialog.Multiselect = true;

            DialogResult openFileResult = importFilesDialog.ShowDialog();

            if (openFileResult == DialogResult.OK)
            {
                btnStartImport.Enabled = true;

                XmlParser.Utilities.ImportFileItem selectedItem = new XmlParser.Utilities.ImportFileItem(importFilesDialog.FileName, importFilesDialog.SafeFileName);

                xmlParser.FilesToImport.Add(selectedItem);

                if (xmlParser.FilesToImport.Count == 0)
                {
                    txtImportLog.Text = null;
                }
                else
                {
                    txtImportLog.Text = "Selected Files:";

                    foreach (XmlParser.Utilities.ImportFileItem item in xmlParser.FilesToImport)
                    {
                        txtImportLog.Text = txtImportLog.Text + Environment.NewLine + "   " + item.SafeName + ";";
                    }
                }
            }
        }
        
        private void btnRemoveImportFile_Click(object sender, EventArgs e)
        {
            if (xmlParser.FilesToImport.Count == 0)
            {
                txtImportLog.Text = null;
                return;
            }

            int i = xmlParser.FilesToImport.Count;
            XmlParser.Utilities.ImportFileItem selectedItem = xmlParser.FilesToImport[i - 1];
            xmlParser.FilesToImport.Remove(selectedItem);

            if (xmlParser.FilesToImport.Count == 0)
            {
                txtImportLog.Text = null;
            }
            else
            {
                txtImportLog.Text = "Selected Files:";

                foreach (Xml.XmlParser.Utilities.ImportFileItem item in xmlParser.FilesToImport)
                {
                    txtImportLog.Text = txtImportLog.Text + Environment.NewLine + "   " + item.SafeName + ";";
                }
            }
        }

        private void btnStartImport_Click(object sender, EventArgs e)
        {
            // Setup global variables
            int totalFilesCount = xmlParser.FilesToImport.Count;

            // Setup UI controls
            btnAddImportFile.Enabled = false;
            btnRemoveImportFile.Enabled = false;
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
                        txtImportFileName.Text = xmlParser.CurrentFile.SafeName;
                });

                backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate(object o, RunWorkerCompletedEventArgs args)
                {
                    if (_errorLog != xmlParser.ErrorLog)
                    {
                        _errorLog = xmlParser.ErrorLog;
                        MessageBox.Show("An error occurred during file import: " + _errorLog, "Error", MessageBoxButtons.OK);
                    }

                    if (progressBar.Value != Decimal.ToInt32(xmlParser.PercentComplete * 100))
                        progressBar.Value = Decimal.ToInt32(xmlParser.PercentComplete * 100);

                    if (txtImportLog.Text != xmlParser.EventLog)
                        txtImportLog.Text = xmlParser.EventLog;

                    if (lblTotalImportProgress.Text != "(" + (xmlParser.CurrentFileIndex).ToString() + " of " + totalFilesCount.ToString() + ")")
                        lblTotalImportProgress.Text = "(" + (xmlParser.CurrentFileIndex).ToString() + " of " + totalFilesCount.ToString() + ")";

                    if (txtImportFileName.Text != xmlParser.CurrentFile.SafeName)
                        txtImportFileName.Text = xmlParser.CurrentFile.SafeName;
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

            btnAddImportFile.Enabled = true;
            btnRemoveImportFile.Enabled = true;
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
            tabControl3.SelectedIndex = 1;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            int index = dgvTasks.CurrentRow.Index;
            Guid managerId = new Guid(dgvTasks.Rows[index].Cells[3].Value.ToString());
            frmManager _frmManager = new frmManager(this, managerId);
            _frmManager.FormClosed += ManagerFormClosed;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            int index = dgvTasks.CurrentRow.Index;
            Guid accountId = new Guid(dgvTasks.Rows[index].Cells[2].Value.ToString());

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

                    ISP.Business.Entities.Relational_Funds_Plans.SaveAssetValues(rfpId, assetValue, assetValueAsOf);
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
                    //Get number of open tasks
                    num = ISP.Business.Entities.Task.GetActiveAssociatedFromUser(CurrentUser.UserId).Rows.Count;
                });

                _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate(object o, RunWorkerCompletedEventArgs args)
                {
                    //New tasks exist
                    if (num > openTaskNotifications)
                    {
                        //Draw label with number of unchecked, open tasks
                        HandleTaskNotifications(num - openTaskNotifications);
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

                paginationAdvisors = new Pagination(dgvAdvisors, Business.Entities.Advisors.SearchActive(txtAdvSearch.Text));
                dgvAdvisors.Columns[0].Visible = false;

                if (!String.IsNullOrEmpty(txtAdvSearch.Text))
                {
                    ISP.Business.Entities.UserSearches.Insert(CurrentUser.UserId, txtAdvSearch.Text, "Advisors");
                    txtAdvSearch.AutoCompleteCustomSource.Clear();

                    foreach (DataRow dr in Business.Entities.UserSearches.Get(CurrentUser.UserId, "Advisors").Rows)
                        txtAdvSearch.AutoCompleteCustomSource.Add(dr["SearchText"].ToString());
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
            OpenFund();
        }

        private void dgvFunds_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenFund();
        }

        public void ManagerFormClosed(object sender, FormClosedEventArgs e)
        {
            LoadManagersDgv();
        }

        private void selectMgrCboIndex(int index)
        {
            cboManagerViews.SelectedIndex = index;
        }

        private void btnManagerNew_Click(object sender, EventArgs e)
        {
            frmManager _frmManager = new frmManager(this);
            _frmManager.FormClosed += ManagerFormClosed;
        }

        private void btnManagerDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedManager();
        }

        private void DeleteSelectedManager()
        {
            int dgvIndex = dgvManagers.CurrentCell.RowIndex;
            Guid managerId = new Guid(dgvManagers.Rows[dgvIndex].Cells[0].Value.ToString());
            string fullname = dgvManagers.Rows[dgvIndex].Cells[1].Value.ToString();

            DialogResult result = MessageBox.Show("Are you sure you wish to delete the following manager: " + fullname + "?", "Attention", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Business.Entities.Manager.Delete(managerId);
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
                    ISP.Business.Entities.UserSearches.Insert(CurrentUser.UserId, txtMgrSearch.Text, "Managers");
                    txtMgrSearch.AutoCompleteCustomSource.Clear();

                    foreach (DataRow dr in Business.Entities.UserSearches.Get(CurrentUser.UserId, "Managers").Rows)
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
                    dataTable = Business.Entities.Fund.GetClientMissingValues();
                else if (cboIndex == 1)
                    dataTable = Business.Entities.Fund.GetAllMissingValues();
                else
                    dataTable = null;

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
                User _createdBy = new User(qmr.CreatedBy);
                string s = qmr.Time.YearValue + " - Q" + qmr.Time.QuarterValue + " -  " + _createdBy.FullName;
                cboSelectedReview.Items.Add(new Utilities.ListItem(s, qmr));
            }

            if (cboSelectedReview.Items.Count > 0 && cboSelectedReview.SelectedIndex == -1)
                cboSelectedReview.SelectedIndex = 0;
        }

        private void cboSelectedReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSelectedReview.SelectedIndex == -1)
                return;

            Business.Entities.QuarterlyMarketsReview review = (Business.Entities.QuarterlyMarketsReview)((Utilities.ListItem)cboSelectedReview.SelectedItem).HiddenObject;
            txtMarketUpdate.Text = review.ReviewText;

            // Automatically selects the quarter value in the quarter cbo based on review's timetableid value
            foreach (Utilities.ListItem item in cboSelectedQuarter.Items)
            {
                if (((Business.Entities.TimeTable)item.HiddenObject).TimeTableId == review.Time.TimeTableId)
                {
                    cboSelectedQuarter.SelectedItem = item;
                    break;
                }
            }
        }

        private void SelectReviewFromReviewCbo(Guid quarterlyMarketsUpdateId)
        {
            foreach (Utilities.ListItem item in cboSelectedReview.Items)
            {
                if (((Business.Entities.QuarterlyMarketsReview)item.HiddenObject).QuarterlyMarketsReviewId == quarterlyMarketsUpdateId)
                {
                    cboSelectedReview.SelectedItem = item;
                    break;
                }
            }
        }

        private void SelectReviewFromReviewCbo(string reviewText)
        {
            foreach (Utilities.ListItem item in cboSelectedReview.Items)
            {
                if (((Business.Entities.QuarterlyMarketsReview)item.HiddenObject).ReviewText == reviewText)
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
            
            Business.Entities.QuarterlyMarketsReview review = (Business.Entities.QuarterlyMarketsReview)((Utilities.ListItem)cboSelectedReview.SelectedItem).HiddenObject;

            try
            {
                review.ReviewText = txtMarketUpdate.Text;
                review.Time = new Business.Entities.TimeTable(((Business.Entities.TimeTable)((Utilities.ListItem)cboSelectedQuarter.SelectedItem).HiddenObject).TimeTableId);
                review.SaveToDateBase(CurrentUser.UserId);
                MessageBox.Show("Record successfully saved!", "Success!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                frmError _frmError = new Presentation.Forms.frmError(this, ex);
            }

            PopulateSelectedReviewCbo();
            SelectReviewFromReviewCbo(review.QuarterlyMarketsReviewId);
        }

        private void btnDeleteMarketUpdate_Click(object sender, EventArgs e)
        {
            if (cboSelectedReview.SelectedIndex == -1)
                return;

            Business.Entities.QuarterlyMarketsReview review = (Business.Entities.QuarterlyMarketsReview)((Utilities.ListItem)cboSelectedReview.SelectedItem).HiddenObject;

            DialogResult result = MessageBox.Show("Are you sure you wish to permanantly delete the review for " + review.Time.YearValue + ", Q" + review.Time.QuarterValue
                + " from the database?", "Attention!", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                try
                {
                    review.ReviewText = txtMarketUpdate.Text;
                    review.DeleteFromDataBase(CurrentUser.UserId);
                    MessageBox.Show("Record successfully deleted!", "Success!", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    frmError _frmError = new Presentation.Forms.frmError(this, ex);
                }
            }

            PopulateSelectedReviewCbo();
        }

        private void btnSaveAsNewMarketUpdate_Click(object sender, EventArgs e)
        {
            string reviewText = txtMarketUpdate.Text;

            try
            {
                Guid timeTableId = ((Business.Entities.TimeTable)((Utilities.ListItem)cboSelectedQuarter.SelectedItem).HiddenObject).TimeTableId;
                Business.Entities.QuarterlyMarketsReview.Insert(reviewText, timeTableId, CurrentUser.UserId);
                MessageBox.Show("Record successfully saved!", "Success!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                frmError _frmError = new Presentation.Forms.frmError(this, ex);
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
            string s = lblMissingValuesLoading.Text;

            if (s == "Loading...")
                lblDuplicateRecordsLoading.Text = "Loading";
            else
                lblDuplicateRecordsLoading.Text = s + ".";
        }

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
                    dataTable = Business.Entities.Fund.GetDuplicateRecordsByMorningstarFundId();
                }
                else if (cboIndex == 1)
                {
                    dataTable = Business.Entities.Fund.GetDuplicateRecordsByTicker();
                }
                else if (cboIndex == 2)
                {
                    dataTable = Business.Entities.Fund.GetDuplicateRecordsByFundName();
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
                return;

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
                    foreach (Guid guid in fundIds)
                    {
                        ISP.Business.Entities.Fund.Deactivate(guid);
                    }

                    MessageBox.Show("Record(s) successfully deactivated!", "Success!", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    frmError _frmError = new Presentation.Forms.frmError(this, ex);
                }

                LoadDuplicateRecordsDgv();
            }
        }

        private void btnNewTaskTime_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentCell == null)
            {
                MessageBox.Show("No task is selected. Please correct and try again.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                Guid taskId = new Guid(dgvTasks.Rows[dgvTasks.CurrentRow.Index].Cells[0].Value.ToString());
                Presentation.Forms.frmTaskTime _frmTaskTime = new Presentation.Forms.frmTaskTime(this, taskId, TaskTimeFormClosed);
            }
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
            frmNewFund _frmNewFund = new frmNewFund(this);
        }

        private void btnDeleteFund_Click(object sender, EventArgs e)
        {
            if (!Security.IsAdmin())
            {
                MessageBox.Show("You do not have the security permissions required to delete funds. Please contact your system administrator for more information", "Attention", MessageBoxButtons.OK);
                return;
            }

            int _index = dgvFunds.CurrentRow.Index;
            Guid _fundId = new Guid(dgvFunds.Rows[_index].Cells["FundId"].Value.ToString());
            Fund _fund;

            try
            {
                _fund = new Fund(_fundId);
            }
            catch(Exception _exception)
            {
                frmError _frmError = new frmError(this, _exception);
                return;
            }

            DialogResult _dialogResult = MessageBox.Show("Are you sure you wish to permanently delete the selected fund: " + _fund.FundName + "?", "Attention", MessageBoxButtons.YesNoCancel);
            if (_dialogResult == DialogResult.Yes)
            {
                try
                {
                    _fund.DeleteFromDatabase();
                    MessageBox.Show("Fund successfully deleted from the database.", "Success!", MessageBoxButtons.OK);
                    LoadFundDgv();
                }
                catch (Exception _exception)
                {
                    frmError _frmError = new frmError(this, _exception);
                    return;
                }
            }
        }
	}
}