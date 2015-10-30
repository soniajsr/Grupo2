using Sismuni.Dominio.Entidad.General;
using Sismuni.Dominio.Entidad.Transparencia;
using Sismuni.Presentacion.Web.Models.General;
using System;
using System.Collections.Generic;
using Sismuni.Presentacion.Web.Helpers.Extensiones;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sismuni.Presentacion.Web.Models.Transparencia.GestionExpediente
{
    public class ExpedienteEditorModelo : MensajeModelo
    {
        public ExpedienteVob Expediente { get; set; }
        public BindingList<SelectListItem> TipoExpediente { get; set; }
       

        public ExpedienteEditorModelo() { }

        public ExpedienteEditorModelo(ExpedienteVob _expediente, List<ElementoVob> _tipoexpediente)
        {
            Expediente = _expediente;
            TipoExpediente = _tipoexpediente.LlenarTT();
        }
    }
}