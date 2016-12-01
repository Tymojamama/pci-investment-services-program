using ISP;
using ISP.Presentation;
using ISP.Presentation.Utilities;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ISP.Business.Entities;

namespace ISP.Presentation.Forms
{
	public partial class frmFund : Form, IMessageFilter
    {
        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

        private frmMain frmMain_Parent;

        private Fund CurrentFund;
        private Fund CurrentBenchmark;
        private FundDetail CurrentFundDetail;
        private FundDetail CurrentBenchmarkDetail;
        private TimeTable CurrentTimeTable;
        private CorrelationAndOutperformance CurrentCorrelationAndOutperformance;

        private Timer _updatePanelTimer = null;
        private bool unsavedChanges = false;

        public frmFund(frmMain mf, Guid fundId, string benchMark = null)
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

            CurrentFund = new Fund(fundId);
            CurrentTimeTable = TimeTable.GetMostRecentTimeTable(CurrentFund.Id);
            CurrentFundDetail = FundDetail.GetAssociatedFundDetail(CurrentFund, CurrentTimeTable);

            fundFormOpen();
            LoadPlansDgv();
            LoadAdvisorTypeCbo();
            getAdvisors();

            lblFundName.Text = Fields.NullHandler(CurrentFund.FundName);
            lblInvestmentId.Text = Fields.NullHandler(CurrentFund.Ticker);

            if (benchMark != null)
            {
                cboBench.Text = benchMark;
            }

            Text = CurrentFund.FundName;
            label26.Text = "Investment Services Program - " + CurrentFund.FundName;


            if (CurrentFund.InceptDate == null)
            {
                lblInceptionDate.Text = Fields.NullHandler(null);
            }
            else
            {
                lblInceptionDate.Text = ((DateTime)CurrentFund.InceptDate).ToString("MMM yyyy");
            }

            if (CurrentFundDetail != null)
            {
                lblFundAssets.Text = FormatMoneyWithAbbreviations(CurrentFundDetail.FundNetAssets);
                lblTopTenHolding.Text = Fields.NullHandler(CurrentFundDetail.Top10holdings);
                lblExpenseRatio.Text = Fields.NullHandler(CurrentFundDetail.ProspectusGrossExpenseRatio);
                lblNumberHolding.Text = Fields.NullHandler(CurrentFundDetail.TotNumOfHoldings);
                lblTurnoverRatio.Text = Fields.NullHandler(CurrentFundDetail.TurnoverRatio);

                lblAvgEffDuration.Text = Fields.NullHandler(CurrentFundDetail.AvgEffDuration);
                lblPeYield.Text = Fields.NullHandler(CurrentFundDetail.PeRatioTTM);
                lblPbYield.Text = Fields.NullHandler(CurrentFundDetail.PbRatioTTM);

                lblTrailingReturnYTD.Text = Fields.NullHandler(CurrentFundDetail.TrailingReturnYTD);
                lblTrailingReturnM1.Text = Fields.NullHandler(CurrentFundDetail.TrailingReturnM1);
                lblFundRetYTD.Text = Fields.NullHandler(CurrentFundDetail.TrailingReturnYTD);
                lblFundRetY1.Text = Fields.NullHandler(CurrentFundDetail.AnnRetY1);
                lblFundRetY2.Text = Fields.NullHandler(CurrentFundDetail.AnnRetY2);
                lblFundRetY3.Text = Fields.NullHandler(CurrentFundDetail.AnnRetY3);
                lblFundRetY4.Text = Fields.NullHandler(CurrentFundDetail.AnnRetY4);
                lblFundRetY5.Text = Fields.NullHandler(CurrentFundDetail.AnnRetY5);
                lblFundRetY6.Text = Fields.NullHandler(CurrentFundDetail.AnnRetY6);
                lblFundRetY7.Text = Fields.NullHandler(CurrentFundDetail.AnnRetY7);
                lblFundRetY8.Text = Fields.NullHandler(CurrentFundDetail.AnnRetY8);
                lblFundRetY9.Text = Fields.NullHandler(CurrentFundDetail.AnnRetY9);
                lblFundRetY10.Text = Fields.NullHandler(CurrentFundDetail.AnnRetY10);
            }

