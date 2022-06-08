using System.ComponentModel.DataAnnotations;

namespace JustSports.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(40)]
        public string Name { get; set; } = string.Empty;
        
        //public IList<Product> Products { get; set; } = new List<Product>();
    }
}
