using System.Web.Http;

namespace OwinSelfHostingInConsoleApp
{
    public class GreetingController : ApiController
    {
        public Greeting Get()
        {
            return new Greeting { Text = "Hello Web API!" };
        }
    }
}
