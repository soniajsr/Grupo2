using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sismuni.Dominio.Entidad;
using Sismuni.Dominio.Entidad.Seguridad;

namespace Sismuni.Infraestructura.Data.Base
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        /// <summary>
        /// Método que confirma todos los cambios.
        /// </summary>
        void Confirmar(string idTransaccion, UsuarioVob usuario);

        /// <summary>
        /// Método que confirma todos los cambios.
        /// </summary>
        void Confirmar();

        /// <summary>
        /// Activa la detección de cambios
        /// </summary>
        void EnableDetectChange();

        /// <summary>
        /// Desactiva la detección de cambios
        /// </summary>
        void DisableDetectChange();
    }
}
