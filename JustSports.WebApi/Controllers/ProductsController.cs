using AutoMapper;
using JustSports.Core.Entities;
using JustSports.Core.Interfaces;
using JustSports.Core.Specifications;
using JustSports.WebApi.Helpers;
using JustSports.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustSports.WebApi.Controllers
{
    [Route(RouteMetadata.VERSION_1)]
    public class ProductsController : BaseController
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper _mapper;

        private readonly IProductRepository _productRepo;

        public ProductsController(ILogger<ProductsController> logger, IMapper mapper, IProductRepository productRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepo = productRepository;
        }

        //public async Task<ActionResult<Pagination<ProductToReturnDTO>>> GetAllAsync([FromQuery] ProductSpecParams productParams)
        //{
        //    var spec = new ProductWithTypesAndBrandsSpecification(productParams);
        //    var countSpec = new ProductWithFiltersForCountSpec(productParams);
        //    var totalItems = await _productsRepo.CounAsync(countSpec);
        //    var products = await _productsRepo.ListAsync(spec);

        //    var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products);
        //    return Ok(new Pagination<ProductToReturnDTO>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        //}

        //public async Task<ActionResult<Pagination<ProductData>>> GetAllAsync([FromQuery] ProductSpecParams productParams)
        //{
        //    var totalItems = await _productRepo.CounAsync(countSpec);
        //    var products = await _productsRepo.ListAsync(spec);

        //    var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products);
        //    return Ok(new Pagination<ProductToReturnDTO>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        //}

        /// <summary>
        /// Returns a paged list of all products
        /// </summary>
        /// <returns></returns>
        [HttpGet("products")]
        public async Task<IEnumerable<ProductData>> GetAllAsync()
        {
            var products = await _productRepo.GetProductsAsync();

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductData>>(products);

            return data;
        }

        /// <summary>
        /// Returns a product based on an identifier
        /// </summary>
        /// <param name="id">Product identifier</param>
        /// <returns></returns>
        [HttpGet("products/{id}")]
        public async Task<ActionResult<ProductData>> GetProduct(int id)
        {
            var product = await _productRepo.GetProductByIdAsync(id);

            var data = _mapper.Map<Product, ProductData>(product);

            return data;
        }
    }
}