using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ahmed_Mostafa_Saleh_3025305.Models
{
    [Index(nameof(AccountNumber), IsUnique = true)]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string AccountNumber { get; set; }
        [Required]
        public Decimal Balance { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

    }
}
