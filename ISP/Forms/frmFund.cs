using ISP;
using ISP.Presentation;
using ISP.Presentation.Utilities;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ISP.Business.Entities;

namespace ISP.Presentation.Forms
{
	public partial class frmFund : Form, IMessageFilter
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

        private frmMain frmMain_Parent;
        private Fund CurrentFund;

        public frmFund(frmMain mf, Guid _fundId, string benchMark = null)
        {
            frmSplashScreen ss = new frmSplashScreen();
            ss.Show();
            Application.DoEvents();

            InitializeComponent();
            frmMain_Parent = mf;

            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            Application.AddMessageFilter(this);
            controlsToMove.Add(label26);
            controlsToMove.Add(lblFundName);
            controlsToMove.Add(panel8);
            controlsToMove.Add(panel16);

            CurrentFund = new Fund(_fundId, null);

            fundFormOpen();
            LoadPlansDgv();
            getAdvisors();

            lblFundName.Text = Fields.NullHandler(CurrentFund.FundName);
            lblInvestmentId.Text = Fields.NullHandler(CurrentFund.Ticker);

            if (benchMark != null)
            {
                cboBench.Text = benchMark;
            }

            Text = CurrentFund.FundName;
            label26.Text = "Investment Services Program - " + CurrentFund.FundName;


            if (CurrentFund.InceptionDate == null)
            {
                lblInceptionDate.Text = Fields.NullHandler(null);
            }
            else
            {
                lblInceptionDate.Text = ((DateTime)CurrentFund.InceptionDate).ToString("MMM yyyy");
            }

            lblFundAssets.Text = FormatMoneyWithAbbreviations(CurrentFund.FundAssets);

            if (CurrentFund.TimeTableId != null)
            {
                label12.Text = "| As of " + CurrentFund.AsOfDate;

                if (CurrentFund.YearValue != DateTime.Now.Year)
                    lblRetYTD.Text = CurrentFund.YearValue.ToString();
                else
                    lblRetYTD.Text = "YTD";

                lblRetY1.Text = (CurrentFund.YearValue - 1).ToString();
                lblRetY2.Text = (CurrentFund.YearValue - 2).ToString();
                lblRetY3.Text = (CurrentFund.YearValue - 3).ToString();
                lblRetY4.Text = (CurrentFund.YearValue - 4).ToString();
                lblRetY5.Text = (CurrentFund.YearValue - 5).ToString();
                lblRetY6.Text = (CurrentFund.YearValue - 6).ToString();
                lblRetY7.Text = (CurrentFund.YearValue - 7).ToString();
                lblRetY8.Text = (CurrentFund.YearValue - 8).ToString();
                lblRetY9.Text = (CurrentFund.YearValue - 9).ToString();
                lblRetY10.Text = (CurrentFund.YearValue - 10).ToString();
            }
            else
            {
                label12.Text = "| No monthly data exists for this fund";
            }

            lblTopTenHolding.Text = Fields.NullHandler(CurrentFund.Top10Holdings);
            lblExpenseRatio.Text = Fields.NullHandler(CurrentFund.GrossExpenseRatio);
            lblNumberHolding.Text = Fields.NullHandler(CurrentFund.TotNumOfHoldings);
            lblTurnoverRatio.Text = Fields.NullHandler(CurrentFund.TurnoverRatio);

            lblAvgEffDuration.Text = Fields.NullHandler(CurrentFund.AvgEffectiveDuration);
            lblPeYield.Text = Fields.NullHandler(CurrentFund.PeYield);
            lblPbYield.Text = Fields.NullHandler(CurrentFund.PbYield);

            lblTrailingReturnYTD.Text = Fields.NullHandler(CurrentFund.TrailingReturnYTD);
            lblTrailingReturnM1.Text = Fields.NullHandler(CurrentFund.TrailingReturnM1);
            lblFundRetYTD.Text = Fields.NullHandler(CurrentFund.TrailingReturnYTD);
            lblFundRetY1.Text = Fields.NullHandler(CurrentFund.AnnRetY1);
            lblFundRetY2.Text = Fields.NullHandler(CurrentFund.AnnRetY2);
            lblFundRetY3.Text = Fields.NullHandler(CurrentFund.AnnRetY3);
            lblFundRetY4.Text = Fields.NullHandler(CurrentFund.AnnRetY4);
            lblFundRetY5.Text = Fields.NullHandler(CurrentFund.AnnRetY5);
            lblFundRetY6.Text = Fields.NullHandler(CurrentFund.AnnRetY6);
            lblFundRetY7.Text = Fields.NullHandler(CurrentFund.AnnRetY7);
            lblFundRetY8.Text = Fields.NullHandler(CurrentFund.AnnRetY8);
            lblFundRetY9.Text = Fields.NullHandler(CurrentFund.AnnRetY9);
            lblFundRetY10.Text = Fields.NullHandler(CurrentFund.AnnRetY10);

            ss.Close();
            this.Show();
		}

