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
    
    public partial class LI_disponibilidadinspector
    {
        public LI_disponibilidadinspector()
        {
            this.LI_inspeccion = new HashSet<LI_inspeccion>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> fechaHoraInicio { get; set; }
        public Nullable<System.DateTime> fechaHoraFin { get; set; }
        public string estado { get; set; }
        public int idInspector { get; set; }
    
        public virtual ICollection<LI_inspeccion> LI_inspeccion { get; set; }
    }
}