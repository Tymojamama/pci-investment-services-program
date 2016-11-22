using DataIntegrationHub.Business.Entities;

using ISP.Business.Entities;
using ISP.Presentation;
using ISP.Presentation.Utilities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISP.Presentation.Forms
{
    public partial class frmNewFund : Form, IMessageFilter
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
        private bool UnsavedChanges = false;

        public frmNewFund(frmMain mainForm)
        {
            InitializeComponent();

            #region IMessageFilter Methods

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.pnlFormHeader);
            controlsToMove.Add(this.lblFormHeader);
            controlsToMove.Add(this.lblHeader);
            controlsToMove.Add(this.pnlBackground);

            #endregion

            frmMain_Parent = mainForm;

            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            LoadCategoryCbo();

            this.Show();
        }

        private void LoadCategoryCbo()
        {
            cboCategory.Items.Clear();

            foreach (StringMap _stringMap in StringMap.AssociatedFromColumnAndTable("Funds", "CategoryId"))
            {
                cboCategory.Items.Add(new ListItem(_stringMap.Value, _stringMap.StringMapId.ToString()));
                cboCategory.Sorted = true;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (UnsavedChanges)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Are you sure you wish to close this form?", "Attention", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void lblCloseForm_Click(object sender, EventArgs e)
        {
            if (UnsavedChanges)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Are you sure you wish to close this form?", "Attention", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void lblMinForm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnlFields_Click(object sender, EventArgs e)
        {
            pnlFields.Focus();
        }

        private void MaximizeForm()
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

        private void pnlFormHeader_DoubleClick(object sender, EventArgs e)
        {
            MaximizeForm();
        }

        private void lblHeader_DoubleClick(object sender, EventArgs e)
        {
            MaximizeForm();
        }

        private void pnlBackground_DoubleClick(object sender, EventArgs e)
        {
            MaximizeForm();
        }

        private void lblFormHeader_DoubleClick(object sender, EventArgs e)
        {
            MaximizeForm();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            UnsavedChanges = true;
        }

        private void cboAdvisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnsavedChanges = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("You must enter a fund name. Please correct and try again.", "Error", MessageBoxButtons.OK);
                return;
            }
            else if (String.IsNullOrWhiteSpace(txtTicker.Text))
            {
                MessageBox.Show("You must enter a ticker. Please correct and try again.", "Error", MessageBoxButtons.OK);
                return;
            }

            Guid? _categoryId;

            int _recordType = 0;

            if (cboCategory.SelectedIndex == -1)
                _categoryId = null;
            else
                _categoryId = new Guid(((ListItem)cboCategory.SelectedItem).HiddenValue);

            if (cboRecordType.Text == "Fund")
                _recordType = 1;
            else if (cboRecordType.Text == "Index")
                _recordType = 2;
            else if (cboRecordType.Text == "Category")
                _recordType = 3;

            Fund _fund = new Fund();
            _fund.FundName = txtName.Text;
            _fund.Ticker = txtTicker.Text;
            _fund.Family = txtFamily.Text;
            _fund.Cusip = txtCusip.Text;
            _fund.CategoryId = _categoryId;
            _fund.RecordType = _recordType;

            try
            {
                _fund.SaveToDatabase(frmMain_Parent.CurrentUser.UserId);
                this.Close();
            }
            catch(Exception _exception)
            {
                frmError _frmError = new frmError(frmMain_Parent, _exception);
            }
        }
    }
}
