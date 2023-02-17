using SalesApp.Core.Interfaces;
using SalesApp.Core.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SalesApp.DataAccess.Commands
{
    public class CustomerCommands : ICustomerCommands
    {
        private readonly SalesContext _salesContext;

        public CustomerCommands(SalesContext context)
        {
            _salesContext = context;
        }

        async Task ICustomerCommands.UpdateCustomerAsync(Customer customer)
        {
            _salesContext.Entry(customer).State = EntityState.Modified;
            await _salesContext.SaveChangesAsync();
        }
    }
}
