using Sismuni.Dominio.Entidad.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.Transparencia.GestionExpediente
{
    public class SolicitudBusquedaExpedientesVob
    {
        public ExpedienteVob ExpedienteFilter { get; set; }
        public CriterioPaginarVob CriterioPaginar { get; set; }
    }
}
