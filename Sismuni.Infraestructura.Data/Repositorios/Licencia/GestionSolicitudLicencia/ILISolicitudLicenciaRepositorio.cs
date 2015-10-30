using Sismuni.Dominio.Entidad.Licencia.GestionSolicitudInspeccion;
using Sismuni.Infraestructura.Data.Base;
using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.Licencia.GestionSolicitudLicencia
{
    public interface ILISolicitudLicenciaRepositorio : IRepositorio<LI_solicitudlicencia>
    {
        List<SolicitudLicenciaVob> BuscarSolicitudesLicencia();
        SolicitudLicenciaVob obtenersolicitud(decimal id);

    }
}
