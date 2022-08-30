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
            this.label3 = new System.Windows.Forms.Label();
            this.dataSet1 = new MAINPROJ.DataSet1();
            this.tipConcediuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipConcediuTableAdapter = new MAINPROJ.DataSet1TableAdapters.TipConcediuTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipConcediuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MAINPROJ.Properties.Resources.Prison_Break_logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 331);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(329, 107);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Stencil", 12F);
            this.button1.Location = new System.Drawing.Point(737, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpDataIncepere
            // 
            this.dtpDataIncepere.Location = new System.Drawing.Point(561, 195);
            this.dtpDataIncepere.Name = "dtpDataIncepere";
            this.dtpDataIncepere.Size = new System.Drawing.Size(200, 20);
            this.dtpDataIncepere.TabIndex = 2;
            this.dtpDataIncepere.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dtpDataSfarsit
            // 
            this.dtpDataSfarsit.Location = new System.Drawing.Point(561, 246);
            this.dtpDataSfarsit.Name = "dtpDataSfarsit";
            this.dtpDataSfarsit.Size = new System.Drawing.Size(200, 20);
            this.dtpDataSfarsit.TabIndex = 3;
            this.dtpDataSfarsit.ValueChanged += new System.EventHandler(this.dtpDataSfarsit_ValueChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Stencil", 10F);
            this.label1.Location = new System.Drawing.Point(376, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data inceperii";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Stencil", 10F);
            this.label2.Location = new System.Drawing.Point(376, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data sfarsitului";
            // 
            // cmbTipConcediu
            // 
            this.cmbTipConcediu.DataSource = this.tipConcediuBindingSource;
            this.cmbTipConcediu.DisplayMember = "Nume";
            this.cmbTipConcediu.FormattingEnabled = true;
            this.cmbTipConcediu.Location = new System.Drawing.Point(561, 300);
            this.cmbTipConcediu.Name = "cmbTipConcediu";
            this.cmbTipConcediu.Size = new System.Drawing.Size(200, 21);
            this.cmbTipConcediu.TabIndex = 6;
            this.cmbTipConcediu.ValueMember = "Id";
            this.cmbTipConcediu.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Stencil", 10F);
            this.label3.Location = new System.Drawing.Point(376, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tip concediu";
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
            // tipConcediuTableAdapter
            // 
            this.tipConcediuTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Stencil", 10F);
            this.button2.Location = new System.Drawing.Point(513, 392);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 46);
            this.button2.TabIndex = 8;
            this.button2.Text = "Trimite cerere";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CerereConcediu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MAINPROJ.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
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
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.CerereConcediu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipConcediuBindingSource)).EndInit();
            this.ResumeLayout(false);

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
    }
}