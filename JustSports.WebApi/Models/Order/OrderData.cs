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

        public CustomerData Customer { get; set; }

        public IReadOnlyList<OrderItemData> OrderItems { get; set; }
        
        public decimal Subtotal { get; set; }

        public string Status { get; set; }

    }
}
