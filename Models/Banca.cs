using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Banca
    {
        public Banca()
        {
            Cliente = new HashSet<Cliente>();
            Tecnico = new HashSet<Tecnico>();
        }

        public int Bancaid { get; set; }
        public string Banco { get; set; }
        public string Cuenta { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Tecnico> Tecnico { get; set; }
    }
}
