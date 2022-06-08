using System.ComponentModel.DataAnnotations;

namespace JustSports.Core.Entities
{
    public class Product
    {
        public long Id { get; set; }

        [StringLength(120)]
        public string Name { get; set; } = string.Empty;

        [StringLength(150)]
        public string ImageUrl { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int QuantityAvailable { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
