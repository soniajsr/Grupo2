using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sismuni.Presentacion.Web.Helpers.Mvc
{
    public class ViewEnginePersonalizado : RazorViewEngine
    {
        public ViewEnginePersonalizado()
        {
            var viewLocations = new[] { 
            /** Controladores Vista**/
            "~/Views/General/{1}/{0}.cshtml",
            "~/Views/General/Error/{0}.cshtml",
            "~/Views/General/{0}.cshtml",                            


            /** Controladores Vista por módulo**/
            "~/Views/Transparencia/{1}/{0}.cshtml",                        
            "~/Views/TesoreriaFinanza/{1}/{0}.cshtml",
            "~/Views/ControlPatrimonial/{1}/{0}.cshtml",
            "~/Views/Licencia/{1}/{0}.cshtml", 

            };

            this.PartialViewLocationFormats = viewLocations;
            this.ViewLocationFormats = viewLocations;
        }
    }
}