        private frmTask _frmTask;

        private Guid advisorId;

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

        public class ListBoxItem
        {
            string displayValue;
            string hiddenValue;

            //Constructor
            public ListBoxItem(string d, string h)
            {
                displayValue = d;
                hiddenValue = h;
            }

            //Accessor
            public string HiddenValue
            {
                get
                {
                    return hiddenValue;
                }
            }

            //Override ToString method
            public override string ToString()
            {
                return displayValue;
            }
        }

        private string FormatMoneyWithAbbreviations(decimal? _assets)
        {
            // Format/set the fund assets field (examples: $30M, $140K, $7B, etc.)
            if (_assets == null)
            {
                return Fields.NullHandler(null);
            }
            else
            {
                if (_assets > 999 && _assets < 10000)
                    return "$" + _assets.ToString().Substring(0, 1) + "K";
                else if (_assets > 9999 && _assets < 100000)
                    return "$" + _assets.ToString().Substring(0, 2) + "K";
                else if (_assets > 99999 && _assets < 1000000)
                    return "$" + _assets.ToString().Substring(0, 3) + "K";
                else if (_assets > 999999 && _assets < 10000000)
                    return "$" + _assets.ToString().Substring(0, 1) + "M";
                else if (_assets > 9999999 && _assets < 100000000)
                    return "$" + _assets.ToString().Substring(0, 2) + "M";
                else if (_assets > 99999999 && _assets < 1000000000)
                    return "$" + _assets.ToString().Substring(0, 3) + "M";
                else if (_assets > 999999999 && _assets < 10000000000)
                    return "$" + _assets.ToString().Substring(0, 1) + "B";
                else if (_assets > 9999999999 && _assets < 100000000000)
                    return "$" + _assets.ToString().Substring(0, 2) + "B";
                else if (_assets > 99999999999 && _assets < 1000000000000)
                    return "$" + _assets.ToString().Substring(0, 3) + "B";
                else if (_assets > 999999999999 && _assets < 10000000000000)
                    return "$" + _assets.ToString().Substring(0, 1) + "T";
                else if (_assets > 9999999999999 && _assets < 100000000000000)
                    return "$" + _assets.ToString().Substring(0, 2) + "T";
                else if (_assets > 99999999999999 && _assets < 1000000000000000)
                    return "$" + _assets.ToString().Substring(0, 3) + "T";
                else
                    return ((decimal)_assets).ToString("C0");
            }
        }

