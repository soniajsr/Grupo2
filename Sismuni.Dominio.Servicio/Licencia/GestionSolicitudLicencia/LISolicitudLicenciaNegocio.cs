using Sismuni.Dominio.Entidad.Licencia.GestionDisponibilidadInspector;
using Sismuni.Dominio.Entidad.Licencia.GestionInspeccion;
using Sismuni.Dominio.Entidad.Licencia.GestionSolicitudInspeccion;
using Sismuni.Dominio.Entidad.Licencia.GestionSolicitudLicencia;
using Sismuni.Dominio.Negocio.Enumeraciones;
using Sismuni.Dominio.Negocio.Recursos;
using Sismuni.Infraestructura.Data.Repositorios.General;
using Sismuni.Infraestructura.Data.Repositorios.Licencia.GestionDisponibilidadInspector;
using Sismuni.Infraestructura.Data.Repositorios.Licencia.GestionSolicitudLicencia;
using System;
using System.Collections.Generic;
using Sismuni.Transversal.Mapeo.Mapeo;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sismuni.Infraestructura.Data.Modelo;
using Sismuni.Infraestructura.Data.Repositorios.Licencia.GestionInspeccion;
using Sismini.Transversal.Mapeo.Recursos;

namespace Sismuni.Dominio.Negocio.Licencia.GestionSolicitudLicencia
{
    public class LISolicitudLicenciaNegocio : ILISolicitudLicenciaNegocio
    {

        private readonly ILISolicitudLicenciaRepositorio _solicitudlicenciaRepositorio;
        private readonly IMultitablaRepositorio _multitablaRepositorio;
        private readonly ILIDisponibilidadInspectorRepositorio _disponibilidadRepositorio;
        private readonly ILIInspeccionRepositorio _inspeccionRepositorio;


        public LISolicitudLicenciaNegocio(ILISolicitudLicenciaRepositorio solicitudlicenciaRepositorio,
                                          IMultitablaRepositorio multitablaRepositorio,
                                          ILIDisponibilidadInspectorRepositorio disponibilidadRepositorio,
                                          ILIInspeccionRepositorio inspeccionRepositorio)
        {

            if (solicitudlicenciaRepositorio == (ILISolicitudLicenciaRepositorio)null) throw new ArgumentNullException("solicitudlicenciaRepositorio");
            if (multitablaRepositorio == (IMultitablaRepositorio)null) throw new ArgumentNullException("multitablaRepositorio");
            if (disponibilidadRepositorio == (ILIDisponibilidadInspectorRepositorio)null) throw new ArgumentNullException("disponibilidadRepositorio");
            if (inspeccionRepositorio == (ILIInspeccionRepositorio)null) throw new ArgumentNullException("inspeccionRepositorio");


            _solicitudlicenciaRepositorio = solicitudlicenciaRepositorio;
            _multitablaRepositorio = multitablaRepositorio;
            _disponibilidadRepositorio = disponibilidadRepositorio;
            _inspeccionRepositorio = inspeccionRepositorio;


        }

        public int AsignarInspeccion(InspeccionVob solicitud)
        {
            var unidad = _inspeccionRepositorio.UnidadDeTrabajo;
            
            var inspeccion = solicitud.ProyectarComo<LI_inspeccion>();
            inspeccion.estado = "1";
            inspeccion.observaciones = "solicitud asignada";
            _inspeccionRepositorio.Agregar(inspeccion);

            var solicitudes = _solicitudlicenciaRepositorio.obtenersolicitud(solicitud.id).ProyectarComo<LI_solicitudlicencia>();

            solicitudes.estado = EstadosValor.SolicitudLicenciaProgramado;

            _solicitudlicenciaRepositorio.Modificar(solicitudes);

            unidad.Confirmar();

            return inspeccion.id;

        }

        public RespuestaDisponibilidadInspectorVob BuscarDisponibilidadInspector(SolicitudDisponibilidadInspectorVob solicitud)
        {
            string valor = string.Empty;
            string texto = PrimerValorEnum.Seleccione.ToString();

            var rangohorarios = _multitablaRepositorio.ListarTablas(Negocio.Recursos.GrupoTabla.RangoHorarios);

            rangohorarios.Add(new Entidad.General.ElementoVob { Valor = valor, Texto = texto });

            rangohorarios = rangohorarios.OrderBy(x => x.Valor).ToList();
            

            List<DisponibilidadInspectorVob> lista = new List<DisponibilidadInspectorVob>();

            lista = _disponibilidadRepositorio.BuscarDisponibilidad();

            if (solicitud.DisponibilidadFilter.Fecha != null)
                lista = lista.Where(x => x.fechaHoraInicio.Value.ToShortDateString() == solicitud.DisponibilidadFilter.Fecha.Value.ToShortDateString()).ToList();

            if (solicitud.DisponibilidadFilter.Rango_Hora != null)
            {
                var valorrango = _multitablaRepositorio.ObtenerValor(solicitud.DisponibilidadFilter.Rango_Hora);

                var rango = valorrango.Texto.Split('-');

                lista = lista.Where(x => x.fechaHoraInicio.Value.Hour >= Convert.ToInt32(rango[0]) && x.fechaHoraFin.Value.Hour <= Convert.ToInt32(rango[1])).ToList();
            
            }

            if (solicitud.DisponibilidadFilter.NumeroSolicitud > 0 && solicitud.DisponibilidadFilter.EstadoSolicitud != EstadosValor.SolicitudLicenciaPendiente)
            {
                lista = _disponibilidadRepositorio.BuscarDisponibilidadPorSolicitud(solicitud.DisponibilidadFilter.NumeroSolicitud);
            }


            lista = lista.OrderByDescending(x => x.fechaHoraFin).ToList();


            int total = lista.Count();

            return new RespuestaDisponibilidadInspectorVob
            {
                listasodisponibilidad = lista,
                totalelementos = total,
                Rango_Horarios = rangohorarios
            };

           
        }

        public RespuestaBusquedaSolicitudLicenciaVob BuscarSolicitudLicencias(SolicitudBusquedaLicenciasVob solicitud)
        {
            List<SolicitudLicenciaVob> lista = new List<SolicitudLicenciaVob>();

            lista = _solicitudlicenciaRepositorio.BuscarSolicitudesLicencia();

            if (solicitud.SolicitudLicenciaFilter.FechaSolicitud != null)
                lista = lista.Where(x => x.FechaSolicitud.Value.ToShortDateString() == solicitud.SolicitudLicenciaFilter.FechaSolicitud.Value.ToShortDateString()).ToList();

            if (solicitud.SolicitudLicenciaFilter.FechaInspeccion != null)
                lista = lista.Where(x => x.FechaInspeccion == solicitud.SolicitudLicenciaFilter.FechaInspeccion).ToList();


            if (solicitud.SolicitudLicenciaFilter.numero > 0)
                lista = lista.Where(x => x.numero == solicitud.SolicitudLicenciaFilter.numero).ToList();

            if (solicitud.SolicitudLicenciaFilter.NombresSolicitante != null)
                lista = lista.Where(x => x.NombresSolicitante.ToUpper().Contains(solicitud.SolicitudLicenciaFilter.NombresSolicitante.ToUpper())).ToList();


            lista = lista.OrderBy(x => x.FechaSolicitud).ToList();
            
            int total = lista.Count();

            return new RespuestaBusquedaSolicitudLicenciaVob
            {
                listasolicitudeslicencia = lista,
                totalelementos = total
            };


        }


    }
}
