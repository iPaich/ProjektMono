using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project.Service.Startup))]
namespace Project.Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
