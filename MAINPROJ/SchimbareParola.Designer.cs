namespace MAINPROJ
{
    partial class SchimbareParola
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtParolaVeche = new System.Windows.Forms.TextBox();
            this.txtParolaNoua = new System.Windows.Forms.TextBox();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Salvare = new System.Windows.Forms.Button();
            this.Renunta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MAINPROJ.Properties.Resources.background;
            this.pictureBox1.Location = new System.Drawing.Point(238, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(257, 211);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // txtParolaVeche
            // 
            this.txtParolaVeche.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParolaVeche.Location = new System.Drawing.Point(273, 30);
            this.txtParolaVeche.Name = "txtParolaVeche";
            this.txtParolaVeche.Size = new System.Drawing.Size(185, 22);
            this.txtParolaVeche.TabIndex = 2;
            // 
            // txtParolaNoua
            // 
            this.txtParolaNoua.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParolaNoua.Location = new System.Drawing.Point(273, 80);
            this.txtParolaNoua.Name = "txtParolaNoua";
            this.txtParolaNoua.PasswordChar = '*';
            this.txtParolaNoua.Size = new System.Drawing.Size(185, 22);
            this.txtParolaNoua.TabIndex = 3;
            this.txtParolaNoua.TextChanged += new System.EventHandler(this.txtParolaNoua_TextChanged);
            // 
            // txtConfirm
            // 
            this.txtConfirm.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirm.Location = new System.Drawing.Point(273, 128);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '*';
            this.txtConfirm.Size = new System.Drawing.Size(185, 22);
            this.txtConfirm.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Parola Veche";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Stencil", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Parola Noua";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Stencil", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Confirmare Parola";
            // 
            // Salvare
            // 
            this.Salvare.BackColor = System.Drawing.SystemColors.Desktop;
            this.Salvare.Font = new System.Drawing.Font("Stencil", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salvare.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Salvare.Location = new System.Drawing.Point(383, 176);
            this.Salvare.Name = "Salvare";
            this.Salvare.Size = new System.Drawing.Size(75, 23);
            this.Salvare.TabIndex = 8;
            this.Salvare.Text = "Salvare";
            this.Salvare.UseVisualStyleBackColor = false;
            this.Salvare.Click += new System.EventHandler(this.Salvare_Click);
            // 
            // Renunta
            // 
            this.Renunta.BackColor = System.Drawing.SystemColors.Desktop;
            this.Renunta.Font = new System.Drawing.Font("Stencil", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Renunta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Renunta.Location = new System.Drawing.Point(273, 176);
            this.Renunta.Name = "Renunta";
            this.Renunta.Size = new System.Drawing.Size(75, 23);
            this.Renunta.TabIndex = 9;
            this.Renunta.Text = "Renunta";
            this.Renunta.UseVisualStyleBackColor = false;
            this.Renunta.Click += new System.EventHandler(this.Renunta_Click);
            // 
            // SchimbareParola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MAINPROJ.Properties.Resources.reback;
            this.ClientSize = new System.Drawing.Size(496, 211);
            this.Controls.Add(this.Renunta);
            this.Controls.Add(this.Salvare);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.txtParolaNoua);
            this.Controls.Add(this.txtParolaVeche);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SchimbareParola";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.SchimbareParola_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtParolaVeche;
        private System.Windows.Forms.TextBox txtParolaNoua;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Salvare;
        private System.Windows.Forms.Button Renunta;
    }
}