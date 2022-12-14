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
using static System.Net.WebRequestMethods;

namespace MAINPROJ
{
    
    public partial class MeniuNavigare : Form
    {
        private int angajatId;
        bool sidebarExpand;
        bool admin;
        bool manager;
        string server = "http://localhost:5031/api/";
        int start = 0;
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
                sidebar.Width -= 18;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 18;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void MeniuNavigare_Load(object sender, EventArgs e)
        {
            
                if (admin == false && manager == false)
                {
                    btnRecrutare.Visible = false;
                    btnGestionareConcedii.Visible = false;
                }
            
         
        }

        private void btnExit_Click(object sender, EventArgs e)
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
            tabelAngajati.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  
            UpdateFont();


            //this.tabelAngajati.Columns["Id"].Visible = false;
            dt = null;
            listaConcedii = null;
        }
        private async ValueTask<List<Member>> GetAngajati()
        {
            HttpResponseMessage response = await Common.client.GetAsync(server + $"MeniuNavigare/GetNumePrenumeFunctiaDataAngajarii");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Member> listaAngajati = JsonConvert.DeserializeObject<List<Member>>(responseBody);
            List<Member> listaSecundara = new List<Member>();
            if (start + 18 > listaAngajati.Count)
            {
                btnForward.Visible = false;
            }
            else
            {
                btnForward.Visible = true;
            }
            if (listaAngajati.Count > start + 18)
            {
                for (int i = start; i < start + 18; i++)
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
        /////////////////Butoane meniu navigare///////////////////
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

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGestionareConcedii_Click(object sender, EventArgs e)
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
                c.DefaultCellStyle.Font = new Font("Stencil", 16F, GraphicsUnit.Pixel);
            }
        }

        private void btnRecrutare_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new RegisterPage(0,"","",admin,manager,angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new LogAuten();
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void tabelAngajati_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            start -= 18;
            if (start < 18)
                btnBackward.Visible = false;
            showTable();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            start += 18;
            if (start >= 18)
                btnBackward.Visible = true;
            showTable();
        }
    }
}
