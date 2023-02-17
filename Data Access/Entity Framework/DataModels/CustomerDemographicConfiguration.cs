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
    // CustomerDemographics
    internal class CustomerDemographicConfiguration : EntityTypeConfiguration<CustomerDemographic>
    {
        public CustomerDemographicConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".CustomerDemographics");
            HasKey(x => x.CustomerTypeId);

            Property(x => x.CustomerTypeId).HasColumnName("CustomerTypeID").IsRequired().IsFixedLength().HasMaxLength(10).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CustomerDesc).HasColumnName("CustomerDesc").IsOptional().HasMaxLength(1073741823);
        }
    }

}
