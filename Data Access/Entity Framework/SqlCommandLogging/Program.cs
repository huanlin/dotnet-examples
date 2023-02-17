using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommandLogging
{
    class Program
    {
        static NorthwindDbContext db = new NorthwindDbContext();

        static void Main(string[] args)
        {
            AddCustomer("XYZ", "XYZ"); // Run this application second time and it will throw exception.

            Console.WriteLine("OK. Run it again!");
        }

        static void AddCustomer(string id, string name)
        {
            var cust = new Customer();
            cust.CustomerId = id;
            cust.CompanyName = name;

            db.Customers.Add(cust);
            db.SaveChanges();
        }
    }
}
