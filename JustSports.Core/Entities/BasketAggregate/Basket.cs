using JustSports.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustSports.Core.Entities.BasketAggregate
{
    public class Basket
    {
        public long Id { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public int CustomerId { get; set; }

        public bool IsDeleted { get; set; }
        
        public List<BasketItem> BasketItems { get; set; }

        public Basket()
        {
        }

        public Basket(int customerId)
        {
            CreatedDate = DateTimeOffset.Now;
            CustomerId = customerId;
        }

    }
}
