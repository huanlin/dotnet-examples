using System.Threading.Tasks;
using LayeredApp.Core.Models;

namespace LayeredApp.Core.Interfaces.Queries
{
    public interface ICustomerQuery
    {
        Task<Customer[]> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
    }
}