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
        public Order()
        {
        }

        public Order(Customer customer, IReadOnlyList<OrderItem> orderItems, decimal amountInclVat)
        {
            OrderNumber = GenerateOrderNumber();
            AmountInclVat = amountInclVat;
            Vat = CalculateVatAmount(amountInclVat);
            AmountExclVat = AmountInclVat - Vat;
            Customer = customer;
            OrderItems = orderItems;
        }

        public long Id { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public string OrderNumber { get; set; }
        public decimal AmountInclVat { get; set; }
        public decimal Vat { get; set; }
        public decimal AmountExclVat { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public IReadOnlyList<OrderItem> OrderItems { get; set; }

        //### Temp
        private string GenerateOrderNumber()
        {

            return "000" + CustomerId;
        }

        private decimal CalculateVatAmount(decimal amountInclVat)
        {
            decimal Vat = (amountInclVat - (15/100));

            return Vat;
        }
    }
}
