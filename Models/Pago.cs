using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Pago
    {
        public int Pagoid { get; set; }
        public double Monto { get; set; }
        public string Tarjeta { get; set; }
        public string Tarjetahabiente { get; set; }
        public string Fechadeexpiracion { get; set; }
        public int Cleinteid { get; set; }
        public int Tecnicoid { get; set; }
        public int Servicioid { get; set; }

        public virtual Cliente Cleinte { get; set; }
        public virtual Servicio Servicio { get; set; }
        public virtual Tecnico Tecnico { get; set; }
    }
}
