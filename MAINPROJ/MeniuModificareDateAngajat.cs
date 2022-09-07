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
using System.Net.Http;
using Newtonsoft.Json;
using RandomProj.Models;

namespace MAINPROJ
{
    public partial class MeniuModificareDateAngajat : Form
    {
        private int angajatId;
        System.Drawing.Image start;
        bool sidebarExpand;
        bool admin;
        bool manager;

        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();

        int angajatIdSelectat;

        public MeniuModificareDateAngajat(int angajatId,bool admin,bool manager)
        {
            this.angajatId = angajatId;
            InitializeComponent();
            this.admin = admin;
            this.manager = manager;
            AddItems();

        }

        private async void AddItems()
        {


            HttpResponseMessage  response =  await  Common.client.GetAsync($"http://localhost:5031/api/MeniuModificareDateAngajat/CheckAdmin?Id={angajatId}");
            response.EnsureSuccessStatusCode(); 
            string responseBody = await response.Content.ReadAsStringAsync();

            bool checkAdm = Convert.ToBoolean(responseBody);

            if (checkAdm == true)
            {
                HttpResponseMessage response2 = await Common.client.GetAsync("http://localhost:5031/api/MeniuModificareDateAngajat/GetAllNames\r\n");
                response2.EnsureSuccessStatusCode();
                string response2Body = await response2.Content.ReadAsStringAsync();

                List<Angajat> listaAngajati = JsonConvert.DeserializeObject<List<Angajat>>(response2Body);

                foreach (Angajat angajat in listaAngajati)
                {
                    comboListaAngajati.Items.Add(angajat.Nume + ' ' + angajat.Prenume);
                }

               
            }
            else
            {
                HttpResponseMessage response3 = await Common.client.GetAsync($"http://localhost:5031/api/MeniuModificareDateAngajat/GetIdEchipa?Id={angajatId}");
                response3.EnsureSuccessStatusCode();
                string response3Body = await response3.Content.ReadAsStringAsync();

                List<Angajat> listaAngajati = JsonConvert.DeserializeObject<List<Angajat>>(response3Body);

                int echipaId = (int) listaAngajati[0].IdEchipa;

                //Console.WriteLine(echipaId);

                HttpResponseMessage response4 = await Common.client.GetAsync($"http://localhost:5031/api/MeniuModificareDateAngajat/GetMembriEchipa?echipaId={echipaId}");
                response4.EnsureSuccessStatusCode();
                string response4Body = await response4.Content.ReadAsStringAsync();

                List<Angajat> listaAngajati2 = JsonConvert.DeserializeObject<List<Angajat>>(response4Body);

                foreach (Angajat angajat in listaAngajati2)
                {
                    comboListaAngajati.Items.Add(angajat.Nume + ' ' + angajat.Prenume);
                }




            }

            //List<Angajat> listaAngajati = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);



            //OleDbConnection con = Common.GetConnection();
            //con.Open();

            //OleDbCommand cmdtestadmin = new OleDbCommand();
            //string idadminQuery = $"select esteAdmin FROM Angajat WHERE Id={angajatId}";
            //cmdtestadmin = new OleDbCommand(idadminQuery, con);
            //int idadmintest = Convert.ToInt32(cmdtestadmin.ExecuteScalar());
            //Console.WriteLine(idadmintest);
            //if (idadmintest == 1)
            //{
            //    OleDbCommand cmd5 = new OleDbCommand();
            //    string numeQuery = $"SELECT Nume,Prenume FROM Angajat";
            //    cmd5 = new OleDbCommand(numeQuery, con);
            //    var rdr2 = cmd5.ExecuteReader();
            //    while (rdr2.Read())
            //    {
            //        comboListaAngajati.Items.Add(rdr2.GetString(0) + ' ' + rdr2.GetString(1));
            //    }

            //}
            //else
            //{
            //    OleDbCommand cmdid = new OleDbCommand();
            //    string idEchipa = $"select IdEchipa FROM Angajat WHERE Id = '{angajatId}'";
            //    cmdid = new OleDbCommand(idEchipa, con);
            //    var idEchipaQuerry = cmdid.ExecuteScalar();



            //    OleDbCommand cmd = new OleDbCommand();
            //    string numeprenumeAngajat = $"select Angajat.Nume , Angajat.Prenume from Angajat JOIN Echipa on Angajat.IdEchipa = Echipa.Id  where Angajat.IdEchipa = '{idEchipaQuerry}' ";
            //    cmd = new OleDbCommand(numeprenumeAngajat, con);
            //    var rdr = cmd.ExecuteReader();



            //    while (rdr.Read())
            //    {
            //        comboListaAngajati.Items.Add(rdr.GetString(0) + ' ' + rdr.GetString(1));


            //    }
            //}


            //con.Close();
        }
              

