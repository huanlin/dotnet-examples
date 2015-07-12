using OneToManyWithDefaultChild.Models;
using System.Data.Entity;

namespace Demo01.CodeFirst
{
    public class SalesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        //public SalesContext()
        //    : base("SalesDB")
        //{

        //}
    }
}
