// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// TargetFrameworkVersion = 4.52
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.ModelConfiguration;
using System.Threading;
using System.Threading.Tasks;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace DataModels
{
    public class NorthwindDbContext : DbContext, INorthwindDbContext
    {
        public IDbSet<AlphabeticalListOfProduct> AlphabeticalListOfProducts { get; set; } // Alphabetical list of products
        public IDbSet<Category> Categories { get; set; } // Categories
        public IDbSet<CategorySalesFor1997> CategorySalesFor1997 { get; set; } // Category Sales for 1997
        public IDbSet<CurrentProductList> CurrentProductLists { get; set; } // Current Product List
        public IDbSet<Customer> Customers { get; set; } // Customers
        public IDbSet<CustomerAndSuppliersByCity> CustomerAndSuppliersByCities { get; set; } // Customer and Suppliers by City
        public IDbSet<CustomerDemographic> CustomerDemographics { get; set; } // CustomerDemographics
        public IDbSet<Employee> Employees { get; set; } // Employees
        public IDbSet<Invoice> Invoices { get; set; } // Invoices
        public IDbSet<Order> Orders { get; set; } // Orders
        public IDbSet<OrderDetail> OrderDetails { get; set; } // Order Details
        public IDbSet<OrderDetailsExtended> OrderDetailsExtendeds { get; set; } // Order Details Extended
        public IDbSet<OrdersQry> OrdersQries { get; set; } // Orders Qry
        public IDbSet<OrderSubtotal> OrderSubtotals { get; set; } // Order Subtotals
        public IDbSet<Product> Products { get; set; } // Products
        public IDbSet<ProductsAboveAveragePrice> ProductsAboveAveragePrices { get; set; } // Products Above Average Price
        public IDbSet<ProductSalesFor1997> ProductSalesFor1997 { get; set; } // Product Sales for 1997
        public IDbSet<ProductsByCategory> ProductsByCategories { get; set; } // Products by Category
        public IDbSet<Region> Regions { get; set; } // Region
        public IDbSet<SalesByCategory> SalesByCategories { get; set; } // Sales by Category
        public IDbSet<SalesTotalsByAmount> SalesTotalsByAmounts { get; set; } // Sales Totals by Amount
        public IDbSet<Shipper> Shippers { get; set; } // Shippers
        public IDbSet<SummaryOfSalesByQuarter> SummaryOfSalesByQuarters { get; set; } // Summary of Sales by Quarter
        public IDbSet<SummaryOfSalesByYear> SummaryOfSalesByYears { get; set; } // Summary of Sales by Year
        public IDbSet<Supplier> Suppliers { get; set; } // Suppliers
        public IDbSet<Sysdiagram> Sysdiagrams { get; set; } // sysdiagrams
        public IDbSet<Territory> Territories { get; set; } // Territories
        
        static NorthwindDbContext()
        {
            Database.SetInitializer<NorthwindDbContext>(null);
        }

        public NorthwindDbContext()
            : base("Name=NorthwindDb")
        {
        }

        public NorthwindDbContext(string connectionString) : base(connectionString)
        {
        }

        public NorthwindDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AlphabeticalListOfProductConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CategorySalesFor1997Configuration());
            modelBuilder.Configurations.Add(new CurrentProductListConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new CustomerAndSuppliersByCityConfiguration());
            modelBuilder.Configurations.Add(new CustomerDemographicConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new InvoiceConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailsExtendedConfiguration());
            modelBuilder.Configurations.Add(new OrdersQryConfiguration());
            modelBuilder.Configurations.Add(new OrderSubtotalConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProductsAboveAveragePriceConfiguration());
            modelBuilder.Configurations.Add(new ProductSalesFor1997Configuration());
            modelBuilder.Configurations.Add(new ProductsByCategoryConfiguration());
            modelBuilder.Configurations.Add(new RegionConfiguration());
            modelBuilder.Configurations.Add(new SalesByCategoryConfiguration());
            modelBuilder.Configurations.Add(new SalesTotalsByAmountConfiguration());
            modelBuilder.Configurations.Add(new ShipperConfiguration());
            modelBuilder.Configurations.Add(new SummaryOfSalesByQuarterConfiguration());
            modelBuilder.Configurations.Add(new SummaryOfSalesByYearConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());
            modelBuilder.Configurations.Add(new SysdiagramConfiguration());
            modelBuilder.Configurations.Add(new TerritoryConfiguration());
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AlphabeticalListOfProductConfiguration(schema));
            modelBuilder.Configurations.Add(new CategoryConfiguration(schema));
            modelBuilder.Configurations.Add(new CategorySalesFor1997Configuration(schema));
            modelBuilder.Configurations.Add(new CurrentProductListConfiguration(schema));
            modelBuilder.Configurations.Add(new CustomerConfiguration(schema));
            modelBuilder.Configurations.Add(new CustomerAndSuppliersByCityConfiguration(schema));
            modelBuilder.Configurations.Add(new CustomerDemographicConfiguration(schema));
            modelBuilder.Configurations.Add(new EmployeeConfiguration(schema));
            modelBuilder.Configurations.Add(new InvoiceConfiguration(schema));
            modelBuilder.Configurations.Add(new OrderConfiguration(schema));
            modelBuilder.Configurations.Add(new OrderDetailConfiguration(schema));
            modelBuilder.Configurations.Add(new OrderDetailsExtendedConfiguration(schema));
            modelBuilder.Configurations.Add(new OrdersQryConfiguration(schema));
            modelBuilder.Configurations.Add(new OrderSubtotalConfiguration(schema));
            modelBuilder.Configurations.Add(new ProductConfiguration(schema));
            modelBuilder.Configurations.Add(new ProductsAboveAveragePriceConfiguration(schema));
            modelBuilder.Configurations.Add(new ProductSalesFor1997Configuration(schema));
            modelBuilder.Configurations.Add(new ProductsByCategoryConfiguration(schema));
            modelBuilder.Configurations.Add(new RegionConfiguration(schema));
            modelBuilder.Configurations.Add(new SalesByCategoryConfiguration(schema));
            modelBuilder.Configurations.Add(new SalesTotalsByAmountConfiguration(schema));
            modelBuilder.Configurations.Add(new ShipperConfiguration(schema));
            modelBuilder.Configurations.Add(new SummaryOfSalesByQuarterConfiguration(schema));
            modelBuilder.Configurations.Add(new SummaryOfSalesByYearConfiguration(schema));
            modelBuilder.Configurations.Add(new SupplierConfiguration(schema));
            modelBuilder.Configurations.Add(new SysdiagramConfiguration(schema));
            modelBuilder.Configurations.Add(new TerritoryConfiguration(schema));
            return modelBuilder;
        }
        
        // Stored Procedures
        public List<CustOrderHistReturnModel> CustOrderHist(string customerId, out int procResult)
        {
            var customerIdParam = new SqlParameter { ParameterName = "@CustomerID", SqlDbType = SqlDbType.NChar, Direction = ParameterDirection.Input, Value = customerId, Size = 5 };
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            var procResultData = Database.SqlQuery<CustOrderHistReturnModel>("EXEC @procResult = [dbo].[CustOrderHist] @CustomerID", customerIdParam, procResultParam).ToList();
 
            procResult = (int) procResultParam.Value;
            return procResultData;
        }

        public List<CustOrdersDetailReturnModel> CustOrdersDetail(int? orderId, out int procResult)
        {
            var orderIdParam = new SqlParameter { ParameterName = "@OrderID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = orderId.GetValueOrDefault() };
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            var procResultData = Database.SqlQuery<CustOrdersDetailReturnModel>("EXEC @procResult = [dbo].[CustOrdersDetail] @OrderID", orderIdParam, procResultParam).ToList();
 
            procResult = (int) procResultParam.Value;
            return procResultData;
        }

        public List<CustOrdersOrdersReturnModel> CustOrdersOrders(string customerId, out int procResult)
        {
            var customerIdParam = new SqlParameter { ParameterName = "@CustomerID", SqlDbType = SqlDbType.NChar, Direction = ParameterDirection.Input, Value = customerId, Size = 5 };
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            var procResultData = Database.SqlQuery<CustOrdersOrdersReturnModel>("EXEC @procResult = [dbo].[CustOrdersOrders] @CustomerID", customerIdParam, procResultParam).ToList();
 
            procResult = (int) procResultParam.Value;
            return procResultData;
        }

        public List<EmployeeSalesByCountryReturnModel> EmployeeSalesByCountry(DateTime? beginningDate, DateTime? endingDate, out int procResult)
        {
            var beginningDateParam = new SqlParameter { ParameterName = "@Beginning_Date", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = beginningDate.GetValueOrDefault() };
            var endingDateParam = new SqlParameter { ParameterName = "@Ending_Date", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = endingDate.GetValueOrDefault() };
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            var procResultData = Database.SqlQuery<EmployeeSalesByCountryReturnModel>("EXEC @procResult = [dbo].[Employee Sales by Country] @Beginning_Date, @Ending_Date", beginningDateParam, endingDateParam, procResultParam).ToList();
 
            procResult = (int) procResultParam.Value;
            return procResultData;
        }

        public List<SalesByYearReturnModel> SalesByYear(DateTime? beginningDate, DateTime? endingDate, out int procResult)
        {
            var beginningDateParam = new SqlParameter { ParameterName = "@Beginning_Date", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = beginningDate.GetValueOrDefault() };
            var endingDateParam = new SqlParameter { ParameterName = "@Ending_Date", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = endingDate.GetValueOrDefault() };
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            var procResultData = Database.SqlQuery<SalesByYearReturnModel>("EXEC @procResult = [dbo].[Sales by Year] @Beginning_Date, @Ending_Date", beginningDateParam, endingDateParam, procResultParam).ToList();
 
            procResult = (int) procResultParam.Value;
            return procResultData;
        }

        public List<SalesByCategoryReturnModel> SalesByCategory(string categoryName, string ordYear, out int procResult)
        {
            var categoryNameParam = new SqlParameter { ParameterName = "@CategoryName", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = categoryName, Size = 15 };
            var ordYearParam = new SqlParameter { ParameterName = "@OrdYear", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = ordYear, Size = 4 };
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            var procResultData = Database.SqlQuery<SalesByCategoryReturnModel>("EXEC @procResult = [dbo].[SalesByCategory] @CategoryName, @OrdYear", categoryNameParam, ordYearParam, procResultParam).ToList();
 
            procResult = (int) procResultParam.Value;
            return procResultData;
        }

        public List<TenMostExpensiveProductsReturnModel> TenMostExpensiveProducts( out int procResult)
        {
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            var procResultData = Database.SqlQuery<TenMostExpensiveProductsReturnModel>("EXEC @procResult = [dbo].[Ten Most Expensive Products] ", procResultParam).ToList();
 
            procResult = (int) procResultParam.Value;
            return procResultData;
        }

    }
}
