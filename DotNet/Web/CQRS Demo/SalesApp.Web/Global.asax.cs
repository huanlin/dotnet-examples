using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using SalesApp.Application.Services;
using SalesApp.Core.Interfaces;
using SalesApp.DataAccess;
using SalesApp.DataAccess.Commands;
using SalesApp.DataAccess.Queries;

namespace SalesApp.Web
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

            // 註冊你的 commands 和 quieries
            builder.RegisterType<CustomerCommands>().As<ICustomerCommands>();
            builder.RegisterType<CustomerQueries>().As<ICustomerQueries>();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;
        }
    }
}
