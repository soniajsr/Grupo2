using Sismuni.Dominio.Entidad.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.Licencia.GestionDisponibilidadInspector
{
    public class SolicitudDisponibilidadInspectorVob
    {
        public DisponibilidadInspectorVob DisponibilidadFilter { get; set; }
        public CriterioPaginarVob CriterioPaginar { get; set; }
    }
}
