using System.Data.Entity;
using System.Threading.Tasks;
using SalesApp.Core.Models;
using SalesApp.Core.Interfaces;

namespace SalesApp.DataAccess.Commands
{
    public class CustomerCommands : ICustomerCommands
    {
        private readonly SalesContext _salesContext;

        public CustomerCommands(SalesContext context)
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
