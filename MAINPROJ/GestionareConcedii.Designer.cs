﻿namespace MAINPROJ
{
    partial class GestionareConcedii
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
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.tabelConcedii = new System.Windows.Forms.DataGridView();
            this.IdAngajat = new MaterialSkin.Controls.MaterialTextBox2();
            this.IdConcediu = new MaterialSkin.Controls.MaterialTextBox2();
            this.Aproba = new System.Windows.Forms.Button();
            this.Refuza = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabelConcedii)).BeginInit();
            this.SuspendLayout();
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
            this.sidebar.TabIndex = 51;
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
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(3, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(197, 63);
            this.panel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::MAINPROJ.Properties.Resources.rsz_homeicon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(-3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "      Home";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button2);
            this.panel3.Location = new System.Drawing.Point(3, 146);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(197, 63);
            this.panel3.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::MAINPROJ.Properties.Resources.rsz_calendaricon;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(-1, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 57);
            this.button2.TabIndex = 1;
            this.button2.Text = "       Concediile \r\n      mele";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button3);
            this.panel4.Location = new System.Drawing.Point(3, 215);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(197, 63);
            this.panel4.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::MAINPROJ.Properties.Resources.rsz_teamicon;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(-2, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(199, 57);
            this.button3.TabIndex = 1;
            this.button3.Text = "        Echipa";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button4);
            this.panel5.Location = new System.Drawing.Point(3, 284);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(197, 63);
            this.panel5.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::MAINPROJ.Properties.Resources.rsz_istockphoto_1136653100_170667a;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(-1, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(198, 57);
            this.button4.TabIndex = 1;
            this.button4.Text = "           Lista Angajati";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button7);
            this.panel6.Location = new System.Drawing.Point(3, 353);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(197, 63);
            this.panel6.TabIndex = 6;
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
            this.panel7.Controls.Add(this.button8);
            this.panel7.Location = new System.Drawing.Point(3, 422);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(197, 63);
            this.panel7.TabIndex = 7;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Image = global::MAINPROJ.Properties.Resources.king;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Location = new System.Drawing.Point(-2, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(199, 57);
            this.button8.TabIndex = 1;
            this.button8.Text = "         Alterare Date";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 10;
            this.sidebarTimer.Tick += new System.EventHandler(this.sidebarTimer_Tick);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(884, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(33, 23);
            this.button5.TabIndex = 52;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tabelConcedii
            // 
            this.tabelConcedii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelConcedii.Location = new System.Drawing.Point(223, 63);
            this.tabelConcedii.Name = "tabelConcedii";
            this.tabelConcedii.Size = new System.Drawing.Size(558, 296);
            this.tabelConcedii.TabIndex = 53;
            // 
            // IdAngajat
            // 
            this.IdAngajat.AnimateReadOnly = false;
            this.IdAngajat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.IdAngajat.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.IdAngajat.Depth = 0;
            this.IdAngajat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.IdAngajat.HideSelection = true;
            this.IdAngajat.LeadingIcon = null;
            this.IdAngajat.Location = new System.Drawing.Point(295, 407);
            this.IdAngajat.MaxLength = 32767;
            this.IdAngajat.MouseState = MaterialSkin.MouseState.OUT;
            this.IdAngajat.Name = "IdAngajat";
            this.IdAngajat.PasswordChar = '\0';
            this.IdAngajat.PrefixSuffixText = null;
            this.IdAngajat.ReadOnly = false;
            this.IdAngajat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdAngajat.SelectedText = "";
            this.IdAngajat.SelectionLength = 0;
            this.IdAngajat.SelectionStart = 0;
            this.IdAngajat.ShortcutsEnabled = true;
            this.IdAngajat.Size = new System.Drawing.Size(59, 48);
            this.IdAngajat.TabIndex = 54;
            this.IdAngajat.TabStop = false;
            this.IdAngajat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.IdAngajat.TrailingIcon = null;
            this.IdAngajat.UseSystemPasswordChar = false;
            // 
            // IdConcediu
            // 
            this.IdConcediu.AnimateReadOnly = false;
            this.IdConcediu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.IdConcediu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.IdConcediu.Depth = 0;
            this.IdConcediu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.IdConcediu.HideSelection = true;
            this.IdConcediu.LeadingIcon = null;
            this.IdConcediu.Location = new System.Drawing.Point(382, 407);
            this.IdConcediu.MaxLength = 32767;
            this.IdConcediu.MouseState = MaterialSkin.MouseState.OUT;
            this.IdConcediu.Name = "IdConcediu";
            this.IdConcediu.PasswordChar = '\0';
            this.IdConcediu.PrefixSuffixText = null;
            this.IdConcediu.ReadOnly = false;
            this.IdConcediu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdConcediu.SelectedText = "";
            this.IdConcediu.SelectionLength = 0;
            this.IdConcediu.SelectionStart = 0;
            this.IdConcediu.ShortcutsEnabled = true;
            this.IdConcediu.Size = new System.Drawing.Size(59, 48);
            this.IdConcediu.TabIndex = 55;
            this.IdConcediu.TabStop = false;
            this.IdConcediu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.IdConcediu.TrailingIcon = null;
            this.IdConcediu.UseSystemPasswordChar = false;
            // 
            // Aproba
            // 
            this.Aproba.Font = new System.Drawing.Font("Stencil", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aproba.Location = new System.Drawing.Point(515, 373);
            this.Aproba.Name = "Aproba";
            this.Aproba.Size = new System.Drawing.Size(120, 41);
            this.Aproba.TabIndex = 56;
            this.Aproba.Text = "Aproba";
            this.Aproba.UseVisualStyleBackColor = true;
            this.Aproba.Click += new System.EventHandler(this.Aproba_Click);
            // 
            // Refuza
            // 
            this.Refuza.Font = new System.Drawing.Font("Stencil", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Refuza.Location = new System.Drawing.Point(515, 426);
            this.Refuza.Name = "Refuza";
            this.Refuza.Size = new System.Drawing.Size(120, 41);
            this.Refuza.TabIndex = 57;
            this.Refuza.Text = "refuza";
            this.Refuza.UseVisualStyleBackColor = true;
            this.Refuza.Click += new System.EventHandler(this.Refuza_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(382, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 34);
            this.label1.TabIndex = 58;
            this.label1.Text = "ID concediu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(295, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 34);
            this.label2.TabIndex = 59;
            this.label2.Text = "Id Angajat";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GestionareConcedii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MAINPROJ.Properties.Resources.reback;
            this.ClientSize = new System.Drawing.Size(914, 491);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Refuza);
            this.Controls.Add(this.Aproba);
            this.Controls.Add(this.IdConcediu);
            this.Controls.Add(this.IdAngajat);
            this.Controls.Add(this.tabelConcedii);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.sidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionareConcedii";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestionare";
            this.Load += new System.EventHandler(this.GestionareConcedii_Load);
            this.sidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabelConcedii)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Timer sidebarTimer;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView tabelConcedii;
        private MaterialSkin.Controls.MaterialTextBox2 IdAngajat;
        private MaterialSkin.Controls.MaterialTextBox2 IdConcediu;
        private System.Windows.Forms.Button Aproba;
        private System.Windows.Forms.Button Refuza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}