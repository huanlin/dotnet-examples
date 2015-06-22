using System.Data.Entity.ModelConfiguration;
using LayeredApp.Core.Model;

namespace LayeredApp.DataAccess
{
    public class SalesOrderConfiguration : EntityTypeConfiguration<SalesOrder>
    {
        public SalesOrderConfiguration()
        {
            Property(t => t.CustomerName).HasMaxLength(30).IsRequired();
            Property(t => t.PONumber).HasMaxLength(10).IsOptional();
        }
    }
}
