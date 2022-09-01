using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAINPROJ
{
    public partial class MeniuModificareDateAngajat : Form
    {
        private int angajatId;

        OleDbCommand cmd = new OleDbCommand();

        public MeniuModificareDateAngajat(int angajatId)
        {
            this.angajatId = angajatId;

            InitializeComponent();
            AddItems();

        }

        private void AddItems()
        {
            OleDbConnection con = Common.GetConnection();
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            string numeprenumeAngajat = "SELECT  Nume, Prenume FROM Angajat";
            cmd = new OleDbCommand(numeprenumeAngajat, con);
            var rdr = cmd.ExecuteReader();

            

            while (rdr.Read())
            {
                comboListaAngajati.Items.Add(rdr.GetString(0) + ' ' + rdr.GetString(1));


            }

            con.Close();
        }









        private void comboListaAngajati_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string[] myArray=comboListaAngajati.SelectedItem.ToString().Split(' ');
            Console.WriteLine(myArray[0]);


        }

       
    }
}
