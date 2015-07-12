using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LinqKit;
using PagedList;
using SalesApp.Core.Interfaces;
using SalesApp.Core.Models;

namespace SalesApp.DataAccess.Queries
{
    public class CustomerQueries : ICustomerQueries
    {
        private readonly SalesContext _salesContext;

        public CustomerQueries(SalesContext context)
        {
            _salesContext = context;
        }

        public Task<Customer[]> GetCustomersAsync()
        {
            return _salesContext.Customers.ToArrayAsync();
        }

        public Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return _salesContext.Customers.SingleOrDefaultAsync(c => c.Id == customerId);
        }

        public Task<IPagedList<Customer>> GetCustomersAsync(int page, int pageSize, string sortOrder, Expression<Func<Customer, bool>> filterExpr)
        {
            var query = (from c in _salesContext.Customers
                         select c)
                        .AsExpandable()     // 必須先呼叫此擴充方法（來自 LinqKit）。
                        .Where(filterExpr);

            // 加上排序
            sortOrder = sortOrder ?? string.Empty;
            switch (sortOrder.ToLower())
            {
                case "country":
                case "country asc":
                    query = query.OrderBy(c => c.Country);
                    break;
                case "country desc":
                    query = query.OrderByDescending(c => c.Country);
                    break;
                case "name desc":
                    query = query.OrderByDescending(c => c.Name);
                    break;
                case "name":
                case "name asc":
                default:
                    query = query.OrderBy(c => c.Name);
                    break;
            }

            if (page < 1)
            {
                page = 1;
            }

            var customers = query.ToPagedList(page, pageSize);
            return Task.FromResult(customers);
        }
    }
}
