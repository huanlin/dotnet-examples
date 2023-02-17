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
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.13.0.0")]
    public class Product
    {
        public int ProductId { get; set; } // ProductID (Primary key)
        public string ProductName { get; set; } // ProductName
        public int? SupplierId { get; set; } // SupplierID
        public int? CategoryId { get; set; } // CategoryID
        public string QuantityPerUnit { get; set; } // QuantityPerUnit
        public decimal? UnitPrice { get; set; } // UnitPrice
        public short? UnitsInStock { get; set; } // UnitsInStock
        public short? UnitsOnOrder { get; set; } // UnitsOnOrder
        public short? ReorderLevel { get; set; } // ReorderLevel
        public bool Discontinued { get; set; } // Discontinued

        // Reverse navigation
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } // Many to many mapping

        // Foreign keys
        public virtual Category Category { get; set; } // FK_Products_Categories
        public virtual Supplier Supplier { get; set; } // FK_Products_Suppliers
        
        public Product()
        {
            UnitPrice = 0m;
            UnitsInStock = 0;
            UnitsOnOrder = 0;
            ReorderLevel = 0;
            Discontinued = false;
            OrderDetails = new List<OrderDetail>();
        }
    }

}
