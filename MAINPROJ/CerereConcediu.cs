using MAINPROJ;
using Newtonsoft.Json;
using RandomProj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MAINPROJ
{
    public partial class CerereConcediu : Form
    {
        private int angajatId;
        OleDbCommand cmd = new OleDbCommand();
        bool sidebarExpand;
        private System.Windows.Forms.Timer tmr;
        bool admin;
        bool manager;
        String url = "http://localhost:5031/api/";
        public CerereConcediu(int angajatId,bool admin, bool manager)
        {
            InitializeComponent();
            this.angajatId = angajatId;
            this.admin = admin; 
            this.manager = manager;

            tmr = new System.Windows.Forms.Timer();
            tmr.Tick += delegate {
                this.Close();
            };
            tmr.Interval = (int)TimeSpan.FromMinutes(5).TotalMilliseconds;
            tmr.Start();
        }

        private async void CerereConcediu_Load(object sender, EventArgs e)
        {


            HttpResponseMessage response3 = await Common.client.GetAsync(url + $"MeniuModificareDateAngajat/GetIdEchipa?Id={angajatId}");
            response3.EnsureSuccessStatusCode();

            string result = await response3.Content.ReadAsStringAsync();

            var ceva = JsonConvert.DeserializeObject(result);

            int echipaId = Convert.ToInt32(ceva);



            HttpResponseMessage response4 = await Common.client.GetAsync(url + $"MeniuModificareDateAngajat/GetMembriEchipa?echipaId={echipaId}");
            response4.EnsureSuccessStatusCode();
            string response4Body = await response4.Content.ReadAsStringAsync();

            List<Angajat> listaAngajati2 = JsonConvert.DeserializeObject<List<Angajat>>(response4Body);
            var bindingSourceAngajat = new BindingSource();
            bindingSourceAngajat.DataSource = listaAngajati2;
            cmbInlocuitor.DataSource = bindingSourceAngajat;
            cmbInlocuitor.ValueMember = "Id";
            cmbInlocuitor.DisplayMember = "Nume";

            

            this.tipConcediuTableAdapter.Fill(this.dataSet1.TipConcediu);
            
            HttpResponseMessage response = await Common.client.GetAsync(url+$"ConcediiPersonale/GetAdminFunctieFromAngajat?angajatId={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Angajat> listaParole = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);
            bool admin = (bool)listaParole[0].EsteAdmin;
            int manager = (int)listaParole[0].IdFunctie;


            if (admin != true && manager != 3)
            {
                btnGestionareConcedii.Visible = false;
            }

            
            HttpResponseMessage response2 = await Common.client.GetAsync(url+$"CerereConcediu/GetZileRamase?angajatId={angajatId}");
            response2.EnsureSuccessStatusCode();
            string responseBody2 = await response2.Content.ReadAsStringAsync();
            int s = Convert.ToInt32(responseBody2);
            label5.Text=Convert.ToString(s);

            HttpResponseMessage response12 = await Common.client.GetAsync(url + $"CerereConcediu/GetZileRamaseMedical?angajatId={angajatId}");
            response12.EnsureSuccessStatusCode();
            string responseBody12 = await response12.Content.ReadAsStringAsync();
            s = Convert.ToInt32(responseBody12);
            label11.Text = Convert.ToString(s);

            HttpResponseMessage response13 = await Common.client.GetAsync(url + $"CerereConcediu/GetZileDeces?angajatId={angajatId}");
            response13.EnsureSuccessStatusCode();
            string responseBody13 = await response13.Content.ReadAsStringAsync();
            s = Convert.ToInt32(responseBody13);
            label12.Text = Convert.ToString(s);

            HttpResponseMessage response14 = await Common.client.GetAsync(url + $"CerereConcediu/GetZileNeplatite?angajatId={angajatId}");
            response14.EnsureSuccessStatusCode();
            string responseBody14 = await response14.Content.ReadAsStringAsync();
            s = Convert.ToInt32(responseBody14);
            label13.Text = Convert.ToString(s);

        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

       

        private void dtpDataSfarsit_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDataSfarsit.Value<dtpDataIncepere.Value)
            {
                MessageBox.Show("Data sfarsitului nu poate fi in trecut");
                dtpDataSfarsit.Value=dtpDataIncepere.Value.AddDays(1);
            }
        }

        private async void btnCerere_Click(object sender, EventArgs e)
        {


            int nr = (dtpDataSfarsit.Value-dtpDataIncepere.Value).Days+1;
            Console.WriteLine(nr);
            HttpResponseMessage response15 = await Common.client.GetAsync(url + $"CerereConcediu/GetConcediuDeja?angajatId={angajatId}&Inceput={dtpDataIncepere.Value}&Sfarsit={dtpDataSfarsit.Value}");
            response15.EnsureSuccessStatusCode();
            HttpResponseMessage response16 = await Common.client.GetAsync(url + $"CerereConcediu/GetConcediuDeja?angajatId={cmbInlocuitor.SelectedValue}&Inceput={dtpDataIncepere.Value}&Sfarsit={dtpDataSfarsit.Value}");
            response16.EnsureSuccessStatusCode();
            string responseBody15 = await response15.Content.ReadAsStringAsync();
            string responseBody16 = await response16.Content.ReadAsStringAsync();
            if ((int)cmbTipConcediu.SelectedValue == 1 && nr > Convert.ToInt32(label5.Text))
                MessageBox.Show("Nu ai destule zile de concediu");

            else if ((int)cmbTipConcediu.SelectedValue == 2 && nr > Convert.ToInt32(label11.Text))
                MessageBox.Show("Nu ai destule zile de concediu");

            else if ((int)cmbTipConcediu.SelectedValue == 3 && nr > Convert.ToInt32(label13.Text))
                MessageBox.Show("Nu ai destule zile de concediu");

            else if ((int)cmbTipConcediu.SelectedValue == 4 && nr > Convert.ToInt32(label12.Text))
                MessageBox.Show("Nu ai destule zile de concediu");

            else if (!Convert.ToBoolean(responseBody16))
                MessageBox.Show("Inlocuitorul ales are concediu in acea perioada");

            else if (Convert.ToBoolean(responseBody15))
            {
                MessageBox.Show("Cerere de concediu adaugata!");
                HttpResponseMessage response = await Common.client.PostAsync(url+$"CerereConcediu/InsertConcediu?TipConcediuId={cmbTipConcediu.SelectedValue}&Inceput={dtpDataIncepere.Value}&Sfarsit={dtpDataSfarsit.Value}&angajatId={angajatId}&inlocuitorId={cmbInlocuitor.SelectedValue}",null);
            }
            else
            {
                MessageBox.Show("Exista deja o cerere de concediu aprobata in acea perioada");
            }
            dtpDataIncepere.Value=DateTime.Now.AddDays(1);
            dtpDataSfarsit.Value=dtpDataIncepere.Value.AddDays(1);
            Console.WriteLine(nr);
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void btnHomePage_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new HomePage(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void btnConcediiPersonale_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new ConcediiRefuzate(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void btnEchipa_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new Echipa(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void btnListaAngajati_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuNavigare(angajatId,admin,manager);
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

        private void btnGestionareConcedii_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new GestionareConcedii(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void ComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            string Nume = ((Angajat)e.ListItem).Nume;
            string Prenume = ((Angajat)e.ListItem).Prenume;
            e.Value = Nume + " " + Prenume;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new LogAuten();
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

    }
}
