using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Negocio.Enumeraciones
{
    public enum PrimerValorEnum
    {
        /// <summary>
        /// Indica que se la seleccionado la opción "Vacío".
        /// </summary>
        Vacio = -1,

        /// <summary>
        /// Indica que no se ha seleccionado ningún elemento de la lista.
        /// </summary>
        Ninguno = -2,

        /// <summary>
        /// Indica que se debe seleccioanr una opción de la lista.
        /// </summary>
        Seleccione = -3,

        /// <summary>
        /// Indica que debe considerar seleccionados todos los elementos de la lista.
        /// </summary>
        Todos = -4,
        /// <summary>
        /// Indica cuando el IdPadreOpcion es "0" lista todos los Grupos de Opciones
        /// </summary>
        IdPadreOpcion = 0
    }
}
