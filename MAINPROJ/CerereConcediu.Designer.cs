namespace MAINPROJ
{
    partial class CerereConcediu
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpDataIncepere = new System.Windows.Forms.DateTimePicker();
            this.dtpDataSfarsit = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipConcediu = new System.Windows.Forms.ComboBox();
            this.tipConcediuBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new MAINPROJ.DataSet1();
            this.tipConcediuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tipConcediuTableAdapter = new MAINPROJ.DataSet1TableAdapters.TipConcediuTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbInlocuitor = new System.Windows.Forms.ComboBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipConcediuBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipConcediuBindingSource)).BeginInit();
            this.sidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MAINPROJ.Properties.Resources.Prison_Break_logo;
            this.pictureBox1.Location = new System.Drawing.Point(273, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(329, 107);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Stencil", 12F);
            this.button1.Location = new System.Drawing.Point(884, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpDataIncepere
            // 
            this.dtpDataIncepere.Location = new System.Drawing.Point(491, 200);
            this.dtpDataIncepere.Name = "dtpDataIncepere";
            this.dtpDataIncepere.Size = new System.Drawing.Size(200, 20);
            this.dtpDataIncepere.TabIndex = 2;
            this.dtpDataIncepere.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dtpDataSfarsit
            // 
            this.dtpDataSfarsit.Location = new System.Drawing.Point(491, 251);
            this.dtpDataSfarsit.Name = "dtpDataSfarsit";
            this.dtpDataSfarsit.Size = new System.Drawing.Size(200, 20);
            this.dtpDataSfarsit.TabIndex = 3;
            this.dtpDataSfarsit.ValueChanged += new System.EventHandler(this.dtpDataSfarsit_ValueChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(316, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data inceperii";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(316, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data sfarsitului";
            // 
            // cmbTipConcediu
            // 
            this.cmbTipConcediu.DataSource = this.tipConcediuBindingSource1;
            this.cmbTipConcediu.DisplayMember = "Nume";
            this.cmbTipConcediu.FormattingEnabled = true;
            this.cmbTipConcediu.Location = new System.Drawing.Point(491, 301);
            this.cmbTipConcediu.Name = "cmbTipConcediu";
            this.cmbTipConcediu.Size = new System.Drawing.Size(200, 21);
            this.cmbTipConcediu.TabIndex = 6;
            this.cmbTipConcediu.ValueMember = "Id";
            this.cmbTipConcediu.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tipConcediuBindingSource1
            // 
            this.tipConcediuBindingSource1.DataMember = "TipConcediu";
            this.tipConcediuBindingSource1.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tipConcediuBindingSource
            // 
            this.tipConcediuBindingSource.DataMember = "TipConcediu";
            this.tipConcediuBindingSource.DataSource = this.dataSet1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Snow;
            this.label3.Location = new System.Drawing.Point(316, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tip concediu";
            // 
            // tipConcediuTableAdapter
            // 
            this.tipConcediuTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Stencil", 10F);
            this.button2.Location = new System.Drawing.Point(536, 392);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 46);
            this.button2.TabIndex = 8;
            this.button2.Text = "Trimite cerere";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Controls.Add(this.panel3);
            this.sidebar.Controls.Add(this.panel4);
            this.sidebar.Controls.Add(this.panel5);
            this.sidebar.Controls.Add(this.panel6);
            this.sidebar.Controls.Add(this.panel7);
            this.sidebar.Location = new System.Drawing.Point(-5, 0);
            this.sidebar.Margin = new System.Windows.Forms.Padding(0);
            this.sidebar.MaximumSize = new System.Drawing.Size(200, 535);
            this.sidebar.MinimumSize = new System.Drawing.Size(61, 535);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(61, 535);
            this.sidebar.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuButton);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 68);
            this.panel1.TabIndex = 1;
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.White;
            this.menuButton.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.Image = global::MAINPROJ.Properties.Resources.rsz_menu_icon_icon_iconscom_71858;
            this.menuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuButton.Location = new System.Drawing.Point(-3, 8);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(200, 51);
            this.menuButton.TabIndex = 2;
            this.menuButton.Text = "      Meniu";
            this.menuButton.UseVisualStyleBackColor = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Location = new System.Drawing.Point(3, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(197, 63);
            this.panel2.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::MAINPROJ.Properties.Resources.rsz_homeicon;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(-3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 57);
            this.button3.TabIndex = 1;
            this.button3.Text = "      Home";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button4);
            this.panel3.Location = new System.Drawing.Point(3, 146);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(197, 63);
            this.panel3.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::MAINPROJ.Properties.Resources.rsz_calendaricon;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(-1, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(198, 57);
            this.button4.TabIndex = 1;
            this.button4.Text = "       Concediile \r\n      mele";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button5);
            this.panel4.Location = new System.Drawing.Point(3, 215);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(197, 63);
            this.panel4.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = global::MAINPROJ.Properties.Resources.rsz_teamicon;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(-2, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(199, 57);
            this.button5.TabIndex = 1;
            this.button5.Text = "        Echipa";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button6);
            this.panel5.Location = new System.Drawing.Point(3, 284);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(197, 63);
            this.panel5.TabIndex = 5;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Image = global::MAINPROJ.Properties.Resources.rsz_istockphoto_1136653100_170667a;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(-1, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(198, 57);
            this.button6.TabIndex = 1;
            this.button6.Text = "           Lista Angajati";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button7);
            this.panel6.Location = new System.Drawing.Point(3, 353);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(197, 63);
            this.panel6.TabIndex = 8;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Image = global::MAINPROJ.Properties.Resources.rsz_sheriff;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(-2, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(199, 57);
            this.button7.TabIndex = 1;
            this.button7.Text = "          Gestionare \r\n        Concedii";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnLogOut);
            this.panel7.Location = new System.Drawing.Point(3, 422);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(197, 63);
            this.panel7.TabIndex = 9;
            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 10;
            this.sidebarTimer.Tick += new System.EventHandler(this.sidebarTimer_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(316, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "ZILE RAMASE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(331, 427);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "1";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Snow;
            this.label6.Location = new System.Drawing.Point(316, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "INLOCUITOR";
            // 
            // cmbInlocuitor
            // 
            this.cmbInlocuitor.FormattingEnabled = true;
            this.cmbInlocuitor.Location = new System.Drawing.Point(491, 354);
            this.cmbInlocuitor.Name = "cmbInlocuitor";
            this.cmbInlocuitor.Size = new System.Drawing.Size(200, 21);
            this.cmbInlocuitor.TabIndex = 13;
            this.cmbInlocuitor.SelectedIndexChanged += new System.EventHandler(this.cmbInlocuitor_SelectedIndexChanged);
            this.cmbInlocuitor.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.ComboBoxFormat);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.White;
            this.btnLogOut.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Image = global::MAINPROJ.Properties.Resources.logouts;
            this.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.Location = new System.Drawing.Point(-1, 1);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(199, 60);
            this.btnLogOut.TabIndex = 5;
            this.btnLogOut.Text = "         Deconectare";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // CerereConcediu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MAINPROJ.Properties.Resources.reback;
            this.ClientSize = new System.Drawing.Size(914, 491);
            this.ControlBox = false;
            this.Controls.Add(this.cmbInlocuitor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTipConcediu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDataSfarsit);
            this.Controls.Add(this.dtpDataIncepere);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CerereConcediu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.CerereConcediu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipConcediuBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipConcediuBindingSource)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpDataIncepere;
        private System.Windows.Forms.DateTimePicker dtpDataSfarsit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipConcediu;
        private System.Windows.Forms.Label label3;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource tipConcediuBindingSource;
        private DataSet1TableAdapters.TipConcediuTableAdapter tipConcediuTableAdapter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Timer sidebarTimer;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.BindingSource tipConcediuBindingSource1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbInlocuitor;
        private System.Windows.Forms.Button btnLogOut;
    }
}