using Sismuni.Presentacion.Web.Helpers.Mvc;
using System.Web;
using System.Web.Mvc;

namespace Sismuni.Presentacion.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           // filters.Add(new AuthorizeAttribute());
            filters.Add(new HandleAntiforgeryTokenErrorAttribute());
        }
    }
}
