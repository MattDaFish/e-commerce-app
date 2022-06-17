using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustSports.Core.Entities.OrderAggregate
{
    public class OrderItem
    {
        public long Id { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }

        public long ProductId { get; set; }
        public Product ProductOrdered { get; set; }

        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(long orderId, long productId, decimal price, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            PurchasePrice = price;
            Quantity = quantity;
        }


    }
}
