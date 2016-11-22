using ISP;
using ISP.Business;
using ISP.Business.Entities;
using ISP.Presentation;
using ISP.Presentation.Utilities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ISP.Presentation.Forms
{
    public partial class frmError : Form, IMessageFilter
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

        public IspException CurrentIspException { get; private set; }

        public frmError(Guid _userId, Exception _exception)
        {
            InitializeComponent();

            #region IMessageFilter Methods

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.panel1);

            #endregion

            CurrentIspException = new IspException(_userId, _exception);
            txtExceptionMessage.Text = CurrentIspException.Exception.Message;

            this.Show();
        }

        public frmError(frmMain _frmMain, Exception _exception)
        {
            InitializeComponent();

            #region IMessageFilter Methods

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.panel1);

            #endregion

            CurrentIspException = new IspException(_frmMain.CurrentUser.UserId, _exception);
            txtExceptionMessage.Text = CurrentIspException.Exception.Message;

            this.Show();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReportError_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentIspException.UserNotes = txtErrorDescription.Text;
                CurrentIspException.SaveToDatabase();

                MessageBox.Show("Success! The error was sent to the IT department. It will be dealt with promptly. "
                    + "Thank you for helping us improve our applications here at PCI!", "Success!", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                ReportViaEmail(ex.Message, "ReportErrorForm.button2_Click");
            }

            this.Close();
        }

        public static void ReportViaEmail(string Message, string Method)
        {
            string error = "Well, this is embarrassing! There was another error that occurred while trying to report the error... "
                + "Instead, would you like for an email to be automatically generated so that you may send it to the IT depatment?";
            DialogResult errorResult = MessageBox.Show(error, "Error!", MessageBoxButtons.YesNo);

            if (errorResult == DialogResult.Yes)
            {
                string enter = "%0D%0A";
                string email =
                    "mailto:zallen@pension-consultants.com?subject=An ISP Error Occurred&body=Hey, Zach!"
                    + enter + enter + "An error occurred within the Investment Services Program for user "
                    + Environment.UserName + ":" + enter + Message;

                if (String.IsNullOrEmpty(Method) == false)
                {
                    email = email + enter + enter
                        + "This error occured during processing of " + Method + ". "
                        + "Furthermore, a second error occured while trying to report this error in the ReportError Form.";
                }

                email = email + enter + enter + "Thanks for looking into these items!";

                string emailTag = string.Format(email);
                System.Diagnostics.Process.Start(emailTag);
            }
        }
    }
}
