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
    public partial class MeniuModificareDateAngajat : Form
    {
        private int angajatId;
        Image start;

        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();

        int angajatIdSelectat;

        public MeniuModificareDateAngajat(int angajatId)
        {
            this.angajatId = angajatId;

            InitializeComponent();
            AddItems();



        }

        private void AddItems()
        {
            OleDbConnection con = Common.GetConnection();
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            string numeprenumeAngajat = "SELECT  Nume, Prenume FROM Angajat";
            cmd = new OleDbCommand(numeprenumeAngajat, con);
            var rdr = cmd.ExecuteReader();

            

            while (rdr.Read())
            {
                comboListaAngajati.Items.Add(rdr.GetString(0) + ' ' + rdr.GetString(1));


            }

            con.Close();
        }
              

        private void MeniuModificareDateAngajati_Load(object sender, EventArgs e)
        {
            showImage();
            start = pozaAngajat.Image;
            OleDbConnection con1 = Common.GetConnection();
            con1.Open();
            OleDbCommand cmd = new OleDbCommand();
            

            string dateAngajat = $"SELECT  a.Nume as NumeA, a.Prenume, a.Salariu, a.Overtime, a.Numar_telefon, a.Sex, a.Data_angajarii,f.nume as Functie, e.nume as Echipa, l.Email as Email FROM Angajat a join functie f on a.IdFunctie = f.Id join echipa e on a.IdEchipa = e.Id join login l on l.AngajatId = a.Id where a.id ={angajatId}";
            cmd = new OleDbCommand(dateAngajat, con1);
            var rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                txtNume.Text = rdr.GetString(0);
                txtPrenume.Text = rdr.GetString(1);
                txtSalariu.Text = rdr.GetValue(2).ToString();
                txtOvertime.Text = rdr.GetValue(3).ToString();
                txtTelefon.Text = rdr.GetValue(4).ToString();
                txtSex.Text = rdr.GetValue(5).ToString();
                txtDataAngajare.Text = rdr.GetValue(6).ToString();
                comboEchipa.Text = rdr.GetValue(8).ToString();
                comboFunctie.Text = rdr.GetValue(7).ToString();
                txtEmail.Text = rdr.GetValue(9).ToString();
            }

            con1.Close();

        }
        private void showImage()
        {
            
            OleDbConnection con2 = Common.GetConnection();
            con2.Open();
            string selectpoza = $"SELECT Angajat.Poza FROM Angajat WHERE Angajat.Id={angajatIdSelectat}";
            cmd = new OleDbCommand(selectpoza, con2);
            string Poza = (string)cmd.ExecuteScalar();
            byte[] imgBytes = Convert.FromBase64String(Poza);

            MemoryStream ms = new MemoryStream(imgBytes);

            Image returnImage = Image.FromStream(ms);
            pozaAngajat.Image = returnImage;
            cmd.ExecuteNonQuery();
            con2.Close();

        }


        private void comboListaAngajati_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string[] myArray=comboListaAngajati.SelectedItem.ToString().Split(' ');
            

            OleDbConnection con3 = Common.GetConnection();
            con3.Open();
            OleDbCommand cmd = new OleDbCommand();


            string idAngajat = $"SELECT Id FROM Angajat WHERE Nume = '{myArray[0]}' AND Prenume = '{myArray[1]}'";
            cmd = new OleDbCommand(idAngajat, con3);
            angajatIdSelectat = (int)cmd.ExecuteScalar();

            string dateAngajat = $"SELECT  a.Nume as NumeA, a.Prenume, a.Salariu, a.Overtime, a.Numar_telefon, a.Sex, a.Data_angajarii,f.nume as Functie, e.nume as Echipa, l.Email as Email FROM Angajat a join functie f on a.IdFunctie = f.Id join echipa e on a.IdEchipa = e.Id join login l on l.AngajatId = a.Id where a.id ={angajatIdSelectat}";
            cmd = new OleDbCommand(dateAngajat, con3);
            var rdr = cmd.ExecuteReader();
           
                                   
            while (rdr.Read())
            {
                txtNume.Text = rdr.GetString(0);
                txtPrenume.Text = rdr.GetString(1);
                txtSalariu.Text = rdr.GetValue(2).ToString();
                txtOvertime.Text = rdr.GetValue(3).ToString();
                txtTelefon.Text = rdr.GetValue(4).ToString();
                txtSex.Text = rdr.GetValue(5).ToString();
                txtDataAngajare.Text = rdr.GetValue(6).ToString();
                comboEchipa.Text = rdr.GetValue(8).ToString();
                comboFunctie.Text = rdr.GetValue(7).ToString();
                txtEmail.Text = rdr.GetValue(9).ToString();
            }

            con3.Close();

            SqlConnection con8 = Common.GetSqlConnection() ;
            con8.Open();
                                                           
            string numeEchipe = "SELECT Id,Nume FROM Echipa";
            SqlDataAdapter dc = new SqlDataAdapter(numeEchipe, con8);
            DataSet dm = new DataSet();
            dc.Fill(dm, "Fleet");
            comboEchipa.DisplayMember = "Nume";
            comboEchipa.ValueMember = "Id";
            comboEchipa.DataSource = dm.Tables[0];

           

            string numeFunctii = "SELECT Id,Nume FROM Functie";
            SqlDataAdapter da = new SqlDataAdapter(numeFunctii, con8);
            DataSet ds = new DataSet();
            da.Fill(ds, "Fleet");
            comboFunctie.DisplayMember = "Nume";
            comboFunctie.ValueMember = "Id";
            comboFunctie.DataSource = ds.Tables[0];


            con8.Close();

            showImage();
        }

        private void btnSalvareModificari_Click(object sender, EventArgs e)
        {
            btnUpload.Visible = false;

            btnSalvareModificari.Visible = false;

            txtEmail.Enabled = false;

            txtTelefon.Enabled = false;

            txtNume.Enabled = false;

            txtPrenume.Enabled = false;

            txtOvertime.Enabled = false;

            txtSalariu.Enabled = false;

            txtDataAngajare.Enabled = false;

            comboEchipa.Enabled = false;

            comboFunctie.Enabled = false;

            OleDbConnection con4 = Common.GetConnection();
            con4.Open();

            dtpDataAngajare.Enabled = false;

            string numartelefon = txtTelefon.Text;
            string email = txtEmail.Text;
            string modifTel = $"UPDATE Angajat SET Numar_telefon = '{numartelefon}' WHERE Id = '{angajatIdSelectat}' ";
            cmd = new OleDbCommand(modifTel, con4);
            cmd.ExecuteNonQuery();
            string modifEmail = $"UPDATE Login SET Email = '{email}' WHERE Id = '{angajatIdSelectat}' ";
            cmd.CommandText = modifEmail;
            cmd.ExecuteNonQuery();
            string modifNume = $"UPDATE Angajat SET Nume = '{txtNume.Text}' WHERE Id = '{angajatIdSelectat}' ";
            cmd.CommandText = modifNume;
            cmd.ExecuteNonQuery();
            string modifPrenume = $"UPDATE Angajat SET Prenume = '{txtPrenume.Text}' WHERE Id = '{angajatIdSelectat}' ";
            cmd.CommandText = modifPrenume;
            cmd.ExecuteNonQuery();
            string modifSalariu = $"UPDATE Angajat SET Salariu = '{txtSalariu.Text}' WHERE Id = '{angajatIdSelectat}' ";
            cmd.CommandText = modifSalariu;
            cmd.ExecuteNonQuery();
            string modifOvertime = $"UPDATE Angajat SET Overtime = '{txtOvertime.Text}' WHERE Id = '{angajatIdSelectat}' ";
            cmd.CommandText = modifOvertime;
            cmd.ExecuteNonQuery();
            
            con4.Close();
            OleDbConnection con6 = Common.GetConnection();
            con6.Open();

            string echipaNoua = $"UPDATE Angajat SET IdEchipa = '{comboEchipa.SelectedValue}' WHERE Id = '{angajatIdSelectat}'";
            cmd = new OleDbCommand(echipaNoua, con6);
            cmd.ExecuteNonQuery();
            string functieNoua = $"UPDATE Angajat SET IdFunctie = '{comboFunctie.SelectedValue}' WHERE Id = '{angajatIdSelectat}'";
            cmd = new OleDbCommand(functieNoua, con6);
            cmd.ExecuteNonQuery();

            

            con6.Close();
        }

        private void btnModificareDate_Click(object sender, EventArgs e)
        {
            txtEmail.Enabled = true;

            txtTelefon.Enabled = true;

            txtDataAngajare.Enabled = true;

            txtNume.Enabled = true;

            txtPrenume.Enabled = true;

            txtOvertime.Enabled = true;

            txtSalariu.Enabled = true;

            dtpDataAngajare.Enabled = true;

            
            btnSalvareModificari.Visible = true;

            btnUpload.Visible = true;

            comboEchipa.Enabled = true;

            comboFunctie.Enabled = true;

           

        }

        private void MeniuModificareDateAngajat_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'prisonBreakDataSet.Echipa' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'dataSet2.Functie' table. You can move, or remove it, as needed.
           
            
        }

        private void dtpDataAngajare_ValueChanged(object sender, EventArgs e)
        {
            txtDataAngajare.Text = dtpDataAngajare.Value.ToString().Split(' ')[0];
            OleDbConnection con5 = Common.GetConnection();
            con5.Open();
            string dataNoua = $"UPDATE Angajat SET Data_angajarii = '{txtDataAngajare.Text}' WHERE Id = '{angajatIdSelectat}'";
            cmd = new OleDbCommand(dataNoua, con5);
            cmd.ExecuteNonQuery();
            con5.Close();
        }

        private void comboEchipa_SelectedIndexChanged(object sender, EventArgs e)
        {
           

           
        }

        private void comboFunctie_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

     

        private void pozaAngajat_Click(object sender, EventArgs e)
        {

        }

      

      

       

       

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select file";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "All files (*.*)|*.*|Text File (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;

          

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                byte[] myImage = new byte[fs.Length];
                fs.Read(myImage, 0, System.Convert.ToInt32(fs.Length));
         

                string pozaNoua = System.Convert.ToBase64String(myImage);
                pozaAngajat.Image = Image.FromStream(fs);
                fs.Close();
                OleDbConnection con6 = Common.GetConnection();

                con6.Open();

                if (pozaAngajat.Image != start)
                {
                    string queryUpdate = $"UPDATE Angajat SET Poza = '{pozaNoua}' WHERE Id = '{angajatIdSelectat}'";
                    cmd.CommandText = queryUpdate;
                    cmd.ExecuteNonQuery();
                }
                
                con6.Close();

            }

        }
    }
}
