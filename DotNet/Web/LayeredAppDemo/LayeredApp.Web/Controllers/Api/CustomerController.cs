using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using LayeredApp.Core.Interfaces.Services;
using LayeredApp.Core.Models;
using LayeredApp.Web.Controllers.Api.Messages.Customer;

namespace LayeredApp.Web.Controllers.Api
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        private CustomerViewModel ConvertToCustomerViewModel(Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address
            };
        }


        [HttpGet]
        public async Task<GetCustomersResponse> GetCustomers()
        {
            var customers = await _customerService.GetCustomersAsync();
            return new GetCustomersResponse
            {
                Valid = true,
                Customers = (from c in customers
                             select new CustomerViewModel
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 Address = c.Address
                             }).ToArray()
            };
        }

    }
}
