using System.Data.Entity;
using ConsoleApp.DataAccess;
using ConsoleApp.DataAccess.Queries;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new SalesDbInitializer());

            var context = new SalesContext();
            var customerQueries = new CustomerQueries(context);

            var demo = new Demo(customerQueries);

            var customers = demo.Run().Result;

            foreach (var cust in customers)
            {
                System.Console.WriteLine(cust.Name);
            }
        }
    }
}
