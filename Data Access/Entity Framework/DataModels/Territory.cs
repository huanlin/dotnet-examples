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
    // Territories
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.13.0.0")]
    public class Territory
    {
        public string TerritoryId { get; set; } // TerritoryID (Primary key)
        public string TerritoryDescription { get; set; } // TerritoryDescription
        public int RegionId { get; set; } // RegionID

        // Reverse navigation
        public virtual ICollection<Employee> Employees { get; set; } // Many to many mapping

        // Foreign keys
        public virtual Region Region { get; set; } // FK_Territories_Region
        
        public Territory()
        {
            Employees = new List<Employee>();
        }
    }

}
