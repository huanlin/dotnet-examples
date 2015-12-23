using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ErrorPageDemo.Startup))]
namespace ErrorPageDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
