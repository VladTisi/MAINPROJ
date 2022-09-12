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
using MAINPROJ;
using Newtonsoft.Json;
using RandomProj;
using static System.Net.WebRequestMethods;

namespace MAINPROJ
{
    public partial class ConcediiRefuzate : Form
    {
        bool sidebarExpand;
        private int angajatId;
        bool admin;
        bool manager;
        string server = "http://localhost:5031/api/";
        int start = 0;
        int startacc = 0;
        int startref = 0;
        int selectedtable = 1;
        public ConcediiRefuzate(int angajatId,bool admin,bool manager)
        {
            InitializeComponent();
            this.angajatId=angajatId;
            this.admin = admin;
            this.manager = manager;
        }

        private void btnCerereNoua_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new CerereConcediu(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();

        }
        private async void showTable()
        {
            DataTable dt = new DataTable();
            DataColumn c = new DataColumn();

            c = new DataColumn("DataInceput");
            dt.Columns.Add(c);
            c = new DataColumn("DataSfarsit");
            dt.Columns.Add(c);

            //Popularea tabelului de concedii
            List<Dto> listaConcedii = new List<Dto>();
            listaConcedii = await GetConcediiAcceptate();
            foreach (Dto myObject in listaConcedii)
            {
                DataRow r = dt.NewRow();
                r["DataInceput"] = myObject.DataInceput.ToString("dd/MM/yy");
                r["DataSfarsit"] = myObject.DataSfarsit.ToString("dd/MM/yy");
                dt.Rows.Add(r);
            }
            tablelConcedii.DataSource = dt;
            dt = null;
            listaConcedii = null;
            tablelConcedii.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UpdateFont(tablelConcedii);
        }
        private async void showTableREF()
        {
            DataTable dt = new DataTable();
            DataColumn c = new DataColumn();

            c = new DataColumn("DataInceput");
            dt.Columns.Add(c);
            c = new DataColumn("DataSfarsit");
            dt.Columns.Add(c);

            //Popularea tabelului de concedii
            List<Dto> listaConcedii = new List<Dto>();
            listaConcedii = await GetConcediiRefuzate();
            foreach (Dto myObject in listaConcedii)
            {
                DataRow r = dt.NewRow();
                r["DataInceput"] = myObject.DataInceput.ToString("dd/MM/yy");
                r["DataSfarsit"] = myObject.DataSfarsit.ToString("dd/MM/yy");
                dt.Rows.Add(r);
            }
            dataGridView1.DataSource = dt;
            dt = null;
            listaConcedii = null;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            UpdateFont(dataGridView1);
        }

        private async void showTablePEND()
        {         
            DataTable dt = new DataTable();
            DataColumn c = new DataColumn();        
            
            c = new DataColumn("DataInceput");
            dt.Columns.Add(c);
            c = new DataColumn("DataSfarsit");
            dt.Columns.Add(c);

            //Popularea tabelului de concedii
            List<Dto> listaConcedii = new List<Dto>();
            listaConcedii = await GetConcediiAsteptare();
            foreach (Dto myObject in listaConcedii)
            {
                DataRow r = dt.NewRow();
                r["DataInceput"] = myObject.DataInceput.ToString("dd/MM/yy");
                r["DataSfarsit"] = myObject.DataSfarsit.ToString("dd/MM/yy");
                dt.Rows.Add(r);
            }
            dataGridView1.DataSource = dt;
            dt = null;
            listaConcedii = null;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UpdateFont(dataGridView1);
        }
        ///Meniu Navigare
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

        private void btnExit_Click(object sender, EventArgs e)
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
        private async ValueTask<List<Dto>> GetConcediiAsteptare()
        {
            HttpResponseMessage response = await Common.client.GetAsync(server + $"ConcediiPersonale/PendingHolidays?Id={angajatId}");
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
        private async ValueTask<List<Dto>> GetConcediiRefuzate()
        {
            HttpResponseMessage response = await Common.client.GetAsync(server + $"ConcediiPersonale/DisapprovedHolidays?Id={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Dto> listaParole = JsonConvert.DeserializeObject<List<Dto>>(responseBody);
            List<Dto> listaSecundara = new List<Dto>();
            if (startref + 5 > listaParole.Count)
            {
                button2.Visible = false;
            }
            else
            {
                button2.Visible = true;
            }
            if (listaParole.Count > startref + 5)
            {
                for (int i = startref; i < startref + 5; i++)
                {
                    listaSecundara.Add(listaParole[i]);
                }

            }
            else
            {
                for (int i = startref; i < listaParole.Count; i++)
                {
                    listaSecundara.Add(listaParole[i]);
                }
            }

            return listaSecundara;
        }
        private async ValueTask<List<Dto>> GetConcediiAcceptate()
        {
            HttpResponseMessage response = await Common.client.GetAsync(server + $"ConcediiPersonale/ApprovedHolidays?Id={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Dto> listaParole = JsonConvert.DeserializeObject<List<Dto>>(responseBody);
            List<Dto> listaSecundara = new List<Dto>();
            if (start + 5 > listaParole.Count)
            {
                btnForward.Visible = false;
            }
            else
            {
                btnForward.Visible = true;
            }
            if (listaParole.Count > start + 5)
            {
                for (int i = start; i < start + 5; i++)
                {
                    listaSecundara.Add(listaParole[i]);
                }

            }
            else
            {
                for (int i = start; i < listaParole.Count; i++)
                {
                    listaSecundara.Add(listaParole[i]);
                }
            }

            return listaSecundara;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void ConcediiPersonale_Load(object sender, EventArgs e)
        {
           

            showTable();
            showTableREF();


            if (!admin && !manager )
                {
                    btnGestionareConcedii.Visible = false;
                }


        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAsteptare_Click(object sender, EventArgs e)
        {
            selectedtable = 2;
            if (startacc >= 5)
                button2.Visible = true;
            else button2.Visible = false;
            showTablePEND();
        }

        private void btnRefuzate_Click(object sender, EventArgs e)
        {
            selectedtable = 1;
            if (startref >= 5)
                button2.Visible = true;
            else button2.Visible = false;
            showTableREF();
        }

        private void btnGestionareConcedii_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new GestionareConcedii(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void UpdateFont(DataGridView date)
        {
            //Change cell font
            foreach (DataGridViewColumn c in date.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Stencil", 16F, GraphicsUnit.Pixel);
            }
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
            showTable();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            start += 5;
            if (start >= 5)
                btnBackward.Visible = true;
            showTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedtable == 1)
            {
                showTableREF();
                startref -= 5;
                if (startref < 5)
                    button1.Visible = false;

            }
            if (selectedtable == 2)
            {
                showTablePEND();
                startacc -= 5;
                if (startacc < 5)
                    button1.Visible = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedtable == 1)
            {
                showTableREF();
                startref += 5;
                if (startref >= 5)
                    button1.Visible = true;
            }

            if (selectedtable == 2)
            {
                showTablePEND();
                startacc += 5;
                if (startacc >= 5)
                    button1.Visible = true;
            }
        }
    }
}
