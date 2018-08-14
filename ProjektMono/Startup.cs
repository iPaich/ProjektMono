using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjektMono.Startup))]
namespace ProjektMono
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
