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
        public ConcediiRefuzate(int angajatId,bool admin,bool manager)
        {
            InitializeComponent();
            this.angajatId=angajatId;
            this.admin = admin;
            this.manager = manager;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
            UpdateFont(dataGridView1);
        }
        ///Meniu Navigare
        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new HomePage(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new ConcediiRefuzate(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new Echipa(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuNavigare(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button6_Click(object sender, EventArgs e)
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
            return listaParole;
        }
        private async ValueTask<List<Dto>> GetConcediiRefuzate()
        {
            HttpResponseMessage response = await Common.client.GetAsync(server + $"ConcediiPersonale/DisapprovedHolidays?Id={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Dto> listaParole = JsonConvert.DeserializeObject<List<Dto>>(responseBody);
            return listaParole;
        }
        private async ValueTask<List<Dto>> GetConcediiAcceptate()
        {
            HttpResponseMessage response = await Common.client.GetAsync(server + $"ConcediiPersonale/ApprovedHolidays?Id={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Dto> listaParole = JsonConvert.DeserializeObject<List<Dto>>(responseBody);
            return listaParole;
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
                    button9.Visible = false;
                }


        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            showTablePEND();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            showTableREF();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new GestionareConcedii(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuModificareDateAngajat(angajatId, admin, manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }
        private void UpdateFont(DataGridView date)
        {
            //Change cell font
            foreach (DataGridViewColumn c in date.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Stencil", 12F, GraphicsUnit.Pixel);
            }
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
