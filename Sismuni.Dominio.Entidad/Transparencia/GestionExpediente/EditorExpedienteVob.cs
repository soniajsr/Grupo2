using Sismuni.Dominio.Entidad.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.Transparencia.GestionExpediente
{
    public class EditorExpedienteVob
    {
        public ExpedienteVob Expediente { get; set; }
        public List<ElementoVob> Tipo_Expedientes { get; set; }
         
    }
}
