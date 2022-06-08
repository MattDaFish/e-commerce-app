using Infrastructure.Data;
using JustSports.Core.Entities;
using JustSports.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace JustSports.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(JustSportsDBContext context) : base(context)
        {
        }

        public async Task<Product> GetProductByIdAsync(long id)
        {
            return await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
            .Include(p => p.Category)
            .ToListAsync();
        }

    }
}