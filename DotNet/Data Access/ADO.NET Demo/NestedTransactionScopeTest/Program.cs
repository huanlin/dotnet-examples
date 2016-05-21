using System;
using System.Data.SqlClient;
using System.Transactions;

namespace NestedTransactionScopeTest
{
    class Program
    {
        private static string _connectionString = "server=.;database=Northwind;uid=sa;pwd=sa";

        static void Main(string[] args)
        {
            Update1();

            Console.WriteLine("Done");
        }

        static void Update1()
        {
            using (var scope1 = new TransactionScope())
            {
                ExecuteSql(_connectionString, "update Employees set LastName='mike' where EmployeeId=1");

                Update2();

                scope1.Complete();
            }
        }

        static void Update2()
        {
            using (var scope2 = new TransactionScope())
            {
                ExecuteSql(_connectionString, "update Customers set City='Taipei' where CustomerId='ALFKI'");
                scope2.Complete(); // remove this line will casue parent transaction to throw TransactionAbortedException. 
                return;
            }
        }

        static int ExecuteSql(string connectionString, string sql)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    return cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
