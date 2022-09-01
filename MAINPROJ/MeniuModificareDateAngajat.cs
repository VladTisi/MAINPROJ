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



        private void HomePage_Load(object sender, EventArgs e)
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
                txtDataAngajare.Text = rdr.GetValue(6).ToString();
                txtFunctie.Text = rdr.GetValue(7).ToString();
                txtEchipa.Text = rdr.GetValue(8).ToString();
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
            Console.WriteLine(myArray[0]);




        }

       
    }
}
