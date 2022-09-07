using Microsoft.Win32;
using MAINPROJ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RandomProj;
using System.Net.Http;

namespace MAINPROJ
{
    
    public partial class MeniuNavigare : Form
    {
        private int angajatId;
        bool sidebarExpand;
        bool admin;
        bool manager;
        public MeniuNavigare(int angajatId,bool admin,bool manager)
        {
            InitializeComponent();
            this.angajatId=angajatId;
            this.admin = admin;
            this.manager = manager;
            showTable();
        }

        private void menuButton_Click_1(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }
        private void sidebarTimer_Tick_1(object sender, EventArgs e)
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

        private void MeniuNavigare_Load(object sender, EventArgs e)
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
        
    private async void showTable()
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
            tabelAngajati.DataSource = dt;
            UpdateFont();

            //this.tabelAngajati.Columns["Id"].Visible = false;
            dt = null;
            listaConcedii = null;
        }
        private async ValueTask<List<Member>> GetAngajati()
        {
            HttpResponseMessage response = await Common.client.GetAsync($"http://localhost:5031/api/MeniuNavigare/GetNumePrenumeFunctiaDataAngajarii");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Member> listaAngajati = JsonConvert.DeserializeObject<List<Member>>(responseBody);
            return listaAngajati;
        }
        /////////////////Butoane meniu navigare///////////////////
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

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuModificareDateAngajat(angajatId,admin,manager);
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
        //////////////////////////////////////////////////////////
        ///
        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in tabelAngajati.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Stencil", 12F, GraphicsUnit.Pixel);
            }
        }
    }
}
