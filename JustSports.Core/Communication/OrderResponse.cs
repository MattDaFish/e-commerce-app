using JustSports.Core.Entities.OrderAggregate;

namespace JustSports.Core.Communication
{
    public class OrderResponse : ServiceResponse<Order>
    {
        public OrderResponse(Order order) : base(order) { }

        public OrderResponse(string message) : base(message) { }
    }
}