using AutoMapper;
using JustSports.Core.Entities;
using JustSports.Core.Interfaces;
using JustSports.WebApi.Helpers;
using JustSports.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustSports.WebApi.Controllers
{
    [Route(RouteMetadata.VERSION_1)]
    public class CategoriesController : BaseController
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IMapper _mapper;

        private readonly ICategoryRepository _categoryRepo;

        public CategoriesController(ILogger<CategoriesController> logger, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _categoryRepo = categoryRepository;
        }

        /// <summary>
        /// Returns a list of all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet("categories")]
        public async Task<IEnumerable<CategoryData>> GetAllAsync()
        {
            var categories = await _categoryRepo.GetCategoriesAsync();

            var data = _mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoryData>>(categories);

            return data;
        }

        /// <summary>
        /// Returns a category based on an identifier
        /// </summary>
        /// <param name="id">Category identifier</param>
        /// <returns></returns>
        [HttpGet("categories/{id}")]
        public async Task<ActionResult<CategoryData>> GetCategory(int id)
        {
            var category = await _categoryRepo.GetCategoryByIdAsync(id);

            var data = _mapper.Map<Category, CategoryData>(category);

            return data;
        }

        /// <summary>
        /// Saves a new category
        /// </summary>
        /// <param name="categoryData">Category data</param>
        /// <returns></returns>
        [HttpPost("categories")]
        public async Task<IActionResult> CreateCategory(SaveCategoryData categoryData)
        {
            var category = _mapper.Map<SaveCategoryData, Category>(categoryData);

            var result = await _categoryRepo.CreateCategoryAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var data = _mapper.Map<Category, SaveCategoryData>(result.Resource);

            return Ok(data);
        }

        /// <summary>
        /// Updates an existing category according to an identifier
        /// </summary>
        /// <param name="id">Category identifier</param>
        /// <param name="categoryData">Updated category data.</param>
        /// <returns></returns>
        [HttpPut("categories/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryData categoryData)
        {
            if (id != categoryData.Id)
                return BadRequest();

            var category = _mapper.Map<CategoryData, Category>(categoryData);

            var result = await _categoryRepo.UpdateCategoryAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var data = _mapper.Map<Category, CategoryData>(result.Resource);

            return Ok(data);
        }

    }
}
