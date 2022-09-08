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
using Newtonsoft.Json;
using System.Net.Http;
using RandomProj.Models;
using Microsoft.VisualBasic;
using static System.Net.WebRequestMethods;

namespace MAINPROJ
{
    public partial class HomePage : Form
    {
        private string backuptel;
        private string backupmail;
        private int angajatId;
        bool sidebarExpand;
        bool admin;
        bool manager;
        string pozaNoua;
        string local = "http://localhost:5031/api/";
        int angajatIdSelectat;
        System.Drawing.Image start;
        public int UserId { get; set; }
        public HomePage(int angajatId)
        {
            InitializeComponent();
            this.angajatId = angajatId;
            

        }
        private async void HomePage_Load(object sender, EventArgs e)
        {
            SetDate(angajatId);
            showImage(angajatId);
            AddItems();
            start = pozaAngajat.Image;

            var response = await Common.client.GetAsync(local + $"GestionareConcedii/GetAdmin?angajatId={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            admin = Convert.ToBoolean(responseBody);

            response = await Common.client.GetAsync(local + $"GestionareConcedii/GetManager?angajatId={angajatId}");
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            manager = Convert.ToBoolean(responseBody);
            
            if (admin != true && manager != true)
            {
                    button7.Visible = false;
                    button8.Visible = false;
                    comboListaAngajati.Visible = false;
            }
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
        private async void button2_Click(object sender, EventArgs e)
        {
            btnUpdatePoza.Visible = false;

            btnSalvareModificari.Visible = false;

            txtTelefon.Enabled = false;

            btnSalvareModificari.Visible = false;

            txtEmail.Enabled = false;

            txtNume.Enabled = false;

            txtPrenume.Enabled = false;

            txtOvertime.Enabled = false;

            txtSalariu.Enabled = false;

            txtDataAngajare.Enabled = false;

            comboEchipa.Enabled = false;

            comboFunctie.Enabled = false;
            //Accesibile de utilizator

            OleDbConnection con = Common.GetConnection();
            

            //modificare nr telefon
            string numartelefon = txtTelefon.Text;
            string email = txtEmail.Text;
            if (validareNrTelefon(numartelefon) == 1)
            {
                HttpResponseMessage response = await Common.client.PostAsync(local+$"HomePage/UpdateTelf?numarTelefon={numartelefon}&Id={angajatId}",null);
            }
            else
            {
                txtTelefon.Text = backuptel;
                MessageBox.Show("Numar de telefon invalid");
            }
            //modificare email
            if(email.Length <=100)
            {
                HttpResponseMessage response = await Common.client.PostAsync(local+$"HomePage/UpdateEmail?email={email}&Id={angajatId}", null);
            }
            else
            {
                txtEmail.Text = backupmail;
                MessageBox.Show("Email invalid");
            }

            //modificare poza
            if (pozaAngajat.Image != start)
            {
         
                HttpResponseMessage response = await Common.client.GetAsync(local + $"HomePage/GetAngajat?Id={angajatId}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();


                Angajat listaAngajati = JsonConvert.DeserializeObject<Angajat>(responseBody);
                listaAngajati.Poza = pozaNoua;
                string JsonAngajat=JsonConvert.SerializeObject(listaAngajati);
                var myAngj = new StringContent(JsonAngajat, Encoding.UTF8, "application/json");

                HttpResponseMessage response2 = await Common.client.PutAsync(local + $"HomePage/UpdatePoza", myAngj);
                response2.EnsureSuccessStatusCode();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            backuptel = txtTelefon.Text;
            backupmail = txtEmail.Text;
            txtEmail.Enabled = true;

            txtTelefon.Enabled = true;

            btnSalvareModificari.Visible = true;

            btnUpdatePoza.Visible = true;
            if(admin || manager)
            {
                txtNume.Enabled = true;

                txtPrenume.Enabled = true;

                txtOvertime.Enabled = true;

                txtSalariu.Enabled = true;

                txtDataAngajare.Enabled = true;

                comboEchipa.Enabled = true;

                comboFunctie.Enabled = true;
            }    

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
            var otherform = new MeniuNavigare(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new HomePage(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private async void showImage(int IdAngajat)
        {
            HttpResponseMessage response = await Common.client.GetAsync(local+$"HomePage/GetPoza?Id={IdAngajat}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();


            List<Angajat> listaAngajati = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);



            string Poza = listaAngajati[0].Poza.ToString();

            byte[] imgBytes = Convert.FromBase64String(Poza);

            MemoryStream ms = new MemoryStream(imgBytes);

        
            if (Poza != "")
            {
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                pozaAngajat.Image = returnImage;

            }

        
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


        private async void comboListaAngajati_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] myArray = comboListaAngajati.SelectedItem.ToString().Split(' ');


            OleDbConnection con3 = Common.GetConnection();
            con3.Open();
            OleDbCommand cmd = new OleDbCommand();


            HttpResponseMessage respId = await Common.client.GetAsync(local + $"HomePage/GetId?nume={myArray[0]}&prenume={myArray[1]}");
            respId.EnsureSuccessStatusCode();
            string respIdBody = await respId.Content.ReadAsStringAsync();
            angajatIdSelectat = Convert.ToInt32(respIdBody);


            SetDate(angajatIdSelectat);

            con3.Close();

            HttpResponseMessage respEch = await Common.client.GetAsync(local+"RegisterPage/GetIdNumeFromEchipa");
            respEch.EnsureSuccessStatusCode();
            string respEchBody = await respEch.Content.ReadAsStringAsync();

            List<Echipe> listaEchipe = JsonConvert.DeserializeObject<List<Echipe>>(respEchBody);

            var bindingSourceEchipa = new BindingSource();
            bindingSourceEchipa.DataSource = listaEchipe;
            comboEchipa.DataSource = bindingSourceEchipa;
            comboEchipa.ValueMember = "Id";
            comboEchipa.DisplayMember = "Nume";

            HttpResponseMessage respFnct = await Common.client.GetAsync(local+"RegisterPage/GetIdNumeFromFunctie");
            respFnct.EnsureSuccessStatusCode();
            string respFnctBody = await respFnct.Content.ReadAsStringAsync();

            List<Functie> listaFunctii = JsonConvert.DeserializeObject<List<Functie>>(respFnctBody);

            var bindingSourceFunctie = new BindingSource();
            bindingSourceFunctie.DataSource = listaFunctii;
            comboFunctie.DataSource = bindingSourceFunctie;
            comboFunctie.ValueMember = "Id";
            comboFunctie.DisplayMember = "Nume";

            showImage(angajatIdSelectat);
        }
        private async void AddItems()
        {
            HttpResponseMessage response = await Common.client.GetAsync(local+$"MeniuModificareDateAngajat/CheckAdmin?Id={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            bool checkAdm = Convert.ToBoolean(responseBody);

            if (checkAdm == true)
            {
                HttpResponseMessage response2 = await Common.client.GetAsync(local + $"MeniuModificareDateAngajat/GetAllNames\r\n");
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
                HttpResponseMessage response3 = await Common.client.GetAsync(local + $"MeniuModificareDateAngajat/GetIdEchipa?Id={angajatId}");
                response3.EnsureSuccessStatusCode();
                string response3Body = await response3.Content.ReadAsStringAsync();

                int echipaId = JsonConvert.DeserializeObject<int>(response3Body);


                //Console.WriteLine(echipaId);

                HttpResponseMessage response4 = await Common.client.GetAsync(local + $"MeniuModificareDateAngajat/GetMembriEchipa?echipaId={echipaId}");
                response4.EnsureSuccessStatusCode();
                string response4Body = await response4.Content.ReadAsStringAsync();

                List<Angajat> listaAngajati2 = JsonConvert.DeserializeObject<List<Angajat>>(response4Body);

                foreach (Angajat angajat in listaAngajati2)
                {
                    comboListaAngajati.Items.Add(angajat.Nume + ' ' + angajat.Prenume);
                }
            }
        }
        public async void SetDate(int angajatId)
        {
            HttpResponseMessage response5 = await Common.client.GetAsync(local + $"meniumodificaredateangajat/getdateangajat?id={angajatId}");
            response5.EnsureSuccessStatusCode();
            string response5body = await response5.Content.ReadAsStringAsync();
            List<Angajat> listaangajati3 = JsonConvert.DeserializeObject<List<Angajat>>(response5body);
            txtNume.Text = listaangajati3[0].Nume;
            txtPrenume.Text = listaangajati3[0].Prenume;
            txtDataAngajare.Text = ((DateTime)(listaangajati3[0].DataAngajarii)).ToString("dd/mm/yy");

            txtOvertime.Text = listaangajati3[0].Overtime.ToString();
            txtSalariu.Text = listaangajati3[0].Salariu.ToString();
            txtTelefon.Text = listaangajati3[0].NumarTelefon.ToString();
            txtSex.Text = listaangajati3[0].Sex;

            HttpResponseMessage response6 = await Common.client.GetAsync(local + $"HomePage/GetFunctieFromId?Id={listaangajati3[0].IdFunctie}");
            response6.EnsureSuccessStatusCode();
            string response6body = await response6.Content.ReadAsStringAsync();
            List<Functie> listafunctie = JsonConvert.DeserializeObject<List<Functie>>(response6body);
            comboFunctie.Text = listafunctie[0].Nume;

            HttpResponseMessage response7 = await Common.client.GetAsync(local + $"HomePage/GetEchipaFromId?Id={listaangajati3[0].IdEchipa}");
            response6.EnsureSuccessStatusCode();
            string response7body = await response7.Content.ReadAsStringAsync();
            List<Echipe> listaechipa = JsonConvert.DeserializeObject<List<Echipe>>(response7body);
            comboEchipa.Text = listaechipa[0].Nume;

            HttpResponseMessage response8 = await Common.client.GetAsync(local + $"HomePage/GetEmailFromId?Id={listaangajati3[0].Id}");
            response6.EnsureSuccessStatusCode();
            string response8body = await response8.Content.ReadAsStringAsync();
            List<Login> listaemail = JsonConvert.DeserializeObject<List<Login>>(response8body);
            txtEmail.Text = listaemail[0].Email;
        }
    }
}