using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using SalesApp.Core.Interfaces;
using SalesApp.Core.Models;
using SalesApp.Web.Controllers.Api.Messages.Customer;

namespace SalesApp.Web.Controllers.Api
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerCommands _customerCommands;
        private readonly ICustomerQueries _customerQueries;

        public CustomerController(ICustomerCommands customerCommands, ICustomerQueries customerQueries)
        {
            _customerCommands = customerCommands;
            _customerQueries = customerQueries;
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
            var customers = await _customerQueries.GetCustomersAsync();

            var customerModels = customers.Select(c => ConvertToCustomerViewModel(c));
            return new GetCustomersResponse
            {
                Valid = true,
                Customers = customerModels.ToArray()
            };
        }

    }
}
