using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.General
{
    public class PaginadoVob<T>
    {
        public IEnumerable<T> Elementos { get; set; }

        public int TotalElementos { get; set; }

        public PaginadoVob() { }

        public PaginadoVob(IEnumerable<T> elementos, int totalElementos)
        {
            TotalElementos = totalElementos;
            Elementos = elementos;
        }


        public string ToList()
        {
            throw new System.NotImplementedException();
        }
    }
}
