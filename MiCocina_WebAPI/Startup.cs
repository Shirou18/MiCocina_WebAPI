using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiCocina_WebAPI.Startup))]
namespace MiCocina_WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
