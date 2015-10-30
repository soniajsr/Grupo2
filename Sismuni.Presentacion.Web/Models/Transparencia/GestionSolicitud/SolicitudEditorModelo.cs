using Sismuni.Dominio.Entidad.Transparencia.GestionSolicitud;
using Sismuni.Presentacion.Web.Models.General;
using System;
using System.Collections.Generic;
using Sismuni.Presentacion.Web.Helpers.Extensiones;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sismuni.Dominio.Entidad.General;

namespace Sismuni.Presentacion.Web.Models.Transparencia.GestionSolicitud
{
    public class SolicitudEditorModelo : MensajeModelo
    {
        public SolicitudVob Solicitud { get; set; }
        public BindingList<SelectListItem> TipoDocumento { get; set; }
        public BindingList<SelectListItem> ModoEnvio { get; set; }
        public BindingList<SelectListItem> TipoInformacion { get; set; }
        

        public SolicitudEditorModelo() { }

        public SolicitudEditorModelo(SolicitudVob _solicitud, 
                                     List<ElementoVob> _tipodocumento,
                                     List<ElementoVob> _modoenvio,
                                     List<ElementoVob> _tipoinformacion)
        {
            Solicitud = _solicitud;
            TipoDocumento = _tipodocumento.LlenarTT();
            ModoEnvio = _modoenvio.LlenarTT();
            TipoInformacion = _tipoinformacion.LlenarTT();
        }
    }
}