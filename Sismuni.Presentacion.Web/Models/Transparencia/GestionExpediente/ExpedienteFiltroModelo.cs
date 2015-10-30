using Sismuni.Dominio.Entidad.Transparencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sismuni.Presentacion.Web.Models.Transparencia.GestionExpediente
{
    public class ExpedienteFiltroModelo
    {
        public ExpedienteVob Expediente { get; set; }

        public ExpedienteFiltroModelo() { }

        public ExpedienteFiltroModelo(ExpedienteVob _expediente)
        {
            Expediente = _expediente;
        }
    }
}