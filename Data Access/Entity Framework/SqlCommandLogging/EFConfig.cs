using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Configuration;

namespace SqlCommandLogging
{
    public class EFConfig : DbConfiguration
    {

        /// <summary>
        /// NOTE: EF cannot find this class because it is not in the same assembly as DbContext, so we configure it in App.config. 
        ///       See "codeConfigurationType" attribute in App.config.
        /// </summary>
        public EFConfig()
        {
            DbInterception.Add(new EFSqlCommandInterceptor());

            int maxRetryCount = 5;
            int maxDelaySeconds = 30;

            SetTransactionHandler(SqlProviderServices.ProviderInvariantName, () => new CommitFailureHandler());

            // The lines below are commented because we don't want SQL retry here.
            /*
            SetExecutionStrategy(SqlProviderServices.ProviderInvariantName, () => new MySqlAzureExecutionStrategy(maxRetryCount, TimeSpan.FromSeconds(maxDelaySeconds)));

            Console.WriteLine(
                "SQL execution strategy configured. Max retry count: {0}, Max retry delay: {1} seconds.", 
                maxRetryCount, maxDelaySeconds);
             */
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
