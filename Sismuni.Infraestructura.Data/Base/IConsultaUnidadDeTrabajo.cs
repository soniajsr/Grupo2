using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Base
{
    public interface IConsultaUnidadDeTrabajo : IUnidadDeTrabajo, IExecuteSql
    {
        //Devuelve entidad del contexto para que puede ser utilizada.
        DbSet<TEntidad> Set<TEntidad>() where TEntidad : class;

        //Devuelve entidad para establecer valores a las propiedaes.
        DbEntityEntry<TEntidad> Entry<TEntidad>(TEntidad entidad) where TEntidad : class;

    }
}
