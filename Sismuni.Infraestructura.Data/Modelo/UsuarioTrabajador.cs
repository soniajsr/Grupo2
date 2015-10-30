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
    
    public partial class UsuarioTrabajador
    {
        public UsuarioTrabajador()
        {
            this.SolicitudInformacionMunicipal = new HashSet<SolicitudInformacionMunicipal>();
        }
    
        public int IdUsuarioTrabajador { get; set; }
        public int IdArea { get; set; }
        public int IdCargo { get; set; }
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public int IdDocumento { get; set; }
        public string NroDocumento { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public Nullable<System.DateTime> FechaCese { get; set; }
        public string UsuRegistro { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public string UsuModifica { get; set; }
        public Nullable<System.DateTime> FechaModifica { get; set; }
    
        public virtual Estado Estado { get; set; }
        public virtual ICollection<SolicitudInformacionMunicipal> SolicitudInformacionMunicipal { get; set; }
        public virtual Area Area { get; set; }
        public virtual Cargo Cargo { get; set; }
    }
}
