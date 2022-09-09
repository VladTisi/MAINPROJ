using Newtonsoft.Json;
using RandomProj;
using RandomProj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Login = RandomProj.Models.Login;

namespace MAINPROJ
{
    public partial class RegisterPage : Form
    {
        string nume;
        string prenume;
        int loginid;
        bool admin;
        bool manager;
        bool sidebarExpand;
        int angajatId;
        OleDbCommand cmd = new OleDbCommand();
        String url= "http://localhost:5031/api/";
        public  RegisterPage(int loginid,string nume, string prenume,bool admin,bool manager, int angajatId)
        {
            InitializeComponent();
            this.nume = nume;  
            this.prenume = prenume;
            this.loginid=loginid;
            this.admin = admin;
            this.manager = manager;
            this.angajatId = angajatId;
            cmbSex.Items.Add("Barbat");
            cmbSex.Items.Add("Femeie");
            txtNume.Text=nume;
            txtPrenume.Text=prenume;
            GetEchipe();
            GetFunctii();
        }
        private void RegisterPage_Load(object sender, EventArgs e)
        {
            if (!admin && !manager)
            {
                sidebar.Visible = false;
                button3.Visible = false;
            }
            else
            {
                txtPrenume.Enabled = true;
                txtNume.Enabled = true;
                button2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private int validareSerieBuletin(string Serie)
        {
            bool hasDigits = false;
            char[] myArray = Serie.ToCharArray();
            for (int i = 0; i<myArray.Length; i++) { 
                if (Serie.Length!=2)
                {
                    break;
                }
                if (Char.IsNumber(myArray[i]))
                {
                    break;
                }
                hasDigits=true;

        }

            if (hasDigits)
            {
                return 1;
            }
            return 0;
        }

        private int validareNrTelefon(string telefon)
        {
            bool hasNumbersOnly = false;
            if (telefon.Length!=10)
            {
                return 0;
            }
            char[] myCharArray = telefon.ToCharArray();
            for (int i = 0; i<myCharArray.Length; i++)
            {
                if (!Char.IsDigit(myCharArray[i]))
                {
                    break;
                }
                hasNumbersOnly=true;
            }

            if (hasNumbersOnly)
            {
                return 1;
            }
            return 0;
        }

        private int validareNrBuletin(string nrbuletin)
        {
            bool hasNumbersOnly = false;
            if (nrbuletin.Length!=6)
            {
                return 0;
            }
            char[] myCharArray = nrbuletin.ToCharArray();
            for (int i = 0; i<myCharArray.Length; i++)
            {
                if (!Char.IsDigit(myCharArray[i]))
                {
                    break;
                }
                hasNumbersOnly=true;
            }

            if (hasNumbersOnly)
            {
                return 1;
            }
            return 0;
        }

        private int validareCNP(string CNP) 
        {
            bool hasNumbersOnly = false;
            if (CNP.Length!=13)
            {
                return 0;
            }
            char[] myCharArray = CNP.ToCharArray();
            for(int i = 0; i<myCharArray.Length; i++)
            {
                if (!Char.IsDigit(myCharArray[i]))
                {
                    break;
                }
                hasNumbersOnly=true;
            }

            if (hasNumbersOnly)
            {
                return 1;
            }
            return 0;
        }

        private void txtCNP_TextChanged(object sender, EventArgs e)
        {

            if (validareCNP(txtCNP.Text)==1)
            {
                string an="";
                string firstpart =txtCNP.Text.Substring(0, 1);
                char an1 = char.Parse(txtCNP.Text.Substring(1,1));
                char an2 = char.Parse(txtCNP.Text.Substring(2,1));
                char luna1 = char.Parse(txtCNP.Text.Substring(3, 1));
                char luna2= char.Parse(txtCNP.Text.Substring(4, 1));
                char ziua1 = char.Parse(txtCNP.Text.Substring(5, 1));
                char ziua2= char.Parse(txtCNP.Text.Substring(6, 1));
                if (firstpart=="5"||firstpart=="6")
                {
                     an = "20";
                }
                if (firstpart=="1"||firstpart=="2")
                {
                    an= "19";
                }
                if (firstpart=="1"||firstpart=="5")
                {
                    cmbSex.SelectedIndex=0;
                }
                else if(firstpart=="2"||firstpart=="6")
                {
                    cmbSex.SelectedIndex=1;
                }
                string fullan = an+an1+an2;
                string luna = Convert.ToString(luna1)+Convert.ToString(luna2);
                String ziua = Convert.ToString(ziua1)+Convert.ToString(ziua2);
                String fulldata = fullan +" " + luna + " " + ziua;
                dtpDataNasterii.Value = DateTime.Parse(fulldata);


            }

        }

        private void txtSerie_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool cnpvalid = true;
            bool serievalida = true;
            bool nrtelefon = true;
            bool nrbuletin = true;
            if (validareCNP(txtCNP.Text)==0)
            {
                MessageBox.Show("CNP Invalid");
                cnpvalid=false;
                txtCNP.Text="";
            }
            if (validareSerieBuletin(txtSerie.Text)==0)
            {
                MessageBox.Show("Serie Invalida");
                serievalida=false;
                txtSerie.Text="";
            }
            if (validareNrTelefon(txtTelefon.Text)==0)
            {
                MessageBox.Show("Numar telefon Invalid");
                nrtelefon=false;
                txtTelefon.Text="";
            }
            if (validareNrBuletin(txtNrBuletin.Text)==0)
            {
                MessageBox.Show("Numar buletin invalid");
                nrbuletin=false;
                txtNrBuletin.Text="";
            }
            if (nrbuletin&&nrtelefon&&serievalida&&cnpvalid)
            {
                OleDbConnection con = Common.GetConnection();
                con.Open();
                string register = $"INSERT INTO Angajat(Nume,Prenume,LoginId,Data_Angajarii,Data_Nasterii,CNP,Serie_buletin,Nr_buletin,Numar_telefon,esteAdmin,Sex,Salariu,Overtime,IdFunctie,IdEchipa)" +
                    $"VALUES ('{txtNume.Text}','{txtPrenume.Text}',{loginid},'{dtpDataAngajarii.Value}','{dtpDataNasterii.Value}','{txtCNP.Text}','{txtSerie.Text}','{txtNrBuletin.Text}','{txtTelefon.Text}','0','{cmbSex.Text}','0','0','{cmbNumeFunctie.SelectedValue}','{cmbNumeEchipa.SelectedValue}')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Profilul tau a fost creat!");

                //$"SELECT Id FROM Angajat WHERE Nume='{nume}' AND Prenume='{prenume}"
                string selectangajatid = $"SELECT Id FROM Angajat WHERE Nume='{nume}' AND Prenume='{prenume}'";
                cmd.CommandText = selectangajatid;
                int angajatid = (int)cmd.ExecuteScalar();
                string updateAngajatId = $"UPDATE Login SET AngajatId={angajatid} WHERE Id={loginid}";
                cmd.CommandText=updateAngajatId;
                cmd.ExecuteNonQuery();
                con.Close();

                this.Hide();
                var otherform = new HomePage(angajatid);
                otherform.Closed += (s, args) => this.Close();
                otherform.Show();


            }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDataAngajarii.Value>DateTime.Now)
            {
                MessageBox.Show("Data angajarii invalida. Ati fost angajat in viitor?");
                dtpDataAngajarii.Value = DateTime.Now;
            }
        }

