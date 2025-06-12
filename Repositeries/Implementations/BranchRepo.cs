using Ahmed_Mostafa_Saleh_3025305.Data;
using Ahmed_Mostafa_Saleh_3025305.Data.DTOs;
using Ahmed_Mostafa_Saleh_3025305.Models;
using Ahmed_Mostafa_Saleh_3025305.Repositeries.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ahmed_Mostafa_Saleh_3025305.Repositeries.Implementations
{
    public class BranchRepo : IBranchRepo
    {
        private readonly AppDbContext _context;

        public BranchRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool AddBranch(BranchWithCustomer branchDTO)
        {
            Branch branch = new Branch
            {
                Name = branchDTO.Name,
                Location = branchDTO.Location,
                Customers = branchDTO.Customers.Select(c => new Customer
                {
                    Name = c.Name,
                    Phone = c.Phone,
                    Email = c.Email,
                    Accounts = c.Accounts.Select(a => new Account
                    {
                        AccountNumber = a.AccountNumber,
                        Balance = a.Balance,
                    }).ToList(),
                    BankCard = new BankCard
                    {
                        CardNumber = c.BankCard.CardNumber,
                        ExpiryDate = c.BankCard.ExpiryDate,
                    }
                }).ToList()
            };
            _context.Branches.Add(branch);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteBranch(int id)
        {
            var branch = _context.Branches.Include(c => c.Customers).FirstOrDefault(x => x.Id == id);
            if(branch != null)
            {
                _context.Branches.Remove(branch);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<BranchWithCustomerResponse> GetBranches()
        {
            var Branches = _context.Branches
                .Include(c => c.Customers)
                .ThenInclude(a => a.Accounts)
                .Select(a => new BranchWithCustomerResponse
                {
                    Name = a.Name,
                    Location = a.Location,
                    Customers = a.Customers.Select(c => new CustomerWithBranchResponse
                    {
                        Name= c.Name,
                        Phone= c.Phone,
                        Email= c.Email,
                        Accounts= c.Accounts.Select(a => new AccountResponse {
                            AccountNumber = a.AccountNumber,
                            Balance = a.Balance,
                        }).ToList(),
                    }).ToList()
                }).ToList();
            if (Branches.Any())
                return Branches;
            return null;
        }

        public bool UpdateBranch(int id, UpdateBranchWithCustomer branchDTO)
        {
            var branch = _context.Branches.Include(c => c.Customers).FirstOrDefault(x => x.Id == id);
            if(branch == null)
                return false;

            List<Customer> customers = new List<Customer>();
            foreach(var index in branchDTO.customerIds)
            {
                var customer = _context.Customers.FirstOrDefault(x => x.Id == index);
                if (customer != null)
                    customers.Add(customer);
                else
                    throw new Exception($"Can't find customer with Id: {index}");
            }

            if (customers.Count > 0)
            {
                branch.Name = branchDTO.Name;
                branch.Location = branchDTO.Location;
                branch.Customers = customers;

                _context.Branches.Update(branch);
                _context.SaveChanges();
                return true;
            }
            else
            {
                branch.Name = branchDTO.Name;
                branch.Location = branchDTO.Location;

                _context.Branches.Update(branch);
                _context.SaveChanges();
                return true;

            }



        }
    }
}
