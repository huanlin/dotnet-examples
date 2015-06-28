using System.Data.Entity;
using System.Threading.Tasks;
using LayeredApp.Core.Interfaces.Queries;
using LayeredApp.Core.Models;

namespace LayeredApp.DataAccess.Queries
{
    public class CustomerQuery : ICustomerQuery
    {
        private readonly SalesContext _salesContext;

        public CustomerQuery(SalesContext context)
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
