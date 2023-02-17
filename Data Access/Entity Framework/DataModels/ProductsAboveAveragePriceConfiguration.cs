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
    // Products Above Average Price
    internal class ProductsAboveAveragePriceConfiguration : EntityTypeConfiguration<ProductsAboveAveragePrice>
    {
        public ProductsAboveAveragePriceConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Products Above Average Price");
            HasKey(x => x.ProductName);

            Property(x => x.ProductName).HasColumnName("ProductName").IsRequired().HasMaxLength(40);
            Property(x => x.UnitPrice).HasColumnName("UnitPrice").IsOptional().HasPrecision(19,4);
        }
    }

}
