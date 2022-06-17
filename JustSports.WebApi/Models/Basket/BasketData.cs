using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustSports.WebApi.Models
{
    public class BasketData
    {
        public long Id { get; set; }

        public int CustomerId { get; set; }

        public List<BasketItemData> BasketItems { get; set; }

    }
}
