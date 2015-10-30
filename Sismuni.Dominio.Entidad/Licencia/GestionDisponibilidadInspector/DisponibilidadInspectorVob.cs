using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.Licencia.GestionDisponibilidadInspector
{
    public class DisponibilidadInspectorVob
    {
        public int id { get; set; }
        public Nullable<System.DateTime> fechaHoraInicio { get; set; }
        public Nullable<System.DateTime> fechaHoraFin { get; set; }
        public string estado { get; set; }
        public int idInspector { get; set; }
        public string NombresInspector { get; set; }
        public string NombresEstado { get; set; }
        public Nullable<DateTime> Fecha { get; set; }
        public string Rango_Hora { get; set; }
        public decimal NumeroSolicitud { get; set; }
        public string EstadoSolicitud { get; set; }
       
    }
}
