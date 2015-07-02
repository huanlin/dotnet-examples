using System.ComponentModel.DataAnnotations;

namespace Demo01.CodeFirst.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }
    }
}
