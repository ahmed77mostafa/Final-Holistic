using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ahmed_Mostafa_Saleh_3025305.Models
{
    public class BankCard
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(16,ErrorMessage ="Card Number can't be more than 16 numbers")]
        public string CardNumber { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
    }
}
