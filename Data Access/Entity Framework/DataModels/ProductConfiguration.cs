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
    // Products
    internal class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Products");
            HasKey(x => x.ProductId);

            Property(x => x.ProductId).HasColumnName("ProductID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProductName).HasColumnName("ProductName").IsRequired().HasMaxLength(40);
            Property(x => x.SupplierId).HasColumnName("SupplierID").IsOptional();
            Property(x => x.CategoryId).HasColumnName("CategoryID").IsOptional();
            Property(x => x.QuantityPerUnit).HasColumnName("QuantityPerUnit").IsOptional().HasMaxLength(20);
            Property(x => x.UnitPrice).HasColumnName("UnitPrice").IsOptional().HasPrecision(19,4);
            Property(x => x.UnitsInStock).HasColumnName("UnitsInStock").IsOptional();
            Property(x => x.UnitsOnOrder).HasColumnName("UnitsOnOrder").IsOptional();
            Property(x => x.ReorderLevel).HasColumnName("ReorderLevel").IsOptional();
            Property(x => x.Discontinued).HasColumnName("Discontinued").IsRequired();

            // Foreign keys
            HasOptional(a => a.Supplier).WithMany(b => b.Products).HasForeignKey(c => c.SupplierId); // FK_Products_Suppliers
            HasOptional(a => a.Category).WithMany(b => b.Products).HasForeignKey(c => c.CategoryId); // FK_Products_Categories
        }
    }

}
