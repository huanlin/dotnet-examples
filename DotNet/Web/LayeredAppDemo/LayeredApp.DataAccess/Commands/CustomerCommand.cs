
using System.Data.Entity;
using System.Threading.Tasks;
using LayeredApp.Core.Models;

namespace LayeredApp.DataAccess.Commands
{
    public class CustomerCommand : ICustomerCommand
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
