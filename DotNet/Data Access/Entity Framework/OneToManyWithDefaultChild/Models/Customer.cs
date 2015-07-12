

namespace OneToManyWithDefaultChild.Models
{
    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DefaultBankAccountId { get; set; }

        // Navigation properties
        //public BankAccount DefaultBankAccount { get; set; }
        //public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
