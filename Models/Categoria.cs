using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Evaluacion = new HashSet<Evaluacion>();
        }

        public int Categoriaid { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Evaluacion> Evaluacion { get; set; }
    }
}
