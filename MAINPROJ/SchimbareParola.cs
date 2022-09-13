using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MAINPROJ
{
    public partial class SchimbareParola : Form
    {
        String url = "http://localhost:5031/";
        int angajatId;
        string ParolaVeche;

        public SchimbareParola(int angajatId)
        {
            InitializeComponent();
            this.angajatId = angajatId;
        }

        private void Renunta_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new HomePage(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();

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

       

        private async void Salvare_Click(object sender, EventArgs e)
        {
            if (txtParolaVeche.Text != Decrypt(ParolaVeche))
            {
                MessageBox.Show("Parola incorecta!");
                return;
            }

     
            

            if (validatePassword(txtParolaNoua.Text, txtConfirm.Text) == 1)
            {
                string ParolaNoua = Encrypt(txtConfirm.Text);

                HttpResponseMessage response = await Common.client.PostAsync(url + $"api/SchimbareParola/UpdatePassword?password={ParolaNoua}&AngajatId={angajatId}", null);

                response.EnsureSuccessStatusCode();

                MessageBox.Show("Parola schimbata cu succes!");
                this.Hide();
                var otherform = new HomePage(angajatId);
                otherform.Closed += (s, args) => this.Close();
                otherform.Show();
            }

                     

        }

        

        private async void SchimbareParola_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = await Common.client.GetAsync(url + $"api/SchimbareParola/GetPassword?AngajatId={angajatId}");
            response.EnsureSuccessStatusCode();
            ParolaVeche = await response.Content.ReadAsStringAsync();


           
        }

        private void txtParolaNoua_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
