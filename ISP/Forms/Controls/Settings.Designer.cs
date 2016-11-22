namespace ISP.Forms.Controls
{
    public partial class Settings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel31 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.cboSmTable = new System.Windows.Forms.ComboBox();
            this.cboSmColumn = new System.Windows.Forms.ComboBox();
            this.txtSmValue = new System.Windows.Forms.TextBox();
            this.btnSmDelete = new System.Windows.Forms.Button();
            this.btnSmInsert = new System.Windows.Forms.Button();
            this.btnSmUpdate = new System.Windows.Forms.Button();
            this.lstStringMapValues = new System.Windows.Forms.ListBox();
            this.lblSmValue = new System.Windows.Forms.Label();
            this.lblSmTable = new System.Windows.Forms.Label();
            this.lblSmColumn = new System.Windows.Forms.Label();
            this.panel31.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel31
            // 
            this.panel31.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel31.Controls.Add(this.label19);
            this.panel31.Controls.Add(this.cboSmTable);
            this.panel31.Controls.Add(this.cboSmColumn);
            this.panel31.Controls.Add(this.txtSmValue);
            this.panel31.Controls.Add(this.btnSmDelete);
            this.panel31.Controls.Add(this.btnSmInsert);
            this.panel31.Controls.Add(this.btnSmUpdate);
            this.panel31.Controls.Add(this.lstStringMapValues);
            this.panel31.Controls.Add(this.lblSmValue);
            this.panel31.Controls.Add(this.lblSmTable);
            this.panel31.Controls.Add(this.lblSmColumn);
            this.panel31.Location = new System.Drawing.Point(0, 0);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(961, 402);
            this.panel31.TabIndex = 29;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Cursor = System.Windows.Forms.Cursors.Default;
            this.label19.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(7, 7);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(296, 22);
            this.label19.TabIndex = 3;
            this.label19.Text = "Edit Values Available for Selection";
            // 
            // cboSmTable
            // 
            this.cboSmTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSmTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSmTable.FormattingEnabled = true;
            this.cboSmTable.Location = new System.Drawing.Point(142, 37);
            this.cboSmTable.Name = "cboSmTable";
            this.cboSmTable.Size = new System.Drawing.Size(297, 21);
            this.cboSmTable.TabIndex = 33;
            this.cboSmTable.SelectedIndexChanged += new System.EventHandler(this.cboSmTable_SelectedIndexChanged);
            // 
            // cboSmColumn
            // 
            this.cboSmColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSmColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSmColumn.FormattingEnabled = true;
            this.cboSmColumn.Location = new System.Drawing.Point(142, 64);
            this.cboSmColumn.Name = "cboSmColumn";
            this.cboSmColumn.Size = new System.Drawing.Size(297, 21);
            this.cboSmColumn.TabIndex = 33;
            this.cboSmColumn.SelectedIndexChanged += new System.EventHandler(this.cboSmColumn_SelectedIndexChanged);
            // 
            // txtSmValue
            // 
            this.txtSmValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSmValue.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSmValue.Location = new System.Drawing.Point(541, 333);
            this.txtSmValue.Name = "txtSmValue";
            this.txtSmValue.Size = new System.Drawing.Size(408, 25);
            this.txtSmValue.TabIndex = 32;
            // 
            // btnSmDelete
            // 
            this.btnSmDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSmDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSmDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSmDelete.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSmDelete.ForeColor = System.Drawing.Color.Black;
            this.btnSmDelete.Location = new System.Drawing.Point(855, 363);
            this.btnSmDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnSmDelete.Name = "btnSmDelete";
            this.btnSmDelete.Size = new System.Drawing.Size(94, 26);
            this.btnSmDelete.TabIndex = 31;
            this.btnSmDelete.Text = "Delete";
            this.btnSmDelete.UseVisualStyleBackColor = false;
            this.btnSmDelete.Click += new System.EventHandler(this.btnSmDelete_Click);
            // 
            // btnSmInsert
            // 
            this.btnSmInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSmInsert.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSmInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSmInsert.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSmInsert.ForeColor = System.Drawing.Color.Black;
            this.btnSmInsert.Location = new System.Drawing.Point(757, 363);
            this.btnSmInsert.Margin = new System.Windows.Forms.Padding(2);
            this.btnSmInsert.Name = "btnSmInsert";
            this.btnSmInsert.Size = new System.Drawing.Size(94, 26);
            this.btnSmInsert.TabIndex = 31;
            this.btnSmInsert.Text = "Save As New";
            this.btnSmInsert.UseVisualStyleBackColor = false;
            this.btnSmInsert.Click += new System.EventHandler(this.btnSmInsert_Click);
            // 
            // btnSmUpdate
            // 
            this.btnSmUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSmUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSmUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSmUpdate.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSmUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnSmUpdate.Location = new System.Drawing.Point(659, 363);
            this.btnSmUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnSmUpdate.Name = "btnSmUpdate";
            this.btnSmUpdate.Size = new System.Drawing.Size(94, 26);
            this.btnSmUpdate.TabIndex = 31;
            this.btnSmUpdate.Text = "Update";
            this.btnSmUpdate.UseVisualStyleBackColor = false;
            this.btnSmUpdate.Click += new System.EventHandler(this.btnSmUpdate_Click);
            // 
            // lstStringMapValues
            // 
            this.lstStringMapValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStringMapValues.FormattingEnabled = true;
            this.lstStringMapValues.Location = new System.Drawing.Point(445, 37);
            this.lstStringMapValues.Name = "lstStringMapValues";
            this.lstStringMapValues.Size = new System.Drawing.Size(504, 290);
            this.lstStringMapValues.TabIndex = 1;
            this.lstStringMapValues.SelectedIndexChanged += new System.EventHandler(this.lstStringMapValues_SelectedIndexChanged);
            // 
            // lblSmValue
            // 
            this.lblSmValue.AutoSize = true;
            this.lblSmValue.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSmValue.Location = new System.Drawing.Point(442, 336);
            this.lblSmValue.Name = "lblSmValue";
            this.lblSmValue.Size = new System.Drawing.Size(93, 16);
            this.lblSmValue.TabIndex = 0;
            this.lblSmValue.Text = "Selected Value";
            // 
            // lblSmTable
            // 
            this.lblSmTable.AutoSize = true;
            this.lblSmTable.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSmTable.Location = new System.Drawing.Point(11, 38);
            this.lblSmTable.Name = "lblSmTable";
            this.lblSmTable.Size = new System.Drawing.Size(98, 16);
            this.lblSmTable.TabIndex = 0;
            this.lblSmTable.Text = "DataBase Table";
            // 
            // lblSmColumn
            // 
            this.lblSmColumn.AutoSize = true;
            this.lblSmColumn.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSmColumn.Location = new System.Drawing.Point(11, 65);
            this.lblSmColumn.Name = "lblSmColumn";
            this.lblSmColumn.Size = new System.Drawing.Size(110, 16);
            this.lblSmColumn.TabIndex = 0;
            this.lblSmColumn.Text = "DataBase Column";
            // 
            // pnlSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel31);
            this.Name = "pnlSettings";
            this.Size = new System.Drawing.Size(961, 402);
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboSmColumn;
        private System.Windows.Forms.TextBox txtSmValue;
        private System.Windows.Forms.Button btnSmDelete;
        private System.Windows.Forms.Button btnSmInsert;
        private System.Windows.Forms.Button btnSmUpdate;
        private System.Windows.Forms.ListBox lstStringMapValues;
        private System.Windows.Forms.Label lblSmValue;
        private System.Windows.Forms.Label lblSmTable;
        private System.Windows.Forms.Label lblSmColumn;
        public System.Windows.Forms.ComboBox cboSmTable;
    }
}
