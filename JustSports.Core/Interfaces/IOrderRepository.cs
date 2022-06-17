using JustSports.Core.Entities.OrderAggregate;
using JustSports.Core.Communication;

namespace JustSports.Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<IReadOnlyList<Order>> GetOrdersAsync();
        Task<IReadOnlyList<Order>> GetOrdersByCustomerIdAsync(int customerId);

        Task<Order> GetOrderByIdAsync(long Id);

        Task<OrderResponse> CreateOrderAsync(long basketId, int customerId);
        
        
    }
}