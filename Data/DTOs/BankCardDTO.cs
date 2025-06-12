using System.ComponentModel.DataAnnotations;

namespace Ahmed_Mostafa_Saleh_3025305.Data.DTOs
{
    public class BankCardDTO
    {
        [Required]
        [MaxLength(16, ErrorMessage = "Card Number can't be more than 16 numbers")]
        public string CardNumber { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
    }
    public class BankCardWithCustomer
    {
        [MaxLength(16, ErrorMessage = "Card Number can't be more than 16 numbers")]
        public string? CardNumber { get; set; } = "";
        public DateTime ExpiryDate { get; set; }
    }
}
