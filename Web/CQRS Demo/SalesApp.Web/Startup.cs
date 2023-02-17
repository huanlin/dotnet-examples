using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SalesApp.Web.Startup))]

namespace SalesApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
