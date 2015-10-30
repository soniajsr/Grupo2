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
    
    public partial class Multitabla
    {
        public Multitabla()
        {
            this.Expediente = new HashSet<Expediente>();
            this.SolicitudInformacionMunicipal = new HashSet<SolicitudInformacionMunicipal>();
            this.SolicitudInformacionMunicipal1 = new HashSet<SolicitudInformacionMunicipal>();
            this.SolicitudInformacionMunicipal11 = new HashSet<SolicitudInformacionMunicipal>();
        }
    
        public string IdMultitabla { get; set; }
        public string IdGrupo { get; set; }
        public string NombreValor { get; set; }
        public string DescripcionLarga { get; set; }
        public Nullable<int> Estado { get; set; }
    
        public virtual GrupoTabla GrupoTabla { get; set; }
        public virtual ICollection<Expediente> Expediente { get; set; }
        public virtual ICollection<SolicitudInformacionMunicipal> SolicitudInformacionMunicipal { get; set; }
        public virtual ICollection<SolicitudInformacionMunicipal> SolicitudInformacionMunicipal1 { get; set; }
        public virtual ICollection<SolicitudInformacionMunicipal> SolicitudInformacionMunicipal11 { get; set; }
    }
}