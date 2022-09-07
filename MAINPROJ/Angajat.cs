using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MAINPROJ
{
    public class Angajat
    {
        public string Nume
        {
            get { return Nume; }
            set { Nume = value; }
        }
        string Prenume {
            get { return Nume; }
            set { Nume = value; }
        }
        string Functie { get; set; }
        string Echipa { get; set; }
        string Sex { get; set; }
        int Salariu { get; set; }
        DateTime Data_angajarii { get; set; }
        string Email { get; set; }
        int Overtime { get; set; }
        string Numar_telefon { get; set; }

        public Angajat()
        {
        }

        public Angajat(string nume, string prenume, string functie, string echipa, string sex, int salariu, DateTime data_angajarii, string email, int overtime, string numar_telefon)
        {
            Nume = nume;
            Prenume = prenume;
            Functie = functie;
            Echipa = echipa;
            Sex = sex;
            Salariu = salariu;
            Data_angajarii = data_angajarii;
            Email = email;
            Overtime = overtime;
            Numar_telefon = numar_telefon;
        }


    }
}
