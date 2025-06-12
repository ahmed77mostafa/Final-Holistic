using Ahmed_Mostafa_Saleh_3025305.Models;
using System.ComponentModel.DataAnnotations;

namespace Ahmed_Mostafa_Saleh_3025305.Data.DTOs
{
    public class CustomerRequest
    {
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public List<AccountResponse> Accounts { get; set; }
        public BankCardWithCustomer? BankCard { get; set; } = new BankCardWithCustomer();
        public List<BranchDTO>? Branches { get; set; } = new List<BranchDTO>();
    }
    public class CustomerResponse
    {
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public BankCardDTO? BankCard { get; set; }
        public List<BranchDTO>? Branches { get; set; }
    }
    public class CustomerWithBranch
    {
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public BankCardDTO? BankCard { get; set; }
        public List<AccountResponse>? Accounts { get; set; }
    }
    public class CustomerWithBranchResponse
    {
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public List<AccountResponse>? Accounts { get; set; }
    }
}
