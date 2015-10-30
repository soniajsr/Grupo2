using Sismuni.Presentacion.Web.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sismuni.Presentacion.Web.Models.Transparencia.GestionSolicitud
{
    public class SolicitudPaginadoModelo : MensajeModelo
    {
        #region PROPIEDADES

        public SolicitudFiltroModelo Filtro { get; set; }

        public SolicitudGridModelo Grid { get; set; }

        #endregion

        #region CONSTRUCTOR

        public SolicitudPaginadoModelo()
        {
            Filtro = new SolicitudFiltroModelo();
        }

        #endregion
    }
}