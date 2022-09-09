using Newtonsoft.Json;
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
using RandomProj.Models;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using RandomProj;
using System.Web.UI.WebControls;

namespace MAINPROJ
{
    public partial class GestionareConcedii : Form
    {
        bool sidebarExpand;
        private int angajatId;
        string ValCelula;
        bool admin;
        bool manager;
        String local = "http://localhost:5031/api/";
        DataTable dt = new DataTable();
        public GestionareConcedii(int angajatId, bool admin, bool manager)
        {
            InitializeComponent();
            this.angajatId = angajatId;
            this.admin = admin;
            this.manager = manager;
            this.admin = admin;
            this.manager = manager;
        }
        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in tabelConcedii.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Stencil", 12F, GraphicsUnit.Pixel);
            }
        }
        private async void GestionareConcedii_Load(object sender, EventArgs e)
        {
            //Crearea tabelului de concedii
            
            DataColumn c = new DataColumn("Id");
            dt.Columns.Add(c);
            c = new DataColumn("Nume");
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
            //c = new DataColumn("Inlocuitor");
            //dt.Columns.Add(c);



            //Popularea tabelului de concedii
            List<Dto> listaConcedii = new List<Dto>();
            listaConcedii = await GetConcedii();
            foreach (Dto myObject in listaConcedii)
            {
                DataRow r = dt.NewRow();
                r["Id"] = myObject.Id;
                r["Nume"] = myObject.Nume;
                r["Prenume"] = myObject.Prenume;
                r["Functia"] = myObject.Functie;
                r["Status"] = myObject.Status;
                r["DataInceput"] = myObject.DataInceput.ToString("dd/MM/yy");
                r["DataSfarsit"] = myObject.DataSfarsit.ToString("dd/MM/yy");
                dt.Rows.Add(r);
            }
            tabelConcedii.DataSource = dt;
            UpdateFont();

            this.tabelConcedii.Columns["Id"].Visible = false;
            
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new GestionareConcedii(angajatId, admin, manager);
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

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private async ValueTask<List<Dto>> GetConcedii()
        {
            HttpResponseMessage response = await Common.client.GetAsync(local+$"GestionareConcedii/GetConcedii?angajatId={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Dto> listaParole = JsonConvert.DeserializeObject<List<Dto>>(responseBody);
            return listaParole;
        }

        private async void Aproba_Click(object sender, EventArgs e)
        {
            var response = await Common.client.PutAsync(local+$"GestionareConcedii/AprobaConcediu?concediuId={ValCelula}",null);
            response.EnsureSuccessStatusCode();
            this.Hide();
            var otherform = new GestionareConcedii(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private async void Refuza_Click(object sender, EventArgs e)
        {
            var response = await Common.client.PutAsync(local+$"GestionareConcedii/RefuzaConcediu?concediuId={ValCelula}", null);
            response.EnsureSuccessStatusCode();
            this.Hide();
            var otherform = new GestionareConcedii(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Nume LIKE '" + SearchBox.Text + "%'";
            tabelConcedii.DataSource = dv;
        }



    }
}
