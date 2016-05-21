using System.Data;
using System.Transactions;

namespace NestedTransactionScopeTest
{
    public class Example2
    {
        private IDbConnection _connection;

        public Example2(IDbConnection conn)
        {
            _connection = conn;
        }

        public void Run()
        {
            Update1();
        }

        private void Update1()
        {
            using (var scope1 = new TransactionScope())
            {
                DbHelper.ExecuteSql(_connection, "update Employees set LastName='mike' where EmployeeId=1");

                Update2();

                scope1.Complete();
            }
        }

        private void Update2()
        {
            using (var scope2 = new TransactionScope())
            {
                DbHelper.ExecuteSql(_connection, "update Customers set City='Taipei' where CustomerId='ALFKI'");
                scope2.Complete(); // remove this line will casue parent transaction to throw TransactionAbortedException. 
            }
        }

    }
}
