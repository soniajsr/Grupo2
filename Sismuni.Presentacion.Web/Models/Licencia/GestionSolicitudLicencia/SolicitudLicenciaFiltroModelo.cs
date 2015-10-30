using Sismuni.Dominio.Entidad.Licencia.GestionSolicitudInspeccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sismuni.Presentacion.Web.Models.Licencia.GestionSolicitudLicencia
{
    public class SolicitudLicenciaFiltroModelo
    {
        public SolicitudLicenciaVob SolicitudLicencia { get; set; }

        public SolicitudLicenciaFiltroModelo() { }

        public SolicitudLicenciaFiltroModelo(SolicitudLicenciaVob _solicitudlicencia)
        {
            SolicitudLicencia = _solicitudlicencia;
        }
    }
}