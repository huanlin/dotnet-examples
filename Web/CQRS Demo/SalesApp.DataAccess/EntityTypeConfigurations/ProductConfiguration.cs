﻿using SalesApp.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace SalesApp.DataAccess.EntityTypeConfigurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(t => t.Id).IsRequired();
            Property(t => t.Description).HasMaxLength(255);
            Property(t => t.Name).HasMaxLength(200);
        }
    }
}
