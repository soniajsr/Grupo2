using Sismuni.Dominio.Entidad.General;
using Sismuni.Dominio.Entidad.Transparencia.GestionSolicitud;
using Sismuni.Dominio.Negocio.Transparencia.GestionSolicitud;
using Sismuni.Presentacion.Web.Controllers.General;
using Sismuni.Presentacion.Web.Helpers.Mvc;
using Sismuni.Presentacion.Web.Models.Transparencia.GestionSolicitud;
using Sismuni.Presentacion.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sismuni.Presentacion.Web.Controllers.Transparencia.GestionSolicitud
{
    public class SolicitudBandejaController :  BaseController
    {
        // GET: SolicitudBandeja
        public ActionResult Index()
        {
            try
            {
                return RedirectToAction("Buscar", "SolicitudBandeja");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
            }
        }

        public PartialViewResult Buscar(int page = 1,
                                        string sort = "NUMEROESOLICITUD",
                                        string sortDir = "DESC",
                                        SolicitudPaginadoModelo tablaPaginado = null,
                                        string mensaje = null,
                                        bool back = false
                                        )
        {

            //  var nombre = tablaPaginado.Filtro.Expediente != null ? tablaPaginado.Filtro.Expediente.NumeroExpediente : 0;

            //Buscamos si existe un temp del back
            if (back) tablaPaginado = GetCache<SolicitudPaginadoModelo>(tablaPaginado);


            //Asignamos valores iniciales
            tablaPaginado = IniciarFiltro(tablaPaginado);

            //Construimos solicitud
            var solicitud = ConstruirSolicitud(page, sort, sortDir, tablaPaginado);

            //Invocamos al servicio

            var _solicitudnegocio = new GNTSolicitudNegocio();

            var respuesta = _solicitudnegocio.BuscarSolicitudes(solicitud);



            //construimos modelo
            var model = ConstruirModeloPaginado(page, respuesta, tablaPaginado.Filtro);
            model.AsignarMensaje(mensaje);

            if (respuesta != null)
            {
                if (respuesta.totalelementos == 0)
                    model.AsignarMensaje(MensajeMvc.MensajeAdvertencia(Mensajes.Msj_NoSeEncontraronResultados));
            }


            //Guardamos el filtro en la cache de la sesión
            if (!back) SetCache<SolicitudPaginadoModelo>(tablaPaginado);


            //Retornamos vista con modelo
            return PartialView("_Index", model);
        }

        #region MÉTODOS - APOYO

        internal SolicitudPaginadoModelo ConstruirModeloPaginado(int pagina, RespuestaBusquedaSolicitudesVob respuesta, SolicitudFiltroModelo filtro)
        {
            return new SolicitudPaginadoModelo
            {
                Grid = new SolicitudGridModelo(respuesta.listasolicitudes, Convert.ToInt32(Paginacion.TamanioPaginaMin), respuesta.totalelementos),
                Filtro = new SolicitudFiltroModelo(filtro.Solicitud)
            };
        }

        internal SolicitudBusquedaSolicitudesVob ConstruirSolicitud(int pagina, string orden, string ordernDir, SolicitudPaginadoModelo solicitud)
        {
            return new SolicitudBusquedaSolicitudesVob
            {
                SolicitudFilter = solicitud.Filtro.Solicitud,
                CriterioPaginar = new CriterioPaginarVob
                {
                    Tamanio = Convert.ToInt32(Paginacion.TamanioPaginaMin),
                    Pagina = pagina,
                    Orden = orden,
                    OrdenDir = ordernDir
                }
            };
        }

        internal SolicitudPaginadoModelo IniciarFiltro(SolicitudPaginadoModelo solicitudPaginado)
        {
            if (solicitudPaginado == null) solicitudPaginado = new SolicitudPaginadoModelo();
            if (solicitudPaginado.Filtro.Solicitud == null) solicitudPaginado.Filtro.Solicitud = new SolicitudVob();
            return solicitudPaginado;
        }

        #endregion
    }
}