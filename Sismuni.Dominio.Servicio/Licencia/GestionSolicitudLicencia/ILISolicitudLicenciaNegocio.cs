using Sismuni.Dominio.Entidad.Licencia.GestionDisponibilidadInspector;
using Sismuni.Dominio.Entidad.Licencia.GestionInspeccion;
using Sismuni.Dominio.Entidad.Licencia.GestionSolicitudLicencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Negocio.Licencia.GestionSolicitudLicencia
{
    public interface ILISolicitudLicenciaNegocio
    {
        RespuestaBusquedaSolicitudLicenciaVob BuscarSolicitudLicencias(SolicitudBusquedaLicenciasVob solicitud);
        RespuestaDisponibilidadInspectorVob BuscarDisponibilidadInspector(SolicitudDisponibilidadInspectorVob solicitud);
        int AsignarInspeccion(InspeccionVob solicitud);
    }
}
