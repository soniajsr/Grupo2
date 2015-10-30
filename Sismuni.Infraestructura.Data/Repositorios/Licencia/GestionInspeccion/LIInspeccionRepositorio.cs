using Sismuni.Infraestructura.Data.Base;
using Sismuni.Infraestructura.Data.Modelo;
using Sismuni.Infraestructura.Data.Repositorios.Licencia.GestionDisponibilidadInspector;
using Sismuni.Infraestructura.Data.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.Licencia.GestionInspeccion
{
    public class LIInspeccionRepositorio : Repositorio<LI_inspeccion>, ILIInspeccionRepositorio
    {
        public LIInspeccionRepositorio(IModeloUnidadDeTrabajo unidaDeTrabajo) : base(unidaDeTrabajo) { }


    }
}
