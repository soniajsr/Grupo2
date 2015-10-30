using Sismuni.Dominio.Entidad.Licencia.GestionDisponibilidadInspector;
using Sismuni.Infraestructura.Data.Base;
using Sismuni.Infraestructura.Data.Modelo;
using Sismuni.Infraestructura.Data.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.Licencia.GestionDisponibilidadInspector
{
    public class LIDisponibilidadInspectorRepositorio : Repositorio<LI_disponibilidadinspector>, ILIDisponibilidadInspectorRepositorio
    {
        public LIDisponibilidadInspectorRepositorio(IModeloUnidadDeTrabajo unidaDeTrabajo) : base(unidaDeTrabajo) { }

        public List<DisponibilidadInspectorVob> BuscarDisponibilidad()
        {
            var set = ObtenerSet<IModeloUnidadDeTrabajo>(this);

            var consulta = from c in set.LI_disponibilidadinspector
                           join emp in set.CO_Empleado on c.idInspector equals emp.ID_Empleado
                           join est in set.Multitabla on c.estado equals est.IdMultitabla
                           select new DisponibilidadInspectorVob
                           {
                               estado = c.estado,
                               fechaHoraInicio = c.fechaHoraInicio,
                               fechaHoraFin = c.fechaHoraFin,
                               NombresInspector = emp.Nombres + " " + emp.Apellido_Paterno + " " + emp.Apellido_Materno,
                               NombresEstado = est.NombreValor,
                               idInspector = c.idInspector,
                               id = c.id,
                           };

            return consulta.ToList();



        }

        public List<DisponibilidadInspectorVob> BuscarDisponibilidadPorSolicitud(decimal id)
        {
            var set = ObtenerSet<IModeloUnidadDeTrabajo>(this);

            var consulta = from c in set.LI_disponibilidadinspector
                           join emp in set.CO_Empleado on c.idInspector equals emp.ID_Empleado
                           join est in set.Multitabla on c.estado equals est.IdMultitabla
                           join ins in set.LI_inspeccion on c.id equals ins.iddisponibilidad
                           where ins.idSolicitudLicencia == id
                           select new DisponibilidadInspectorVob
                           {
                               estado = c.estado,
                               fechaHoraInicio = c.fechaHoraInicio,
                               fechaHoraFin = c.fechaHoraFin,
                               NombresInspector = emp.Nombres + " " + emp.Apellido_Paterno + " " + emp.Apellido_Materno,
                               NombresEstado = est.NombreValor,
                               idInspector = c.idInspector,
                               id = c.id,
                               NumeroSolicitud = ins.idSolicitudLicencia
                           };

            return consulta.ToList();



        }

    }
}
