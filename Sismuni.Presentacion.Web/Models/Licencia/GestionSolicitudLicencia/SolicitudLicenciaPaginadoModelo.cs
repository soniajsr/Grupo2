using Sismuni.Presentacion.Web.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sismuni.Presentacion.Web.Models.Licencia.GestionSolicitudLicencia
{
    public class SolicitudLicenciaPaginadoModelo : MensajeModelo
    {
        #region PROPIEDADES

        public SolicitudLicenciaFiltroModelo Filtro { get; set; }

        public SolicitudLicenciaGridModelo Grid { get; set; }

        #endregion

        #region CONSTRUCTOR

        public SolicitudLicenciaPaginadoModelo()
        {
            Filtro = new SolicitudLicenciaFiltroModelo();
        }

        #endregion

    }
}