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
    
    public partial class NO_SolicitudInformacionArea
    {
        public int idSolicitudInformacion { get; set; }
        public int ID_Tramite { get; set; }
        public int ID_Empleado { get; set; }
        public Nullable<System.DateTime> FechaSolicitud { get; set; }
        public string Observacio { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
    
        public virtual NO_Expediente_Elim NO_Expediente_Elim { get; set; }
    }
}