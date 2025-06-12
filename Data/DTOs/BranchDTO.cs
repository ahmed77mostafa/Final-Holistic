using Ahmed_Mostafa_Saleh_3025305.Models;
using System.ComponentModel.DataAnnotations;

namespace Ahmed_Mostafa_Saleh_3025305.Data.DTOs
{
    public class BranchDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
    }
    public class BranchWithCustomer
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public List<CustomerWithBranch>? Customers { get; set; } = new List<CustomerWithBranch>();
    }
    public class BranchWithCustomerResponse
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public List<CustomerWithBranchResponse>? Customers { get; set; }
    }
    public class UpdateBranchWithCustomer
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public List<int>? customerIds { get; set; } = new List<int>();
    }
}
