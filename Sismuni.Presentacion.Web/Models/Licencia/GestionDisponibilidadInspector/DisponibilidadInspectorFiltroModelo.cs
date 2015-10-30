using Sismuni.Dominio.Entidad.General;
using Sismuni.Dominio.Entidad.Licencia.GestionDisponibilidadInspector;
using System;
using System.Collections.Generic;
using Sismuni.Presentacion.Web.Helpers.Extensiones;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sismuni.Presentacion.Web.Models.Licencia.GestionDisponibilidadInspector
{
    public class DisponibilidadInspectorFiltroModelo
    {
        public DisponibilidadInspectorVob DisponibilidadInspector { get; set; }
        public BindingList<SelectListItem> RangoHorario { get; set; }
        

        public DisponibilidadInspectorFiltroModelo() { }

        public DisponibilidadInspectorFiltroModelo(DisponibilidadInspectorVob _disponibilidadinspector,
                                                   IEnumerable<ElementoVob> _RangoHorario)
        {
            DisponibilidadInspector = _disponibilidadinspector;
            RangoHorario = _RangoHorario.LlenarTT();
        }
    }
}