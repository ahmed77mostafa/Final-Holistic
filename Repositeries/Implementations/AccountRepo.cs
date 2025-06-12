using Ahmed_Mostafa_Saleh_3025305.Data;
using Ahmed_Mostafa_Saleh_3025305.Data.DTOs;
using Ahmed_Mostafa_Saleh_3025305.Models;
using Ahmed_Mostafa_Saleh_3025305.Repositeries.Interfaces;

namespace Ahmed_Mostafa_Saleh_3025305.Repositeries.Implementations
{
    public class AccountRepo : IAccountRepo
    {
        private readonly AppDbContext _context;

        public AccountRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool AddAccount(AccountRequest accountRequest)
        {
            if(accountRequest.Balance < 0)
                return false;
            var customer = _context.Customers.FirstOrDefault(x => x.Id == accountRequest.CustomerId);
            if(customer == null)
                return false;

            Account account = new Account
            {
                AccountNumber = accountRequest.AccountNumber,
                Balance = accountRequest.Balance,
                CustomerId = accountRequest.CustomerId,
            };

            _context.Accounts.Add(account);
            _context.SaveChanges();
            return true;
        }
    }
}
