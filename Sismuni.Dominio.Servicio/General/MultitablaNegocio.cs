using Sismuni.Dominio.Entidad.General;
using Sismuni.Infraestructura.Data.Repositorios.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Negocio.General
{
    public class MultitablaNegocio : IMultitablaNegocio
    {
        public List<ElementoVob> BuscarElementos(string idgrupo)
        {
            List<ElementoVob> lista = new List<ElementoVob>();
            var multiRepo = new MultitablaRepositorio();
            lista = multiRepo.ListarTablas(idgrupo);
            return lista;
        }

       
       

    }

   


}