        private void cmbNumeEchipa_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtNume_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpDataNasterii_ValueChanged(object sender, EventArgs e)
        {

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

        private async void button3_Click(object sender, EventArgs e)
        {
            string email = $"{txtNume.Text}.{txtPrenume.Text}@totalsoft.ro";
            string generated_pass = Membership.GeneratePassword(8, 0);
            Console.WriteLine(generated_pass);
            await Common.client.PostAsync(url+$"RegisterPage/InsertLogin?email={email}&parola={Encrypt(generated_pass)}",null);
            HttpResponseMessage response = await Common.client.GetAsync(url+$"RegisterPage/GetIdLogin?email={email}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Login> ids = JsonConvert.DeserializeObject<List<Login>>(responseBody);
            int loginid = ids[0].Id;
            Console.WriteLine($"userid is {loginid}");



            bool cnpvalid = true;
            bool serievalida = true;
            bool nrtelefon = true;
            bool nrbuletin = true;
            if (validareCNP(txtCNP.Text) == 0)
            {
                MessageBox.Show("CNP Invalid");
                cnpvalid = false;
                txtCNP.Text = "";
            }
            if (validareSerieBuletin(txtSerie.Text) == 0)
            {
                MessageBox.Show("Serie Invalida");
                serievalida = false;
                txtSerie.Text = "";
            }
            if (validareNrTelefon(txtTelefon.Text) == 0)
            {
                MessageBox.Show("Numar telefon Invalid");
                nrtelefon = false;
                txtTelefon.Text = "";
            }
            if (validareNrBuletin(txtNrBuletin.Text) == 0)
            {
                MessageBox.Show("Numar buletin invalid");
                nrbuletin = false;
                txtNrBuletin.Text = "";
            }
            if (nrbuletin && nrtelefon && serievalida && cnpvalid)
            {
                OleDbConnection con = Common.GetConnection();
                con.Open();
                string register = $"INSERT INTO Angajat(Nume,Prenume,LoginId,Data_Angajarii,Data_Nasterii,CNP,Serie_buletin,Nr_buletin,Numar_telefon,esteAdmin,Sex,Salariu,Overtime,IdFunctie,IdEchipa)" +
                    $"VALUES ('{txtNume.Text}','{txtPrenume.Text}',{loginid},'{dtpDataAngajarii.Value}','{dtpDataNasterii.Value}','{txtCNP.Text}','{txtSerie.Text}','{txtNrBuletin.Text}','{txtTelefon.Text}','0','{cmbSex.Text}','0','0','{cmbNumeFunctie.SelectedValue}','{cmbNumeEchipa.SelectedValue}')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                int angajatid = 0;
                HttpResponseMessage response2 = await Common.client.GetAsync(url+$"RegisterPage/GetAngajatIdFromLoginId?loginid={loginid}");
                response2.EnsureSuccessStatusCode();
                string responseBody2 = await response2.Content.ReadAsStringAsync();
                List<Login> listaid = JsonConvert.DeserializeObject<List<Login>>(responseBody2);
                angajatid=listaid[0].Id;


                await Common.client.PostAsync(url+$"RegisterPage/UpdateAngajatId?id={loginid}&angajatid={angajatid}",null);

                MessageBox.Show("Profilul tau a fost creat!");
            }



        }

        private void cmbNumeFunctie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPrenume_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbSex_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        // Butoane meniu navigare
        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new HomePage(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new ConcediiRefuzate(angajatId, admin, manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new Echipa(angajatId, admin, manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuNavigare(angajatId, admin, manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new GestionareConcedii(angajatId, admin, manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuModificareDateAngajat(angajatId, admin, manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }
        ///////////////////////////////////////////////////////////////////////////

        public async void GetFunctii()
        {
            HttpResponseMessage response = await Common.client.GetAsync(url+"RegisterPage/GetIdNumeFromFunctie");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Functie> listaFunctii = JsonConvert.DeserializeObject<List<Functie>>(responseBody);
            DataTable dt = new DataTable();
            DataColumn c = new DataColumn("Id");
            dt.Columns.Add(c);
            c = new DataColumn("Nume");
            dt.Columns.Add(c);
           
                if (admin)
                {
                    foreach (Functie f in listaFunctii)
                    {
                        DataRow r = dt.NewRow();
                        r["Id"] = f.Id;
                        r["Nume"] = f.Nume;
                        dt.Rows.Add(r);
                    }
                }
                else 
                {
                    foreach (Functie f in listaFunctii)
                    {
                        if (f.Id != 3)
                        {
                             DataRow r = dt.NewRow();
                            r["Id"] = f.Id;
                            r["Nume"] = f.Nume;
                            dt.Rows.Add(r);
                        }
                    }
                }
            cmbNumeFunctie.DisplayMember = "Nume";
            cmbNumeFunctie.ValueMember = "Id";
            cmbNumeFunctie.DataSource = dt;

            return;
        }
        public async void GetEchipe()
        {
            HttpResponseMessage response = await Common.client.GetAsync(url + "RegisterPage/GetIdNumeFromEchipa");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Functie> listaFunctii = JsonConvert.DeserializeObject<List<Functie>>(responseBody);
            DataTable dt = new DataTable();
            DataColumn c = new DataColumn("Id");
            dt.Columns.Add(c);
            c = new DataColumn("Nume");
            dt.Columns.Add(c);

            foreach (Functie f in listaFunctii)
            {
                DataRow r = dt.NewRow();
                r["Id"] = f.Id;
                r["Nume"] = f.Nume;
                dt.Rows.Add(r);
            }

            cmbNumeEchipa.DisplayMember = "Nume";
            cmbNumeEchipa.ValueMember = "Id";
            cmbNumeEchipa.DataSource = dt;

            return;
        }
    }
}
