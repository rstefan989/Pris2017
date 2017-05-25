using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PRISSafari.Startup))]
namespace PRISSafari
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
