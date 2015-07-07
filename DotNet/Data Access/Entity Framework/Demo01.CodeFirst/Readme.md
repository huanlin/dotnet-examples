# Demo01.CodeFirst

A very simple example for showing Entity Framework Code First.

## Note

 - When the application is started, the database will always be created.
 - Database seeding is demonstrated.
 - To see the database, at least run this application once, then open SQL Server Object Explorer window in Visual Studio. 

   In the SQL Server Object Explorer, under "SQL Server" node, you should see some connection nodes such as:

   - (localdb)\MSSQLLocalDB (....) 
   - (localdb)\Projects (....) 
   - (localdb)\ProjectsV12 (....) 
   - (localdb)\v11.0 (....) 
   
   You'll find the application's database under one of the above connection nodes. The database name would be "Demo01.CodeFirst.SalesContext".
   If you can't find the database, try adding a connection yourself. For example, you might need to add a connection with name "(localdb)\MSSQLLocalDB".
   Also, make sure you have installed the up-to-date version of SQL Server Data Tools.