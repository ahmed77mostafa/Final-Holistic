using System.ComponentModel.DataAnnotations;

namespace Ahmed_Mostafa_Saleh_3025305.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public List<Account> Accounts { get; set; }
        public BankCard BankCard { get; set; }
        public List<Branch> Branches { get; set; }
    }
}
