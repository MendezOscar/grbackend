using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Contrato
    {
        public int Contratoid { get; set; }
        public string Descripcion { get; set; }
        public int Tecnicoid { get; set; }

        public virtual Tecnico Tecnico { get; set; }
    }
}
