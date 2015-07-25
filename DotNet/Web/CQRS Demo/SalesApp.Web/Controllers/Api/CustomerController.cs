using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;
using LinqKit;
using PagedList.EntityFramework;
using SalesApp.Core.Interfaces;
using SalesApp.Core.Models;
using SalesApp.Core.Extensions;
using SalesApp.DataAccess;
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

        // 非公開方法，單純示範把全部的查詢處理都寫在 controller 動作方法中（分頁、篩選、排序實際上還是在 DB 端執行）。
        private async Task<GetCustomersResponse> GetCustomersV0([FromUri] GetCustomersRequest request)
        {
            SalesContext salesContext = new SalesContext();

            // 建立篩選條件
            var customersQuery = salesContext.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(request.Name));
            }
            if (!string.IsNullOrWhiteSpace(request.Country))
            {
                customersQuery = customersQuery.Where(c => c.Country.Equals(request.Country));
            }

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

            // 分頁（使用 PagedList.EntityFramework）
            var pagedResult = await customersQuery.ToPagedListAsync(request.Page, request.PageSize);

            // 轉換成 View Model
            var customerModels = pagedResult.Select(ConvertToCustomerViewModel);

            return new GetCustomersResponse
            {
                Succeeded = true,
                Customers = customerModels.ToArray()
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

        /// <summary>
        /// 示範：由 CustomerQueries 類別負責執行查詢。該查詢可支援分頁、排序、篩選。查詢返回的結果是指定頁次的資料序列。
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<GetCustomersResponse> GetCustomersV1([FromUri] GetCustomersRequest request)
        {
            // 建立篩選條件
            var filterExpr = CreateFilterExpression(request);

            // 取得分頁結果
            var customers = await _customerQueries.GetCustomersAsync(request.Page, request.PageSize, request.SortOrder, filterExpr);          

            // 轉換成 View Model
            var customerModels = customers.Select(ConvertToCustomerViewModel);

            return new GetCustomersResponse
            {
                Succeeded = true,
                Customers = customerModels.ToArray()
            };
        }

        /// <summary>
        /// 示範：
        ///   1. 使用 LinqKit 套件來建立篩選子句。
        ///   2. 篩選、排序、分頁等子句都是寫在這個 Controller 動作方法中（實際執行仍是在 DB 端）。
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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

        [HttpGet, Route("v3")]
        public async Task<GetCustomersResponse> GetCustomersV3([FromUri] GetCustomersRequest request)
        {
            var customersQuery = _customerQueries.GetCustomersQuery();
            
            // 建立篩選條件（使用 SalesApp.Core.Extensions.QueryableWhereExtension 裡面的擴充方法）
            customersQuery = customersQuery
                .Where(request.Name, c => c.Name.Contains(request.Name))
                .Where(request.Country, c => c.Country.Equals(request.Country));

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
