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
    // Shippers
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.13.0.0")]
    public class Shipper
    {
        public int ShipperId { get; set; } // ShipperID (Primary key)
        public string CompanyName { get; set; } // CompanyName
        public string Phone { get; set; } // Phone

        // Reverse navigation
        public virtual ICollection<Order> Orders { get; set; } // Orders.FK_Orders_Shippers
        
        public Shipper()
        {
            Orders = new List<Order>();
        }
    }

}
