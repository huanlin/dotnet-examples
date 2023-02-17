using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ConnectionRetry
{
    public class MyEFConfig : DbConfiguration
    {
        public MyEFConfig()
        {
            SetExecutionStrategy("System.Data.SqlClient", 
                () => new MySqlAzureExecutionStrategy(3, TimeSpan.FromSeconds(60)));
        }
    }

    public class MySqlAzureExecutionStrategy : SqlAzureExecutionStrategy
    {
        private List<int> _errorCodesToRetry = new List<int>
        {
            //List custom error codes here.
        };

        public MySqlAzureExecutionStrategy(int maxRetryCount, TimeSpan maxDelay) : base(maxRetryCount, maxDelay)
        {

        }

        protected override bool ShouldRetryOn(Exception exception)
        {
            Console.WriteLine("\r\nEntering MySqlAzureExecutionStrategy.ShouldRetryOn()\r\n");

            var sqlException = exception as SqlException;
            if (sqlException != null)
            {
                foreach (SqlError err in sqlException.Errors)
                {
                    Console.WriteLine(err.Message + " , " + err.Number);
                    // Enumerate through all errors found in the exception.
                    if (_errorCodesToRetry.Contains(err.Number))
                    {
                        Console.WriteLine("\r\nLeaving MySqlAzureExecutionStrategy.ShouldRetryOn() with retry.");
                        return true;
                    }
                }
            }
            Console.WriteLine("\r\nLeaving MySqlAzureExecutionStrategy.ShouldRetryOn() without retry.");
            return base.ShouldRetryOn(exception);
        }
    }
}
