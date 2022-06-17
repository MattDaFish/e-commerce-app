using Infrastructure.Data;
using JustSports.Core.Entities.OrderAggregate;
using JustSports.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using JustSports.Core.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace JustSports.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(JustSportsDBContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                .Include(p => p.OrderItems)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _context.Orders
                .Include(p => p.OrderItems)
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        
        public async Task<Order> GetOrderByIdAsync(long id)
        {
            return await _context.Orders
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<OrderResponse> CreateOrderAsync(long basketId, int customerId)
        {
            //### Get basket to convert to order
            var basket = await _context.Baskets
                .Include(x => x.BasketItems)
                .Where(x => x.IsDeleted == false && x.Id == basketId)
                .FirstOrDefaultAsync();

            if (basket == null)
                return new OrderResponse("Unable to create order - basket not found.");

            if (basket.CustomerId != customerId)
                return new OrderResponse("Invalid basket for the specified customerId.");

            //### Get count of customer orders
            int orderCount = await _context.Orders.Where(x => x.CustomerId == customerId).CountAsync();

            //### Create new order
            var order = new Order(basket.CustomerId, orderCount, basketId);

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            //### Set orderId
            long orderId = order.Id;

            var orderItems = new List<OrderItem>();

            foreach (var basketItem in basket.BasketItems)
            {
                var orderItem = new OrderItem(orderId, basketItem.ProductId, basketItem.PurchasePrice, basketItem.Quantity);
                orderItems.Add(orderItem);
            }

            var totalIncVat = orderItems.Sum(item => item.PurchasePrice * item.Quantity);

            order.UpdateOrder(totalIncVat, orderItems);

            //### Delete basket
            basket.IsDeleted = true;

            //await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return new OrderResponse(order);
        }

    }
}