using System.Data.Entity;
using Console.Models;
using ConsoleApp.Models;

namespace ConsoleApp.DataAccess
{
    public class SalesContext : DbContext
    {
        public SalesContext() : base("SalesDBConnection")
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
        }
    }
}
