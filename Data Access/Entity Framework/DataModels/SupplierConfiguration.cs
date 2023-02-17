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
    // Suppliers
    internal class SupplierConfiguration : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Suppliers");
            HasKey(x => x.SupplierId);

            Property(x => x.SupplierId).HasColumnName("SupplierID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CompanyName).HasColumnName("CompanyName").IsRequired().HasMaxLength(40);
            Property(x => x.ContactName).HasColumnName("ContactName").IsOptional().HasMaxLength(30);
            Property(x => x.ContactTitle).HasColumnName("ContactTitle").IsOptional().HasMaxLength(30);
            Property(x => x.Address).HasColumnName("Address").IsOptional().HasMaxLength(60);
            Property(x => x.City).HasColumnName("City").IsOptional().HasMaxLength(15);
            Property(x => x.Region).HasColumnName("Region").IsOptional().HasMaxLength(15);
            Property(x => x.PostalCode).HasColumnName("PostalCode").IsOptional().HasMaxLength(10);
            Property(x => x.Country).HasColumnName("Country").IsOptional().HasMaxLength(15);
            Property(x => x.Phone).HasColumnName("Phone").IsOptional().HasMaxLength(24);
            Property(x => x.Fax).HasColumnName("Fax").IsOptional().HasMaxLength(24);
            Property(x => x.HomePage).HasColumnName("HomePage").IsOptional().HasMaxLength(1073741823);
        }
    }

}
