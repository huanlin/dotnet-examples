using System.Threading.Tasks;
using LayeredApp.Core.Models;

namespace LayeredApp.DataAccess.Commands
{
    public interface ICustomerCommand
    {
        Task UpdateCustomer(Customer customer);
    }
}