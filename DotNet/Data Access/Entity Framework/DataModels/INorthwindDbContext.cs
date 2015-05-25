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
    public interface INorthwindDbContext : IDisposable
    {
        IDbSet<AlphabeticalListOfProduct> AlphabeticalListOfProducts { get; set; } // Alphabetical list of products
        IDbSet<Category> Categories { get; set; } // Categories
        IDbSet<CategorySalesFor1997> CategorySalesFor1997 { get; set; } // Category Sales for 1997
        IDbSet<CurrentProductList> CurrentProductLists { get; set; } // Current Product List
        IDbSet<Customer> Customers { get; set; } // Customers
        IDbSet<CustomerAndSuppliersByCity> CustomerAndSuppliersByCities { get; set; } // Customer and Suppliers by City
        IDbSet<CustomerDemographic> CustomerDemographics { get; set; } // CustomerDemographics
        IDbSet<Employee> Employees { get; set; } // Employees
        IDbSet<Invoice> Invoices { get; set; } // Invoices
        IDbSet<Order> Orders { get; set; } // Orders
        IDbSet<OrderDetail> OrderDetails { get; set; } // Order Details
        IDbSet<OrderDetailsExtended> OrderDetailsExtendeds { get; set; } // Order Details Extended
        IDbSet<OrdersQry> OrdersQries { get; set; } // Orders Qry
        IDbSet<OrderSubtotal> OrderSubtotals { get; set; } // Order Subtotals
        IDbSet<Product> Products { get; set; } // Products
        IDbSet<ProductsAboveAveragePrice> ProductsAboveAveragePrices { get; set; } // Products Above Average Price
        IDbSet<ProductSalesFor1997> ProductSalesFor1997 { get; set; } // Product Sales for 1997
        IDbSet<ProductsByCategory> ProductsByCategories { get; set; } // Products by Category
        IDbSet<Region> Regions { get; set; } // Region
        IDbSet<SalesByCategory> SalesByCategories { get; set; } // Sales by Category
        IDbSet<SalesTotalsByAmount> SalesTotalsByAmounts { get; set; } // Sales Totals by Amount
        IDbSet<Shipper> Shippers { get; set; } // Shippers
        IDbSet<SummaryOfSalesByQuarter> SummaryOfSalesByQuarters { get; set; } // Summary of Sales by Quarter
        IDbSet<SummaryOfSalesByYear> SummaryOfSalesByYears { get; set; } // Summary of Sales by Year
        IDbSet<Supplier> Suppliers { get; set; } // Suppliers
        IDbSet<Sysdiagram> Sysdiagrams { get; set; } // sysdiagrams
        IDbSet<Territory> Territories { get; set; } // Territories

        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
        // Stored Procedures
        List<CustOrderHistReturnModel> CustOrderHist(string customerId, out int procResult);
        List<CustOrdersDetailReturnModel> CustOrdersDetail(int? orderId, out int procResult);
        List<CustOrdersOrdersReturnModel> CustOrdersOrders(string customerId, out int procResult);
        List<EmployeeSalesByCountryReturnModel> EmployeeSalesByCountry(DateTime? beginningDate, DateTime? endingDate, out int procResult);
        List<SalesByYearReturnModel> SalesByYear(DateTime? beginningDate, DateTime? endingDate, out int procResult);
        List<SalesByCategoryReturnModel> SalesByCategory(string categoryName, string ordYear, out int procResult);
        List<TenMostExpensiveProductsReturnModel> TenMostExpensiveProducts( out int procResult);
    }

}
