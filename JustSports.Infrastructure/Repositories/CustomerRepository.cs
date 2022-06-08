using Infrastructure.Data;
using JustSports.Core.Communication;
using JustSports.Core.Entities;
using JustSports.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustSports.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(JustSportsDBContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Customer>> GetCustomersAsync()
        {
            return await _context.Customers
            .OrderBy(x => x.Name)
            .ThenBy(x => x.Surname)
            .ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers
                .FindAsync(id);
        }

        public async Task<CustomerResponse> CreateCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return new CustomerResponse(customer);
        }

        public async Task<CustomerResponse> UpdateCustomerAsync(Customer customer)
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