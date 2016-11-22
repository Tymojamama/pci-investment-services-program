namespace ISP.Presentation.Forms
{
	partial class frmTask
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.labelTaskName = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboBoxOwner = new System.Windows.Forms.ComboBox();
            this.domainUpDown = new System.Windows.Forms.DomainUpDown();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.comboBoxRegarding = new System.Windows.Forms.ComboBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTaskName
            // 
            this.labelTaskName.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTaskName.Location = new System.Drawing.Point(2, 16);
            this.labelTaskName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTaskName.Name = "labelTaskName";
            this.labelTaskName.Size = new System.Drawing.Size(82, 20);
            this.labelTaskName.TabIndex = 0;
            this.labelTaskName.Text = "Task";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(129, 16);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(277, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fund";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 201);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Due Date";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsTab = true;
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBox1.Location = new System.Drawing.Point(129, 199);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.MaxLength = 2;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(27, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "mm";
            this.textBox1.Enter += new System.EventHandler(this.TextBox1Enter);
            this.textBox1.Leave += new System.EventHandler(this.TextBox1Leave);
            // 
            // textBox2
            // 
            this.textBox2.AcceptsTab = true;
            this.textBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBox2.Location = new System.Drawing.Point(165, 200);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.MaxLength = 2;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(27, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "dd";
            this.textBox2.Enter += new System.EventHandler(this.TextBox2Enter);
            this.textBox2.Leave += new System.EventHandler(this.TextBox2Leave);
            // 
            // textBox3
            // 
            this.textBox3.AcceptsTab = true;
            this.textBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBox3.Location = new System.Drawing.Point(201, 200);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.MaxLength = 4;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(50, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "yyyy";
            this.textBox3.Enter += new System.EventHandler(this.TextBox3Enter);
            this.textBox3.Leave += new System.EventHandler(this.TextBox3Leave);
            // 
            // textBox4
            // 
            this.textBox4.AcceptsTab = true;
            this.textBox4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBox4.Location = new System.Drawing.Point(259, 201);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.MaxLength = 2;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(27, 20);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "hh";
            this.textBox4.Enter += new System.EventHandler(this.TextBox4Enter);
            this.textBox4.Leave += new System.EventHandler(this.TextBox4Leave);
            // 
            // textBox5
            // 
            this.textBox5.AcceptsTab = true;
            this.textBox5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBox5.Location = new System.Drawing.Point(295, 201);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.MaxLength = 2;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(27, 20);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "mm";
            this.textBox5.Enter += new System.EventHandler(this.TextBox5Enter);
            this.textBox5.Leave += new System.EventHandler(this.TextBox5Leave);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 176);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Owner";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(156, 202);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "/";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(191, 202);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "/";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(286, 201);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = ":";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 224);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Description *";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(129, 224);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(277, 100);
            this.textBox6.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(294, 330);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 26);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(354, 330);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(52, 26);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comboBoxOwner
            // 
            this.comboBoxOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxOwner.ForeColor = System.Drawing.Color.Black;
            this.comboBoxOwner.FormattingEnabled = true;
            this.comboBoxOwner.Location = new System.Drawing.Point(129, 176);
            this.comboBoxOwner.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxOwner.Name = "comboBoxOwner";
            this.comboBoxOwner.Size = new System.Drawing.Size(277, 21);
            this.comboBoxOwner.TabIndex = 4;
            this.comboBoxOwner.SelectedIndexChanged += new System.EventHandler(this.comboBoxOwnerSelectedIndexChange);
            // 
            // domainUpDown
            // 
            this.domainUpDown.Items.Add("AM");
            this.domainUpDown.Items.Add("PM");
            this.domainUpDown.Location = new System.Drawing.Point(327, 201);
            this.domainUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.domainUpDown.Name = "domainUpDown";
            this.domainUpDown.ReadOnly = true;
            this.domainUpDown.Size = new System.Drawing.Size(79, 20);
            this.domainUpDown.TabIndex = 10;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label26);
            this.panel7.Location = new System.Drawing.Point(0, 26);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(418, 41);
            this.panel7.TabIndex = 23;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("High Tower Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(-1, 2);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(156, 37);
            this.label26.TabIndex = 19;
            this.label26.Text = "New Task";
            // 
            // comboBoxRegarding
            // 
            this.comboBoxRegarding.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxRegarding.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxRegarding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxRegarding.FormattingEnabled = true;
            this.comboBoxRegarding.Location = new System.Drawing.Point(129, 39);
            this.comboBoxRegarding.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxRegarding.Name = "comboBoxRegarding";
            this.comboBoxRegarding.Size = new System.Drawing.Size(277, 21);
            this.comboBoxRegarding.TabIndex = 1;
            this.comboBoxRegarding.SelectedIndexChanged += new System.EventHandler(this.comboBoxRegardingSelectedIndexChange);
            // 
            // textBox7
            // 
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBox7.Location = new System.Drawing.Point(2, 4);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(270, 13);
            this.textBox7.TabIndex = 24;
            this.textBox7.Text = "Select a fund using the box above...";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Location = new System.Drawing.Point(129, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 21);
            this.panel1.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.textBox8);
            this.panel2.Location = new System.Drawing.Point(129, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(277, 21);
            this.panel2.TabIndex = 28;
            // 
            // textBox8
            // 
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBox8.Location = new System.Drawing.Point(2, 4);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(270, 13);
            this.textBox8.TabIndex = 24;
            this.textBox8.Text = "Select a manager using the box above...";
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(129, 85);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(277, 21);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 87);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Manager";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.textBox9);
            this.panel3.Location = new System.Drawing.Point(129, 153);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(277, 21);
            this.panel3.TabIndex = 31;
            // 
            // textBox9
            // 
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBox9.Location = new System.Drawing.Point(2, 4);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(270, 13);
            this.textBox9.TabIndex = 24;
            this.textBox9.Text = "Select an account using the box above...";
            // 
            // comboBox3
            // 
            this.comboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(129, 130);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(277, 21);
            this.comboBox3.TabIndex = 3;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 132);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Account";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.comboBox3);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.comboBox2);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.domainUpDown);
            this.panel4.Controls.Add(this.comboBoxRegarding);
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Controls.Add(this.textBox6);
            this.panel4.Controls.Add(this.textBox3);
            this.panel4.Controls.Add(this.textBox2);
            this.panel4.Controls.Add(this.textBox5);
            this.panel4.Controls.Add(this.textBox4);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.comboBox1);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.labelTaskName);
            this.panel4.Controls.Add(this.comboBoxOwner);
            this.panel4.Location = new System.Drawing.Point(0, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(418, 364);
            this.panel4.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(111, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 16);
            this.label12.TabIndex = 32;
            this.label12.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(111, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 16);
            this.label8.TabIndex = 32;
            this.label8.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(126, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 14);
            this.label7.TabIndex = 32;
            this.label7.Text = "* denotes required fields";
            // 
            // panel16
            // 
            this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel16.BackColor = System.Drawing.Color.SteelBlue;
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.pictureBox1);
            this.panel16.Controls.Add(this.label39);
            this.panel16.Controls.Add(this.label31);
            this.panel16.Location = new System.Drawing.Point(0, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(418, 27);
            this.panel16.TabIndex = 60;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::ISP.Properties.Resources.lightbulb;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.White;
            this.label39.Location = new System.Drawing.Point(26, 5);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(176, 16);
            this.label39.TabIndex = 23;
            this.label39.Text = "Investment Services Program";
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(390, 1);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(25, 25);
            this.label31.TabIndex = 22;
            this.label31.Text = "x";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label31.Click += new System.EventHandler(this.label31_Click);
            this.label31.MouseEnter += new System.EventHandler(this.CloseFormButton_MouseEnter);
            this.label31.MouseLeave += new System.EventHandler(this.CloseFormButton_MouseLeave);
            // 
            // frmTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(418, 430);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selected Fund...";
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.DomainUpDown domainUpDown;
        private System.Windows.Forms.ComboBox comboBoxOwner;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelTaskName;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label26;
        public System.Windows.Forms.ComboBox comboBoxRegarding;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox8;
        public System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox9;
        public System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label31;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
	}
}