        private async void MeniuModificareDateAngajati_Load(object sender, EventArgs e)
        {
            showImage();
            start = pozaAngajat.Image;
            //OleDbConnection con1 = Common.GetConnection();
            //con1.Open();
            //OleDbCommand cmd = new OleDbCommand();

            HttpResponseMessage response5 = await Common.client.GetAsync($"http://localhost:5031/api/MeniuModificareDateAngajat/GetDateAngajat?Id={angajatId}");
            response5.EnsureSuccessStatusCode();
            string response5Body = await response5.Content.ReadAsStringAsync();

            List<Angajat> listaAngajati3 = JsonConvert.DeserializeObject<List<Angajat>>(response5Body);

            txtNume.Text = listaAngajati3[0].Nume;

            txtPrenume.Text = listaAngajati3[0].Prenume;

            txtDataAngajare.Text = listaAngajati3[0].DataAngajarii.ToString();

            txtOvertime.Text = listaAngajati3[0].Overtime.ToString();

            txtSalariu.Text = listaAngajati3[0].Salariu.ToString(); 

            txtTelefon.Text = listaAngajati3[0].NumarTelefon.ToString();

            txtSex.Text = listaAngajati3[0].Sex;

            comboEchipa.Text = listaAngajati3[0].Echipa.ToString();

            comboFunctie.Text = listaAngajati3[0].Functie.ToString();

            //HttpResponseMessage response7 = await Common.client.GetAsync($"http://localhost:5031/api/MeniuModificareDateAngajat/GetEchipe");
            //response5.EnsureSuccessStatusCode();
            //string response7Body = await response7.Content.ReadAsStringAsync();

            //List<Angajat> listaAngajati5 = JsonConvert.DeserializeObject<List<Angajat>>(response7Body);

            //comboEchipa.Text = listaAngajati5[0].Nume.ToString();











            //string dateAngajat = $"SELECT  a.Nume as NumeA, a.Prenume, a.Salariu, a.Overtime, a.Numar_telefon, a.Sex, a.Data_angajarii,f.nume as Functie, e.nume as Echipa, l.Email as Email FROM Angajat a join functie f on a.IdFunctie = f.Id join echipa e on a.IdEchipa = e.Id join login l on l.AngajatId = a.Id where a.id ={angajatId}";
            //cmd = new OleDbCommand(dateAngajat, con1);
            //var rdr = cmd.ExecuteReader();

            //while (rdr.Read())
            //{
            //    txtNume.Text = rdr.GetString(0);
            //    txtPrenume.Text = rdr.GetString(1);
            //    txtSalariu.Text = rdr.GetValue(2).ToString();
            //    txtOvertime.Text = rdr.GetValue(3).ToString();
            //    txtTelefon.Text = rdr.GetValue(4).ToString();
            //    txtSex.Text = rdr.GetValue(5).ToString();
            //    txtDataAngajare.Text = rdr.GetValue(6).ToString();
            //    comboEchipa.Text = rdr.GetValue(8).ToString();
            //    comboFunctie.Text = rdr.GetValue(7).ToString();
            //    txtEmail.Text = rdr.GetValue(9).ToString();
            //}

            //con1.Close();

        }
        private async void showImage()
        {
            HttpResponseMessage response6 = await Common.client.GetAsync($"http://localhost:5031/api/MeniuModificareDateAngajat/GetPozaAngajat?Id={angajatIdSelectat}");
            response6.EnsureSuccessStatusCode();
            string response6Body = await response6.Content.ReadAsStringAsync();

            List<Angajat> listaAngajati4 = JsonConvert.DeserializeObject<List<Angajat>>(response6Body);



            string Poza = listaAngajati4[0].Poza.ToString();

            byte[] imgBytes = Convert.FromBase64String(Poza);
                     

            MemoryStream ms = new MemoryStream(imgBytes);

            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            pozaAngajat.Image = returnImage;
           

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
                pozaAngajat.Image = System.Drawing.Image.FromStream(fs);
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

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new HomePage(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new ConcediiRefuzate(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new Echipa(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuNavigare(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new GestionareConcedii(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuModificareDateAngajat(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new Recrutam(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }
    }
}
