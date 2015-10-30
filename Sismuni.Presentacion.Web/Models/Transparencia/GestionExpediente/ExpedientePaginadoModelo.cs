using Sismuni.Presentacion.Web.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sismuni.Presentacion.Web.Models.Transparencia.GestionExpediente
{
    public class ExpedientePaginadoModelo : MensajeModelo
    {
        #region PROPIEDADES

        public ExpedienteFiltroModelo Filtro { get; set; }

        public ExpedienteGridModelo Grid { get; set; }

        #endregion

        #region CONSTRUCTOR

        public ExpedientePaginadoModelo()
        {
            Filtro = new ExpedienteFiltroModelo();
        }

        #endregion

    }
}