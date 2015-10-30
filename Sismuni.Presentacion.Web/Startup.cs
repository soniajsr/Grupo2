using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sismuni.Presentacion.Web.Startup))]
namespace Sismuni.Presentacion.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
