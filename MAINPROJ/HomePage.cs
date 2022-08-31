﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAINPROJ;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MAINPROJ
{
    public partial class HomePage : Form
    {
        bool sidebarExpand;
        OleDbCommand cmd = new OleDbCommand();
        public int UserId { get; set; }
        public HomePage(int userId)
        {
            InitializeComponent();
            UserId = userId;
        }
        
        private void button2_Click(object sender, EventArgs e)
        { 
            btnUpdatePoza.Visible = false;

            btnSalvareModificari.Visible = false;

            txtEmail.Enabled = false;

            txtTelefon.Enabled = false;

            //Accesibile de utilizator

            OleDbConnection con = Common.GetConnection();
            con.Open();
            
            string numartelefon = txtTelefon.Text;
            string email = txtEmail.Text;
            string modifTel = $"UPDATE Angajat SET Numar_telefon = '{numartelefon}' WHERE Id = 4 ";
            cmd = new OleDbCommand(modifTel, con);
            string modifEmail = $"UPDATE Login SET Email = '{email}' WHERE Id = 4 ";


            cmd.ExecuteNonQuery();
            con.Close();

            //Accesibile de admin/manager

           //OleDbConnection con = Common.GetConnection();
           // con.Open();

           // string numartelefon = txtTelefon.Text;
           // string email = txtEmail.Text;
           // string modifTel = $"UPDATE Angajat SET Numar_telefon = '{numartelefon}' WHERE Id = 4 ";
           // cmd = new OleDbCommand(modifTel, con);
           // string modifEmail = $"UPDATE Login SET Email = '{email}' WHERE Id = 4 ";


           //cmd.ExecuteNonQuery();
           //con.Close();



        }


        private void button6_Click(object sender, EventArgs e)
        {
            txtEmail.Enabled = true;

            txtTelefon.Enabled = true;

            btnSalvareModificari.Visible = true;

            btnUpdatePoza.Visible = true;
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
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


        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var otherform = new MeniuNavigare();
            otherform.Closed += (s, args) => this.Close();
            otherform.Show();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

            //UserId = int =      $"UPDATE Login SET Email = '{email}' WHERE Id = 4 ";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void txtOvertime_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
