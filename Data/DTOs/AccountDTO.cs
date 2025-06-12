using System.ComponentModel.DataAnnotations;

namespace Ahmed_Mostafa_Saleh_3025305.Data.DTOs
{
    public class AccountResponse
    {
        [Required]
        [MaxLength(20)]
        public string AccountNumber { get; set; }
        [Required]
        public Decimal Balance { get; set; }
    }
    public class AccountRequest
    {
        [Required]
        [MaxLength(20)]
        public string AccountNumber { get; set; }
        [Required]
        public Decimal Balance { get; set; }
        public int CustomerId { get; set; }
    }
}
