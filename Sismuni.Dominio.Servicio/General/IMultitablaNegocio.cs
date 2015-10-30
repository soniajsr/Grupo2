using Sismuni.Dominio.Entidad.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Negocio.General
{
    public interface IMultitablaNegocio
    {
        List<ElementoVob> BuscarElementos(string idgrupo);
       

    }
}
