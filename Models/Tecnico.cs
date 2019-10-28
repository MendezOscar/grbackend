using System;
using System.Collections.Generic;

namespace grbackend.Models
{
    public partial class Tecnico
    {
        public Tecnico()
        {
            Anuncio = new HashSet<Anuncio>();
            Contrato = new HashSet<Contrato>();
            Evaluacion = new HashSet<Evaluacion>();
            Historialtecnico = new HashSet<Historialtecnico>();
            Pago = new HashSet<Pago>();
        }

        public int Tecnicoid { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int Servicioid { get; set; }
        public int Usuarioid { get; set; }
        public int Bancaid { get; set; }

        public virtual Banca Banca { get; set; }
        public virtual Servicio Servicio { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Anuncio> Anuncio { get; set; }
        public virtual ICollection<Contrato> Contrato { get; set; }
        public virtual ICollection<Evaluacion> Evaluacion { get; set; }
        public virtual ICollection<Historialtecnico> Historialtecnico { get; set; }
        public virtual ICollection<Pago> Pago { get; set; }
    }
}
