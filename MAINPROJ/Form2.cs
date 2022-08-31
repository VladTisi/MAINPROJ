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



namespace MAINPROJ
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
           else if(autpass.Text == conpass.Text && autemail.Text!="")
            {
                OleDbConnection con = Common.GetConnection();
                con.Open();
                string register = "INSERT INTO Login(Email,Parola) VALUES('" + autpass.Text + "','" + autpass.Text + "')" ;
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

        private void checkLog_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLog.Checked)
            {
               logpass.PasswordChar = '\0';
            }
            else
            {
                logpass.PasswordChar = '*';
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void conpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkAut_CheckedChanged(object sender, EventArgs e)
        {
            if(checkAut.Checked)
            {
                autpass.PasswordChar = '\0';
                conpass.PasswordChar = '\0';
            }
            else
            {
                autpass.PasswordChar = '*';
                conpass.PasswordChar = '*';
            }
        }

        private void autpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void logare_Click(object sender, EventArgs e)
        {
            string email = logmail.Text;

            OleDbConnection conn = Common.GetConnection();
            cmd = new OleDbCommand($"SELECT Parola FROM Login WHERE Email='{email}'");
            cmd.Connection = conn;
            conn.Open();
            string parola = logpass.Text;
            string password = (string)cmd.ExecuteScalar();
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email invalid");
            }
            if(password != logpass.Text)
            {
                MessageBox.Show("Parola invalida");
            }
            Console.WriteLine(logpass.Text);
            conn.Close();


        }
    }
}
