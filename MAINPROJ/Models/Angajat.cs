using MAINPROJ;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace RandomProj.Models
{
    public partial class Angajat
    {
        public Angajat()
        {
            ConcediuInlocuitors = new HashSet<Concediu>();
            InverseManager = new HashSet<Angajat>();
            Logins = new HashSet<Login>();
        }

        public int Id { get; set; }
        public string Nume { get; set; } 
        public string Prenume { get; set; } 
        public int? LoginId { get; set; }
        public DateTime? DataAngajarii { get; set; }
        public DateTime? DataNasterii { get; set; }
        public string Cnp { get; set; }
        public string SerieBuletin { get; set; } 
        public string NrBuletin { get; set; } 
        public string NumarTelefon { get; set; } 
        public bool? EsteAdmin { get; set; }
        public int? ManagerId { get; set; }
        public string Sex { get; set; } 
        public string Salariu { get; set; }
        public string Overtime { get; set; }
        public bool? SexVizbil { get; set; }

        public bool? SalariuVizibil { get; set; }

        public int? IdFunctie { get; set; }
        public int? IdEchipa { get; set; }
        public int? ZileConcediu { get; set; }
        public int? ZileConcediuRamase { get; set; }
        public string Poza { get; set; }

        public virtual Echipe Echipa { get; set; }
        public virtual Functie Functie { get; set; }
        public virtual Login Login { get; set; } 
        public virtual Angajat Manager { get; set; }
        public virtual Concediu Concediu { get; set; }
        public virtual ICollection<Concediu> Concedius { get; set; }
        public virtual ICollection<Concediu> ConcediuInlocuitors { get; set; }
        public virtual ICollection<Angajat> InverseManager { get; set; }
        public virtual ICollection<Login> Logins { get; set; }

    }
}
