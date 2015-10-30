using Sismuni.Dominio.Entidad.General;
using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.General
{
    public class MultitablaRepositorio : IMultitablaRepositorio
    {
        public MultitablaRepositorio()
        {

        }


        public List<ElementoVob> ListarTablas(string idgrupo)
        {
            using (var context = new UPC_MUNIEntities())
            {

                var consulta = from exp in context.Multitabla
                               where exp.IdGrupo == idgrupo
                               select new ElementoVob
                               {
                                   Valor = exp.IdMultitabla,
                                   Texto = exp.NombreValor
                               };

                return consulta.ToList();
            }
        }

        public ElementoVob ObtenerValor(string idmultitabla)
        {
            using (var context = new UPC_MUNIEntities())
            {

                var consulta = from exp in context.Multitabla
                               where exp.IdMultitabla == idmultitabla
                               select new ElementoVob
                               {
                                   Valor = exp.IdMultitabla,
                                   Texto = exp.NombreValor
                               };

                return consulta.FirstOrDefault();
            }

        }
    }
}
