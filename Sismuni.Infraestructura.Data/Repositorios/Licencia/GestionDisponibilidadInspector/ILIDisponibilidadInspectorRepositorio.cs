using Sismuni.Dominio.Entidad.Licencia.GestionDisponibilidadInspector;
using Sismuni.Infraestructura.Data.Base;
using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.Licencia.GestionDisponibilidadInspector
{
    public interface ILIDisponibilidadInspectorRepositorio : IRepositorio<LI_disponibilidadinspector>
    {
        List<DisponibilidadInspectorVob> BuscarDisponibilidad();
        List<DisponibilidadInspectorVob> BuscarDisponibilidadPorSolicitud(decimal id);

    }
}
