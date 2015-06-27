using System.Collections.Generic;
using System.Threading.Tasks;
using LayeredApp.Core.Models;

namespace LayeredApp.DataAccess.Queries
{
    public interface ICustomerQuery
    {
        Task<ICollection<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
    }
}