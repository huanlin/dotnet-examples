using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LayeredApp.Web.Startup))]

namespace LayeredApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);            
        }
    }
}
