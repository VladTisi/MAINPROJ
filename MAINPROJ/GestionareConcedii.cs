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

namespace MAINPROJ
{
    public partial class GestionareConcedii : Form
    {
        bool sidebarExpand;
        private int angajatId;
        string ValCelula;
        public GestionareConcedii(int angajatId)
        {
            InitializeComponent();
            this.angajatId = angajatId;

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
            DataTable dt = new DataTable();
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
            dt = null;
            listaConcedii = null;
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
            var otherform = new ConcediiRefuzate(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new Echipa(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuNavigare(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new GestionareConcedii(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuModificareDateAngajat(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private async ValueTask<List<Dto>> GetConcedii()
        {
            HttpResponseMessage response = await Common.client.GetAsync($"http://localhost:5031/api/GestionareConcedii/GetConcedii?angajatId={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Dto> listaParole = JsonConvert.DeserializeObject<List<Dto>>(responseBody);
            return listaParole;
        }

        private async void Aproba_Click(object sender, EventArgs e)
        {
            OleDbConnection con3 = Common.GetConnection();
            con3.Open();
            OleDbCommand cmd = new OleDbCommand();
            string dateAngajat = $"UPDATE Concediu SET stareConcediuId=2 WHERE Id={Convert.ToInt32(ValCelula)} ";
            cmd = new OleDbCommand(dateAngajat, con3);
            cmd.ExecuteNonQuery();
            con3.Close();
            this.Hide();
            var otherform = new GestionareConcedii(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void Refuza_Click(object sender, EventArgs e)
        {
            if (this.tabelConcedii.SelectedRows.Count > 0)
            {
                tabelConcedii.Rows.RemoveAt(this.tabelConcedii.SelectedRows[0].Index);
            }
            OleDbConnection con3 = Common.GetConnection();
            con3.Open();
            OleDbCommand cmd = new OleDbCommand();
            string dateAngajat = $"UPDATE Concediu SET stareConcediuId=3 WHERE Id={Convert.ToInt32(ValCelula)}";
            cmd = new OleDbCommand(dateAngajat, con3);
            cmd.ExecuteNonQuery();
            con3.Close();
            this.Hide();
            var otherform = new GestionareConcedii(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void tabelConcedii_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = tabelConcedii.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = tabelConcedii.Rows[selectedrowindex];
            ValCelula = Convert.ToString(selectedRow.Cells["Id"].Value);
            Console.WriteLine(ValCelula);
        }
    }
}
