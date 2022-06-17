using JustSports.Core.Communication;
using JustSports.Core.Entities.BasketAggregate;

namespace JustSports.Core.Interfaces
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasketByCustomerIdAsync(int customerId);

        Task<BasketResponse> CreateOrUpdateBasketAsync(Basket basket);
        
        Task<BasketResponse> DeleteBasketAsync(long Id);

    }
}