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
    // Categories
    internal class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Categories");
            HasKey(x => x.CategoryId);

            Property(x => x.CategoryId).HasColumnName("CategoryID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CategoryName).HasColumnName("CategoryName").IsRequired().HasMaxLength(15);
            Property(x => x.Description).HasColumnName("Description").IsOptional().HasMaxLength(1073741823);
            Property(x => x.Picture).HasColumnName("Picture").IsOptional().HasMaxLength(2147483647);
        }
    }

}
