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
    public class SolicitudController : BaseController
    {
        // GET: Solicitud
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Editor(int? id, string mensaje = null)
        {

            try
            {
                var _solicitudnegocio = new GNTSolicitudNegocio();

                var respuesta = _solicitudnegocio.ObtenerEditor(id);

                var modelo = new SolicitudEditorModelo(respuesta.Solicitud, respuesta.Tipo_Documentos,respuesta.Modo_Envios,respuesta.Tipo_Informaciones);

                modelo.AsignarMensaje(mensaje);

                return View("_Editor", modelo);

            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
            }


        }

        public ActionResult Agregar(SolicitudEditorModelo editor)
        {
            // Generando solicitud
            var solicitud = new RegistrarSolicitudVob
            {
                Solicitud = editor.Solicitud,
            };

            try
            {

                var _solicitudnegocio = new GNTSolicitudNegocio();
                // Agregando nuevo 
                var id = _solicitudnegocio.Agregar(solicitud);
                //EncuestaUsuarioPaginadoModelo model = new EncuestaUsuarioPaginadoModelo();
                //model.Filtro.EncuestaUsuario.IdEncuesta = id;
                // Generando el mensaje de salida
                var mensaje = MensajeMvc.MensajeSatisfactorio(string.Format(Mensajes.MsjeSolicitudRegistrado, id));

                //Redireccionando a la bandeja de Contrato
                return RedirectToAction("Buscar", "SolicitudBandeja", new { mensaje = mensaje });
                //  return RedirectToAction("Editor", "GestionExpediente", new { id = id, mensaje = mensaje });
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
            }
        }

        public ActionResult Modificar(SolicitudEditorModelo editor)
        {
            // Generando solicitud
            var solicitud = new RegistrarSolicitudVob
            {
                Solicitud = editor.Solicitud,
            };

            try
            {

                var _solicitudnegocio = new GNTSolicitudNegocio();
                // Agregando nuevo 
                var id = _solicitudnegocio.Modificar(solicitud);
                //EncuestaUsuarioPaginadoModelo model = new EncuestaUsuarioPaginadoModelo();
                //model.Filtro.EncuestaUsuario.IdEncuesta = id;
                // Generando el mensaje de salida
                var mensaje = MensajeMvc.MensajeSatisfactorio(string.Format(Mensajes.MsjeSolicitudModificado, id));

                //Redireccionando a la bandeja de Contrato
                return RedirectToAction("Buscar", "SolicitudBandeja", new { mensaje = mensaje });
                //  return RedirectToAction("Editor", "GestionExpediente", new { id = id, mensaje = mensaje });
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
            }
        }
    }
}