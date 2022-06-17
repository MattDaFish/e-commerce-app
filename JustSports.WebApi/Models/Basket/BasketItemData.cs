using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustSports.WebApi.Models
{
    public class BasketItemData
    {
        public long Id { get; set; }

        //public long BasketId { get; set; }
        
        public long ProductId { get; set; }

        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
    }
}
