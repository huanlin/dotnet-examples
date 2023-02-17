using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PagedList;
using SalesApp.Core.Models;

namespace SalesApp.Core.Interfaces
{
    public interface ICustomerQueries
    {
        // 傳回指定 ID 的客戶資料
        Task<Customer> GetCustomerByIdAsync(int customerId);

        // 不支援分頁、排序、篩選，由實作此介面的 Query 物件取得全部的客戶資料並直接轉成陣列。
        Task<Customer[]> GetCustomersAsync();   

        // 支援分頁、排序、篩選（呼叫端可用 PredicateBuilder 建立篩選表示式）
        Task<IPagedList<Customer>> GetCustomersAsync(int page, int pageSize, string sortOrder, Expression<Func<Customer, bool>> filterExpr);

        // 只傳回 IQueryable<T>，用意是讓 Query 物件只提供最陽春的 LINQ 查詢，
        // 而其餘的篩選、排序、分頁等處理全都由呼叫端來負責。此方法與 GetCustomersAsync 的主要差異即在於
        IQueryable<Customer> GetCustomersQuery();
    }
}