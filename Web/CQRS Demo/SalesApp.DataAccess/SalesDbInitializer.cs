using SalesApp.Core.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SalesApp.DataAccess
{
    public class SalesDbInitializer : DropCreateDatabaseAlways<SalesContext>
    {
        private SalesContext _salesContext;

        protected override void Seed(SalesContext context)
        {
            _salesContext = context;

            var customers = GenerateCustomers();
            var products = GenerateProducts();
            GenerateOrders(customers, products);

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

        private IList<Product> GenerateProducts()
        {
            var products = new List<Product>
            {
                new Product { Name = "Learning C#", Description = "Learning C# by Michael Tsai", CategoryId = ProductCategoryEnum.Books, UnitPrice = 300 },
                new Product { Name = "Heros", Description = "Heros by Alesso", CategoryId = ProductCategoryEnum.Music, UnitPrice = 350 },
                new Product { Name = "ASUS ZENBOOK", Description = "ASUS ZENBOOK 305", CategoryId = ProductCategoryEnum.Hardware, UnitPrice = 60000 },
                new Product { Name = "Office 2016", Description = "Office 2016", CategoryId = ProductCategoryEnum.Software, UnitPrice = 5000 }
            };
            _salesContext.Products.AddRange(products);
            _salesContext.SaveChanges();
            return products;
        }

        private void GenerateOrders(IList<Customer> customers,  IList<Product> products)
        {
            var orders = new List<Order>
            {
                new Order { CustomerId = customers[0].Id, ReceiverName = "John", ReceiverAddress = "高雄市", StatusId = OrderStatusEnum.Created},
                new Order { CustomerId = customers[1].Id, ReceiverName = "Smith", ReceiverAddress = "新竹市", StatusId = OrderStatusEnum.Packaging}
            };

            orders[0].OrderItems = new List<OrderItem>
            {
                new OrderItem { OrderId = 0, ProductId = products[0].Id, Quantity = 2, UnitPrice = products[0].UnitPrice },
                new OrderItem { OrderId = 0, ProductId = products[1].Id, Quantity = 3, UnitPrice = products[1].UnitPrice },
            };
            orders[0].TotalPrice = orders[0].OrderItems.Sum(oi => oi.UnitPrice*oi.Quantity);

            orders[1].OrderItems = new List<OrderItem>
            {
                new OrderItem { OrderId = 1, ProductId = products[2].Id, Quantity = 1, UnitPrice = products[2].UnitPrice }
            };
            orders[1].TotalPrice = orders[1].OrderItems.Sum(oi => oi.UnitPrice * oi.Quantity);

            _salesContext.Orders.AddRange(orders);
            _salesContext.SaveChanges();
        }
    }
}
