using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.Transparencia.GestionSolicitud
{
    public class SolicitudVob
    {
        public long NumeroSolicitud { get; set; }
        public Nullable<System.DateTime> FechaSolicitud { get; set; }
        public string NombresSolicitante { get; set; }
        public string ApellidoPaternoSolicitante { get; set; }
        public string ApellidoMaternoSolicitante { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public Nullable<long> Codigo_Solicitud { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public string Nombres_Completos_Solicitante { get; set; }
        public string Nombre_Tipo_Documento { get; set; }
        public string Nombre_Estado { get; set;  }
        public string Estado_Solicitud { get; set; }
        public string Modo_Envio { get; set; }
        public string Nombres_Responsable { get; set; }
        public string Tipo_Informacion { get; set; }
        public string Observaciones { get; set; }
    }
}
