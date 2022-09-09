using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAINPROJ
{
    public partial class Recrutam : Form
    {
        private int angajatId;
        string nume;
        string prenume;
        int loginid;
        bool sidebarExpand;
        bool admin;
        bool manager;
        OleDbCommand cmd = new OleDbCommand();
        public Recrutam(int angajatId, bool admin, bool manager)
        {
            InitializeComponent();
            this.angajatId = angajatId;
            this.nume = nume;
            this.prenume = prenume;
            this.loginid = loginid;
            this.admin = admin;
            this.manager = manager;
            cmbSex.Items.Add("Barbat");
            cmbSex.Items.Add("Femeie");
            txtNume.Text = nume;
            txtPrenume.Text = prenume;
            SqlConnection con8 = Common.GetSqlConnection();
            con8.Open();
            string queryEchipa = "SELECT Id,Nume FROM Echipa";
            SqlDataAdapter da = new SqlDataAdapter(queryEchipa, con8);
            DataSet ds = new DataSet();
            da.Fill(ds, "Fleet");
            cmbNumeEchipa.DisplayMember = "Nume";
            cmbNumeEchipa.ValueMember = "Id";
            cmbNumeEchipa.DataSource = ds.Tables[0];
            con8.Close();
            SqlConnection con9 = Common.GetSqlConnection();
            con9.Open();
            string queryFunctie = "SELECT Id,Nume FROM Functie";
            SqlDataAdapter da2 = new SqlDataAdapter(queryFunctie, con9);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "Fleet");
            cmbNumeFunctie.DisplayMember = "Nume";
            cmbNumeFunctie.ValueMember = "Id";
            cmbNumeFunctie.DataSource = ds2.Tables[0];
            con9.Close();
        }
        private void Recrutam_Load(object sender, EventArgs e)
        {
            if(!admin || !manager)
            {
                label6.Visible = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private int validareSerieBuletin(string Serie)
        {
            bool hasDigits = false;
            char[] myArray = Serie.ToCharArray();
            for (int i = 0; i < myArray.Length; i++)
            {
                if (Serie.Length != 2)
                {
                    break;
                }
                if (Char.IsNumber(myArray[i]))
                {
                    break;
                }
                hasDigits = true;

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
            if (telefon.Length != 10)
            {
                return 0;
            }
            char[] myCharArray = telefon.ToCharArray();
            for (int i = 0; i < myCharArray.Length; i++)
            {
                if (!Char.IsDigit(myCharArray[i]))
                {
                    break;
                }
                hasNumbersOnly = true;
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
            if (nrbuletin.Length != 6)
            {
                return 0;
            }
            char[] myCharArray = nrbuletin.ToCharArray();
            for (int i = 0; i < myCharArray.Length; i++)
            {
                if (!Char.IsDigit(myCharArray[i]))
                {
                    break;
                }
                hasNumbersOnly = true;
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
            if (CNP.Length != 13)
            {
                return 0;
            }
            char[] myCharArray = CNP.ToCharArray();
            for (int i = 0; i < myCharArray.Length; i++)
            {
                if (!Char.IsDigit(myCharArray[i]))
                {
                    break;
                }
                hasNumbersOnly = true;
            }

            if (hasNumbersOnly)
            {
                return 1;
            }
            return 0;
        }

        private void txtCNP_TextChanged(object sender, EventArgs e)
        {

            if (validareCNP(txtCNP.Text) == 1)
            {
                string an = "";
                string firstpart = txtCNP.Text.Substring(0, 1);
                char an1 = char.Parse(txtCNP.Text.Substring(1, 1));
                char an2 = char.Parse(txtCNP.Text.Substring(2, 1));
                char luna1 = char.Parse(txtCNP.Text.Substring(3, 1));
                char luna2 = char.Parse(txtCNP.Text.Substring(4, 1));
                char ziua1 = char.Parse(txtCNP.Text.Substring(5, 1));
                char ziua2 = char.Parse(txtCNP.Text.Substring(6, 1));
                if (firstpart == "5" || firstpart == "6")
                {
                    an = "20";
                }
                if (firstpart == "1" || firstpart == "2")
                {
                    an = "19";
                }
                if (firstpart == "1" || firstpart == "5")
                {
                    cmbSex.SelectedIndex = 0;
                }
                else if (firstpart == "2" || firstpart == "6")
                {
                    cmbSex.SelectedIndex = 1;
                }
                string fullan = an + an1 + an2;
                string luna = Convert.ToString(luna1) + Convert.ToString(luna2);
                String ziua = Convert.ToString(ziua1) + Convert.ToString(ziua2);
                String fulldata = fullan + " " + luna + " " + ziua;
                dtpDataNasterii.Value = DateTime.Parse(fulldata);


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
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

                    MessageBox.Show("Profilul tau a fost creat!");
                }


            
        }

        private void dtpDataNasterii_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpDataAngajarii_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDataAngajarii.Value > DateTime.Now)
            {
                MessageBox.Show("Data angajarii invalida. Ati fost angajat in viitor?");
                dtpDataAngajarii.Value = DateTime.Now;
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new HomePage(angajatId);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new ConcediiRefuzate(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new Echipa(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuNavigare(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new GestionareConcedii(angajatId,admin,manager);
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuModificareDateAngajat(angajatId,admin,manager);
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new LogAuten();
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }
    }
}
