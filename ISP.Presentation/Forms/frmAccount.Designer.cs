namespace ISP.Presentation.Forms
{
	partial class frmAccount
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccount));
            this.tabControlClientDetail = new System.Windows.Forms.TabControl();
            this.tabClientSummary = new System.Windows.Forms.TabPage();
            this.pnlSummaryTabHeader = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label42 = new System.Windows.Forms.Label();
            this.txtCustodians = new System.Windows.Forms.RichTextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtRecordKeepers = new System.Windows.Forms.RichTextBox();
            this.lblAddressHeader = new System.Windows.Forms.Label();
            this.lblRelatedEntitiesHeader = new System.Windows.Forms.Label();
            this.lblContactInformationHeader = new System.Windows.Forms.Label();
            this.lblAccountInformationHeader = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtAddressZip = new System.Windows.Forms.RichTextBox();
            this.txtFax = new System.Windows.Forms.RichTextBox();
            this.txtPrimaryContactEmail = new System.Windows.Forms.RichTextBox();
            this.txtPrimaryContactName = new System.Windows.Forms.RichTextBox();
            this.txtPhone = new System.Windows.Forms.RichTextBox();
            this.txtAddressState = new System.Windows.Forms.RichTextBox();
            this.assetvalue = new System.Windows.Forms.RichTextBox();
            this.txtCommitteeMembers = new System.Windows.Forms.RichTextBox();
            this.txtAddressCity = new System.Windows.Forms.RichTextBox();
            this.txtEngagements = new System.Windows.Forms.RichTextBox();
            this.txtAddressLine2 = new System.Windows.Forms.RichTextBox();
            this.txtName = new System.Windows.Forms.RichTextBox();
            this.txtAddressLine1 = new System.Windows.Forms.RichTextBox();
            this.tabClientInvestments = new System.Windows.Forms.TabPage();
            this.pnlInvestmentTabBody = new System.Windows.Forms.Panel();
            this.pnlSelectedPlan = new System.Windows.Forms.Panel();
            this.cboSelectedPlan = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblToFunds = new System.Windows.Forms.Label();
            this.lblToIpsMonitoringCriteria = new System.Windows.Forms.Label();
            this.tabControlInvestments = new System.Windows.Forms.TabControl();
            this.tabFunds = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblTotalPlanValue = new System.Windows.Forms.Label();
            this.cboPlanFundViews = new System.Windows.Forms.ComboBox();
            this.pnlRelationalFundPlanDetails = new System.Windows.Forms.Panel();
            this.btnClearFund = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.lblBenchmarkPrimary = new System.Windows.Forms.Label();
            this.cboIsPerformanceCalculated = new System.Windows.Forms.ComboBox();
            this.lblIsPerformanceCalculated = new System.Windows.Forms.Label();
            this.cboIsMonitored = new System.Windows.Forms.ComboBox();
            this.lblIsMonitored = new System.Windows.Forms.Label();
            this.lblSelectedBenchmarkPrimary = new System.Windows.Forms.Label();
            this.txtOrdinal = new System.Windows.Forms.TextBox();
            this.txtAssetValueAsOf = new System.Windows.Forms.TextBox();
            this.txtAssetValue = new System.Windows.Forms.TextBox();
            this.txtDateRemoved = new System.Windows.Forms.TextBox();
            this.txtDateAdded = new System.Windows.Forms.TextBox();
            this.cboStateCode = new System.Windows.Forms.ComboBox();
            this.cboAnalyst = new System.Windows.Forms.ComboBox();
            this.cboAssetClass = new System.Windows.Forms.ComboBox();
            this.cboBenchMarkSecondary = new System.Windows.Forms.ComboBox();
            this.lblStateCode = new System.Windows.Forms.Label();
            this.lblAnalyst = new System.Windows.Forms.Label();
            this.btnOpenFund = new System.Windows.Forms.Button();
            this.lblOrdinal = new System.Windows.Forms.Label();
            this.btnOpenParHistory = new System.Windows.Forms.Button();
            this.lblAssetValueAsOf = new System.Windows.Forms.Label();
            this.lblAssetValue = new System.Windows.Forms.Label();
            this.lblDateRemoved = new System.Windows.Forms.Label();
            this.lblAssetValueDollarSign = new System.Windows.Forms.Label();
            this.lblAssetClass = new System.Windows.Forms.Label();
            this.lblDateAdded = new System.Windows.Forms.Label();
            this.lblBenchMarkSecondary = new System.Windows.Forms.Label();
            this.lblFundName = new System.Windows.Forms.Label();
            this.lblRecordSaved = new System.Windows.Forms.Label();
            this.lblPlanFundView = new System.Windows.Forms.Label();
            this.btnSortDown = new System.Windows.Forms.Button();
            this.btnSortUp = new System.Windows.Forms.Button();
            this.btnAddFund = new System.Windows.Forms.Button();
            this.dgvFunds = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFundsGroupHeader = new System.Windows.Forms.Label();
            this.btnSaveFund = new System.Windows.Forms.Button();
            this.btnRemoveFund = new System.Windows.Forms.Button();
            this.tabIpsMonitoringCriteria = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlIpsMonitoringCriteria = new System.Windows.Forms.Panel();
            this.txtExpenseRatio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTrackManagers = new System.Windows.Forms.ComboBox();
            this.cboIpsRisk3Yr = new System.Windows.Forms.ComboBox();
            this.cboIpsReturn3Yr = new System.Windows.Forms.ComboBox();
            this.cboIpsReturn1Yr = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblIpsMonitoringCriteriaHeader = new System.Windows.Forms.Label();
            this.btnSaveIpsCriteria = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlInvestmentTabHeader = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.tabClientObservations = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label55 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pnlObservationsTabHeader = new System.Windows.Forms.Panel();
            this.label39 = new System.Windows.Forms.Label();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label49 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label38 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tabControlClientDetail.SuspendLayout();
            this.tabClientSummary.SuspendLayout();
            this.pnlSummaryTabHeader.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabClientInvestments.SuspendLayout();
            this.pnlInvestmentTabBody.SuspendLayout();
            this.pnlSelectedPlan.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabControlInvestments.SuspendLayout();
            this.tabFunds.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pnlRelationalFundPlanDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunds)).BeginInit();
            this.tabIpsMonitoringCriteria.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlIpsMonitoringCriteria.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlInvestmentTabHeader.SuspendLayout();
            this.tabClientObservations.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnlObservationsTabHeader.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel16.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlClientDetail
            // 
            this.tabControlClientDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlClientDetail.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlClientDetail.Controls.Add(this.tabClientSummary);
            this.tabControlClientDetail.Controls.Add(this.tabClientInvestments);
            this.tabControlClientDetail.Controls.Add(this.tabClientObservations);
            this.tabControlClientDetail.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabControlClientDetail.Location = new System.Drawing.Point(-6, 0);
            this.tabControlClientDetail.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlClientDetail.Name = "tabControlClientDetail";
            this.tabControlClientDetail.SelectedIndex = 0;
            this.tabControlClientDetail.Size = new System.Drawing.Size(989, 629);
            this.tabControlClientDetail.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlClientDetail.TabIndex = 37;
            // 
            // tabClientSummary
            // 
            this.tabClientSummary.BackColor = System.Drawing.Color.Gainsboro;
            this.tabClientSummary.Controls.Add(this.pnlSummaryTabHeader);
            this.tabClientSummary.Controls.Add(this.panel2);
            this.tabClientSummary.Location = new System.Drawing.Point(4, 25);
            this.tabClientSummary.Margin = new System.Windows.Forms.Padding(2);
            this.tabClientSummary.Name = "tabClientSummary";
            this.tabClientSummary.Padding = new System.Windows.Forms.Padding(2);
            this.tabClientSummary.Size = new System.Drawing.Size(981, 600);
            this.tabClientSummary.TabIndex = 0;
            this.tabClientSummary.Text = "Summary";
            // 
            // pnlSummaryTabHeader
            // 
            this.pnlSummaryTabHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSummaryTabHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSummaryTabHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummaryTabHeader.Controls.Add(this.label23);
            this.pnlSummaryTabHeader.Controls.Add(this.label56);
            this.pnlSummaryTabHeader.Font = new System.Drawing.Font("High Tower Text", 32F);
            this.pnlSummaryTabHeader.Location = new System.Drawing.Point(2, 0);
            this.pnlSummaryTabHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSummaryTabHeader.Name = "pnlSummaryTabHeader";
            this.pnlSummaryTabHeader.Size = new System.Drawing.Size(968, 49);
            this.pnlSummaryTabHeader.TabIndex = 57;
            this.pnlSummaryTabHeader.DoubleClick += new System.EventHandler(this.MaximizeForm);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("High Tower Text", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(-3, 1);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(270, 44);
            this.label23.TabIndex = 0;
            this.label23.Text = "Company Name";
            this.label23.TextChanged += new System.EventHandler(this.label23_TextChanged);
            this.label23.DoubleClick += new System.EventHandler(this.MaximizeForm);
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.Color.Transparent;
            this.label56.Font = new System.Drawing.Font("Gadugi", 20F);
            this.label56.ForeColor = System.Drawing.Color.Black;
            this.label56.Location = new System.Drawing.Point(8, 46);
            this.label56.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(152, 38);
            this.label56.TabIndex = 40;
            this.label56.Text = "Summary";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label42);
            this.panel2.Controls.Add(this.txtCustodians);
            this.panel2.Controls.Add(this.label41);
            this.panel2.Controls.Add(this.txtRecordKeepers);
            this.panel2.Controls.Add(this.lblAddressHeader);
            this.panel2.Controls.Add(this.lblRelatedEntitiesHeader);
            this.panel2.Controls.Add(this.lblContactInformationHeader);
            this.panel2.Controls.Add(this.lblAccountInformationHeader);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.txtAddressZip);
            this.panel2.Controls.Add(this.txtFax);
            this.panel2.Controls.Add(this.txtPrimaryContactEmail);
            this.panel2.Controls.Add(this.txtPrimaryContactName);
            this.panel2.Controls.Add(this.txtPhone);
            this.panel2.Controls.Add(this.txtAddressState);
            this.panel2.Controls.Add(this.assetvalue);
            this.panel2.Controls.Add(this.txtCommitteeMembers);
            this.panel2.Controls.Add(this.txtAddressCity);
            this.panel2.Controls.Add(this.txtEngagements);
            this.panel2.Controls.Add(this.txtAddressLine2);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.txtAddressLine1);
            this.panel2.Location = new System.Drawing.Point(2, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(968, 545);
            this.panel2.TabIndex = 58;
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Arial", 9F);
            this.label42.Location = new System.Drawing.Point(14, 331);
            this.label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(113, 18);
            this.label42.TabIndex = 56;
            this.label42.Text = "Custodian:";
            // 
            // txtCustodians
            // 
            this.txtCustodians.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustodians.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCustodians.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustodians.Font = new System.Drawing.Font("Arial", 8F);
            this.txtCustodians.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCustodians.Location = new System.Drawing.Point(131, 330);
            this.txtCustodians.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustodians.Multiline = false;
            this.txtCustodians.Name = "txtCustodians";
            this.txtCustodians.ReadOnly = true;
            this.txtCustodians.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtCustodians.Size = new System.Drawing.Size(819, 19);
            this.txtCustodians.TabIndex = 55;
            this.txtCustodians.Text = "";
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Arial", 9F);
            this.label41.Location = new System.Drawing.Point(14, 310);
            this.label41.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(113, 18);
            this.label41.TabIndex = 54;
            this.label41.Text = "Record Keeper:";
            // 
            // txtRecordKeepers
            // 
            this.txtRecordKeepers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecordKeepers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRecordKeepers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecordKeepers.Font = new System.Drawing.Font("Arial", 8F);
            this.txtRecordKeepers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtRecordKeepers.Location = new System.Drawing.Point(131, 309);
            this.txtRecordKeepers.Margin = new System.Windows.Forms.Padding(2);
            this.txtRecordKeepers.Multiline = false;
            this.txtRecordKeepers.Name = "txtRecordKeepers";
            this.txtRecordKeepers.ReadOnly = true;
            this.txtRecordKeepers.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtRecordKeepers.Size = new System.Drawing.Size(819, 19);
            this.txtRecordKeepers.TabIndex = 53;
            this.txtRecordKeepers.Text = "";
            // 
            // lblAddressHeader
            // 
            this.lblAddressHeader.AutoSize = true;
            this.lblAddressHeader.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.lblAddressHeader.Location = new System.Drawing.Point(13, 185);
            this.lblAddressHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddressHeader.Name = "lblAddressHeader";
            this.lblAddressHeader.Size = new System.Drawing.Size(69, 19);
            this.lblAddressHeader.TabIndex = 40;
            this.lblAddressHeader.Text = "Address";
            // 
            // lblRelatedEntitiesHeader
            // 
            this.lblRelatedEntitiesHeader.AutoSize = true;
            this.lblRelatedEntitiesHeader.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelatedEntitiesHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.lblRelatedEntitiesHeader.Location = new System.Drawing.Point(12, 262);
            this.lblRelatedEntitiesHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRelatedEntitiesHeader.Name = "lblRelatedEntitiesHeader";
            this.lblRelatedEntitiesHeader.Size = new System.Drawing.Size(128, 19);
            this.lblRelatedEntitiesHeader.TabIndex = 40;
            this.lblRelatedEntitiesHeader.Text = "Related Entities";
            // 
            // lblContactInformationHeader
            // 
            this.lblContactInformationHeader.AutoSize = true;
            this.lblContactInformationHeader.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactInformationHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.lblContactInformationHeader.Location = new System.Drawing.Point(13, 107);
            this.lblContactInformationHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContactInformationHeader.Name = "lblContactInformationHeader";
            this.lblContactInformationHeader.Size = new System.Drawing.Size(164, 19);
            this.lblContactInformationHeader.TabIndex = 40;
            this.lblContactInformationHeader.Text = "Contact Information";
            // 
            // lblAccountInformationHeader
            // 
            this.lblAccountInformationHeader.AutoSize = true;
            this.lblAccountInformationHeader.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountInformationHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.lblAccountInformationHeader.Location = new System.Drawing.Point(12, 13);
            this.lblAccountInformationHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAccountInformationHeader.Name = "lblAccountInformationHeader";
            this.lblAccountInformationHeader.Size = new System.Drawing.Size(168, 19);
            this.lblAccountInformationHeader.TabIndex = 40;
            this.lblAccountInformationHeader.Text = "Account Information";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 9F);
            this.label11.Location = new System.Drawing.Point(707, 236);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 16);
            this.label11.TabIndex = 52;
            this.label11.Text = "ZIP:";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Arial", 9F);
            this.label13.Location = new System.Drawing.Point(453, 155);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 19);
            this.label13.TabIndex = 52;
            this.label13.Text = "Fax:";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Arial", 9F);
            this.label15.Location = new System.Drawing.Point(452, 134);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 19);
            this.label15.TabIndex = 52;
            this.label15.Text = "Primary Email:";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Arial", 9F);
            this.label12.Location = new System.Drawing.Point(19, 155);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 19);
            this.label12.TabIndex = 52;
            this.label12.Text = "Phone:";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 9F);
            this.label10.Location = new System.Drawing.Point(453, 235);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 19);
            this.label10.TabIndex = 52;
            this.label10.Text = "State:";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 9F);
            this.label9.Location = new System.Drawing.Point(453, 213);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 19);
            this.label9.TabIndex = 52;
            this.label9.Text = "City";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 9F);
            this.label8.Location = new System.Drawing.Point(19, 233);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 19);
            this.label8.TabIndex = 52;
            this.label8.Text = "Line 2:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 9F);
            this.label7.Location = new System.Drawing.Point(19, 211);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 19);
            this.label7.TabIndex = 52;
            this.label7.Text = "Line 1:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.Location = new System.Drawing.Point(19, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 18);
            this.label4.TabIndex = 52;
            this.label4.Text = "Primary Contact:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.Location = new System.Drawing.Point(19, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 18);
            this.label3.TabIndex = 52;
            this.label3.Text = "Asset Value:";
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Arial", 9F);
            this.label21.Location = new System.Drawing.Point(14, 289);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(113, 18);
            this.label21.TabIndex = 52;
            this.label21.Text = "Committee:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(19, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 18);
            this.label2.TabIndex = 52;
            this.label2.Text = "Engagements:";
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Arial", 9F);
            this.label24.Location = new System.Drawing.Point(19, 39);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(113, 18);
            this.label24.TabIndex = 52;
            this.label24.Text = "Account Name:";
            // 
            // txtAddressZip
            // 
            this.txtAddressZip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddressZip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAddressZip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddressZip.Font = new System.Drawing.Font("Arial", 8F);
            this.txtAddressZip.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAddressZip.Location = new System.Drawing.Point(740, 235);
            this.txtAddressZip.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddressZip.Multiline = false;
            this.txtAddressZip.Name = "txtAddressZip";
            this.txtAddressZip.ReadOnly = true;
            this.txtAddressZip.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtAddressZip.Size = new System.Drawing.Size(210, 19);
            this.txtAddressZip.TabIndex = 13;
            this.txtAddressZip.Text = "";
            // 
            // txtFax
            // 
            this.txtFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFax.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFax.Font = new System.Drawing.Font("Arial", 8F);
            this.txtFax.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFax.Location = new System.Drawing.Point(551, 155);
            this.txtFax.Margin = new System.Windows.Forms.Padding(2);
            this.txtFax.Multiline = false;
            this.txtFax.Name = "txtFax";
            this.txtFax.ReadOnly = true;
            this.txtFax.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtFax.Size = new System.Drawing.Size(399, 19);
            this.txtFax.TabIndex = 8;
            this.txtFax.Text = "";
            // 
            // txtPrimaryContactEmail
            // 
            this.txtPrimaryContactEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrimaryContactEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPrimaryContactEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrimaryContactEmail.Font = new System.Drawing.Font("Arial", 8F);
            this.txtPrimaryContactEmail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPrimaryContactEmail.Location = new System.Drawing.Point(551, 134);
            this.txtPrimaryContactEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrimaryContactEmail.Multiline = false;
            this.txtPrimaryContactEmail.Name = "txtPrimaryContactEmail";
            this.txtPrimaryContactEmail.ReadOnly = true;
            this.txtPrimaryContactEmail.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtPrimaryContactEmail.Size = new System.Drawing.Size(399, 19);
            this.txtPrimaryContactEmail.TabIndex = 6;
            this.txtPrimaryContactEmail.Text = "";
            this.txtPrimaryContactEmail.DoubleClick += new System.EventHandler(this.txtPrimaryContactEmail_DoubleClick);
            // 
            // txtPrimaryContactName
            // 
            this.txtPrimaryContactName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPrimaryContactName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrimaryContactName.Font = new System.Drawing.Font("Arial", 8F);
            this.txtPrimaryContactName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPrimaryContactName.Location = new System.Drawing.Point(136, 133);
            this.txtPrimaryContactName.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrimaryContactName.Multiline = false;
            this.txtPrimaryContactName.Name = "txtPrimaryContactName";
            this.txtPrimaryContactName.ReadOnly = true;
            this.txtPrimaryContactName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtPrimaryContactName.Size = new System.Drawing.Size(297, 19);
            this.txtPrimaryContactName.TabIndex = 5;
            this.txtPrimaryContactName.Text = "";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Font = new System.Drawing.Font("Arial", 8F);
            this.txtPhone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPhone.Location = new System.Drawing.Point(136, 154);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhone.Multiline = false;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtPhone.Size = new System.Drawing.Size(297, 19);
            this.txtPhone.TabIndex = 7;
            this.txtPhone.Text = "";
            // 
            // txtAddressState
            // 
            this.txtAddressState.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAddressState.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddressState.Font = new System.Drawing.Font("Arial", 8F);
            this.txtAddressState.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAddressState.Location = new System.Drawing.Point(551, 234);
            this.txtAddressState.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddressState.Multiline = false;
            this.txtAddressState.Name = "txtAddressState";
            this.txtAddressState.ReadOnly = true;
            this.txtAddressState.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtAddressState.Size = new System.Drawing.Size(152, 19);
            this.txtAddressState.TabIndex = 12;
            this.txtAddressState.Text = "";
            // 
            // assetvalue
            // 
            this.assetvalue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.assetvalue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.assetvalue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.assetvalue.Font = new System.Drawing.Font("Arial", 8F);
            this.assetvalue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.assetvalue.Location = new System.Drawing.Point(136, 59);
            this.assetvalue.Margin = new System.Windows.Forms.Padding(2);
            this.assetvalue.Multiline = false;
            this.assetvalue.Name = "assetvalue";
            this.assetvalue.ReadOnly = true;
            this.assetvalue.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.assetvalue.Size = new System.Drawing.Size(814, 19);
            this.assetvalue.TabIndex = 2;
            this.assetvalue.Text = "";
            // 
            // txtCommitteeMembers
            // 
            this.txtCommitteeMembers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommitteeMembers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCommitteeMembers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCommitteeMembers.Font = new System.Drawing.Font("Arial", 8F);
            this.txtCommitteeMembers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCommitteeMembers.Location = new System.Drawing.Point(131, 288);
            this.txtCommitteeMembers.Margin = new System.Windows.Forms.Padding(2);
            this.txtCommitteeMembers.Multiline = false;
            this.txtCommitteeMembers.Name = "txtCommitteeMembers";
            this.txtCommitteeMembers.ReadOnly = true;
            this.txtCommitteeMembers.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtCommitteeMembers.Size = new System.Drawing.Size(819, 19);
            this.txtCommitteeMembers.TabIndex = 4;
            this.txtCommitteeMembers.Text = "";
            // 
            // txtAddressCity
            // 
            this.txtAddressCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddressCity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAddressCity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddressCity.Font = new System.Drawing.Font("Arial", 8F);
            this.txtAddressCity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAddressCity.Location = new System.Drawing.Point(551, 213);
            this.txtAddressCity.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddressCity.Multiline = false;
            this.txtAddressCity.Name = "txtAddressCity";
            this.txtAddressCity.ReadOnly = true;
            this.txtAddressCity.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtAddressCity.Size = new System.Drawing.Size(399, 19);
            this.txtAddressCity.TabIndex = 10;
            this.txtAddressCity.Text = "";
            // 
            // txtEngagements
            // 
            this.txtEngagements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEngagements.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEngagements.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEngagements.Font = new System.Drawing.Font("Arial", 8F);
            this.txtEngagements.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEngagements.Location = new System.Drawing.Point(136, 80);
            this.txtEngagements.Margin = new System.Windows.Forms.Padding(2);
            this.txtEngagements.Multiline = false;
            this.txtEngagements.Name = "txtEngagements";
            this.txtEngagements.ReadOnly = true;
            this.txtEngagements.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtEngagements.Size = new System.Drawing.Size(814, 19);
            this.txtEngagements.TabIndex = 3;
            this.txtEngagements.Text = "";
            // 
            // txtAddressLine2
            // 
            this.txtAddressLine2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAddressLine2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddressLine2.Font = new System.Drawing.Font("Arial", 8F);
            this.txtAddressLine2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAddressLine2.Location = new System.Drawing.Point(136, 231);
            this.txtAddressLine2.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddressLine2.Multiline = false;
            this.txtAddressLine2.Name = "txtAddressLine2";
            this.txtAddressLine2.ReadOnly = true;
            this.txtAddressLine2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtAddressLine2.Size = new System.Drawing.Size(297, 19);
            this.txtAddressLine2.TabIndex = 11;
            this.txtAddressLine2.Text = "";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Arial", 8F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(136, 38);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtName.Size = new System.Drawing.Size(814, 19);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "";
            // 
            // txtAddressLine1
            // 
            this.txtAddressLine1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAddressLine1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddressLine1.Font = new System.Drawing.Font("Arial", 8F);
            this.txtAddressLine1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAddressLine1.Location = new System.Drawing.Point(136, 210);
            this.txtAddressLine1.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddressLine1.Multiline = false;
            this.txtAddressLine1.Name = "txtAddressLine1";
            this.txtAddressLine1.ReadOnly = true;
            this.txtAddressLine1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtAddressLine1.Size = new System.Drawing.Size(297, 19);
            this.txtAddressLine1.TabIndex = 9;
            this.txtAddressLine1.Text = "";
            // 
            // tabClientInvestments
            // 
            this.tabClientInvestments.BackColor = System.Drawing.Color.LightGray;
            this.tabClientInvestments.Controls.Add(this.pnlInvestmentTabBody);
            this.tabClientInvestments.Controls.Add(this.panel5);
            this.tabClientInvestments.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabClientInvestments.Location = new System.Drawing.Point(4, 25);
            this.tabClientInvestments.Margin = new System.Windows.Forms.Padding(2);
            this.tabClientInvestments.Name = "tabClientInvestments";
            this.tabClientInvestments.Size = new System.Drawing.Size(981, 600);
            this.tabClientInvestments.TabIndex = 2;
            this.tabClientInvestments.Text = "Investments";
            // 
            // pnlInvestmentTabBody
            // 
            this.pnlInvestmentTabBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInvestmentTabBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.pnlInvestmentTabBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInvestmentTabBody.Controls.Add(this.pnlSelectedPlan);
            this.pnlInvestmentTabBody.Controls.Add(this.panel7);
            this.pnlInvestmentTabBody.Controls.Add(this.tabControlInvestments);
            this.pnlInvestmentTabBody.Location = new System.Drawing.Point(2, 48);
            this.pnlInvestmentTabBody.Name = "pnlInvestmentTabBody";
            this.pnlInvestmentTabBody.Size = new System.Drawing.Size(968, 543);
            this.pnlInvestmentTabBody.TabIndex = 63;
            // 
            // pnlSelectedPlan
            // 
            this.pnlSelectedPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSelectedPlan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(56)))), ((int)(((byte)(60)))));
            this.pnlSelectedPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectedPlan.Controls.Add(this.cboSelectedPlan);
            this.pnlSelectedPlan.Controls.Add(this.label40);
            this.pnlSelectedPlan.Location = new System.Drawing.Point(-1, 495);
            this.pnlSelectedPlan.Name = "pnlSelectedPlan";
            this.pnlSelectedPlan.Size = new System.Drawing.Size(968, 47);
            this.pnlSelectedPlan.TabIndex = 71;
            // 
            // cboSelectedPlan
            // 
            this.cboSelectedPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSelectedPlan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSelectedPlan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSelectedPlan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboSelectedPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectedPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSelectedPlan.FormattingEnabled = true;
            this.cboSelectedPlan.ItemHeight = 13;
            this.cboSelectedPlan.Location = new System.Drawing.Point(122, 12);
            this.cboSelectedPlan.MinimumSize = new System.Drawing.Size(272, 0);
            this.cboSelectedPlan.Name = "cboSelectedPlan";
            this.cboSelectedPlan.Size = new System.Drawing.Size(832, 21);
            this.cboSelectedPlan.TabIndex = 56;
            this.cboSelectedPlan.SelectedIndexChanged += new System.EventHandler(this.cboSelectedPlan_SelectedIndexChanged);
            // 
            // label40
            // 
            this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label40.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.White;
            this.label40.Location = new System.Drawing.Point(7, 12);
            this.label40.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(115, 18);
            this.label40.TabIndex = 44;
            this.label40.Text = "Selected Plan:";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.panel7.Controls.Add(this.lblToFunds);
            this.panel7.Controls.Add(this.lblToIpsMonitoringCriteria);
            this.panel7.Font = new System.Drawing.Font("High Tower Text", 32F);
            this.panel7.Location = new System.Drawing.Point(-1, -1);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(968, 21);
            this.panel7.TabIndex = 79;
            // 
            // lblToFunds
            // 
            this.lblToFunds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToFunds.AutoSize = true;
            this.lblToFunds.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblToFunds.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToFunds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(56)))), ((int)(((byte)(60)))));
            this.lblToFunds.Location = new System.Drawing.Point(829, 1);
            this.lblToFunds.Name = "lblToFunds";
            this.lblToFunds.Size = new System.Drawing.Size(127, 19);
            this.lblToFunds.TabIndex = 1;
            this.lblToFunds.Text = "◀ back to Funds";
            this.lblToFunds.Visible = false;
            this.lblToFunds.Click += new System.EventHandler(this.lblToFunds_Click);
            this.lblToFunds.MouseEnter += new System.EventHandler(this.lblToIpsMonitoringCriteria_MouseEnter);
            this.lblToFunds.MouseLeave += new System.EventHandler(this.lblToIpsMonitoringCriteria_MouseLeave);
            // 
            // lblToIpsMonitoringCriteria
            // 
            this.lblToIpsMonitoringCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToIpsMonitoringCriteria.AutoSize = true;
            this.lblToIpsMonitoringCriteria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblToIpsMonitoringCriteria.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToIpsMonitoringCriteria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(56)))), ((int)(((byte)(60)))));
            this.lblToIpsMonitoringCriteria.Location = new System.Drawing.Point(739, 1);
            this.lblToIpsMonitoringCriteria.Name = "lblToIpsMonitoringCriteria";
            this.lblToIpsMonitoringCriteria.Size = new System.Drawing.Size(232, 19);
            this.lblToIpsMonitoringCriteria.TabIndex = 1;
            this.lblToIpsMonitoringCriteria.Text = "to Plan Details / IPS Criteria ▶";
            this.lblToIpsMonitoringCriteria.Click += new System.EventHandler(this.lblToIpsMonitoringCriteria_Click);
            this.lblToIpsMonitoringCriteria.MouseEnter += new System.EventHandler(this.lblToIpsMonitoringCriteria_MouseEnter);
            this.lblToIpsMonitoringCriteria.MouseLeave += new System.EventHandler(this.lblToIpsMonitoringCriteria_MouseLeave);
            // 
            // tabControlInvestments
            // 
            this.tabControlInvestments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlInvestments.Controls.Add(this.tabFunds);
            this.tabControlInvestments.Controls.Add(this.tabIpsMonitoringCriteria);
            this.tabControlInvestments.Location = new System.Drawing.Point(-7, -2);
            this.tabControlInvestments.Name = "tabControlInvestments";
            this.tabControlInvestments.SelectedIndex = 0;
            this.tabControlInvestments.Size = new System.Drawing.Size(978, 502);
            this.tabControlInvestments.TabIndex = 78;
            // 
            // tabFunds
            // 
            this.tabFunds.Controls.Add(this.panel6);
            this.tabFunds.Location = new System.Drawing.Point(4, 22);
            this.tabFunds.Name = "tabFunds";
            this.tabFunds.Padding = new System.Windows.Forms.Padding(3);
            this.tabFunds.Size = new System.Drawing.Size(970, 476);
            this.tabFunds.TabIndex = 1;
            this.tabFunds.Text = "Funds";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lblTotalPlanValue);
            this.panel6.Controls.Add(this.cboPlanFundViews);
            this.panel6.Controls.Add(this.pnlRelationalFundPlanDetails);
            this.panel6.Controls.Add(this.lblRecordSaved);
            this.panel6.Controls.Add(this.lblPlanFundView);
            this.panel6.Controls.Add(this.btnSortDown);
            this.panel6.Controls.Add(this.btnSortUp);
            this.panel6.Controls.Add(this.btnAddFund);
            this.panel6.Controls.Add(this.dgvFunds);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.lblFundsGroupHeader);
            this.panel6.Controls.Add(this.btnSaveFund);
            this.panel6.Controls.Add(this.btnRemoveFund);
            this.panel6.Location = new System.Drawing.Point(2, -3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(968, 479);
            this.panel6.TabIndex = 0;
            // 
            // lblTotalPlanValue
            // 
            this.lblTotalPlanValue.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPlanValue.Location = new System.Drawing.Point(11, 447);
            this.lblTotalPlanValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalPlanValue.Name = "lblTotalPlanValue";
            this.lblTotalPlanValue.Size = new System.Drawing.Size(497, 18);
            this.lblTotalPlanValue.TabIndex = 89;
            this.lblTotalPlanValue.Text = "Total plan value: ";
            // 
            // cboPlanFundViews
            // 
            this.cboPlanFundViews.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboPlanFundViews.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlanFundViews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPlanFundViews.FormattingEnabled = true;
            this.cboPlanFundViews.Items.AddRange(new object[] {
            "Active Associated Funds",
            "Inactive Associated Funds"});
            this.cboPlanFundViews.Location = new System.Drawing.Point(64, 30);
            this.cboPlanFundViews.Name = "cboPlanFundViews";
            this.cboPlanFundViews.Size = new System.Drawing.Size(301, 21);
            this.cboPlanFundViews.TabIndex = 77;
            this.cboPlanFundViews.SelectedIndexChanged += new System.EventHandler(this.cboPlanFundViews_SelectedIndexChanged);
            // 
            // pnlRelationalFundPlanDetails
            // 
            this.pnlRelationalFundPlanDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRelationalFundPlanDetails.BackColor = System.Drawing.Color.Transparent;
            this.pnlRelationalFundPlanDetails.Controls.Add(this.btnClearFund);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.label18);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.lblBenchmarkPrimary);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.cboIsPerformanceCalculated);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.lblIsPerformanceCalculated);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.cboIsMonitored);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.lblIsMonitored);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.lblSelectedBenchmarkPrimary);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.txtOrdinal);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.txtAssetValueAsOf);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.txtAssetValue);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.txtDateRemoved);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.txtDateAdded);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.cboStateCode);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.cboAnalyst);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.cboAssetClass);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.cboBenchMarkSecondary);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.lblStateCode);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.lblAnalyst);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.btnOpenFund);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.lblOrdinal);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.btnOpenParHistory);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.lblAssetValueAsOf);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.lblAssetValue);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.lblDateRemoved);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.lblAssetValueDollarSign);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.lblAssetClass);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.lblDateAdded);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.lblBenchMarkSecondary);
            this.pnlRelationalFundPlanDetails.Controls.Add(this.lblFundName);
            this.pnlRelationalFundPlanDetails.Location = new System.Drawing.Point(529, 27);
            this.pnlRelationalFundPlanDetails.Name = "pnlRelationalFundPlanDetails";
            this.pnlRelationalFundPlanDetails.Size = new System.Drawing.Size(426, 438);
            this.pnlRelationalFundPlanDetails.TabIndex = 88;
            // 
            // btnClearFund
            // 
            this.btnClearFund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFund.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClearFund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFund.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(56)))), ((int)(((byte)(60)))));
            this.btnClearFund.Location = new System.Drawing.Point(389, 26);
            this.btnClearFund.Name = "btnClearFund";
            this.btnClearFund.Size = new System.Drawing.Size(27, 22);
            this.btnClearFund.TabIndex = 79;
            this.btnClearFund.Text = "x";
            this.btnClearFund.UseVisualStyleBackColor = false;
            this.btnClearFund.Click += new System.EventHandler(this.btnClearFund_Click);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Arial", 9F);
            this.label18.Location = new System.Drawing.Point(11, 28);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(157, 18);
            this.label18.TabIndex = 78;
            this.label18.Text = "Primary Benchmark:";
            // 
            // label14
            // 
            this.lblBenchmarkPrimary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBenchmarkPrimary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblBenchmarkPrimary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBenchmarkPrimary.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBenchmarkPrimary.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblBenchmarkPrimary.Location = new System.Drawing.Point(172, 26);
            this.lblBenchmarkPrimary.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBenchmarkPrimary.Name = "label14";
            this.lblBenchmarkPrimary.Size = new System.Drawing.Size(212, 22);
            this.lblBenchmarkPrimary.TabIndex = 77;
            this.lblBenchmarkPrimary.Text = "Select a fund...";
            this.lblBenchmarkPrimary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBenchmarkPrimary.Click += new System.EventHandler(this.label14_Click);
            // 
            // cboIsPerformanceCalculated
            // 
            this.cboIsPerformanceCalculated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIsPerformanceCalculated.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboIsPerformanceCalculated.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboIsPerformanceCalculated.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboIsPerformanceCalculated.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIsPerformanceCalculated.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboIsPerformanceCalculated.FormattingEnabled = true;
            this.cboIsPerformanceCalculated.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cboIsPerformanceCalculated.Location = new System.Drawing.Point(172, 96);
            this.cboIsPerformanceCalculated.Name = "cboIsPerformanceCalculated";
            this.cboIsPerformanceCalculated.Size = new System.Drawing.Size(244, 21);
            this.cboIsPerformanceCalculated.TabIndex = 75;
            this.cboIsPerformanceCalculated.TextChanged += new System.EventHandler(this.cboIsPerformanceCalculated_TextChanged);
            // 
            // lblIsPerformanceCalculated
            // 
            this.lblIsPerformanceCalculated.Font = new System.Drawing.Font("Arial", 9F);
            this.lblIsPerformanceCalculated.Location = new System.Drawing.Point(10, 98);
            this.lblIsPerformanceCalculated.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIsPerformanceCalculated.Name = "lblIsPerformanceCalculated";
            this.lblIsPerformanceCalculated.Size = new System.Drawing.Size(157, 18);
            this.lblIsPerformanceCalculated.TabIndex = 76;
            this.lblIsPerformanceCalculated.Text = "Is Performance Calculated:";
            // 
            // cboIsMonitored
            // 
            this.cboIsMonitored.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIsMonitored.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboIsMonitored.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboIsMonitored.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboIsMonitored.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIsMonitored.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboIsMonitored.FormattingEnabled = true;
            this.cboIsMonitored.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cboIsMonitored.Location = new System.Drawing.Point(172, 73);
            this.cboIsMonitored.Name = "cboIsMonitored";
            this.cboIsMonitored.Size = new System.Drawing.Size(244, 21);
            this.cboIsMonitored.TabIndex = 73;
            // 
            // lblIsMonitored
            // 
            this.lblIsMonitored.Font = new System.Drawing.Font("Arial", 9F);
            this.lblIsMonitored.Location = new System.Drawing.Point(10, 75);
            this.lblIsMonitored.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIsMonitored.Name = "lblIsMonitored";
            this.lblIsMonitored.Size = new System.Drawing.Size(157, 18);
            this.lblIsMonitored.TabIndex = 74;
            this.lblIsMonitored.Text = "Is Actively Monitored:";
            // 
            // lblSelectedBenchmarkPrimary
            // 
            this.lblSelectedBenchmarkPrimary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedBenchmarkPrimary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSelectedBenchmarkPrimary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSelectedBenchmarkPrimary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSelectedBenchmarkPrimary.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectedBenchmarkPrimary.Location = new System.Drawing.Point(172, 7);
            this.lblSelectedBenchmarkPrimary.Name = "lblSelectedBenchmarkPrimary";
            this.lblSelectedBenchmarkPrimary.Size = new System.Drawing.Size(244, 18);
            this.lblSelectedBenchmarkPrimary.TabIndex = 0;
            this.lblSelectedBenchmarkPrimary.Text = "Select a fund";
            this.lblSelectedBenchmarkPrimary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrdinal
            // 
            this.txtOrdinal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrdinal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOrdinal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrdinal.Location = new System.Drawing.Point(172, 222);
            this.txtOrdinal.Multiline = true;
            this.txtOrdinal.Name = "txtOrdinal";
            this.txtOrdinal.Size = new System.Drawing.Size(244, 18);
            this.txtOrdinal.TabIndex = 9;
            this.txtOrdinal.TextChanged += new System.EventHandler(this.cboIsMonitored_TextChanged);
            // 
            // txtAssetValueAsOf
            // 
            this.txtAssetValueAsOf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssetValueAsOf.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAssetValueAsOf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAssetValueAsOf.Location = new System.Drawing.Point(172, 179);
            this.txtAssetValueAsOf.Multiline = true;
            this.txtAssetValueAsOf.Name = "txtAssetValueAsOf";
            this.txtAssetValueAsOf.Size = new System.Drawing.Size(244, 18);
            this.txtAssetValueAsOf.TabIndex = 7;
            this.txtAssetValueAsOf.TextChanged += new System.EventHandler(this.cboIsMonitored_TextChanged);
            // 
            // txtAssetValue
            // 
            this.txtAssetValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssetValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAssetValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAssetValue.Location = new System.Drawing.Point(172, 159);
            this.txtAssetValue.Multiline = true;
            this.txtAssetValue.Name = "txtAssetValue";
            this.txtAssetValue.Size = new System.Drawing.Size(244, 18);
            this.txtAssetValue.TabIndex = 6;
            this.txtAssetValue.TextChanged += new System.EventHandler(this.cboIsMonitored_TextChanged);
            // 
            // txtDateRemoved
            // 
            this.txtDateRemoved.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateRemoved.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDateRemoved.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDateRemoved.Location = new System.Drawing.Point(172, 139);
            this.txtDateRemoved.Multiline = true;
            this.txtDateRemoved.Name = "txtDateRemoved";
            this.txtDateRemoved.Size = new System.Drawing.Size(244, 18);
            this.txtDateRemoved.TabIndex = 5;
            this.txtDateRemoved.TextChanged += new System.EventHandler(this.cboIsMonitored_TextChanged);
            // 
            // txtDateAdded
            // 
            this.txtDateAdded.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateAdded.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDateAdded.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDateAdded.Location = new System.Drawing.Point(172, 119);
            this.txtDateAdded.Multiline = true;
            this.txtDateAdded.Name = "txtDateAdded";
            this.txtDateAdded.Size = new System.Drawing.Size(244, 18);
            this.txtDateAdded.TabIndex = 4;
            this.txtDateAdded.TextChanged += new System.EventHandler(this.cboIsMonitored_TextChanged);
            // 
            // cboStateCode
            // 
            this.cboStateCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStateCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboStateCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStateCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStateCode.FormattingEnabled = true;
            this.cboStateCode.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cboStateCode.Location = new System.Drawing.Point(172, 265);
            this.cboStateCode.Name = "cboStateCode";
            this.cboStateCode.Size = new System.Drawing.Size(244, 21);
            this.cboStateCode.TabIndex = 11;
            this.cboStateCode.TextChanged += new System.EventHandler(this.cboIsMonitored_TextChanged);
            // 
            // cboAnalyst
            // 
            this.cboAnalyst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAnalyst.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboAnalyst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnalyst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAnalyst.FormattingEnabled = true;
            this.cboAnalyst.Items.AddRange(new object[] {
            "75%",
            "85%",
            "100%",
            "120%"});
            this.cboAnalyst.Location = new System.Drawing.Point(172, 242);
            this.cboAnalyst.Name = "cboAnalyst";
            this.cboAnalyst.Size = new System.Drawing.Size(244, 21);
            this.cboAnalyst.TabIndex = 10;
            this.cboAnalyst.TextChanged += new System.EventHandler(this.cboIsMonitored_TextChanged);
            // 
            // cboAssetClass
            // 
            this.cboAssetClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAssetClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboAssetClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAssetClass.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboAssetClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAssetClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAssetClass.FormattingEnabled = true;
            this.cboAssetClass.Location = new System.Drawing.Point(172, 199);
            this.cboAssetClass.Name = "cboAssetClass";
            this.cboAssetClass.Size = new System.Drawing.Size(244, 21);
            this.cboAssetClass.TabIndex = 8;
            this.cboAssetClass.TextChanged += new System.EventHandler(this.cboIsMonitored_TextChanged);
            // 
            // cboBenchMarkSecondary
            // 
            this.cboBenchMarkSecondary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBenchMarkSecondary.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboBenchMarkSecondary.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBenchMarkSecondary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboBenchMarkSecondary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBenchMarkSecondary.FormattingEnabled = true;
            this.cboBenchMarkSecondary.Location = new System.Drawing.Point(172, 50);
            this.cboBenchMarkSecondary.Name = "cboBenchMarkSecondary";
            this.cboBenchMarkSecondary.Size = new System.Drawing.Size(244, 21);
            this.cboBenchMarkSecondary.TabIndex = 3;
            this.cboBenchMarkSecondary.TextChanged += new System.EventHandler(this.cboIsMonitored_TextChanged);
            // 
            // lblStateCode
            // 
            this.lblStateCode.Font = new System.Drawing.Font("Arial", 9F);
            this.lblStateCode.Location = new System.Drawing.Point(10, 266);
            this.lblStateCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStateCode.Name = "lblStateCode";
            this.lblStateCode.Size = new System.Drawing.Size(157, 18);
            this.lblStateCode.TabIndex = 72;
            this.lblStateCode.Text = "Record State:";
            // 
            // lblAnalyst
            // 
            this.lblAnalyst.Font = new System.Drawing.Font("Arial", 9F);
            this.lblAnalyst.Location = new System.Drawing.Point(10, 244);
            this.lblAnalyst.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAnalyst.Name = "lblAnalyst";
            this.lblAnalyst.Size = new System.Drawing.Size(157, 18);
            this.lblAnalyst.TabIndex = 72;
            this.lblAnalyst.Text = "Analyst:";
            // 
            // btnOpenFund
            // 
            this.btnOpenFund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFund.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOpenFund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFund.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFund.ForeColor = System.Drawing.Color.Black;
            this.btnOpenFund.Location = new System.Drawing.Point(302, 405);
            this.btnOpenFund.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenFund.Name = "btnOpenFund";
            this.btnOpenFund.Size = new System.Drawing.Size(55, 26);
            this.btnOpenFund.TabIndex = 13;
            this.btnOpenFund.Text = "Open";
            this.btnOpenFund.UseVisualStyleBackColor = false;
            this.btnOpenFund.Click += new System.EventHandler(this.btnOpenFund_Click);
            // 
            // lblOrdinal
            // 
            this.lblOrdinal.Font = new System.Drawing.Font("Arial", 9F);
            this.lblOrdinal.Location = new System.Drawing.Point(10, 223);
            this.lblOrdinal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrdinal.Name = "lblOrdinal";
            this.lblOrdinal.Size = new System.Drawing.Size(157, 18);
            this.lblOrdinal.TabIndex = 72;
            this.lblOrdinal.Text = "Ordinal:";
            // 
            // btnOpenParHistory
            // 
            this.btnOpenParHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenParHistory.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOpenParHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenParHistory.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenParHistory.ForeColor = System.Drawing.Color.Black;
            this.btnOpenParHistory.Location = new System.Drawing.Point(361, 405);
            this.btnOpenParHistory.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenParHistory.Name = "btnOpenParHistory";
            this.btnOpenParHistory.Size = new System.Drawing.Size(55, 26);
            this.btnOpenParHistory.TabIndex = 13;
            this.btnOpenParHistory.Text = "PARs";
            this.toolTip.SetToolTip(this.btnOpenParHistory, "Open the Probation Analysis Review history for this fund and plan.");
            this.btnOpenParHistory.UseVisualStyleBackColor = false;
            this.btnOpenParHistory.Click += new System.EventHandler(this.btnOpenParHistory_Click);
            // 
            // lblAssetValueAsOf
            // 
            this.lblAssetValueAsOf.Font = new System.Drawing.Font("Arial", 9F);
            this.lblAssetValueAsOf.Location = new System.Drawing.Point(10, 180);
            this.lblAssetValueAsOf.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAssetValueAsOf.Name = "lblAssetValueAsOf";
            this.lblAssetValueAsOf.Size = new System.Drawing.Size(157, 18);
            this.lblAssetValueAsOf.TabIndex = 72;
            this.lblAssetValueAsOf.Text = "Asset Value As Of:";
            // 
            // lblAssetValue
            // 
            this.lblAssetValue.Font = new System.Drawing.Font("Arial", 9F);
            this.lblAssetValue.Location = new System.Drawing.Point(10, 159);
            this.lblAssetValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAssetValue.Name = "lblAssetValue";
            this.lblAssetValue.Size = new System.Drawing.Size(131, 18);
            this.lblAssetValue.TabIndex = 72;
            this.lblAssetValue.Text = "Asset Value:";
            // 
            // lblDateRemoved
            // 
            this.lblDateRemoved.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDateRemoved.Location = new System.Drawing.Point(10, 139);
            this.lblDateRemoved.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateRemoved.Name = "lblDateRemoved";
            this.lblDateRemoved.Size = new System.Drawing.Size(131, 18);
            this.lblDateRemoved.TabIndex = 72;
            this.lblDateRemoved.Text = "Date Removed:";
            // 
            // lblAssetValueDollarSign
            // 
            this.lblAssetValueDollarSign.Font = new System.Drawing.Font("Arial", 9F);
            this.lblAssetValueDollarSign.Location = new System.Drawing.Point(155, 159);
            this.lblAssetValueDollarSign.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAssetValueDollarSign.Name = "lblAssetValueDollarSign";
            this.lblAssetValueDollarSign.Size = new System.Drawing.Size(12, 18);
            this.lblAssetValueDollarSign.TabIndex = 72;
            this.lblAssetValueDollarSign.Text = "$";
            // 
            // lblAssetClass
            // 
            this.lblAssetClass.Font = new System.Drawing.Font("Arial", 9F);
            this.lblAssetClass.Location = new System.Drawing.Point(10, 200);
            this.lblAssetClass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAssetClass.Name = "lblAssetClass";
            this.lblAssetClass.Size = new System.Drawing.Size(157, 18);
            this.lblAssetClass.TabIndex = 72;
            this.lblAssetClass.Text = "Asset Class:";
            // 
            // lblDateAdded
            // 
            this.lblDateAdded.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDateAdded.Location = new System.Drawing.Point(10, 119);
            this.lblDateAdded.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateAdded.Name = "lblDateAdded";
            this.lblDateAdded.Size = new System.Drawing.Size(131, 18);
            this.lblDateAdded.TabIndex = 72;
            this.lblDateAdded.Text = "Date Added:";
            // 
            // lblBenchMarkSecondary
            // 
            this.lblBenchMarkSecondary.Font = new System.Drawing.Font("Arial", 9F);
            this.lblBenchMarkSecondary.Location = new System.Drawing.Point(10, 51);
            this.lblBenchMarkSecondary.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBenchMarkSecondary.Name = "lblBenchMarkSecondary";
            this.lblBenchMarkSecondary.Size = new System.Drawing.Size(157, 18);
            this.lblBenchMarkSecondary.TabIndex = 72;
            this.lblBenchMarkSecondary.Text = "Secondary Benchmark:";
            // 
            // lblFundName
            // 
            this.lblFundName.Font = new System.Drawing.Font("Arial", 9F);
            this.lblFundName.Location = new System.Drawing.Point(10, 8);
            this.lblFundName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundName.Name = "lblFundName";
            this.lblFundName.Size = new System.Drawing.Size(157, 18);
            this.lblFundName.TabIndex = 72;
            this.lblFundName.Text = "Fund Name:";
            // 
            // lblRecordSaved
            // 
            this.lblRecordSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecordSaved.AutoSize = true;
            this.lblRecordSaved.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordSaved.Location = new System.Drawing.Point(878, 8);
            this.lblRecordSaved.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordSaved.Name = "lblRecordSaved";
            this.lblRecordSaved.Size = new System.Drawing.Size(47, 16);
            this.lblRecordSaved.TabIndex = 0;
            this.lblRecordSaved.Text = "Saved!";
            this.lblRecordSaved.Visible = false;
            // 
            // lblPlanFundView
            // 
            this.lblPlanFundView.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanFundView.Location = new System.Drawing.Point(12, 32);
            this.lblPlanFundView.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlanFundView.Name = "lblPlanFundView";
            this.lblPlanFundView.Size = new System.Drawing.Size(46, 18);
            this.lblPlanFundView.TabIndex = 87;
            this.lblPlanFundView.Text = "Views:";
            // 
            // btnSortDown
            // 
            this.btnSortDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSortDown.BackColor = System.Drawing.Color.Transparent;
            this.btnSortDown.BackgroundImage = global::ISP.Properties.Resources.arrowDown;
            this.btnSortDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSortDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSortDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSortDown.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSortDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.btnSortDown.Location = new System.Drawing.Point(436, 30);
            this.btnSortDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnSortDown.Name = "btnSortDown";
            this.btnSortDown.Size = new System.Drawing.Size(20, 20);
            this.btnSortDown.TabIndex = 80;
            this.toolTip.SetToolTip(this.btnSortDown, "Increment selected fund ordinal value down by one");
            this.btnSortDown.UseVisualStyleBackColor = false;
            this.btnSortDown.Click += new System.EventHandler(this.btnSortDown_Click);
            // 
            // btnSortUp
            // 
            this.btnSortUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSortUp.BackColor = System.Drawing.Color.Transparent;
            this.btnSortUp.BackgroundImage = global::ISP.Properties.Resources.arrowUp;
            this.btnSortUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSortUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSortUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSortUp.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSortUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.btnSortUp.Location = new System.Drawing.Point(411, 30);
            this.btnSortUp.Margin = new System.Windows.Forms.Padding(0);
            this.btnSortUp.Name = "btnSortUp";
            this.btnSortUp.Size = new System.Drawing.Size(20, 20);
            this.btnSortUp.TabIndex = 79;
            this.toolTip.SetToolTip(this.btnSortUp, "Increment selected fund ordinal value up by one");
            this.btnSortUp.UseVisualStyleBackColor = false;
            this.btnSortUp.Click += new System.EventHandler(this.btnSortUp_Click);
            // 
            // btnAddFund
            // 
            this.btnAddFund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFund.BackColor = System.Drawing.Color.Transparent;
            this.btnAddFund.BackgroundImage = global::ISP.Properties.Resources.plus;
            this.btnAddFund.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddFund.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFund.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFund.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.btnAddFund.Location = new System.Drawing.Point(461, 30);
            this.btnAddFund.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddFund.Name = "btnAddFund";
            this.btnAddFund.Size = new System.Drawing.Size(20, 20);
            this.btnAddFund.TabIndex = 81;
            this.toolTip.SetToolTip(this.btnAddFund, "Add a new fund to plan");
            this.btnAddFund.UseVisualStyleBackColor = false;
            this.btnAddFund.Click += new System.EventHandler(this.btnAddFund_Click);
            // 
            // dgvFunds
            // 
            this.dgvFunds.AllowUserToAddRows = false;
            this.dgvFunds.AllowUserToDeleteRows = false;
            this.dgvFunds.AllowUserToResizeRows = false;
            this.dgvFunds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFunds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFunds.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFunds.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvFunds.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFunds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFunds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFunds.EnableHeadersVisualStyles = false;
            this.dgvFunds.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFunds.Location = new System.Drawing.Point(11, 57);
            this.dgvFunds.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFunds.MultiSelect = false;
            this.dgvFunds.Name = "dgvFunds";
            this.dgvFunds.ReadOnly = true;
            this.dgvFunds.RowHeadersVisible = false;
            this.dgvFunds.RowTemplate.Height = 24;
            this.dgvFunds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvFunds.Size = new System.Drawing.Size(497, 388);
            this.dgvFunds.TabIndex = 83;
            this.dgvFunds.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFunds_CellDoubleClick);
            this.dgvFunds.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFunds_CellEnter);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.label6.Location = new System.Drawing.Point(525, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 21);
            this.label6.TabIndex = 84;
            this.label6.Text = "Selected Fund";
            // 
            // lblFundsGroupHeader
            // 
            this.lblFundsGroupHeader.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFundsGroupHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.lblFundsGroupHeader.Location = new System.Drawing.Point(7, 6);
            this.lblFundsGroupHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFundsGroupHeader.Name = "lblFundsGroupHeader";
            this.lblFundsGroupHeader.Size = new System.Drawing.Size(184, 21);
            this.lblFundsGroupHeader.TabIndex = 85;
            this.lblFundsGroupHeader.Text = "Funds in Selected Plan";
            // 
            // btnSaveFund
            // 
            this.btnSaveFund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFund.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveFund.BackgroundImage = global::ISP.Properties.Resources.save;
            this.btnSaveFund.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveFund.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveFund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFund.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveFund.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.btnSaveFund.Location = new System.Drawing.Point(929, 4);
            this.btnSaveFund.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveFund.Name = "btnSaveFund";
            this.btnSaveFund.Size = new System.Drawing.Size(26, 26);
            this.btnSaveFund.TabIndex = 78;
            this.toolTip.SetToolTip(this.btnSaveFund, "Save details of selected fund to plan");
            this.btnSaveFund.UseVisualStyleBackColor = false;
            this.btnSaveFund.Click += new System.EventHandler(this.btnSaveFund_Click);
            // 
            // btnRemoveFund
            // 
            this.btnRemoveFund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFund.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveFund.BackgroundImage = global::ISP.Properties.Resources.x;
            this.btnRemoveFund.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveFund.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveFund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFund.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFund.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.btnRemoveFund.Location = new System.Drawing.Point(486, 30);
            this.btnRemoveFund.Margin = new System.Windows.Forms.Padding(0);
            this.btnRemoveFund.Name = "btnRemoveFund";
            this.btnRemoveFund.Size = new System.Drawing.Size(20, 20);
            this.btnRemoveFund.TabIndex = 82;
            this.toolTip.SetToolTip(this.btnRemoveFund, "Remove selected fund from plan");
            this.btnRemoveFund.UseVisualStyleBackColor = false;
            this.btnRemoveFund.Click += new System.EventHandler(this.btnRemoveFund_Click);
            // 
            // tabIpsMonitoringCriteria
            // 
            this.tabIpsMonitoringCriteria.Controls.Add(this.panel1);
            this.tabIpsMonitoringCriteria.Location = new System.Drawing.Point(4, 22);
            this.tabIpsMonitoringCriteria.Name = "tabIpsMonitoringCriteria";
            this.tabIpsMonitoringCriteria.Padding = new System.Windows.Forms.Padding(3);
            this.tabIpsMonitoringCriteria.Size = new System.Drawing.Size(970, 476);
            this.tabIpsMonitoringCriteria.TabIndex = 0;
            this.tabIpsMonitoringCriteria.Text = "IPS Monitoring Criteria";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnlIpsMonitoringCriteria);
            this.panel1.Controls.Add(this.lblIpsMonitoringCriteriaHeader);
            this.panel1.Controls.Add(this.btnSaveIpsCriteria);
            this.panel1.Location = new System.Drawing.Point(2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 481);
            this.panel1.TabIndex = 78;
            // 
            // pnlIpsMonitoringCriteria
            // 
            this.pnlIpsMonitoringCriteria.BackColor = System.Drawing.Color.Transparent;
            this.pnlIpsMonitoringCriteria.Controls.Add(this.txtExpenseRatio);
            this.pnlIpsMonitoringCriteria.Controls.Add(this.label5);
            this.pnlIpsMonitoringCriteria.Controls.Add(this.cboTrackManagers);
            this.pnlIpsMonitoringCriteria.Controls.Add(this.cboIpsRisk3Yr);
            this.pnlIpsMonitoringCriteria.Controls.Add(this.cboIpsReturn3Yr);
            this.pnlIpsMonitoringCriteria.Controls.Add(this.cboIpsReturn1Yr);
            this.pnlIpsMonitoringCriteria.Controls.Add(this.label57);
            this.pnlIpsMonitoringCriteria.Controls.Add(this.label28);
            this.pnlIpsMonitoringCriteria.Controls.Add(this.label26);
            this.pnlIpsMonitoringCriteria.Controls.Add(this.label22);
            this.pnlIpsMonitoringCriteria.Location = new System.Drawing.Point(10, 28);
            this.pnlIpsMonitoringCriteria.Name = "pnlIpsMonitoringCriteria";
            this.pnlIpsMonitoringCriteria.Size = new System.Drawing.Size(277, 150);
            this.pnlIpsMonitoringCriteria.TabIndex = 77;
            // 
            // txtExpenseRatio
            // 
            this.txtExpenseRatio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpenseRatio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtExpenseRatio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExpenseRatio.Location = new System.Drawing.Point(145, 102);
            this.txtExpenseRatio.Multiline = true;
            this.txtExpenseRatio.Name = "txtExpenseRatio";
            this.txtExpenseRatio.Size = new System.Drawing.Size(124, 22);
            this.txtExpenseRatio.TabIndex = 75;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 9F);
            this.label5.Location = new System.Drawing.Point(6, 104);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 18);
            this.label5.TabIndex = 74;
            this.label5.Text = "Expense Ratio:";
            // 
            // cboTrackManagers
            // 
            this.cboTrackManagers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTrackManagers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboTrackManagers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrackManagers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTrackManagers.FormattingEnabled = true;
            this.cboTrackManagers.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cboTrackManagers.Location = new System.Drawing.Point(145, 78);
            this.cboTrackManagers.Name = "cboTrackManagers";
            this.cboTrackManagers.Size = new System.Drawing.Size(124, 21);
            this.cboTrackManagers.TabIndex = 3;
            this.cboTrackManagers.SelectedIndexChanged += new System.EventHandler(this.cboIpsReturn1Yr_TextChanged);
            this.cboTrackManagers.TextChanged += new System.EventHandler(this.cboIpsReturn1Yr_TextChanged);
            // 
            // cboIpsRisk3Yr
            // 
            this.cboIpsRisk3Yr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIpsRisk3Yr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboIpsRisk3Yr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIpsRisk3Yr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboIpsRisk3Yr.FormattingEnabled = true;
            this.cboIpsRisk3Yr.Items.AddRange(new object[] {
            "",
            "100%",
            "120%"});
            this.cboIpsRisk3Yr.Location = new System.Drawing.Point(145, 54);
            this.cboIpsRisk3Yr.Name = "cboIpsRisk3Yr";
            this.cboIpsRisk3Yr.Size = new System.Drawing.Size(124, 21);
            this.cboIpsRisk3Yr.TabIndex = 2;
            this.cboIpsRisk3Yr.SelectedIndexChanged += new System.EventHandler(this.cboIpsReturn1Yr_TextChanged);
            this.cboIpsRisk3Yr.TextChanged += new System.EventHandler(this.cboIpsReturn1Yr_TextChanged);
            // 
            // cboIpsReturn3Yr
            // 
            this.cboIpsReturn3Yr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIpsReturn3Yr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboIpsReturn3Yr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIpsReturn3Yr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboIpsReturn3Yr.FormattingEnabled = true;
            this.cboIpsReturn3Yr.Items.AddRange(new object[] {
            "",
            "80%",
            "85%",
            "90%",
            "95%",
            "100%"});
            this.cboIpsReturn3Yr.Location = new System.Drawing.Point(145, 30);
            this.cboIpsReturn3Yr.Name = "cboIpsReturn3Yr";
            this.cboIpsReturn3Yr.Size = new System.Drawing.Size(124, 21);
            this.cboIpsReturn3Yr.TabIndex = 1;
            this.cboIpsReturn3Yr.SelectedIndexChanged += new System.EventHandler(this.cboIpsReturn1Yr_TextChanged);
            this.cboIpsReturn3Yr.TextChanged += new System.EventHandler(this.cboIpsReturn1Yr_TextChanged);
            // 
            // cboIpsReturn1Yr
            // 
            this.cboIpsReturn1Yr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIpsReturn1Yr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboIpsReturn1Yr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIpsReturn1Yr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboIpsReturn1Yr.FormattingEnabled = true;
            this.cboIpsReturn1Yr.Items.AddRange(new object[] {
            "",
            "60%",
            "65%",
            "70%",
            "75%",
            "80%",
            "85%",
            "100%"});
            this.cboIpsReturn1Yr.Location = new System.Drawing.Point(145, 6);
            this.cboIpsReturn1Yr.Name = "cboIpsReturn1Yr";
            this.cboIpsReturn1Yr.Size = new System.Drawing.Size(124, 21);
            this.cboIpsReturn1Yr.TabIndex = 0;
            this.cboIpsReturn1Yr.SelectedIndexChanged += new System.EventHandler(this.cboIpsReturn1Yr_TextChanged);
            this.cboIpsReturn1Yr.TextChanged += new System.EventHandler(this.cboIpsReturn1Yr_TextChanged);
            // 
            // label57
            // 
            this.label57.Font = new System.Drawing.Font("Arial", 9F);
            this.label57.Location = new System.Drawing.Point(6, 80);
            this.label57.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(113, 18);
            this.label57.TabIndex = 72;
            this.label57.Text = "Track Managers:";
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Arial", 9F);
            this.label28.Location = new System.Drawing.Point(6, 57);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(113, 18);
            this.label28.TabIndex = 72;
            this.label28.Text = "Risk 3 YR:";
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Arial", 9F);
            this.label26.Location = new System.Drawing.Point(6, 33);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(113, 18);
            this.label26.TabIndex = 72;
            this.label26.Text = "Return 3 YR:";
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Arial", 9F);
            this.label22.Location = new System.Drawing.Point(6, 9);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(113, 18);
            this.label22.TabIndex = 72;
            this.label22.Text = "Return 1 YR:";
            // 
            // lblIpsMonitoringCriteriaHeader
            // 
            this.lblIpsMonitoringCriteriaHeader.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpsMonitoringCriteriaHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.lblIpsMonitoringCriteriaHeader.Location = new System.Drawing.Point(7, 4);
            this.lblIpsMonitoringCriteriaHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIpsMonitoringCriteriaHeader.Name = "lblIpsMonitoringCriteriaHeader";
            this.lblIpsMonitoringCriteriaHeader.Size = new System.Drawing.Size(204, 21);
            this.lblIpsMonitoringCriteriaHeader.TabIndex = 62;
            this.lblIpsMonitoringCriteriaHeader.Text = "IPS Monitoring Criteria";
            // 
            // btnSaveIpsCriteria
            // 
            this.btnSaveIpsCriteria.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveIpsCriteria.BackgroundImage = global::ISP.Properties.Resources.save;
            this.btnSaveIpsCriteria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveIpsCriteria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveIpsCriteria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveIpsCriteria.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveIpsCriteria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.btnSaveIpsCriteria.Location = new System.Drawing.Point(263, 1);
            this.btnSaveIpsCriteria.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveIpsCriteria.Name = "btnSaveIpsCriteria";
            this.btnSaveIpsCriteria.Size = new System.Drawing.Size(24, 24);
            this.btnSaveIpsCriteria.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnSaveIpsCriteria, "Save IPS monitoring criteria");
            this.btnSaveIpsCriteria.UseVisualStyleBackColor = false;
            this.btnSaveIpsCriteria.Click += new System.EventHandler(this.btnSaveIpsCriteria_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.pnlInvestmentTabHeader);
            this.panel5.Font = new System.Drawing.Font("High Tower Text", 32F);
            this.panel5.Location = new System.Drawing.Point(-1, -1);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(971, 50);
            this.panel5.TabIndex = 58;
            // 
            // pnlInvestmentTabHeader
            // 
            this.pnlInvestmentTabHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInvestmentTabHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnlInvestmentTabHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInvestmentTabHeader.Controls.Add(this.label30);
            this.pnlInvestmentTabHeader.Font = new System.Drawing.Font("High Tower Text", 32F);
            this.pnlInvestmentTabHeader.Location = new System.Drawing.Point(2, 0);
            this.pnlInvestmentTabHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlInvestmentTabHeader.Name = "pnlInvestmentTabHeader";
            this.pnlInvestmentTabHeader.Size = new System.Drawing.Size(968, 49);
            this.pnlInvestmentTabHeader.TabIndex = 59;
            this.pnlInvestmentTabHeader.DoubleClick += new System.EventHandler(this.MaximizeForm);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("High Tower Text", 27.75F);
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(-3, 1);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(270, 44);
            this.label30.TabIndex = 0;
            this.label30.Text = "Company Name";
            this.label30.DoubleClick += new System.EventHandler(this.MaximizeForm);
            // 
            // tabClientObservations
            // 
            this.tabClientObservations.BackColor = System.Drawing.Color.Gainsboro;
            this.tabClientObservations.Controls.Add(this.panel8);
            this.tabClientObservations.Controls.Add(this.pnlObservationsTabHeader);
            this.tabClientObservations.Location = new System.Drawing.Point(4, 25);
            this.tabClientObservations.Margin = new System.Windows.Forms.Padding(2);
            this.tabClientObservations.Name = "tabClientObservations";
            this.tabClientObservations.Size = new System.Drawing.Size(981, 600);
            this.tabClientObservations.TabIndex = 3;
            this.tabClientObservations.Text = "Observations";
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label55);
            this.panel8.Controls.Add(this.label51);
            this.panel8.Controls.Add(this.label54);
            this.panel8.Controls.Add(this.label50);
            this.panel8.Controls.Add(this.richTextBox4);
            this.panel8.Controls.Add(this.comboBox10);
            this.panel8.Controls.Add(this.comboBox9);
            this.panel8.Controls.Add(this.button7);
            this.panel8.Controls.Add(this.button2);
            this.panel8.Controls.Add(this.button4);
            this.panel8.Controls.Add(this.comboBox8);
            this.panel8.Controls.Add(this.label53);
            this.panel8.Controls.Add(this.label48);
            this.panel8.Controls.Add(this.label52);
            this.panel8.Controls.Add(this.label17);
            this.panel8.Controls.Add(this.label44);
            this.panel8.Controls.Add(this.label45);
            this.panel8.Controls.Add(this.label16);
            this.panel8.Location = new System.Drawing.Point(2, 48);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(968, 543);
            this.panel8.TabIndex = 69;
            // 
            // label55
            // 
            this.label55.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(752, 512);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(17, 16);
            this.label55.TabIndex = 82;
            this.label55.Text = "...";
            // 
            // label51
            // 
            this.label51.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(752, 490);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(17, 16);
            this.label51.TabIndex = 82;
            this.label51.Text = "...";
            // 
            // label54
            // 
            this.label54.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(561, 512);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(17, 16);
            this.label54.TabIndex = 82;
            this.label54.Text = "...";
            // 
            // label50
            // 
            this.label50.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(561, 490);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(17, 16);
            this.label50.TabIndex = 82;
            this.label50.Text = "...";
            // 
            // richTextBox4
            // 
            this.richTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox4.Location = new System.Drawing.Point(14, 33);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(940, 448);
            this.richTextBox4.TabIndex = 80;
            this.richTextBox4.Text = "";
            // 
            // comboBox10
            // 
            this.comboBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox10.Enabled = false;
            this.comboBox10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox10.FormattingEnabled = true;
            this.comboBox10.Location = new System.Drawing.Point(98, 511);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(326, 21);
            this.comboBox10.TabIndex = 79;
            // 
            // comboBox9
            // 
            this.comboBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox9.Enabled = false;
            this.comboBox9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Location = new System.Drawing.Point(98, 487);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(326, 21);
            this.comboBox9.TabIndex = 79;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button7.Enabled = false;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Gadugi", 12F);
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(876, 495);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(78, 32);
            this.button7.TabIndex = 78;
            this.button7.Text = "Save";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(823, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 24);
            this.button2.TabIndex = 75;
            this.button2.Text = "New";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(889, 5);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 24);
            this.button4.TabIndex = 76;
            this.button4.Text = "Remove";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox8
            // 
            this.comboBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox8.Enabled = false;
            this.comboBox8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(122, 6);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(696, 21);
            this.comboBox8.TabIndex = 73;
            this.comboBox8.SelectedIndexChanged += new System.EventHandler(this.comboBox8_SelectedIndexChanged);
            // 
            // label53
            // 
            this.label53.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label53.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(465, 512);
            this.label53.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(91, 18);
            this.label53.TabIndex = 71;
            this.label53.Text = "Created By:";
            // 
            // label48
            // 
            this.label48.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label48.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(465, 490);
            this.label48.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(91, 18);
            this.label48.TabIndex = 71;
            this.label48.Text = "Last Modified By:";
            // 
            // label52
            // 
            this.label52.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label52.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(655, 512);
            this.label52.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(92, 18);
            this.label52.TabIndex = 71;
            this.label52.Text = "Created On";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(655, 490);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 18);
            this.label17.TabIndex = 71;
            this.label17.Text = "Last Modified On:";
            // 
            // label44
            // 
            this.label44.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label44.Font = new System.Drawing.Font("Arial", 9F);
            this.label44.Location = new System.Drawing.Point(11, 489);
            this.label44.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(82, 18);
            this.label44.TabIndex = 71;
            this.label44.Text = "Month:";
            // 
            // label45
            // 
            this.label45.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label45.Font = new System.Drawing.Font("Arial", 9F);
            this.label45.Location = new System.Drawing.Point(11, 513);
            this.label45.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(82, 18);
            this.label45.TabIndex = 72;
            this.label45.Text = "Owner:";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.label16.Location = new System.Drawing.Point(10, 6);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 21);
            this.label16.TabIndex = 68;
            this.label16.Text = "Observations";
            // 
            // pnlObservationsTabHeader
            // 
            this.pnlObservationsTabHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlObservationsTabHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnlObservationsTabHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlObservationsTabHeader.Controls.Add(this.label39);
            this.pnlObservationsTabHeader.Font = new System.Drawing.Font("High Tower Text", 32F);
            this.pnlObservationsTabHeader.Location = new System.Drawing.Point(2, 0);
            this.pnlObservationsTabHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlObservationsTabHeader.Name = "pnlObservationsTabHeader";
            this.pnlObservationsTabHeader.Size = new System.Drawing.Size(968, 49);
            this.pnlObservationsTabHeader.TabIndex = 67;
            this.pnlObservationsTabHeader.DoubleClick += new System.EventHandler(this.MaximizeForm);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("High Tower Text", 27.75F);
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(-3, 1);
            this.label39.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(270, 44);
            this.label39.TabIndex = 0;
            this.label39.Text = "Company Name";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label25);
            this.panel4.Location = new System.Drawing.Point(0, 667);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(968, 21);
            this.panel4.TabIndex = 57;
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
            this.panel3.Controls.Add(this.label49);
            this.panel3.Controls.Add(this.label47);
            this.panel3.Controls.Add(this.label46);
            this.panel3.Location = new System.Drawing.Point(0, 615);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(968, 53);
            this.panel3.TabIndex = 58;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.Cursor = System.Windows.Forms.Cursors.Default;
            this.label49.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.Black;
            this.label49.Location = new System.Drawing.Point(184, 15);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(133, 25);
            this.label49.TabIndex = 0;
            this.label49.Text = "Observations";
            this.label49.Click += new System.EventHandler(this.label49_Click);
            this.label49.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.label49.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.BackColor = System.Drawing.Color.Transparent;
            this.label47.Cursor = System.Windows.Forms.Cursors.Default;
            this.label47.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.Black;
            this.label47.Location = new System.Drawing.Point(117, 15);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(61, 25);
            this.label47.TabIndex = 0;
            this.label47.Text = "Plans";
            this.label47.Click += new System.EventHandler(this.label47_Click);
            this.label47.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.label47.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
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
            // panel16
            // 
            this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.label38);
            this.panel16.Controls.Add(this.label1);
            this.panel16.Location = new System.Drawing.Point(0, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(968, 27);
            this.panel16.TabIndex = 60;
            this.panel16.DoubleClick += new System.EventHandler(this.MaximizeForm);
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label38.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.White;
            this.label38.Location = new System.Drawing.Point(940, 1);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(25, 25);
            this.label38.TabIndex = 22;
            this.label38.Text = "x";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label38.Click += new System.EventHandler(this.CloseForm);
            this.label38.MouseEnter += new System.EventHandler(this.CloseFormButton_MouseEnter);
            this.label38.MouseLeave += new System.EventHandler(this.CloseFormButton_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Investment Services Program - Account";
            this.label1.DoubleClick += new System.EventHandler(this.MaximizeForm);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Save";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Save and Close";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Save and New";
            // 
            // frmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(968, 688);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.tabControlClientDetail);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(755, 595);
            this.Name = "frmAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account";
            this.tabControlClientDetail.ResumeLayout(false);
            this.tabClientSummary.ResumeLayout(false);
            this.pnlSummaryTabHeader.ResumeLayout(false);
            this.pnlSummaryTabHeader.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabClientInvestments.ResumeLayout(false);
            this.pnlInvestmentTabBody.ResumeLayout(false);
            this.pnlSelectedPlan.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tabControlInvestments.ResumeLayout(false);
            this.tabFunds.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.pnlRelationalFundPlanDetails.ResumeLayout(false);
            this.pnlRelationalFundPlanDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunds)).EndInit();
            this.tabIpsMonitoringCriteria.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlIpsMonitoringCriteria.ResumeLayout(false);
            this.pnlIpsMonitoringCriteria.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.pnlInvestmentTabHeader.ResumeLayout(false);
            this.pnlInvestmentTabHeader.PerformLayout();
            this.tabClientObservations.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.pnlObservationsTabHeader.ResumeLayout(false);
            this.pnlObservationsTabHeader.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.ResumeLayout(false);

        }
		public System.Windows.Forms.RichTextBox txtName;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.Label lblContactInformationHeader;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
		public System.Windows.Forms.RichTextBox txtAddressZip;
		public System.Windows.Forms.RichTextBox txtAddressState;
		public System.Windows.Forms.RichTextBox txtAddressCity;
		public System.Windows.Forms.RichTextBox txtAddressLine2;
		public System.Windows.Forms.RichTextBox txtAddressLine1;
		public System.Windows.Forms.RichTextBox txtPhone;
		public System.Windows.Forms.RichTextBox txtPrimaryContactEmail;
		public System.Windows.Forms.RichTextBox txtFax;
		private System.Windows.Forms.TabPage tabClientObservations;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		public System.Windows.Forms.Label lblAccountInformationHeader;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabClientInvestments;
        private System.Windows.Forms.TabPage tabClientSummary;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.RichTextBox txtEngagements;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
        public System.Windows.Forms.RichTextBox assetvalue;
        public System.Windows.Forms.TabControl tabControlClientDetail;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel pnlSummaryTabHeader;
        public System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Label lblIpsMonitoringCriteriaHeader;
        private System.Windows.Forms.Panel pnlInvestmentTabHeader;
        public System.Windows.Forms.Label label30;
        public System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel pnlObservationsTabHeader;
        public System.Windows.Forms.Label label39;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlInvestmentTabBody;
        private System.Windows.Forms.Panel panel8;
        public System.Windows.Forms.RichTextBox txtPrimaryContactName;
        public System.Windows.Forms.Label lblAddressHeader;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.RichTextBox txtCommitteeMembers;
        private System.Windows.Forms.Panel pnlSelectedPlan;
        public System.Windows.Forms.ComboBox cboSelectedPlan;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox cboIpsRisk3Yr;
        private System.Windows.Forms.ComboBox cboIpsReturn3Yr;
        private System.Windows.Forms.ComboBox cboIpsReturn1Yr;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label42;
        public System.Windows.Forms.RichTextBox txtCustodians;
        private System.Windows.Forms.Label label41;
        public System.Windows.Forms.RichTextBox txtRecordKeepers;
        public System.Windows.Forms.Label lblRelatedEntitiesHeader;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox comboBox10;
        private System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label52;
        public System.Windows.Forms.Label label56;
        private System.Windows.Forms.ComboBox cboTrackManagers;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Button btnSaveIpsCriteria;
        private System.Windows.Forms.Panel pnlIpsMonitoringCriteria;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblToIpsMonitoringCriteria;
        private System.Windows.Forms.TabControl tabControlInvestments;
        private System.Windows.Forms.TabPage tabFunds;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cboPlanFundViews;
        private System.Windows.Forms.Panel pnlRelationalFundPlanDetails;
        private System.Windows.Forms.Label lblSelectedBenchmarkPrimary;
        private System.Windows.Forms.TextBox txtOrdinal;
        private System.Windows.Forms.TextBox txtAssetValueAsOf;
        private System.Windows.Forms.TextBox txtAssetValue;
        private System.Windows.Forms.TextBox txtDateRemoved;
        private System.Windows.Forms.TextBox txtDateAdded;
        private System.Windows.Forms.ComboBox cboStateCode;
        private System.Windows.Forms.ComboBox cboAnalyst;
        public System.Windows.Forms.ComboBox cboAssetClass;
        public System.Windows.Forms.ComboBox cboBenchMarkSecondary;
        private System.Windows.Forms.Label lblStateCode;
        private System.Windows.Forms.Label lblAnalyst;
        private System.Windows.Forms.Button btnOpenFund;
        private System.Windows.Forms.Label lblOrdinal;
        private System.Windows.Forms.Button btnOpenParHistory;
        private System.Windows.Forms.Label lblAssetValueAsOf;
        private System.Windows.Forms.Label lblAssetValue;
        private System.Windows.Forms.Label lblDateRemoved;
        private System.Windows.Forms.Label lblAssetValueDollarSign;
        private System.Windows.Forms.Label lblAssetClass;
        private System.Windows.Forms.Label lblDateAdded;
        private System.Windows.Forms.Label lblBenchMarkSecondary;
        private System.Windows.Forms.Label lblFundName;
        private System.Windows.Forms.Label lblRecordSaved;
        private System.Windows.Forms.Label lblPlanFundView;
        private System.Windows.Forms.Button btnSortDown;
        private System.Windows.Forms.Button btnSortUp;
        private System.Windows.Forms.Button btnAddFund;
        private System.Windows.Forms.DataGridView dgvFunds;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblFundsGroupHeader;
        private System.Windows.Forms.Button btnSaveFund;
        private System.Windows.Forms.Button btnRemoveFund;
        private System.Windows.Forms.TabPage tabIpsMonitoringCriteria;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblToFunds;
        private System.Windows.Forms.Label lblTotalPlanValue;
        public System.Windows.Forms.ComboBox cboIsPerformanceCalculated;
        private System.Windows.Forms.Label lblIsPerformanceCalculated;
        public System.Windows.Forms.ComboBox cboIsMonitored;
        private System.Windows.Forms.Label lblIsMonitored;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExpenseRatio;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblBenchmarkPrimary;
        private System.Windows.Forms.Button btnClearFund;
	}
}
