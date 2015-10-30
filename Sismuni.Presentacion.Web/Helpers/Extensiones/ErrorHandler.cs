using Sismuni.Presentacion.Web.Helpers.Log;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Resources;

namespace Sismuni.Presentacion.Web.Helpers.Extensiones
{
    public static class ErrorHandler
    {
        /// <summary>
        /// LogHelper
        /// </summary>

        private readonly static LogError LogHelper = new LogError();

        /// <summary>
        /// CapturarError
        /// </summary>
        /// <param name="error">error</param>
        /// <param name="controlador">controlador</param>
        /// <param name="accion">accion</param>
        public static void CapturarError(this Exception error, string controlador = "", string accion = "")
        {
            var identificador = Guid.NewGuid().ToString();
            var rutalog = ConfigurationManager.AppSettings["KeyRutaLogError"];
            var usuario = "Administrador";
            var comentario = string.Format(@"El Usuario [{0}] ejecutó la accion: [{1}/{2}]", usuario, controlador, accion);
            LogHelper.AgregarError(rutalog,error.Message,controlador,accion);
        }
       
    }
}