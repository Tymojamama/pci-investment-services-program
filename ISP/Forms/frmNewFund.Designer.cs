namespace ISP.Presentation.Forms
{
    partial class frmNewFund
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
            this.cboRecordType = new System.Windows.Forms.ComboBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblRecordType = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCusip = new System.Windows.Forms.TextBox();
            this.txtFamily = new System.Windows.Forms.TextBox();
            this.lblCusip = new System.Windows.Forms.Label();
            this.lblFamily = new System.Windows.Forms.Label();
            this.txtTicker = new System.Windows.Forms.TextBox();
            this.lblTicker = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlFormHeader.SuspendLayout();
            this.pnlBackground.SuspendLayout();
            this.pnlFields.SuspendLayout();
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
            this.pnlFormHeader.Size = new System.Drawing.Size(505, 27);
            this.pnlFormHeader.TabIndex = 60;
            this.pnlFormHeader.DoubleClick += new System.EventHandler(this.pnlFormHeader_DoubleClick);
            // 
            // lblFormMinimize
            // 
            this.lblFormMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormMinimize.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblFormMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormMinimize.ForeColor = System.Drawing.Color.White;
            this.lblFormMinimize.Location = new System.Drawing.Point(449, 1);
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
            this.lblFormClose.Location = new System.Drawing.Point(477, 1);
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
            this.lblFormHeader.Size = new System.Drawing.Size(247, 16);
            this.lblFormHeader.TabIndex = 23;
            this.lblFormHeader.Text = "Investment Services Program - New Fund";
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
            this.pnlBackground.Controls.Add(this.btnSave);
            this.pnlBackground.Location = new System.Drawing.Point(0, 25);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(505, 295);
            this.pnlBackground.TabIndex = 61;
            this.pnlBackground.DoubleClick += new System.EventHandler(this.pnlBackground_DoubleClick);
            // 
            // pnlFields
            // 
            this.pnlFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFields.Controls.Add(this.cboRecordType);
            this.pnlFields.Controls.Add(this.cboCategory);
            this.pnlFields.Controls.Add(this.lblRecordType);
            this.pnlFields.Controls.Add(this.lblCategory);
            this.pnlFields.Controls.Add(this.txtCusip);
            this.pnlFields.Controls.Add(this.txtFamily);
            this.pnlFields.Controls.Add(this.lblCusip);
            this.pnlFields.Controls.Add(this.lblFamily);
            this.pnlFields.Controls.Add(this.txtTicker);
            this.pnlFields.Controls.Add(this.lblTicker);
            this.pnlFields.Controls.Add(this.txtName);
            this.pnlFields.Controls.Add(this.lblName);
            this.pnlFields.Location = new System.Drawing.Point(-1, 63);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(505, 175);
            this.pnlFields.TabIndex = 78;
            this.pnlFields.Click += new System.EventHandler(this.pnlFields_Click);
            // 
            // cboRecordType
            // 
            this.cboRecordType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRecordType.BackColor = System.Drawing.SystemColors.Window;
            this.cboRecordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRecordType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboRecordType.FormattingEnabled = true;
            this.cboRecordType.Items.AddRange(new object[] {
            "",
            "Fund",
            "Index",
            "Category"});
            this.cboRecordType.Location = new System.Drawing.Point(98, 138);
            this.cboRecordType.Name = "cboRecordType";
            this.cboRecordType.Size = new System.Drawing.Size(395, 21);
            this.cboRecordType.TabIndex = 75;
            this.cboRecordType.SelectedIndexChanged += new System.EventHandler(this.cboAdvisor_SelectedIndexChanged);
            // 
            // cboCategory
            // 
            this.cboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategory.BackColor = System.Drawing.SystemColors.Window;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(98, 112);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(395, 21);
            this.cboCategory.TabIndex = 75;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboAdvisor_SelectedIndexChanged);
            // 
            // lblRecordType
            // 
            this.lblRecordType.AutoSize = true;
            this.lblRecordType.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordType.Location = new System.Drawing.Point(11, 139);
            this.lblRecordType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordType.Name = "lblRecordType";
            this.lblRecordType.Size = new System.Drawing.Size(74, 16);
            this.lblRecordType.TabIndex = 74;
            this.lblRecordType.Text = "Record Type";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(11, 112);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(56, 16);
            this.lblCategory.TabIndex = 74;
            this.lblCategory.Text = "Category";
            // 
            // txtCusip
            // 
            this.txtCusip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCusip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCusip.Location = new System.Drawing.Point(98, 87);
            this.txtCusip.Multiline = true;
            this.txtCusip.Name = "txtCusip";
            this.txtCusip.Size = new System.Drawing.Size(396, 20);
            this.txtCusip.TabIndex = 73;
            this.txtCusip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // txtFamily
            // 
            this.txtFamily.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFamily.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFamily.Location = new System.Drawing.Point(98, 61);
            this.txtFamily.Multiline = true;
            this.txtFamily.Name = "txtFamily";
            this.txtFamily.Size = new System.Drawing.Size(396, 20);
            this.txtFamily.TabIndex = 73;
            this.txtFamily.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // lblCusip
            // 
            this.lblCusip.AutoSize = true;
            this.lblCusip.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusip.Location = new System.Drawing.Point(11, 86);
            this.lblCusip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCusip.Name = "lblCusip";
            this.lblCusip.Size = new System.Drawing.Size(40, 16);
            this.lblCusip.TabIndex = 74;
            this.lblCusip.Text = "CUSIP";
            // 
            // lblFamily
            // 
            this.lblFamily.AutoSize = true;
            this.lblFamily.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFamily.Location = new System.Drawing.Point(11, 60);
            this.lblFamily.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFamily.Name = "lblFamily";
            this.lblFamily.Size = new System.Drawing.Size(43, 16);
            this.lblFamily.TabIndex = 74;
            this.lblFamily.Text = "Family";
            // 
            // txtTicker
            // 
            this.txtTicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTicker.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTicker.Location = new System.Drawing.Point(98, 35);
            this.txtTicker.Multiline = true;
            this.txtTicker.Name = "txtTicker";
            this.txtTicker.Size = new System.Drawing.Size(396, 20);
            this.txtTicker.TabIndex = 73;
            this.txtTicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // lblTicker
            // 
            this.lblTicker.AutoSize = true;
            this.lblTicker.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicker.Location = new System.Drawing.Point(11, 34);
            this.lblTicker.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTicker.Name = "lblTicker";
            this.lblTicker.Size = new System.Drawing.Size(40, 16);
            this.lblTicker.TabIndex = 74;
            this.lblTicker.Text = "Ticker";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Location = new System.Drawing.Point(98, 9);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(396, 20);
            this.txtName.TabIndex = 73;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(11, 8);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(40, 16);
            this.lblName.TabIndex = 74;
            this.lblName.Text = "Name";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("High Tower Text", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(5, 8);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(184, 45);
            this.lblHeader.TabIndex = 76;
            this.lblHeader.Text = "New Fund";
            this.lblHeader.DoubleClick += new System.EventHandler(this.lblHeader_DoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Gadugi", 12F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(412, 251);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 32);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmNewFund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 320);
            this.Controls.Add(this.pnlBackground);
            this.Controls.Add(this.pnlFormHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNewFund";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProbationAnalysisForm";
            this.pnlFormHeader.ResumeLayout(false);
            this.pnlFormHeader.PerformLayout();
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.pnlFields.ResumeLayout(false);
            this.pnlFields.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFormHeader;
        private System.Windows.Forms.Label lblFormMinimize;
        private System.Windows.Forms.Label lblFormClose;
        private System.Windows.Forms.Panel pnlBackground;
        public System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Label lblFormHeader;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cboRecordType;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblRecordType;
        private System.Windows.Forms.Label lblCategory;
        public System.Windows.Forms.TextBox txtFamily;
        private System.Windows.Forms.Label lblFamily;
        public System.Windows.Forms.TextBox txtTicker;
        private System.Windows.Forms.Label lblTicker;
        public System.Windows.Forms.TextBox txtCusip;
        private System.Windows.Forms.Label lblCusip;
    }
}