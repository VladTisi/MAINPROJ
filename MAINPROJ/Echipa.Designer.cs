namespace MAINPROJ
{
    partial class Echipa
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
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
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
            this.btnExit = new System.Windows.Forms.Button();
            this.tabelConcediu = new System.Windows.Forms.DataGridView();
            this.btnCerereNoua = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabelEchipa = new System.Windows.Forms.DataGridView();
            this.btnBackward = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.sidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabelConcediu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelEchipa)).BeginInit();
            this.SuspendLayout();
            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 10;
            this.sidebarTimer.Tick += new System.EventHandler(this.sidebarTimer_Tick);
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
            this.sidebar.TabIndex = 50;
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
            this.panel6.TabIndex = 6;
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
            this.panel7.TabIndex = 7;
            // 
            // panel8
            // 
            this.panel8.Location = new System.Drawing.Point(3, 491);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(197, 63);
            this.panel8.TabIndex = 8;
            // 
            // panel9
            // 
            this.panel9.Location = new System.Drawing.Point(3, 560);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(197, 63);
            this.panel9.TabIndex = 9;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnLogOut);
            this.panel10.Location = new System.Drawing.Point(3, 629);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(197, 63);
            this.panel10.TabIndex = 10;
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
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "         Deconectare";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(1164, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 32);
            this.btnExit.TabIndex = 51;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tabelConcediu
            // 
            this.tabelConcediu.AllowUserToAddRows = false;
            this.tabelConcediu.AllowUserToDeleteRows = false;
            this.tabelConcediu.BackgroundColor = System.Drawing.Color.White;
            this.tabelConcediu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelConcediu.Location = new System.Drawing.Point(613, 216);
            this.tabelConcediu.Name = "tabelConcediu";
            this.tabelConcediu.ReadOnly = true;
            this.tabelConcediu.Size = new System.Drawing.Size(562, 252);
            this.tabelConcediu.TabIndex = 53;
            this.tabelConcediu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelEchipa_CellContentClick);
            // 
            // btnCerereNoua
            // 
            this.btnCerereNoua.BackColor = System.Drawing.Color.Black;
            this.btnCerereNoua.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerereNoua.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerereNoua.Location = new System.Drawing.Point(811, 536);
            this.btnCerereNoua.Name = "btnCerereNoua";
            this.btnCerereNoua.Size = new System.Drawing.Size(166, 58);
            this.btnCerereNoua.TabIndex = 54;
            this.btnCerereNoua.Text = "Cerere Concediu";
            this.btnCerereNoua.UseVisualStyleBackColor = false;
            this.btnCerereNoua.Click += new System.EventHandler(this.btnCerereNoua_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MAINPROJ.Properties.Resources.Prison_Break_logo;
            this.pictureBox1.Location = new System.Drawing.Point(347, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(470, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(327, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 56;
            this.label1.Text = "Echipa ta";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(806, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 25);
            this.label2.TabIndex = 57;
            this.label2.Text = "Concedii ECHIPA";
            // 
            // tabelEchipa
            // 
            this.tabelEchipa.AllowUserToAddRows = false;
            this.tabelEchipa.AllowUserToDeleteRows = false;
            this.tabelEchipa.BackgroundColor = System.Drawing.Color.White;
            this.tabelEchipa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelEchipa.Location = new System.Drawing.Point(191, 216);
            this.tabelEchipa.Name = "tabelEchipa";
            this.tabelEchipa.ReadOnly = true;
            this.tabelEchipa.Size = new System.Drawing.Size(394, 252);
            this.tabelEchipa.TabIndex = 58;
            this.tabelEchipa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelEchipa_CellContentClick_1);
            // 
            // btnBackward
            // 
            this.btnBackward.BackColor = System.Drawing.Color.White;
            this.btnBackward.Font = new System.Drawing.Font("Stencil", 10F);
            this.btnBackward.ForeColor = System.Drawing.Color.Black;
            this.btnBackward.Location = new System.Drawing.Point(191, 491);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(84, 28);
            this.btnBackward.TabIndex = 72;
            this.btnBackward.Text = "<<<<";
            this.btnBackward.UseVisualStyleBackColor = false;
            this.btnBackward.Visible = false;
            this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.Color.White;
            this.btnForward.Font = new System.Drawing.Font("Stencil", 10F);
            this.btnForward.ForeColor = System.Drawing.Color.Black;
            this.btnForward.Location = new System.Drawing.Point(501, 491);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(84, 28);
            this.btnForward.TabIndex = 71;
            this.btnForward.Text = ">>>>";
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Stencil", 10F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(613, 492);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 28);
            this.button1.TabIndex = 74;
            this.button1.Text = "<<<<";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Font = new System.Drawing.Font("Stencil", 10F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1091, 492);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 28);
            this.button2.TabIndex = 73;
            this.button2.Text = ">>>>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Echipa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MAINPROJ.Properties.Resources.Back_1200x700;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnBackward);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.tabelEchipa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCerereNoua);
            this.Controls.Add(this.tabelConcediu);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.sidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Echipa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Echipa";
            this.Load += new System.EventHandler(this.Echipa_Load);
            this.sidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabelConcediu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelEchipa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer sidebarTimer;
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
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView tabelConcediu;
        private System.Windows.Forms.Button btnCerereNoua;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnGestionareConcedii;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tabelEchipa;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnBackward;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}