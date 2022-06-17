using JustSports.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustSports.Core.Entities.OrderAggregate
{
    public class Order
    {
        public long Id { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public string OrderNumber { get; set; }
        public decimal AmountInclVat { get; set; }
        public decimal Vat { get; set; }
        public decimal AmountExclVat { get; set; }

        public int OrderStatus { get; set; }

        public long BasketId { get; set; }

        public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
        
        public IReadOnlyList<OrderItem> OrderItems { get; set; }

        public Order()
        {
        }

        public Order(int customerId, int orderCount, long basketId)
        {
            OrderNumber = GenerateOrderNumber(customerId, orderCount);
            AmountInclVat = 0;
            Vat = 0;
            AmountExclVat = 0;
            CustomerId = customerId;
            BasketId = basketId;
            OrderStatus = (int)OrderStatusEnum.Pending;
        }

        public void UpdateOrder(decimal amountInclVat, IReadOnlyList<OrderItem> orderItems)
        {
            AmountInclVat = amountInclVat;
            Vat = CalculateVatAmount(amountInclVat);
            AmountExclVat = amountInclVat - Vat;

            OrderItems = orderItems;
        }

        private string GenerateOrderNumber(int customerId, int orderCount)
        {
            orderCount += 1;

            return "ORD-" + customerId + "-000" + orderCount;
        }

        private decimal CalculateVatAmount(decimal amountInclVat)
        {
            return (amountInclVat / 100) * 15;
        }
    }
}
