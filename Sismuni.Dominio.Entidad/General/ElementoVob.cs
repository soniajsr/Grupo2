using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.General
{
    public class ElementoVob
    {
        /// <summary>
        /// Valor en texto
        /// </summary>
        public string Valor { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        public object ValorObjeto { get; set; }

        /// <summary>
        /// Texto
        /// </summary>
        public string Texto { get; set; }

        /// <summary>
        /// Seleccione
        /// </summary>
        public bool Seleccionado { get; set; }        
    }
}
