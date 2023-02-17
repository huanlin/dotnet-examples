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
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.13.0.0")]
    public class FakeNorthwindDbContext : INorthwindDbContext
    {
        public IDbSet<AlphabeticalListOfProduct> AlphabeticalListOfProducts { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<CategorySalesFor1997> CategorySalesFor1997 { get; set; }
        public IDbSet<CurrentProductList> CurrentProductLists { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<CustomerAndSuppliersByCity> CustomerAndSuppliersByCities { get; set; }
        public IDbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Invoice> Invoices { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderDetail> OrderDetails { get; set; }
        public IDbSet<OrderDetailsExtended> OrderDetailsExtendeds { get; set; }
        public IDbSet<OrdersQry> OrdersQries { get; set; }
        public IDbSet<OrderSubtotal> OrderSubtotals { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<ProductsAboveAveragePrice> ProductsAboveAveragePrices { get; set; }
        public IDbSet<ProductSalesFor1997> ProductSalesFor1997 { get; set; }
        public IDbSet<ProductsByCategory> ProductsByCategories { get; set; }
        public IDbSet<Region> Regions { get; set; }
        public IDbSet<SalesByCategory> SalesByCategories { get; set; }
        public IDbSet<SalesTotalsByAmount> SalesTotalsByAmounts { get; set; }
        public IDbSet<Shipper> Shippers { get; set; }
        public IDbSet<SummaryOfSalesByQuarter> SummaryOfSalesByQuarters { get; set; }
        public IDbSet<SummaryOfSalesByYear> SummaryOfSalesByYears { get; set; }
        public IDbSet<Supplier> Suppliers { get; set; }
        public IDbSet<Sysdiagram> Sysdiagrams { get; set; }
        public IDbSet<Territory> Territories { get; set; }

        public FakeNorthwindDbContext()
        {
            AlphabeticalListOfProducts = new FakeDbSet<AlphabeticalListOfProduct>();
            Categories = new FakeDbSet<Category>();
            CategorySalesFor1997 = new FakeDbSet<CategorySalesFor1997>();
            CurrentProductLists = new FakeDbSet<CurrentProductList>();
            Customers = new FakeDbSet<Customer>();
            CustomerAndSuppliersByCities = new FakeDbSet<CustomerAndSuppliersByCity>();
            CustomerDemographics = new FakeDbSet<CustomerDemographic>();
            Employees = new FakeDbSet<Employee>();
            Invoices = new FakeDbSet<Invoice>();
            Orders = new FakeDbSet<Order>();
            OrderDetails = new FakeDbSet<OrderDetail>();
            OrderDetailsExtendeds = new FakeDbSet<OrderDetailsExtended>();
            OrdersQries = new FakeDbSet<OrdersQry>();
            OrderSubtotals = new FakeDbSet<OrderSubtotal>();
            Products = new FakeDbSet<Product>();
            ProductsAboveAveragePrices = new FakeDbSet<ProductsAboveAveragePrice>();
            ProductSalesFor1997 = new FakeDbSet<ProductSalesFor1997>();
            ProductsByCategories = new FakeDbSet<ProductsByCategory>();
            Regions = new FakeDbSet<Region>();
            SalesByCategories = new FakeDbSet<SalesByCategory>();
            SalesTotalsByAmounts = new FakeDbSet<SalesTotalsByAmount>();
            Shippers = new FakeDbSet<Shipper>();
            SummaryOfSalesByQuarters = new FakeDbSet<SummaryOfSalesByQuarter>();
            SummaryOfSalesByYears = new FakeDbSet<SummaryOfSalesByYear>();
            Suppliers = new FakeDbSet<Supplier>();
            Sysdiagrams = new FakeDbSet<Sysdiagram>();
            Territories = new FakeDbSet<Territory>();
        }

        public int SaveChanges()
        {
            return 0;
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
        }
        
        public void Dispose()
        {
            Dispose(true);
        }
        
        // Stored Procedures
        public List<CustOrderHistReturnModel> CustOrderHist(string customerId, out int procResult)
        {
 
            procResult = 0;
            return new List<CustOrderHistReturnModel>();
        }

        public List<CustOrdersDetailReturnModel> CustOrdersDetail(int? orderId, out int procResult)
        {
 
            procResult = 0;
            return new List<CustOrdersDetailReturnModel>();
        }

        public List<CustOrdersOrdersReturnModel> CustOrdersOrders(string customerId, out int procResult)
        {
 
            procResult = 0;
            return new List<CustOrdersOrdersReturnModel>();
        }

        public List<EmployeeSalesByCountryReturnModel> EmployeeSalesByCountry(DateTime? beginningDate, DateTime? endingDate, out int procResult)
        {
 
            procResult = 0;
            return new List<EmployeeSalesByCountryReturnModel>();
        }

        public List<SalesByYearReturnModel> SalesByYear(DateTime? beginningDate, DateTime? endingDate, out int procResult)
        {
 
            procResult = 0;
            return new List<SalesByYearReturnModel>();
        }

        public List<SalesByCategoryReturnModel> SalesByCategory(string categoryName, string ordYear, out int procResult)
        {
 
            procResult = 0;
            return new List<SalesByCategoryReturnModel>();
        }

        public List<TenMostExpensiveProductsReturnModel> TenMostExpensiveProducts( out int procResult)
        {
 
            procResult = 0;
            return new List<TenMostExpensiveProductsReturnModel>();
        }

    }
}
