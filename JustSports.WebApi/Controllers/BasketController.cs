using AutoMapper;
using JustSports.Core.Entities.BasketAggregate;
using JustSports.Core.Interfaces;
using JustSports.WebApi.Helpers;
using JustSports.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustSports.WebApi.Controllers
{
    [Route(RouteMetadata.VERSION_1)]
    public class BasketController : BaseController
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IMapper _mapper;

        private readonly IBasketRepository _basketRepo;

        public BasketController(ILogger<BasketController> logger, IMapper mapper, IBasketRepository basketRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _basketRepo = basketRepository;
        }

        /// <summary>
        /// Returns a basket based on the customer identifier
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns></returns>
        [HttpGet("basket/{customerId}")]
        public async Task<ActionResult<BasketData>> GetBasket(int customerId)
        {
            var basket = await _basketRepo.GetBasketByCustomerIdAsync(customerId);

            var data = _mapper.Map<Basket, BasketData>(basket);

            return data;
        }

        /// <summary>
        /// Create or update a customers basket
        /// </summary>
        /// <param name="basketData">Basket data</param>
        /// <returns></returns>
        [HttpPut("basket")]
        public async Task<IActionResult> UpsertBasket([FromBody] BasketData basketData)
        {
            var basket = _mapper.Map<BasketData, Basket>(basketData);
            
            var result = await _basketRepo.CreateOrUpdateBasketAsync(basket);

            if (!result.Success)
                return BadRequest(result.Message);

            var data = _mapper.Map<Basket, BasketData>(result.Resource);

            return Ok(data);
        }

        /// <summary>
        /// Delete a basket
        /// </summary>
        /// <param name="id">Basket identifier</param>
        /// <returns></returns>
        [HttpDelete("basket")]
        public async Task<IActionResult> DeleteBasket(long id)
        {
            var result = await _basketRepo.DeleteBasketAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok();
        }



    }
}
