using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            Historialtecnico = new HashSet<Historialtecnico>();
            Pago = new HashSet<Pago>();
            Tecnico = new HashSet<Tecnico>();
        }

        public int Servicioid { get; set; }
        public string Nombre { get; set; }
        public int Categoriaid { get; set; }

        public virtual ICollection<Historialtecnico> Historialtecnico { get; set; }
        public virtual ICollection<Pago> Pago { get; set; }
        public virtual ICollection<Tecnico> Tecnico { get; set; }
    }
}
