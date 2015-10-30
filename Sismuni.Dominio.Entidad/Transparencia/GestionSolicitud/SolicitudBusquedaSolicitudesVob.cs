using Sismuni.Dominio.Entidad.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.Transparencia.GestionSolicitud
{
    public class SolicitudBusquedaSolicitudesVob
    {
        public SolicitudVob SolicitudFilter { get; set; }
        public CriterioPaginarVob CriterioPaginar { get; set; }
    }
}
