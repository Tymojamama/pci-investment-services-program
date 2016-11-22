namespace ISP.Forms.Controls
{
    partial class Clients
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlClients = new System.Windows.Forms.Panel();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.lblClntViews = new System.Windows.Forms.Label();
            this.lblCurrentClient = new System.Windows.Forms.Label();
            this.cboClientViews = new System.Windows.Forms.ComboBox();
            this.btnOpenClient = new System.Windows.Forms.Button();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.lblSrchClnts = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClients
            // 
            this.pnlClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlClients.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlClients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlClients.Controls.Add(this.btnNextPage);
            this.pnlClients.Controls.Add(this.btnPreviousPage);
            this.pnlClients.Controls.Add(this.lblClntViews);
            this.pnlClients.Controls.Add(this.lblCurrentClient);
            this.pnlClients.Controls.Add(this.cboClientViews);
            this.pnlClients.Controls.Add(this.btnOpenClient);
            this.pnlClients.Controls.Add(this.dgvClients);
            this.pnlClients.Controls.Add(this.lblSrchClnts);
            this.pnlClients.Controls.Add(this.txtSearch);
            this.pnlClients.Location = new System.Drawing.Point(0, 0);
            this.pnlClients.Name = "pnlClients";
            this.pnlClients.Size = new System.Drawing.Size(995, 457);
            this.pnlClients.TabIndex = 25;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNextPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPage.Location = new System.Drawing.Point(494, 418);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(29, 32);
            this.btnNextPage.TabIndex = 24;
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = false;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPreviousPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousPage.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousPage.Location = new System.Drawing.Point(459, 418);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(29, 32);
            this.btnPreviousPage.TabIndex = 24;
            this.btnPreviousPage.Text = "<";
            this.btnPreviousPage.UseVisualStyleBackColor = false;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // lblClntViews
            // 
            this.lblClntViews.AutoSize = true;
            this.lblClntViews.BackColor = System.Drawing.Color.Transparent;
            this.lblClntViews.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClntViews.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblClntViews.Location = new System.Drawing.Point(4, 6);
            this.lblClntViews.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClntViews.Name = "lblClntViews";
            this.lblClntViews.Size = new System.Drawing.Size(41, 16);
            this.lblClntViews.TabIndex = 19;
            this.lblClntViews.Text = "Views";
            // 
            // lblCurrentClient
            // 
            this.lblCurrentClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurrentClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCurrentClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCurrentClient.Font = new System.Drawing.Font("Gadugi", 12F);
            this.lblCurrentClient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCurrentClient.Location = new System.Drawing.Point(7, 418);
            this.lblCurrentClient.Name = "lblCurrentClient";
            this.lblCurrentClient.Size = new System.Drawing.Size(446, 32);
            this.lblCurrentClient.TabIndex = 23;
            this.lblCurrentClient.Text = "Select an account";
            this.lblCurrentClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboClientViews
            // 
            this.cboClientViews.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClientViews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboClientViews.Items.AddRange(new object[] {
            "Active Clients",
            "Active 3(21) Clients",
            "Active 3(38) Clients",
            "Active RC Clients"});
            this.cboClientViews.Location = new System.Drawing.Point(49, 4);
            this.cboClientViews.Margin = new System.Windows.Forms.Padding(2);
            this.cboClientViews.Name = "cboClientViews";
            this.cboClientViews.Size = new System.Drawing.Size(157, 21);
            this.cboClientViews.TabIndex = 16;
            this.cboClientViews.SelectedIndexChanged += new System.EventHandler(this.cboClientViews_SelectedIndexChanged);
            // 
            // btnOpenClient
            // 
            this.btnOpenClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOpenClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenClient.Font = new System.Drawing.Font("Gadugi", 12F);
            this.btnOpenClient.ForeColor = System.Drawing.Color.Black;
            this.btnOpenClient.Location = new System.Drawing.Point(905, 416);
            this.btnOpenClient.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenClient.Name = "btnOpenClient";
            this.btnOpenClient.Size = new System.Drawing.Size(78, 32);
            this.btnOpenClient.TabIndex = 22;
            this.btnOpenClient.Text = "Open";
            this.btnOpenClient.UseVisualStyleBackColor = false;
            this.btnOpenClient.Click += new System.EventHandler(this.btnOpenClient_Click);
            // 
            // dgvClients
            // 
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Gadugi", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClients.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClients.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("High Tower Text", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClients.Location = new System.Drawing.Point(7, 31);
            this.dgvClients.Margin = new System.Windows.Forms.Padding(2);
            this.dgvClients.MultiSelect = false;
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvClients.RowHeadersVisible = false;
            this.dgvClients.RowTemplate.Height = 24;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvClients.ShowEditingIcon = false;
            this.dgvClients.Size = new System.Drawing.Size(976, 381);
            this.dgvClients.TabIndex = 0;
            this.dgvClients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClients_CellDoubleClick);
            this.dgvClients.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClients_CellFocus);
            this.dgvClients.Sorted += new System.EventHandler(this.dataGridViewAccount_Sorted);
            // 
            // lblSrchClnts
            // 
            this.lblSrchClnts.AutoSize = true;
            this.lblSrchClnts.BackColor = System.Drawing.Color.Transparent;
            this.lblSrchClnts.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrchClnts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSrchClnts.Location = new System.Drawing.Point(210, 6);
            this.lblSrchClnts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSrchClnts.Name = "lblSrchClnts";
            this.lblSrchClnts.Size = new System.Drawing.Size(47, 16);
            this.lblSrchClnts.TabIndex = 19;
            this.lblSrchClnts.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.AcceptsReturn = true;
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Location = new System.Drawing.Point(261, 5);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(722, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.WordWrap = false;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchClnts_KeyDown);
            // 
            // Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlClients);
            this.Name = "Clients";
            this.Size = new System.Drawing.Size(995, 457);
            this.pnlClients.ResumeLayout(false);
            this.pnlClients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlClients;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Label lblClntViews;
        private System.Windows.Forms.Label lblCurrentClient;
        public System.Windows.Forms.ComboBox cboClientViews;
        public System.Windows.Forms.Button btnOpenClient;
        public System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.Label lblSrchClnts;
        public System.Windows.Forms.TextBox txtSearch;
    }
}
