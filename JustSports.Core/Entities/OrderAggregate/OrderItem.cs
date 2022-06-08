using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustSports.Core.Entities.OrderAggregate
{
    public class OrderItem
    {
        public OrderItem()
        {
        }

        public OrderItem(Order order, Product product, decimal price, int quantity)
        {
            OrderId = order.Id;
            ProductOrdered = product;
            PurchasePrice = price;
            Quantity = quantity;
        }

        public long Id { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }

        public long ProductId { get; set; }
        public Product ProductOrdered { get; set; }

        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
    }
}
