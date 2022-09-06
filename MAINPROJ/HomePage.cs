using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAINPROJ;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MAINPROJ
{
    public partial class HomePage : Form
    {
        private string backuptel;
        private string backupmail;
        private int angajatId;
        bool sidebarExpand;
        OleDbCommand cmd = new OleDbCommand();
        string pozaNoua;
        Image start;

        public int UserId { get; set; }
        public HomePage(int angajatId)
        {
            InitializeComponent();
            this.angajatId = angajatId;

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            OleDbConnection con3 = Common.GetConnection();
            con3.Open();

            OleDbCommand cmd1 = new OleDbCommand();
            string comanda = $"declare @numar as int  set @numar=(select datediff( month, Angajat.Data_angajarii, Getdate() )*2  from Angajat where Id={angajatId}) UPDATE Angajat set ZileConcediuRamase= (select @numar - isnull(sum( datediff( day, Concediu.Data_inceput, Concediu.Data_sfarsit )- datediff( week, Concediu.Data_inceput, Concediu.Data_sfarsit )*2 +1),0) as Zile  from Angajat   join Concediu on Angajat.Id=Concediu.angajatId  join StareConcediu on Concediu.stareConcediuId=StareConcediu.Id  where Angajat.Id={angajatId} and StareConcediu.Id=2) WHERE Id={angajatId}";
            cmd1 = new OleDbCommand(comanda, con3);
            cmd1.ExecuteNonQuery();

            string dateAngajat = $"SELECT  a.Nume as NumeA, a.Prenume, a.Salariu, a.Overtime, a.Numar_telefon, a.Sex, a.Data_angajarii,f.nume as Functie, e.nume as Echipa, l.Email as Email FROM Angajat a join functie f on a.IdFunctie = f.Id join echipa e on a.IdEchipa = e.Id join login l on l.AngajatId = a.Id where a.id ={angajatId}";
            cmd = new OleDbCommand(dateAngajat, con3);
            var rdr = cmd.ExecuteReader();
            showImage();
            start = pozaAngajat.Image;
            while (rdr.Read())
            {
                txtNume.Text = rdr.GetString(0);
                txtPrenume.Text = rdr.GetString(1);
                txtSalariu.Text = rdr.GetValue(2).ToString();
                txtOvertime.Text = rdr.GetValue(3).ToString();
                txtTelefon.Text = rdr.GetValue(4).ToString();
                txtSex.Text = rdr.GetValue(5).ToString();
                txtDataAngajare.Text = rdr.GetValue(6).ToString();
                txtFunctie.Text = rdr.GetValue(7).ToString();
                txtEchipa.Text = rdr.GetValue(8).ToString();
                txtEmail.Text = rdr.GetValue(9).ToString();
            }

            string dateAdmin = $"SELECT  esteAdmin, IdFunctie FROM Angajat WHERE Id={angajatId}";
            cmd = new OleDbCommand(dateAdmin, con3);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                bool admin = rdr.GetBoolean(0);
                int manager = rdr.GetInt32(1);
                if (admin != true && manager != 3)
                {
                    button7.Visible = false;
                    button8.Visible = false;
                }
            }
            con3.Close();

        }

        private int validareNrTelefon(string telefon)
        {
            bool hasNumbersOnly = false;
            if (telefon.Length != 10)
            {
                return 0;
            }
            char[] myCharArray = telefon.ToCharArray();
            for (int i = 0; i < myCharArray.Length; i++)
            {
                if (!Char.IsDigit(myCharArray[i]))
                {
                    break;
                }
                hasNumbersOnly = true;
            }



            if (hasNumbersOnly)
            {
                return 1;
            }
            return 0;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            btnUpdatePoza.Visible = false;

            btnSalvareModificari.Visible = false;

            txtEmail.Enabled = false;

            txtTelefon.Enabled = false;

            //Accesibile de utilizator

            OleDbConnection con = Common.GetConnection();
            con.Open();

            //modificare nr telefon
            string numartelefon = txtTelefon.Text;
            string email = txtEmail.Text;
            if (validareNrTelefon(numartelefon) == 1)
            {
                string modifTel = $"UPDATE Angajat SET Numar_telefon = '{numartelefon}' WHERE Id = '{angajatId}' ";
                cmd = new OleDbCommand(modifTel, con);
                cmd.ExecuteNonQuery();
            }
            else
            {
                txtTelefon.Text = backuptel;
                MessageBox.Show("Numar de telefon invalid");
               
            }
            //modificare email
            if(email.Length <=100)
            {
            string modifEmail = $"UPDATE Login SET Email = '{email}' WHERE Id = '{angajatId}' ";
            cmd.CommandText = modifEmail;
            cmd.ExecuteNonQuery();
            }
            else
            {
                txtEmail.Text = backupmail;
                MessageBox.Show("Email invalid");

            }
            
            //modificare poza
            if(pozaAngajat.Image!=start)
            {
                string modifPoza = $"UPDATE Angajat SET Poza = '{pozaNoua}' WHERE Id = '{angajatId}' ";
                cmd.CommandText = modifPoza;
                cmd.ExecuteNonQuery();
            }
            con.Close();

           
        }


        private void button6_Click(object sender, EventArgs e)
        {
            backuptel = txtTelefon.Text;
            backupmail = txtEmail.Text;
            txtEmail.Enabled = true;

            txtTelefon.Enabled = true;

            btnSalvareModificari.Visible = true;

            btnUpdatePoza.Visible = true;
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuNavigare(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new ConcediiRefuzate(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new Echipa(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new HomePage(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void showImage()
        {

            OleDbConnection con = Common.GetConnection();
            string selectpoza = $"SELECT Angajat.Poza FROM Angajat WHERE Angajat.Id={angajatId}";
            cmd = new OleDbCommand(selectpoza, con);
            string Poza = (string)cmd.ExecuteScalar();
            byte[] imgBytes = Convert.FromBase64String(Poza);

            MemoryStream ms = new MemoryStream(imgBytes);
            if (Poza != "")
            {
                Image returnImage = Image.FromStream(ms);
                pozaAngajat.Image = returnImage;

            }

        
    }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new GestionareConcedii(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuModificareDateAngajat(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void btnUpdatePoza_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pozaAngajat.Image = new Bitmap(open.FileName);
                byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(pozaAngajat.Image, typeof(byte[]));
                pozaNoua = Convert.ToBase64String(bytes);
                

                // image file path  
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDataAngajare_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOvertime_TextChanged(object sender, EventArgs e)
        {

        }

        private void pozaAngajat_Click(object sender, EventArgs e)
        {

        }
    }
}