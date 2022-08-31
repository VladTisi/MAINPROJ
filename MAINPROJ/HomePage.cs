using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAINPROJ;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MAINPROJ
{
    public partial class HomePage : Form
    {
        bool sidebarExpand;
        public HomePage()
        {
            InitializeComponent();

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            //OleDbConnection con = Common.GetConnection();
            //con.Open();
            //String Nume=$"SELECT Nume from Angajat Where ";
            //String Prenume= $"SELECT Prenume from Angajat Where "; 
            //String Functie= $"SELECT Functie from Angajat Where ";
            //String Echipa = $"SELECT Echipa from Angajat Where ";
            //String Email = $"SELECT Email from Login Where Login.Id ";
            //int Id;
            //String Sex = $"SELECT Sex from Angajat Where ";
            //String nrTel = $"SELECT Numar_Telefon from Angajat Where ";
            //int Overtime;
            //int Salariu;
            //String DataA;
          







            //con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            btnUpdatePoza.Visible = false;

            btnSalvare.Visible = false;

            txtEmail.Enabled = false;

            txtTelefon.Enabled = false;
        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            txtEmail.Enabled = true;

            txtTelefon.Enabled = true;

            btnSalvare.Visible = true;

            btnUpdatePoza.Visible = true;
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void button5_Click(object sender, EventArgs e)
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


        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuNavigare();
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new ConcediiPersonale();
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new Echipa();
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new HomePage();
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }
    }
}
