using Mvc5DI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc5DI.Infrastructure
{
    public class MyResolver : System.Web.Mvc.IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(CustomerController))
            {
                var customerSvc = new Services.CustomerService();
                var controller = new Controllers.CustomerController(customerSvc);
                return controller;
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }
    }
}