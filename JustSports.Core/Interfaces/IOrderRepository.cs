using JustSports.Core.Entities.OrderAggregate;

namespace JustSports.Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync();
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync();
        Task<Order> GetOrderByIdAsync(int Id);
    }
}