using Demo01.CodeFirst.Models;
using Demo01.CodeFirst.Models.Mapping;
using System.Data.Entity;

namespace Demo01.CodeFirst
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
            Database.SetInitializer(new SalesDbInitializer());
            /*
             * Some initialization options:
             * 
            Database.SetInitializer<SalesContext>(null);
            Database.SetInitializer(new CreateDatabaseIfNotExists<SalesContext>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<SalesContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SalesContext>()); 
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SalesContext, MyConfiguration>()); 
             */
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            

            modelBuilder.Configurations.Add(new CustomerMap());
        }

    }
}
