using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Configuration;

namespace InfoTicket.Core.Infrastructure
{
    public class EFConfig : DbConfiguration
    {
        public EFConfig()
        {
            DbInterception.Add(new EFSqlCommandInterceptor());

            int maxRetryCount = 20;
            int maxDelaySeconds = 60;

            SetTransactionHandler(SqlProviderServices.ProviderInvariantName, () => new CommitFailureHandler());
            SetExecutionStrategy(SqlProviderServices.ProviderInvariantName, () => new MySqlAzureExecutionStrategy(maxRetryCount, TimeSpan.FromSeconds(maxDelaySeconds)));

            Console.WriteLine(
                "SQL execution strategy configured. Max retry count: {0}, Max retry delay: {1} seconds.", 
                maxRetryCount, maxDelaySeconds);
        }
    }

    public class MySqlAzureExecutionStrategy : SqlAzureExecutionStrategy
    {
        private List<int> _errorCodesToRetry = new List<int>
        {
            // Add the error code here for retry.
            18456
        };

        public MySqlAzureExecutionStrategy(int maxRetryCount, TimeSpan maxDelay)
            : base(maxRetryCount, maxDelay)
        {

        }

        protected override bool ShouldRetryOn(Exception exception)
        {
            var sqlException = exception as SqlException;
            if (sqlException != null)
            {
                foreach (SqlError err in sqlException.Errors)
                {
                    Console.WriteLine("Retry on SQL Server operation error! Code={0}, Msg={1}", err.Number, err.Message);
                    return true;
                    //if (_errorCodesToRetry.Contains(err.Number))
                    //{
                    //    return true;
                    //}
                }
            }
            return base.ShouldRetryOn(exception);
        }
    }
}
