using System.Collections.Generic;
using System.Threading.Tasks;
using LayeredApp.Core.Models;
using LayeredApp.DataAccess.Commands;
using LayeredApp.DataAccess.Queries;

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

        public Task<ICollection<Customer>> GetCustomersAsync()
        {
            return _customerQuery.GetCustomersAsync();
        }

        public Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return _customerQuery.GetCustomerByIdAsync(customerId);
        }
    }
}
