using Sismuni.Dominio.Entidad.Transparencia.GestionSolicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Negocio.Transparencia.GestionSolicitud
{
    public interface IGNTSolicitudNegocio
    {
        RespuestaBusquedaSolicitudesVob BuscarSolicitudes(SolicitudBusquedaSolicitudesVob solicitud);
        EditorSolicitudVob ObtenerEditor(int? id);
        int Agregar(RegistrarSolicitudVob registro);
        int Modificar(RegistrarSolicitudVob registro);
    }
}
