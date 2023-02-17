using System.Linq;
using ConsoleApp.Models;

namespace ConsoleApp.DataAccess.Queries
{
    public interface ICustomerQueries 
    {
        IQueryable<Customer> GetCustomersQuery();
    }
}
