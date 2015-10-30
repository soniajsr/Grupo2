using Sismuni.Dominio.Entidad.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.Transparencia.GestionSolicitud
{
    public class EditorSolicitudVob
    {
        public SolicitudVob Solicitud { get; set; }
        public List<ElementoVob> Tipo_Documentos { get; set; }
        public List<ElementoVob> Modo_Envios { get; set; }
        public List<ElementoVob> Tipo_Informaciones { get; set; }
        

    }
}
