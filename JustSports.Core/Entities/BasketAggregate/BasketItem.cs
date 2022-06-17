using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustSports.Core.Entities.BasketAggregate
{
    public class BasketItem
    {
        public long Id { get; set; }

        public long BasketId { get; set; }
        public Basket Basket { get; set; }

        public long ProductId { get; set; }
        
        public decimal PurchasePrice { get; set; }
        
        public int Quantity { get; set; }

        public BasketItem()
        {
        }

        public BasketItem(long basketId, long productId, decimal price, int quantity)
        {
            BasketId = basketId;
            ProductId = productId;
            PurchasePrice = price;
            Quantity = quantity;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

    }
}