        public void LoadPlansDgv()
        {
            DataTable dt = ISP.Business.Entities.Plan.GetAssociatedFromFund(CurrentFund.FundId);

            dgvPlans.DataSource = dt;
            dgvPlans.Columns[0].Visible = false;
            dgvPlans.Columns[1].Visible = false;
            dgvPlans.Columns[2].Visible = false;

            dgvPlans.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPlans.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPlans.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void getAdvisors()
        {
            dgvAdvisors.DataSource = ISP.Business.Entities.Advisors.GetAssociatedFromFund(CurrentFund.FundId);
            dgvAdvisors.Columns[0].Visible = false;
        }
			
		public void fundFormOpen()
        {
            foreach (DataRow dr in ISP.Business.Entities.Benchmarks.Get().Rows)
            {
                cboBench.Items.Add(new ListBoxItem(dr["FundName"].ToString(), dr["FundId"].ToString()));
            }

            foreach (DataRow dr in ISP.Business.Entities.TimeTable.GetAssociatedFromFund(CurrentFund.FundId).Rows)
            {
                comboBox3.Items.Add(new ListBoxItem(dr["Month"].ToString(), dr["TimeTableId"].ToString()));
            }

            if (comboBox1.Items.Count > 0) { comboBox1.SelectedIndex = 0; }
            if (comboBox2.Items.Count > 0) { comboBox2.SelectedIndex = 0; }
            if (comboBox3.Items.Count > 0) { comboBox3.SelectedIndex = 0; }
            if (cboAdvView.Items.Count > 0) { cboAdvView.SelectedIndex = 0; }
            if (cboManagerViews.Items.Count > 0) { cboManagerViews.SelectedIndex = 0; }
		}
		
		void cboTaskViews_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (cboTaskViews.Text == "My Open Associated Tasks")
            {
                dgvTasks.DataSource = ISP.Business.Entities.Task.GetActiveAssociatedFromUserAndFund(frmMain_Parent.CurrentUser.UserId, CurrentFund.FundId);
            }
            else if (cboTaskViews.Text == "My Closed Associated Tasks")
            {
                dgvTasks.DataSource = ISP.Business.Entities.Task.GetInactiveAssociatedFromUserAndFund(frmMain_Parent.CurrentUser.UserId, CurrentFund.FundId);
            }
            else if (cboTaskViews.Text == "All Open Associated Tasks")
            {
                dgvTasks.DataSource = ISP.Business.Entities.Task.GetActiveAssociatedFromFund(CurrentFund.FundId);
            }
            else if (cboTaskViews.Text == "All Closed Associated Tasks")
            {
                dgvTasks.DataSource = ISP.Business.Entities.Task.GetInactiveAssociatedFromFund(CurrentFund.FundId);
            }
            else
            {
                dgvTasks.DataSource = null;
            }

            dgvTasks.Columns[0].Visible = false;
            dgvTasks.Columns[1].Visible = false;
            dgvTasks.Columns[2].Visible = false;
            dgvTasks.Columns[3].Visible = false;
		}
		
		void ButtonNewTaskClick(object sender, EventArgs e)
		{
			_frmTask = new frmTask(frmMain_Parent);

            _frmTask.FundId = CurrentFund.FundId.ToString();
			_frmTask.comboBoxRegarding.Text = lblFundName.Text;
		}
		
		public void tabControl1SelectedIndexChanged(object sender, EventArgs e)
		{
			cboTaskViews.SelectedIndex = 0;
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

        private void label38_Click(object sender, EventArgs e)
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
            label.BackColor = System.Drawing.Color.SteelBlue;
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
            label.BackColor = System.Drawing.Color.AliceBlue;
        }

