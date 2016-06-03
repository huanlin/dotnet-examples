using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;

namespace ConsoleApplication1
{
    // Ref: http://codeopinion.com/how-to-create-owin-middleware/
    class Program
    {
        static void Main(string[] args)
        {
            var uri = "http://localhost:8080";
            using (WebApp.Start<Startup>(uri))
            {
                System.Console.WriteLine("Started");
                Console.ReadKey();
                Console.WriteLine("Stopping");
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureWebApi(app);

            app.Use<Middleware1>();
            app.Use<Middleware2>();           
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            app.UseWebApi(config);
        }
    }


    public class Middleware1 : OwinMiddleware
    {

        public Middleware1(OwinMiddleware next) : base(next)
        {
        }


        public async override Task Invoke(IOwinContext context)
        {
            string msg = "Middleware1.Invoke(), Request Path: " + context.Request.Path + "\r\n";
            Console.WriteLine(msg);

            await context.Response.WriteAsync(msg);

            await Next.Invoke(context);

            await context.Response.WriteAsync("Response Status code: " + context.Response.StatusCode);
        }
    }

    public class Middleware2 : OwinMiddleware
    {
        public Middleware2(OwinMiddleware next) : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            string msg = "Middleware2.Invoke(), Request Path: " + context.Request.Path + "\r\n";

            Console.WriteLine(msg);

            await context.Response.WriteAsync(msg);

            await Next.Invoke(context);          
        }
    }
}
