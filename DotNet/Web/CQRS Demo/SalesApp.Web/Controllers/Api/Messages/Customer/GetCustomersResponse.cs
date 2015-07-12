
namespace SalesApp.Web.Controllers.Api.Messages.Customer
{
    public class GetCustomersResponse : ResponseMessageBase
    {
        public CustomerViewModel[] Customers { get; set; }
    }
}