
using System.Data.Entity.ModelConfiguration;

namespace Demo01.CodeFirst.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id });

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("Customer");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