            if (CurrentTimeTable != null)
            {
                label12.Text = "| As of " + CurrentTimeTable.EndDate.ToString("MMMM yyyy");

                if (CurrentTimeTable.YearValue != DateTime.Now.Year)
                    lblRetYTD.Text = CurrentTimeTable.YearValue.ToString();
                else
                    lblRetYTD.Text = "YTD";

                lblRetY1.Text = (CurrentTimeTable.YearValue - 1).ToString();
                lblRetY2.Text = (CurrentTimeTable.YearValue - 2).ToString();
                lblRetY3.Text = (CurrentTimeTable.YearValue - 3).ToString();
                lblRetY4.Text = (CurrentTimeTable.YearValue - 4).ToString();
                lblRetY5.Text = (CurrentTimeTable.YearValue - 5).ToString();
                lblRetY6.Text = (CurrentTimeTable.YearValue - 6).ToString();
                lblRetY7.Text = (CurrentTimeTable.YearValue - 7).ToString();
                lblRetY8.Text = (CurrentTimeTable.YearValue - 8).ToString();
                lblRetY9.Text = (CurrentTimeTable.YearValue - 9).ToString();
                lblRetY10.Text = (CurrentTimeTable.YearValue - 10).ToString();
            }
            else
            {
                label12.Text = "| No monthly data exists for this fund";
            }

            txtInternalBenchmark.Text = CurrentFund.InternalBenchmark;
            txtDefinedUniverse.Text = CurrentFund.DefinedUniverse;
            txtPurchaseStrategy.Text = CurrentFund.PurchaseStrategy;
            txtSellStrategy.Text = CurrentFund.SellStrategy;
            txtTargetNumberPositions.Text = CurrentFund.TargetNumberPositions;
            txtDiversified1940Act.Text = CurrentFund.Diversified1940Act;
            txtEDGARReview.Text = CurrentFund.EDGARReview;

            pnlSummaryBody.VerticalScroll.Visible = false;
            pnlSummaryBody.VerticalScroll.Enabled = false;

            ss.Close();
            this.Show();
		}

        private frmTask _frmTask;

        private Guid advisorId;

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

