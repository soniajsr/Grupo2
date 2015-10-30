using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.Transparencia.GestionExpediente
{
    public class RespuestaBusquedaExpedientesVob
    {
        public List<ExpedienteVob> listaexpedientes { get; set; }
        public int totalelementos { get; set; }
    }
}
