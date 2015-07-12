using SalesApp.Web.Models;

namespace SalesApp.Web.Models.Customer
{
    public class GetCustomersRequest : ApiPagingRequest
    {
        // 篩選條件
        public string Name { get; set; }
        public string Country { get; set; }
    }
}