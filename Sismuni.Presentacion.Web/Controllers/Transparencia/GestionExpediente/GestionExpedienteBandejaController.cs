using Sismuni.Dominio.Entidad.General;
using Sismuni.Dominio.Entidad.Transparencia;
using Sismuni.Dominio.Entidad.Transparencia.GestionExpediente;
using Sismuni.Presentacion.Web.Models.Transparencia.GestionExpediente;
using Sismuni.Presentacion.Web.Models.General;
using Sismuni.Presentacion.Web.Helpers;
using Sismuni.Presentacion.Web.Helpers.Mvc;
using Sismuni.Presentacion.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sismuni.Presentacion.Web.Controllers.General;
using Sismuni.Dominio.Negocio.Transparencia;
using Sismuni.Dominio.Administracion;

namespace Sismuni.Presentacion.Web.Controllers.Transparencia.GestionExpediente
{
    public class GestionExpedienteBandejaController : BaseController
    {
        // GET: GestionExpedienteBandeja
        public readonly ExpedienteAdm _expedienteAdm;

        public GestionExpedienteBandejaController()
        {
            _expedienteAdm = ExpedienteAdm.ObtenerServicio();
        }


        public ActionResult Index()
        {
            try
            {
                return RedirectToAction("Buscar", "GestionExpedienteBandeja");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
            }
        }

        public PartialViewResult Buscar(int page = 1,
                                        string sort = "NUMEROEXPEDIENTE",
                                        string sortDir = "DESC",
                                        ExpedientePaginadoModelo tablaPaginado = null,
                                        string mensaje = null,
                                        bool back = false
                                        )
        {

          //  var nombre = tablaPaginado.Filtro.Expediente != null ? tablaPaginado.Filtro.Expediente.NumeroExpediente : 0;

            //Buscamos si existe un temp del back
            if (back) tablaPaginado = GetCache<ExpedientePaginadoModelo>(tablaPaginado);


            //Asignamos valores iniciales
            tablaPaginado = IniciarFiltro(tablaPaginado);

            //Construimos solicitud
            var solicitud = ConstruirSolicitud(page, sort, sortDir, tablaPaginado);

            //Invocamos al servicio

            //var _expedientenegocio = new GNTExpedienteNegocio();

            //var respuesta = _expedientenegocio.BuscarExpedientes(solicitud);
            var respuesta = _expedienteAdm.ExpedienteNegocio.BuscarExpedientes(solicitud);


            //construimos modelo
            var model = ConstruirModeloPaginado(page, respuesta, tablaPaginado.Filtro);
            model.AsignarMensaje(mensaje);

            if (respuesta != null)
            {
                if (respuesta.totalelementos == 0)
                    model.AsignarMensaje(MensajeMvc.MensajeAdvertencia(Mensajes.Msj_NoSeEncontraronResultados));
            }


            //Guardamos el filtro en la cache de la sesión
            if (!back) SetCache<ExpedientePaginadoModelo>(tablaPaginado);


            //Retornamos vista con modelo
            return PartialView("_Index", model);
        }

        #region MÉTODOS - APOYO

        internal ExpedientePaginadoModelo ConstruirModeloPaginado(int pagina, RespuestaBusquedaExpedientesVob respuesta, ExpedienteFiltroModelo filtro)
        {
            return new ExpedientePaginadoModelo
            {
                Grid = new ExpedienteGridModelo(respuesta.listaexpedientes, Convert.ToInt32(Paginacion.TamanioPaginaMin), respuesta.totalelementos),
                Filtro = new ExpedienteFiltroModelo(filtro.Expediente)
            };
        }

        internal SolicitudBusquedaExpedientesVob ConstruirSolicitud(int pagina, string orden, string ordernDir, ExpedientePaginadoModelo expediente)
        {
            return new SolicitudBusquedaExpedientesVob
            {
                ExpedienteFilter = expediente.Filtro.Expediente,
                CriterioPaginar = new CriterioPaginarVob
                {
                    Tamanio = Convert.ToInt32(Paginacion.TamanioPaginaMin),
                    Pagina = pagina,
                    Orden = orden,
                    OrdenDir = ordernDir
                }
            };
        }

        internal ExpedientePaginadoModelo IniciarFiltro(ExpedientePaginadoModelo expedientePaginado)
        {
            if (expedientePaginado == null) expedientePaginado = new ExpedientePaginadoModelo();
            if (expedientePaginado.Filtro.Expediente == null) expedientePaginado.Filtro.Expediente = new ExpedienteVob();
            return expedientePaginado;
        }

        #endregion
    }
}