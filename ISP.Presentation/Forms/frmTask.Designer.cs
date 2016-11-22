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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTaskName = new System.Windows.Forms.Label();
            this.cboTaskType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboOwner = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblFormHeader = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnClearAccount = new System.Windows.Forms.Button();
            this.btnClearManager = new System.Windows.Forms.Button();
            this.btnClearFund = new System.Windows.Forms.Button();
            this.lblSelectedAccount = new System.Windows.Forms.Label();
            this.lblSelectedManager = new System.Windows.Forms.Label();
            this.lblSelectedFund = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label39 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabTaskTime = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddFund = new System.Windows.Forms.Button();
            this.btnRemoveFund = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.dgvTaskTimes = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNavigationTaskTime = new System.Windows.Forms.Label();
            this.lblNavigationMain = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDateCompleted = new System.Windows.Forms.RichTextBox();
            this.txtDateDue = new System.Windows.Forms.RichTextBox();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel16.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabTaskTime.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskTimes)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTaskName
            // 
            this.labelTaskName.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTaskName.Location = new System.Drawing.Point(2, 29);
            this.labelTaskName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTaskName.Name = "labelTaskName";
            this.labelTaskName.Size = new System.Drawing.Size(123, 20);
            this.labelTaskName.TabIndex = 0;
            this.labelTaskName.Text = "Task*";
            // 
            // cboTaskType
            // 
            this.cboTaskType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTaskType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTaskType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTaskType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTaskType.ForeColor = System.Drawing.Color.Black;
            this.cboTaskType.FormattingEnabled = true;
            this.cboTaskType.Location = new System.Drawing.Point(129, 29);
            this.cboTaskType.Margin = new System.Windows.Forms.Padding(2);
            this.cboTaskType.Name = "cboTaskType";
            this.cboTaskType.Size = new System.Drawing.Size(563, 22);
            this.cboTaskType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fund";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Due Date";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Owner*";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 179);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Date Completed";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescription.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(129, 202);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(563, 136);
            this.txtDescription.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.BackgroundImage = global::ISP.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(664, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(30, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboOwner
            // 
            this.cboOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOwner.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboOwner.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOwner.ForeColor = System.Drawing.Color.Black;
            this.cboOwner.FormattingEnabled = true;
            this.cboOwner.Location = new System.Drawing.Point(129, 130);
            this.cboOwner.Margin = new System.Windows.Forms.Padding(2);
            this.cboOwner.Name = "cboOwner";
            this.cboOwner.Size = new System.Drawing.Size(563, 22);
            this.cboOwner.TabIndex = 8;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblFormHeader);
            this.panel7.Controls.Add(this.btnSave);
            this.panel7.Location = new System.Drawing.Point(0, 26);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(704, 41);
            this.panel7.TabIndex = 23;
            // 
            // lblFormHeader
            // 
            this.lblFormHeader.AutoSize = true;
            this.lblFormHeader.Font = new System.Drawing.Font("High Tower Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormHeader.ForeColor = System.Drawing.Color.Black;
            this.lblFormHeader.Location = new System.Drawing.Point(-1, 2);
            this.lblFormHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormHeader.Name = "lblFormHeader";
            this.lblFormHeader.Size = new System.Drawing.Size(156, 37);
            this.lblFormHeader.TabIndex = 19;
            this.lblFormHeader.Text = "New Task";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Manager";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 107);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Account";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtDateDue);
            this.panel4.Controls.Add(this.txtDateCompleted);
            this.panel4.Controls.Add(this.cboStatus);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.btnClearAccount);
            this.panel4.Controls.Add(this.btnClearManager);
            this.panel4.Controls.Add(this.btnClearFund);
            this.panel4.Controls.Add(this.lblSelectedAccount);
            this.panel4.Controls.Add(this.lblSelectedManager);
            this.panel4.Controls.Add(this.lblSelectedFund);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.txtDescription);
            this.panel4.Controls.Add(this.cboTaskType);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.labelTaskName);
            this.panel4.Controls.Add(this.cboOwner);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(704, 363);
            this.panel4.TabIndex = 32;
            // 
            // btnClearAccount
            // 
            this.btnClearAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearAccount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClearAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(56)))), ((int)(((byte)(60)))));
            this.btnClearAccount.Location = new System.Drawing.Point(664, 105);
            this.btnClearAccount.Name = "btnClearAccount";
            this.btnClearAccount.Size = new System.Drawing.Size(27, 22);
            this.btnClearAccount.TabIndex = 7;
            this.btnClearAccount.Text = "x";
            this.btnClearAccount.UseVisualStyleBackColor = false;
            this.btnClearAccount.Click += new System.EventHandler(this.btnClearAccount_Click);
            // 
            // btnClearManager
            // 
            this.btnClearManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearManager.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClearManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(56)))), ((int)(((byte)(60)))));
            this.btnClearManager.Location = new System.Drawing.Point(664, 80);
            this.btnClearManager.Name = "btnClearManager";
            this.btnClearManager.Size = new System.Drawing.Size(27, 22);
            this.btnClearManager.TabIndex = 5;
            this.btnClearManager.Text = "x";
            this.btnClearManager.UseVisualStyleBackColor = false;
            this.btnClearManager.Click += new System.EventHandler(this.btnClearManager_Click);
            // 
            // btnClearFund
            // 
            this.btnClearFund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFund.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClearFund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFund.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(56)))), ((int)(((byte)(60)))));
            this.btnClearFund.Location = new System.Drawing.Point(664, 55);
            this.btnClearFund.Name = "btnClearFund";
            this.btnClearFund.Size = new System.Drawing.Size(27, 22);
            this.btnClearFund.TabIndex = 3;
            this.btnClearFund.Text = "x";
            this.btnClearFund.UseVisualStyleBackColor = false;
            this.btnClearFund.Click += new System.EventHandler(this.btnClearFund_Click);
            // 
            // lblSelectedAccount
            // 
            this.lblSelectedAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedAccount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSelectedAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectedAccount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedAccount.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSelectedAccount.Location = new System.Drawing.Point(129, 105);
            this.lblSelectedAccount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedAccount.Name = "lblSelectedAccount";
            this.lblSelectedAccount.Size = new System.Drawing.Size(530, 22);
            this.lblSelectedAccount.TabIndex = 6;
            this.lblSelectedAccount.Text = "Select an account...";
            this.lblSelectedAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelectedAccount.Click += new System.EventHandler(this.lblSelectedAccount_Click);
            // 
            // lblSelectedManager
            // 
            this.lblSelectedManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedManager.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSelectedManager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectedManager.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedManager.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSelectedManager.Location = new System.Drawing.Point(129, 80);
            this.lblSelectedManager.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedManager.Name = "lblSelectedManager";
            this.lblSelectedManager.Size = new System.Drawing.Size(530, 22);
            this.lblSelectedManager.TabIndex = 4;
            this.lblSelectedManager.Text = "Select a manager...";
            this.lblSelectedManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelectedManager.Click += new System.EventHandler(this.lblSelectedManager_Click);
            // 
            // lblSelectedFund
            // 
            this.lblSelectedFund.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedFund.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSelectedFund.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectedFund.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFund.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSelectedFund.Location = new System.Drawing.Point(129, 55);
            this.lblSelectedFund.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedFund.Name = "lblSelectedFund";
            this.lblSelectedFund.Size = new System.Drawing.Size(530, 22);
            this.lblSelectedFund.TabIndex = 2;
            this.lblSelectedFund.Text = "Select a fund...";
            this.lblSelectedFund.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelectedFund.Click += new System.EventHandler(this.lblSelectedFund_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(126, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 14);
            this.label7.TabIndex = 32;
            this.label7.Text = "* denotes required fields";
            // 
            // panel16
            // 
            this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.label39);
            this.panel16.Controls.Add(this.label31);
            this.panel16.Location = new System.Drawing.Point(0, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(704, 27);
            this.panel16.TabIndex = 60;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.White;
            this.label39.Location = new System.Drawing.Point(3, 5);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(215, 16);
            this.label39.TabIndex = 23;
            this.label39.Text = "Investment Services Program - Task";
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(676, 1);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(25, 25);
            this.label31.TabIndex = 22;
            this.label31.Text = "x";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label31.Click += new System.EventHandler(this.label31_Click);
            this.label31.MouseEnter += new System.EventHandler(this.CloseFormButton_MouseEnter);
            this.label31.MouseLeave += new System.EventHandler(this.CloseFormButton_MouseLeave);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabTaskTime);
            this.tabControl.Location = new System.Drawing.Point(-4, 44);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(712, 389);
            this.tabControl.TabIndex = 61;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.panel4);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(704, 363);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "tabMain";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tabTaskTime
            // 
            this.tabTaskTime.Controls.Add(this.panel1);
            this.tabTaskTime.Location = new System.Drawing.Point(4, 22);
            this.tabTaskTime.Name = "tabTaskTime";
            this.tabTaskTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabTaskTime.Size = new System.Drawing.Size(704, 363);
            this.tabTaskTime.TabIndex = 1;
            this.tabTaskTime.Text = "tabTaskTime";
            this.tabTaskTime.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAddFund);
            this.panel1.Controls.Add(this.btnRemoveFund);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.dgvTaskTimes);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 435);
            this.panel1.TabIndex = 33;
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
            this.btnAddFund.Location = new System.Drawing.Point(649, 2);
            this.btnAddFund.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddFund.Name = "btnAddFund";
            this.btnAddFund.Size = new System.Drawing.Size(20, 20);
            this.btnAddFund.TabIndex = 92;
            this.btnAddFund.UseVisualStyleBackColor = false;
            this.btnAddFund.Click += new System.EventHandler(this.btnAddFund_Click);
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
            this.btnRemoveFund.Location = new System.Drawing.Point(674, 2);
            this.btnRemoveFund.Margin = new System.Windows.Forms.Padding(0);
            this.btnRemoveFund.Name = "btnRemoveFund";
            this.btnRemoveFund.Size = new System.Drawing.Size(20, 20);
            this.btnRemoveFund.TabIndex = 93;
            this.btnRemoveFund.UseVisualStyleBackColor = false;
            this.btnRemoveFund.Click += new System.EventHandler(this.btnRemoveFund_Click);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(46)))), ((int)(((byte)(71)))));
            this.label18.Location = new System.Drawing.Point(2, 2);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(193, 21);
            this.label18.TabIndex = 91;
            this.label18.Text = "Time Entries";
            // 
            // dgvTaskTimes
            // 
            this.dgvTaskTimes.AllowUserToAddRows = false;
            this.dgvTaskTimes.AllowUserToDeleteRows = false;
            this.dgvTaskTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTaskTimes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaskTimes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTaskTimes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Gadugi", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTaskTimes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTaskTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Gadugi", 7.8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTaskTimes.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTaskTimes.EnableHeadersVisualStyles = false;
            this.dgvTaskTimes.Location = new System.Drawing.Point(6, 25);
            this.dgvTaskTimes.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTaskTimes.MultiSelect = false;
            this.dgvTaskTimes.Name = "dgvTaskTimes";
            this.dgvTaskTimes.ReadOnly = true;
            this.dgvTaskTimes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTaskTimes.RowHeadersVisible = false;
            this.dgvTaskTimes.RowTemplate.Height = 24;
            this.dgvTaskTimes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTaskTimes.Size = new System.Drawing.Size(688, 331);
            this.dgvTaskTimes.TabIndex = 90;
            this.dgvTaskTimes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaskTimes_CellDoubleClick);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblNavigationTaskTime);
            this.panel3.Controls.Add(this.lblNavigationMain);
            this.panel3.Location = new System.Drawing.Point(0, 428);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(704, 53);
            this.panel3.TabIndex = 63;
            // 
            // lblNavigationTaskTime
            // 
            this.lblNavigationTaskTime.AutoSize = true;
            this.lblNavigationTaskTime.BackColor = System.Drawing.Color.Transparent;
            this.lblNavigationTaskTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblNavigationTaskTime.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavigationTaskTime.ForeColor = System.Drawing.Color.Black;
            this.lblNavigationTaskTime.Location = new System.Drawing.Point(117, 15);
            this.lblNavigationTaskTime.Name = "lblNavigationTaskTime";
            this.lblNavigationTaskTime.Size = new System.Drawing.Size(113, 25);
            this.lblNavigationTaskTime.TabIndex = 0;
            this.lblNavigationTaskTime.Text = "Task Times";
            this.lblNavigationTaskTime.Click += new System.EventHandler(this.lblNavigationTaskTime_Click);
            this.lblNavigationTaskTime.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.lblNavigationTaskTime.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // lblNavigationMain
            // 
            this.lblNavigationMain.AutoSize = true;
            this.lblNavigationMain.BackColor = System.Drawing.Color.Transparent;
            this.lblNavigationMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblNavigationMain.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavigationMain.ForeColor = System.Drawing.Color.Black;
            this.lblNavigationMain.Location = new System.Drawing.Point(12, 15);
            this.lblNavigationMain.Name = "lblNavigationMain";
            this.lblNavigationMain.Size = new System.Drawing.Size(99, 25);
            this.lblNavigationMain.TabIndex = 0;
            this.lblNavigationMain.Text = "Summary";
            this.lblNavigationMain.Click += new System.EventHandler(this.lblNavigationMain_Click);
            this.lblNavigationMain.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.lblNavigationMain.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label25);
            this.panel2.Location = new System.Drawing.Point(0, 480);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(704, 21);
            this.panel2.TabIndex = 62;
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
            this.label25.Size = new System.Drawing.Size(150, 16);
            this.label25.TabIndex = 40;
            this.label25.Text = "Ready";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 202);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Description";
            // 
            // cboStatus
            // 
            this.cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStatus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.ForeColor = System.Drawing.Color.Black;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Completed",
            "Uncompleted"});
            this.cboStatus.Location = new System.Drawing.Point(129, 4);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(563, 22);
            this.cboStatus.TabIndex = 0;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1, 4);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 20);
            this.label13.TabIndex = 39;
            this.label13.Text = "Status*";
            // 
            // txtDateCompleted
            // 
            this.txtDateCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateCompleted.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDateCompleted.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDateCompleted.Font = new System.Drawing.Font("Arial", 8F);
            this.txtDateCompleted.ForeColor = System.Drawing.Color.Black;
            this.txtDateCompleted.Location = new System.Drawing.Point(129, 179);
            this.txtDateCompleted.Margin = new System.Windows.Forms.Padding(2);
            this.txtDateCompleted.Multiline = false;
            this.txtDateCompleted.Name = "txtDateCompleted";
            this.txtDateCompleted.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtDateCompleted.Size = new System.Drawing.Size(563, 21);
            this.txtDateCompleted.TabIndex = 10;
            this.txtDateCompleted.Text = "";
            // 
            // txtDateDue
            // 
            this.txtDateDue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateDue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDateDue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDateDue.Font = new System.Drawing.Font("Arial", 8F);
            this.txtDateDue.ForeColor = System.Drawing.Color.Black;
            this.txtDateDue.Location = new System.Drawing.Point(129, 155);
            this.txtDateDue.Margin = new System.Windows.Forms.Padding(2);
            this.txtDateDue.Multiline = false;
            this.txtDateDue.Name = "txtDateDue";
            this.txtDateDue.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtDateDue.Size = new System.Drawing.Size(563, 21);
            this.txtDateDue.TabIndex = 9;
            this.txtDateDue.Text = "";
            // 
            // frmTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(704, 501);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selected Fund...";
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabTaskTime.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskTimes)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ComboBox cboOwner;
		private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelTaskName;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblFormHeader;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label31;
        public System.Windows.Forms.ComboBox cboTaskType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSelectedFund;
        private System.Windows.Forms.Button btnClearFund;
        private System.Windows.Forms.Button btnClearManager;
        private System.Windows.Forms.Label lblSelectedManager;
        private System.Windows.Forms.Button btnClearAccount;
        private System.Windows.Forms.Label lblSelectedAccount;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabTaskTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblNavigationTaskTime;
        private System.Windows.Forms.Label lblNavigationMain;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.Label label18;
        public System.Windows.Forms.DataGridView dgvTaskTimes;
        private System.Windows.Forms.Button btnAddFund;
        private System.Windows.Forms.Button btnRemoveFund;
        private System.Windows.Forms.ToolTip toolTip;
        public System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.RichTextBox txtDateCompleted;
        public System.Windows.Forms.RichTextBox txtDateDue;
	}
}
