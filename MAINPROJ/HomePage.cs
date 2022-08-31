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

namespace MAINPROJ
{
    public partial class HomePage : Form
    {
        bool sidebarExpand;
        public HomePage()
        {
            InitializeComponent();
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

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
