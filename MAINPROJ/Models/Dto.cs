using System;
using MAINPROJ;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace RandomProj
{
    public class Dto
    {
        public int Id { get; set; }
        public string Nume { get; set; } 
        public string Prenume { get; set; } 
        public string Functie { get; set; }
        public string Status { get; set; }
        public DateTime DataInceput { get; set; }
        public DateTime DataSfarsit { get; set; }

    }

    public class AngajatFunctie
    {
        public string Nume { get; set; } 
        public string Prenume { get; set; } 
        public string Functie { get; set; }  
        public int IdFunctieFromFunctie { get; set; }

        public int IdFunctie { get; set; }


        public int IdFunctieFromAngajat{ get; set; }

    }

    public class AngajatConcediu
    {
        public int IdAngajatFromAngajat { get; set; }

        public DateTime DataInceput { get; set; }

        public DateTime DataSfarsit { get; set; }

        public int? StareConcediuId  { get; set; }
    }
    public class Member
    {
        public string Nume { get; set; } 
        public string Prenume { get; set; }
        public string Functia { get; set; } 
        public DateTime DataAngajarii { get; set; }
    }
}
