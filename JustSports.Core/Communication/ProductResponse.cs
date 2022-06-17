using JustSports.Core.Entities;

namespace JustSports.Core.Communication
{
    public class ProductResponse : ServiceResponse<Product>
    {
        public ProductResponse(Product product) : base(product) { }

        public ProductResponse(string message) : base(message) { }
    }
}