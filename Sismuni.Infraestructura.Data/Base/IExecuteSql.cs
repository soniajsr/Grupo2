using System.Collections.Generic;
using System.Data.Objects;

namespace Sismuni.Infraestructura.Data.Base
{
    public interface IExecuteSql
    {
        /// <summary>
        /// EjecutaConsulta
        /// </summary>
        /// <typeparam name="TEntidad">TEntidad</typeparam>
        /// <param name="sqlQuery">sqlQuery</param>
        /// <param name="parameters">parameters</param>
        /// <returns>Lista de entidades</returns>
        IEnumerable<TEntidad> ExecuteStoreQuery<TEntidad>(string sqlQuery, params object[] parameters);

        /// <summary>
        /// EjecutaComando
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="parameters">parameters</param>
        /// <returns>int</returns>
        int ExecuteStoreCommand(string sqlCommand, params object[] parameters);
    }
}
