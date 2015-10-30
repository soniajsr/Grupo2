using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.Transparencia.GestionSolicitud
{
    public class RespuestaBusquedaSolicitudesVob
    {
        public List<SolicitudVob> listasolicitudes { get; set; }
        public int totalelementos { get; set; }
    }
}
