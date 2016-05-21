using System.Transactions;

namespace NestedTransactionScopeTest
{
    public class Example1
    {
        private string _connectionString;
        public Example1(string connectionString)
        {
            _connectionString = connectionString;
        }


        public void Run()
        {
            Update1();
        }

        private void Update1()
        {
            using (var scope1 = new TransactionScope())
            {
                DbHelper.ExecuteSql(_connectionString, "update Employees set LastName='mike' where EmployeeId=1");

                if (Update2())
                {
                    scope1.Complete();
                }                
            }
        }

        private bool Update2()
        {
            bool succeeded = false;
            using (var scope2 = new TransactionScope())
            {
                DbHelper.ExecuteSql(_connectionString, "update Customers set City='Taipei' where CustomerId='ALFKI'");
                scope2.Complete(); // remove this line will casue parent transaction to throw TransactionAbortedException. 
                succeeded = true;
            }

            return succeeded;
        }
    }
}
