

namespace Sismuni.Transversal.Mapeo.Mapeo
{
    public static class TypeAdapterFactory
    {
        #region VARIABLES

        /// <summary>
        /// Contrato del tipo de adaptador actual.
        /// </summary>
        static ITypeAdapterFactory _currentTypeAdapterFactory = null;

        #endregion

        #region MÉTODOS ESTATICOS

        /// <summary>
        /// Establece contrato para la factoria del adaptador.
        /// </summary>
        /// <param name="adapterFactory">Contrato de la factoria del adaptador.</param>
        public static void SetCurrent(ITypeAdapterFactory adapterFactory)
        {
            _currentTypeAdapterFactory = adapterFactory;
        }

        /// <summary>
        /// Crea un nuevo tipo de dapatador conla factoria actual.
        /// </summary>
        /// <returns>Instancia del tipo de adaptador creado.</returns>
        public static ITypeAdapter CreateAdapter()
        {
            return _currentTypeAdapterFactory.Create();
        }

        #endregion
    }
}
