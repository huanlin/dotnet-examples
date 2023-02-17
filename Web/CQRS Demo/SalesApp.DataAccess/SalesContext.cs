using SalesApp.Core.Models;
using SalesApp.DataAccess.EntityTypeConfigurations;
using System.Data.Entity;

namespace SalesApp.DataAccess
{
    public class SalesContext : DbContext
    {
        public SalesContext() : base("SalesDBConnection")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderItemConfiguration());            
        }
    }
}
