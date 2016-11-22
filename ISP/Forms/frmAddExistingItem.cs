using ISP;
using ISP.Business.Entities;
using ISP.Presentation;
using ISP.Presentation.Utilities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISP.Presentation.Forms
{
    public partial class frmAddExistingItem : Form, IMessageFilter
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

        public frmAddExistingItem(frmMain mf, string _FormType, Guid RegardingId1, string RegardingId2, FormClosedEventHandler Close)
        {
            Presentation.Forms.frmSplashScreen ss = new Presentation.Forms.frmSplashScreen();
            ss.Show();
            Application.DoEvents();

            InitializeComponent();
            frmMain_Parent = mf;

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.label1);
            controlsToMove.Add(this.label23);
            controlsToMove.Add(this.panel2);
            controlsToMove.Add(this.panel16);
            controlsToMove.Add(this.pictureBox1);

            this.FormClosed += Close;

            FormType = _FormType;
            
            if (FormType == "Custodian")
            {
                FormType = "Custodian";

                label23.Text = "Add a custodian";
                labelRegarding1.Text = "Plan";
                label31.Text = "Select a custodian";

                try
                {
                    Business.Entities.Plan plan = new Business.Entities.Plan(RegardingId1);
                    PlanId = plan.PlanId;
                    textBox7.Text = plan.PlanName;
                }
                catch (Exception ex)
                {
                    frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
                }
            }
            else if (FormType == "Plan")
            {
                FormType = "Plan";

                label23.Text = "Add a plan";
                labelRegarding1.Text = "Fund";
                label31.Text = "Select a plan";

                try
                {
                    Fund details = new Fund(RegardingId1, null);
                    FundId = details.FundId;
                    textBox7.Text = details.FundName;
                }
                catch (Exception ex)
                {
                    frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
                }
            }
            else if (FormType == "Fund")
            {
                FormType = "Fund";

                label23.Text = "Add a fund";
                labelRegarding1.Text = "Plan";
                label31.Text = "Select a fund";

                try
                {
                    Business.Entities.Plan plan = new Business.Entities.Plan(RegardingId1);
                    PlanId = plan.PlanId;
                    textBox7.Text = plan.PlanName;
                }
                catch (Exception ex)
                {
                    frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
                }
            }

            ss.Close();
            this.Show();
            txtSearch.Select();
        }

        public string FormType;

        public Guid PlanId;
        public Guid FundId;
        public Guid CustodianId;

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

        private void CloseFormButton_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.Color.Black;
            label.BackColor = System.Drawing.Color.Orchid;
        }

        private void CloseFormButton_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.Color.White;
            label.BackColor = System.Drawing.Color.DarkMagenta;
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvResults.CurrentRow.Index;

            if (FormType == "Custodian")
            {
                CustodianId = new Guid(dgvResults.Rows[index].Cells[0].Value.ToString());
            }
            else if (FormType == "Plan")
            {
                PlanId = new Guid(dgvResults.Rows[index].Cells[0].Value.ToString());
            }
            else if (FormType == "Fund")
            {
                FundId = new Guid(dgvResults.Rows[index].Cells[0].Value.ToString());
            }

            label31.Text = dgvResults.Rows[index].Cells[1].Value.ToString();
        }

        private void Submit(object sender, EventArgs e)
        {
            if (dgvResults.DataSource == null || dgvResults.Rows.Count == 0)
            {
                MessageBox.Show("Nothing is currently selected", "Error", MessageBoxButtons.OK);
                return;
            }

            if (FormType == "Custodian")
            {
                if (String.IsNullOrEmpty(CustodianId.ToString()) == false && String.IsNullOrEmpty(PlanId.ToString()) == false)
                {
                    try
                    {
                        ISP.Business.Entities.Relational_Custodians_Plans.Insert(CustodianId, PlanId);

                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
                    }
                }
            }
            else if (FormType == "Plan")
            {
                if (String.IsNullOrEmpty(FundId.ToString()) == false && String.IsNullOrEmpty(PlanId.ToString()) == false)
                {
                    try
                    {
                        ISP.Business.Entities.Relational_Funds_Plans.Insert(FundId, PlanId, frmMain_Parent.CurrentUser.UserId);

                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
                    }
                }
            }
            else if (FormType == "Fund")
            {
                if (String.IsNullOrEmpty(FundId.ToString()) == false && String.IsNullOrEmpty(PlanId.ToString()) == false)
                {
                    try
                    {
                        ISP.Business.Entities.Relational_Funds_Plans.Insert(FundId, PlanId, frmMain_Parent.CurrentUser.UserId);

                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
                    }
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonSave.PerformClick();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;

                if (FormType == "Custodian")
                {
                    DataTable dt = Business.Entities.Relational_Custodians_Plans.SearchByCustodians(txtSearch.Text);
                    Pagination p = new Pagination(dgvResults, dt);
                }
                else if (FormType == "Plan")
                {
                    DataTable dt = Business.Entities.Relational_Funds_Plans.SearchByPlan(txtSearch.Text);
                    Pagination p = new Pagination(dgvResults, dt);
                }
                else if (FormType == "Fund")
                {
                    DataTable dt = Business.Entities.Fund.SearchByFundNameAndTicker(txtSearch.Text);
                    Pagination p = new Pagination(dgvResults, dt);
                }

                dgvResults.Columns[0].Visible = false;
            }
        }
    }
}
