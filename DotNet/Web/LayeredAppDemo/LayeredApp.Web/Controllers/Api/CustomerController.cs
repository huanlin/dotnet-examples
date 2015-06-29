using System.Web.Http;
using System.Linq;
using System.Threading.Tasks;
using LayeredApp.Core.Interfaces.Commands;
using LayeredApp.Core.Interfaces.Queries;
using LayeredApp.Core.Models;
using LayeredApp.Web.Controllers.Api.Messages.Customer;
using WebGrease.Css.Extensions;

namespace LayeredApp.Web.Controllers.Api
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerCommand _customerCommand;
        private readonly ICustomerQuery _customerQuery;

        public CustomerController(ICustomerCommand customerCommand, ICustomerQuery customerQuery)
        {
            _customerCommand = customerCommand;
            _customerQuery = customerQuery;
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
            var customers = await _customerQuery.GetCustomersAsync();
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
