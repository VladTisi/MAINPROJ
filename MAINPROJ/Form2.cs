using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace PrisonBreakProj
{
    public partial class LogAuten : Form
    {
        public LogAuten()
        {
            InitializeComponent();
            

        }
        OleDbCommand cmd = new OleDbCommand();
        private void Form2_Load(object sender, EventArgs e)
        {
           

        }

        private void AUTENTIFICARE_Click(object sender, EventArgs e)
        {
           if(autemail.Text =="" && autpass.Text=="" && conpass.Text =="")
            {
                MessageBox.Show("Campurile nu sunt completate");
            }
           else if(autpass.Text == conpass.Text)
            {
                OleDbConnection con = Common.GetConnection();
                con.Open();
                string register = "INSERT INTO Angajati VALUES('" + autpass.Text + "','" + autpass.Text + "')" ;
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Contul tau a fost creat!");

            }
           else
            {
                MessageBox.Show("Parolele nu se potrivesc!");
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void conpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
