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
    
    public partial class PV_Requerimiento
    {
        public int ID_Requerimiento { get; set; }
        public string Observacion { get; set; }
        public System.DateTime FechaRequerimiento { get; set; }
        public int ID_Iniciativa_Vecinal { get; set; }
        public int ID_Area { get; set; }
        public int ID_Empleado { get; set; }
    }
}