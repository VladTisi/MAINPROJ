using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAINPROJ
{
    public partial class ConcediiPersonale : Form
    {
        public ConcediiPersonale()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var CerereConcediu = new CerereConcediu();
            CerereConcediu.Closed += (s, args) => this.Close();
            CerereConcediu.Show();

        }
    }
}
