
using LayeredApp.Core.Interfaces.Commands;
using LayeredApp.Core.Interfaces.Queries;

namespace LayeredApp.Core.Interfaces.Services
{
    public interface ICustomerService : ICustomerQuery, ICustomerCommand
    {
        // Define operations that neither query nor update the data store.
    }
}
