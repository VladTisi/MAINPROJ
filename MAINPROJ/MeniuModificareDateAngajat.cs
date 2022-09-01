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

namespace MAINPROJ
{
    public partial class MeniuModificareDateAngajat : Form
    {
        private int angajatId;

        OleDbCommand cmd = new OleDbCommand();

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
            OleDbConnection con3 = Common.GetConnection();
            con3.Open();
            OleDbCommand cmd = new OleDbCommand();
            

            string dateAngajat = $"SELECT  a.Nume as NumeA, a.Prenume, a.Salariu, a.Overtime, a.Numar_telefon, a.Sex, a.Data_angajarii,f.nume as Functie, e.nume as Echipa, l.Email as Email FROM Angajat a join functie f on a.IdFunctie = f.Id join echipa e on a.IdEchipa = e.Id join login l on l.AngajatId = a.Id where a.id ={angajatId}";
            cmd = new OleDbCommand(dateAngajat, con3);
            var rdr = cmd.ExecuteReader();
            showImage();
            while (rdr.Read())
            {
                txtNume.Text = rdr.GetString(0);
                txtPrenume.Text = rdr.GetString(1);
                txtSalariu.Text = rdr.GetValue(2).ToString();
                txtOvertime.Text = rdr.GetValue(3).ToString();
                txtTelefon.Text = rdr.GetValue(4).ToString();
                txtSex.Text = rdr.GetValue(5).ToString();
                //txtDataAngajare.Text = rdr.GetValue(6).ToString();
                //txtFunctie.Text = rdr.GetValue(7).ToString();
                //txtEchipa.Text = rdr.GetValue(8).ToString();
                txtEmail.Text = rdr.GetValue(9).ToString();
            }

            con3.Close();

        }
        private void showImage()
        {

            OleDbConnection con = Common.GetConnection();
            string selectpoza = $"SELECT Angajat.Poza FROM Angajat WHERE Angajat.Id={angajatId}";
            cmd = new OleDbCommand(selectpoza, con);
            string Poza = (string)cmd.ExecuteScalar();
            byte[] imgBytes = Convert.FromBase64String(Poza);

            MemoryStream ms = new MemoryStream(imgBytes);

            Image returnImage = Image.FromStream(ms);
            pozaAngajat.Image = returnImage;
            cmd.ExecuteNonQuery();

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
                //txtFunctie.Text = rdr.GetValue(7).ToString();
                //txtEchipa.Text = rdr.GetValue(8).ToString();
                txtEmail.Text = rdr.GetValue(9).ToString();
            }

            con3.Close();


        }

        private void btnSalvareModificari_Click(object sender, EventArgs e)
        {
            btnUpdatePoza.Visible = false;

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

            OleDbConnection con = Common.GetConnection();
            con.Open();

            dtpDataAngajare.Enabled = false;

            string numartelefon = txtTelefon.Text;
            string email = txtEmail.Text;
            string modifTel = $"UPDATE Angajat SET Numar_telefon = '{numartelefon}' WHERE Id = '{angajatIdSelectat}' ";
            cmd = new OleDbCommand(modifTel, con);
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


         







            con.Close();
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

            btnUpdatePoza.Visible = true;

            comboEchipa.Enabled = true;

            comboFunctie.Enabled = true;

        }

        private void MeniuModificareDateAngajat_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'prisonBreakDataSet.Echipa' table. You can move, or remove it, as needed.
            this.echipaTableAdapter.Fill(this.prisonBreakDataSet.Echipa);
            // TODO: This line of code loads data into the 'dataSet2.Functie' table. You can move, or remove it, as needed.
            this.functieTableAdapter.Fill(this.dataSet2.Functie);

        }

        private void dtpDataAngajare_ValueChanged(object sender, EventArgs e)
        {
            txtDataAngajare.Text = dtpDataAngajare.Value.ToString().Split(' ')[0];
            OleDbConnection con = Common.GetConnection();
            con.Open();
            string dataNoua = $"UPDATE Angajat SET Data_angajarii = '{txtDataAngajare.Text}' WHERE Id = '{angajatIdSelectat}'";
            cmd = new OleDbCommand(dataNoua, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void comboEchipa_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection con = Common.GetConnection();
            con.Open();
            string echipaNoua = $"UPDATE Angajat SET IdEchipa = '{comboEchipa.SelectedValue}' WHERE Id = '{angajatIdSelectat}'";
            cmd = new OleDbCommand(echipaNoua, con);
            cmd.ExecuteNonQuery();
            con.Close();

           
        }

        private void comboFunctie_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection con = Common.GetConnection();
            con.Open();
            string functieNoua = $"UPDATE Angajat SET IdFunctie = '{comboFunctie.SelectedValue}' WHERE Id = '{angajatIdSelectat}'";
            cmd = new OleDbCommand(functieNoua, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
