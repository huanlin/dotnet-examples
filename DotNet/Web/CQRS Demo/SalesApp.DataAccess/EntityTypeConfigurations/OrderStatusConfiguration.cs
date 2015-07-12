using SalesApp.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace SalesApp.DataAccess.EntityTypeConfigurations
{
    public class OrderStatusConfiguration : EntityTypeConfiguration<OrderStatus>
    {
        public OrderStatusConfiguration()
        {
            Property(t => t.Id).IsRequired();
            Property(t => t.Name).HasMaxLength(30);
        }
    }
}
