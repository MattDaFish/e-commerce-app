using Infrastructure.Data;
using JustSports.Core.Communication;
using JustSports.Core.Entities;
using JustSports.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JustSports.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(JustSportsDBContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
        {
            return await _context.Categories
            .OrderBy(x => x.Name)
            .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories
                .FindAsync(id);
        }

        public async Task<CategoryResponse> CreateCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return new CategoryResponse(category);
        }

        public async Task<CategoryResponse> UpdateCategoryAsync(Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(category.Id);

            if (existingCategory == null)
                return new CategoryResponse("Category not found.");

            existingCategory.Name = category.Name;

            await _context.SaveChangesAsync();

            return new CategoryResponse(category);
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}