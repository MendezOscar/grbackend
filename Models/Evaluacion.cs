using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Evaluacion
    {
        public int Evaluacionid { get; set; }
        public int Puntuacion { get; set; }
        public string Comentario { get; set; }
        public int Clienteid { get; set; }
        public int Tecnicoid { get; set; }
        public int Categoriaid { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Tecnico Tecnico { get; set; }
    }
}
