# CQRS Demo

  A CQRS example with ASP.NET Web API 2.x.
  
## Test the Application

  1. Open the solution file with Visual Studio 2013/2015, the press F5 or Ctrl+F5.
  2. In your browser's address box, enter the following URLs to test:
  
     - http://[host name and port]/api/Customer/page=1&pageSize=10
     - http://[host name and port]/api/Customer/page=1&pageSize=5&sortOrder=country
     - http://[host name and port]/api/Customer/page=1&pageSize=5&name=j
     - http://[host name and port]/api/Customer/page=1&pageSize=5&name=j&country=ROC

## Dependencies

 - [PagedList](https://github.com/troygoode/PagedList)
 - [LINQKit](http://www.albahari.com/nutshell/linqkit.aspx)
 - Entity Framework

## Notes

 - Applied CQRS pattern.

 - Entity Framework with Code First. 

    - The database will be created every time app initialized.
    - Seeding with custom DropCreateDatabaseAlways<SalesContext> class.

 - Using only one repository, so no UoW required.

 - The number of first page in PagedList is 1. If you pass 0 as the page number, PagedList will throw an exception.

 - Filtering, paging, and sorting are implemented in the Query class.

 - Filtering, paging, and sorting should be all executed at DB side. Use SQL monitor to confirm this requirement.

 - While connecting to the database, use "(LocalDb)\v11.0" as the data source (server) name.

 - SalesApp.Core does not depend on Entity Framework and LINQKit.

## To-Do List

 - Unit tests.
