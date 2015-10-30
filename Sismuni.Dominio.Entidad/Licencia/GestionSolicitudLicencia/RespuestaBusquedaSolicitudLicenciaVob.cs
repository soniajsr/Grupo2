using Sismuni.Dominio.Entidad.Licencia.GestionSolicitudInspeccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.Licencia.GestionSolicitudLicencia
{
    public class RespuestaBusquedaSolicitudLicenciaVob
    {
        public List<SolicitudLicenciaVob> listasolicitudeslicencia { get; set; }
        public int totalelementos { get; set; }
    }
}
