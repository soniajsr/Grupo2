using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Base
{
    public interface IRepositorio<TEntidad> where TEntidad : class
    {
        /// <summary>
        /// Obtiene la unidad de trabajo.
        /// </summary>
        IUnidadDeTrabajo UnidadDeTrabajo { get; }

        /// <summary>
        /// Agrega entidad en el repositorios
        /// </summary>
        /// <param name="entidad">entidad a agregar al repositorio</param>
        void Agregar(TEntidad entidad);

        /// <summary>
        /// Agrega entidades en el repositorios
        /// </summary>
        /// <param name="entidad">entidad a agregar al repositorio</param>
        void AgregarRango(IEnumerable<TEntidad> entidades);

        /// <summary>
        /// Eliminar una lista de entidades
        /// </summary>
        /// <param name="entidades">entidades</param>
        void EliminarRango(IEnumerable<TEntidad> entidades);

        /// <summary>
        /// Elimina entidad en el repositorio
        /// </summary>
        /// <param name="entidad">entidad a eliminar del repositorio</param>
        void Eliminar(TEntidad entidad);

        /// <summary>
        /// Modifica entidad en el repositorio
        /// </summary>
        /// <param name="entidad">entidad a modificar en el repositorio</param>
        void Modificar(TEntidad entidad, bool activarDeteccion = false);

        /// <summary>
        /// ListaPorCriterio sin Tracking
        /// </summary>
        /// <param name="criterio">Criterio</param>
        /// <returns>Entidadades</returns>
        IEnumerable<TEntidad> ListarParaVer(ICriterio<TEntidad> criterio);

        /// <summary>
        /// ListarParaVerOrdenar
        /// </summary>
        /// <param name="criterio">Criterio</param>
        /// <returns>Entidadades</returns>
        IEnumerable<TEntidad> ListarParaVerOrdenar(ICriterio<TEntidad> criterio, string order, string orderDir);

        /// <summary>
        /// ListaPorCriterio con tracking
        /// </summary>
        /// <param name="criterio">Criterio</param>
        /// <returns>Entidadades</returns>
        IEnumerable<TEntidad> ListarParaEditar(ICriterio<TEntidad> criterio);

        /// <summary>
        /// Obtener entidad por criterio con tracking
        /// </summary>
        /// <param name="criterio">criterio</param>
        /// <returns>Entidad</returns>
        TEntidad EntidadParaVer(ICriterio<TEntidad> criterio);

        /// <summary>
        /// Obtener entidad por criterio con tracking
        /// </summary>
        /// <param name="criterio">criterio</param>
        /// <returns>Entidad</returns>
        TEntidad EntidadParaEditar(ICriterio<TEntidad> criterio);

        /// <summary>
        /// Contar criterio sin Tracking
        /// </summary>
        /// <param name="criterio">Criterio</param>
        /// <returns>Entidadades</returns>
        int ContarPorCriterio(ICriterio<TEntidad> criterio);

    }
}
