using System;
using System.Collections.Generic;

namespace RandomProj.Models
{
    public partial class Echipe
    {
        public Echipe()
        {
            Angajats = new HashSet<Angajat>();
        }

        public int Id { get; set; }
        public string Nume { get; set; } 

        public virtual ICollection<Angajat> Angajats { get; set; }
    }
}
