using System.Collections.Generic;
using System.Data.Entity;
using ConsoleApp.Models;

namespace ConsoleApp.DataAccess
{
    public class SalesDbInitializer : DropCreateDatabaseAlways<SalesContext>
    {
        private SalesContext _salesContext;

        protected override void Seed(SalesContext context)
        {
            _salesContext = context;

            var customers = GenerateCustomers();

            base.Seed(context);
        }

        private IList<Customer> GenerateCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { Name = "Michael", Country = "ROC", Address = "台北市中山區大馬路 132 號" },
                new Customer { Name = "Jack", Country = "ROC", Address = "新北市樹林區黑暗巷 1 號" },
                new Customer { Name = "Judy", Country = "USA" , Address = "test address 1" },
                new Customer { Name = "Vivid", Country = "JPN", Address = "test address 2" },
                new Customer { Name = "John", Country = "KOR", Address = "test address 3" },
                new Customer { Name = "Brian", Country = "CHN", Address = "test address 4" },
                new Customer { Name = "Maria", Country = "CAN", Address = "test address 5" },
            };

            _salesContext.Customers.AddRange(customers);
            _salesContext.SaveChanges();
            return customers;
        }
    }
}
