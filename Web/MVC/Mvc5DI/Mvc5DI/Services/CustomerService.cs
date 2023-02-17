using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc5DI.Services
{
    public class CustomerService : ICustomerService
    {
        public string Hello()
        {
            return "Hello";
        }
    }
}