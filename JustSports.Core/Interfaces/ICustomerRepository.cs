using JustSports.Core.Communication;
using JustSports.Core.Entities;

namespace JustSports.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyList<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);

        Task<CustomerResponse> UpdateCustomerAsync(Customer customer);

    }
}