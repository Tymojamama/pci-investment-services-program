using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISP.Presentation.Forms
{
    public partial class frmTaskTime : Form, IMessageFilter
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

        public frmMain frmMain_Parent;

        private Business.Entities.Task task;
        private Business.Entities.TaskTime taskTime;

        Stopwatch stopWatch = new Stopwatch();

        /// <summary>
        /// Creates an instance of a Task Time form in order to edit the TaskTime.
        /// </summary>
        /// <param name="_frmMain"></param>
        /// <param name="_taskId"></param>
        /// <param name="_taskTimeId"></param>
        /// <param name="_formClosed"></param>
        public frmTaskTime(frmMain _frmMain, Guid _taskId, Guid _taskTimeId, FormClosedEventHandler _formClosed = null)
        {
            Presentation.Forms.frmSplashScreen ss = new Presentation.Forms.frmSplashScreen();
            ss.Show();
            Application.DoEvents();

            InitializeComponent();

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.pnlMainHeader);
            controlsToMove.Add(this.panel12);
            controlsToMove.Add(this.panel13);
            controlsToMove.Add(this.label48);
            controlsToMove.Add(this.label39);

            frmMain_Parent = _frmMain;
            FormClosed += _formClosed;

            task = new Business.Entities.Task(_taskId);
            taskTime = new Business.Entities.TaskTime(frmMain_Parent.CurrentUser.UserId, _taskTimeId);
            txtTaskName.Text = task.TaskTypeIdName;
            txtDescription.Text = taskTime.Description;
            txtNotes.Text = taskTime.Notes;

            if (taskTime.StartDate == null)
                txtStartDate.Text = null;
            else
                txtStartDate.Text = ((DateTime)taskTime.StartDate).ToString("MM/dd/yyyy HH:mm tt");

            if (taskTime.EndDate == null)
                txtEndDate.Text = null;
            else
                txtEndDate.Text = ((DateTime)taskTime.EndDate).ToString("MM/dd/yyyy HH:mm tt");

            if (taskTime.DurationMinutes == null)
            {
                txtDuration.Text = null;
            }
            else
            {
                TimeSpan timeSpan = TimeSpan.FromMinutes((double)taskTime.DurationMinutes);
                txtDuration.Text = Convert.ToString(String.Format("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds));
            }

            this.Show();
            ss.Close();
        }

        /// <summary>
        /// Creates an instance of a Task Time form in order to insert new entries against the selected Task.
        /// </summary>
        /// <param name="_frmMain"></param>
        /// <param name="_taskId"></param>
        /// <param name="_formClosed"></param>
        public frmTaskTime(frmMain _frmMain, Guid _taskId, FormClosedEventHandler _formClosed = null)
        {
            InitializeComponent();

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.pnlMainHeader);
            controlsToMove.Add(this.panel12);
            controlsToMove.Add(this.panel13);
            controlsToMove.Add(this.label48);
            controlsToMove.Add(this.label39);

            frmMain_Parent = _frmMain;
            FormClosed += _formClosed;

            task = new Business.Entities.Task(_taskId);
            txtTaskName.Text = task.TaskTypeIdName;

            taskTime = new Business.Entities.TaskTime(frmMain_Parent.CurrentUser.UserId);
            taskTime.TaskId = _taskId;
            taskTime.DurationMinutes = 0;

            this.Show();
        }

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnTimeStart.Text == "Stop")
            {
                btnTimeStart.PerformClick();
            }

            if (String.IsNullOrWhiteSpace(txtStartDate.Text))
            {
                MessageBox.Show("Start date field cannot be blank. Please correct and try again.","Error!", MessageBoxButtons.OK);
                return;
            }
            else if (String.IsNullOrWhiteSpace(txtEndDate.Text))
            {
                MessageBox.Show("End date field cannot be blank. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                return;
            }

            taskTime.Description = txtDescription.Text;
            taskTime.StartDate = DateTime.Parse(txtStartDate.Text);
            taskTime.EndDate = DateTime.Parse(txtEndDate.Text);
            TimeSpan duration = TimeSpan.Parse(txtDuration.Text);
            taskTime.DurationMinutes = (decimal)duration.TotalMinutes;
            taskTime.Notes = txtNotes.Text;

            try
            {
                taskTime.SaveToDatabase();
                this.Close();
            }
            catch (Exception ex)
            {
                frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
            }
        }

        private void CloseFormButton_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.Color.Black;
            label.BackColor = System.Drawing.Color.DarkGray;
        }

        private void CloseFormButton_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.Color.White;
            label.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
        }

        private void lblMinForm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimeStart_Click(object sender, EventArgs e)
        {
            //Setup local variable
            TimeSpan ts = stopWatch.Elapsed + TimeSpan.FromMinutes((double)taskTime.DurationMinutes);

            if (btnTimeStart.Text == "Start")
            {
                txtDescription.Select();

                stopWatch.Start();
                btnTimeStart.Text = "Stop";

                //Set Start Time Value and clear End Time Value
                if (String.IsNullOrWhiteSpace(txtStartDate.Text))
                    txtStartDate.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm tt");

                txtEndDate.Text = null;

                //Update duration field with stop watch time
                while (ts.Hours < 10 && stopWatch.IsRunning == true)
                {
                    ts = stopWatch.Elapsed + TimeSpan.FromMinutes((double)taskTime.DurationMinutes);

                    txtDuration.Text = Convert.ToString(String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds));
                    Application.DoEvents();
                }
            }
            else if (btnTimeStart.Text == "Stop")
            {
                stopWatch.Stop();
                btnTimeStart.Text = "Start";

                //Set End Time text value
                txtEndDate.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm tt");

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
                txtDuration.Text = elapsedTime;
            }
        }

        private void btnTimeReset_Click(object sender, EventArgs e)
        {
            stopWatch.Reset();
            btnTimeStart.Text = "Start";
            taskTime.DurationMinutes = null;
            txtDuration.Text = null;
            txtStartDate.Text = null;
            txtEndDate.Text = null;
        }
    }
}
