using System.Threading.Tasks;
using LayeredApp.Core.Interfaces.Commands;
using LayeredApp.Core.Interfaces.Queries;
using LayeredApp.Core.Models;

namespace LayeredApp.Application.Services
{
    public class CustomerService
    {
        private readonly ICustomerCommand _customerCommand;
        private readonly ICustomerQuery _customerQuery;


        public CustomerService(ICustomerCommand customerCommand, ICustomerQuery customerQuery)
        {
            _customerCommand = customerCommand;
            _customerQuery = customerQuery;
        }

        public Task<Customer[]> GetCustomersAsync()
        {
            return _customerQuery.GetCustomersAsync();
        }

        public Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return _customerQuery.GetCustomerByIdAsync(customerId);
        }
    }
}
