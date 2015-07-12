using Demo02.CodeFirstSqlView.Models;
using Demo02.CodeFirstSqlView.Models.Mapping;
using Microsoft.Data.Entity;

namespace Demo02.CodeFirstSqlView
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

            // Force to run the database initializer.
            Database.Initialize(true);

            // Create a view!
            this.Database.ExecuteSqlCommand("CREATE VIEW [CustomerView] AS SELECT * FROM [Customer]");
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .Property(t => t.Id).Required()
                .Property(t => t.Name);

            //modelBuilder.Entity<CustomerView>)
            //    .
        }

    }
}
