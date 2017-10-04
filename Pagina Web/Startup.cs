using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pagina_Web.Startup))]
namespace Pagina_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
