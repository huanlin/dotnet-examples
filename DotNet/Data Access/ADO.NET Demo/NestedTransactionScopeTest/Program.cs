using System;

namespace NestedTransactionScopeTest
{
    class Program
    {
        private static string _connectionString = "server=.;database=Northwind;uid=sa;pwd=sa";

        static void Main(string[] args)
        {
            new Example1(_connectionString).Run();          

            Console.WriteLine("Done");
        }

    }
}
