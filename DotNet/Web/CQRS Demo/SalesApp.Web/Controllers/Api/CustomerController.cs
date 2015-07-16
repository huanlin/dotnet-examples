using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;
using LinqKit;
using PagedList.EntityFramework;
using SalesApp.Core.Interfaces;
using SalesApp.Core.Models;
using SalesApp.Web.Models.Customer;

namespace SalesApp.Web.Controllers.Api
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerCommands _customerCommands;
        private readonly ICustomerQueries _customerQueries;

        public CustomerController(ICustomerCommands customerCommands, ICustomerQueries customerQueries)
        {
            _customerCommands = customerCommands;
            _customerQueries = customerQueries;
        }

        private CustomerViewModel ConvertToCustomerViewModel(Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Country = customer.Country,
                Address = customer.Address
            };
        }

        private Expression<Func<Customer, bool>> CreateFilterExpression(GetCustomersRequest request)
        {
            var expr = PredicateBuilder.True<Customer>();

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                expr = expr.And(c => c.Name.Contains(request.Name));
            }
            if (!string.IsNullOrWhiteSpace(request.Country))
            {
                expr = expr.And(c => c.Country.Equals(request.Country));
            }
            return expr;
        }

        [HttpGet]
        public async Task<GetCustomersResponse> GetCustomers([FromUri] GetCustomersRequest request)
        {
            // 建立篩選條件
            var filterExpr = CreateFilterExpression(request);

            // 取得分頁結果
            var customers = await _customerQueries.GetCustomersAsync(request.Page, request.PageSize, request.SortOrder, filterExpr);          

            // 轉換成 View Model
            var customerModels = customers.Select(c => ConvertToCustomerViewModel(c));

            return new GetCustomersResponse
            {
                Succeeded = true,
                Customers = customerModels.ToArray()
            };
        }

        [HttpGet, Route("v2")]
        public async Task<GetCustomersResponse> GetCustomersV2([FromUri] GetCustomersRequest request)
        {
            var customersQuery = _customerQueries.GetCustomersQuery();

            // 建立篩選條件
            var filterExpr = CreateFilterExpression(request);

            customersQuery = customersQuery
                .AsExpandable()     // 必須先呼叫此擴充方法（來自 LinqKit）。
                .Where(filterExpr);

            // 排序
            switch (request.SortOrder.ToLower())
            {
                case "country":
                case "country asc":
                    customersQuery = customersQuery.OrderBy(c => c.Country);
                    break;
                case "country desc":
                    customersQuery = customersQuery.OrderByDescending(c => c.Country);
                    break;
                case "name desc":
                    customersQuery = customersQuery.OrderByDescending(c => c.Name);
                    break;
                default:
                    customersQuery = customersQuery.OrderBy(c => c.Name);
                    break;
            }

            // 分頁
            var pagedResult = await customersQuery.ToPagedListAsync(request.Page, request.PageSize);

            // 轉換成 View Model
            var customerModels = pagedResult.Select(ConvertToCustomerViewModel);

            return new GetCustomersResponse
            {
                Succeeded = true,
                Customers = customerModels.ToArray()
            };
        }

    }
}
