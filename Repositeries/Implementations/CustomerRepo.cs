using Ahmed_Mostafa_Saleh_3025305.Data;
using Ahmed_Mostafa_Saleh_3025305.Data.DTOs;
using Ahmed_Mostafa_Saleh_3025305.Models;
using Ahmed_Mostafa_Saleh_3025305.Repositeries.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ahmed_Mostafa_Saleh_3025305.Repositeries.Implementations
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly AppDbContext _context;

        public CustomerRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool AddCustomer(CustomerRequest customerDTO)
        {
            Customer customer = new Customer
            {
                Name = customerDTO.Name,
                Email = customerDTO.Email,
                Phone = customerDTO.Phone,
                Accounts = customerDTO.Accounts.Select(a => new Account
                {
                    AccountNumber = a.AccountNumber,
                    Balance = a.Balance,
                }).ToList(),
                Branches = customerDTO.Branches.Select(a => new Branch
                {
                    Name = a.Name,
                    Location = a.Location,
                }).ToList(),
                BankCard = new BankCard
                {
                    CardNumber = customerDTO.BankCard.CardNumber,
                    ExpiryDate = customerDTO.BankCard.ExpiryDate,
                }
            };

            _context.Customers.Add(customer);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public CustomerResponse GetCustomerById(int id)
        {
            var customer = _context.Customers
                .Include(b => b.Branches)
                .Include(b => b.BankCard)
                .FirstOrDefault(a => a.Id == id);
            if (customer == null)
                return null;
            else
            {
                CustomerResponse customerResponse = new CustomerResponse
                {
                     Name= customer.Name,
                     Phone= customer.Phone,
                     Email = customer.Email,
                     Branches = customer.Branches.Select(a => new BranchDTO
                     {
                         Name = a.Name,
                         Location = a.Location,
                     }).ToList(),
                     BankCard = new BankCardDTO
                     {
                         CardNumber= customer.BankCard.CardNumber,
                         ExpiryDate = customer.BankCard.ExpiryDate
                     }
                };

                return customerResponse;
            }
        }
    }
}
