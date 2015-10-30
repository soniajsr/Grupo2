using Sismuni.Dominio.Administracion;
using Sismuni.Dominio.Entidad.General;
using Sismuni.Dominio.Entidad.Licencia.GestionSolicitudInspeccion;
using Sismuni.Dominio.Entidad.Licencia.GestionSolicitudLicencia;
using Sismuni.Presentacion.Web.Controllers.General;
using Sismuni.Presentacion.Web.Helpers.Mvc;
using Sismuni.Presentacion.Web.Models.Licencia.GestionSolicitudLicencia;
using Sismuni.Presentacion.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sismuni.Presentacion.Web.Controllers.Licencia.GestionSolicitudLicencia
{
    public class GestionSolicitudLicenciaBandejaController : BaseController
    {
        public readonly GestionLicenciasAdm _licenciaAdm;

        public GestionSolicitudLicenciaBandejaController()
        {
            _licenciaAdm = GestionLicenciasAdm.ObtenerServicio();
        }

        public ActionResult Index()
        {
            try
            {

                

                return RedirectToAction("Buscar", "GestionSolicitudLicenciaBandeja");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
            }
        }

        public PartialViewResult Buscar(int page = 1,
                                        string sort = "NUMEROEXPEDIENTE",
                                        string sortDir = "DESC",
                                        SolicitudLicenciaPaginadoModelo tablaPaginado = null,
                                        string mensaje = null,
                                        bool back = false
                                        )
        {

            //  var nombre = tablaPaginado.Filtro.Expediente != null ? tablaPaginado.Filtro.Expediente.NumeroExpediente : 0;

            //Buscamos si existe un temp del back
            if (back) tablaPaginado = GetCache<SolicitudLicenciaPaginadoModelo>(tablaPaginado);


            //Asignamos valores iniciales
            tablaPaginado = IniciarFiltro(tablaPaginado);

            //Construimos solicitud
            var solicitud = ConstruirSolicitud(page, sort, sortDir, tablaPaginado);

            //Invocamos al servicio

            //var _expedientenegocio = new GNTExpedienteNegocio();

            //var respuesta = _expedientenegocio.BuscarExpedientes(solicitud);
            var respuesta = _licenciaAdm.SolicitudLicenciaNegocio.BuscarSolicitudLicencias(solicitud);


            //construimos modelo
            var model = ConstruirModeloPaginado(page, respuesta, tablaPaginado.Filtro);
            model.AsignarMensaje(mensaje);

            if (respuesta != null)
            {
                if (respuesta.totalelementos == 0)
                    model.AsignarMensaje(MensajeMvc.MensajeAdvertencia(Mensajes.Msj_NoSeEncontraronResultados));
            }


            //Guardamos el filtro en la cache de la sesión
            if (!back) SetCache<SolicitudLicenciaPaginadoModelo>(tablaPaginado);


            //Retornamos vista con modelo
            return PartialView("_Index", model);
        }

        #region MÉTODOS - APOYO

        internal SolicitudLicenciaPaginadoModelo ConstruirModeloPaginado(int pagina, RespuestaBusquedaSolicitudLicenciaVob respuesta, SolicitudLicenciaFiltroModelo filtro)
        {
            return new SolicitudLicenciaPaginadoModelo
            {
                Grid = new SolicitudLicenciaGridModelo(respuesta.listasolicitudeslicencia, Convert.ToInt32(Paginacion.TamanioPaginaMin), respuesta.totalelementos),
                Filtro = new SolicitudLicenciaFiltroModelo(filtro.SolicitudLicencia)
            };
        }

        internal SolicitudBusquedaLicenciasVob ConstruirSolicitud(int pagina, string orden, string ordernDir, SolicitudLicenciaPaginadoModelo solicitud)
        {
            return new SolicitudBusquedaLicenciasVob
            {
                SolicitudLicenciaFilter = solicitud.Filtro.SolicitudLicencia,
                CriterioPaginar = new CriterioPaginarVob
                {
                    Tamanio = Convert.ToInt32(Paginacion.TamanioPaginaMin),
                    Pagina = pagina,
                    Orden = orden,
                    OrdenDir = ordernDir
                }
            };
        }

        internal SolicitudLicenciaPaginadoModelo IniciarFiltro(SolicitudLicenciaPaginadoModelo solicitudPaginado)
        {
            if (solicitudPaginado == null) solicitudPaginado = new SolicitudLicenciaPaginadoModelo();
            if (solicitudPaginado.Filtro.SolicitudLicencia == null) solicitudPaginado.Filtro.SolicitudLicencia = new SolicitudLicenciaVob();
            return solicitudPaginado;
        }

        #endregion

    }
}