namespace ISP.Presentation.Forms
{
	partial class frmFund
	{
		
		private System.ComponentModel.IContainer components = null;
		
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabFundTasks = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.button18 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.cboTaskViews = new System.Windows.Forms.ComboBox();
            this.tabFundCharts = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabFundPerformance = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartSummary = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblOutperform5Yr = new System.Windows.Forms.Label();
            this.lblCorrel5Yr = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblTurnoverRatio = new System.Windows.Forms.Label();
            this.lblNumberHolding = new System.Windows.Forms.Label();
            this.lblExpenseRatio = new System.Windows.Forms.Label();
            this.lblTrailingReturnM1 = new System.Windows.Forms.Label();
            this.lblTopTenHolding = new System.Windows.Forms.Label();
            this.lblTrailingReturnYTD = new System.Windows.Forms.Label();
            this.lblHeaderTrailingReturnM1 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblIndexRetY10 = new System.Windows.Forms.Label();
            this.lblFundRetY10 = new System.Windows.Forms.Label();
            this.lblIndexRetY9 = new System.Windows.Forms.Label();
            this.lblFundRetY9 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblIndexRetY8 = new System.Windows.Forms.Label();
            this.lblFundRetY8 = new System.Windows.Forms.Label();
            this.lblIndexRetY7 = new System.Windows.Forms.Label();
            this.lblFundRetY7 = new System.Windows.Forms.Label();
            this.lblIndexRetY6 = new System.Windows.Forms.Label();
            this.lblFundRetY6 = new System.Windows.Forms.Label();
            this.lblIndexRetY5 = new System.Windows.Forms.Label();
            this.lblFundRetY5 = new System.Windows.Forms.Label();
            this.lblIndexRet = new System.Windows.Forms.Label();
            this.lblIndexRetY4 = new System.Windows.Forms.Label();
            this.lblIndexRetY3 = new System.Windows.Forms.Label();
            this.lblFundRet = new System.Windows.Forms.Label();
            this.lblIndexRetY2 = new System.Windows.Forms.Label();
            this.lblFundRetY4 = new System.Windows.Forms.Label();
            this.lblIndexRetY1 = new System.Windows.Forms.Label();
            this.lblFundRetY3 = new System.Windows.Forms.Label();
            this.lblIndexRetYTD = new System.Windows.Forms.Label();
            this.lblFundRetY2 = new System.Windows.Forms.Label();
            this.lblFundRetY1 = new System.Windows.Forms.Label();
            this.lblFundRetYTD = new System.Windows.Forms.Label();
            this.lblOutperform3Yr = new System.Windows.Forms.Label();
            this.lblCorrel3Yr = new System.Windows.Forms.Label();
            this.lblPbYield = new System.Windows.Forms.Label();
            this.lblPeYield = new System.Windows.Forms.Label();
            this.lblAvgEffDuration = new System.Windows.Forms.Label();
            this.lblFundAssets = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lblRetY10 = new System.Windows.Forms.Label();
            this.lblRetY9 = new System.Windows.Forms.Label();
            this.lblRetY8 = new System.Windows.Forms.Label();
            this.lblRetY7 = new System.Windows.Forms.Label();
            this.lblRetY6 = new System.Windows.Forms.Label();
            this.lblRetY5 = new System.Windows.Forms.Label();
            this.lblRetY4 = new System.Windows.Forms.Label();
            this.lblRetY3 = new System.Windows.Forms.Label();
            this.lblRetY2 = new System.Windows.Forms.Label();
            this.lblRetY1 = new System.Windows.Forms.Label();
            this.lblRetYTD = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInceptionDate = new System.Windows.Forms.Label();
            this.lblInvestmentId = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.tabFundPlans = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.dgvPlans = new System.Windows.Forms.DataGridView();
            this.tabFundAdvisors = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.cboAdvView = new System.Windows.Forms.ComboBox();
            this.btnOpenAdv = new System.Windows.Forms.Button();
            this.lblSelectedAdv = new System.Windows.Forms.Label();
            this.dgvAdvisors = new System.Windows.Forms.DataGridView();
            this.tabFundDetails = new System.Windows.Forms.TabPage();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnRefreshReturns = new System.Windows.Forms.Button();
            this.dgvFundDetail = new System.Windows.Forms.DataGridView();
            this.tabManagers = new System.Windows.Forms.TabPage();
            this.pnlManagerBody = new System.Windows.Forms.Panel();
            this.lblManagerViews = new System.Windows.Forms.Label();
            this.cboManagerViews = new System.Windows.Forms.ComboBox();
            this.btnOpenManager = new System.Windows.Forms.Button();
            this.lblSelectedManager = new System.Windows.Forms.Label();
            this.dgvManagers = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblManagers = new System.Windows.Forms.Label();
            this.lblAdvisors = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.lblMenuDetails = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.lblFundName = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboBench = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.tabFundTasks.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.tabFundCharts.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabFundPerformance.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSummary)).BeginInit();
            this.panel7.SuspendLayout();
            this.tabFundPlans.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).BeginInit();
            this.tabFundAdvisors.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvisors)).BeginInit();
            this.tabFundDetails.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFundDetail)).BeginInit();
            this.tabManagers.SuspendLayout();
            this.pnlManagerBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagers)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFundTasks
            // 
            this.tabFundTasks.BackColor = System.Drawing.Color.Transparent;
            this.tabFundTasks.Controls.Add(this.panel6);
            this.tabFundTasks.Location = new System.Drawing.Point(4, 22);
            this.tabFundTasks.Margin = new System.Windows.Forms.Padding(2);
            this.tabFundTasks.Name = "tabFundTasks";
            this.tabFundTasks.Padding = new System.Windows.Forms.Padding(2);
            this.tabFundTasks.Size = new System.Drawing.Size(800, 568);
            this.tabFundTasks.TabIndex = 1;
            this.tabFundTasks.Text = "Tasks";
            this.tabFundTasks.UseVisualStyleBackColor = true;
            this.tabFundTasks.Enter += new System.EventHandler(this.tabControl1SelectedIndexChanged);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.AutoScroll = true;
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.button9);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label37);
            this.panel6.Controls.Add(this.button18);
            this.panel6.Controls.Add(this.button25);
            this.panel6.Controls.Add(this.button23);
            this.panel6.Controls.Add(this.button6);
            this.panel6.Controls.Add(this.button19);
            this.panel6.Controls.Add(this.dgvTasks);
            this.panel6.Controls.Add(this.cboTaskViews);
            this.panel6.Location = new System.Drawing.Point(2, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(798, 564);
            this.panel6.TabIndex = 10;
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Gadugi", 12F);
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.Location = new System.Drawing.Point(707, 522);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(78, 32);
            this.button9.TabIndex = 77;
            this.button9.Text = "Open";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.openTask);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Gadugi", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(8, 522);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(446, 32);
            this.label3.TabIndex = 76;
            this.label3.Text = "Select a task";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label37.Location = new System.Drawing.Point(10, 10);
            this.label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(41, 16);
            this.label37.TabIndex = 75;
            this.label37.Text = "Views";
            // 
            // button18
            // 
            this.button18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.ForeColor = System.Drawing.Color.Black;
            this.button18.Location = new System.Drawing.Point(544, 5);
            this.button18.Margin = new System.Windows.Forms.Padding(2);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(78, 26);
            this.button18.TabIndex = 69;
            this.button18.Text = "New";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.ButtonNewTaskClick);
            // 
            // button25
            // 
            this.button25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button25.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button25.Enabled = false;
            this.button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button25.Font = new System.Drawing.Font("Gadugi", 8.25F);
            this.button25.Location = new System.Drawing.Point(441, 5);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(76, 26);
            this.button25.TabIndex = 71;
            this.button25.Text = "Open Acct";
            this.button25.UseVisualStyleBackColor = false;
            // 
            // button23
            // 
            this.button23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button23.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button23.Enabled = false;
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button23.Font = new System.Drawing.Font("Gadugi", 8.25F);
            this.button23.Location = new System.Drawing.Point(358, 5);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(78, 26);
            this.button23.TabIndex = 72;
            this.button23.Text = "Open Mgr";
            this.button23.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Gadugi", 8.25F);
            this.button6.Location = new System.Drawing.Point(709, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(76, 26);
            this.button6.TabIndex = 74;
            this.button6.Text = "Complete";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button19
            // 
            this.button19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button19.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.ForeColor = System.Drawing.Color.Black;
            this.button19.Location = new System.Drawing.Point(626, 5);
            this.button19.Margin = new System.Windows.Forms.Padding(2);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(78, 26);
            this.button19.TabIndex = 70;
            this.button19.Text = "Delete";
            this.button19.UseVisualStyleBackColor = false;
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToDeleteRows = false;
            this.dgvTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTasks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("High Tower Text", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Gadugi", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTasks.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTasks.Location = new System.Drawing.Point(8, 36);
            this.dgvTasks.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTasks.MultiSelect = false;
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTasks.RowHeadersVisible = false;
            this.dgvTasks.RowTemplate.Height = 24;
            this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTasks.Size = new System.Drawing.Size(777, 482);
            this.dgvTasks.TabIndex = 1;
            // 
            // cboTaskViews
            // 
            this.cboTaskViews.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTaskViews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTaskViews.Items.AddRange(new object[] {
            "My Open Associated Tasks",
            "My Closed Associated Tasks",
            "All Open Associated Tasks",
            "All Closed Associated Tasks"});
            this.cboTaskViews.Location = new System.Drawing.Point(55, 7);
            this.cboTaskViews.Margin = new System.Windows.Forms.Padding(2);
            this.cboTaskViews.Name = "cboTaskViews";
            this.cboTaskViews.Size = new System.Drawing.Size(246, 21);
            this.cboTaskViews.TabIndex = 0;
            this.cboTaskViews.SelectedIndexChanged += new System.EventHandler(this.cboTaskViews_SelectedIndexChanged);
            // 
            // tabFundCharts
            // 
            this.tabFundCharts.BackColor = System.Drawing.Color.Transparent;
            this.tabFundCharts.Controls.Add(this.panel5);
            this.tabFundCharts.Location = new System.Drawing.Point(4, 22);
            this.tabFundCharts.Margin = new System.Windows.Forms.Padding(2);
            this.tabFundCharts.Name = "tabFundCharts";
            this.tabFundCharts.Padding = new System.Windows.Forms.Padding(2);
            this.tabFundCharts.Size = new System.Drawing.Size(800, 568);
            this.tabFundCharts.TabIndex = 0;
            this.tabFundCharts.Text = "Charts";
            this.tabFundCharts.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.AutoScroll = true;
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.comboBox3);
            this.panel5.Controls.Add(this.comboBox1);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.chartMain);
            this.panel5.Location = new System.Drawing.Point(2, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(798, 564);
            this.panel5.TabIndex = 1;
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(537, 8);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(247, 21);
            this.comboBox3.TabIndex = 55;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "12 Month Rolling Return",
            "36 Month Rolling Return",
            "36 Month Rolling Standard Deviation",
            "Annualized Returns",
            "Annual Returns",
            "Standard Deviation"});
            this.comboBox1.Location = new System.Drawing.Point(98, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(365, 21);
            this.comboBox1.TabIndex = 55;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(475, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 54;
            this.label2.Text = "Month";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(7, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 19);
            this.label5.TabIndex = 54;
            this.label5.Text = "Chart Type";
            // 
            // chartMain
            // 
            this.chartMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chartMain.BorderlineColor = System.Drawing.Color.Black;
            this.chartMain.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.IsMarksNextToAxis = false;
            chartArea1.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.Name = "ChartArea1";
            this.chartMain.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chartMain.Legends.Add(legend1);
            this.chartMain.Location = new System.Drawing.Point(10, 35);
            this.chartMain.Name = "chartMain";
            this.chartMain.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartMain.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.DarkBlue,
        System.Drawing.Color.DarkRed};
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsValueShownAsLabel = true;
            series1.Label = "#VAL{.0}";
            series1.Legend = "Legend1";
            series1.Name = "Investment";
            series1.SmartLabelStyle.CalloutStyle = System.Windows.Forms.DataVisualization.Charting.LabelCalloutStyle.None;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Benchmark";
            this.chartMain.Series.Add(series1);
            this.chartMain.Series.Add(series2);
            this.chartMain.Size = new System.Drawing.Size(774, 519);
            this.chartMain.TabIndex = 50;
            this.chartMain.Text = "chart1";
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabFundPerformance);
            this.tabMain.Controls.Add(this.tabFundCharts);
            this.tabMain.Controls.Add(this.tabFundTasks);
            this.tabMain.Controls.Add(this.tabFundPlans);
            this.tabMain.Controls.Add(this.tabFundAdvisors);
            this.tabMain.Controls.Add(this.tabFundDetails);
            this.tabMain.Controls.Add(this.tabManagers);
            this.tabMain.Location = new System.Drawing.Point(-6, 63);
            this.tabMain.Margin = new System.Windows.Forms.Padding(2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(808, 594);
            this.tabMain.TabIndex = 35;
            // 
            // tabFundPerformance
            // 
            this.tabFundPerformance.Controls.Add(this.panel1);
            this.tabFundPerformance.Location = new System.Drawing.Point(4, 22);
            this.tabFundPerformance.Margin = new System.Windows.Forms.Padding(2);
            this.tabFundPerformance.Name = "tabFundPerformance";
            this.tabFundPerformance.Size = new System.Drawing.Size(800, 568);
            this.tabFundPerformance.TabIndex = 2;
            this.tabFundPerformance.Text = "Performance";
            this.tabFundPerformance.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chartSummary);
            this.panel1.Controls.Add(this.lblOutperform5Yr);
            this.panel1.Controls.Add(this.lblCorrel5Yr);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.lblIndexRetY10);
            this.panel1.Controls.Add(this.lblFundRetY10);
            this.panel1.Controls.Add(this.lblIndexRetY9);
            this.panel1.Controls.Add(this.lblFundRetY9);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.lblIndexRetY8);
            this.panel1.Controls.Add(this.lblFundRetY8);
            this.panel1.Controls.Add(this.lblIndexRetY7);
            this.panel1.Controls.Add(this.lblFundRetY7);
            this.panel1.Controls.Add(this.lblIndexRetY6);
            this.panel1.Controls.Add(this.lblFundRetY6);
            this.panel1.Controls.Add(this.lblIndexRetY5);
            this.panel1.Controls.Add(this.lblFundRetY5);
            this.panel1.Controls.Add(this.lblIndexRet);
            this.panel1.Controls.Add(this.lblIndexRetY4);
            this.panel1.Controls.Add(this.lblIndexRetY3);
            this.panel1.Controls.Add(this.lblFundRet);
            this.panel1.Controls.Add(this.lblIndexRetY2);
            this.panel1.Controls.Add(this.lblFundRetY4);
            this.panel1.Controls.Add(this.lblIndexRetY1);
            this.panel1.Controls.Add(this.lblFundRetY3);
            this.panel1.Controls.Add(this.lblIndexRetYTD);
            this.panel1.Controls.Add(this.lblFundRetY2);
            this.panel1.Controls.Add(this.lblFundRetY1);
            this.panel1.Controls.Add(this.lblFundRetYTD);
            this.panel1.Controls.Add(this.lblOutperform3Yr);
            this.panel1.Controls.Add(this.lblCorrel3Yr);
            this.panel1.Controls.Add(this.lblPbYield);
            this.panel1.Controls.Add(this.lblPeYield);
            this.panel1.Controls.Add(this.lblAvgEffDuration);
            this.panel1.Controls.Add(this.lblFundAssets);
            this.panel1.Controls.Add(this.label33);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.lblRetY10);
            this.panel1.Controls.Add(this.lblRetY9);
            this.panel1.Controls.Add(this.lblRetY8);
            this.panel1.Controls.Add(this.lblRetY7);
            this.panel1.Controls.Add(this.lblRetY6);
            this.panel1.Controls.Add(this.lblRetY5);
            this.panel1.Controls.Add(this.lblRetY4);
            this.panel1.Controls.Add(this.lblRetY3);
            this.panel1.Controls.Add(this.lblRetY2);
            this.panel1.Controls.Add(this.lblRetY1);
            this.panel1.Controls.Add(this.lblRetYTD);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblInceptionDate);
            this.panel1.Controls.Add(this.lblInvestmentId);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label82);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 564);
            this.panel1.TabIndex = 0;
            // 
            // chartSummary
            // 
            this.chartSummary.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chartSummary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chartSummary.BorderlineColor = System.Drawing.Color.Black;
            this.chartSummary.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal;
            chartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.IsMarksNextToAxis = false;
            chartArea2.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.Name = "ChartArea1";
            this.chartSummary.ChartAreas.Add(chartArea2);
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "Legend1";
            this.chartSummary.Legends.Add(legend2);
            this.chartSummary.Location = new System.Drawing.Point(10, 322);
            this.chartSummary.MinimumSize = new System.Drawing.Size(776, 230);
            this.chartSummary.Name = "chartSummary";
            this.chartSummary.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartSummary.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.DarkBlue,
        System.Drawing.Color.DarkRed};
            series3.ChartArea = "ChartArea1";
            series3.IsValueShownAsLabel = true;
            series3.Label = "#VAL{0.0}";
            series3.Legend = "Legend1";
            series3.Name = "Investment";
            series3.SmartLabelStyle.CalloutStyle = System.Windows.Forms.DataVisualization.Charting.LabelCalloutStyle.None;
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Benchmark";
            this.chartSummary.Series.Add(series3);
            this.chartSummary.Series.Add(series4);
            this.chartSummary.Size = new System.Drawing.Size(776, 230);
            this.chartSummary.TabIndex = 51;
            // 
            // lblOutperform5Yr
            // 
            this.lblOutperform5Yr.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblOutperform5Yr.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutperform5Yr.Location = new System.Drawing.Point(675, 159);
            this.lblOutperform5Yr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOutperform5Yr.Name = "lblOutperform5Yr";
            this.lblOutperform5Yr.Size = new System.Drawing.Size(83, 21);
            this.lblOutperform5Yr.TabIndex = 48;
            this.lblOutperform5Yr.Text = "-";
            this.lblOutperform5Yr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCorrel5Yr
            // 
            this.lblCorrel5Yr.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCorrel5Yr.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrel5Yr.Location = new System.Drawing.Point(675, 138);
            this.lblCorrel5Yr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCorrel5Yr.Name = "lblCorrel5Yr";
            this.lblCorrel5Yr.Size = new System.Drawing.Size(83, 22);
            this.lblCorrel5Yr.TabIndex = 49;
            this.lblCorrel5Yr.Text = "-";
            this.lblCorrel5Yr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblTurnoverRatio);
            this.panel7.Controls.Add(this.lblNumberHolding);
            this.panel7.Controls.Add(this.lblExpenseRatio);
            this.panel7.Controls.Add(this.lblTrailingReturnM1);
            this.panel7.Controls.Add(this.lblTopTenHolding);
            this.panel7.Controls.Add(this.lblTrailingReturnYTD);
            this.panel7.Controls.Add(this.lblHeaderTrailingReturnM1);
            this.panel7.Controls.Add(this.label20);
            this.panel7.Controls.Add(this.label21);
            this.panel7.Controls.Add(this.label13);
            this.panel7.Controls.Add(this.label19);
            this.panel7.Controls.Add(this.label17);
            this.panel7.Location = new System.Drawing.Point(-1, 27);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(798, 82);
            this.panel7.TabIndex = 47;
            // 
            // lblTurnoverRatio
            // 
            this.lblTurnoverRatio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTurnoverRatio.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnoverRatio.Location = new System.Drawing.Point(638, 31);
            this.lblTurnoverRatio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTurnoverRatio.Name = "lblTurnoverRatio";
            this.lblTurnoverRatio.Size = new System.Drawing.Size(120, 37);
            this.lblTurnoverRatio.TabIndex = 43;
            this.lblTurnoverRatio.Text = "-";
            // 
            // lblNumberHolding
            // 
            this.lblNumberHolding.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNumberHolding.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberHolding.Location = new System.Drawing.Point(519, 31);
            this.lblNumberHolding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumberHolding.Name = "lblNumberHolding";
            this.lblNumberHolding.Size = new System.Drawing.Size(120, 37);
            this.lblNumberHolding.TabIndex = 43;
            this.lblNumberHolding.Text = "-";
            // 
            // lblExpenseRatio
            // 
            this.lblExpenseRatio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblExpenseRatio.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpenseRatio.Location = new System.Drawing.Point(400, 31);
            this.lblExpenseRatio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExpenseRatio.Name = "lblExpenseRatio";
            this.lblExpenseRatio.Size = new System.Drawing.Size(120, 37);
            this.lblExpenseRatio.TabIndex = 43;
            this.lblExpenseRatio.Text = "-";
            // 
            // lblTrailingReturnM1
            // 
            this.lblTrailingReturnM1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTrailingReturnM1.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrailingReturnM1.Location = new System.Drawing.Point(162, 31);
            this.lblTrailingReturnM1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTrailingReturnM1.Name = "lblTrailingReturnM1";
            this.lblTrailingReturnM1.Size = new System.Drawing.Size(120, 37);
            this.lblTrailingReturnM1.TabIndex = 43;
            this.lblTrailingReturnM1.Text = "-";
            // 
            // lblTopTenHolding
            // 
            this.lblTopTenHolding.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTopTenHolding.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopTenHolding.Location = new System.Drawing.Point(281, 31);
            this.lblTopTenHolding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTopTenHolding.Name = "lblTopTenHolding";
            this.lblTopTenHolding.Size = new System.Drawing.Size(120, 37);
            this.lblTopTenHolding.TabIndex = 43;
            this.lblTopTenHolding.Text = "-";
            // 
            // lblTrailingReturnYTD
            // 
            this.lblTrailingReturnYTD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTrailingReturnYTD.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrailingReturnYTD.Location = new System.Drawing.Point(43, 31);
            this.lblTrailingReturnYTD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTrailingReturnYTD.Name = "lblTrailingReturnYTD";
            this.lblTrailingReturnYTD.Size = new System.Drawing.Size(120, 37);
            this.lblTrailingReturnYTD.TabIndex = 43;
            this.lblTrailingReturnYTD.Text = "-";
            // 
            // lblHeaderTrailingReturnM1
            // 
            this.lblHeaderTrailingReturnM1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeaderTrailingReturnM1.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTrailingReturnM1.Location = new System.Drawing.Point(162, 7);
            this.lblHeaderTrailingReturnM1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeaderTrailingReturnM1.Name = "lblHeaderTrailingReturnM1";
            this.lblHeaderTrailingReturnM1.Size = new System.Drawing.Size(120, 24);
            this.lblHeaderTrailingReturnM1.TabIndex = 42;
            this.lblHeaderTrailingReturnM1.Text = "Trailing Return M1";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label20.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(400, 7);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(120, 24);
            this.label20.TabIndex = 42;
            this.label20.Text = "Gross Expense Ratio";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label21.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(281, 7);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 24);
            this.label21.TabIndex = 42;
            this.label21.Text = "Top 10 Holding";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(638, 7);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 24);
            this.label13.TabIndex = 42;
            this.label13.Text = "Turnover Ratio";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label19.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(519, 7);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(120, 24);
            this.label19.TabIndex = 42;
            this.label19.Text = "Number of Holdings";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label17.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(43, 7);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 24);
            this.label17.TabIndex = 42;
            this.label17.Text = "Trailing Return YTD";
            // 
            // lblIndexRetY10
            // 
            this.lblIndexRetY10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIndexRetY10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndexRetY10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIndexRetY10.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndexRetY10.Location = new System.Drawing.Point(713, 266);
            this.lblIndexRetY10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIndexRetY10.Name = "lblIndexRetY10";
            this.lblIndexRetY10.Size = new System.Drawing.Size(63, 22);
            this.lblIndexRetY10.TabIndex = 46;
            this.lblIndexRetY10.Text = "-";
            this.lblIndexRetY10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFundRetY10
            // 
            this.lblFundRetY10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFundRetY10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFundRetY10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFundRetY10.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFundRetY10.Location = new System.Drawing.Point(713, 245);
            this.lblFundRetY10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundRetY10.Name = "lblFundRetY10";
            this.lblFundRetY10.Size = new System.Drawing.Size(63, 22);
            this.lblFundRetY10.TabIndex = 46;
            this.lblFundRetY10.Text = "-";
            this.lblFundRetY10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndexRetY9
            // 
            this.lblIndexRetY9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIndexRetY9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndexRetY9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIndexRetY9.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndexRetY9.Location = new System.Drawing.Point(651, 266);
            this.lblIndexRetY9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIndexRetY9.Name = "lblIndexRetY9";
            this.lblIndexRetY9.Size = new System.Drawing.Size(63, 22);
            this.lblIndexRetY9.TabIndex = 46;
            this.lblIndexRetY9.Text = "-";
            this.lblIndexRetY9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFundRetY9
            // 
            this.lblFundRetY9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFundRetY9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFundRetY9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFundRetY9.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFundRetY9.Location = new System.Drawing.Point(651, 245);
            this.lblFundRetY9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundRetY9.Name = "lblFundRetY9";
            this.lblFundRetY9.Size = new System.Drawing.Size(63, 22);
            this.lblFundRetY9.TabIndex = 46;
            this.lblFundRetY9.Text = "-";
            this.lblFundRetY9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label22.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(10, 295);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(208, 24);
            this.label22.TabIndex = 42;
            this.label22.Text = "Annualized Returns";
            // 
            // lblIndexRetY8
            // 
            this.lblIndexRetY8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIndexRetY8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndexRetY8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIndexRetY8.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndexRetY8.Location = new System.Drawing.Point(589, 266);
            this.lblIndexRetY8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIndexRetY8.Name = "lblIndexRetY8";
            this.lblIndexRetY8.Size = new System.Drawing.Size(63, 22);
            this.lblIndexRetY8.TabIndex = 46;
            this.lblIndexRetY8.Text = "-";
            this.lblIndexRetY8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFundRetY8
            // 
            this.lblFundRetY8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFundRetY8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFundRetY8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFundRetY8.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFundRetY8.Location = new System.Drawing.Point(589, 245);
            this.lblFundRetY8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundRetY8.Name = "lblFundRetY8";
            this.lblFundRetY8.Size = new System.Drawing.Size(63, 22);
            this.lblFundRetY8.TabIndex = 46;
            this.lblFundRetY8.Text = "-";
            this.lblFundRetY8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndexRetY7
            // 
            this.lblIndexRetY7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIndexRetY7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndexRetY7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIndexRetY7.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndexRetY7.Location = new System.Drawing.Point(527, 266);
            this.lblIndexRetY7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIndexRetY7.Name = "lblIndexRetY7";
            this.lblIndexRetY7.Size = new System.Drawing.Size(63, 22);
            this.lblIndexRetY7.TabIndex = 46;
            this.lblIndexRetY7.Text = "-";
            this.lblIndexRetY7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFundRetY7
            // 
            this.lblFundRetY7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFundRetY7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFundRetY7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFundRetY7.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFundRetY7.Location = new System.Drawing.Point(527, 245);
            this.lblFundRetY7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundRetY7.Name = "lblFundRetY7";
            this.lblFundRetY7.Size = new System.Drawing.Size(63, 22);
            this.lblFundRetY7.TabIndex = 46;
            this.lblFundRetY7.Text = "-";
            this.lblFundRetY7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndexRetY6
            // 
            this.lblIndexRetY6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIndexRetY6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndexRetY6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIndexRetY6.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndexRetY6.Location = new System.Drawing.Point(465, 266);
            this.lblIndexRetY6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIndexRetY6.Name = "lblIndexRetY6";
            this.lblIndexRetY6.Size = new System.Drawing.Size(63, 22);
            this.lblIndexRetY6.TabIndex = 46;
            this.lblIndexRetY6.Text = "-";
            this.lblIndexRetY6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFundRetY6
            // 
            this.lblFundRetY6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFundRetY6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFundRetY6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFundRetY6.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFundRetY6.Location = new System.Drawing.Point(465, 245);
            this.lblFundRetY6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundRetY6.Name = "lblFundRetY6";
            this.lblFundRetY6.Size = new System.Drawing.Size(63, 22);
            this.lblFundRetY6.TabIndex = 46;
            this.lblFundRetY6.Text = "-";
            this.lblFundRetY6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndexRetY5
            // 
            this.lblIndexRetY5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIndexRetY5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndexRetY5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIndexRetY5.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndexRetY5.Location = new System.Drawing.Point(403, 266);
            this.lblIndexRetY5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIndexRetY5.Name = "lblIndexRetY5";
            this.lblIndexRetY5.Size = new System.Drawing.Size(63, 22);
            this.lblIndexRetY5.TabIndex = 46;
            this.lblIndexRetY5.Text = "-";
            this.lblIndexRetY5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFundRetY5
            // 
            this.lblFundRetY5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFundRetY5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFundRetY5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFundRetY5.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFundRetY5.Location = new System.Drawing.Point(403, 245);
            this.lblFundRetY5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundRetY5.Name = "lblFundRetY5";
            this.lblFundRetY5.Size = new System.Drawing.Size(63, 22);
            this.lblFundRetY5.TabIndex = 46;
            this.lblFundRetY5.Text = "-";
            this.lblFundRetY5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndexRet
            // 
            this.lblIndexRet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIndexRet.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndexRet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIndexRet.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndexRet.Location = new System.Drawing.Point(15, 266);
            this.lblIndexRet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIndexRet.Name = "lblIndexRet";
            this.lblIndexRet.Size = new System.Drawing.Size(79, 22);
            this.lblIndexRet.TabIndex = 42;
            this.lblIndexRet.Text = "Benchmark";
            // 
            // lblIndexRetY4
            // 
            this.lblIndexRetY4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIndexRetY4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndexRetY4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIndexRetY4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndexRetY4.Location = new System.Drawing.Point(341, 266);
            this.lblIndexRetY4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIndexRetY4.Name = "lblIndexRetY4";
            this.lblIndexRetY4.Size = new System.Drawing.Size(63, 22);
            this.lblIndexRetY4.TabIndex = 46;
            this.lblIndexRetY4.Text = "-";
            this.lblIndexRetY4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndexRetY3
            // 
            this.lblIndexRetY3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIndexRetY3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndexRetY3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIndexRetY3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndexRetY3.Location = new System.Drawing.Point(279, 266);
            this.lblIndexRetY3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIndexRetY3.Name = "lblIndexRetY3";
            this.lblIndexRetY3.Size = new System.Drawing.Size(63, 22);
            this.lblIndexRetY3.TabIndex = 46;
            this.lblIndexRetY3.Text = "-";
            this.lblIndexRetY3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFundRet
            // 
            this.lblFundRet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFundRet.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFundRet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFundRet.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFundRet.Location = new System.Drawing.Point(15, 245);
            this.lblFundRet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundRet.Name = "lblFundRet";
            this.lblFundRet.Size = new System.Drawing.Size(79, 22);
            this.lblFundRet.TabIndex = 42;
            this.lblFundRet.Text = "Fund";
            // 
            // lblIndexRetY2
            // 
            this.lblIndexRetY2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIndexRetY2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndexRetY2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIndexRetY2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndexRetY2.Location = new System.Drawing.Point(217, 266);
            this.lblIndexRetY2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIndexRetY2.Name = "lblIndexRetY2";
            this.lblIndexRetY2.Size = new System.Drawing.Size(63, 22);
            this.lblIndexRetY2.TabIndex = 46;
            this.lblIndexRetY2.Text = "-";
            this.lblIndexRetY2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFundRetY4
            // 
            this.lblFundRetY4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFundRetY4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFundRetY4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFundRetY4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFundRetY4.Location = new System.Drawing.Point(341, 245);
            this.lblFundRetY4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundRetY4.Name = "lblFundRetY4";
            this.lblFundRetY4.Size = new System.Drawing.Size(63, 22);
            this.lblFundRetY4.TabIndex = 46;
            this.lblFundRetY4.Text = "-";
            this.lblFundRetY4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndexRetY1
            // 
            this.lblIndexRetY1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIndexRetY1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndexRetY1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIndexRetY1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndexRetY1.Location = new System.Drawing.Point(155, 266);
            this.lblIndexRetY1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIndexRetY1.Name = "lblIndexRetY1";
            this.lblIndexRetY1.Size = new System.Drawing.Size(63, 22);
            this.lblIndexRetY1.TabIndex = 46;
            this.lblIndexRetY1.Text = "-";
            this.lblIndexRetY1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFundRetY3
            // 
            this.lblFundRetY3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFundRetY3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFundRetY3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFundRetY3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFundRetY3.Location = new System.Drawing.Point(279, 245);
            this.lblFundRetY3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundRetY3.Name = "lblFundRetY3";
            this.lblFundRetY3.Size = new System.Drawing.Size(63, 22);
            this.lblFundRetY3.TabIndex = 46;
            this.lblFundRetY3.Text = "-";
            this.lblFundRetY3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndexRetYTD
            // 
            this.lblIndexRetYTD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIndexRetYTD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndexRetYTD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIndexRetYTD.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndexRetYTD.Location = new System.Drawing.Point(93, 266);
            this.lblIndexRetYTD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIndexRetYTD.Name = "lblIndexRetYTD";
            this.lblIndexRetYTD.Size = new System.Drawing.Size(63, 22);
            this.lblIndexRetYTD.TabIndex = 46;
            this.lblIndexRetYTD.Text = "-";
            this.lblIndexRetYTD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFundRetY2
            // 
            this.lblFundRetY2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFundRetY2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFundRetY2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFundRetY2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFundRetY2.Location = new System.Drawing.Point(217, 245);
            this.lblFundRetY2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundRetY2.Name = "lblFundRetY2";
            this.lblFundRetY2.Size = new System.Drawing.Size(63, 22);
            this.lblFundRetY2.TabIndex = 46;
            this.lblFundRetY2.Text = "-";
            this.lblFundRetY2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFundRetY1
            // 
            this.lblFundRetY1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFundRetY1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFundRetY1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFundRetY1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFundRetY1.Location = new System.Drawing.Point(155, 245);
            this.lblFundRetY1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundRetY1.Name = "lblFundRetY1";
            this.lblFundRetY1.Size = new System.Drawing.Size(63, 22);
            this.lblFundRetY1.TabIndex = 46;
            this.lblFundRetY1.Text = "-";
            this.lblFundRetY1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFundRetYTD
            // 
            this.lblFundRetYTD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFundRetYTD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFundRetYTD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFundRetYTD.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFundRetYTD.Location = new System.Drawing.Point(93, 245);
            this.lblFundRetYTD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundRetYTD.Name = "lblFundRetYTD";
            this.lblFundRetYTD.Size = new System.Drawing.Size(63, 22);
            this.lblFundRetYTD.TabIndex = 46;
            this.lblFundRetYTD.Text = "-";
            this.lblFundRetYTD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOutperform3Yr
            // 
            this.lblOutperform3Yr.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblOutperform3Yr.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutperform3Yr.Location = new System.Drawing.Point(593, 159);
            this.lblOutperform3Yr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOutperform3Yr.Name = "lblOutperform3Yr";
            this.lblOutperform3Yr.Size = new System.Drawing.Size(83, 21);
            this.lblOutperform3Yr.TabIndex = 46;
            this.lblOutperform3Yr.Text = "-";
            this.lblOutperform3Yr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCorrel3Yr
            // 
            this.lblCorrel3Yr.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCorrel3Yr.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrel3Yr.Location = new System.Drawing.Point(593, 138);
            this.lblCorrel3Yr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCorrel3Yr.Name = "lblCorrel3Yr";
            this.lblCorrel3Yr.Size = new System.Drawing.Size(83, 22);
            this.lblCorrel3Yr.TabIndex = 46;
            this.lblCorrel3Yr.Text = "-";
            this.lblCorrel3Yr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPbYield
            // 
            this.lblPbYield.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPbYield.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPbYield.Location = new System.Drawing.Point(345, 159);
            this.lblPbYield.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPbYield.Name = "lblPbYield";
            this.lblPbYield.Size = new System.Drawing.Size(120, 22);
            this.lblPbYield.TabIndex = 46;
            this.lblPbYield.Text = "-";
            // 
            // lblPeYield
            // 
            this.lblPeYield.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPeYield.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeYield.Location = new System.Drawing.Point(345, 138);
            this.lblPeYield.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPeYield.Name = "lblPeYield";
            this.lblPeYield.Size = new System.Drawing.Size(120, 22);
            this.lblPeYield.TabIndex = 46;
            this.lblPeYield.Text = "-";
            // 
            // lblAvgEffDuration
            // 
            this.lblAvgEffDuration.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAvgEffDuration.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgEffDuration.Location = new System.Drawing.Point(345, 117);
            this.lblAvgEffDuration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAvgEffDuration.Name = "lblAvgEffDuration";
            this.lblAvgEffDuration.Size = new System.Drawing.Size(120, 22);
            this.lblAvgEffDuration.TabIndex = 46;
            this.lblAvgEffDuration.Text = "-";
            // 
            // lblFundAssets
            // 
            this.lblFundAssets.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFundAssets.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFundAssets.Location = new System.Drawing.Point(115, 159);
            this.lblFundAssets.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundAssets.Name = "lblFundAssets";
            this.lblFundAssets.Size = new System.Drawing.Size(113, 22);
            this.lblFundAssets.TabIndex = 46;
            this.lblFundAssets.Text = "-";
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label33.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(469, 159);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(120, 21);
            this.label33.TabIndex = 44;
            this.label33.Text = "Outperformance:";
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label31.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(675, 117);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(83, 22);
            this.label31.TabIndex = 44;
            this.label31.Text = "5 YR";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRetY10
            // 
            this.lblRetY10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRetY10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRetY10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRetY10.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetY10.ForeColor = System.Drawing.Color.Black;
            this.lblRetY10.Location = new System.Drawing.Point(713, 224);
            this.lblRetY10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRetY10.Name = "lblRetY10";
            this.lblRetY10.Size = new System.Drawing.Size(63, 22);
            this.lblRetY10.TabIndex = 44;
            this.lblRetY10.Text = "10 YR";
            this.lblRetY10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRetY9
            // 
            this.lblRetY9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRetY9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRetY9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRetY9.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetY9.ForeColor = System.Drawing.Color.Black;
            this.lblRetY9.Location = new System.Drawing.Point(651, 224);
            this.lblRetY9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRetY9.Name = "lblRetY9";
            this.lblRetY9.Size = new System.Drawing.Size(63, 22);
            this.lblRetY9.TabIndex = 44;
            this.lblRetY9.Text = "9 YR";
            this.lblRetY9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRetY8
            // 
            this.lblRetY8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRetY8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRetY8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRetY8.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetY8.ForeColor = System.Drawing.Color.Black;
            this.lblRetY8.Location = new System.Drawing.Point(589, 224);
            this.lblRetY8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRetY8.Name = "lblRetY8";
            this.lblRetY8.Size = new System.Drawing.Size(63, 22);
            this.lblRetY8.TabIndex = 44;
            this.lblRetY8.Text = "8 YR";
            this.lblRetY8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRetY7
            // 
            this.lblRetY7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRetY7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRetY7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRetY7.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetY7.ForeColor = System.Drawing.Color.Black;
            this.lblRetY7.Location = new System.Drawing.Point(527, 224);
            this.lblRetY7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRetY7.Name = "lblRetY7";
            this.lblRetY7.Size = new System.Drawing.Size(63, 22);
            this.lblRetY7.TabIndex = 44;
            this.lblRetY7.Text = "7 YR";
            this.lblRetY7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRetY6
            // 
            this.lblRetY6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRetY6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRetY6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRetY6.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetY6.ForeColor = System.Drawing.Color.Black;
            this.lblRetY6.Location = new System.Drawing.Point(465, 224);
            this.lblRetY6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRetY6.Name = "lblRetY6";
            this.lblRetY6.Size = new System.Drawing.Size(63, 22);
            this.lblRetY6.TabIndex = 44;
            this.lblRetY6.Text = "6 YR";
            this.lblRetY6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRetY5
            // 
            this.lblRetY5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRetY5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRetY5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRetY5.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetY5.ForeColor = System.Drawing.Color.Black;
            this.lblRetY5.Location = new System.Drawing.Point(403, 224);
            this.lblRetY5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRetY5.Name = "lblRetY5";
            this.lblRetY5.Size = new System.Drawing.Size(63, 22);
            this.lblRetY5.TabIndex = 44;
            this.lblRetY5.Text = "5 YR";
            this.lblRetY5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRetY4
            // 
            this.lblRetY4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRetY4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRetY4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRetY4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetY4.ForeColor = System.Drawing.Color.Black;
            this.lblRetY4.Location = new System.Drawing.Point(341, 224);
            this.lblRetY4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRetY4.Name = "lblRetY4";
            this.lblRetY4.Size = new System.Drawing.Size(63, 22);
            this.lblRetY4.TabIndex = 44;
            this.lblRetY4.Text = "4 YR";
            this.lblRetY4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRetY3
            // 
            this.lblRetY3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRetY3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRetY3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRetY3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetY3.ForeColor = System.Drawing.Color.Black;
            this.lblRetY3.Location = new System.Drawing.Point(279, 224);
            this.lblRetY3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRetY3.Name = "lblRetY3";
            this.lblRetY3.Size = new System.Drawing.Size(63, 22);
            this.lblRetY3.TabIndex = 44;
            this.lblRetY3.Text = "3 YR";
            this.lblRetY3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRetY2
            // 
            this.lblRetY2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRetY2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRetY2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRetY2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetY2.ForeColor = System.Drawing.Color.Black;
            this.lblRetY2.Location = new System.Drawing.Point(217, 224);
            this.lblRetY2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRetY2.Name = "lblRetY2";
            this.lblRetY2.Size = new System.Drawing.Size(63, 22);
            this.lblRetY2.TabIndex = 44;
            this.lblRetY2.Text = "2 YR";
            this.lblRetY2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRetY1
            // 
            this.lblRetY1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRetY1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRetY1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRetY1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetY1.ForeColor = System.Drawing.Color.Black;
            this.lblRetY1.Location = new System.Drawing.Point(155, 224);
            this.lblRetY1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRetY1.Name = "lblRetY1";
            this.lblRetY1.Size = new System.Drawing.Size(63, 22);
            this.lblRetY1.TabIndex = 44;
            this.lblRetY1.Text = "1 YR";
            this.lblRetY1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRetYTD
            // 
            this.lblRetYTD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRetYTD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRetYTD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRetYTD.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetYTD.ForeColor = System.Drawing.Color.Black;
            this.lblRetYTD.Location = new System.Drawing.Point(93, 224);
            this.lblRetYTD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRetYTD.Name = "lblRetYTD";
            this.lblRetYTD.Size = new System.Drawing.Size(63, 22);
            this.lblRetYTD.TabIndex = 44;
            this.lblRetYTD.Text = "YTD";
            this.lblRetYTD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(593, 117);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 22);
            this.label16.TabIndex = 44;
            this.label16.Text = "3 YR";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label32.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(469, 138);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(120, 22);
            this.label32.TabIndex = 44;
            this.label32.Text = "Correlation:";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(232, 159);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 22);
            this.label15.TabIndex = 44;
            this.label15.Text = "P/B Yield:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(232, 138);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 22);
            this.label10.TabIndex = 44;
            this.label10.Text = "P/E Yield:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(232, 117);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 22);
            this.label8.TabIndex = 44;
            this.label8.Text = "Avg Eff Duration:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 159);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 22);
            this.label7.TabIndex = 44;
            this.label7.Text = "Fund Assets:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 138);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 22);
            this.label6.TabIndex = 44;
            this.label6.Text = "Inception Date:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 22);
            this.label4.TabIndex = 44;
            this.label4.Text = "Investment ID:";
            // 
            // lblInceptionDate
            // 
            this.lblInceptionDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInceptionDate.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInceptionDate.Location = new System.Drawing.Point(115, 138);
            this.lblInceptionDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInceptionDate.Name = "lblInceptionDate";
            this.lblInceptionDate.Size = new System.Drawing.Size(113, 22);
            this.lblInceptionDate.TabIndex = 43;
            this.lblInceptionDate.Text = "-";
            // 
            // lblInvestmentId
            // 
            this.lblInvestmentId.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInvestmentId.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvestmentId.Location = new System.Drawing.Point(115, 117);
            this.lblInvestmentId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInvestmentId.Name = "lblInvestmentId";
            this.lblInvestmentId.Size = new System.Drawing.Size(113, 22);
            this.lblInvestmentId.TabIndex = 43;
            this.lblInvestmentId.Text = "-";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Firebrick;
            this.label12.Location = new System.Drawing.Point(100, 4);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(684, 19);
            this.label12.TabIndex = 0;
            this.label12.Text = "| As of April 2015";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Firebrick;
            this.label11.Location = new System.Drawing.Point(16, 3);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "Summary";
            // 
            // label82
            // 
            this.label82.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label82.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.Location = new System.Drawing.Point(10, 194);
            this.label82.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(178, 24);
            this.label82.TabIndex = 42;
            this.label82.Text = "Annual Returns";
            // 
            // tabFundPlans
            // 
            this.tabFundPlans.Controls.Add(this.panel9);
            this.tabFundPlans.Location = new System.Drawing.Point(4, 22);
            this.tabFundPlans.Name = "tabFundPlans";
            this.tabFundPlans.Padding = new System.Windows.Forms.Padding(3);
            this.tabFundPlans.Size = new System.Drawing.Size(800, 568);
            this.tabFundPlans.TabIndex = 3;
            this.tabFundPlans.Text = "Plans";
            this.tabFundPlans.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.Gainsboro;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.button2);
            this.panel9.Controls.Add(this.button3);
            this.panel9.Controls.Add(this.label42);
            this.panel9.Controls.Add(this.comboBox2);
            this.panel9.Controls.Add(this.button1);
            this.panel9.Controls.Add(this.label41);
            this.panel9.Controls.Add(this.dgvPlans);
            this.panel9.Location = new System.Drawing.Point(2, -8);
            this.panel9.Margin = new System.Windows.Forms.Padding(2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(798, 580);
            this.panel9.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(544, 13);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 26);
            this.button2.TabIndex = 82;
            this.button2.Text = "New";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(626, 13);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 26);
            this.button3.TabIndex = 83;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.Transparent;
            this.label42.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label42.Location = new System.Drawing.Point(10, 18);
            this.label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(41, 16);
            this.label42.TabIndex = 81;
            this.label42.Text = "Views";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.Items.AddRange(new object[] {
            "Active Associated Plans"});
            this.comboBox2.Location = new System.Drawing.Point(55, 15);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(246, 21);
            this.comboBox2.TabIndex = 80;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Gadugi", 12F);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(707, 530);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 32);
            this.button1.TabIndex = 79;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label41
            // 
            this.label41.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label41.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label41.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label41.Font = new System.Drawing.Font("Gadugi", 12F);
            this.label41.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label41.Location = new System.Drawing.Point(8, 530);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(446, 32);
            this.label41.TabIndex = 78;
            this.label41.Text = "Select a plan";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvPlans
            // 
            this.dgvPlans.AllowUserToAddRows = false;
            this.dgvPlans.AllowUserToDeleteRows = false;
            this.dgvPlans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlans.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("High Tower Text", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlans.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPlans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Gadugi", 7.8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlans.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPlans.Location = new System.Drawing.Point(8, 44);
            this.dgvPlans.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPlans.MultiSelect = false;
            this.dgvPlans.Name = "dgvPlans";
            this.dgvPlans.ReadOnly = true;
            this.dgvPlans.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPlans.RowHeadersVisible = false;
            this.dgvPlans.RowTemplate.Height = 24;
            this.dgvPlans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPlans.Size = new System.Drawing.Size(777, 482);
            this.dgvPlans.TabIndex = 2;
            this.dgvPlans.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            this.dgvPlans.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellEnter);
            // 
            // tabFundAdvisors
            // 
            this.tabFundAdvisors.Controls.Add(this.panel10);
            this.tabFundAdvisors.Location = new System.Drawing.Point(4, 22);
            this.tabFundAdvisors.Name = "tabFundAdvisors";
            this.tabFundAdvisors.Padding = new System.Windows.Forms.Padding(3);
            this.tabFundAdvisors.Size = new System.Drawing.Size(800, 568);
            this.tabFundAdvisors.TabIndex = 4;
            this.tabFundAdvisors.Text = "Advisors";
            this.tabFundAdvisors.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.Color.Gainsboro;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.button4);
            this.panel10.Controls.Add(this.button5);
            this.panel10.Controls.Add(this.label43);
            this.panel10.Controls.Add(this.cboAdvView);
            this.panel10.Controls.Add(this.btnOpenAdv);
            this.panel10.Controls.Add(this.lblSelectedAdv);
            this.panel10.Controls.Add(this.dgvAdvisors);
            this.panel10.Location = new System.Drawing.Point(2, -8);
            this.panel10.Margin = new System.Windows.Forms.Padding(2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(798, 580);
            this.panel10.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(544, 13);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 26);
            this.button4.TabIndex = 82;
            this.button4.Text = "New";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(626, 13);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(78, 26);
            this.button5.TabIndex = 83;
            this.button5.Text = "Delete";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label43.Location = new System.Drawing.Point(10, 18);
            this.label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(41, 16);
            this.label43.TabIndex = 81;
            this.label43.Text = "Views";
            // 
            // cboAdvView
            // 
            this.cboAdvView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAdvView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAdvView.Items.AddRange(new object[] {
            "Associated Advisors"});
            this.cboAdvView.Location = new System.Drawing.Point(55, 15);
            this.cboAdvView.Margin = new System.Windows.Forms.Padding(2);
            this.cboAdvView.Name = "cboAdvView";
            this.cboAdvView.Size = new System.Drawing.Size(246, 21);
            this.cboAdvView.TabIndex = 80;
            this.cboAdvView.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // btnOpenAdv
            // 
            this.btnOpenAdv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenAdv.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOpenAdv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenAdv.Font = new System.Drawing.Font("Gadugi", 12F);
            this.btnOpenAdv.ForeColor = System.Drawing.Color.Black;
            this.btnOpenAdv.Location = new System.Drawing.Point(707, 530);
            this.btnOpenAdv.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenAdv.Name = "btnOpenAdv";
            this.btnOpenAdv.Size = new System.Drawing.Size(78, 32);
            this.btnOpenAdv.TabIndex = 79;
            this.btnOpenAdv.Text = "Open";
            this.btnOpenAdv.UseVisualStyleBackColor = false;
            this.btnOpenAdv.Click += new System.EventHandler(this.btnOpenAdv_Click);
            // 
            // lblSelectedAdv
            // 
            this.lblSelectedAdv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectedAdv.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSelectedAdv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelectedAdv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSelectedAdv.Font = new System.Drawing.Font("Gadugi", 12F);
            this.lblSelectedAdv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectedAdv.Location = new System.Drawing.Point(8, 530);
            this.lblSelectedAdv.Name = "lblSelectedAdv";
            this.lblSelectedAdv.Size = new System.Drawing.Size(446, 32);
            this.lblSelectedAdv.TabIndex = 78;
            this.lblSelectedAdv.Text = "Select an advisor";
            this.lblSelectedAdv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvAdvisors
            // 
            this.dgvAdvisors.AllowUserToAddRows = false;
            this.dgvAdvisors.AllowUserToDeleteRows = false;
            this.dgvAdvisors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAdvisors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdvisors.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("High Tower Text", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAdvisors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAdvisors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Gadugi", 7.8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAdvisors.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAdvisors.Location = new System.Drawing.Point(8, 44);
            this.dgvAdvisors.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAdvisors.MultiSelect = false;
            this.dgvAdvisors.Name = "dgvAdvisors";
            this.dgvAdvisors.ReadOnly = true;
            this.dgvAdvisors.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAdvisors.RowHeadersVisible = false;
            this.dgvAdvisors.RowTemplate.Height = 24;
            this.dgvAdvisors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAdvisors.Size = new System.Drawing.Size(777, 482);
            this.dgvAdvisors.TabIndex = 2;
            this.dgvAdvisors.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdvisors_CellDoubleClick);
            this.dgvAdvisors.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdvisors_CellEnter);
            // 
            // tabFundDetails
            // 
            this.tabFundDetails.Controls.Add(this.panel11);
            this.tabFundDetails.Location = new System.Drawing.Point(4, 22);
            this.tabFundDetails.Name = "tabFundDetails";
            this.tabFundDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabFundDetails.Size = new System.Drawing.Size(800, 568);
            this.tabFundDetails.TabIndex = 5;
            this.tabFundDetails.Text = "Returns";
            this.tabFundDetails.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.BackColor = System.Drawing.Color.Gainsboro;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.btnRefreshReturns);
            this.panel11.Controls.Add(this.dgvFundDetail);
            this.panel11.Location = new System.Drawing.Point(2, -8);
            this.panel11.Margin = new System.Windows.Forms.Padding(2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(798, 576);
            this.panel11.TabIndex = 3;
            // 
            // btnRefreshReturns
            // 
            this.btnRefreshReturns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshReturns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRefreshReturns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshReturns.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshReturns.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshReturns.Location = new System.Drawing.Point(706, 13);
            this.btnRefreshReturns.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshReturns.Name = "btnRefreshReturns";
            this.btnRefreshReturns.Size = new System.Drawing.Size(78, 26);
            this.btnRefreshReturns.TabIndex = 83;
            this.btnRefreshReturns.Text = "Refresh";
            this.btnRefreshReturns.UseVisualStyleBackColor = false;
            this.btnRefreshReturns.Click += new System.EventHandler(this.btnRefreshReturns_Click);
            // 
            // dgvFundDetail
            // 
            this.dgvFundDetail.AllowUserToAddRows = false;
            this.dgvFundDetail.AllowUserToDeleteRows = false;
            this.dgvFundDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFundDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFundDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("High Tower Text", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFundDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvFundDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Gadugi", 7.8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFundDetail.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvFundDetail.Location = new System.Drawing.Point(8, 44);
            this.dgvFundDetail.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFundDetail.MultiSelect = false;
            this.dgvFundDetail.Name = "dgvFundDetail";
            this.dgvFundDetail.ReadOnly = true;
            this.dgvFundDetail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvFundDetail.RowHeadersVisible = false;
            this.dgvFundDetail.RowTemplate.Height = 24;
            this.dgvFundDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvFundDetail.Size = new System.Drawing.Size(777, 510);
            this.dgvFundDetail.TabIndex = 2;
            // 
            // tabManagers
            // 
            this.tabManagers.Controls.Add(this.pnlManagerBody);
            this.tabManagers.Location = new System.Drawing.Point(4, 22);
            this.tabManagers.Name = "tabManagers";
            this.tabManagers.Padding = new System.Windows.Forms.Padding(3);
            this.tabManagers.Size = new System.Drawing.Size(800, 568);
            this.tabManagers.TabIndex = 6;
            this.tabManagers.Text = "Managers";
            this.tabManagers.UseVisualStyleBackColor = true;
            // 
            // pnlManagerBody
            // 
            this.pnlManagerBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlManagerBody.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlManagerBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlManagerBody.Controls.Add(this.lblManagerViews);
            this.pnlManagerBody.Controls.Add(this.cboManagerViews);
            this.pnlManagerBody.Controls.Add(this.btnOpenManager);
            this.pnlManagerBody.Controls.Add(this.lblSelectedManager);
            this.pnlManagerBody.Controls.Add(this.dgvManagers);
            this.pnlManagerBody.Location = new System.Drawing.Point(2, -8);
            this.pnlManagerBody.Margin = new System.Windows.Forms.Padding(2);
            this.pnlManagerBody.Name = "pnlManagerBody";
            this.pnlManagerBody.Size = new System.Drawing.Size(798, 580);
            this.pnlManagerBody.TabIndex = 3;
            // 
            // lblManagerViews
            // 
            this.lblManagerViews.AutoSize = true;
            this.lblManagerViews.BackColor = System.Drawing.Color.Transparent;
            this.lblManagerViews.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagerViews.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblManagerViews.Location = new System.Drawing.Point(10, 18);
            this.lblManagerViews.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblManagerViews.Name = "lblManagerViews";
            this.lblManagerViews.Size = new System.Drawing.Size(41, 16);
            this.lblManagerViews.TabIndex = 81;
            this.lblManagerViews.Text = "Views";
            // 
            // cboManagerViews
            // 
            this.cboManagerViews.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManagerViews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboManagerViews.Items.AddRange(new object[] {
            "Associated Managers"});
            this.cboManagerViews.Location = new System.Drawing.Point(55, 15);
            this.cboManagerViews.Margin = new System.Windows.Forms.Padding(2);
            this.cboManagerViews.Name = "cboManagerViews";
            this.cboManagerViews.Size = new System.Drawing.Size(246, 21);
            this.cboManagerViews.TabIndex = 80;
            this.cboManagerViews.SelectedIndexChanged += new System.EventHandler(this.cboManagerViews_SelectedIndexChanged);
            // 
            // btnOpenManager
            // 
            this.btnOpenManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenManager.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOpenManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenManager.Font = new System.Drawing.Font("Gadugi", 12F);
            this.btnOpenManager.ForeColor = System.Drawing.Color.Black;
            this.btnOpenManager.Location = new System.Drawing.Point(707, 530);
            this.btnOpenManager.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenManager.Name = "btnOpenManager";
            this.btnOpenManager.Size = new System.Drawing.Size(78, 32);
            this.btnOpenManager.TabIndex = 79;
            this.btnOpenManager.Text = "Open";
            this.btnOpenManager.UseVisualStyleBackColor = false;
            this.btnOpenManager.Click += new System.EventHandler(this.btnOpenManager_Click);
            // 
            // lblSelectedManager
            // 
            this.lblSelectedManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectedManager.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSelectedManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelectedManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSelectedManager.Font = new System.Drawing.Font("Gadugi", 12F);
            this.lblSelectedManager.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectedManager.Location = new System.Drawing.Point(8, 530);
            this.lblSelectedManager.Name = "lblSelectedManager";
            this.lblSelectedManager.Size = new System.Drawing.Size(446, 32);
            this.lblSelectedManager.TabIndex = 78;
            this.lblSelectedManager.Text = "Select a manager";
            this.lblSelectedManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvManagers
            // 
            this.dgvManagers.AllowUserToAddRows = false;
            this.dgvManagers.AllowUserToDeleteRows = false;
            this.dgvManagers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManagers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvManagers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("High Tower Text", 10F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManagers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvManagers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Gadugi", 7.8F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManagers.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvManagers.Location = new System.Drawing.Point(8, 44);
            this.dgvManagers.Margin = new System.Windows.Forms.Padding(2);
            this.dgvManagers.MultiSelect = false;
            this.dgvManagers.Name = "dgvManagers";
            this.dgvManagers.ReadOnly = true;
            this.dgvManagers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvManagers.RowHeadersVisible = false;
            this.dgvManagers.RowTemplate.Height = 24;
            this.dgvManagers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvManagers.Size = new System.Drawing.Size(777, 482);
            this.dgvManagers.TabIndex = 2;
            this.dgvManagers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManagers_CellDoubleClick);
            this.dgvManagers.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManagers_CellEnter);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label25);
            this.panel4.Location = new System.Drawing.Point(0, 744);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(798, 21);
            this.panel4.TabIndex = 58;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(5, 0);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(576, 16);
            this.label25.TabIndex = 40;
            this.label25.Text = "Ready";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblManagers);
            this.panel3.Controls.Add(this.lblAdvisors);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label49);
            this.panel3.Controls.Add(this.lblMenuDetails);
            this.panel3.Controls.Add(this.label30);
            this.panel3.Controls.Add(this.label46);
            this.panel3.Location = new System.Drawing.Point(0, 692);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(798, 53);
            this.panel3.TabIndex = 59;
            // 
            // lblManagers
            // 
            this.lblManagers.AutoSize = true;
            this.lblManagers.BackColor = System.Drawing.Color.Transparent;
            this.lblManagers.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblManagers.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagers.ForeColor = System.Drawing.Color.Black;
            this.lblManagers.Location = new System.Drawing.Point(506, 15);
            this.lblManagers.Name = "lblManagers";
            this.lblManagers.Size = new System.Drawing.Size(104, 25);
            this.lblManagers.TabIndex = 0;
            this.lblManagers.Text = "Managers";
            this.lblManagers.Click += new System.EventHandler(this.lblManagers_Click);
            this.lblManagers.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.lblManagers.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // lblAdvisors
            // 
            this.lblAdvisors.AutoSize = true;
            this.lblAdvisors.BackColor = System.Drawing.Color.Transparent;
            this.lblAdvisors.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblAdvisors.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvisors.ForeColor = System.Drawing.Color.Black;
            this.lblAdvisors.Location = new System.Drawing.Point(410, 15);
            this.lblAdvisors.Name = "lblAdvisors";
            this.lblAdvisors.Size = new System.Drawing.Size(90, 25);
            this.lblAdvisors.TabIndex = 0;
            this.lblAdvisors.Text = "Advisors";
            this.lblAdvisors.Click += new System.EventHandler(this.lblAdvisors_Click);
            this.lblAdvisors.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.lblAdvisors.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(343, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plans";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.Cursor = System.Windows.Forms.Cursors.Default;
            this.label49.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.Black;
            this.label49.Location = new System.Drawing.Point(275, 15);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(62, 25);
            this.label49.TabIndex = 0;
            this.label49.Text = "Tasks";
            this.label49.Click += new System.EventHandler(this.label49_Click);
            this.label49.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.label49.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // lblMenuDetails
            // 
            this.lblMenuDetails.AutoSize = true;
            this.lblMenuDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblMenuDetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMenuDetails.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuDetails.ForeColor = System.Drawing.Color.Black;
            this.lblMenuDetails.Location = new System.Drawing.Point(117, 15);
            this.lblMenuDetails.Name = "lblMenuDetails";
            this.lblMenuDetails.Size = new System.Drawing.Size(75, 25);
            this.lblMenuDetails.TabIndex = 0;
            this.lblMenuDetails.Text = "Details";
            this.lblMenuDetails.Click += new System.EventHandler(this.lblMenuDetails_Click);
            this.lblMenuDetails.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.lblMenuDetails.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Cursor = System.Windows.Forms.Cursors.Default;
            this.label30.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(198, 15);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(71, 25);
            this.label30.TabIndex = 0;
            this.label30.Text = "Charts";
            this.label30.Click += new System.EventHandler(this.label47_Click);
            this.label30.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.label30.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.Cursor = System.Windows.Forms.Cursors.Default;
            this.label46.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.Black;
            this.label46.Location = new System.Drawing.Point(12, 15);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(99, 25);
            this.label46.TabIndex = 0;
            this.label46.Text = "Summary";
            this.label46.Click += new System.EventHandler(this.label46_Click);
            this.label46.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.label46.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // lblFundName
            // 
            this.lblFundName.AutoSize = true;
            this.lblFundName.Font = new System.Drawing.Font("High Tower Text", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFundName.ForeColor = System.Drawing.Color.Black;
            this.lblFundName.Location = new System.Drawing.Point(2, 7);
            this.lblFundName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundName.Name = "lblFundName";
            this.lblFundName.Size = new System.Drawing.Size(203, 45);
            this.lblFundName.TabIndex = 0;
            this.lblFundName.Text = "Fund Name";
            this.lblFundName.DoubleClick += new System.EventHandler(this.MaximizeForm);
            // 
            // panel16
            // 
            this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel16.BackColor = System.Drawing.Color.SteelBlue;
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.label26);
            this.panel16.Controls.Add(this.label38);
            this.panel16.Location = new System.Drawing.Point(0, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(798, 27);
            this.panel16.TabIndex = 61;
            this.panel16.DoubleClick += new System.EventHandler(this.MaximizeForm);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(4, 5);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(217, 16);
            this.label26.TabIndex = 23;
            this.label26.Text = "Investment Services Program - Fund";
            this.label26.DoubleClick += new System.EventHandler(this.MaximizeForm);
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label38.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.White;
            this.label38.Location = new System.Drawing.Point(770, 1);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(25, 25);
            this.label38.TabIndex = 22;
            this.label38.Text = "x";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label38.Click += new System.EventHandler(this.label38_Click);
            this.label38.MouseEnter += new System.EventHandler(this.CloseFormButton_MouseEnter);
            this.label38.MouseLeave += new System.EventHandler(this.CloseFormButton_MouseLeave);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.lblFundName);
            this.panel8.Location = new System.Drawing.Point(0, 26);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(798, 61);
            this.panel8.TabIndex = 62;
            this.panel8.DoubleClick += new System.EventHandler(this.MaximizeForm);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cboBench);
            this.panel2.Controls.Add(this.label40);
            this.panel2.Location = new System.Drawing.Point(0, 646);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 47);
            this.panel2.TabIndex = 63;
            // 
            // cboBench
            // 
            this.cboBench.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBench.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBench.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBench.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBench.FormattingEnabled = true;
            this.cboBench.ItemHeight = 13;
            this.cboBench.Location = new System.Drawing.Point(199, 12);
            this.cboBench.MinimumSize = new System.Drawing.Size(272, 0);
            this.cboBench.Name = "cboBench";
            this.cboBench.Size = new System.Drawing.Size(585, 21);
            this.cboBench.TabIndex = 56;
            this.cboBench.SelectedIndexChanged += new System.EventHandler(this.cboBench_SelectedIndexChanged);
            // 
            // label40
            // 
            this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label40.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(7, 12);
            this.label40.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(181, 18);
            this.label40.TabIndex = 44;
            this.label40.Text = "Compare to Benchmark";
            // 
            // frmFund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(798, 765);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmFund";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fund Detail";
            this.tabFundTasks.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.tabFundCharts.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabFundPerformance.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSummary)).EndInit();
            this.panel7.ResumeLayout(false);
            this.tabFundPlans.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).EndInit();
            this.tabFundAdvisors.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvisors)).EndInit();
            this.tabFundDetails.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFundDetail)).EndInit();
            this.tabManagers.ResumeLayout(false);
            this.pnlManagerBody.ResumeLayout(false);
            this.pnlManagerBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagers)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabFundPerformance;
		private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.ComboBox cboTaskViews;
		private System.Windows.Forms.TabPage tabFundTasks;
		private System.Windows.Forms.TabPage tabFundCharts;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label46;
        public System.Windows.Forms.Label lblFundName;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ComboBox comboBox3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblTurnoverRatio;
        public System.Windows.Forms.Label lblTopTenHolding;
        public System.Windows.Forms.Label lblExpenseRatio;
        public System.Windows.Forms.Label lblNumberHolding;
        public System.Windows.Forms.Label lblTrailingReturnYTD;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblInceptionDate;
        public System.Windows.Forms.Label lblInvestmentId;
        public System.Windows.Forms.Label lblOutperform5Yr;
        public System.Windows.Forms.Label lblCorrel5Yr;
        private System.Windows.Forms.Panel panel7;
        public System.Windows.Forms.Label lblOutperform3Yr;
        public System.Windows.Forms.Label lblCorrel3Yr;
        public System.Windows.Forms.Label lblFundAssets;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.ComboBox cboBench;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TabPage tabFundPlans;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label41;
        public System.Windows.Forms.DataGridView dgvPlans;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TabPage tabFundAdvisors;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.ComboBox cboAdvView;
        public System.Windows.Forms.Button btnOpenAdv;
        private System.Windows.Forms.Label lblSelectedAdv;
        public System.Windows.Forms.DataGridView dgvAdvisors;
        private System.Windows.Forms.Label lblAdvisors;
        public System.Windows.Forms.Label lblFundRetYTD;
        public System.Windows.Forms.Label lblFundRetY7;
        public System.Windows.Forms.Label lblFundRetY6;
        public System.Windows.Forms.Label lblFundRetY5;
        public System.Windows.Forms.Label lblFundRetY4;
        public System.Windows.Forms.Label lblFundRetY3;
        public System.Windows.Forms.Label lblFundRetY2;
        public System.Windows.Forms.Label lblFundRetY1;
        public System.Windows.Forms.Label lblIndexRetY10;
        public System.Windows.Forms.Label lblFundRetY10;
        public System.Windows.Forms.Label lblIndexRetY9;
        public System.Windows.Forms.Label lblFundRetY9;
        private System.Windows.Forms.Label label82;
        public System.Windows.Forms.Label lblIndexRetY8;
        public System.Windows.Forms.Label lblFundRetY8;
        public System.Windows.Forms.Label lblIndexRetY7;
        public System.Windows.Forms.Label lblIndexRetY6;
        public System.Windows.Forms.Label lblIndexRetY5;
        private System.Windows.Forms.Label lblIndexRet;
        public System.Windows.Forms.Label lblIndexRetY4;
        public System.Windows.Forms.Label lblIndexRetY3;
        private System.Windows.Forms.Label lblFundRet;
        public System.Windows.Forms.Label lblIndexRetY2;
        public System.Windows.Forms.Label lblIndexRetY1;
        public System.Windows.Forms.Label lblIndexRetYTD;
        public System.Windows.Forms.Label lblPbYield;
        public System.Windows.Forms.Label lblPeYield;
        public System.Windows.Forms.Label lblAvgEffDuration;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblRetY7;
        public System.Windows.Forms.Label lblRetY6;
        public System.Windows.Forms.Label lblRetY5;
        public System.Windows.Forms.Label lblRetY4;
        public System.Windows.Forms.Label lblRetY3;
        public System.Windows.Forms.Label lblRetY2;
        public System.Windows.Forms.Label lblRetY1;
        public System.Windows.Forms.Label lblRetY10;
        public System.Windows.Forms.Label lblRetY9;
        public System.Windows.Forms.Label lblRetY8;
        public System.Windows.Forms.Label lblRetYTD;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartSummary;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label label26;
        public System.Windows.Forms.Label lblTrailingReturnM1;
        private System.Windows.Forms.Label lblHeaderTrailingReturnM1;
        private System.Windows.Forms.Label lblMenuDetails;
        private System.Windows.Forms.TabPage tabFundDetails;
        private System.Windows.Forms.Panel panel11;
        public System.Windows.Forms.DataGridView dgvFundDetail;
        private System.Windows.Forms.Button btnRefreshReturns;
        private System.Windows.Forms.TabPage tabManagers;
        private System.Windows.Forms.Panel pnlManagerBody;
        private System.Windows.Forms.Label lblManagerViews;
        private System.Windows.Forms.ComboBox cboManagerViews;
        public System.Windows.Forms.Button btnOpenManager;
        private System.Windows.Forms.Label lblSelectedManager;
        public System.Windows.Forms.DataGridView dgvManagers;
        private System.Windows.Forms.Label lblManagers;
	}
}
