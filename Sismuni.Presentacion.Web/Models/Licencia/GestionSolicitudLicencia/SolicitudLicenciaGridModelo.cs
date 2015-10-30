using Sismuni.Dominio.Entidad.Licencia.GestionSolicitudInspeccion;
using Sismuni.Presentacion.Web.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sismuni.Presentacion.Web.Models.Licencia.GestionSolicitudLicencia
{
    public class SolicitudLicenciaGridModelo : GridModelo<SolicitudLicenciaVob>
    {
        public SolicitudLicenciaGridModelo() : base(new List<SolicitudLicenciaVob>()) { }
        public SolicitudLicenciaGridModelo(IEnumerable<SolicitudLicenciaVob> lista, int tamanioPagina, int totalPagina) : base(lista, tamanioPagina, totalPagina) { }

    }
}