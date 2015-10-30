using Sismuni.Dominio.Administracion;
using Sismuni.Dominio.Entidad.General;
using Sismuni.Dominio.Entidad.Licencia.GestionDisponibilidadInspector;
using Sismuni.Dominio.Entidad.Licencia.GestionInspeccion;
using Sismuni.Presentacion.Web.Controllers.General;
using Sismuni.Presentacion.Web.Helpers.Mvc;
using Sismuni.Presentacion.Web.Models.Licencia.GestionDisponibilidadInspector;
using Sismuni.Presentacion.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sismuni.Presentacion.Web.Controllers.Licencia.GestionDisponibilidadInspector
{
    public class GestionDisponibilidadInspectorBandejaController : BaseController
    {
        // GET: GestionDisponibilidadInspectorBandeja
        public readonly GestionLicenciasAdm _licenciaAdm;

        public GestionDisponibilidadInspectorBandejaController()
        {
            _licenciaAdm = GestionLicenciasAdm.ObtenerServicio();
        }

        public ActionResult Index()
        {
            try
            {
                return RedirectToAction("Buscar", "GestionDisponibilidadInspectorBandeja");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
            }
        }

        public ActionResult Asignar(decimal id,
                                    decimal idinspector,
                                    DateTime? FechaInicio,
                                    DateTime? FechaFin,
                                    decimal idhorario
                                    )
        {
            InspeccionVob inspeccion = new InspeccionVob();

            inspeccion.iddisponibilidad = Convert.ToInt32(idhorario);
            inspeccion.idInspector = Convert.ToInt32(idinspector);
            inspeccion.idSolicitudLicencia = Convert.ToInt32(id);

            var idregistra = _licenciaAdm.SolicitudLicenciaNegocio.AsignarInspeccion(inspeccion);

            var mensaje = MensajeMvc.MensajeSatisfactorio(string.Format(Mensajes.MsjeInspeccionRegistrado, id));



            return RedirectToAction("Buscar", "GestionSolicitudLicenciaBandeja", new { mensaje = mensaje });
     

        }

        public PartialViewResult Buscar(int page = 1,
                                       string sort = "NUMEROEXPEDIENTE",
                                       string sortDir = "DESC",
                                       DisponibilidadInspectorPaginadoModelo tablaPaginado = null,
                                       string mensaje = null,
                                       bool back = false,
                                       decimal id = 0 ,
                                       string estado = "" 
                                       )
        {

            //  var nombre = tablaPaginado.Filtro.Expediente != null ? tablaPaginado.Filtro.Expediente.NumeroExpediente : 0;

            //Buscamos si existe un temp del back
            if (back) tablaPaginado = GetCache<DisponibilidadInspectorPaginadoModelo>(tablaPaginado);


            //Asignamos valores iniciales
            tablaPaginado = IniciarFiltro(tablaPaginado);

            //Construimos solicitud
            var solicitud = ConstruirSolicitud(page, sort, sortDir, tablaPaginado);

            //Invocamos al servicio

            //var _expedientenegocio = new GNTExpedienteNegocio();
            solicitud.DisponibilidadFilter.EstadoSolicitud = estado;
            solicitud.DisponibilidadFilter.NumeroSolicitud = id;


            //var respuesta = _expedientenegocio.BuscarExpedientes(solicitud);
            var respuesta = _licenciaAdm.SolicitudLicenciaNegocio.BuscarDisponibilidadInspector(solicitud);


            //construimos modelo
            var model = ConstruirModeloPaginado(page, respuesta, tablaPaginado.Filtro);
            model.AsignarMensaje(mensaje);

            model.Filtro.DisponibilidadInspector.NumeroSolicitud = id;
            model.Filtro.DisponibilidadInspector.EstadoSolicitud = estado;

            if (respuesta != null)
            {
                if (respuesta.totalelementos == 0)
                    model.AsignarMensaje(MensajeMvc.MensajeAdvertencia(Mensajes.Msj_NoSeEncontraronResultados));
            }


            //Guardamos el filtro en la cache de la sesión
            if (!back) SetCache<DisponibilidadInspectorPaginadoModelo>(tablaPaginado);


            //Retornamos vista con modelo
            return PartialView("_Index", model);
        }

        #region MÉTODOS - APOYO

        internal DisponibilidadInspectorPaginadoModelo ConstruirModeloPaginado(int pagina, RespuestaDisponibilidadInspectorVob respuesta, DisponibilidadInspectorFiltroModelo filtro)
        {
            return new DisponibilidadInspectorPaginadoModelo
            {
                Grid = new DisponibilidadInspectorGridModelo(respuesta.listasodisponibilidad, Convert.ToInt32(Paginacion.TamanioPaginaMin), respuesta.totalelementos),
                Filtro = new DisponibilidadInspectorFiltroModelo(filtro.DisponibilidadInspector,respuesta.Rango_Horarios)
            };
        }

        internal SolicitudDisponibilidadInspectorVob ConstruirSolicitud(int pagina, string orden, string ordernDir, DisponibilidadInspectorPaginadoModelo solicitud)
        {
            return new SolicitudDisponibilidadInspectorVob
            {
                DisponibilidadFilter = solicitud.Filtro.DisponibilidadInspector,
                CriterioPaginar = new CriterioPaginarVob
                {
                    Tamanio = Convert.ToInt32(Paginacion.TamanioPaginaMin),
                    Pagina = pagina,
                    Orden = orden,
                    OrdenDir = ordernDir
                }
            };
        }

        internal DisponibilidadInspectorPaginadoModelo IniciarFiltro(DisponibilidadInspectorPaginadoModelo solicitudPaginado)
        {
            if (solicitudPaginado == null) solicitudPaginado = new DisponibilidadInspectorPaginadoModelo();
            if (solicitudPaginado.Filtro.DisponibilidadInspector == null) solicitudPaginado.Filtro.DisponibilidadInspector = new DisponibilidadInspectorVob();
            return solicitudPaginado;
        }

        #endregion



    }


}