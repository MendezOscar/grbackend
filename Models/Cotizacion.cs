using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Cotizacion
    {
        public int Cotizacionid { get; set; }
        public string Descripcion { get; set; }
        public int Clienteid { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
