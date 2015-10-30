using Sismuni.Dominio.Entidad.Transparencia.GestionExpediente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Negocio.Transparencia
{
    public interface IGNTExpedienteNegocio
    {
        RespuestaBusquedaExpedientesVob BuscarExpedientes(SolicitudBusquedaExpedientesVob solicitud);
        EditorExpedienteVob ObtenerEditor(int? id);
        int Agregar(RegistrarExpedienteVob registro);
        int Modificar(RegistrarExpedienteVob registro);
    }
}
