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
    public partial class Echipa : Form
    {
        private void showTable()
        {
            SqlConnection con = new SqlConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=PrisonBreak;Persist Security Info=True;User ID=internship2022;Password=int");
            con.Open();
            string comanda = $"SELECT Angajat.Prenume,Angajat.Nume,Functie.Nume as [Functia], Concediu.Data_inceput, Concediu.Data_sfarsit FROM Angajat join Functie on Angajat.IdFunctie=Functie.Id join Concediu on Concediu.angajatId = Angajat.Id join StareConcediu on StareConcediu.Id = Concediu.stareConcediuId  WHERE Angajat.IdEchipa=(SELECT IdEchipa FROM Angajat where Angajat.Id={angajatId} and StareConcediu.Id = 2 and Concediu.Data_inceput >GETDATE())";
            using (SqlCommand cmd = new SqlCommand(comanda, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            tabelConcediu.DataSource = dt;
                        }
                    }
                }
            con.Close();
        }
        private void showEchipa()
        {
            SqlConnection con = new SqlConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=PrisonBreak;Persist Security Info=True;User ID=internship2022;Password=int");
            con.Open();
            string comanda = $"SELECT Angajat.Prenume,Angajat.Nume,Functie.Nume as [Functia] FROM Angajat join Functie on Angajat.IdFunctie=Functie.Id WHERE Angajat.IdEchipa=(SELECT IdEchipa FROM Angajat where Angajat.Id={angajatId})";
            using (SqlCommand cmd = new SqlCommand(comanda, con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        tabelEchipa.DataSource = dt;
                    }
                }
            }
            con.Close();
        }
        bool sidebarExpand;
        private int angajatId;
        public Echipa(int angajatId)
        {
            InitializeComponent();
            this.angajatId=angajatId;
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

        private void Echipa_Load(object sender, EventArgs e)
        {
           
                // Toggle between True and False.  
                //monthCalendar1.ShowToday = !monthCalendar1.ShowToday;
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
                if (admin != true && manager != 3)
                {
                    button7.Visible = false;
                    button8.Visible = false;
                }
            }

            con3.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new CerereConcediu(angajatId);
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

        private void tabelEchipa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
