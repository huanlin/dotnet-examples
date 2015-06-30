using System.Threading.Tasks;
using LayeredApp.Core.Interfaces.Commands;
using LayeredApp.Core.Interfaces.Queries;
using LayeredApp.Core.Interfaces.Services;
using LayeredApp.Core.Models;

namespace LayeredApp.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerCommand _customerCommand;
        private readonly ICustomerQuery _customerQuery;


        public CustomerService(ICustomerCommand customerCommand, ICustomerQuery customerQuery)
        {
            _customerCommand = customerCommand;
            _customerQuery = customerQuery;
        }

        Task<Customer[]> ICustomerQuery.GetCustomersAsync()
        {
            return _customerQuery.GetCustomersAsync();
        }

        Task<Customer> ICustomerQuery.GetCustomerByIdAsync(int customerId)
        {
            return _customerQuery.GetCustomerByIdAsync(customerId);
        }

        Task ICustomerCommand.UpdateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
