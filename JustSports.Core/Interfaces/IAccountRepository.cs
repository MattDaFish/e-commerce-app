using JustSports.Core.Communication;
using JustSports.Core.Entities;

namespace JustSports.Core.Interfaces
{
    public interface IAccountRepository
    {
        Task<Customer> AuthenticateCustomerAccountAsync(Customer customer);

        Task<CustomerResponse> RegisterCustomerAccountAsync(Customer customer);
        Task<CustomerResponse> UpdateCustomerAccountAsync(Customer customer);

    }
}