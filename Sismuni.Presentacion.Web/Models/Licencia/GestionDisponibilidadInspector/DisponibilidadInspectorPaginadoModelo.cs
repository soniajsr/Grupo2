using Sismuni.Presentacion.Web.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sismuni.Presentacion.Web.Models.Licencia.GestionDisponibilidadInspector
{
    public class DisponibilidadInspectorPaginadoModelo : MensajeModelo
    {
        #region PROPIEDADES

        public DisponibilidadInspectorFiltroModelo Filtro { get; set; }

        public DisponibilidadInspectorGridModelo Grid { get; set; }

        #endregion

        #region CONSTRUCTOR

        public DisponibilidadInspectorPaginadoModelo()
        {
            Filtro = new DisponibilidadInspectorFiltroModelo();
        }

        #endregion
    }
}