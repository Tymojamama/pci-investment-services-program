namespace ISP.Presentation.Forms
{
    partial class frmProbationAnalysis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlFormHeader = new System.Windows.Forms.Panel();
            this.lblFormMinimize = new System.Windows.Forms.Label();
            this.lblFormClose = new System.Windows.Forms.Label();
            this.lblFormHeader = new System.Windows.Forms.Label();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.pnlFields = new System.Windows.Forms.Panel();
            this.cboOwner = new System.Windows.Forms.ComboBox();
            this.lblOwner = new System.Windows.Forms.Label();
            this.txtRecommendation = new System.Windows.Forms.RichTextBox();
            this.lblRecommendation = new System.Windows.Forms.Label();
            this.txtConsiderations = new System.Windows.Forms.RichTextBox();
            this.txtTemporaryPermanent = new System.Windows.Forms.RichTextBox();
            this.txtHypothesisSupport = new System.Windows.Forms.RichTextBox();
            this.txtHypothesis = new System.Windows.Forms.RichTextBox();
            this.txtRecognition = new System.Windows.Forms.RichTextBox();
            this.lblConsiderations = new System.Windows.Forms.Label();
            this.cboRecommendedWord = new System.Windows.Forms.ComboBox();
            this.cboSelectedQuarter = new System.Windows.Forms.ComboBox();
            this.lblTemporaryPermanent = new System.Windows.Forms.Label();
            this.lblHypothesisSupport = new System.Windows.Forms.Label();
            this.lblHypothesis = new System.Windows.Forms.Label();
            this.lblBumper = new System.Windows.Forms.Label();
            this.lblRecommendedWord = new System.Windows.Forms.Label();
            this.lblQuarter = new System.Windows.Forms.Label();
            this.lblRecognition = new System.Windows.Forms.Label();
            this.txtDateApproved = new System.Windows.Forms.TextBox();
            this.lblDateApproved = new System.Windows.Forms.Label();
            this.txtDatePresented = new System.Windows.Forms.TextBox();
            this.lblDatePresented = new System.Windows.Forms.Label();
            this.txtPlan = new System.Windows.Forms.TextBox();
            this.lblPlan = new System.Windows.Forms.Label();
            this.txtFund = new System.Windows.Forms.TextBox();
            this.lblFund = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboSelectedReview = new System.Windows.Forms.ComboBox();
            this.lblSelectedReview = new System.Windows.Forms.Label();
            this.btnNewProbationAnalysis = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlFormHeader.SuspendLayout();
            this.pnlBackground.SuspendLayout();
            this.pnlFields.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFormHeader
            // 
            this.pnlFormHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlFormHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormHeader.Controls.Add(this.lblFormMinimize);
            this.pnlFormHeader.Controls.Add(this.lblFormClose);
            this.pnlFormHeader.Controls.Add(this.lblFormHeader);
            this.pnlFormHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlFormHeader.Name = "pnlFormHeader";
            this.pnlFormHeader.Size = new System.Drawing.Size(950, 27);
            this.pnlFormHeader.TabIndex = 60;
            this.pnlFormHeader.DoubleClick += new System.EventHandler(this.pnlFormHeader_DoubleClick);
            // 
            // lblFormMinimize
            // 
            this.lblFormMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormMinimize.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblFormMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormMinimize.ForeColor = System.Drawing.Color.White;
            this.lblFormMinimize.Location = new System.Drawing.Point(894, 1);
            this.lblFormMinimize.Name = "lblFormMinimize";
            this.lblFormMinimize.Size = new System.Drawing.Size(25, 25);
            this.lblFormMinimize.TabIndex = 22;
            this.lblFormMinimize.Text = "-";
            this.lblFormMinimize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblFormMinimize.Click += new System.EventHandler(this.lblMinForm_Click);
            this.lblFormMinimize.MouseEnter += new System.EventHandler(this.CloseFormButton_MouseEnter);
            this.lblFormMinimize.MouseLeave += new System.EventHandler(this.CloseFormButton_MouseLeave);
            // 
            // lblFormClose
            // 
            this.lblFormClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormClose.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblFormClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormClose.ForeColor = System.Drawing.Color.White;
            this.lblFormClose.Location = new System.Drawing.Point(922, 1);
            this.lblFormClose.Name = "lblFormClose";
            this.lblFormClose.Size = new System.Drawing.Size(25, 25);
            this.lblFormClose.TabIndex = 22;
            this.lblFormClose.Text = "x";
            this.lblFormClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFormClose.Click += new System.EventHandler(this.lblCloseForm_Click);
            this.lblFormClose.MouseEnter += new System.EventHandler(this.CloseFormButton_MouseEnter);
            this.lblFormClose.MouseLeave += new System.EventHandler(this.CloseFormButton_MouseLeave);
            // 
            // lblFormHeader
            // 
            this.lblFormHeader.AutoSize = true;
            this.lblFormHeader.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormHeader.ForeColor = System.Drawing.Color.White;
            this.lblFormHeader.Location = new System.Drawing.Point(4, 5);
            this.lblFormHeader.Name = "lblFormHeader";
            this.lblFormHeader.Size = new System.Drawing.Size(296, 16);
            this.lblFormHeader.TabIndex = 23;
            this.lblFormHeader.Text = "Investment Services Program - Probation Analysis";
            this.lblFormHeader.DoubleClick += new System.EventHandler(this.lblFormHeader_DoubleClick);
            // 
            // pnlBackground
            // 
            this.pnlBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBackground.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBackground.Controls.Add(this.pnlFields);
            this.pnlBackground.Controls.Add(this.lblHeader);
            this.pnlBackground.Controls.Add(this.panel1);
            this.pnlBackground.Controls.Add(this.btnDelete);
            this.pnlBackground.Controls.Add(this.btnClose);
            this.pnlBackground.Controls.Add(this.btnSave);
            this.pnlBackground.Location = new System.Drawing.Point(0, 25);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(950, 650);
            this.pnlBackground.TabIndex = 61;
            this.pnlBackground.DoubleClick += new System.EventHandler(this.pnlBackground_DoubleClick);
            // 
            // pnlFields
            // 
            this.pnlFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFields.AutoScroll = true;
            this.pnlFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFields.Controls.Add(this.cboOwner);
            this.pnlFields.Controls.Add(this.lblOwner);
            this.pnlFields.Controls.Add(this.txtRecommendation);
            this.pnlFields.Controls.Add(this.lblRecommendation);
            this.pnlFields.Controls.Add(this.txtConsiderations);
            this.pnlFields.Controls.Add(this.txtTemporaryPermanent);
            this.pnlFields.Controls.Add(this.txtHypothesisSupport);
            this.pnlFields.Controls.Add(this.txtHypothesis);
            this.pnlFields.Controls.Add(this.txtRecognition);
            this.pnlFields.Controls.Add(this.lblConsiderations);
            this.pnlFields.Controls.Add(this.cboRecommendedWord);
            this.pnlFields.Controls.Add(this.cboSelectedQuarter);
            this.pnlFields.Controls.Add(this.lblTemporaryPermanent);
            this.pnlFields.Controls.Add(this.lblHypothesisSupport);
            this.pnlFields.Controls.Add(this.lblHypothesis);
            this.pnlFields.Controls.Add(this.lblBumper);
            this.pnlFields.Controls.Add(this.lblRecommendedWord);
            this.pnlFields.Controls.Add(this.lblQuarter);
            this.pnlFields.Controls.Add(this.lblRecognition);
            this.pnlFields.Controls.Add(this.txtDateApproved);
            this.pnlFields.Controls.Add(this.lblDateApproved);
            this.pnlFields.Controls.Add(this.txtDatePresented);
            this.pnlFields.Controls.Add(this.lblDatePresented);
            this.pnlFields.Controls.Add(this.txtPlan);
            this.pnlFields.Controls.Add(this.lblPlan);
            this.pnlFields.Controls.Add(this.txtFund);
            this.pnlFields.Controls.Add(this.lblFund);
            this.pnlFields.Location = new System.Drawing.Point(-1, 95);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(950, 498);
            this.pnlFields.TabIndex = 78;
            this.pnlFields.Click += new System.EventHandler(this.pnlFields_Click);
            // 
            // cboOwner
            // 
            this.cboOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboOwner.FormattingEnabled = true;
            this.cboOwner.Location = new System.Drawing.Point(134, 53);
            this.cboOwner.Name = "cboOwner";
            this.cboOwner.Size = new System.Drawing.Size(767, 21);
            this.cboOwner.TabIndex = 81;
            this.cboOwner.TextChanged += new System.EventHandler(this.cboSelectedQuarter_TextChanged);
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwner.Location = new System.Drawing.Point(11, 54);
            this.lblOwner.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(46, 16);
            this.lblOwner.TabIndex = 80;
            this.lblOwner.Text = "Owner:";
            // 
            // txtRecommendation
            // 
            this.txtRecommendation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecommendation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecommendation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRecommendation.Location = new System.Drawing.Point(133, 505);
            this.txtRecommendation.Name = "txtRecommendation";
            this.txtRecommendation.Size = new System.Drawing.Size(767, 54);
            this.txtRecommendation.TabIndex = 79;
            this.txtRecommendation.Text = "";
            this.txtRecommendation.TextChanged += new System.EventHandler(this.txtRecognition_TextChanged);
            // 
            // lblRecommendation
            // 
            this.lblRecommendation.AutoSize = true;
            this.lblRecommendation.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecommendation.Location = new System.Drawing.Point(11, 505);
            this.lblRecommendation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecommendation.Name = "lblRecommendation";
            this.lblRecommendation.Size = new System.Drawing.Size(106, 16);
            this.lblRecommendation.TabIndex = 78;
            this.lblRecommendation.Text = "Recommendation:";
            // 
            // txtConsiderations
            // 
            this.txtConsiderations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsiderations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsiderations.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConsiderations.Location = new System.Drawing.Point(134, 408);
            this.txtConsiderations.Name = "txtConsiderations";
            this.txtConsiderations.Size = new System.Drawing.Size(767, 94);
            this.txtConsiderations.TabIndex = 77;
            this.txtConsiderations.Text = "";
            this.txtConsiderations.TextChanged += new System.EventHandler(this.txtRecognition_TextChanged);
            // 
            // txtTemporaryPermanent
            // 
            this.txtTemporaryPermanent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemporaryPermanent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTemporaryPermanent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTemporaryPermanent.Location = new System.Drawing.Point(134, 310);
            this.txtTemporaryPermanent.Name = "txtTemporaryPermanent";
            this.txtTemporaryPermanent.Size = new System.Drawing.Size(767, 94);
            this.txtTemporaryPermanent.TabIndex = 77;
            this.txtTemporaryPermanent.Text = "";
            this.txtTemporaryPermanent.TextChanged += new System.EventHandler(this.txtRecognition_TextChanged);
            // 
            // txtHypothesisSupport
            // 
            this.txtHypothesisSupport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHypothesisSupport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHypothesisSupport.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHypothesisSupport.Location = new System.Drawing.Point(134, 213);
            this.txtHypothesisSupport.Name = "txtHypothesisSupport";
            this.txtHypothesisSupport.Size = new System.Drawing.Size(766, 94);
            this.txtHypothesisSupport.TabIndex = 77;
            this.txtHypothesisSupport.Text = "";
            this.txtHypothesisSupport.TextChanged += new System.EventHandler(this.txtRecognition_TextChanged);
            // 
            // txtHypothesis
            // 
            this.txtHypothesis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHypothesis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHypothesis.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHypothesis.Location = new System.Drawing.Point(133, 157);
            this.txtHypothesis.Name = "txtHypothesis";
            this.txtHypothesis.Size = new System.Drawing.Size(767, 54);
            this.txtHypothesis.TabIndex = 77;
            this.txtHypothesis.Text = "";
            this.txtHypothesis.TextChanged += new System.EventHandler(this.txtRecognition_TextChanged);
            // 
            // txtRecognition
            // 
            this.txtRecognition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecognition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecognition.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRecognition.Location = new System.Drawing.Point(134, 101);
            this.txtRecognition.Name = "txtRecognition";
            this.txtRecognition.Size = new System.Drawing.Size(767, 54);
            this.txtRecognition.TabIndex = 77;
            this.txtRecognition.Text = "";
            this.txtRecognition.TextChanged += new System.EventHandler(this.txtRecognition_TextChanged);
            // 
            // lblConsiderations
            // 
            this.lblConsiderations.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsiderations.Location = new System.Drawing.Point(11, 408);
            this.lblConsiderations.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConsiderations.Name = "lblConsiderations";
            this.lblConsiderations.Size = new System.Drawing.Size(118, 39);
            this.lblConsiderations.TabIndex = 74;
            this.lblConsiderations.Text = "Special Considerations:";
            // 
            // cboRecommendedWord
            // 
            this.cboRecommendedWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRecommendedWord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRecommendedWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboRecommendedWord.FormattingEnabled = true;
            this.cboRecommendedWord.Location = new System.Drawing.Point(134, 563);
            this.cboRecommendedWord.Name = "cboRecommendedWord";
            this.cboRecommendedWord.Size = new System.Drawing.Size(767, 21);
            this.cboRecommendedWord.TabIndex = 76;
            this.cboRecommendedWord.TextChanged += new System.EventHandler(this.cboSelectedQuarter_TextChanged);
            // 
            // cboSelectedQuarter
            // 
            this.cboSelectedQuarter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSelectedQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectedQuarter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSelectedQuarter.FormattingEnabled = true;
            this.cboSelectedQuarter.Location = new System.Drawing.Point(134, 77);
            this.cboSelectedQuarter.Name = "cboSelectedQuarter";
            this.cboSelectedQuarter.Size = new System.Drawing.Size(767, 21);
            this.cboSelectedQuarter.TabIndex = 76;
            this.cboSelectedQuarter.TextChanged += new System.EventHandler(this.cboSelectedQuarter_TextChanged);
            // 
            // lblTemporaryPermanent
            // 
            this.lblTemporaryPermanent.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemporaryPermanent.Location = new System.Drawing.Point(11, 310);
            this.lblTemporaryPermanent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTemporaryPermanent.Name = "lblTemporaryPermanent";
            this.lblTemporaryPermanent.Size = new System.Drawing.Size(118, 39);
            this.lblTemporaryPermanent.TabIndex = 74;
            this.lblTemporaryPermanent.Text = "Temporary vs. Permanent:";
            // 
            // lblHypothesisSupport
            // 
            this.lblHypothesisSupport.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHypothesisSupport.Location = new System.Drawing.Point(9, 213);
            this.lblHypothesisSupport.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHypothesisSupport.Name = "lblHypothesisSupport";
            this.lblHypothesisSupport.Size = new System.Drawing.Size(118, 39);
            this.lblHypothesisSupport.TabIndex = 74;
            this.lblHypothesisSupport.Text = "Hypothesis Support And Analysis:";
            // 
            // lblHypothesis
            // 
            this.lblHypothesis.AutoSize = true;
            this.lblHypothesis.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHypothesis.Location = new System.Drawing.Point(10, 157);
            this.lblHypothesis.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHypothesis.Name = "lblHypothesis";
            this.lblHypothesis.Size = new System.Drawing.Size(70, 16);
            this.lblHypothesis.TabIndex = 74;
            this.lblHypothesis.Text = "Hypothesis:";
            // 
            // lblBumper
            // 
            this.lblBumper.AutoSize = true;
            this.lblBumper.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBumper.Location = new System.Drawing.Point(11, 674);
            this.lblBumper.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBumper.Name = "lblBumper";
            this.lblBumper.Size = new System.Drawing.Size(11, 16);
            this.lblBumper.TabIndex = 74;
            this.lblBumper.Text = ".";
            // 
            // lblRecommendedWord
            // 
            this.lblRecommendedWord.AutoSize = true;
            this.lblRecommendedWord.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecommendedWord.Location = new System.Drawing.Point(11, 564);
            this.lblRecommendedWord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecommendedWord.Name = "lblRecommendedWord";
            this.lblRecommendedWord.Size = new System.Drawing.Size(111, 16);
            this.lblRecommendedWord.TabIndex = 74;
            this.lblRecommendedWord.Text = "Recommend Word:";
            // 
            // lblQuarter
            // 
            this.lblQuarter.AutoSize = true;
            this.lblQuarter.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuarter.Location = new System.Drawing.Point(11, 78);
            this.lblQuarter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuarter.Name = "lblQuarter";
            this.lblQuarter.Size = new System.Drawing.Size(51, 16);
            this.lblQuarter.TabIndex = 74;
            this.lblQuarter.Text = "Quarter:";
            // 
            // lblRecognition
            // 
            this.lblRecognition.AutoSize = true;
            this.lblRecognition.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecognition.Location = new System.Drawing.Point(11, 101);
            this.lblRecognition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecognition.Name = "lblRecognition";
            this.lblRecognition.Size = new System.Drawing.Size(75, 16);
            this.lblRecognition.TabIndex = 74;
            this.lblRecognition.Text = "Recognition:";
            // 
            // txtDateApproved
            // 
            this.txtDateApproved.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateApproved.Location = new System.Drawing.Point(134, 588);
            this.txtDateApproved.Name = "txtDateApproved";
            this.txtDateApproved.Size = new System.Drawing.Size(767, 20);
            this.txtDateApproved.TabIndex = 73;
            this.txtDateApproved.TextChanged += new System.EventHandler(this.txtRecognition_TextChanged);
            // 
            // lblDateApproved
            // 
            this.lblDateApproved.AutoSize = true;
            this.lblDateApproved.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateApproved.Location = new System.Drawing.Point(11, 588);
            this.lblDateApproved.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateApproved.Name = "lblDateApproved";
            this.lblDateApproved.Size = new System.Drawing.Size(90, 16);
            this.lblDateApproved.TabIndex = 74;
            this.lblDateApproved.Text = "Date Approved:";
            // 
            // txtDatePresented
            // 
            this.txtDatePresented.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatePresented.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDatePresented.Location = new System.Drawing.Point(134, 611);
            this.txtDatePresented.Name = "txtDatePresented";
            this.txtDatePresented.Size = new System.Drawing.Size(767, 20);
            this.txtDatePresented.TabIndex = 73;
            this.txtDatePresented.TextChanged += new System.EventHandler(this.txtRecognition_TextChanged);
            // 
            // lblDatePresented
            // 
            this.lblDatePresented.AutoSize = true;
            this.lblDatePresented.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatePresented.Location = new System.Drawing.Point(11, 611);
            this.lblDatePresented.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDatePresented.Name = "lblDatePresented";
            this.lblDatePresented.Size = new System.Drawing.Size(90, 16);
            this.lblDatePresented.TabIndex = 74;
            this.lblDatePresented.Text = "Date Presented:";
            // 
            // txtPlan
            // 
            this.txtPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlan.Enabled = false;
            this.txtPlan.Location = new System.Drawing.Point(134, 31);
            this.txtPlan.Name = "txtPlan";
            this.txtPlan.Size = new System.Drawing.Size(767, 20);
            this.txtPlan.TabIndex = 73;
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlan.Location = new System.Drawing.Point(11, 31);
            this.lblPlan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(34, 16);
            this.lblPlan.TabIndex = 74;
            this.lblPlan.Text = "Plan:";
            // 
            // txtFund
            // 
            this.txtFund.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFund.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFund.Enabled = false;
            this.txtFund.Location = new System.Drawing.Point(134, 9);
            this.txtFund.Name = "txtFund";
            this.txtFund.Size = new System.Drawing.Size(767, 20);
            this.txtFund.TabIndex = 73;
            // 
            // lblFund
            // 
            this.lblFund.AutoSize = true;
            this.lblFund.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFund.Location = new System.Drawing.Point(11, 8);
            this.lblFund.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFund.Name = "lblFund";
            this.lblFund.Size = new System.Drawing.Size(38, 16);
            this.lblFund.TabIndex = 74;
            this.lblFund.Text = "Fund:";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("High Tower Text", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(5, 8);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(435, 45);
            this.lblHeader.TabIndex = 76;
            this.lblHeader.Text = "Probation Analysis Review";
            this.lblHeader.DoubleClick += new System.EventHandler(this.lblHeader_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboSelectedReview);
            this.panel1.Controls.Add(this.lblSelectedReview);
            this.panel1.Controls.Add(this.btnNewProbationAnalysis);
            this.panel1.Location = new System.Drawing.Point(-1, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 37);
            this.panel1.TabIndex = 75;
            // 
            // cboSelectedReview
            // 
            this.cboSelectedReview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSelectedReview.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectedReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSelectedReview.FormattingEnabled = true;
            this.cboSelectedReview.Location = new System.Drawing.Point(133, 7);
            this.cboSelectedReview.Name = "cboSelectedReview";
            this.cboSelectedReview.Size = new System.Drawing.Size(743, 21);
            this.cboSelectedReview.TabIndex = 76;
            this.cboSelectedReview.SelectedIndexChanged += new System.EventHandler(this.cboSelectedReview_SelectedIndexChanged);
            // 
            // lblSelectedReview
            // 
            this.lblSelectedReview.AutoSize = true;
            this.lblSelectedReview.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedReview.ForeColor = System.Drawing.Color.White;
            this.lblSelectedReview.Location = new System.Drawing.Point(10, 8);
            this.lblSelectedReview.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedReview.Name = "lblSelectedReview";
            this.lblSelectedReview.Size = new System.Drawing.Size(95, 16);
            this.lblSelectedReview.TabIndex = 74;
            this.lblSelectedReview.Text = "Selected Review:";
            // 
            // btnNewProbationAnalysis
            // 
            this.btnNewProbationAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewProbationAnalysis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNewProbationAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewProbationAnalysis.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewProbationAnalysis.ForeColor = System.Drawing.Color.Black;
            this.btnNewProbationAnalysis.Location = new System.Drawing.Point(881, 5);
            this.btnNewProbationAnalysis.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewProbationAnalysis.Name = "btnNewProbationAnalysis";
            this.btnNewProbationAnalysis.Size = new System.Drawing.Size(57, 24);
            this.btnNewProbationAnalysis.TabIndex = 13;
            this.btnNewProbationAnalysis.Text = "New";
            this.btnNewProbationAnalysis.UseVisualStyleBackColor = false;
            this.btnNewProbationAnalysis.Click += new System.EventHandler(this.btnNewProbationAnalysis_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Gadugi", 12F);
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(97, 606);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 32);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Gadugi", 12F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(860, 606);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 32);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Gadugi", 12F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(12, 606);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 32);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ProbationAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 675);
            this.Controls.Add(this.pnlBackground);
            this.Controls.Add(this.pnlFormHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProbationAnalysisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProbationAnalysisForm";
            this.pnlFormHeader.ResumeLayout(false);
            this.pnlFormHeader.PerformLayout();
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.pnlFields.ResumeLayout(false);
            this.pnlFields.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFormHeader;
        private System.Windows.Forms.Label lblFormMinimize;
        private System.Windows.Forms.Label lblFormClose;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSelectedReview;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label lblFund;
        public System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblQuarter;
        private System.Windows.Forms.RichTextBox txtRecognition;
        private System.Windows.Forms.Button btnNewProbationAnalysis;
        private System.Windows.Forms.Label lblRecognition;
        private System.Windows.Forms.RichTextBox txtHypothesisSupport;
        private System.Windows.Forms.RichTextBox txtHypothesis;
        private System.Windows.Forms.Label lblHypothesisSupport;
        private System.Windows.Forms.Label lblHypothesis;
        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.RichTextBox txtRecommendation;
        private System.Windows.Forms.Label lblRecommendation;
        private System.Windows.Forms.RichTextBox txtConsiderations;
        private System.Windows.Forms.RichTextBox txtTemporaryPermanent;
        private System.Windows.Forms.Label lblConsiderations;
        private System.Windows.Forms.Label lblTemporaryPermanent;
        private System.Windows.Forms.Label lblBumper;
        private System.Windows.Forms.Label lblRecommendedWord;
        private System.Windows.Forms.TextBox txtDateApproved;
        private System.Windows.Forms.Label lblDateApproved;
        private System.Windows.Forms.TextBox txtDatePresented;
        private System.Windows.Forms.Label lblDatePresented;
        public System.Windows.Forms.ComboBox cboSelectedReview;
        public System.Windows.Forms.TextBox txtPlan;
        public System.Windows.Forms.TextBox txtFund;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.ComboBox cboSelectedQuarter;
        public System.Windows.Forms.ComboBox cboRecommendedWord;
        public System.Windows.Forms.Label lblFormHeader;
        public System.Windows.Forms.ComboBox cboOwner;
        private System.Windows.Forms.Label lblOwner;
    }
}