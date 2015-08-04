using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ArmorDemoWeb.Startup))]

namespace ArmorDemoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
