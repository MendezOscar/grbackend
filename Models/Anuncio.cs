using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Anuncio
    {
        public int Anuncioid { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public int Tecnicoid { get; set; }

        public virtual Tecnico Tecnico { get; set; }
    }
}
