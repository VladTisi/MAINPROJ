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

namespace MAINPROJ
{
    public partial class ConcediiRefuzate : Form
    {
        bool sidebarExpand;
        private int angajatId;
        public ConcediiRefuzate(int angajatId)
        {
            InitializeComponent();
            this.angajatId=angajatId;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new CerereConcediu(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();

        }
        private void showTable()
        {
            string constring = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=PrisonBreak;Persist Security Info=True;User ID=internship2022;Password=int";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT Concediu.Data_inceput as [Data de inceput],Concediu.Data_sfarsit as [Data de finalizare] FROM Concediu join Angajat on Concediu.angajatId={angajatId} and Angajat.Id={angajatId} WHERE Concediu.stareConcediuId = {2}", con))
                {
                    
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            tablelConcedii.DataSource = dt;
                        }
                    }
                }
            }
        }
        private void showTableREF()
        {
            string constring = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=PrisonBreak;Persist Security Info=True;User ID=internship2022;Password=int";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT Concediu.Data_inceput as [Data de inceput],Concediu.Data_sfarsit as [Data de finalizare] FROM Concediu join Angajat on Concediu.angajatId={angajatId} and Angajat.Id={angajatId} WHERE Concediu.stareConcediuId = {3}", con))
                {

                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private async void showTablePEND()
        {
            //string constring = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=PrisonBreak;Persist Security Info=True;User ID=internship2022;Password=int";
            //using (SqlConnection con = new SqlConnection(constring))
            //{
            //    using (SqlCommand cmd = new SqlCommand($"SELECT Concediu.Data_inceput as [Data de inceput],Concediu.Data_sfarsit as [Data de finalizare] FROM Concediu join Angajat on Concediu.angajatId={angajatId} and Angajat.Id={angajatId} WHERE Concediu.stareConcediuId = {1}", con))
            //    {

            //        cmd.CommandType = CommandType.Text;
            //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            //        {
            //            using (DataTable dt = new DataTable())
            //            {
            //                sda.Fill(dt);
            //                dataGridView1.DataSource = dt;
            //            }
            //        }
            //    }
            //}
            //Crearea tabelului de concedii
            DataTable dt = new DataTable();
            DataColumn c = new DataColumn();
            
            c = new DataColumn("DataInceput");
            dt.Columns.Add(c);
            c = new DataColumn("DataSfarsit");
            dt.Columns.Add(c);

            //Popularea tabelului de concedii
            List<AngajatConcediu> listaConcedii = new List<AngajatConcediu>();
            listaConcedii = await GetConcedii();
            foreach (AngajatConcediu myObject in listaConcedii)
            {
                DataRow r = dt.NewRow();
                r["DataInceput"] = myObject.DataInceput;
                r["DataSfarsit"] = myObject.DataSfarsit;
                dt.Rows.Add(r);
            }
            tablelConcedii.DataSource = dt;
            dt = null;
            listaConcedii = null;
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
            var otherform = new ConcediiRefuzate(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new Echipa(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuNavigare(angajatId);
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
        private async ValueTask<List<AngajatConcediu>> GetConcedii()
        {
            HttpResponseMessage response = await Common.client.GetAsync($"http://localhost:5031/api/ConcediiPersonale/ApprovedHolidays?Id={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<AngajatConcediu> listaParole = JsonConvert.DeserializeObject<List<AngajatConcediu>>(responseBody);
            return listaParole;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ConcediiPersonale_Load(object sender, EventArgs e)
        {
            showTable();
            showTableREF();
            OleDbConnection con3 = Common.GetConnection();
            con3.Open();
            string dateAngajat = $"SELECT  esteAdmin, IdFunctie FROM Angajat WHERE Id={angajatId}";
            var cmd = new OleDbCommand(dateAngajat, con3);
            var rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                bool admin = rdr.GetBoolean(0);
                int manager = rdr.GetInt32(1);
                if (admin != true && manager != 3)
                {
                    button10.Visible = false;
                    button9.Visible = false;
                }
            }
            con3.Close();
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
            var otherform = new GestionareConcedii(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuModificareDateAngajat(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }
    }
}
