using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Base
{
    public interface ICriterio<TEntidad> where TEntidad : class
    {
        Expression<Func<TEntidad, bool>> SatisfacePara();

        Expression<Func<TEntidad, bool>> SatisfacerParaOtro();

    }
}
