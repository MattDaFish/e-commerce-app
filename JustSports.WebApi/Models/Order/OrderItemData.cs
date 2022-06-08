using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustSports.WebApi.Models
{
    public class OrderItemData
    {
        public long Id { get; set; }

        public ProductData ProductOrdered { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
