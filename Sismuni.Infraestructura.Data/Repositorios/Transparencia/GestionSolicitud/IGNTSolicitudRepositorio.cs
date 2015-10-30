using Sismuni.Dominio.Entidad.Transparencia.GestionSolicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.Transparencia.GestionSolicitud
{
    public interface IGNTSolicitudRepositorio
    {
        List<SolicitudVob> BuscarSolicitudes();
        SolicitudVob BuscarSolicitudporId(long id);
        int Agregar(SolicitudVob solicitud);
        int Modificar(SolicitudVob solicitud);
    }
}
