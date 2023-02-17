using SalesApp.Web.Models;

namespace SalesApp.Web.Models.Customer
{
    public class GetCustomersResponse : ApiResponse
    {
        public CustomerViewModel[] Customers { get; set; }
    }
}