        private void LoadPlansDgv()
        {
            DataTable dt = PlanDetail.GetAssociatedFromFund(CurrentFund.Id);

            dgvPlans.DataSource = dt;
            dgvPlans.Columns["Relational_Funds_PlansId"].Visible = false;
            dgvPlans.Columns["PlanId"].Visible = false;
            dgvPlans.Columns["AccountId"].Visible = false;

            dgvPlans.Columns["PlanName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPlans.Columns["PlanType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPlans.Columns["AssetValue"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPlans.Columns["Account"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPlans.Columns["DateAdded"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPlans.Columns["DateRemoved"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvPlans.Columns["PlanName"].HeaderText = "Plan Name";
            dgvPlans.Columns["PlanType"].HeaderText = "Plan Type";
            dgvPlans.Columns["AssetValue"].HeaderText = "Asset Value";
            dgvPlans.Columns["DateAdded"].HeaderText = "Date Added";
            dgvPlans.Columns["DateRemoved"].HeaderText = "Date Removed";

            dgvPlans.Columns["AssetValue"].DefaultCellStyle.Format = "C2";
        }

        private void getAdvisors()
        {
            dgvAdvisors.DataSource = ISP.Business.Entities.Advisors.GetAssociatedFromFund(CurrentFund.Id);
            dgvAdvisors.Columns[0].Visible = false;
        }

        private void fundFormOpen()
        {
            foreach (DataRow dr in ISP.Business.Entities.Benchmarks.Get().Rows)
            {
                cboBench.Items.Add(new ListItem(dr["FundName"].ToString(), dr["FundId"].ToString()));
            }

            foreach (DataRow dr in ISP.Business.Entities.TimeTable.GetAssociatedFromFund(CurrentFund.Id).Rows)
            {
                comboBox3.Items.Add(new ListItem(dr["Month"].ToString(), dr["TimeTableId"].ToString()));
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
                dgvTasks.DataSource = ISP.Business.Entities.Task.GetActiveAssociatedFromUserAndFund(frmMain_Parent.CurrentUser.UserId, CurrentFund.Id);
            }
            else if (cboTaskViews.Text == "My Closed Associated Tasks")
            {
                dgvTasks.DataSource = ISP.Business.Entities.Task.GetInactiveAssociatedFromUserAndFund(frmMain_Parent.CurrentUser.UserId, CurrentFund.Id);
            }
            else if (cboTaskViews.Text == "All Open Associated Tasks")
            {
                dgvTasks.DataSource = ISP.Business.Entities.Task.GetActiveAssociatedFromFund(CurrentFund.Id);
            }
            else if (cboTaskViews.Text == "All Closed Associated Tasks")
            {
                dgvTasks.DataSource = ISP.Business.Entities.Task.GetInactiveAssociatedFromFund(CurrentFund.Id);
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
            _frmTask.CurrentTask.FundId = CurrentFund.Id;
            _frmTask.SetFundId(CurrentFund.Id);
		}

        private void tabControl1SelectedIndexChanged(object sender, EventArgs e)
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
            if (UnsavedChanges())
            {
                DialogResult dialogResult = MessageBox.Show("There are unsaved changes. Are you sure you wish to exit?", "Attention", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void SetTextFundFields()
        {
            // txtInternalBenchmark
            if (String.IsNullOrWhiteSpace(txtInternalBenchmark.Text))
            {
                CurrentFund.InternalBenchmark = null;
            }
            else
            {
                CurrentFund.InternalBenchmark = txtInternalBenchmark.Text;
            }

            // txtDefinedUniverse
            if (String.IsNullOrWhiteSpace(txtDefinedUniverse.Text))
            {
                CurrentFund.DefinedUniverse = null;
            }
            else
            {
                CurrentFund.DefinedUniverse = txtDefinedUniverse.Text;
            }

            // txtPurchaseStrategy
            if (String.IsNullOrWhiteSpace(txtPurchaseStrategy.Text))
            {
                CurrentFund.PurchaseStrategy = null;
            }
            else
            {
                CurrentFund.PurchaseStrategy = txtPurchaseStrategy.Text;
            }

            // txtSellStrategy
            if (String.IsNullOrWhiteSpace(txtSellStrategy.Text))
            {
                CurrentFund.SellStrategy = null;
            }
            else
            {
                CurrentFund.SellStrategy = txtSellStrategy.Text;
            }

            // txtTargetNumberPositions
            if (String.IsNullOrWhiteSpace(txtTargetNumberPositions.Text))
            {
                CurrentFund.TargetNumberPositions = null;
            }
            else
            {
                CurrentFund.TargetNumberPositions = txtTargetNumberPositions.Text;
            }

            // txtTargetNumberPositions
            if (String.IsNullOrWhiteSpace(txtTargetNumberPositions.Text))
            {
                CurrentFund.TargetNumberPositions = null;
            }
            else
            {
                CurrentFund.TargetNumberPositions = txtTargetNumberPositions.Text;
            }

            // txtDiversified1940Act
            if (String.IsNullOrWhiteSpace(txtDiversified1940Act.Text))
            {
                CurrentFund.Diversified1940Act = null;
            }
            else
            {
                CurrentFund.Diversified1940Act = txtDiversified1940Act.Text;
            }

            // txtEDGARReview
            if (String.IsNullOrWhiteSpace(txtEDGARReview.Text))
            {
                CurrentFund.EDGARReview = null;
            }
            else
            {
                CurrentFund.EDGARReview = txtEDGARReview.Text;
            }
        }

        private bool UnsavedChanges()
        {
            Fund databaseFund = new Fund(CurrentFund.Id);

            SetTextFundFields();

            if (CurrentFund.InternalBenchmark != databaseFund.InternalBenchmark)
            {
                return true;
            }

            if (CurrentFund.DefinedUniverse != databaseFund.DefinedUniverse)
            {
                return true;
            }

            if (CurrentFund.PurchaseStrategy != databaseFund.PurchaseStrategy)
            {
                return true;
            }

            if (CurrentFund.SellStrategy != databaseFund.SellStrategy)
            {
                return true;
            }

            if (CurrentFund.TargetNumberPositions != databaseFund.TargetNumberPositions)
            {
                return true;
            }

            if (CurrentFund.Diversified1940Act != databaseFund.Diversified1940Act)
            {
                return true;
            }

            if (CurrentFund.EDGARReview != databaseFund.EDGARReview)
            {
                return true;
            }

            return false;
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

            Guid benchId = new Guid(((ListItem)cboBench.SelectedItem).HiddenValue);
            CurrentBenchmark = new Fund(benchId);

            CurrentCorrelationAndOutperformance = new CorrelationAndOutperformance(CurrentFund, CurrentBenchmark, CurrentTimeTable);

            lblCorrel3Yr.Text = CurrentCorrelationAndOutperformance.CorrelationToBench3Yr.ToString();
            lblCorrel5Yr.Text = CurrentCorrelationAndOutperformance.CorrelationToBench5Yr.ToString();
            lblOutperform3Yr.Text = CurrentCorrelationAndOutperformance.OutperformAvg3Yr.ToString() + "%";
            lblOutperform5Yr.Text = CurrentCorrelationAndOutperformance.OutperformAvg5Yr.ToString() + "%";
        }

        private void LoadCharts()
        {
            DataTable dt = null;

            string timeTableId = "NULL";
            string benchId = "NULL";

            Guid timeTableIdGuid;
            Guid benchIdGuid;

            if (comboBox3.SelectedIndex != -1) { timeTableId = ((ListItem)comboBox3.SelectedItem).HiddenValue; }
            if (cboBench.SelectedIndex != -1) { benchId = ((ListItem)cboBench.SelectedItem).HiddenValue; }

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
                dt = ISP.Business.Entities.Fund.Get12MoRollingReturn(timeTableIdGuid, CurrentFund.Id, benchIdGuid);

                chartMain.Series["Investment"].Label = null;
                chartMain.Series["Investment"].IsValueShownAsLabel = false;
            }
            else if (comboBox1.Text == "36 Month Rolling Return")
            {
                dt = ISP.Business.Entities.Fund.Get36MoRollingReturn(timeTableIdGuid, CurrentFund.Id, benchIdGuid);

                chartMain.Series["Investment"].Label = null;
                chartMain.Series["Investment"].IsValueShownAsLabel = false;
            }
            else if (comboBox1.Text == "36 Month Rolling Standard Deviation")
            {
                dt = ISP.Business.Entities.Fund.Get36MoRollingStandardDeviation(timeTableIdGuid, CurrentFund.Id, benchIdGuid);

                chartMain.Series["Investment"].Label = null;
                chartMain.Series["Investment"].IsValueShownAsLabel = false;
            }
            else if (comboBox1.Text == "Annualized Returns")
            {
                dt = ISP.Business.Entities.Fund.GetAnnualizedReturns(timeTableIdGuid, CurrentFund.Id, benchIdGuid);

                chartMain.Series["Benchmark"].Label = "#VAL{0.0}";
                chartMain.Series["Benchmark"].IsValueShownAsLabel = true;

                chartMain.Series["Investment"].ChartType = columnChart;
                chartMain.Series["Benchmark"].ChartType = columnChart;
            }
            else if (comboBox1.Text == "Annual Returns")
            {
                dt = ISP.Business.Entities.Fund.GetAnnualReturns(timeTableIdGuid, CurrentFund.Id, benchIdGuid);

                chartMain.Series["Benchmark"].Label = "#VAL{0.0}";
                chartMain.Series["Benchmark"].IsValueShownAsLabel = true;

                chartMain.Series["Investment"].ChartType = columnChart;
                chartMain.Series["Benchmark"].ChartType = columnChart;
            }
            else if (comboBox1.Text == "Standard Deviation")
            {
                dt = ISP.Business.Entities.Fund.GetStandardDevation(timeTableIdGuid, CurrentFund.Id, benchIdGuid);

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

            dt = Fund.GetAnnualizedReturns(timeTableIdGuid, CurrentFund.Id, benchIdGuid);

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

            // We have to refresh ComboBoxes because they don't draw well after performing this function.
            foreach (ComboBox comboBox in GetAll(this, typeof(ComboBox)))
            {
                comboBox.Refresh();
            }

            Application.DoEvents();
        }

        private IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
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
            frmSelectRecord.RecordType recordType = frmSelectRecord.RecordType.Plan;
            DataTable dataTable = PlanDetail.Get();
            frmSelectRecord frm = new frmSelectRecord(frmMain_Parent, recordType, CurrentFund.FundName, dataTable);
            frm.RecordSelected += frmSelectPlan_RecordSelected;
        }

        private void frmSelectPlan_RecordSelected(object sender, EventArgs e)
        {
            Guid planId = (Guid)sender;
            Relational_Funds_Plans relational_Funds_Plans = new Relational_Funds_Plans();
            relational_Funds_Plans.FundId = CurrentFund.Id;
            relational_Funds_Plans.PlanId = planId;
            relational_Funds_Plans.SaveRecordToDatabase(frmMain_Parent.CurrentUser.UserId);
            LoadPlansDgv();
        }

        private void cboBench_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBench.SelectedIndex != -1)
            {
                Guid benchmarkId = new Guid(((ListItem)cboBench.SelectedItem).HiddenValue);
                CurrentBenchmark = new Fund(benchmarkId);
            }

            CalculateCorrelationAndOutperformance();
            LoadCharts();
            LoadIndexReturns();
        }

        private void LoadIndexReturns()
        {
            if (CurrentBenchmark == null)
                return;

            CurrentBenchmarkDetail = FundDetail.GetAssociatedFundDetail(CurrentBenchmark, CurrentTimeTable);

            lblIndexRetYTD.Text = Fields.NullHandler(CurrentBenchmarkDetail.TrailingReturnYTD);
            lblIndexRetY1.Text = Fields.NullHandler(CurrentBenchmarkDetail.AnnRetY1);
            lblIndexRetY2.Text = Fields.NullHandler(CurrentBenchmarkDetail.AnnRetY2);
            lblIndexRetY3.Text = Fields.NullHandler(CurrentBenchmarkDetail.AnnRetY3);
            lblIndexRetY4.Text = Fields.NullHandler(CurrentBenchmarkDetail.AnnRetY4);
            lblIndexRetY5.Text = Fields.NullHandler(CurrentBenchmarkDetail.AnnRetY5);
            lblIndexRetY6.Text = Fields.NullHandler(CurrentBenchmarkDetail.AnnRetY6);
            lblIndexRetY7.Text = Fields.NullHandler(CurrentBenchmarkDetail.AnnRetY7);
            lblIndexRetY8.Text = Fields.NullHandler(CurrentBenchmarkDetail.AnnRetY8);
            lblIndexRetY9.Text = Fields.NullHandler(CurrentBenchmarkDetail.AnnRetY9);
            lblIndexRetY10.Text = Fields.NullHandler(CurrentBenchmarkDetail.AnnRetY10);

            if (CurrentFundDetail.TrailingReturnYTD < CurrentBenchmarkDetail.TrailingReturnYTD)
                lblFundRetYTD.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetYTD.ForeColor = System.Drawing.Color.Black;

            if (CurrentFundDetail.AnnRetY1 < CurrentBenchmarkDetail.AnnRetY1)
                lblFundRetY1.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY1.ForeColor = System.Drawing.Color.Black;

            if (CurrentFundDetail.AnnRetY2 < CurrentBenchmarkDetail.AnnRetY2)
                lblFundRetY2.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY2.ForeColor = System.Drawing.Color.Black;

            if (CurrentFundDetail.AnnRetY3 < CurrentBenchmarkDetail.AnnRetY3)
                lblFundRetY3.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY3.ForeColor = System.Drawing.Color.Black;

            if (CurrentFundDetail.AnnRetY4 < CurrentBenchmarkDetail.AnnRetY4)
                lblFundRetY4.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY4.ForeColor = System.Drawing.Color.Black;

            if (CurrentFundDetail.AnnRetY5 < CurrentBenchmarkDetail.AnnRetY5)
                lblFundRetY5.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY5.ForeColor = System.Drawing.Color.Black;

            if (CurrentFundDetail.AnnRetY6 < CurrentBenchmarkDetail.AnnRetY6)
                lblFundRetY6.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY6.ForeColor = System.Drawing.Color.Black;

            if (CurrentFundDetail.AnnRetY7 < CurrentBenchmarkDetail.AnnRetY7)
                lblFundRetY7.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY7.ForeColor = System.Drawing.Color.Black;

            if (CurrentFundDetail.AnnRetY8 < CurrentBenchmarkDetail.AnnRetY8)
                lblFundRetY8.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY8.ForeColor = System.Drawing.Color.Black;

            if (CurrentFundDetail.AnnRetY9 < CurrentBenchmarkDetail.AnnRetY9)
                lblFundRetY9.ForeColor = System.Drawing.Color.Red;
            else
                lblFundRetY9.ForeColor = System.Drawing.Color.Black;

            if (CurrentFundDetail.AnnRetY10 < CurrentBenchmarkDetail.AnnRetY10)
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
                Relational_Funds_Plans relational_Funds_Plans = new Relational_Funds_Plans(rfpID);
                relational_Funds_Plans.SetRecordInactive();
                relational_Funds_Plans.SaveRecordToDatabase(userId);
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
            advisorId = new Guid(dgvAdvisors.Rows[index].Cells["AdvisorId"].Value.ToString());

            Presentation.Forms.frmAdvisor advisorForm = new Presentation.Forms.frmAdvisor(frmMain_Parent, advisorId);
        }

        private void cboAdvViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAdvisorsDgv();
        }

        private void dgvAdvisors_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvAdvisors.CurrentRow.Index;
            advisorId = new Guid(dgvAdvisors.Rows[index].Cells["AdvisorId"].Value.ToString());

            if (!String.IsNullOrWhiteSpace(dgvAdvisors.Rows[index].Cells["Relational_Advisors_FundsId"].Value.ToString()))
            {
                Guid fundAdvisorId = new Guid(dgvAdvisors.Rows[index].Cells["Relational_Advisors_FundsId"].Value.ToString());
                LoadFundAdvisorFields(fundAdvisorId);
            }

            lblSelectedAdvisor.Text = dgvAdvisors.Rows[index].Cells["Name"].Value.ToString();

            lblRecordSaved.Visible = false;
        }

        private void LoadFundAdvisorFields(Guid fundAdvisorId)
        {
            FundAdvisor fundAdvisor = new FundAdvisor(fundAdvisorId);

            if (fundAdvisor.AdvisorType != null)
            {
                StringMap advisorType = new StringMap((Guid)fundAdvisor.AdvisorType);
                cboAdvisorType.Text = advisorType.Value;
            }
            else
            {
                cboAdvisorType.SelectedIndex = 0;
            }

            if (fundAdvisor.StartDate != null)
            {
                txtStartDate.Text = ((DateTime)fundAdvisor.StartDate).ToString("M/d/yyyy");
            }
            else
            {
                txtStartDate.Text = null;
            }

            if (fundAdvisor.EndDate != null)
            {
                txtEndDate.Text = ((DateTime)fundAdvisor.EndDate).ToString("M/d/yyyy");
            }
            else
            {
                txtEndDate.Text = null;
            }
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
            advisorId = new Guid(dgvAdvisors.Rows[index].Cells["AdvisorId"].Value.ToString());

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
            dgvFundDetail.DataSource = Fund.GetFundDetails(CurrentFund.Id);
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
            dgvManagers.DataSource = Manager.GetAssociatedFromFund(this.CurrentFund.Id);
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

        private void pnlSummaryBody_Click(object sender, EventArgs e)
        {
            vScrollBar1.Focus();
        }

        private void summaryBodyControl_Click(object sender, EventArgs e)
        {
            vScrollBar1.Focus();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            decimal vScrollBar1_Percent = (decimal)vScrollBar1.Value / (decimal)vScrollBar1.Maximum;

            pnlSummaryBody.VerticalScroll.Value = (int)((decimal)pnlSummaryBody.VerticalScroll.Maximum * vScrollBar1_Percent);

            pnlSummaryBody.SuspendLayout();
            UpdateLayoutAfterDelay(pnlSummaryBody);
        }

        /// <summary>
        /// Updates the layout of the specified control after a delay of 100 milliseconds. Will reset if the method is called before
        /// it reaches 100 milliseconds.
        /// </summary>
        /// <param name="control">Used to resume the layout after the delay.</param>
        /// <remarks>
        /// Took me forever to figure out! I needed to update the control with a delay so that the control would scroll
        /// smoothly with <see cref="vScrollBar1"/>. Panels try to add and immediately remove the scroll bar when the vertical
        /// scrollbar value is changed, which makes it not scroll smoothly. This delays it long enough to not see this shutter.
        /// </remarks>
        private void UpdateLayoutAfterDelay(Control control)
        {
            _updatePanelTimer = new Timer();
            _updatePanelTimer.Interval = 100;
            _updatePanelTimer.Tick += _updatePanelTimer_Tick;
            _updatePanelTimer.Start();
        }

        /// <summary>
        /// Resumes the layout of <see cref="pnlSummaryBody"/> on tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _updatePanelTimer_Tick(object sender, EventArgs e)
        {
            pnlSummaryBody.ResumeLayout(false);
            _updatePanelTimer.Stop();
            _updatePanelTimer.Dispose();
        }

        private void btnSaveFund_Click(object sender, EventArgs e)
        {
            try
            {
                SetTextFundFields();
                CurrentFund.SaveRecordToDatabase(frmMain_Parent.CurrentUser.UserId);
                MessageBox.Show("Record successfully saved!", "Success!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                frmError frmError = new frmError(frmMain_Parent, ex);
            }
        }

        private void btnNewAdvisor_Click(object sender, EventArgs e)
        {
            frmSelectRecord.RecordType selectRecordType = frmSelectRecord.RecordType.Advisor;

            // Create a DataTable with only two columns: AdvisorId and Name.
            DataTable dataTable = Advisors.GetActive();
            foreach (DataColumn dataColumn in Advisors.GetActive().Columns)
            {
                if (dataColumn.ColumnName != "AdvisorId" && dataColumn.ColumnName != "Name")
                {
                    dataTable.Columns.Remove(dataColumn.ColumnName);
                }
            }

            frmSelectRecord frmSelectAdvisor = new frmSelectRecord(frmMain_Parent, selectRecordType, CurrentFund, dataTable);
            frmSelectAdvisor.RecordSelected += frmSelectAdvisor_RecordSelected;
        }

        private void frmSelectAdvisor_RecordSelected(object sender, EventArgs e)
        {
            Guid advisorId = (Guid)sender;

            FundAdvisor relational_Advisors_Funds = new FundAdvisor();
            relational_Advisors_Funds.AdvisorId = advisorId;
            relational_Advisors_Funds.FundId = CurrentFund.Id;
            relational_Advisors_Funds.SaveRecordToDatabase(frmMain_Parent.CurrentUser.UserId);

            LoadAdvisorsDgv();
        }

        private void LoadAdvisorsDgv()
        {
            dgvAdvisors.DataSource = Advisors.GetAssociatedFromFund(CurrentFund.Id);
            dgvAdvisors.Columns["Relational_Advisors_FundsId"].Visible = false;
            dgvAdvisors.Columns["AdvisorId"].Visible = false;

            lblRecordSaved.Visible = false;
        }

        private void btnSaveFundAdvisorDetails_Click(object sender, EventArgs e)
        {
            int index = dgvAdvisors.CurrentRow.Index;
            if (!String.IsNullOrWhiteSpace(dgvAdvisors.Rows[index].Cells["Relational_Advisors_FundsId"].Value.ToString()))
            {
                SaveFundAdvisorDetails();
            }
        }

        private void SaveFundAdvisorDetails()
        {
            int index = dgvAdvisors.CurrentRow.Index;
            Guid fundAdvisorId = new Guid(dgvAdvisors.Rows[index].Cells["Relational_Advisors_FundsId"].Value.ToString());
            FundAdvisor fundAdvisor = new FundAdvisor(fundAdvisorId);

            if (cboAdvisorType.SelectedIndex != -1 && cboAdvisorType.SelectedIndex != 0)
            {
                ListItem listItem = (ListItem)cboAdvisorType.SelectedItem;
                StringMap stringMap = (StringMap)listItem.HiddenObject;
                fundAdvisor.AdvisorType = stringMap.Id;
            }
            else
            {
                fundAdvisor.AdvisorType = null;
            }

            if (String.IsNullOrWhiteSpace(txtStartDate.Text))
            {
                fundAdvisor.StartDate = null;
            }
            else
            {
                try
                {
                    fundAdvisor.StartDate = DateTime.Parse(txtStartDate.Text);
                }
                catch
                {
                    MessageBox.Show("Start Date is not in a recognizable datetime format. Please correct and try again.", "Error", MessageBoxButtons.OK);
                    return;
                }
            }

            if (String.IsNullOrWhiteSpace(txtEndDate.Text))
            {
                fundAdvisor.EndDate = null;
            }
            else
            {
                try
                {
                    fundAdvisor.EndDate = DateTime.Parse(txtEndDate.Text);
                }
                catch
                {
                    MessageBox.Show("End Date is not in a recognizable datetime format. Please correct and try again.", "Error", MessageBoxButtons.OK);
                    return;
                }
            }

            fundAdvisor.SaveRecordToDatabase(frmMain_Parent.CurrentUser.UserId);
            LoadAdvisorsDgv();
            SelectFundAdvisorInAdvisorDgv(fundAdvisor.Id);
            lblRecordSaved.Visible = true;
        }

        private void SelectFundAdvisorInAdvisorDgv(Guid fundAdvisorId)
        {
            foreach (DataGridViewRow dataRow in dgvAdvisors.Rows)
            {
                if (String.IsNullOrWhiteSpace(dataRow.Cells["Relational_Advisors_FundsId"].Value.ToString()))
                {
                    continue;
                }

                if (new Guid(dataRow.Cells["Relational_Advisors_FundsId"].Value.ToString()) == fundAdvisorId)
                {
                    dgvAdvisors.CurrentCell = dgvAdvisors.Rows[dataRow.Index].Cells["Name"];
                }
            }
        }

        private void LoadAdvisorTypeCbo()
        {
            cboAdvisorType.Items.Clear();

            cboAdvisorType.Items.Add(new ListItem("", ""));

            foreach (StringMap stringMap in StringMap.AssociatedFromColumnAndTable("Relational_Advisors_Funds", "AdvisorType"))
            {
                cboAdvisorType.Items.Add(new ListItem(stringMap.Value, stringMap));
            }
        }

        private void btnDeleteAdvisor_Click(object sender, EventArgs e)
        {
            int index = dgvAdvisors.CurrentRow.Index;
            advisorId = new Guid(dgvAdvisors.Rows[index].Cells["AdvisorId"].Value.ToString());

            if (!String.IsNullOrWhiteSpace(dgvAdvisors.Rows[index].Cells["Relational_Advisors_FundsId"].Value.ToString()))
            {
                Guid fundAdvisorId = new Guid(dgvAdvisors.Rows[index].Cells["Relational_Advisors_FundsId"].Value.ToString());
                FundAdvisor fundAdvisor = new FundAdvisor(fundAdvisorId);

                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete the selected Advisor from the fund?", "Attention", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    fundAdvisor.DeleteRecordFromDatabase();
                }

                LoadAdvisorsDgv();
            }
        }
	}
}
