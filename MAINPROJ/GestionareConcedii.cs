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

namespace MAINPROJ
{
    public partial class GestionareConcedii : Form
    {
        bool sidebarExpand;
        private int angajatId;

        public GestionareConcedii(int angajatId)
        {
            InitializeComponent();
            this.angajatId = angajatId;
        }

        private void GestionareConcedii_Load(object sender, EventArgs e)
        {
            string comanda="";
            OleDbConnection con3 = Common.GetConnection();
            con3.Open();
            OleDbCommand cmd = new OleDbCommand();

            string dateAngajat = $"SELECT  esteAdmin, IdFunctie FROM Angajat WHERE Id={angajatId}";
            cmd = new OleDbCommand(dateAngajat, con3);
            var rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                bool admin = rdr.GetBoolean(0);
                int manager = rdr.GetInt32(1);
                if (admin)
                    comanda = "SELECT Angajat.Id as [Id Angajat],Angajat.Nume, Functie.Nume,Concediu.Id as[Id Concediu], Concediu.Data_inceput,Concediu.Data_sfarsit,TipConcediu.Nume as[Tip Concediu] FROM Angajat JOIN Functie on Angajat.IdFunctie=Functie.Id join Concediu on Concediu.angajatId=Angajat.Id join TipConcediu on TipConcediu.Id=Concediu.TipConcediuId WHERE Concediu.stareConcediuId=1";
                else if (manager == 3)
                    comanda = $"SELECT Angajat.Id as [Id Angajat],Angajat.Nume, Functie.Nume,Concediu.Id as[Id Concediu], Concediu.Data_inceput,Concediu.Data_sfarsit,TipConcediu.Nume as[Tip Concediu] FROM Angajat JOIN Functie on Angajat.IdFunctie=Functie.Id join Concediu on Concediu.angajatId=Angajat.Id join TipConcediu on TipConcediu.Id=Concediu.TipConcediuId WHERE Concediu.stareConcediuId=1 and Functie.Id !=3 and Angajat.ManagerId={angajatId}";
            }

            con3.Close();
            showTable(comanda);
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

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void showTable(string comanda)
        {
            string constring = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=PrisonBreak;Persist Security Info=True;User ID=internship2022;Password=int";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand(comanda, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            tabelConcedii.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void Aproba_Click(object sender, EventArgs e)
        {

        }

        private void Refuza_Click(object sender, EventArgs e)
        {

        }
    }
}
