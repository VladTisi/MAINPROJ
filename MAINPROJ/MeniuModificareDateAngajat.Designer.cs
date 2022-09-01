namespace MAINPROJ
{
    partial class MeniuModificareDateAngajat
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
            this.comboListaAngajati = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUpdatePoza = new System.Windows.Forms.Button();
            this.txtDataAngajare = new System.Windows.Forms.TextBox();
            this.txtSalariu = new System.Windows.Forms.TextBox();
            this.txtOvertime = new System.Windows.Forms.TextBox();
            this.txtEchipa = new System.Windows.Forms.TextBox();
            this.txtFunctie = new System.Windows.Forms.TextBox();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.txtPrenume = new System.Windows.Forms.TextBox();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnSalvareModificari = new System.Windows.Forms.Button();
            this.btnModificareDate = new System.Windows.Forms.Button();
            this.labelFunctie = new System.Windows.Forms.Label();
            this.labelPrenume = new System.Windows.Forms.Label();
            this.pozaAngajat = new System.Windows.Forms.PictureBox();
            this.labelSex = new System.Windows.Forms.Label();
            this.labelOvertime = new System.Windows.Forms.Label();
            this.labelSalariu = new System.Windows.Forms.Label();
            this.labelDataAngajare = new System.Windows.Forms.Label();
            this.labelNumarTelefon = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelEchipa = new System.Windows.Forms.Label();
            this.labelNume = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pozaAngajat)).BeginInit();
            this.SuspendLayout();
            // 
            // comboListaAngajati
            // 
            this.comboListaAngajati.FormattingEnabled = true;
            this.comboListaAngajati.Location = new System.Drawing.Point(636, 55);
            this.comboListaAngajati.Name = "comboListaAngajati";
            this.comboListaAngajati.Size = new System.Drawing.Size(121, 21);
            this.comboListaAngajati.TabIndex = 0;
            this.comboListaAngajati.SelectedIndexChanged += new System.EventHandler(this.comboListaAngajati_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MAINPROJ.Properties.Resources.Prison_Break_logo;
            this.pictureBox1.Location = new System.Drawing.Point(327, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(244, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 73;
            this.pictureBox1.TabStop = false;
            // 
            // btnUpdatePoza
            // 
            this.btnUpdatePoza.Location = new System.Drawing.Point(177, 135);
            this.btnUpdatePoza.Name = "btnUpdatePoza";
            this.btnUpdatePoza.Size = new System.Drawing.Size(90, 23);
            this.btnUpdatePoza.TabIndex = 72;
            this.btnUpdatePoza.Text = "Update";
            this.btnUpdatePoza.UseVisualStyleBackColor = true;
            this.btnUpdatePoza.Visible = false;
            // 
            // txtDataAngajare
            // 
            this.txtDataAngajare.Enabled = false;
            this.txtDataAngajare.Location = new System.Drawing.Point(641, 375);
            this.txtDataAngajare.Name = "txtDataAngajare";
            this.txtDataAngajare.Size = new System.Drawing.Size(100, 20);
            this.txtDataAngajare.TabIndex = 71;
            // 
            // txtSalariu
            // 
            this.txtSalariu.Enabled = false;
            this.txtSalariu.Location = new System.Drawing.Point(641, 312);
            this.txtSalariu.Name = "txtSalariu";
            this.txtSalariu.Size = new System.Drawing.Size(100, 20);
            this.txtSalariu.TabIndex = 70;
            // 
            // txtOvertime
            // 
            this.txtOvertime.Enabled = false;
            this.txtOvertime.Location = new System.Drawing.Point(641, 253);
            this.txtOvertime.Name = "txtOvertime";
            this.txtOvertime.Size = new System.Drawing.Size(100, 20);
            this.txtOvertime.TabIndex = 69;
            // 
            // txtEchipa
            // 
            this.txtEchipa.Enabled = false;
            this.txtEchipa.Location = new System.Drawing.Point(447, 251);
            this.txtEchipa.Name = "txtEchipa";
            this.txtEchipa.Size = new System.Drawing.Size(100, 20);
            this.txtEchipa.TabIndex = 68;
            // 
            // txtFunctie
            // 
            this.txtFunctie.Enabled = false;
            this.txtFunctie.Location = new System.Drawing.Point(447, 192);
            this.txtFunctie.Name = "txtFunctie";
            this.txtFunctie.Size = new System.Drawing.Size(100, 20);
            this.txtFunctie.TabIndex = 67;
            // 
            // txtSex
            // 
            this.txtSex.Enabled = false;
            this.txtSex.Location = new System.Drawing.Point(277, 253);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(100, 20);
            this.txtSex.TabIndex = 66;
            // 
            // txtPrenume
            // 
            this.txtPrenume.Enabled = false;
            this.txtPrenume.Location = new System.Drawing.Point(277, 228);
            this.txtPrenume.Name = "txtPrenume";
            this.txtPrenume.Size = new System.Drawing.Size(100, 20);
            this.txtPrenume.TabIndex = 65;
            // 
            // txtNume
            // 
            this.txtNume.Enabled = false;
            this.txtNume.Location = new System.Drawing.Point(277, 202);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(100, 20);
            this.txtNume.TabIndex = 64;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Enabled = false;
            this.txtTelefon.Location = new System.Drawing.Point(447, 375);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(100, 20);
            this.txtTelefon.TabIndex = 63;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(447, 314);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 62;
            // 
            // btnSalvareModificari
            // 
            this.btnSalvareModificari.Location = new System.Drawing.Point(629, 135);
            this.btnSalvareModificari.Name = "btnSalvareModificari";
            this.btnSalvareModificari.Size = new System.Drawing.Size(112, 23);
            this.btnSalvareModificari.TabIndex = 61;
            this.btnSalvareModificari.Text = "Salvare modificari";
            this.btnSalvareModificari.UseVisualStyleBackColor = true;
            this.btnSalvareModificari.Visible = false;
            // 
            // btnModificareDate
            // 
            this.btnModificareDate.Location = new System.Drawing.Point(629, 448);
            this.btnModificareDate.Name = "btnModificareDate";
            this.btnModificareDate.Size = new System.Drawing.Size(112, 24);
            this.btnModificareDate.TabIndex = 60;
            this.btnModificareDate.Text = "Modificare date";
            this.btnModificareDate.UseVisualStyleBackColor = true;
            // 
            // labelFunctie
            // 
            this.labelFunctie.AutoSize = true;
            this.labelFunctie.BackColor = System.Drawing.Color.Transparent;
            this.labelFunctie.Font = new System.Drawing.Font("Stencil", 11.75F);
            this.labelFunctie.Location = new System.Drawing.Point(443, 167);
            this.labelFunctie.Name = "labelFunctie";
            this.labelFunctie.Size = new System.Drawing.Size(74, 19);
            this.labelFunctie.TabIndex = 50;
            this.labelFunctie.Text = "Functie";
            // 
            // labelPrenume
            // 
            this.labelPrenume.AutoSize = true;
            this.labelPrenume.BackColor = System.Drawing.Color.Transparent;
            this.labelPrenume.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrenume.ForeColor = System.Drawing.Color.White;
            this.labelPrenume.Location = new System.Drawing.Point(174, 229);
            this.labelPrenume.Name = "labelPrenume";
            this.labelPrenume.Size = new System.Drawing.Size(83, 19);
            this.labelPrenume.TabIndex = 59;
            this.labelPrenume.Text = "Prenume";
            // 
            // pozaAngajat
            // 
            this.pozaAngajat.Location = new System.Drawing.Point(177, 19);
            this.pozaAngajat.Name = "pozaAngajat";
            this.pozaAngajat.Size = new System.Drawing.Size(90, 110);
            this.pozaAngajat.TabIndex = 58;
            this.pozaAngajat.TabStop = false;
            // 
            // labelSex
            // 
            this.labelSex.AutoSize = true;
            this.labelSex.BackColor = System.Drawing.Color.Transparent;
            this.labelSex.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSex.ForeColor = System.Drawing.Color.White;
            this.labelSex.Location = new System.Drawing.Point(174, 254);
            this.labelSex.Name = "labelSex";
            this.labelSex.Size = new System.Drawing.Size(37, 19);
            this.labelSex.TabIndex = 57;
            this.labelSex.Text = "sex";
            // 
            // labelOvertime
            // 
            this.labelOvertime.AutoSize = true;
            this.labelOvertime.BackColor = System.Drawing.Color.Transparent;
            this.labelOvertime.Font = new System.Drawing.Font("Stencil", 11.75F);
            this.labelOvertime.Location = new System.Drawing.Point(637, 228);
            this.labelOvertime.Name = "labelOvertime";
            this.labelOvertime.Size = new System.Drawing.Size(87, 19);
            this.labelOvertime.TabIndex = 56;
            this.labelOvertime.Text = "Overtime";
            // 
            // labelSalariu
            // 
            this.labelSalariu.AutoSize = true;
            this.labelSalariu.BackColor = System.Drawing.Color.Transparent;
            this.labelSalariu.Font = new System.Drawing.Font("Stencil", 11.75F);
            this.labelSalariu.Location = new System.Drawing.Point(637, 290);
            this.labelSalariu.Name = "labelSalariu";
            this.labelSalariu.Size = new System.Drawing.Size(75, 19);
            this.labelSalariu.TabIndex = 55;
            this.labelSalariu.Text = "Salariu";
            // 
            // labelDataAngajare
            // 
            this.labelDataAngajare.AutoSize = true;
            this.labelDataAngajare.BackColor = System.Drawing.Color.Transparent;
            this.labelDataAngajare.Font = new System.Drawing.Font("Stencil", 11.75F);
            this.labelDataAngajare.Location = new System.Drawing.Point(637, 353);
            this.labelDataAngajare.Name = "labelDataAngajare";
            this.labelDataAngajare.Size = new System.Drawing.Size(133, 19);
            this.labelDataAngajare.TabIndex = 54;
            this.labelDataAngajare.Text = "data Angajare";
            // 
            // labelNumarTelefon
            // 
            this.labelNumarTelefon.AutoSize = true;
            this.labelNumarTelefon.BackColor = System.Drawing.Color.Transparent;
            this.labelNumarTelefon.Font = new System.Drawing.Font("Stencil", 11.75F);
            this.labelNumarTelefon.Location = new System.Drawing.Point(443, 353);
            this.labelNumarTelefon.Name = "labelNumarTelefon";
            this.labelNumarTelefon.Size = new System.Drawing.Size(159, 19);
            this.labelNumarTelefon.TabIndex = 53;
            this.labelNumarTelefon.Text = "Numar de telefon";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.BackColor = System.Drawing.Color.Transparent;
            this.labelEmail.Font = new System.Drawing.Font("Stencil", 11.75F);
            this.labelEmail.Location = new System.Drawing.Point(443, 292);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(56, 19);
            this.labelEmail.TabIndex = 52;
            this.labelEmail.Text = "Email";
            // 
            // labelEchipa
            // 
            this.labelEchipa.AutoSize = true;
            this.labelEchipa.BackColor = System.Drawing.Color.Transparent;
            this.labelEchipa.Font = new System.Drawing.Font("Stencil", 11.75F);
            this.labelEchipa.Location = new System.Drawing.Point(443, 229);
            this.labelEchipa.Name = "labelEchipa";
            this.labelEchipa.Size = new System.Drawing.Size(65, 19);
            this.labelEchipa.TabIndex = 51;
            this.labelEchipa.Text = "Echipa";
            // 
            // labelNume
            // 
            this.labelNume.AutoSize = true;
            this.labelNume.BackColor = System.Drawing.Color.Transparent;
            this.labelNume.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNume.ForeColor = System.Drawing.Color.White;
            this.labelNume.Location = new System.Drawing.Point(174, 203);
            this.labelNume.Name = "labelNume";
            this.labelNume.Size = new System.Drawing.Size(53, 19);
            this.labelNume.TabIndex = 49;
            this.labelNume.Text = "Nume";
            // 
            // MeniuModificareDateAngajat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MAINPROJ.Properties.Resources.reback;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnUpdatePoza);
            this.Controls.Add(this.txtDataAngajare);
            this.Controls.Add(this.txtSalariu);
            this.Controls.Add(this.txtOvertime);
            this.Controls.Add(this.txtEchipa);
            this.Controls.Add(this.txtFunctie);
            this.Controls.Add(this.txtSex);
            this.Controls.Add(this.txtPrenume);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnSalvareModificari);
            this.Controls.Add(this.btnModificareDate);
            this.Controls.Add(this.labelFunctie);
            this.Controls.Add(this.labelPrenume);
            this.Controls.Add(this.pozaAngajat);
            this.Controls.Add(this.labelSex);
            this.Controls.Add(this.labelOvertime);
            this.Controls.Add(this.labelSalariu);
            this.Controls.Add(this.labelDataAngajare);
            this.Controls.Add(this.labelNumarTelefon);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelEchipa);
            this.Controls.Add(this.labelNume);
            this.Controls.Add(this.comboListaAngajati);
            this.Name = "MeniuModificareDateAngajat";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pozaAngajat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboListaAngajati;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnUpdatePoza;
        private System.Windows.Forms.TextBox txtDataAngajare;
        private System.Windows.Forms.TextBox txtSalariu;
        private System.Windows.Forms.TextBox txtOvertime;
        private System.Windows.Forms.TextBox txtEchipa;
        private System.Windows.Forms.TextBox txtFunctie;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.TextBox txtPrenume;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSalvareModificari;
        private System.Windows.Forms.Button btnModificareDate;
        private System.Windows.Forms.Label labelFunctie;
        private System.Windows.Forms.Label labelPrenume;
        private System.Windows.Forms.PictureBox pozaAngajat;
        private System.Windows.Forms.Label labelSex;
        private System.Windows.Forms.Label labelOvertime;
        private System.Windows.Forms.Label labelSalariu;
        private System.Windows.Forms.Label labelDataAngajare;
        private System.Windows.Forms.Label labelNumarTelefon;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelEchipa;
        private System.Windows.Forms.Label labelNume;
    }
}