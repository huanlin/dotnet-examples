using System.Data.Entity;
using System.Threading.Tasks;
using ConsoleApp.DataAccess.Queries;
using ConsoleApp.Models;

namespace ConsoleApp
{
    public class Demo
    {
        private ICustomerQueries _customerQueries;

        public Demo(ICustomerQueries customerQueries)
        {
            _customerQueries = customerQueries;
        }

        public async Task<Customer[]> Run()
        {
            var query = _customerQueries.GetCustomersQuery();
            var customers = await query.ToArrayAsync();

            return customers;
        }
    }
}
