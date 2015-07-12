using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PagedList;
using SalesApp.Core.Models;

namespace SalesApp.Core.Interfaces
{
    public interface ICustomerQueries
    {
        // 不支援分頁、排序、篩選
        Task<Customer[]> GetCustomersAsync();   

        // 支援分頁、排序、篩選（呼叫端可用 PredicateBuilder 建立篩選表示式）
        Task<IPagedList<Customer>> GetCustomersAsync(int page, int pageSize, string sortOrder, Expression<Func<Customer, bool>> filterExpr);

        Task<Customer> GetCustomerByIdAsync(int customerId);
    }
}