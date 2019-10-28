using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Historialtecnico
    {
        public int Historialtecnicoid { get; set; }
        public int Tecnicoid { get; set; }
        public int Servicioid { get; set; }

        public virtual Servicio Servicio { get; set; }
        public virtual Tecnico Tecnico { get; set; }
    }
}
