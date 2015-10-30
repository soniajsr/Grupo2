using Sismuni.Dominio.Entidad.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.Licencia.GestionDisponibilidadInspector
{
    public class RespuestaDisponibilidadInspectorVob
    {
        public List<DisponibilidadInspectorVob> listasodisponibilidad { get; set; }
        public List<ElementoVob> Rango_Horarios { get; set; }
        
        public int totalelementos { get; set; }
    }
}
