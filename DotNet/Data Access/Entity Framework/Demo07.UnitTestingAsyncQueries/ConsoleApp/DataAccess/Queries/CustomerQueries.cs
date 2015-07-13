using System.Linq;
using ConsoleApp.Models;

namespace ConsoleApp.DataAccess.Queries
{
    public class CustomerQueries : ICustomerQueries
    {
        private readonly SalesContext _salesContext;

        public CustomerQueries(SalesContext context)
        {
            _salesContext = context;
        }

        public IQueryable<Customer> GetCustomersQuery()
        {
            return _salesContext.Customers;
        }
    }
}
