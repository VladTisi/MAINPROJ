using Newtonsoft.Json;
using RandomProj;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MAINPROJ
{
    public partial class Echipa : Form
    {
        private async void showTable()
        {
            DataTable dt = new DataTable();

            DataColumn c = new DataColumn("Nume");
            dt.Columns.Add(c);
            c = new DataColumn("Prenume");
            dt.Columns.Add(c);
            c = new DataColumn("Functia");
            dt.Columns.Add(c);
            c = new DataColumn("Status");
            dt.Columns.Add(c);
            c = new DataColumn("DataInceput");
            dt.Columns.Add(c);
            c = new DataColumn("DataSfarsit");
            dt.Columns.Add(c);


            //Popularea tabelului de angajati
            List<Dto> listaConcedii = new List<Dto>();
            listaConcedii = await GetConcedii();
            foreach (Dto myObject in listaConcedii)
            {
                DataRow r = dt.NewRow();
                r["Nume"] = myObject.Nume;
                r["Prenume"] = myObject.Prenume;
                r["Functia"] = myObject.Functie;
                r["Status"] = myObject.Status;
                r["DataInceput"] = myObject.DataInceput.ToString("dd/MM/yy");
                r["DataSfarsit"] = myObject.DataSfarsit.ToString("dd/MM/yy");
                dt.Rows.Add(r);
            }
            tabelConcediu.DataSource = dt;
            UpdateFont(tabelConcediu);
        }
        private async void showEchipa()
        {
            DataTable dt = new DataTable();

            DataColumn c = new DataColumn("Nume");
            dt.Columns.Add(c);
            c = new DataColumn("Prenume");
            dt.Columns.Add(c);
            c = new DataColumn("Functia");
            dt.Columns.Add(c);
            c = new DataColumn("DataAngajarii");
            dt.Columns.Add(c);

            //Popularea tabelului de angajati
            List<Member> listaConcedii = new List<Member>();
            listaConcedii = await GetAngajati();
            foreach (Member myObject in listaConcedii)
            {
                DataRow r = dt.NewRow();
                r["Nume"] = myObject.Nume;
                r["Prenume"] = myObject.Prenume;
                r["Functia"] = myObject.Functia;
                r["DataAngajarii"] = myObject.DataAngajarii.ToString("dd/MM/yy");
                dt.Rows.Add(r);
            }
            tabelEchipa.DataSource = dt;
            UpdateFont(tabelEchipa);
        }
        bool sidebarExpand;
        private int angajatId;
        bool admin;
        bool manager;
        public Echipa(int angajatId, bool admin, bool manager)
        {
            InitializeComponent();
            this.angajatId=angajatId;
            this.admin = admin;
            this.manager = manager;
            showTable();
            showEchipa();

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

        private void Echipa_Load(object sender, EventArgs e)
        {
                if (admin != true && manager != true)
                {
                    button7.Visible = false;
                    button8.Visible = false;
                }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new CerereConcediu(angajatId,admin,manager);
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

        private void tabelEchipa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private async ValueTask<List<Member>> GetAngajati()
        {
            HttpResponseMessage response = await Common.client.GetAsync($"http://localhost:5031/api/Echipa/GetEchipa?angajatId={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Member> listaAngajati = JsonConvert.DeserializeObject<List<Member>>(responseBody);
            return listaAngajati;
        }
        private async ValueTask<List<Dto>> GetConcedii()
        {
            HttpResponseMessage response = await Common.client.GetAsync($"http://localhost:5031/api/Echipa/GetConcediiEchipa?angajatId={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Dto> listaParole = JsonConvert.DeserializeObject<List<Dto>>(responseBody);
            return listaParole;
        }
        private void UpdateFont(DataGridView a)
        {
            //Change cell font
            foreach (DataGridViewColumn c in a.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Stencil", 12F, GraphicsUnit.Pixel);
            }
        }

        private void tabelEchipa_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
