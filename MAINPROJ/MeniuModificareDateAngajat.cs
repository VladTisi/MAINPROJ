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
        string local = "http://localhost:5031/api";

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

           
        }
              

        private async void MeniuModificareDateAngajati_Load(object sender, EventArgs e)
        {
            showImage();
            start = pozaAngajat.Image;
           
            HttpResponseMessage response5 = await Common.client.GetAsync($"http://localhost:5031/api/MeniuModificareDateAngajat/GetDateleAngajat?Id={angajatId}");
            response5.EnsureSuccessStatusCode();
            string response5Body = await response5.Content.ReadAsStringAsync();

            var angajatulMEU  = JsonConvert.DeserializeObject<Angajat>(response5Body);


            txtNume.Text = angajatulMEU.Nume;

            txtPrenume.Text = angajatulMEU.Prenume;

            txtDataAngajare.Text = angajatulMEU.DataAngajarii.ToString();

            txtOvertime.Text = angajatulMEU.Overtime.ToString();

            txtSalariu.Text = angajatulMEU.Salariu.ToString(); 

            txtTelefon.Text = angajatulMEU.NumarTelefon.ToString();

            txtSex.Text = angajatulMEU.Sex;

            comboEchipa.Text = angajatulMEU.Echipa.ToString();

            comboFunctie.Text = angajatulMEU.Functie.ToString();



        }
        private async void showImage()
        {
            HttpResponseMessage response6 = await Common.client.GetAsync($"http://localhost:5031/api/MeniuModificareDateAngajat/GetPozaAngajat?Id={angajatIdSelectat}");
            response6.EnsureSuccessStatusCode();
            string response6Body = await response6.Content.ReadAsStringAsync();

            List<Angajat> listaAngajati4 = JsonConvert.DeserializeObject<List<Angajat>>(response6Body);



            string Poza = listaAngajati4[0].Poza.ToString();

            if (string.IsNullOrEmpty(Poza))
            { return; 
            }

            byte[] imgBytes = Convert.FromBase64String(Poza);
                     

            MemoryStream ms = new MemoryStream(imgBytes);

            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            pozaAngajat.Image = returnImage;
           

        }


        private async void comboListaAngajati_SelectedIndexChanged(object sender, EventArgs e)
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

            HttpResponseMessage respEch = await Common.client.GetAsync("http://localhost:5031/api/MeniuModificareDateAngajat/GetEchipe");
            respEch.EnsureSuccessStatusCode();
            string respEchBody = await respEch.Content.ReadAsStringAsync();

            List<RandomProj.Models.Echipa> listaEchipe = JsonConvert.DeserializeObject<List<RandomProj.Models.Echipa>>(respEchBody);
                      
            var bindingSourceEchipa = new BindingSource();
            bindingSourceEchipa.DataSource = listaEchipe;
            comboEchipa.DataSource = bindingSourceEchipa;
            comboEchipa.ValueMember = "Id";
            comboEchipa.DisplayMember = "Nume";

            HttpResponseMessage respFnct = await Common.client.GetAsync("http://localhost:5031/api/MeniuModificareDateAngajat/GetFunctii");
            respFnct.EnsureSuccessStatusCode();
            string respFnctBody = await respFnct.Content.ReadAsStringAsync();

            List<Functie> listaFunctii = JsonConvert.DeserializeObject<List<Functie>>(respFnctBody);

            var bindingSourceFunctie = new BindingSource();
            bindingSourceFunctie.DataSource = listaFunctii;
            comboFunctie.DataSource = bindingSourceFunctie;
            comboFunctie.ValueMember = "Id";
            comboFunctie.DisplayMember = "Nume";





            showImage();
        }

        private async void btnSalvareModificari_Click(object sender, EventArgs e)
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


            HttpResponseMessage response5 = await Common.client.GetAsync($"http://localhost:5031/api/MeniuModificareDateAngajat/GetDateleAngajat?Id={angajatId}");
            response5.EnsureSuccessStatusCode();
            string response5Body = await response5.Content.ReadAsStringAsync();

            var angajatulMEU = JsonConvert.DeserializeObject<Angajat>(response5Body);

            angajatulMEU.Nume = txtNume.Text;

            angajatulMEU.Prenume = txtPrenume.Text;

            angajatulMEU.NumarTelefon = txtTelefon.Text;

            angajatulMEU.Overtime = txtOvertime.Text;

            angajatulMEU.Salariu = txtSalariu.Text;

            angajatulMEU.IdFunctie = (int)comboFunctie.SelectedValue;

            angajatulMEU.IdEchipa = (int)comboEchipa.SelectedValue;

            int loginId = angajatulMEU.LoginId;

            string emailnou = txtEmail.Text;
                        
            //++MODIF EMAIL

            string jsonangajat = JsonConvert.SerializeObject(angajatulMEU);
            var myangj = new StringContent(jsonangajat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Common.client.PostAsync(local + $"UpdateDate", myangj);


            //OleDbConnection con4 = Common.GetConnection();
            //con4.Open();

            //dtpDataAngajare.Enabled = false;

            //string numartelefon = txtTelefon.Text;
            //string email = txtEmail.Text;
            //string modifTel = $"UPDATE Angajat SET Numar_telefon = '{numartelefon}' WHERE Id = '{angajatIdSelectat}' ";
            //cmd = new OleDbCommand(modifTel, con4);
            //cmd.ExecuteNonQuery();
            //string modifEmail = $"UPDATE Login SET Email = '{email}' WHERE Id = '{angajatIdSelectat}' ";
            //cmd.CommandText = modifEmail;
            //cmd.ExecuteNonQuery();
            //string modifNume = $"UPDATE Angajat SET Nume = '{txtNume.Text}' WHERE Id = '{angajatIdSelectat}' ";
            //cmd.CommandText = modifNume;
            //cmd.ExecuteNonQuery();
            //string modifPrenume = $"UPDATE Angajat SET Prenume = '{txtPrenume.Text}' WHERE Id = '{angajatIdSelectat}' ";
            //cmd.CommandText = modifPrenume;
            //cmd.ExecuteNonQuery();
            //string modifSalariu = $"UPDATE Angajat SET Salariu = '{txtSalariu.Text}' WHERE Id = '{angajatIdSelectat}' ";
            //cmd.CommandText = modifSalariu;
            //cmd.ExecuteNonQuery();
            //string modifOvertime = $"UPDATE Angajat SET Overtime = '{txtOvertime.Text}' WHERE Id = '{angajatIdSelectat}' ";
            //cmd.CommandText = modifOvertime;
            //cmd.ExecuteNonQuery();
            
            //con4.Close();
            //OleDbConnection con6 = Common.GetConnection();
            //con6.Open();

            //string echipaNoua = $"UPDATE Angajat SET IdEchipa = '{comboEchipa.SelectedValue}' WHERE Id = '{angajatIdSelectat}'";
            //cmd = new OleDbCommand(echipaNoua, con6);
            //cmd.ExecuteNonQuery();
            //string functieNoua = $"UPDATE Angajat SET IdFunctie = '{comboFunctie.SelectedValue}' WHERE Id = '{angajatIdSelectat}'";
            //cmd = new OleDbCommand(functieNoua, con6);
            //cmd.ExecuteNonQuery();

            

            //con6.Close();
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
