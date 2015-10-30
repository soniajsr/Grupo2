using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.Licencia.GestionInspeccion
{
    public class InspeccionVob
    {
        public int id { get; set; }
        public Nullable<System.DateTime> fechaHoraInicio { get; set; }
        public Nullable<System.DateTime> fechaHoraFin { get; set; }
        public string estado { get; set; }
        public string observaciones { get; set; }
        public int idSolicitudLicencia { get; set; }
        public int idInspector { get; set; }
        public Nullable<int> iddisponibilidad { get; set; }
    }
}
