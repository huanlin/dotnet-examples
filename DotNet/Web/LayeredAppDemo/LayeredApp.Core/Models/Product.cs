
namespace LayeredApp.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductCategoryEnum CategoryId { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
    }
}
