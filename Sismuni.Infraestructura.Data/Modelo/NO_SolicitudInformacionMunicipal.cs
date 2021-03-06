//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sismuni.Infraestructura.Data.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class NO_SolicitudInformacionMunicipal
    {
        public NO_SolicitudInformacionMunicipal()
        {
            this.NO_Expediente_Elim = new HashSet<NO_Expediente_Elim>();
            this.NO_InformacionMunicipal = new HashSet<NO_InformacionMunicipal>();
            this.NO_InformeMunicipal = new HashSet<NO_InformeMunicipal>();
        }
    
        public int idNumeroSolicitud { get; set; }
        public Nullable<System.DateTime> FechaSolicitud { get; set; }
        public string NombresSolicitante { get; set; }
        public string ApellidoPaternoSolicitante { get; set; }
        public string ApellidoMaternoSolicitante { get; set; }
        public string NumeroDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Modo_Envio { get; set; }
        public string Tipo_Informacion { get; set; }
        public string Motivo_Solicitud { get; set; }
        public string Observaciones { get; set; }
    
        public virtual ICollection<NO_Expediente_Elim> NO_Expediente_Elim { get; set; }
        public virtual ICollection<NO_InformacionMunicipal> NO_InformacionMunicipal { get; set; }
        public virtual ICollection<NO_InformeMunicipal> NO_InformeMunicipal { get; set; }
    }
}
