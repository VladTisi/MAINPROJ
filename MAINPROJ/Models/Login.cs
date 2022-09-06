using System;
using System.Collections.Generic;

namespace RandomProj.Models
{
    public partial class Login
    {
        public Login()
        {
            Angajats = new HashSet<Angajat>();
        }

        public int Id { get; set; }
        public string Email { get; set; } 
        public string Parola { get; set; } 
        public int? AngajatId { get; set; }

        public virtual Angajat Angajat { get; set; }
        public virtual ICollection<Angajat> Angajats { get; set; }
    }
}
