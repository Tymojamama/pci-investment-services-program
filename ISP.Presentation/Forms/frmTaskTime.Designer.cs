namespace ISP.Presentation.Forms
{
    partial class frmTaskTime
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
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnTimeReset = new System.Windows.Forms.Button();
            this.btnTimeStart = new System.Windows.Forms.Button();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label48 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.pnlMainHeader = new System.Windows.Forms.Panel();
            this.lblMinForm = new System.Windows.Forms.Label();
            this.lblCloseForm = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.pnlMainHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel12
            // 
            this.panel12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel12.BackColor = System.Drawing.Color.Gainsboro;
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.btnTimeReset);
            this.panel12.Controls.Add(this.btnTimeStart);
            this.panel12.Controls.Add(this.txtTaskName);
            this.panel12.Controls.Add(this.label54);
            this.panel12.Controls.Add(this.txtNotes);
            this.panel12.Controls.Add(this.label53);
            this.panel12.Controls.Add(this.txtDuration);
            this.panel12.Controls.Add(this.label52);
            this.panel12.Controls.Add(this.txtEndDate);
            this.panel12.Controls.Add(this.label51);
            this.panel12.Controls.Add(this.txtStartDate);
            this.panel12.Controls.Add(this.label50);
            this.panel12.Controls.Add(this.btnCancel);
            this.panel12.Controls.Add(this.btnSave);
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Controls.Add(this.txtDescription);
            this.panel12.Controls.Add(this.label49);
            this.panel12.Location = new System.Drawing.Point(0, 26);
            this.panel12.Margin = new System.Windows.Forms.Padding(2);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(461, 247);
            this.panel12.TabIndex = 69;
            // 
            // btnTimeReset
            // 
            this.btnTimeReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimeReset.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTimeReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimeReset.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimeReset.Location = new System.Drawing.Point(182, 210);
            this.btnTimeReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimeReset.Name = "btnTimeReset";
            this.btnTimeReset.Size = new System.Drawing.Size(56, 26);
            this.btnTimeReset.TabIndex = 81;
            this.btnTimeReset.Text = "Reset";
            this.btnTimeReset.UseVisualStyleBackColor = false;
            this.btnTimeReset.Click += new System.EventHandler(this.btnTimeReset_Click);
            // 
            // btnTimeStart
            // 
            this.btnTimeStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimeStart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTimeStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimeStart.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimeStart.Location = new System.Drawing.Point(122, 210);
            this.btnTimeStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimeStart.Name = "btnTimeStart";
            this.btnTimeStart.Size = new System.Drawing.Size(56, 26);
            this.btnTimeStart.TabIndex = 82;
            this.btnTimeStart.Text = "Start";
            this.btnTimeStart.UseVisualStyleBackColor = false;
            this.btnTimeStart.Click += new System.EventHandler(this.btnTimeStart_Click);
            // 
            // txtTaskName
            // 
            this.txtTaskName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaskName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTaskName.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaskName.Location = new System.Drawing.Point(122, 40);
            this.txtTaskName.Margin = new System.Windows.Forms.Padding(2);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.ReadOnly = true;
            this.txtTaskName.Size = new System.Drawing.Size(327, 18);
            this.txtTaskName.TabIndex = 80;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(7, 40);
            this.label54.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(99, 16);
            this.label54.TabIndex = 79;
            this.label54.Text = "Regarding Task";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotes.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(122, 145);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(2);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(327, 61);
            this.txtNotes.TabIndex = 71;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(7, 144);
            this.label53.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(43, 16);
            this.label53.TabIndex = 78;
            this.label53.Text = "Notes";
            // 
            // txtDuration
            // 
            this.txtDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuration.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDuration.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuration.Location = new System.Drawing.Point(122, 124);
            this.txtDuration.Margin = new System.Windows.Forms.Padding(2);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(327, 18);
            this.txtDuration.TabIndex = 77;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(7, 124);
            this.label52.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(58, 16);
            this.label52.TabIndex = 76;
            this.label52.Text = "Duration";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEndDate.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(122, 103);
            this.txtEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(327, 18);
            this.txtEndDate.TabIndex = 75;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(7, 103);
            this.label51.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(61, 16);
            this.label51.TabIndex = 74;
            this.label51.Text = "End Date";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStartDate.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartDate.Location = new System.Drawing.Point(122, 82);
            this.txtStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(327, 18);
            this.txtStartDate.TabIndex = 73;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(7, 82);
            this.label50.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(66, 16);
            this.label50.TabIndex = 72;
            this.label50.Text = "Start Date";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(393, 210);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 26);
            this.btnCancel.TabIndex = 71;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(332, 210);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 26);
            this.btnSave.TabIndex = 71;
            this.btnSave.Text = "Submit";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel13
            // 
            this.panel13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.label48);
            this.panel13.Font = new System.Drawing.Font("High Tower Text", 32F);
            this.panel13.Location = new System.Drawing.Point(-1, -1);
            this.panel13.Margin = new System.Windows.Forms.Padding(2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(461, 37);
            this.panel13.TabIndex = 69;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("High Tower Text", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.Color.Black;
            this.label48.Location = new System.Drawing.Point(2, 2);
            this.label48.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(138, 32);
            this.label48.TabIndex = 0;
            this.label48.Text = "Task Time";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(122, 61);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(327, 18);
            this.txtDescription.TabIndex = 26;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(7, 61);
            this.label49.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(74, 16);
            this.label49.TabIndex = 24;
            this.label49.Text = "Description";
            // 
            // pnlMainHeader
            // 
            this.pnlMainHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlMainHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMainHeader.Controls.Add(this.lblMinForm);
            this.pnlMainHeader.Controls.Add(this.lblCloseForm);
            this.pnlMainHeader.Controls.Add(this.label39);
            this.pnlMainHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlMainHeader.Name = "pnlMainHeader";
            this.pnlMainHeader.Size = new System.Drawing.Size(461, 27);
            this.pnlMainHeader.TabIndex = 70;
            // 
            // lblMinForm
            // 
            this.lblMinForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinForm.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblMinForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinForm.ForeColor = System.Drawing.Color.White;
            this.lblMinForm.Location = new System.Drawing.Point(405, 1);
            this.lblMinForm.Name = "lblMinForm";
            this.lblMinForm.Size = new System.Drawing.Size(25, 25);
            this.lblMinForm.TabIndex = 22;
            this.lblMinForm.Text = "-";
            this.lblMinForm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblMinForm.Click += new System.EventHandler(this.lblMinForm_Click);
            this.lblMinForm.MouseEnter += new System.EventHandler(this.CloseFormButton_MouseEnter);
            this.lblMinForm.MouseLeave += new System.EventHandler(this.CloseFormButton_MouseLeave);
            // 
            // lblCloseForm
            // 
            this.lblCloseForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCloseForm.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloseForm.ForeColor = System.Drawing.Color.White;
            this.lblCloseForm.Location = new System.Drawing.Point(433, 1);
            this.lblCloseForm.Name = "lblCloseForm";
            this.lblCloseForm.Size = new System.Drawing.Size(25, 25);
            this.lblCloseForm.TabIndex = 22;
            this.lblCloseForm.Text = "x";
            this.lblCloseForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCloseForm.Click += new System.EventHandler(this.lblCloseForm_Click);
            this.lblCloseForm.MouseEnter += new System.EventHandler(this.CloseFormButton_MouseEnter);
            this.lblCloseForm.MouseLeave += new System.EventHandler(this.CloseFormButton_MouseLeave);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.White;
            this.label39.Location = new System.Drawing.Point(4, 5);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(176, 16);
            this.label39.TabIndex = 23;
            this.label39.Text = "Investment Services Program";
            // 
            // frmTaskTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 273);
            this.Controls.Add(this.pnlMainHeader);
            this.Controls.Add(this.panel12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTaskTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaskTimeForm";
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.pnlMainHeader.ResumeLayout(false);
            this.pnlMainHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel13;
        public System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        public System.Windows.Forms.TextBox txtTaskName;
        public System.Windows.Forms.TextBox txtNotes;
        public System.Windows.Forms.TextBox txtDuration;
        public System.Windows.Forms.TextBox txtEndDate;
        public System.Windows.Forms.TextBox txtStartDate;
        public System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel pnlMainHeader;
        private System.Windows.Forms.Label lblMinForm;
        private System.Windows.Forms.Label lblCloseForm;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button btnTimeReset;
        private System.Windows.Forms.Button btnTimeStart;
    }
}