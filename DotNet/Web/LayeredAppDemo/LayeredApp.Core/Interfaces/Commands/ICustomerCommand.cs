using System.Threading.Tasks;
using LayeredApp.Core.Models;

namespace LayeredApp.Core.Interfaces.Commands
{
    public interface ICustomerCommand
    {
        Task UpdateCustomer(Customer customer);
    }
}