using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cliente = new HashSet<Cliente>();
            Tecnico = new HashSet<Tecnico>();
        }

        public int Usuarioid { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public int Tipo { get; set; }
        public int Cuenta { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Tecnico> Tecnico { get; set; }
    }
}
