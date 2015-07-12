using System;
using Demo01.CodeFirst.Models;

namespace Demo01.CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                Name = "Michael Tsai"
            };

            using (var context = new SalesContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                
                foreach (var cust in context.Customers)
                {
                    Console.WriteLine("{0}: {1}", cust.Id, cust.Name);   
                };
            }
        }
    }
}
