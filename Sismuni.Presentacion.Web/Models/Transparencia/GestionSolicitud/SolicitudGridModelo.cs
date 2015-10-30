using Sismuni.Dominio.Entidad.Transparencia.GestionSolicitud;
using Sismuni.Presentacion.Web.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sismuni.Presentacion.Web.Models.Transparencia.GestionSolicitud
{
    public class SolicitudGridModelo : GridModelo<SolicitudVob>
    {
        public SolicitudGridModelo() : base(new List<SolicitudVob>()) { }
        public SolicitudGridModelo(IEnumerable<SolicitudVob> lista, int tamanioPagina, int totalPagina) : base(lista, tamanioPagina, totalPagina) { }

    }
}