using System.Data.Entity;
using LayeredApp.Core.Model;

namespace LayeredApp.DataAccess
{
    public class SalesContext : DbContext
    {
        public SalesContext() : base("SalesDBConnection")
        {
        }

        public DbSet<SalesOrder> SalesOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SalesOrderConfiguration());

            //base.OnModelCreating(modelBuilder);
        }
    }
}
