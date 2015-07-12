using System.Data.Entity;
using System.Threading.Tasks;
using SalesApp.Core.Models;
using SalesApp.Core.Interfaces;

namespace SalesApp.DataAccess.Commands
{
    public class CustomerCommand : ICustomerCommands
    {
        private readonly SalesContext _salesContext;

        public CustomerCommand(SalesContext context)
        {
            _salesContext = context;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            _salesContext.Entry(customer).State = EntityState.Modified;
            _salesContext.SaveChanges();
        }
    }
}
