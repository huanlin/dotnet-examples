using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using ConsoleApp.Models;

namespace Console.Models
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(t => t.Id).IsRequired();
            Property(t => t.Name).HasMaxLength(60)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Customer_Name", 1) {IsUnique = false}));
            Property(t => t.Country).HasMaxLength(30);
            Property(t => t.Address).HasMaxLength(200);
        }
    }
}
