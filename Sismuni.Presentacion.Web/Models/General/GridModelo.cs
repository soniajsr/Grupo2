using System.Collections.Generic;


namespace Sismuni.Presentacion.Web.Models.General
{
    public class GridModelo<T>
    {
        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="items">items</param>
        public GridModelo(IEnumerable<T> items)
        {
            ElementosPagina = items;
            TamanioPagina = 1;
            TotalPagina = 0;
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="elementosPagina">Elementos a pintar en la página</param>
        /// <param name="tamanioPagina">Número de elementos por página</param>
        /// <param name="totalPagina">Numero total elementos resultante luego de aplicar los filtros </param>
        public GridModelo(IEnumerable<T> elementosPagina, int tamanioPagina, int totalPagina)
        {
            ElementosPagina = elementosPagina;
            TamanioPagina = tamanioPagina;
            TotalPagina = totalPagina;
        }

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// ElementosPagina
        /// </summary>
        public IEnumerable<T> ElementosPagina { get; set; }

        /// <summary>
        /// TamanioPagina
        /// </summary>
        public int TamanioPagina { get; set; }

        /// <summary>
        /// TotalPagina
        /// </summary>
        public int TotalPagina { get; set; }

        #endregion

    }
}