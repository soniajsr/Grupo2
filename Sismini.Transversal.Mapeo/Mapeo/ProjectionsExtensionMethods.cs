using System;
using System.Collections.Generic;
using System.Linq;

namespace Sismuni.Transversal.Mapeo.Mapeo
{
    public static class ProjectionsExtensionMethods
    {
        /// <summary>
        /// Proyecta como la entidad solicitada
        /// </summary>
        /// <typeparam name="TProjection">entidad solicitada</typeparam>
        /// <param name="item">elemento a proyectar</param>
        /// <returns>entidad proyectada</returns>
        public static TProjection ProyectarComo<TProjection>(this Object item)
            where TProjection : class,new()
        {
            if (item == null) return null;
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<TProjection>(item);
        }


        /// <summary>
        /// Proyecta una lista a otro tipo de lista.
        /// </summary>
        /// <typeparam name="TSource">Tipo Origen</typeparam>
        /// <typeparam name="TProjection">Tipo Destino</typeparam>
        /// <param name="items">Lista</param>
        /// <returns>Lista Proyectada</returns>
        public static List<TProjection> ProyectarComoLista<TSource, TProjection>(this IEnumerable<TSource> items)
            where TProjection : class
        {
            if (items == null) return null;
            if (!items.Any()) return new List<TProjection>();

            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }

        /// <summary>
        /// Proyecta una lista de objetos en un lista del tipo destino.
        /// </summary>
        /// <typeparam name="TProjection">Tipo destino</typeparam>
        /// <param name="items">Lista de objetos</param>
        /// <returns>Lista Proyectada</returns>
        public static List<TProjection> ProyectarComoLista<TProjection>(this IEnumerable<object> items)
            where TProjection : class,new()
        {
            if (items == null) return null;
            if (!items.Any()) return new List<TProjection>();

            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }

        /// <summary>
        /// Proyecta un diccionario como lista
        /// </summary>
        /// <typeparam name="TProjection">Tipo destino</typeparam>
        /// <param name="items">Diccionario</param>
        /// <returns>Lista proyectada</returns>
        public static List<TProjection> ProyectarComoLista<TProjection>(this Dictionary<string, string> items)
            where TProjection : class,new()
        {
            if (items == null) return null;
            if (!items.Any()) return new List<TProjection>();

            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }

    }
}
