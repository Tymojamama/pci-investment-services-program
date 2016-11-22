using ISP.Business.Entities;
using ISP.Presentation.Utilities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISP.Presentation.Forms
{
    public partial class frmMergeFunds : Form, IMessageFilter
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

        private Presentation.Forms.frmMain frmMain_Parent;
        private Fund fund1;
        private Fund fund2;

        public frmMergeFunds(Presentation.Forms.frmMain mf, Fund fundRecord1, Fund fundRecord2)
        {
            InitializeComponent();

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.pnlHeader);
            controlsToMove.Add(this.lblHeader);
            controlsToMove.Add(this.pnlFormHeader);
            controlsToMove.Add(this.lblFormHeader);

            frmMain_Parent = mf;
            fund1 = fundRecord1;
            fund2 = fundRecord2;

            cboMasterRecord.Items.Add(new ListItem(fund1.Ticker + " - " + fund1.FundName, fund1));
            cboMasterRecord.Items.Add(new ListItem(fund2.Ticker + " - " + fund2.FundName, fund2));

            txtFund1Name.Text = fund1.FundName;
            txtFund1Ticker.Text = fund1.Ticker;
            txtFund1Category.Text = fund1.Category;
            txtFund1Family.Text = fund1.Family;
            txtFund1Advisor.Text = fund1.Advisor;
            txtFund1Cusip.Text = fund1.Cusip;

            if (!String.IsNullOrWhiteSpace(fund1.InceptionDate.ToString()))
                txtFund1InceptDate.Text = ((DateTime)fund1.InceptionDate).ToString("MMMM dd, yyyy");

            txtFund2Name.Text = fund2.FundName;
            txtFund2Ticker.Text = fund2.Ticker;
            txtFund2Category.Text = fund2.Category;
            txtFund2Family.Text = fund2.Family;
            txtFund2Advisor.Text = fund2.Advisor;
            txtFund2Cusip.Text = fund2.Cusip;

            if (!String.IsNullOrWhiteSpace(fund2.InceptionDate.ToString()))
                txtFund2InceptDate.Text = ((DateTime)fund2.InceptionDate).ToString("MMMM dd, yyyy");

            Business.Entities.Fund.DataMaintenance fund1DataMantenance = new Business.Entities.Fund.DataMaintenance(fund1.FundId);
            txtFund1DataStartDate.Text = fund1DataMantenance.DataStartDate;
            txtFund1DataEndDate.Text = fund1DataMantenance.DataEndDate;
            txtFund1MonthCount.Text = fund1DataMantenance.MonthCount.ToString("N0");

            Business.Entities.Fund.DataMaintenance fund2DataMantenance = new Business.Entities.Fund.DataMaintenance(fund2.FundId);
            txtFund2DataStartDate.Text = fund2DataMantenance.DataStartDate;
            txtFund2DataEndDate.Text = fund2DataMantenance.DataEndDate;
            txtFund2MonthCount.Text = fund2DataMantenance.MonthCount.ToString("N0");

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void lblFormClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblFormMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboMasterRecord.SelectedIndex == -1)
            {
                MessageBox.Show("Error: You must select a master record. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                return;
            }

            if (cboMonthlyData.SelectedIndex == -1)
            {
                MessageBox.Show("Error: You must select an option for monthly data. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                return;
            }

            Guid masterFundId = ((Fund)((ListItem)cboMasterRecord.SelectedItem).HiddenObject).FundId;
            Guid minorFundId;

            if (masterFundId == fund1.FundId)
                minorFundId = fund2.FundId;
            else
                minorFundId = fund1.FundId;

            try
            {
                frmSplashScreen ss = new frmSplashScreen();
                ss.Show();

                Application.DoEvents();

                if (cboMonthlyData.SelectedIndex == 0)
                {
                    Business.Entities.Fund.Disable(minorFundId, frmMain_Parent.CurrentUser.UserId);
                }
                else if (cboMonthlyData.SelectedIndex == 1)
                {
                    Business.Entities.Fund.MergeRecordsWithOverwrite(masterFundId, minorFundId, frmMain_Parent.CurrentUser.UserId);
                }
                else if (cboMonthlyData.SelectedIndex == 2)
                {
                    Business.Entities.Fund.MergeRecordsWithCopy(masterFundId, minorFundId, frmMain_Parent.CurrentUser.UserId);
                }

                ss.Close();

                MessageBox.Show("Records successfully merged!", "Success!", MessageBoxButtons.OK);

                frmMain_Parent.LoadDuplicateRecordsDgv();

                this.Close();
            }
            catch (Exception ex)
            {
                frmError _frmError = new frmError(frmMain_Parent, ex);
            }
        }

        private void cboMasterRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMasterRecord.SelectedIndex == -1)
            {
                txtFund1Name.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund1Ticker.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund1Category.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund1Family.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund1Advisor.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund1Cusip.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund1InceptDate.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund1DataStartDate.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund1DataEndDate.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund1MonthCount.BackColor = System.Drawing.Color.WhiteSmoke;

                txtFund1Name.ForeColor = System.Drawing.Color.Black;
                txtFund1Ticker.ForeColor = System.Drawing.Color.Black;
                txtFund1Category.ForeColor = System.Drawing.Color.Black;
                txtFund1Family.ForeColor = System.Drawing.Color.Black;
                txtFund1Advisor.ForeColor = System.Drawing.Color.Black;
                txtFund1Cusip.ForeColor = System.Drawing.Color.Black;
                txtFund1InceptDate.ForeColor = System.Drawing.Color.Black;
                txtFund1DataStartDate.ForeColor = System.Drawing.Color.Black;
                txtFund1DataEndDate.ForeColor = System.Drawing.Color.Black;
                txtFund1MonthCount.ForeColor = System.Drawing.Color.Black;

                txtFund2Name.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund2Ticker.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund2Category.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund2Family.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund2Advisor.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund2Cusip.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund2InceptDate.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund2DataStartDate.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund2DataEndDate.BackColor = System.Drawing.Color.WhiteSmoke;
                txtFund2MonthCount.BackColor = System.Drawing.Color.WhiteSmoke;

                txtFund2Name.ForeColor = System.Drawing.Color.Black;
                txtFund2Ticker.ForeColor = System.Drawing.Color.Black;
                txtFund2Category.ForeColor = System.Drawing.Color.Black;
                txtFund2Family.ForeColor = System.Drawing.Color.Black;
                txtFund2Advisor.ForeColor = System.Drawing.Color.Black;
                txtFund2Cusip.ForeColor = System.Drawing.Color.Black;
                txtFund2InceptDate.ForeColor = System.Drawing.Color.Black;
                txtFund2DataStartDate.ForeColor = System.Drawing.Color.Black;
                txtFund2DataEndDate.ForeColor = System.Drawing.Color.Black;
                txtFund2MonthCount.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                Fund selectedFund = ((Fund)((ListItem)cboMasterRecord.SelectedItem).HiddenObject);

                if (selectedFund.Ticker == txtFund1Ticker.Text && selectedFund.FundName == txtFund1Name.Text)
                {
                    txtFund1Name.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund1Ticker.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund1Category.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund1Family.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund1Advisor.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund1Cusip.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund1InceptDate.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund1DataStartDate.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund1DataEndDate.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund1MonthCount.BackColor = System.Drawing.Color.SteelBlue;

                    txtFund1Name.ForeColor = System.Drawing.Color.White;
                    txtFund1Ticker.ForeColor = System.Drawing.Color.White;
                    txtFund1Category.ForeColor = System.Drawing.Color.White;
                    txtFund1Family.ForeColor = System.Drawing.Color.White;
                    txtFund1Advisor.ForeColor = System.Drawing.Color.White;
                    txtFund1Cusip.ForeColor = System.Drawing.Color.White;
                    txtFund1InceptDate.ForeColor = System.Drawing.Color.White;
                    txtFund1DataStartDate.ForeColor = System.Drawing.Color.White;
                    txtFund1DataEndDate.ForeColor = System.Drawing.Color.White;
                    txtFund1MonthCount.ForeColor = System.Drawing.Color.White;

                    txtFund2Name.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund2Ticker.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund2Category.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund2Family.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund2Advisor.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund2Cusip.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund2InceptDate.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund2DataStartDate.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund2DataEndDate.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund2MonthCount.BackColor = System.Drawing.Color.WhiteSmoke;

                    txtFund2Name.ForeColor = System.Drawing.Color.Black;
                    txtFund2Ticker.ForeColor = System.Drawing.Color.Black;
                    txtFund2Category.ForeColor = System.Drawing.Color.Black;
                    txtFund2Family.ForeColor = System.Drawing.Color.Black;
                    txtFund2Advisor.ForeColor = System.Drawing.Color.Black;
                    txtFund2Cusip.ForeColor = System.Drawing.Color.Black;
                    txtFund2InceptDate.ForeColor = System.Drawing.Color.Black;
                    txtFund2DataStartDate.ForeColor = System.Drawing.Color.Black;
                    txtFund2DataEndDate.ForeColor = System.Drawing.Color.Black;
                    txtFund2MonthCount.ForeColor = System.Drawing.Color.Black;
                }
                else if (selectedFund.Ticker == txtFund2Ticker.Text && selectedFund.FundName == txtFund2Name.Text)
                {
                    txtFund1Name.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund1Ticker.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund1Category.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund1Family.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund1Advisor.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund1Cusip.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund1InceptDate.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund1DataStartDate.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund1DataEndDate.BackColor = System.Drawing.Color.WhiteSmoke;
                    txtFund1MonthCount.BackColor = System.Drawing.Color.WhiteSmoke;

                    txtFund1Name.ForeColor = System.Drawing.Color.Black;
                    txtFund1Ticker.ForeColor = System.Drawing.Color.Black;
                    txtFund1Category.ForeColor = System.Drawing.Color.Black;
                    txtFund1Family.ForeColor = System.Drawing.Color.Black;
                    txtFund1Advisor.ForeColor = System.Drawing.Color.Black;
                    txtFund1Cusip.ForeColor = System.Drawing.Color.Black;
                    txtFund1InceptDate.ForeColor = System.Drawing.Color.Black;
                    txtFund1DataStartDate.ForeColor = System.Drawing.Color.Black;
                    txtFund1DataEndDate.ForeColor = System.Drawing.Color.Black;
                    txtFund1MonthCount.ForeColor = System.Drawing.Color.Black;

                    txtFund2Name.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund2Ticker.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund2Category.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund2Family.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund2Advisor.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund2Cusip.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund2InceptDate.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund2DataStartDate.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund2DataEndDate.BackColor = System.Drawing.Color.SteelBlue;
                    txtFund2MonthCount.BackColor = System.Drawing.Color.SteelBlue;

                    txtFund2Name.ForeColor = System.Drawing.Color.White;
                    txtFund2Ticker.ForeColor = System.Drawing.Color.White;
                    txtFund2Category.ForeColor = System.Drawing.Color.White;
                    txtFund2Family.ForeColor = System.Drawing.Color.White;
                    txtFund2Advisor.ForeColor = System.Drawing.Color.White;
                    txtFund2Cusip.ForeColor = System.Drawing.Color.White;
                    txtFund2InceptDate.ForeColor = System.Drawing.Color.White;
                    txtFund2DataStartDate.ForeColor = System.Drawing.Color.White;
                    txtFund2DataEndDate.ForeColor = System.Drawing.Color.White;
                    txtFund2MonthCount.ForeColor = System.Drawing.Color.White;
                }
            }
        }
    }
}
