using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.General
{
    public class CriterioPaginarVob
    {
        /// <summary>
        /// Pagina
        /// </summary>
        public int Pagina { get; set; }

        /// <summary>
        /// Tamanio
        /// </summary>
        public int Tamanio { get; set; }

        /// <summary>
        /// Orden
        /// </summary>
        public string Orden { get; set; }

        /// <summary>
        /// OrdenDir
        /// </summary>
        public string OrdenDir { get; set; }
    }
}
