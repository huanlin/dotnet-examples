using Microsoft.Data.Entity;
using Demo02.CodeFirstSqlView.Models;

namespace Demo02.CodeFirstSqlView
{
    public class SalesDbInitializer : DropCreateDatabaseAlways<SalesContext>
    {
        public override void InitializeDatabase(SalesContext context)
        {
            base.InitializeDatabase(context);
        }

        protected override void Seed(SalesContext context)
        {
            CreateCustomerData(context);
        }

        private void CreateCustomerData(SalesContext context)
        {
            context.Customers.Add(new Customer { Id = 1, Name = "Jack" });
            context.Customers.Add(new Customer { Id = 2, Name = "Michael" });

            context.SaveChanges();
        }
    }
}