        private void ReportTypeMenuItem_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.SystemColors.ControlText;
            label.BackColor = System.Drawing.Color.PowderBlue;
        }

        private void CalculateCorrelationAndOutperformance()
        {
            if (cboBench.SelectedIndex == -1)
                return;

            Guid benchId = new Guid(((ListBoxItem)cboBench.SelectedItem).HiddenValue);

            CurrentFund.RunComparison(benchId);
            lblCorrel3Yr.Text = CurrentFund.Comparison.CorrelationToBench3Yr.ToString();
            lblCorrel5Yr.Text = CurrentFund.Comparison.CorrelationToBench5Yr.ToString();
            lblOutperform3Yr.Text = CurrentFund.Comparison.OutperformAvg3Yr.ToString() + "%";
            lblOutperform5Yr.Text = CurrentFund.Comparison.OutperformAvg5Yr.ToString() + "%";
        }

        private void LoadCharts()
        {
            DataTable dt = null;

            string timeTableId = "NULL";
            string benchId = "NULL";

            Guid timeTableIdGuid;
            Guid benchIdGuid;

            if (comboBox3.SelectedIndex != -1) { timeTableId = ((ListBoxItem)comboBox3.SelectedItem).HiddenValue; }
            if (cboBench.SelectedIndex != -1) { benchId = ((ListBoxItem)cboBench.SelectedItem).HiddenValue; }

            Guid.TryParse(timeTableId, out timeTableIdGuid);
            Guid.TryParse(benchId, out benchIdGuid);

            chartMain.Series["Investment"].Points.Clear();
            chartMain.Series["Benchmark"].Points.Clear();

            System.Windows.Forms.DataVisualization.Charting.SeriesChartType lineChart = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            System.Windows.Forms.DataVisualization.Charting.SeriesChartType columnChart = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            chartMain.Series["Investment"].ChartType = lineChart;
            chartMain.Series["Benchmark"].ChartType = lineChart;

            chartMain.Series["Investment"].Label = "#VAL{0.0}";
            chartMain.Series["Investment"].IsValueShownAsLabel = true;

            chartMain.Series["Benchmark"].Label = null;
            chartMain.Series["Benchmark"].IsValueShownAsLabel = false;

            if (comboBox1.Text == "12 Month Rolling Return")
            {
                dt = ISP.Business.Entities.Fund.Get12MoRollingReturn(timeTableIdGuid, CurrentFund.FundId, benchIdGuid);

                chartMain.Series["Investment"].Label = null;
                chartMain.Series["Investment"].IsValueShownAsLabel = false;
            }
            else if (comboBox1.Text == "36 Month Rolling Return")
            {
                dt = ISP.Business.Entities.Fund.Get36MoRollingReturn(timeTableIdGuid, CurrentFund.FundId, benchIdGuid);

                chartMain.Series["Investment"].Label = null;
                chartMain.Series["Investment"].IsValueShownAsLabel = false;
            }
            else if (comboBox1.Text == "36 Month Rolling Standard Deviation")
            {
                dt = ISP.Business.Entities.Fund.Get36MoRollingStandardDeviation(timeTableIdGuid, CurrentFund.FundId, benchIdGuid);

                chartMain.Series["Investment"].Label = null;
                chartMain.Series["Investment"].IsValueShownAsLabel = false;
            }
            else if (comboBox1.Text == "Annualized Returns")
            {
                dt = ISP.Business.Entities.Fund.GetAnnualizedReturns(timeTableIdGuid, CurrentFund.FundId, benchIdGuid);

                chartMain.Series["Benchmark"].Label = "#VAL{0.0}";
                chartMain.Series["Benchmark"].IsValueShownAsLabel = true;

                chartMain.Series["Investment"].ChartType = columnChart;
                chartMain.Series["Benchmark"].ChartType = columnChart;
            }
            else if (comboBox1.Text == "Annual Returns")
            {
                dt = ISP.Business.Entities.Fund.GetAnnualReturns(timeTableIdGuid, CurrentFund.FundId, benchIdGuid);

                chartMain.Series["Benchmark"].Label = "#VAL{0.0}";
                chartMain.Series["Benchmark"].IsValueShownAsLabel = true;

                chartMain.Series["Investment"].ChartType = columnChart;
                chartMain.Series["Benchmark"].ChartType = columnChart;
            }
            else if (comboBox1.Text == "Standard Deviation")
            {
                dt = ISP.Business.Entities.Fund.GetStandardDevation(timeTableIdGuid, CurrentFund.FundId, benchIdGuid);

                chartMain.Series["Benchmark"].Label = "#VAL{0.0}";
                chartMain.Series["Benchmark"].IsValueShownAsLabel = true;

                chartMain.Series["Investment"].ChartType = columnChart;
                chartMain.Series["Benchmark"].ChartType = columnChart;
            }

            chartMain.Series["Investment"].XValueMember = "XAxis";
            chartMain.Series["Investment"].YValueMembers = "FundSeries";
            chartMain.Series["Benchmark"].XValueMember = "XAxis";
            chartMain.Series["Benchmark"].YValueMembers = "BenchSeries";

            chartMain.DataSource = dt;

            //
            // chartSummary
            //

            dt = ISP.Business.Entities.Fund.GetAnnualizedReturns(timeTableIdGuid, CurrentFund.FundId, benchIdGuid);

            chartSummary.Series["Investment"].Points.Clear();
            chartSummary.Series["Benchmark"].Points.Clear();

            chartSummary.Series["Investment"].XValueMember = "XAxis";
            chartSummary.Series["Investment"].YValueMembers = "FundSeries";
            chartSummary.Series["Benchmark"].XValueMember = "XAxis";
            chartSummary.Series["Benchmark"].YValueMembers = "BenchSeries";
            chartSummary.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCharts();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCharts();
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

        private void openTask(object sender, EventArgs e)
        {
            frmMain_Parent.Activate();
            frmMain_Parent.tabMain.SelectedIndex = 5;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Presentation.Forms.frmAddExistingItem aei = new Presentation.Forms.frmAddExistingItem(frmMain_Parent, "Plan", CurrentFund.FundId, null, getPlansEventHandler);
        }

        private void getPlansEventHandler (object sender, FormClosedEventArgs e)
        {
            LoadPlansDgv();
        }

        private void cboBench_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBench.SelectedIndex != -1)
            {
                Guid benchmarkId = new Guid(((ListBoxItem)cboBench.SelectedItem).HiddenValue);
                this.CurrentFund.Benchmark = new Fund(benchmarkId, this.CurrentFund.TimeTableId);
            }

            CalculateCorrelationAndOutperformance();
            LoadCharts();
            LoadIndexReturns();
        }

        private void LoadIndexReturns()
        {
            if (this.CurrentFund.Benchmark == null)
                return;

            lblIndexRetYTD.Text = Fields.NullHandler(this.CurrentFund.Benchmark.TrailingReturnYTD);
            lblIndexRetY1.Text = Fields.NullHandler(this.CurrentFund.Benchmark.AnnRetY1);
            lblIndexRetY2.Text = Fields.NullHandler(this.CurrentFund.Benchmark.AnnRetY2);
            lblIndexRetY3.Text = Fields.NullHandler(this.CurrentFund.Benchmark.AnnRetY3);
            lblIndexRetY4.Text = Fields.NullHandler(this.CurrentFund.Benchmark.AnnRetY4);
            lblIndexRetY5.Text = Fields.NullHandler(this.CurrentFund.Benchmark.AnnRetY5);
            lblIndexRetY6.Text = Fields.NullHandler(this.CurrentFund.Benchmark.AnnRetY6);
            lblIndexRetY7.Text = Fields.NullHandler(this.CurrentFund.Benchmark.AnnRetY7);
            lblIndexRetY8.Text = Fields.NullHandler(this.CurrentFund.Benchmark.AnnRetY8);
            lblIndexRetY9.Text = Fields.NullHandler(this.CurrentFund.Benchmark.AnnRetY9);
            lblIndexRetY10.Text = Fields.NullHandler(this.CurrentFund.Benchmark.AnnRetY10);

            if (CurrentFund.TrailingReturnYTD < CurrentFund.Benchmark.TrailingReturnYTD)
                lblFundRetYTD.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetYTD.ForeColor = System.Drawing.Color.Black;

            if (CurrentFund.AnnRetY1 < CurrentFund.Benchmark.AnnRetY1)
                lblFundRetY1.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY1.ForeColor = System.Drawing.Color.Black;

            if (CurrentFund.AnnRetY2 < CurrentFund.Benchmark.AnnRetY2)
                lblFundRetY2.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY2.ForeColor = System.Drawing.Color.Black;

            if (CurrentFund.AnnRetY3 < CurrentFund.Benchmark.AnnRetY3)
                lblFundRetY3.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY3.ForeColor = System.Drawing.Color.Black;

            if (CurrentFund.AnnRetY4 < CurrentFund.Benchmark.AnnRetY4)
                lblFundRetY4.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY4.ForeColor = System.Drawing.Color.Black;

            if (CurrentFund.AnnRetY5 < CurrentFund.Benchmark.AnnRetY5)
                lblFundRetY5.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY5.ForeColor = System.Drawing.Color.Black;

            if (CurrentFund.AnnRetY6 < CurrentFund.Benchmark.AnnRetY6)
                lblFundRetY6.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY6.ForeColor = System.Drawing.Color.Black;

            if (CurrentFund.AnnRetY7 < CurrentFund.Benchmark.AnnRetY7)
                lblFundRetY7.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY7.ForeColor = System.Drawing.Color.Black;

            if (CurrentFund.AnnRetY8 < CurrentFund.Benchmark.AnnRetY8)
                lblFundRetY8.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY8.ForeColor = System.Drawing.Color.Black;

            if (CurrentFund.AnnRetY9 < CurrentFund.Benchmark.AnnRetY9)
                lblFundRetY9.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY9.ForeColor = System.Drawing.Color.Black;

            if (CurrentFund.AnnRetY10 < CurrentFund.Benchmark.AnnRetY10)
                lblFundRetY10.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY10.ForeColor = System.Drawing.Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dgvPlans.CurrentRow.Index;
            Guid rfpID = new Guid(dgvPlans.Rows[index].Cells[0].Value.ToString());
            Guid userId = frmMain_Parent.CurrentUser.UserId;
            string planName = dgvPlans.Rows[index].Cells[3].Value.ToString();

            DialogResult result = MessageBox.Show("Are you sure you wish to remove " + lblFundName.Text + " from " + planName + "?", "Attention", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ISP.Business.Entities.Relational_Funds_Plans.Remove(rfpID, userId);
            }

            LoadPlansDgv();
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvPlans.CurrentRow.Index;
            label41.Text = dgvPlans.Rows[index].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = dgvPlans.CurrentRow.Index;
            Guid accountId = new Guid(dgvPlans.Rows[index].Cells[2].Value.ToString());

            Presentation.Forms.frmAccount accountForm = new Presentation.Forms.frmAccount(frmMain_Parent, accountId);
            accountForm.tabControlClientDetail.SelectedIndex = 1;
        }

        private void lblAdvisors_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 4;
        }

        private void btnOpenAdv_Click(object sender, EventArgs e)
        {
            int index = dgvAdvisors.CurrentRow.Index;
            advisorId = new Guid(dgvAdvisors.Rows[index].Cells[0].Value.ToString());

            Presentation.Forms.frmAdvisor advisorForm = new Presentation.Forms.frmAdvisor(frmMain_Parent, advisorId);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvAdvisors.DataSource = ISP.Business.Entities.Advisors.GetAssociatedFromFund(CurrentFund.FundId);
        }

        private void dgvAdvisors_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvAdvisors.CurrentRow.Index;
            advisorId = new Guid(dgvAdvisors.Rows[index].Cells[0].Value.ToString());
            lblSelectedAdv.Text = dgvAdvisors.Rows[index].Cells[1].Value.ToString();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvPlans.CurrentRow.Index;
            Guid accountId = new Guid(dgvPlans.Rows[index].Cells[2].Value.ToString());

            Presentation.Forms.frmAccount accountForm = new Presentation.Forms.frmAccount(frmMain_Parent, accountId);
            accountForm.tabControlClientDetail.SelectedIndex = 1;
        }

        private void dgvAdvisors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvAdvisors.CurrentRow.Index;
            advisorId = new Guid(dgvAdvisors.Rows[index].Cells[0].Value.ToString());

            Presentation.Forms.frmAdvisor advisorForm = new Presentation.Forms.frmAdvisor(frmMain_Parent, advisorId);
        }

        private void lblMenuDetails_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 5;

            if (dgvFundDetail.DataSource == null)
                LoadFundDetailDgv();
        }

        private void LoadFundDetailDgv()
        {
            dgvFundDetail.DataSource = Fund.GetFundDetails(CurrentFund.FundId);
            dgvFundDetail.Columns[0].Visible = false;
        }

        private void btnRefreshReturns_Click(object sender, EventArgs e)
        {
            LoadFundDetailDgv();
        }

        private void cboManagerViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadManagersDgv();
        }

        private void LoadManagersDgv()
        {
            dgvManagers.DataSource = Manager.GetAssociatedFromFund(this.CurrentFund.FundId);
            dgvManagers.Columns["ManagerId"].Visible = false;
        }

        private void lblManagers_Click(object sender, EventArgs e)
        {
            tabMain.SelectedTab = tabMain.TabPages["tabManagers"];
        }

        private void btnOpenManager_Click(object sender, EventArgs e)
        {
            OpenManager();
        }

        private void OpenManager()
        {
            int index = dgvManagers.CurrentRow.Index;
            Guid _managerId = new Guid(dgvManagers.Rows[index].Cells[0].Value.ToString());
            frmManager _frmManager = new frmManager(frmMain_Parent, _managerId);
        }

        private void dgvManagers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenManager();
        }

        private void dgvManagers_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvManagers.CurrentRow.Index;
            string _firstName = dgvManagers.Rows[index].Cells["First Name"].Value.ToString();
            string _middleName = dgvManagers.Rows[index].Cells["Middle Name"].Value.ToString();
            string _lastName = dgvManagers.Rows[index].Cells["Last Name"].Value.ToString();
            string _fullName = _firstName + " " + _middleName + " " + _lastName;
            lblSelectedManager.Text = _fullName;
        }
	}
}
