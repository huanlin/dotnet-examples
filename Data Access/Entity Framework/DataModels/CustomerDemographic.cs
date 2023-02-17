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
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.13.0.0")]
    public class CustomerDemographic
    {
        public string CustomerTypeId { get; set; } // CustomerTypeID (Primary key)
        public string CustomerDesc { get; set; } // CustomerDesc

        // Reverse navigation
        public virtual ICollection<Customer> Customers { get; set; } // Many to many mapping
        
        public CustomerDemographic()
        {
            Customers = new List<Customer>();
        }
    }

}
