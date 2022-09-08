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

using System.Security.Cryptography;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using RandomProj.Models;

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
        String url = "http://localhost:5031/";
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

            if (password == confirmpassword && password.Length >= 8)
            {
                char[] mychars = password.ToCharArray();
                for (int i = 0; i < mychars.Length; i++)
                {
                    char c = mychars[i];
                    if (char.IsDigit(c) && digit == false)
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
                if (digit && specialchar && majuscula)
                {
                    return 1;
                }


            }
            return 0;
        }

        private async ValueTask<int> checkIfEmailExists()
        {
            string email = autemail.Text;
            HttpResponseMessage response = await Common.client.GetAsync(url+$"api/LogAuten/GetPassword?email={email}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Login> listaParole = JsonConvert.DeserializeObject<List<Login>>(responseBody);
            if (listaParole.Count>0)
            {
                return 0;
            }
            

            return 1;
        }
        private async void AUTENTIFICARE_Click(object sender, EventArgs e)
        {
            int passvalid = validatePassword(autpass.Text, conpass.Text);
            int emailvalid = validateEmail(autemail.Text);

            if (passvalid == 0)
            {
                MessageBox.Show("Parola invalida");
                autpass.Text="";
                conpass.Text="";

            }
            if (emailvalid == 0)
            {
                MessageBox.Show("Email invalid");
                autemail.Text="";
            }

            if ((await checkIfEmailExists())==0)
            {
                MessageBox.Show("Exista deja un cont cu acest email!");
                autemail.Text="";

            }

            if (passvalid == 1 && emailvalid == 1 && (await checkIfEmailExists())==1)
            {
                //OleDbConnection con = Common.GetConnection();
                //con.Open();
                //string register = "INSERT INTO Login(Email,Parola) VALUES('" + autemail.Text + "','" + Encrypt(autpass.Text) + "')";
                //cmd = new OleDbCommand(register, con);
                //cmd.ExecuteNonQuery();
                //con.Close();

                HttpResponseMessage response = await Common.client.PostAsync(url+$"api/LogAuten/InsertLogin?email={autemail.Text}&password={Encrypt(autpass.Text)}",null);


                MessageBox.Show("Contul tau a fost creat!");
                string[] myArray = autemail.Text.Split('.');
                Console.WriteLine(myArray[0]);
                Console.WriteLine(myArray[1].Split('@')[0]);
                string email = autemail.Text;

                //OleDbConnection conn1234 = Common.GetConnection();
                //cmd2 = new OleDbCommand($"SELECT Id FROM Login WHERE Email='{email}'");
                //cmd2.Connection = conn1234;
                //conn1234.Open();
                //int IdLogin = (int)cmd2.ExecuteScalar();
                //conn1234.Close();
                HttpResponseMessage newresponse = await Common.client.GetAsync(url+$"api/LogAuten/GetIdFromEmail?email={email}");
                newresponse.EnsureSuccessStatusCode();
                string responseBody2 = await newresponse.Content.ReadAsStringAsync();
                List<Login> listaParole = JsonConvert.DeserializeObject<List<Login>>(responseBody2);
                int IdLogin = listaParole[0].Id;
                autemail.Text="";
                autpass.Text="";
                conpass.Text="";
                this.Hide();
                var otherform = new RegisterPage(IdLogin,myArray[0], myArray[1].Split('@')[0]);
                otherform.Closed += (s, args) => this.Close();
                otherform.Show();
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
            if (checkAut.Checked)
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

        private async void logare_Click(object sender, EventArgs e)
        {
            string email = logmail.Text;

            //OleDbConnection conn = Common.GetConnection();
            //cmd = new OleDbCommand($"SELECT Parola FROM Login WHERE Email='{email}'");
            //cmd.Connection = conn;
            //conn.Open();
            string parola = logpass.Text;
            //string password = Decrypt((string)cmd.ExecuteScalar());
            HttpResponseMessage response = await Common.client.GetAsync(url+$"api/LogAuten/GetPassword?email={email}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Login> listaParole = JsonConvert.DeserializeObject<List<Login>>(responseBody);
            string password = Decrypt(listaParole[0].Parola);
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email invalid");
            }
            if (password != logpass.Text)
            {
                MessageBox.Show("Parola invalida");
            }
            //conn.Close();


            if (parola == password)
            {
                String s = Interaction.InputBox("Introduceti codul de validare primit pe email", "Cod de validare", "000000");
                Random r = new Random();
                int x = r.Next(100000, 999999);
                if (Convert.ToInt32(s)==x)
                {

                }
                //OleDbConnection conn2 = Common.GetConnection();
                //cmd2 = new OleDbCommand($"SELECT AngajatId FROM Login WHERE Email='{email}'");
                //cmd2.Connection = conn2;
                //conn2.Open();
                //angajatId = (int)cmd2.ExecuteScalar();
                //conn2.Close();
                HttpResponseMessage response2 = await Common.client.GetAsync(url+$"api/LogAuten/GetAngajatIdFromEmail?email={email}");
                response2.EnsureSuccessStatusCode();
                string responseBody2 = await response2.Content.ReadAsStringAsync();
                List<Login> listaParole2 = JsonConvert.DeserializeObject<List<Login>>(responseBody2);
                int angajatId = (int)listaParole2[0].AngajatId;
                this.Hide();
                var otherform = new HomePage(angajatId);
                otherform.Closed += (s, args) => this.Close();
                otherform.Show();
            }

        }

        public static string Encrypt(string encryptString)
        {
            string EncryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";  //we can change the code converstion key as per our requirement    
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";  //we can change the code converstion key as per our requirement, but the decryption key should be same as encryption key    
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        private void autemail_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {



            DialogResult dialogResult = MessageBox.Show("Doriti sa resetati parola?", "Resetare parola", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //OleDbConnection conn = Common.GetConnection();
                Random r = new Random();
                int x = r.Next(100000, 999999);
                Console.WriteLine(x);
                string email = logmail.Text;
                //cmd = new OleDbCommand($"SELECT Parola FROM Login WHERE Email='{email}'");
                //cmd.Connection = conn;
                //conn.Open();
                //string password = (string)cmd.ExecuteScalar();
                HttpResponseMessage response = await Common.client.GetAsync(url+$"api/LogAuten/GetPassword?email={email}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Login> listaParole = JsonConvert.DeserializeObject<List<Login>>(responseBody);
                string password=listaParole[0].Parola;
                if (!String.IsNullOrEmpty(password))
                {
                    Class1.sendMail("Mail resetare parola", $"Ati solicitat schimbarea parolei. Introduceti codul:{x}. Daca nu ati fost dumneavoastra, ignorati acest mail. ", email);
                    String s = Interaction.InputBox("Introduceti codul de validare primit pe email", "Cod de validare", "000000");
                    if (Int32.Parse(s) == x)
                    {
                        HttpResponseMessage response2 = await Common.client.GetAsync(url+$"api/LogAuten/GetAngajatIdFromEmail?email={email}");
                        response2.EnsureSuccessStatusCode();
                        string responseBody2 = await response2.Content.ReadAsStringAsync();
                        List<Login> listaParole2 = JsonConvert.DeserializeObject<List<Login>>(responseBody2);
                        int angajatId = (int)listaParole2[0].AngajatId;
                        //string selectId = $"SELECT AngajatId FROM Login WHERE Email='{email}'";
                        //cmd.CommandText = selectId;
                        //int angajatId = (int)cmd.ExecuteScalar();
                        string generated_pass = Membership.GeneratePassword(8, 0);
                        Console.WriteLine(generated_pass);
                        //string updatePasswordQuery = $"UPDATE Login SET Parola='{Encrypt(generated_pass)}' WHERE AngajatId={angajatId}";
                        //cmd.CommandText = updatePasswordQuery;
                        //cmd.ExecuteNonQuery();
                        ///api/LogAuten/UpdatePassword?password=Vlad1234%2A&angajatid=32
                        HttpResponseMessage abcd = await Common.client.PostAsync(url+$"api/LogAuten/UpdatePassword?password={Encrypt(generated_pass)}&angajatid={angajatId}",null);
                        Class1.sendMail("Parola temporara", $"Parola dumneavoasta temporara este: {generated_pass}", email);
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
                //conn.Close();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkIfEmailExists();
        }
    }
    }


