

namespace Sismuni.Transversal.Mapeo.Mapeo
{
    public interface ITypeAdapterFactory
    {
        #region MÉTODOS DE LA INTERFACE

        /// <summary>
        /// Crea el tipo del adapatador.
        /// </summary>
        /// <returns>Adaptador creado del tipo ITypeAdapter.</returns>
        ITypeAdapter Create();

        #endregion
    }
}
