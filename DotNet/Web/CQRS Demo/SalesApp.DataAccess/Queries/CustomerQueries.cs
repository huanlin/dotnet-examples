using System.Data.Entity;
using System.Threading.Tasks;
using SalesApp.Core.Interfaces;
using SalesApp.Core.Models;

namespace SalesApp.DataAccess.Queries
{
    public class CustomerQueries : ICustomerQueries
    {
        private readonly SalesContext _salesContext;

        public CustomerQueries(SalesContext context)
        {
            _salesContext = context;
        }

        public Task<Customer[]> GetCustomersAsync()
        {
            return _salesContext.Customers.ToArrayAsync();
        }

        public Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return _salesContext.Customers.SingleOrDefaultAsync(c => c.Id == customerId);
        }
    }
}
