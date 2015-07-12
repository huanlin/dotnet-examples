# CQRS Demo


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