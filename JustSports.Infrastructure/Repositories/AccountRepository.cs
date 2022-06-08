using Infrastructure.Data;
using JustSports.Core.Communication;
using JustSports.Core.Entities;
using JustSports.Core.Exceptions;
using JustSports.Core.Interfaces;
using JustSports.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace JustSports.Infrastructure.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(JustSportsDBContext context) : base(context)
        {
        }

        public async Task<Customer> AuthenticateCustomerAccountAsync(Customer customer)
        {
            //### Hash customer password
            string HashPassword = StringExtensions.GetMd5Sum(customer.Password);

            var customerAuth = await _context.Customers
                .Where(x => x.Email == customer.Email && x.Password == HashPassword)
                .FirstOrDefaultAsync();

            if (customerAuth == null)
                throw new CustomerAuthenticationFailureException();

            return customerAuth;
        }

        public async Task<CustomerResponse> RegisterCustomerAccountAsync(Customer customer)
        {
            //### Hash customer password
            string HashPassword = StringExtensions.GetMd5Sum(customer.Password);
            customer.Password = HashPassword;

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return new CustomerResponse(customer);
        }

        public async Task<CustomerResponse> UpdateCustomerAccountAsync(Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(customer.Id);

            if (existingCustomer == null)
                return new CustomerResponse("Customer not found.");

            existingCustomer.Name = customer.Name;
            existingCustomer.Surname = customer.Surname;
            existingCustomer.CellNumber = customer.CellNumber;

            //existingCustomer.Email = customer.Email;
            //existingCustomer.Password = customer.Password;

            await _context.SaveChangesAsync();

            return new CustomerResponse(customer);
        }

    }
}