using Sismuni.Dominio.Entidad.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.General
{
    public interface IMultitablaRepositorio
    {

        List<ElementoVob> ListarTablas(string idgrupo);
        ElementoVob ObtenerValor(string idmultitabla);
    }
}
