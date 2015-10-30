using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.Transparencia
{
    public class ExpedienteVob
    {
        public long NumeroExpediente { get; set; }
        public Nullable<System.DateTime> FechaExpediente { get; set; }
        public Nullable<long> NumeroSolicitud { get; set; }
        public string Observaciones { get; set; }
        public string Especificaciones_Tecnicas { get; set; }
        public Nullable<int> Estado { get; set; }

        public Nullable<System.DateTime> FECHAINICIO { get; set; }
        
        public string Nombres_Solicitante { get; set; }

        public Nullable<System.DateTime> FECHAFIN { get; set; }
        

        public Nullable<decimal> Codigo_Expediente { get; set; }

        public string FECHACONSULTA { get; set; }
        public string NOMBREARCHIVO { get; set; }
        public string Asunto { get; set; }
        public string Tipo_Expediente { get; set; }

    }
}
