using SalesApp.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace SalesApp.DataAccess.EntityTypeConfigurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            Property(t => t.Id).IsRequired();
            Property(t => t.CustomerId).IsRequired();
            Property(t => t.ReceiverName).HasMaxLength(60).IsRequired();
            Property(t => t.ReceiverAddress).HasMaxLength(200).IsRequired();
        }
    }
}
