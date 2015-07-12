using System.Threading.Tasks;
using SalesApp.Core.Interfaces;
using SalesApp.Core.Models;

namespace SalesApp.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerCommands _customerCommand;
        private readonly ICustomerQueries _customerQuery;


        public CustomerService(ICustomerCommands customerCommand, ICustomerQueries customerQuery)
        {
            _customerCommand = customerCommand;
            _customerQuery = customerQuery;
        }

        Task<Customer[]> ICustomerQueries.GetCustomersAsync()
        {
            return _customerQuery.GetCustomersAsync();
        }

        Task<Customer> ICustomerQueries.GetCustomerByIdAsync(int customerId)
        {
            return _customerQuery.GetCustomerByIdAsync(customerId);
        }

        Task ICustomerCommands.UpdateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
