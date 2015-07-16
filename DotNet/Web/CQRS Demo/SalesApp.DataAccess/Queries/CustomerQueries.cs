using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LinqKit;
using PagedList;
using PagedList.EntityFramework;
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

        Task<Customer[]> ICustomerQueries.GetCustomersAsync()
        {
            return _salesContext.Customers.ToArrayAsync();
        }

        Task<Customer> ICustomerQueries.GetCustomerByIdAsync(int customerId)
        {
            return _salesContext.Customers.SingleOrDefaultAsync(c => c.Id == customerId);
        }       

        async Task<IPagedList<Customer>> ICustomerQueries.GetCustomersAsync(int page, int pageSize, string sortOrder, Expression<Func<Customer, bool>> filterExpr)
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
                default:
                    query = query.OrderBy(c => c.Name);
                    break;
            }

            if (page < 1)
            {
                page = 1;
            }

            var customers = await query.ToPagedListAsync(page, pageSize);
            return customers;
        }

        IQueryable<Customer> ICustomerQueries.GetCustomersQuery()
        {
            return _salesContext.Customers;
        }
    }
}
