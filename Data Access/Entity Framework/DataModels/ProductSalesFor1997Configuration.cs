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
    // Product Sales for 1997
    internal class ProductSalesFor1997Configuration : EntityTypeConfiguration<ProductSalesFor1997>
    {
        public ProductSalesFor1997Configuration(string schema = "dbo")
        {
            ToTable(schema + ".Product Sales for 1997");
            HasKey(x => new { x.CategoryName, x.ProductName });

            Property(x => x.CategoryName).HasColumnName("CategoryName").IsRequired().HasMaxLength(15);
            Property(x => x.ProductName).HasColumnName("ProductName").IsRequired().HasMaxLength(40);
            Property(x => x.ProductSales).HasColumnName("ProductSales").IsOptional().HasPrecision(19,4);
        }
    }

}
