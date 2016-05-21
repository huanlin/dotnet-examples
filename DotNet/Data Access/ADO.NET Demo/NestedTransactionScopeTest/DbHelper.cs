using System.Data;
using System.Data.SqlClient;

namespace NestedTransactionScopeTest
{
    public class DbHelper
    {
        public static int ExecuteSql(string connectionString, string sql)
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

        public static int ExecuteSql(IDbConnection conn, string sql)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                return cmd.ExecuteNonQuery();
            }
        }

    }
}
