using JustSports.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JustSports.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(long id);
        Task<IReadOnlyList<Product>> GetProductsAsync();        
    }
}