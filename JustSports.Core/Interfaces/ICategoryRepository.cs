using JustSports.Core.Communication;
using JustSports.Core.Entities;

namespace JustSports.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IReadOnlyList<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);

        Task<CategoryResponse> CreateCategoryAsync(Category category);
        Task<CategoryResponse> UpdateCategoryAsync(Category category);

    }
}