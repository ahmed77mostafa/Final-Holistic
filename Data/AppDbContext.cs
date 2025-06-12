using Ahmed_Mostafa_Saleh_3025305.Models;
using Microsoft.EntityFrameworkCore;

namespace Ahmed_Mostafa_Saleh_3025305.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
