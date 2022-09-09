using MAINPROJ;
using Newtonsoft.Json;
using RandomProj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAINPROJ
{
    public partial class CerereConcediu : Form
    {
        private int angajatId;
        OleDbCommand cmd = new OleDbCommand();
        bool sidebarExpand;
        private System.Windows.Forms.Timer tmr;
        bool admin;
        bool manager;
        String url = "http://localhost:5031/api/";
        public CerereConcediu(int angajatId,bool admin, bool manager)
        {
            InitializeComponent();
            this.angajatId = angajatId;
            this.admin = admin; 
            this.manager = manager;

            tmr = new System.Windows.Forms.Timer();
            tmr.Tick += delegate {
                this.Close();
            };
            tmr.Interval = (int)TimeSpan.FromMinutes(5).TotalMilliseconds;
            tmr.Start();
        }

        private async void CerereConcediu_Load(object sender, EventArgs e)
        {


            HttpResponseMessage response3 = await Common.client.GetAsync(url + $"MeniuModificareDateAngajat/GetIdEchipa?Id={angajatId}");
            response3.EnsureSuccessStatusCode();

            string result = await response3.Content.ReadAsStringAsync();

            var ceva = JsonConvert.DeserializeObject(result);

            int echipaId = Convert.ToInt32(ceva);



            HttpResponseMessage response4 = await Common.client.GetAsync(url + $"MeniuModificareDateAngajat/GetMembriEchipa?echipaId={echipaId}");
            response4.EnsureSuccessStatusCode();
            string response4Body = await response4.Content.ReadAsStringAsync();

            List<Angajat> listaAngajati2 = JsonConvert.DeserializeObject<List<Angajat>>(response4Body);
            var bindingSourceAngajat = new BindingSource();
            bindingSourceAngajat.DataSource = listaAngajati2;
            cmbInlocuitor.DataSource = bindingSourceAngajat;
            cmbInlocuitor.ValueMember = "Id";
            cmbInlocuitor.DisplayMember = "Nume";
            foreach (Angajat angajat in listaAngajati2)
            {
                //cmbInlocuitor.Items.Add(angajat.Nume + ' ' + angajat.Prenume);
            }

            this.tipConcediuTableAdapter.Fill(this.dataSet1.TipConcediu);
            // TODO: This line of code loads data into the 'dataSet1.TipConcediu' table. You can move, or remove it, as needed.

            OleDbConnection con3 = Common.GetConnection();
            con3.Open();
            OleDbCommand cmd = new OleDbCommand();

            string dateAngajat = $"SELECT  esteAdmin, IdFunctie FROM Angajat WHERE Id={angajatId}";
            cmd = new OleDbCommand(dateAngajat, con3);
            var rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                bool admin = rdr.GetBoolean(0);
                int manager = rdr.GetInt32(1);
                if (admin != true && manager != 3)
                {
                    button7.Visible = false;
                }
            }

            string comanda = $"declare @numar as int  set @numar=(select datediff( month, Angajat.Data_angajarii, Getdate() )*2  from Angajat where Id={angajatId})  select @numar - isnull(sum( datediff( day, Concediu.Data_inceput, Concediu.Data_sfarsit )- datediff( week, Concediu.Data_inceput, Concediu.Data_sfarsit )*2 +1),0) as Zile  from Angajat   join Concediu on Angajat.Id=Concediu.angajatId  join StareConcediu on Concediu.stareConcediuId=StareConcediu.Id  where Angajat.Id={angajatId} and StareConcediu.Id=2";
            cmd= new OleDbCommand(comanda, con3);
            OleDbDataReader reader=cmd.ExecuteReader();
            reader.Read();
            label5.Text = reader["Zile"].ToString();
            con3.Close();
          
             
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDataIncepere.Value<DateTime.Now)
            {
                MessageBox.Show("Data inceperii nu poate fi in trecut!");
                dtpDataIncepere.Value=DateTime.Now;
            }
        }

        private void dtpDataSfarsit_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDataSfarsit.Value<DateTime.Now)
            {
                MessageBox.Show("Data sfarsitului nu poate fi in trecut");
                dtpDataSfarsit.Value=dtpDataIncepere.Value.AddDays(1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            OleDbConnection con = Common.GetConnection();
            con.Open();
            //string sss = $"asdasd{dtpDataIncepere.Value},{dtpDataIncepere.Value}";
            //Console.WriteLine(sss);
            
            string comanda = $"select datediff(day,'{dtpDataIncepere.Value}','{dtpDataSfarsit.Value}')+1";
            cmd = new OleDbCommand(comanda, con);
            int nr = (int)cmd.ExecuteScalar();
            if (nr > Convert.ToInt32(label5.Text))
                MessageBox.Show("Nu ai destule zile de concediu");
            
            else
            {
                MessageBox.Show("Cerere de concediu adaugata!");
                Console.WriteLine(cmbInlocuitor.SelectedIndex); 
                string register = $"INSERT INTO Concediu(TipConcediuId,Data_inceput,Data_sfarsit,stareConcediuId,angajatId,InlocuitorId) VALUES ({cmbTipConcediu.SelectedValue},'{dtpDataIncepere.Value}','{dtpDataSfarsit.Value}',{1},{angajatId},{cmbInlocuitor.SelectedIndex})";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            dtpDataIncepere.Value=DateTime.Now.AddDays(1);
            dtpDataSfarsit.Value=dtpDataIncepere.Value.AddDays(1);
            Console.WriteLine(nr);
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void cmbInlocuitor_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            string Nume = ((Angajat)e.ListItem).Nume;
            string Prenume = ((Angajat)e.ListItem).Prenume;
            e.Value = Nume + " " + Prenume;
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
