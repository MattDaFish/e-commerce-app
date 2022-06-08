using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustSports.WebApi.Models
{
    public class ProductData
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

        public int QuantityAvailable { get; set; }
        
    }
}
