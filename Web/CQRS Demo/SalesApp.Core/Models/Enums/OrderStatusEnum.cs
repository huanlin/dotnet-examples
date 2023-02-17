
namespace SalesApp.Core.Models
{
    public enum OrderStatusEnum
    {
        Created = 0,
        Packaging,
        Shipping,
        Received,
        Canceling,
        Canceled
    }
}
