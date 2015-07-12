namespace SalesApp.Core.Interfaces
{
    public interface ICustomerService : ICustomerQueries, ICustomerCommands
    {
        // Define operations that neither query nor update the data store.
    }
}
