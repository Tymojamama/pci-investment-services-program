using DataIntegrationHub.Business.Entities;

using ISP.Business.Entities;
using ISP.Presentation;
using ISP.Presentation.Utilities;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;

namespace ISP.Presentation.Forms
{
    /// <summary>
    /// Represents a Windows Forms UI used for interacting with Task database data.
    /// </summary>
    public partial class frmTask : Form, IMessageFilter
    {
        #region IMessageFilter Members

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

        /// <summary>
        /// Filters out a message before it is dispatched.
        /// </summary>
        /// <param name="m">The message to be dispatched. You cannot modify this message.</param>
        /// <returns>
        /// true to filter the message and stop it from being dispatched; false to allow the
        /// message to continue to the next filter or control.
        /// </returns>
        public bool PreFilterMessage(ref Message m)
        {
            int WM_NCLBUTTONDOWN = 0xA1;
            int HT_CAPTION = 0x2;
            int WM_LBUTTONDOWN = 0x0201;

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

        /// <summary>
        /// Represents the underlying <see cref="DatabaseEntity"/> that the form is modeling.
        /// </summary>
        public Task CurrentTask;

        /// <summary>
        /// Identifies if the form is in the process of initialing setting fields.
        /// </summary>
        /// <remarks>
        /// This is to ensure that events like SelectedIndexChanged don't overwrite data
        /// that was supposed to have been set when constructing the form.
        /// </remarks>
        public bool IsFillingComponents { get; private set; }

        private frmMain frmMain_Parent;

        /// <summary>
        /// Instantiates a Task form of a new <see cref="Task"/> to be created.
        /// </summary>
        /// <param name="_frmMain"></param>
        public frmTask(frmMain _frmMain)
        {
            frmSplashScreen frmSplashScreen = new frmSplashScreen();
            frmSplashScreen.Show();
            Application.DoEvents();

            IsFillingComponents = true;

            InitializeComponent();
            FillComponent();
            SetComponent(null);
            PrepareMessageFilter();

            IsFillingComponents = false;

            frmMain_Parent = _frmMain;

            cboTaskType.Select();

            this.Show();
            frmSplashScreen.Close();
		}
        
        /// <summary>
        /// Instantiates a Task form representing an existing <see cref="Task"/> in the database.
        /// </summary>
        /// <param name="_frmMain"></param>
        /// <param name="task"></param>
        public frmTask(frmMain _frmMain, Task task)
        {
            frmSplashScreen frmSplashScreen = new frmSplashScreen();
            frmSplashScreen.Show();
            Application.DoEvents();

            IsFillingComponents = true;

            InitializeComponent();
            FillComponent();
            SetComponent(task);
            PrepareMessageFilter();

            IsFillingComponents = false;

            frmMain_Parent = _frmMain;

            cboTaskType.Select();

            this.Show();
            frmSplashScreen.Close();
        }

        private void FillComponent()
        {
            LoadCboTaskType();
            LoadCboOwner();
        }

        private void LoadDgvTaskTime()
        {
            dgvTaskTimes.DataSource = TaskTime.GetAssociatedFromTask(CurrentTask.Id);
            dgvTaskTimes.Columns["TaskTimeId"].Visible = false;
        }

        private void SetComponent(Task task)
        {
            if (task == null)
            {
                CurrentTask = new Task();
                CurrentTask.SetOpen();

                SelectCboStatus(CurrentTask);
                lblNavigationTaskTime.Visible = false;
            }
            else
            {
                CurrentTask = task;
                SelectCboTaskType(CurrentTask.TaskTypeId);
                SelectCboStatus(CurrentTask);
                SetAccountId(CurrentTask.AccountId);
                SetManagerId(CurrentTask.ManagerId);
                SetFundId(CurrentTask.FundId);
                SelectCboOwner(CurrentTask.OwnerId);
                SetDueOn(CurrentTask.DueOn);
                SetDateComplete(CurrentTask.DateCompleted);
                txtDescription.Text = CurrentTask.Detail;

                StringMap stringMap = new StringMap(CurrentTask.TaskTypeId);
                lblFormHeader.Text = stringMap.Value;

                LoadDgvTaskTime();
            }
        }

        private void SelectCboStatus(Task task)
        {
            if (task.IsOpen())
            {
                cboStatus.Text = "Uncompleted";
            }
            else if (task.IsComplete())
            {
                cboStatus.Text = "Completed";
            }
            else
            {
                cboStatus.SelectedIndex = -1;
            }
        }

        private void SelectCboTaskType(Guid taskTypeId)
        {
            foreach (ListItem item in cboTaskType.Items)
            {
                Guid itemId = new Guid(item.HiddenValue);
                if (taskTypeId == itemId)
                {
                    cboTaskType.SelectedItem = item;
                    return;
                }
            }
        }

        private void SetAccountId(Guid? accountId)
        {
            if (accountId == null)
            {
                lblSelectedAccount.Text = "Select an account...";
                toolTip.SetToolTip(lblSelectedAccount, "Click to search for an account to assocaite to this task.");
                return;
            }

            Account account = new Account((Guid)accountId);
            lblSelectedAccount.Text = account.Name;
            toolTip.SetToolTip(lblSelectedAccount, "Click to open the selected account.");
        }

        private void SetManagerId(Guid? managerId)
        {
            if (managerId == null)
            {
                lblSelectedManager.Text = "Select a manager...";
                toolTip.SetToolTip(lblSelectedManager, "Click to search for a manager to assocaite to this task.");
                return;
            }

            Manager manager = new Manager((Guid)managerId);
            lblSelectedManager.Text = manager.FullName;
            toolTip.SetToolTip(lblSelectedManager, "Click to open the selected manager.");
        }

        public void SetFundId(Guid? fundId)
        {
            if (fundId == null)
            {
                lblSelectedFund.Text = "Select a fund...";
                toolTip.SetToolTip(lblSelectedFund, "Click to search for a fund to assocaite to this task.");
                return;
            }

            Fund fund = new Fund((Guid)fundId);
            lblSelectedFund.Text = fund.FundName;
            toolTip.SetToolTip(lblSelectedFund, "Click to open the selected fund.");
        }

        private void SelectCboOwner(Guid ownerId)
        {
            foreach (ListItem item in cboOwner.Items)
            {
                Guid itemId = new Guid(item.HiddenValue);
                if (ownerId == itemId)
                {
                    cboOwner.SelectedItem = item;
                    return;
                }
            }
        }

        private void SetDateComplete(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                txtDateCompleted.Text = null;
                return;
            }

            txtDateCompleted.Text = ((DateTime)dateTime).ToString("M/d/yyyy h:mm tt");
        }

