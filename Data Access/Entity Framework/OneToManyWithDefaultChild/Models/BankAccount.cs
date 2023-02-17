
namespace OneToManyWithDefaultChild.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string AccountNumber { get; set; }
        public int Balance { get; set; }

        // Navigation properties
        //public Customer Customer { get; set; }
    }
}
