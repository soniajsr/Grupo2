using Sismuni.Dominio.Entidad.Transparencia.GestionSolicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sismuni.Presentacion.Web.Models.Transparencia.GestionSolicitud
{
    public class SolicitudFiltroModelo
    {
        public SolicitudVob Solicitud { get; set; }

        public SolicitudFiltroModelo() { }

        public SolicitudFiltroModelo(SolicitudVob _solicitud)
        {
            Solicitud = _solicitud;
        }
    }
}