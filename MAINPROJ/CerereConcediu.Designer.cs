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
            this.btnCerere = new System.Windows.Forms.Button();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHomePage = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnConcediiPersonale = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnEchipa = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnListaAngajati = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnGestionareConcedii = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbInlocuitor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtComentarii = new System.Windows.Forms.RichTextBox();
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
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MAINPROJ.Properties.Resources.Prison_Break_logo;
            this.pictureBox1.Location = new System.Drawing.Point(390, -8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(391, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1157, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpDataIncepere
            // 
            this.dtpDataIncepere.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataIncepere.Location = new System.Drawing.Point(642, 171);
            this.dtpDataIncepere.Name = "dtpDataIncepere";
            this.dtpDataIncepere.Size = new System.Drawing.Size(315, 25);
            this.dtpDataIncepere.TabIndex = 2;
            // 
            // dtpDataSfarsit
            // 
            this.dtpDataSfarsit.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataSfarsit.Location = new System.Drawing.Point(642, 235);
            this.dtpDataSfarsit.Name = "dtpDataSfarsit";
            this.dtpDataSfarsit.Size = new System.Drawing.Size(315, 25);
            this.dtpDataSfarsit.TabIndex = 3;
            this.dtpDataSfarsit.ValueChanged += new System.EventHandler(this.dtpDataSfarsit_ValueChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(396, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data inceperii";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(396, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data sfarsitului";
            // 
            // cmbTipConcediu
            // 
            this.cmbTipConcediu.DataSource = this.tipConcediuBindingSource1;
            this.cmbTipConcediu.DisplayMember = "Nume";
            this.cmbTipConcediu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipConcediu.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipConcediu.FormattingEnabled = true;
            this.cmbTipConcediu.Location = new System.Drawing.Point(642, 302);
            this.cmbTipConcediu.Name = "cmbTipConcediu";
            this.cmbTipConcediu.Size = new System.Drawing.Size(315, 26);
            this.cmbTipConcediu.TabIndex = 6;
            this.cmbTipConcediu.ValueMember = "Id";
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
            this.label3.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Snow;
            this.label3.Location = new System.Drawing.Point(396, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tip concediu";
            // 
            // tipConcediuTableAdapter
            // 
            this.tipConcediuTableAdapter.ClearBeforeFill = true;
            // 
            // btnCerere
            // 
            this.btnCerere.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCerere.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerere.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerere.Location = new System.Drawing.Point(708, 633);
            this.btnCerere.Name = "btnCerere";
            this.btnCerere.Size = new System.Drawing.Size(190, 56);
            this.btnCerere.TabIndex = 8;
            this.btnCerere.Text = "trimite cerere";
            this.btnCerere.UseVisualStyleBackColor = false;
            this.btnCerere.Click += new System.EventHandler(this.btnCerere_Click);
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
            this.sidebar.Controls.Add(this.panel8);
            this.sidebar.Controls.Add(this.panel9);
            this.sidebar.Controls.Add(this.panel10);
            this.sidebar.Location = new System.Drawing.Point(-5, 0);
            this.sidebar.Margin = new System.Windows.Forms.Padding(0);
            this.sidebar.MaximumSize = new System.Drawing.Size(200, 700);
            this.sidebar.MinimumSize = new System.Drawing.Size(61, 700);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(61, 700);
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
            this.panel2.Controls.Add(this.btnHomePage);
            this.panel2.Location = new System.Drawing.Point(3, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(197, 63);
            this.panel2.TabIndex = 2;
            // 
            // btnHomePage
            // 
            this.btnHomePage.BackColor = System.Drawing.Color.White;
            this.btnHomePage.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomePage.Image = global::MAINPROJ.Properties.Resources.rsz_homeicon;
            this.btnHomePage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHomePage.Location = new System.Drawing.Point(-3, 3);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Size = new System.Drawing.Size(200, 57);
            this.btnHomePage.TabIndex = 1;
            this.btnHomePage.Text = "      Home";
            this.btnHomePage.UseVisualStyleBackColor = false;
            this.btnHomePage.Click += new System.EventHandler(this.btnHomePage_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnConcediiPersonale);
            this.panel3.Location = new System.Drawing.Point(3, 146);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(197, 63);
            this.panel3.TabIndex = 3;
            // 
            // btnConcediiPersonale
            // 
            this.btnConcediiPersonale.BackColor = System.Drawing.Color.White;
            this.btnConcediiPersonale.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConcediiPersonale.Image = global::MAINPROJ.Properties.Resources.rsz_calendaricon;
            this.btnConcediiPersonale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConcediiPersonale.Location = new System.Drawing.Point(-1, 3);
            this.btnConcediiPersonale.Name = "btnConcediiPersonale";
            this.btnConcediiPersonale.Size = new System.Drawing.Size(198, 57);
            this.btnConcediiPersonale.TabIndex = 1;
            this.btnConcediiPersonale.Text = "       Concediile \r\n      mele";
            this.btnConcediiPersonale.UseVisualStyleBackColor = false;
            this.btnConcediiPersonale.Click += new System.EventHandler(this.btnConcediiPersonale_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnEchipa);
            this.panel4.Location = new System.Drawing.Point(3, 215);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(197, 63);
            this.panel4.TabIndex = 4;
            // 
            // btnEchipa
            // 
            this.btnEchipa.BackColor = System.Drawing.Color.White;
            this.btnEchipa.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEchipa.Image = global::MAINPROJ.Properties.Resources.rsz_teamicon;
            this.btnEchipa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEchipa.Location = new System.Drawing.Point(-2, 3);
            this.btnEchipa.Name = "btnEchipa";
            this.btnEchipa.Size = new System.Drawing.Size(199, 57);
            this.btnEchipa.TabIndex = 1;
            this.btnEchipa.Text = "        Echipa";
            this.btnEchipa.UseVisualStyleBackColor = false;
            this.btnEchipa.Click += new System.EventHandler(this.btnEchipa_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnListaAngajati);
            this.panel5.Location = new System.Drawing.Point(3, 284);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(197, 63);
            this.panel5.TabIndex = 5;
            // 
            // btnListaAngajati
            // 
            this.btnListaAngajati.BackColor = System.Drawing.Color.White;
            this.btnListaAngajati.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaAngajati.Image = global::MAINPROJ.Properties.Resources.rsz_istockphoto_1136653100_170667a;
            this.btnListaAngajati.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListaAngajati.Location = new System.Drawing.Point(-1, 3);
            this.btnListaAngajati.Name = "btnListaAngajati";
            this.btnListaAngajati.Size = new System.Drawing.Size(198, 57);
            this.btnListaAngajati.TabIndex = 1;
            this.btnListaAngajati.Text = "           Lista Angajati";
            this.btnListaAngajati.UseVisualStyleBackColor = false;
            this.btnListaAngajati.Click += new System.EventHandler(this.btnListaAngajati_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnGestionareConcedii);
            this.panel6.Location = new System.Drawing.Point(3, 353);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(197, 63);
            this.panel6.TabIndex = 8;
            // 
            // btnGestionareConcedii
            // 
            this.btnGestionareConcedii.BackColor = System.Drawing.Color.White;
            this.btnGestionareConcedii.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionareConcedii.Image = global::MAINPROJ.Properties.Resources.rsz_sheriff;
            this.btnGestionareConcedii.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionareConcedii.Location = new System.Drawing.Point(-2, 3);
            this.btnGestionareConcedii.Name = "btnGestionareConcedii";
            this.btnGestionareConcedii.Size = new System.Drawing.Size(199, 57);
            this.btnGestionareConcedii.TabIndex = 1;
            this.btnGestionareConcedii.Text = "          Gestionare \r\n        Concedii";
            this.btnGestionareConcedii.UseVisualStyleBackColor = false;
            this.btnGestionareConcedii.Click += new System.EventHandler(this.btnGestionareConcedii_Click);
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(3, 422);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(197, 63);
            this.panel7.TabIndex = 9;
            // 
            // panel8
            // 
            this.panel8.Location = new System.Drawing.Point(3, 491);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(197, 63);
            this.panel8.TabIndex = 10;
            // 
            // panel9
            // 
            this.panel9.Location = new System.Drawing.Point(3, 560);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(197, 63);
            this.panel9.TabIndex = 11;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnLogOut);
            this.panel10.Location = new System.Drawing.Point(3, 629);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(197, 63);
            this.panel10.TabIndex = 12;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.White;
            this.btnLogOut.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Image = global::MAINPROJ.Properties.Resources.logouts;
            this.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.Location = new System.Drawing.Point(-1, 3);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(199, 60);
            this.btnLogOut.TabIndex = 5;
            this.btnLogOut.Text = "         Deconectare";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
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
            this.label4.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(396, 559);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "ZILE RAMASE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(772, 557);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "1";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Snow;
            this.label6.Location = new System.Drawing.Point(396, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "INLOCUITOR";
            // 
            // cmbInlocuitor
            // 
            this.cmbInlocuitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInlocuitor.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInlocuitor.FormattingEnabled = true;
            this.cmbInlocuitor.Location = new System.Drawing.Point(642, 374);
            this.cmbInlocuitor.Name = "cmbInlocuitor";
            this.cmbInlocuitor.Size = new System.Drawing.Size(315, 26);
            this.cmbInlocuitor.TabIndex = 13;
            this.cmbInlocuitor.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.ComboBoxFormat);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(638, 559);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 22);
            this.label7.TabIndex = 14;
            this.label7.Text = "Odihna";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(638, 584);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 22);
            this.label8.TabIndex = 15;
            this.label8.Text = "Medical";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(814, 560);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 22);
            this.label9.TabIndex = 16;
            this.label9.Text = "DECES";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(814, 585);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 22);
            this.label10.TabIndex = 17;
            this.label10.Text = "neplatite";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(772, 582);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 22);
            this.label11.TabIndex = 18;
            this.label11.Text = "1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(948, 558);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 22);
            this.label12.TabIndex = 19;
            this.label12.Text = "1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(948, 583);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 22);
            this.label13.TabIndex = 20;
            this.label13.Text = "1";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Snow;
            this.label14.Location = new System.Drawing.Point(396, 440);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(146, 23);
            this.label14.TabIndex = 21;
            this.label14.Text = "comentarii";
            // 
            // txtComentarii
            // 
            this.txtComentarii.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentarii.Location = new System.Drawing.Point(642, 440);
            this.txtComentarii.Name = "txtComentarii";
            this.txtComentarii.Size = new System.Drawing.Size(315, 96);
            this.txtComentarii.TabIndex = 22;
            this.txtComentarii.Text = "";
            // 
            // CerereConcediu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MAINPROJ.Properties.Resources.Back_1200x700;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.ControlBox = false;
            this.Controls.Add(this.txtComentarii);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbInlocuitor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.btnCerere);
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
            this.panel10.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnCerere;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnHomePage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnConcediiPersonale;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnEchipa;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnListaAngajati;
        private System.Windows.Forms.Timer sidebarTimer;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnGestionareConcedii;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.BindingSource tipConcediuBindingSource1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbInlocuitor;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox txtComentarii;
    }
}