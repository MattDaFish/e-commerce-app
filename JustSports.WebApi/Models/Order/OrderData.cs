using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustSports.WebApi.Models
{
    public class OrderData
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

        public IReadOnlyList<OrderItemData> OrderItems { get; set; }
        
    }
}
