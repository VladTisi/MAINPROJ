using PrisonBreakProj;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAINPROJ
{
    public partial class CerereConcediu : Form
    {
        int angajatIdTemp = 5;
        OleDbCommand cmd = new OleDbCommand();
        bool sidebarExpand;
        public CerereConcediu()
        {
            InitializeComponent();
        }

        private void CerereConcediu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.TipConcediu' table. You can move, or remove it, as needed.
            this.tipConcediuTableAdapter.Fill(this.dataSet1.TipConcediu);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(cmbTipConcediu.SelectedValue);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDataIncepere.Value<DateTime.Now)
            {
                MessageBox.Show("Data inceperii nu poate fi in trecut!");
                dtpDataIncepere.Value=DateTime.Now;
            }
        }

        private void dtpDataSfarsit_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDataSfarsit.Value<DateTime.Now)
            {
                MessageBox.Show("Data sfarsitului nu poate fi in trecut");
                dtpDataSfarsit.Value=dtpDataIncepere.Value.AddDays(1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            OleDbConnection con = Common.GetConnection();
            con.Open();
            //string sss = $"asdasd{dtpDataIncepere.Value},{dtpDataIncepere.Value}";
            //Console.WriteLine(sss);
            string register = $"INSERT INTO Concediu(TipConcediuId,Data_inceput,Data_sfarsit,stareConcediuId,angajatId) VALUES ({cmbTipConcediu.SelectedValue},'{dtpDataIncepere.Value}','{dtpDataSfarsit.Value}',{1},{angajatIdTemp})";
            //cmd.Parameters.AddWithValue("@TipConcediuId", cmbTipConcediu.SelectedValue);
            //cmd.Parameters.AddWithValue("@Data_inceput", dtpDataIncepere.Value);
            //cmd.Parameters.AddWithValue("@Data_sfarsit", dtpDataSfarsit.Value);
            //cmd.Parameters.AddWithValue("@stareConcediuId",1);
            //cmd.Parameters.AddWithValue("@angajatId", angajatIdTemp);

            cmd = new OleDbCommand(register, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Cerere de concediu adaugata!");
            dtpDataIncepere.Value=DateTime.Now;
            dtpDataSfarsit.Value=dtpDataIncepere.Value.AddDays(1);
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new HomePage();
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new HomePage();
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new HomePage();
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuNavigare();
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
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
    }
}
