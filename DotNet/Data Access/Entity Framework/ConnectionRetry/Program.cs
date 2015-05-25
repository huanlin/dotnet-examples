using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectionRetry
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Model.NorthwindEntities();
            using (db)
            {
                var qry = from t in db.Customers
                          select t;
                Console.WriteLine("Before connect: " + DateTime.Now.ToString());
                try
                {
                    var customer = qry.FirstOrDefault();
                    Console.WriteLine("Done: " + DateTime.Now.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:" + DateTime.Now.ToString());
                    Console.WriteLine(ex.Message);
                }                
            }
        }
    }
}
