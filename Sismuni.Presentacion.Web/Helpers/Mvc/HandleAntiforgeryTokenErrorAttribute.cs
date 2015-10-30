using Sismuni.Presentacion.Web.Helpers.Log;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sismuni.Presentacion.Web.Helpers.Mvc
{
    public class HandleAntiforgeryTokenErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {

            string fecha = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
            string ruta_log = string.Format(ConfigurationManager.AppSettings["KeyRutaLogError"].ToString(), fecha);
            LogError log = new LogError();

            var controlador = (string)filterContext.RouteData.Values["controller"];
            var accion = (string)filterContext.RouteData.Values["action"];
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(new { action = "ErrorSistema", controller = "Error", mensaje = filterContext.Exception.Message }));

            log.AgregarError(ruta_log, filterContext.Exception.Message,controlador,accion);

        }
    }
}