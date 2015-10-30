using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sismuni.Presentacion.Web.Helpers.Extensiones;
using Sismuni.Presentacion.Web.Helpers.Enumeraciones;

namespace Sismuni.Presentacion.Web.Helpers.Mvc
{
    public class MensajeMvc
    {
        #region PROPIEDADES

        /// <summary>
        /// Tipo
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Mensaje
        /// </summary>
        public string Mensaje { get; set; }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// MensajeSatisfactorio
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <param name="param">param</param>
        /// <returns>string</returns>
        internal static string MensajeSatisfactorio(string mensaje, params object[] param)
        {
            return MensajeTipo(TipoNotificacionEnum.Satisfactorio, string.Format(mensaje, param));
        }

        /// <summary>
        /// MensajeSatisfactorio
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <returns>string</returns>
        internal static string MensajeSatisfactorio(string mensaje)
        {
            return MensajeTipo(TipoNotificacionEnum.Satisfactorio, mensaje);
        }

        /// <summary>
        /// MensajeError
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <param name="param">param</param>
        /// <returns>string</returns>
        internal static string MensajeError(string mensaje, params object[] param)
        {
            return MensajeTipo(TipoNotificacionEnum.Error, string.Format(mensaje, param));

        }

        /// <summary>
        /// MensajeError
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <returns>string</returns>
        internal static string MensajeError(string mensaje)
        {
            return MensajeTipo(TipoNotificacionEnum.Error, mensaje);
        }

        /// <summary>
        /// MensajeAdvertencia
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <param name="param">param</param>
        /// <returns>string</returns>
        internal static string MensajeAdvertencia(string mensaje, params object[] param)
        {
            return MensajeTipo(TipoNotificacionEnum.Advertencia, string.Format(mensaje, param));

        }

        /// <summary>
        /// MensajeAdvertencia
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <returns>string</returns>
        public static string MensajeAdvertencia(string mensaje)
        {
            return MensajeTipo(TipoNotificacionEnum.Advertencia, mensaje);
        }

        /// <summary>
        /// MensajePeligro
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <param name="param">param</param>
        /// <returns>string</returns>
        internal static string MensajePeligro(string mensaje, params object[] param)
        {
            return MensajeTipo(TipoNotificacionEnum.Peligro, string.Format(mensaje, param));

        }

        /// <summary>
        /// MensajePeligro
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <returns>string</returns>
        internal static string MensajePeligro(string mensaje)
        {
            return MensajeTipo(TipoNotificacionEnum.Peligro, mensaje);
        }

        /// <summary>
        /// MensajeTipo
        /// </summary>
        /// <param name="tipo">tipo</param>
        /// <param name="mensaje">mensaje</param>
        /// <returns>string</returns>
        internal static string MensajeTipo(TipoNotificacionEnum tipo, string mensaje)
        {
            return (new MensajeMvc
            {
                Tipo = tipo.ToString(),
                Mensaje = mensaje
            }).Serialize();
        }

        /// <summary>
        /// MensajeJson
        /// </summary>
        /// <param name="tipo">tipo</param>
        /// <param name="mensaje">mensaje</param>
        /// <returns>object</returns>
        internal static object MensajeJson(TipoNotificacionEnum tipo, string mensaje)
        {
            return new
            {
                Tipo = tipo.ToString(),
                Mensaje = mensaje
            };
        }

        /// <summary>
        /// ObtenerMensaje
        /// </summary>
        /// <param name="mensajeTipo">mensajeTipo</param>
        /// <returns>MensajeMvc</returns>
        internal static MensajeMvc ObtenerMensaje(string mensajeTipo)
        {
            return mensajeTipo.Serialize<MensajeMvc>();
        }

        #endregion
    }
}