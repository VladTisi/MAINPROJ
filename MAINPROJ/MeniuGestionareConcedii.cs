using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAINPROJ
{
    public partial class MeniuGestionareConcedii : Form
    {
        public MeniuGestionareConcedii()
        {
            InitializeComponent();
            showTable();
        }

            private void showTable()
            {
                string constring = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=PrisonBreak;Persist Security Info=True;User ID=internship2022;Password=int";
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT a.Nume, a.Prenume, f.Nume AS Functie, c.Data_inceput, c.Data_sfarsit, DATEDIFF(weekday,c.Data_inceput, c.Data_sfarsit) AS Perioada, tc.Nume AS TipConcediu\r\nFROM Angajat a\r\nJOIN Concediu c on a.Id=c.angajatId\r\nJOIN TipConcediu tc on c.TipConcediuId = tc.Id\r\nJOIN Functie f on f.Id = a.IdFunctie", con))
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
       
       



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
