using Sismini.Transversal.Mapeo.Recursos;
using Sismuni.Dominio.Entidad.Licencia.GestionSolicitudInspeccion;
using Sismuni.Infraestructura.Data.Base;
using Sismuni.Infraestructura.Data.Modelo;
using Sismuni.Infraestructura.Data.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.Licencia.GestionSolicitudLicencia
{
    public class LISolicitudLicenciaRepositorio : Repositorio<LI_solicitudlicencia>, ILISolicitudLicenciaRepositorio
    {

        public LISolicitudLicenciaRepositorio(IModeloUnidadDeTrabajo unidaDeTrabajo) : base(unidaDeTrabajo) { }

        public SolicitudLicenciaVob obtenersolicitud(decimal id)
        {
            var set = ObtenerSet<IModeloUnidadDeTrabajo>(this);
            var consulta = from sol in set.LI_solicitudlicencia
                           select new SolicitudLicenciaVob
                           {
                               id = sol.id,
                               FechaSolicitud = sol.FechaSolicitud,
                               ID_Ciudadano = sol.ID_Ciudadano,
                               numero = sol.numero,
                               estado = sol.estado

                           };

            return consulta.FirstOrDefault();

        }

        public List<SolicitudLicenciaVob> BuscarSolicitudesLicencia()
        {
            var set = ObtenerSet<IModeloUnidadDeTrabajo>(this);

            var consulta = from sol in set.LI_solicitudlicencia
                           join per in set.CO_Ciudadano on sol.ID_Ciudadano equals per.ID_Ciudadano
                           join ins in set.LI_inspeccion on sol.id equals ins.idSolicitudLicencia into tmp
                           from ins in tmp.DefaultIfEmpty()
                           join trab in set.CO_Empleado on ins.idInspector equals trab.ID_Empleado into tmp2
                           from trab in tmp2.DefaultIfEmpty()
                           orderby sol.FechaSolicitud descending 
                           select new SolicitudLicenciaVob
                           {
                               estado = sol.estado,
                               NumeroSolicitud = sol.id,
                               idPersonaNoMunicipio = sol.ID_Ciudadano,
                               numero = sol.numero,
                               NombresSolicitante = per.Nombres + " " + per.Apellido_Paterno + " " + per.Apellido_Materno,
                               FechaSolicitud = sol.FechaSolicitud,
                               FechaInspeccion = ins.LI_disponibilidadinspector.fechaHoraFin,
                               NombresInspector = trab.Nombres + " " + trab.Apellido_Paterno + " " + trab.Apellido_Materno
                           };


            return consulta.ToList();
            



        }

    }
}
