using LayeredApp.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace LayeredApp.DataAccess.EntityTypeConfigurations
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
