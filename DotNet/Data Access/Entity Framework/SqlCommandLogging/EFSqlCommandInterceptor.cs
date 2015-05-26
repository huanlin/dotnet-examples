using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommandLogging
{
    internal class EFSqlCommandInterceptor : IDbCommandInterceptor 
    {
        public void NonQueryExecuting(
            DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            //LogIfNonAsync(command, interceptionContext);
        }

        public void NonQueryExecuted(
            DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }

        public void ReaderExecuting(
            DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            //LogIfNonAsync(command, interceptionContext);
        }

        public void ReaderExecuted(
            DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }

        public void ScalarExecuting(
            DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            //LogIfNonAsync(command, interceptionContext);
        }

        public void ScalarExecuted(
            DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }

        private void LogIfNonAsync<TResult>(
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if (!interceptionContext.IsAsync)
            {
                Console.WriteLine("Non-async command used: {0}", command.CommandText);
            }
        }

        /// <summary>
        /// Log SQL command only when exception.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="command"></param>
        /// <param name="interceptionContext"></param>
        private void LogIfError<TResult>(
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {            
            if (interceptionContext.Exception != null)
            {
                Console.WriteLine("SQL command failed with exception: {0}\r\n", interceptionContext.Exception.Message);
                Console.WriteLine("SQL command and parameters: \r\n");
                Console.WriteLine(command.CommandText);
                if (command.Parameters != null) 
                {
                    foreach (var param in command.Parameters.OfType<DbParameter>())
                    {
                        LogParameter(command, interceptionContext, param);
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TResult">The type of the operation's results.</typeparam>
        /// <param name="command">The command being logged.</param>
        /// <param name="interceptionContext">Contextual information associated with the command.</param>
        /// <param name="parameter">The parameter to log.</param>
        private void LogParameter<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext, DbParameter parameter)
        {
            // -- Name: [Value] (Type = {}, Direction = {}, IsNullable = {}, Size = {}, Precision = {} Scale = {})
            var builder = new StringBuilder();
            builder.Append("-- ")
                .Append(parameter.ParameterName)
                .Append(": '")
                .Append((parameter.Value == null || parameter.Value == DBNull.Value) ? "null" : parameter.Value)
                .Append("' (Type = ")
                .Append(parameter.DbType);

            if (parameter.Direction != ParameterDirection.Input)
            {
                builder.Append(", Direction = ").Append(parameter.Direction);
            }

            if (!parameter.IsNullable)
            {
                builder.Append(", IsNullable = false");
            }

            if (parameter.Size != 0)
            {
                builder.Append(", Size = ").Append(parameter.Size);
            }

            if (((IDbDataParameter)parameter).Precision != 0)
            {
                builder.Append(", Precision = ").Append(((IDbDataParameter)parameter).Precision);
            }

            if (((IDbDataParameter)parameter).Scale != 0)
            {
                builder.Append(", Scale = ").Append(((IDbDataParameter)parameter).Scale);
            }

            builder.Append(")").Append(Environment.NewLine);

            Console.WriteLine(builder.ToString());
        }
    }
}
