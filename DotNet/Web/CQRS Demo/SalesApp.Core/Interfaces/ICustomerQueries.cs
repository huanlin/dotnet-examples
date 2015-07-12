using System.Threading.Tasks;
using SalesApp.Core.Models;

namespace SalesApp.Core.Interfaces
{
    public interface ICustomerQueries
    {
        Task<Customer[]> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
    }
}