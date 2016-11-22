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
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace ISP.Presentation.Forms
{
    public partial class frmTask : Form, IMessageFilter
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

        frmMain frmMain_Parent;

        public frmTask(frmMain _frmMain)
        {
            frmSplashScreen _frmSplashScreen = new frmSplashScreen();
            _frmSplashScreen.Show();
            Application.DoEvents();

            InitializeComponent();

            #region IMessageFilter Methods

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.label26);
            controlsToMove.Add(this.label39);
            controlsToMove.Add(this.panel7);
            controlsToMove.Add(this.panel16);
            controlsToMove.Add(this.pictureBox1);

            #endregion

            frmMain_Parent = _frmMain;

            comboBoxRegarding.Items.Clear();

            foreach (DataRow dr in Account.GetActiveCustomers().Rows)
            {
                comboBox3.Items.Add(new ListItem(dr["Account"].ToString(), dr["AccountId"].ToString()));
            }

            foreach (DataRow dr in Fund.GetAllTickers().Rows)
            {
                comboBoxRegarding.Items.Add(new ListItem(dr["Ticker"].ToString() + " - " + dr["FundName"].ToString(), dr["FundId"].ToString()));
            }

            foreach (DataRow dr in Manager.GetActive().Rows)
            {
                comboBox2.Items.Add(new ListItem(dr["Full Name"].ToString() + ", " + dr["Credentials"].ToString(), dr["ManagerId"].ToString()));
            }

            foreach (DataRow dr in Task.GetTaskNames().Rows)
            {
                comboBox1.Items.Add(new ListItem(dr["TaskName"].ToString(), dr["TaskTypeId"].ToString()));
            }

            foreach (User _user in User.ActiveUsers())
            {
                comboBoxOwner.Items.Add(new ListItem(_user.FullName, _user.UserId.ToString()));
            }

            comboBox1.Select();

            this.Show();
            _frmSplashScreen.Close();
		}

        public string FundId;
        string ManagerId;
        public string AccountId;
        string UserId;
        string TaskTypeId;
		
        static bool ValidateTime(string time, string format)
        {
            DateTime outTime;
            return DateTime.TryParseExact(time, format, null, DateTimeStyles.None, out outTime);
        }
		
		void btnSave_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(comboBox1.Text))
            {
				MessageBox.Show("Please enter a task", "Task Save Error", MessageBoxButtons.OK);
			}
            else if (String.IsNullOrEmpty(UserId))
            {
				MessageBox.Show("Please enter an owner of this task", "Task Save Error", MessageBoxButtons.OK);
			}
            else if (textBox1.Text.Length > 2 || textBox2.Text.Length > 2 || textBox3.Text.Length > 4)
            {
				MessageBox.Show("Please enter a valid date", "Task Save Error", MessageBoxButtons.OK);
			}
            else if (textBox4.Text.Length > 2 || textBox5.Text.Length > 2)
            {
				MessageBox.Show("Please enter a valid time", "Task Save Error", MessageBoxButtons.OK);
			}
            else if (String.IsNullOrEmpty(textBox7.Text) && String.IsNullOrEmpty(textBox8.Text) && String.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("A new task must be associated with at least one of the following: fund, account, or manager", "Task Save Error", MessageBoxButtons.OK);
            }
            else
            {
				string task = comboBox1.SelectedIndex.ToString();

                string mo = textBox1.Text;
                string day = textBox2.Text;
                string yr = textBox3.Text;
                string hr = textBox4.Text;
                string mi = textBox5.Text;
                string am = domainUpDown.Text;
                string dueOn = mo + "/" + day +"/" + yr + " " + hr + ":" + mi + " " + am;
                DateTime? DueOn;
                bool isValidDate = false;

                if (mo == "mm" || day == "dd" || yr == "yyyy" || hr == "hh" || mi == "mm")
                {
                    DueOn = null;
                }
                else
                {
                    try
                    {
                        DueOn = DateTime.Parse(dueOn);
                        isValidDate = ValidateTime(dueOn, "MM/dd/yyyy hh:mm tt");
                    }
                    catch
                    {
                        MessageBox.Show("The Due On field is not in the correct format (MM/dd/yyyy hh:mm tt)", "Error", MessageBoxButtons.OK);
                        return;
                    }
                }

                Guid taskTypeId = new Guid(TaskTypeId);

                Guid? fundId;
                if (String.IsNullOrEmpty(FundId))
                {
                    fundId = null;
                }
                else
                {
                    fundId = new Guid(FundId);
                }

                Guid? accountId;
                if (String.IsNullOrEmpty(AccountId))
                {
                    accountId = null;
                }
                else
                {
                    accountId = new Guid(AccountId);
                }

                Guid? managerId;
                if (String.IsNullOrEmpty(ManagerId))
                {
                    managerId = null;
                }
                else
                {
                    managerId = new Guid(ManagerId);
                }

                Guid userId = new Guid(UserId);
                string TaskDetail = textBox6.Text;
                
                try
                {
                    ISP.Business.Entities.Task.Insert(taskTypeId, fundId, accountId, managerId, userId, TaskDetail, DueOn, frmMain_Parent.CurrentUser.UserId);
                    MessageBox.Show("Success! The new task has been created!", "Success!", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
                }
				
				this.Close();
			}
		}
		
		void comboBoxRegardingSelectedIndexChange(object sender, EventArgs e)
        {
            textBox7.Text = comboBoxRegarding.Text;
            FundId = ((Utilities.ListItem)comboBoxRegarding.SelectedItem).HiddenValue.ToString();
        }

        void comboBoxOwnerSelectedIndexChange(object sender, EventArgs e)
		{
            UserId = ((Utilities.ListItem)comboBoxOwner.SelectedItem).HiddenValue.ToString();
		}
		
		void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void TextBox1Enter(object sender, EventArgs e)
		{
			if (textBox1.Text == "mm")
            {
				textBox1.Text = "";
				textBox1.ForeColor = System.Drawing.SystemColors.ControlText;
			}
		}
		
		void TextBox1Leave(object sender, EventArgs e)
		{
			int n;
			bool isNumeric = int.TryParse(textBox1.Text, out n);
			
			if (textBox1.Text.Length == 2 && isNumeric == true) {
			
			} else if (textBox1.Text == "" || isNumeric == false) {
				textBox1.Text = "mm";
				textBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			} else if (textBox1.Text.Length == 1) {
				textBox1.Text = "0" + textBox1.Text;
			}
		}
		
		void TextBox2Enter(object sender, EventArgs e)
		{
			if (textBox2.Text == "dd") {
				textBox2.Text = "";
				textBox2.ForeColor = System.Drawing.SystemColors.ControlText;
			}
		}
		
		void TextBox2Leave(object sender, EventArgs e)
		{
			int n;
			bool isNumeric = int.TryParse(textBox2.Text, out n);
			
			if (textBox2.Text.Length == 2 && isNumeric == true) {
			
			} else if (textBox2.Text == "" || isNumeric == false) {
				textBox2.Text = "dd";
				textBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			} else if (textBox2.Text.Length == 1) {
				textBox2.Text = "0" + textBox2.Text;
			}
		}
		
		void TextBox3Enter(object sender, EventArgs e)
		{
			if (textBox3.Text == "yyyy")
            {
				textBox3.Text = "";
				textBox3.ForeColor = System.Drawing.SystemColors.ControlText;
			}
		
		}
		
		void TextBox3Leave(object sender, EventArgs e)
		{
			int n;
			bool isNumeric = int.TryParse(textBox3.Text, out n);
			
			if (textBox3.Text.Length == 4 && isNumeric == true) {
			
			} else if (textBox3.Text.Length == 2 && isNumeric == true) {
				textBox3.Text = "20" + textBox3.Text;
				textBox3.ForeColor = System.Drawing.SystemColors.ControlText;
			} else if (textBox3.Text == "") {
				textBox3.Text = "yyyy";
				textBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			}
		}
		
		void TextBox4Enter(object sender, EventArgs e)
		{
			if (textBox4.Text == "hh")
            {
				textBox4.Text = "";
				textBox4.ForeColor = System.Drawing.SystemColors.ControlText;
			}
		}
		
		void TextBox4Leave(object sender, EventArgs e)
		{
			int n;
			bool isNumeric = int.TryParse(textBox4.Text, out n);
			
			if (textBox4.Text.Length == 2 && isNumeric == true) {
			
			} else if (textBox4.Text == "" || isNumeric == false) {
				textBox4.Text = "hh";
				textBox4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			} else if (textBox4.Text.Length == 1) {
				textBox4.Text = "0" + textBox4.Text;
			}
		}
		
		void TextBox5Enter(object sender, EventArgs e)
		{
			if (textBox5.Text == "mm")
            {
				textBox5.Text = "";
				textBox5.ForeColor = System.Drawing.SystemColors.ControlText;
			}
		}
		
		void TextBox5Leave(object sender, EventArgs e)
		{
			int n;
			bool isNumeric = int.TryParse(textBox5.Text, out n);
			
			if (textBox5.Text.Length == 2 && isNumeric == true) {
			
			} else if (textBox5.Text == "" || isNumeric == false) {
				textBox5.Text = "mm";
				textBox5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			} else if (textBox5.Text.Length == 1) {
				textBox5.Text = textBox5.Text + "0";
			}
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox1.Text != "") {
                TaskTypeId = ((Utilities.ListItem)comboBox1.SelectedItem).HiddenValue.ToString();
			}
		}

        private void label31_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox8.Text = comboBox2.Text;
            ManagerId = ((Utilities.ListItem)comboBox2.SelectedItem).HiddenValue.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox9.Text = comboBox3.Text;
            AccountId = ((Utilities.ListItem)comboBox3.SelectedItem).HiddenValue.ToString();
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
	}
}
