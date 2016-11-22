namespace ISP.Presentation.Forms
{
    partial class frmError
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtErrorDescription = new System.Windows.Forms.TextBox();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnReportError = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExceptionMessage = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Salmon;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 65);
            this.panel1.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("High Tower Text", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(6, 6);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 57);
            this.label10.TabIndex = 19;
            this.label10.Text = "Error!";
            // 
            // txtErrorDescription
            // 
            this.txtErrorDescription.Location = new System.Drawing.Point(8, 284);
            this.txtErrorDescription.Multiline = true;
            this.txtErrorDescription.Name = "txtErrorDescription";
            this.txtErrorDescription.Size = new System.Drawing.Size(419, 129);
            this.txtErrorDescription.TabIndex = 23;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.Location = new System.Drawing.Point(324, 421);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(103, 39);
            this.btnCloseForm.TabIndex = 24;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnReportError
            // 
            this.btnReportError.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnReportError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportError.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportError.Location = new System.Drawing.Point(215, 421);
            this.btnReportError.Name = "btnReportError";
            this.btnReportError.Size = new System.Drawing.Size(103, 39);
            this.btnReportError.TabIndex = 24;
            this.btnReportError.Text = "Report Error";
            this.btnReportError.UseVisualStyleBackColor = false;
            this.btnReportError.Click += new System.EventHandler(this.btnReportError_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(424, 45);
            this.label2.TabIndex = 20;
            this.label2.Text = "The following error occurred while you were using the Investment Services Program" +
    ":";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(4, 233);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(423, 48);
            this.label3.TabIndex = 20;
            this.label3.Text = "Please take a moment to describe what you were doing when this error occurred (op" +
    "tional):";
            // 
            // txtExceptionMessage
            // 
            this.txtExceptionMessage.Enabled = false;
            this.txtExceptionMessage.Location = new System.Drawing.Point(8, 114);
            this.txtExceptionMessage.Multiline = true;
            this.txtExceptionMessage.Name = "txtExceptionMessage";
            this.txtExceptionMessage.ReadOnly = true;
            this.txtExceptionMessage.Size = new System.Drawing.Size(419, 106);
            this.txtExceptionMessage.TabIndex = 23;
            // 
            // frmError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(436, 471);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReportError);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.txtExceptionMessage);
            this.Controls.Add(this.txtErrorDescription);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportErrorForm";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtErrorDescription;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnReportError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtExceptionMessage;
    }
}