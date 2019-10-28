using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cotizacion = new HashSet<Cotizacion>();
            Evaluacion = new HashSet<Evaluacion>();
            Pago = new HashSet<Pago>();
        }

        public int Clienteid { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int Bancaid { get; set; }
        public int Usuarioid { get; set; }

        public virtual Banca Banca { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Cotizacion> Cotizacion { get; set; }
        public virtual ICollection<Evaluacion> Evaluacion { get; set; }
        public virtual ICollection<Pago> Pago { get; set; }
    }
}
