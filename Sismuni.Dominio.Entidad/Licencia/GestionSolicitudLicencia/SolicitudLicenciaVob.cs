using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.Licencia.GestionSolicitudInspeccion
{
    public class SolicitudLicenciaVob
    {
        public int NumeroSolicitud { get; set; }
        public Nullable<int> numero { get; set; }
        public string estado { get; set; }
        public int idPersonaNoMunicipio { get; set; }
        public Nullable<DateTime> FechaSolicitud { get; set; }
        public Nullable<DateTime> FechaInspeccion { get; set; }

        public string NombresSolicitante { get; set; }
        public string NombresInspector { get; set; }

        public Nullable<decimal> NroExpediente { get; set; }
        public int id { get; set; }
        
        public int ID_Ciudadano { get; set; }
    }
}
