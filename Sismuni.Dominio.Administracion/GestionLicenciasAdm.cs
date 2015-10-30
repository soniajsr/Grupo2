using Sismuni.Dominio.Negocio.Licencia.GestionSolicitudLicencia;
using Sismuni.Transversal.Injeccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Administracion
{
    public class GestionLicenciasAdm
    {
        private static GestionLicenciasAdm _licencias = null;

        public ILISolicitudLicenciaNegocio SolicitudLicenciaNegocio { get { return Dependencia.Resolve<ILISolicitudLicenciaNegocio>(); } }


        private GestionLicenciasAdm() { }

        public static GestionLicenciasAdm ObtenerServicio()
        {
            if (_licencias == null)
                _licencias = new GestionLicenciasAdm();
            return _licencias;
        }
    }
}
