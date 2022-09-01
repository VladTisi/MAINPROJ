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
using static MAINPROJ.Class1;
using System.Web.Security;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MAINPROJ
{
    public partial class LogAuten : Form
    {

        int angajatId;
        public LogAuten()
        {
            InitializeComponent();
            

        }
        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();
        private void Form2_Load(object sender, EventArgs e)
        {
           

        }
        private int validateEmail(string email)
            {
            if (email.Contains("@") && email.Contains(".") && email.Length > 8)
            {
                return 1;
            }
            else return 0;
            }

        private int validatePassword(string password, string confirmpassword)
        {
            bool specialchar = false;
            bool majuscula = false;
            bool digit = false;

            if(password == confirmpassword && password.Length>=8)
            {
                char[] mychars = password.ToCharArray();    
                for(int i=0; i<mychars.Length; i++)
                {
                    char c = mychars[i];
                    if(char.IsDigit(c) && digit == false)
                    {
                        digit = true;   
                    }
                    if (!char.IsLetterOrDigit(c) && specialchar == false && !char.IsWhiteSpace(c))
                    {
                        specialchar = true;
                    }
                    if (char.IsUpper(c) && majuscula == false)
                    {
                        majuscula = true;
                    }
                }
                if(digit && specialchar && majuscula)
                {
                    return 1;
                }
                
                
            } return 0;
        }
        private void AUTENTIFICARE_Click(object sender, EventArgs e)
        {
            int passvalid = validatePassword(autpass.Text, conpass.Text);
            int emailvalid = validateEmail(autemail.Text);

            if(passvalid==0)
            {
                MessageBox.Show("Parola invalida");

            }
            if(emailvalid==0)
            {
                MessageBox.Show("Email invalid");
            }
            if(passvalid ==1 && emailvalid ==1)
            {
                OleDbConnection con = Common.GetConnection();
                con.Open();
                string register = "INSERT INTO Login(Email,Parola) VALUES('" + autpass.Text + "','" + autpass.Text + "')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Contul tau a fost creat!");
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
            conn.Close();
            if (parola==password)
            {
                OleDbConnection conn2 = Common.GetConnection();
                cmd2 = new OleDbCommand($"SELECT AngajatId FROM Login WHERE Email='{email}'");
                cmd2.Connection = conn2;
                conn2.Open();
                angajatId = (int) cmd2.ExecuteScalar();
                conn2.Close();
                this.Hide();
                var otherform = new HomePage(angajatId);
                otherform.Closed += (s, args) => this.Close();
                otherform.Show();
            }
           


        }

        private void autemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            DialogResult dialogResult = MessageBox.Show("Doriti sa resetati parola?", "Resetare parola", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                OleDbConnection conn = Common.GetConnection();
                Random r = new Random();
                int x = r.Next(100000, 999999);
                Console.WriteLine(x);
                string email = logmail.Text;
                cmd = new OleDbCommand($"SELECT Parola FROM Login WHERE Email='{email}'");
                cmd.Connection = conn;
                conn.Open();
                string password = (string)cmd.ExecuteScalar();
                if (!String.IsNullOrEmpty(password))
                {
                    Class1.sendMail("Mail resetare parola", $"Ati solicitat schimbarea parolei. Introduceti codul:{x}. Daca nu ati fost dumneavoastra, ignorati acest mail. ", "denisa.marica@totalsoft.ro");
                    String s = Interaction.InputBox("Introduceti codul de validare primit pe email", "Cod de validare", "000000");
                    if (Int32.Parse(s)==x)
                    {
                        string selectId = $"SELECT AngajatId FROM Login WHERE Email='{email}'";
                        cmd.CommandText = selectId;
                        int angajatId = (int) cmd.ExecuteScalar();
                        string generated_pass = Membership.GeneratePassword(8, 0);
                        Console.WriteLine(generated_pass);
                        string updatePasswordQuery = $"UPDATE Login SET Parola='{generated_pass}' WHERE AngajatId={angajatId}";
                        cmd.CommandText=updatePasswordQuery;
                        cmd.ExecuteNonQuery();
                        Class1.sendMail("Parola temporara", $"Parola dumneavoasta temporara este: {generated_pass}", "denisa.marica@totalsoft.ro");
                    }
                    else
                    {
                        MessageBox.Show("Invalid code");
                    }
                }
                else
                {
                    MessageBox.Show("Nu exista un cont cu acest email");
                }
                conn.Close();


            }


        }
    }
}
