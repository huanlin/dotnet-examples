using System.Threading.Tasks;
using SalesApp.Core.Interfaces;
using SalesApp.Core.Models;

namespace SalesApp.Application.Services
{
    /// <summary>
    /// 由於 ICustomerCommands 和 ICustomerQueries 所定義的操作已經能夠滿足此範例的需要，所以這個類別目前沒有任何用處，只是為將來而預留（也有可能是多慮了）。
    /// 你可以從 CustomerController 的 ctor 發現，注入的物件是 ICustomerCommands 和 ICustomerQueries，並非 ICustomerService。
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerCommands _customerCommand;
        private readonly ICustomerQueries _customerQuery;

        public CustomerService(ICustomerCommands customerCommand, ICustomerQueries customerQuery)
        {
            _customerCommand = customerCommand;
            _customerQuery = customerQuery;
        }
    }
}
