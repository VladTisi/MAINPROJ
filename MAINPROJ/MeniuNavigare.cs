using Microsoft.Win32;
using PrisonBreakProj;
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
    public partial class MeniuNavigare : Form
    {
        bool sidebarExpand;
        public MeniuNavigare()
        {
            InitializeComponent();
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
                Logo.Location = new Point(330, 37);
                tabelAngajati.Location = new Point(175, 115);
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                Logo.Location = new Point(360, 37);
                tabelAngajati.Location = new Point(205, 115);
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

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showTable()
        {
            string constring = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=PrisonBreak;Persist Security Info=True;User ID=internship2022;Password=int";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Angajat.Poza, Angajat.Prenume,Angajat.Nume,Functie.Nume as [Functia],Angajat.Data_Angajarii as [Data angajarii] FROM Angajat join Functie on Angajat.IdFunctie=Functie.Id", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            tabelAngajati.DataSource = dt;
                        }
                    }
                }
            }
        }


    }
}
