using OneToManyWithDefaultChild.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace OneToManyWithDefaultChild
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SalesContext>());

            using (var context = new SalesContext())
            {
                Customer customer = new Customer
                {
                    Name = "Michael Tsai"
                };
                context.Customers.Add(customer);
                context.SaveChanges();

                Console.WriteLine(context.Customers.First().Name);
            }

            //BankAccount wallet = new BankAccount
            //{
            //    Balance = 100
            //};

        }
    }
}
