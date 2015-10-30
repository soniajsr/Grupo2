using Sismuni.Dominio.Entidad.General;
using Sismuni.Dominio.Entidad.Licencia.GestionSolicitudInspeccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.Licencia.GestionSolicitudLicencia
{
    public class SolicitudBusquedaLicenciasVob
    {
        public SolicitudLicenciaVob SolicitudLicenciaFilter { get; set; }
        public CriterioPaginarVob CriterioPaginar { get; set; }
    }
}
