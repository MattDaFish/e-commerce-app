using AutoMapper;
using JustSports.Core.Entities.OrderAggregate;
using JustSports.Core.Interfaces;
using JustSports.Core.Specifications;
using JustSports.WebApi.Helpers;
using JustSports.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustSports.WebApi.Controllers
{
    [Route(RouteMetadata.VERSION_1)]
    public class OrdersController : BaseController
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IMapper _mapper;

        private readonly IOrderRepository _orderRepo;

        public OrdersController(ILogger<OrdersController> logger, IMapper mapper, IOrderRepository orderRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _orderRepo = orderRepository;
        }

        /// <summary>
        /// Returns a paged list of all orders
        /// </summary>
        /// <returns></returns>
        [HttpGet("orders")]
        public async Task<IEnumerable<OrderData>> GetAllAsync()
        {
            var orders = await _orderRepo.GetOrdersAsync();

            var data = _mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderData>>(orders);

            return data;
        }

        /// <summary>
        /// Returns a paged list of all orders for a customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns></returns>
        [HttpGet("orders/{customerId}")]
        public async Task<IEnumerable<OrderData>> GetOrdersByCustomerIdAsync(int customerId)
        {
            var orders = await _orderRepo.GetOrdersByCustomerIdAsync(customerId);

            var data = _mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderData>>(orders);

            return data;
        }

        /// <summary>
        /// Returns an order based on an order identifier
        /// </summary>
        /// <param name="id">Product identifier</param>
        /// <returns></returns>
        [HttpGet("orders/{id}")]
        public async Task<ActionResult<OrderData>> GetOrderDetails(int id)
        {
            var order = await _orderRepo.GetOrderByIdAsync(id);

            var data = _mapper.Map<Order, OrderData>(order);

            return data;
        }

        /// <summary>
        /// Creates a new order
        /// </summary>
        /// <param name="orderData">Order data</param>
        /// <returns></returns>
        [HttpPost("orders")]
        public async Task<IActionResult> CreateOrder([FromBody] SaveOrderData orderData)
        {
            var result = await _orderRepo.CreateOrderAsync(orderData.BasketId, orderData.CustomerId);

            if (!result.Success)
                return BadRequest(result.Message);

            var data = _mapper.Map<Order, OrderData>(result.Resource);

            return Ok(data);
        }

    }
}