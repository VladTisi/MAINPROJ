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
    public partial class RegisterPage : Form
    {
        string nume;
        string prenume;
        public RegisterPage(string nume, string prenume)
        {
            InitializeComponent();
            this.nume = nume;  
            this.prenume = prenume;
            cmbSex.Items.Add("Barbat");
            cmbSex.Items.Add("Femeie");
            txtNume.Text=nume;
            txtPrenume.Text=prenume;
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
                if (Char.IsLetter(myArray[i]))
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
    }
}
