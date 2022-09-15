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
        int start = 0;
        int startacc = 0;
        int startref = 0;
        int selectedtable = 1;
        int counter = 0;
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
                c.DefaultCellStyle.Font = new Font("Stencil", 16F, GraphicsUnit.Pixel);
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

            tabelConcedii.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UpdateFont();

            this.tabelConcedii.Columns["Id"].Visible = false;
            
        }

        private async void showTablePEND()
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
            tabelConcedii.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UpdateFont();

            this.tabelConcedii.Columns["Id"].Visible = false;

        }
        private async void showTableREF()
        {
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
            listaConcedii = await GetConcediiRefuzate();
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
            tabelConcedii.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UpdateFont();

            this.tabelConcedii.Columns["Id"].Visible = false;
        }

        private async void showTableACC()
        {
            DataTable dt = new DataTable();
            DataColumn c = new DataColumn();
            c = new DataColumn("Id");
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
            listaConcedii = await GetConcediiAcceptate();
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
            dt = null;
            listaConcedii = null;
            tabelConcedii.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.Fill;
            this.tabelConcedii.Columns["Id"].Visible = false;
            UpdateFont();

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

        private void btnGestionareConcedii_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new GestionareConcedii(angajatId, admin, manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

       

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private async ValueTask<List<Dto>> GetConcedii()
        {
            HttpResponseMessage response = await Common.client.GetAsync(local+$"GestionareConcedii/GetConcedii?angajatId={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Dto> listaParole = JsonConvert.DeserializeObject<List<Dto>>(responseBody);
            List<Dto> listaSecundara = new List<Dto>();
            if (start+17>listaParole.Count)
            {
                btnForward.Visible=false;
            }
            else
            {
                btnForward.Visible=true;
            }
            if(listaParole.Count > start+17)
            {
                for (int i = start; i<start+17; i++)
                {
                    listaSecundara.Add(listaParole[i]);
                }

            }
            else
            {
                for(int i = start; i<listaParole.Count; i++)
                {
                    listaSecundara.Add(listaParole[i]);
                }
            }
            
            return listaSecundara;
        }

        private async void Aproba_Click(object sender, EventArgs e)
        {
            if (ValCelula != null)
            {
                var response = await Common.client.PutAsync(local + $"GestionareConcedii/AprobaConcediu?concediuId={ValCelula}", null);
                response.EnsureSuccessStatusCode();
                this.Hide();
                var otherform = new GestionareConcedii(angajatId, admin, manager);
                otherform.Closed += (s, args) => this.Close();
                otherform.Show();

            }
            else
            {
                MessageBox.Show("Niciun concediu selectat!");
            }
        }
        private async ValueTask<List<Dto>> GetConcediiRefuzate()
        {
            HttpResponseMessage response = await Common.client.GetAsync(local + $"GestionareConcedii/GetConcediuRefuzat?concediuId={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Dto> listaParole = JsonConvert.DeserializeObject<List<Dto>>(responseBody);
            List<Dto> listaSecundara = new List<Dto>();
            if (startref+17>listaParole.Count)
            {
                btnForward.Visible=false;
            }
            else
            {
                btnForward.Visible=true;
            }
            if (listaParole.Count > startref+17)
            {
                for (int i = startref; i<startref+17; i++)
                {
                    listaSecundara.Add(listaParole[i]);
                }

            }
            else
            {
                for (int i = startref; i<listaParole.Count; i++)
                {
                    listaSecundara.Add(listaParole[i]);
                }
            }

            return listaSecundara;
        }

        private async ValueTask<List<Dto>> GetConcediiAcceptate()
        {
            HttpResponseMessage response = await Common.client.GetAsync(local + $"GestionareConcedii/GetConcediuAcceptate?concediuId={angajatId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Dto> listaParole = JsonConvert.DeserializeObject<List<Dto>>(responseBody);
            List<Dto> listaSecundara = new List<Dto>();
            if (startacc+17>listaParole.Count)
            {
                btnForward.Visible=false;
            }
            else
            {
                btnForward.Visible=true;
            }
            if (listaParole.Count > startacc+17)
            {
                for (int i = startacc; i<startacc+17; i++)
                {
                    listaSecundara.Add(listaParole[i]);
                }

            }
            else
            {
                for (int i = startacc; i<listaParole.Count; i++)
                {
                    listaSecundara.Add(listaParole[i]);
                }
            }

            return listaSecundara;
        }
        private async void Refuza_Click(object sender, EventArgs e)
        {
            var response = await Common.client.PutAsync(local + $"GestionareConcedii/RefuzaConcediu?concediuId={ValCelula}", null);
            response.EnsureSuccessStatusCode();
            this.Hide();
            var otherform = new GestionareConcedii(angajatId, admin, manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            char[] s = SearchBox.Text.ToCharArray();
            for(int i=0;i<s.Length;i++)
            {
                if (Char.IsLetter(s[i]) == false)
                {
                    MessageBox.Show("Se pot introduce doar litere");
                    SearchBox.Text = "";
                    return;
                }
                    
            }
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Nume LIKE '" + SearchBox.Text + "%'";
            tabelConcedii.DataSource = dv;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (startref>=17) 
                btnBackward.Visible=true;
            else btnBackward.Visible=false;
            selectedtable=3;
            showTableREF();
            Refuza.Visible = false;
            Aproba.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (start>=17)
                btnBackward.Visible=true;
            else btnBackward.Visible=false;
            selectedtable=1;
            showTablePEND();
            Refuza.Visible = true;
            Aproba.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (startacc>=17)
                btnBackward.Visible=true;
            else btnBackward.Visible=false;
            selectedtable=2;
            showTableACC();
            Refuza.Visible = false;
            Aproba.Visible = false;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {

        }

        private async void tabelConcedii_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            int selectedrowindex = tabelConcedii.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = tabelConcedii.Rows[selectedrowindex];

            ValCelula = Convert.ToString(selectedRow.Cells["Id"].Value);

            Console.WriteLine(ValCelula);
            HttpResponseMessage response = await Common.client.GetAsync(local + $"GestionareConcedii/GetComentariu?concediuId={ValCelula}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            MessageBox.Show(responseBody);
        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new LogAuten();
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (selectedtable==1)
            {
                showTablePEND();
                start+=17;
                if (start>=17)
                    btnBackward.Visible=true;
            }

            if (selectedtable==2)
            {
                showTableACC();
                startacc+=17;
                if (startacc>=17)
                    btnBackward.Visible=true;
            }
            if (selectedtable==3)
            {
                showTableREF();
                startref+=17;
                if (startref>=17)
                    btnBackward.Visible=true;
            }
            
        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            
            if (selectedtable==1)
            {
                showTablePEND();
                start-=17;
                if (start<17)
                    btnBackward.Visible=false;

            }
            if (selectedtable==2)
            {
                showTableACC();
                startacc-=17;
                if (startacc<17)
                    btnBackward.Visible=false;

            }
            if (selectedtable==3)
            {
                showTableREF();
                startref-=17;
                if (startref<17)
                    btnBackward.Visible=false;

            }

        }
    }
}
