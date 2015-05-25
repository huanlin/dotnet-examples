using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5DI.Controllers
{
    public class CustomerController : Controller
    {
        private Services.ICustomerService _customerService;

        public CustomerController(Services.ICustomerService customerSvc)
        {
            _customerService = customerSvc;
        }

        public ActionResult Index()
        {
            return Content(_customerService.Hello());
        }

    }
}
