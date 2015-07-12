using System.Threading.Tasks;
using SalesApp.Core.Models;

namespace SalesApp.Core.Interfaces
{
    public interface ICustomerCommands
    {
        Task UpdateCustomer(Customer customer);
    }
}