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
                monthCalendar1.ShowToday = !monthCalendar1.ShowToday;
     
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

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

        }
    }

}