        private void SetDueOn(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                txtDateDue.Text = null;
                return;
            }

            txtDateDue.Text = ((DateTime)dateTime).ToString("M/d/yyyy h:mm tt");
        }

        private void LoadCboTaskType()
        {
            cboTaskType.Items.Clear();
            foreach (DataRow dr in Task.GetTaskNames().Rows)
            {
                cboTaskType.Items.Add(new ListItem(dr["TaskName"].ToString(), dr["TaskTypeId"].ToString()));
            }
        }

        private void LoadCboOwner()
        {
            cboOwner.Items.Clear();
            foreach (User _user in User.ActiveUsers())
            {
                cboOwner.Items.Add(new ListItem(_user.FullName, _user.UserId.ToString()));
            }
        }

        private void PrepareMessageFilter()
        {
            Application.AddMessageFilter(this);
            controlsToMove.Add(this.lblFormHeader);
            controlsToMove.Add(this.label39);
            controlsToMove.Add(this.panel7);
            controlsToMove.Add(this.panel16);
        }

        static bool ValidateTime(string time, string format)
        {
            DateTime outTime;
            return DateTime.TryParseExact(time, format, null, DateTimeStyles.None, out outTime);
        }
		
		private void btnSave_Click(object sender, EventArgs e)
		{
            if (cboOwner.SelectedItem == null)
            {
                MessageBox.Show("Please enter an owner of this task.", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Guid ownerId = new Guid(((ListItem)cboOwner.SelectedItem).HiddenValue);
                CurrentTask.OwnerId = ownerId;
            }

            if (cboTaskType.SelectedItem == null)
            {
                MessageBox.Show("Please enter a task type.", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Guid taskTypeId = new Guid(((ListItem)cboTaskType.SelectedItem).HiddenValue);
                CurrentTask.TaskTypeId = taskTypeId;
            }

			if (CurrentTask.FundId == null && CurrentTask.ManagerId == null && CurrentTask.AccountId == null)
            {
                MessageBox.Show("A new task must be associated with at least one of the following: fund, account, or manager", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(txtDateDue.Text))
                {
                    CurrentTask.DueOn = null;
                }
                else
                {
                    try
                    {
                        CurrentTask.DueOn = DateTime.Parse(txtDateDue.Text);
                    }
                    catch
                    {
                        MessageBox.Show("The date due field is not in a recognizable datetime format (MM/dd/yyyy hh:mm tt)", "Error", MessageBoxButtons.OK);
                        return;
                    }
                }

                if (String.IsNullOrWhiteSpace(txtDateCompleted.Text))
                {
                    CurrentTask.DateCompleted = null;
                }
                else
                {
                    try
                    {
                        CurrentTask.DateCompleted = DateTime.Parse(txtDateCompleted.Text);
                    }
                    catch
                    {
                        MessageBox.Show("The date completed field is not in a recognizable datetime format (MM/dd/yyyy hh:mm tt)", "Error", MessageBoxButtons.OK);
                        return;
                    }
                }

                string TaskDetail = txtDescription.Text;
                
                try
                {
                    CurrentTask.Detail = TaskDetail;

                    CurrentTask.SaveRecordToDatabase(frmMain_Parent.CurrentUser.UserId);

                    MessageBox.Show("Success! The task has been saved!", "Success!", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    frmError _frmError = new frmError(frmMain_Parent, ex);
                }
				
				this.Close();
			}
		}
		
		void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
        private void label31_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void SelectFund()
        {
            Forms.frmSelectRecord.RecordType selectType = Forms.frmSelectRecord.RecordType.Fund;
            DataTable dataTable = Fund.GetByFundName();
            frmSelectRecord frmSelectFund = new frmSelectRecord(frmMain_Parent, selectType, CurrentTask, dataTable);
            frmSelectFund.RecordSelected += frmSelectFund_RecordSelected;
        }

        private void frmSelectFund_RecordSelected(object sender, EventArgs e)
        {
            Guid fundId = (Guid)sender;
            CurrentTask.FundId = fundId;

            Fund fund = new Fund(fundId);
            lblSelectedFund.Text = fund.FundName;
        }

        private void btnClearFund_Click(object sender, EventArgs e)
        {
            CurrentTask.FundId = null;
            SetFundId(null);
        }

        private void btnClearManager_Click(object sender, EventArgs e)
        {
            CurrentTask.ManagerId = null;
            SetManagerId(null);
        }

        private void SelectManager()
        {
            Forms.frmSelectRecord.RecordType selectType = Forms.frmSelectRecord.RecordType.Manager;
            DataTable dataTable = Manager.GetActive();
            frmSelectRecord frmSelectManager = new frmSelectRecord(frmMain_Parent, selectType, CurrentTask, dataTable);
            frmSelectManager.RecordSelected += frmSelectManager_RecordSelected;
        }

        private void frmSelectManager_RecordSelected(object sender, EventArgs e)
        {
            Guid managerId = (Guid)sender;
            CurrentTask.ManagerId = managerId;

            Manager manager = new Manager(managerId);
            lblSelectedManager.Text = manager.FullName;
        }

        private void SelectAccount()
        {
            Forms.frmSelectRecord.RecordType selectType = Forms.frmSelectRecord.RecordType.Account;
            DataTable dataTable = Account.GetActiveCustomers();
            frmSelectRecord frmSelectAccount = new frmSelectRecord(frmMain_Parent, selectType, CurrentTask, dataTable);
            frmSelectAccount.RecordSelected += frmSelectAccount_RecordSelected;
        }

        private void frmSelectAccount_RecordSelected(object sender, EventArgs e)
        {
            Guid accountId = (Guid)sender;
            CurrentTask.AccountId = accountId;

            Account account = new Account(accountId);
            lblSelectedAccount.Text = account.Name;
        }

        private void btnClearAccount_Click(object sender, EventArgs e)
        {
            CurrentTask.AccountId = null;
            SetAccountId(null);
        }

        private void lblNavigationMain_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages["tabMain"];
        }

        private void lblNavigationTaskTime_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages["tabTaskTime"];
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

        private void btnAddFund_Click(object sender, EventArgs e)
        {
            frmTaskTime frmTaskTime = new frmTaskTime(frmMain_Parent, CurrentTask.Id);
            frmTaskTime.FormClosed += frmTaskTime_FormClosed;
        }

        private void frmTaskTime_FormClosed(object sender, EventArgs e)
        {
            LoadDgvTaskTime();
        }

        private void btnRemoveFund_Click(object sender, EventArgs e)
        {
            if (dgvTaskTimes.CurrentRow == null)
            {
                return;
            }

            int index = dgvTaskTimes.CurrentRow.Index;
            Guid taskTimeId = new Guid(dgvTaskTimes.Rows[index].Cells["TaskTimeId"].Value.ToString());
            TaskTime taskTime = new TaskTime(taskTimeId);
            taskTime.DeleteRecordFromDatabase();
            LoadDgvTaskTime();
        }

        private void dgvTaskTimes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvTaskTimes.CurrentRow.Index;
            Guid taskTimeId = new Guid(dgvTaskTimes.Rows[index].Cells["TaskTimeId"].Value.ToString());
            frmTaskTime frmTaskTime = new frmTaskTime(frmMain_Parent, CurrentTask.Id, taskTimeId);
            frmTaskTime.FormClosed += frmTaskTime_FormClosed;
        }

        private void lblSelectedFund_Click(object sender, EventArgs e)
        {
            if (CurrentTask.FundId == null)
            {
                SelectFund();
            }
            else
            {
                Guid fundId = (Guid)CurrentTask.FundId;
                frmFund frmFund = new frmFund(frmMain_Parent, fundId);
            }
        }

        private void lblSelectedManager_Click(object sender, EventArgs e)
        {
            if (CurrentTask.ManagerId == null)
            {
                SelectManager();
            }
            else
            {
                Guid managerId = (Guid)CurrentTask.ManagerId;
                frmManager frmManager = new frmManager(frmMain_Parent, managerId);
            }
        }

        private void lblSelectedAccount_Click(object sender, EventArgs e)
        {
            if (CurrentTask.AccountId == null)
            {
                SelectAccount();
            }
            else
            {
                Guid accountId = (Guid)CurrentTask.AccountId;
                frmAccount frmAccount = new frmAccount(frmMain_Parent, accountId);
            }
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsFillingComponents)
            {
                return;
            }

            if (cboStatus.Text == "Uncompleted")
            {
                CurrentTask.SetOpen();
                SetDateComplete(CurrentTask.DateCompleted);
            }
            else if (cboStatus.Text == "Completed")
            {
                CurrentTask.SetComplete();
                SetDateComplete(CurrentTask.DateCompleted);
            }
        }
	}
}
