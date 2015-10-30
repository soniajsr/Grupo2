using System.Web.Script.Serialization;

namespace Sismuni.Presentacion.Web.Helpers.Extensiones
{
    public static class SerializarJson
    {
        /// <summary>
        /// Serializa un objeto en modo JSON.
        /// </summary>
        /// <typeparam name="T">Clase del objeto.</typeparam>
        /// <param name="param">Objeto.</param>
        /// <returns>Cadena JSON del objeto.</returns>
        public static string Serialize<T>(this T param)
        {
            if (param == null) return null;
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(param);
        }

        /// <summary>
        /// Deserializa el string JSON en la objeto de la clase pasada como parámetro.
        /// </summary>
        /// <typeparam name="T">Clase del Objeto.</typeparam>
        /// <param name="data">String de tipo JSON.</param>
        /// <returns>Retorna el objeto de la clase pasada como parámtro.</returns>
        public static T Serialize<T>(this string data)
        {
            if (string.IsNullOrEmpty(data)) return default(T);
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(data);
        }

        /// <summary>
        /// Deserializa el string JSON en la objeto de la clase pasada como parámetro.
        /// </summary>
        /// <typeparam name="T">Clase del Objeto.</typeparam>
        /// <param name="data">String de tipo JSON.</param>
        /// <returns>Retorna el objeto de la clase pasada como parámtro.</returns>
        public static T SerializeNew<T>(this string data)
        {
            if (string.IsNullOrEmpty(data)) data = "{}";
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(data);
        }
    }
}