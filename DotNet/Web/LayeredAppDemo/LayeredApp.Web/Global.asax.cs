using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using LayeredApp.Application.Services;
using LayeredApp.Core.Interfaces.Commands;
using LayeredApp.Core.Interfaces.Queries;
using LayeredApp.Core.Interfaces.Services;
using LayeredApp.DataAccess;
using LayeredApp.DataAccess.Commands;
using LayeredApp.DataAccess.Queries;

namespace LayeredApp.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize the database.
            Database.SetInitializer(new SalesDbInitializer());
            using (var context = new SalesContext())
            {
                context.Database.Initialize(force: true);
            }


            // Configuring Autofac
            var config = GlobalConfiguration.Configuration;

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());    // Registering all API controllers.
            builder.RegisterType<SalesContext>().As<SalesContext>();            // Don't forget to register our DbContext class!

            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<CustomerCommand>().As<ICustomerCommand>();
            builder.RegisterType<CustomerQuery>().As<ICustomerQuery>();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;
        }
    }
}
