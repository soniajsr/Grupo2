using Sismuni.Dominio.Entidad.Transparencia;
using Sismuni.Presentacion.Web.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sismuni.Presentacion.Web.Models.Transparencia.GestionExpediente
{
    public class ExpedienteGridModelo : GridModelo<ExpedienteVob>
    {
        public ExpedienteGridModelo() : base(new List<ExpedienteVob>()) { }
        public ExpedienteGridModelo(IEnumerable<ExpedienteVob> lista, int tamanioPagina, int totalPagina) : base(lista, tamanioPagina, totalPagina) { }

    }
}