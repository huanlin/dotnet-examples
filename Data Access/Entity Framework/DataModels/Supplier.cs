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
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.13.0.0")]
    public class Supplier
    {
        public int SupplierId { get; set; } // SupplierID (Primary key)
        public string CompanyName { get; set; } // CompanyName
        public string ContactName { get; set; } // ContactName
        public string ContactTitle { get; set; } // ContactTitle
        public string Address { get; set; } // Address
        public string City { get; set; } // City
        public string Region { get; set; } // Region
        public string PostalCode { get; set; } // PostalCode
        public string Country { get; set; } // Country
        public string Phone { get; set; } // Phone
        public string Fax { get; set; } // Fax
        public string HomePage { get; set; } // HomePage

        // Reverse navigation
        public virtual ICollection<Product> Products { get; set; } // Products.FK_Products_Suppliers
        
        public Supplier()
        {
            Products = new List<Product>();
        }
    }

}
