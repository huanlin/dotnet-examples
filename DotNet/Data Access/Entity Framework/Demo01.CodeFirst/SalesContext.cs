using System.Data.Entity;
using Demo01.CodeFirst.Models;

namespace Demo01.CodeFirst
{
    public class SalesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

    }
}
