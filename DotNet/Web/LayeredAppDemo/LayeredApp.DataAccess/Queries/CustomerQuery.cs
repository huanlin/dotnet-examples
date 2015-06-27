using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
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

        public async Task<ICollection<Customer>> GetCustomersAsync()
        {
            return await _salesContext.Customers.ToListAsync();
        }

        public Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return _salesContext.Customers.SingleOrDefaultAsync(c => c.Id == customerId);
        }
    }
}
