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
using static System.Net.WebRequestMethods;


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

                r["DataInceput"] = myObject.DataInceput.ToString("dd/MM/yyyy");
                r["DataSfarsit"] = myObject.DataSfarsit.ToString("dd/MM/yyyy");
                dt.Rows.Add(r);
            }
            tabelConcediu.DataSource = dt;
            tabelConcediu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                r["DataAngajarii"] = myObject.DataAngajarii.ToString("dd/MM/yyyy");
                dt.Rows.Add(r);
            }
            tabelEchipa.DataSource = dt;
            tabelEchipa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UpdateFont(tabelEchipa);
        }
        bool sidebarExpand;
        private int angajatId;
        bool admin;
        bool manager;
        int start = 0;
        int startacc = 0;
        string url ="http://localhost:5031/api/";
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

        private void Echipa_Load(object sender, EventArgs e)
        {
                if (admin != true && manager != true)
                {
                    btnGestionareConcedii.Visible = false;
                }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnCerereNoua_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new CerereConcediu(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void btnGestionareConcedii_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new GestionareConcedii(angajatId,admin,manager);
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
            HttpResponseMessage response = await Common.client.GetAsync(url+$"Echipa/GetEchipa?angajatId={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Member> listaAngajati = JsonConvert.DeserializeObject<List<Member>>(responseBody);
            List<Member> listaSecundara = new List<Member>();
            if (start + 5 > listaAngajati.Count)
            {
                btnForward.Visible = false;
            }
            else
            {
                btnForward.Visible = true;
            }
            if (listaAngajati.Count > start + 5)
            {
                for (int i = start; i < start + 5; i++)
                {
                    listaSecundara.Add(listaAngajati[i]);
                }

            }
            else
            {
                for (int i = start; i < listaAngajati.Count; i++)
                {
                    listaSecundara.Add(listaAngajati[i]);
                }
            }

            return listaSecundara;
        }
        private async ValueTask<List<Dto>> GetConcedii()
        {
            HttpResponseMessage response = await Common.client.GetAsync(url+$"Echipa/GetConcediiEchipa?angajatId={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Dto> listaParole = JsonConvert.DeserializeObject<List<Dto>>(responseBody);
            List<Dto> listaSecundara = new List<Dto>();
            if (startacc + 5 > listaParole.Count)
            {
                button2.Visible = false;
            }
            else
            {
                button2.Visible = true;
            }
            if (listaParole.Count > startacc + 5)
            {
                for (int i = startacc; i < startacc + 5; i++)
                {
                    listaSecundara.Add(listaParole[i]);
                }

            }
            else
            {
                for (int i = startacc; i < listaParole.Count; i++)
                {
                    listaSecundara.Add(listaParole[i]);
                }
            }

            return listaSecundara;
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new LogAuten();
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            start -= 5;
            if (start < 5)
                btnBackward.Visible = false;
            showEchipa();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            start += 5;
            if (start >= 5)
                btnBackward.Visible = true;
            showEchipa();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startacc -= 5;
            if (startacc < 5)
                button1.Visible = false;
            showTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            startacc += 5;
            if (startacc >= 5)
                button1.Visible = true;
            showTable();
        }
    }

}
