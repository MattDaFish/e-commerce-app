using AutoMapper;
using JustSports.Core.Entities;
using JustSports.Core.Interfaces;
using JustSports.WebApi.Helpers;
using JustSports.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustSports.WebApi.Controllers
{
    [Route(RouteMetadata.VERSION_1)]
    public class CustomersController : BaseController
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IMapper _mapper;

        private readonly ICustomerRepository _customerRepo;

        public CustomersController(ILogger<CustomersController> logger, IMapper mapper, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _customerRepo = customerRepository;
        }

        /// <summary>
        /// Returns a list of all customers
        /// </summary>
        /// <returns></returns>
        [HttpGet("customers")]
        public async Task<IEnumerable<CustomerData>> GetAllAsync()
        {
            var customers = await _customerRepo.GetCustomersAsync();

            var data = _mapper.Map<IReadOnlyList<Customer>, IReadOnlyList<CustomerData>>(customers);

            return data;
        }

        /// <summary>
        /// Returns a customer based on an identifier
        /// </summary>
        /// <param name="id">Customer identifier</param>
        /// <returns></returns>
        [HttpGet("customers/{id}")]
        public async Task<ActionResult<CustomerData>> GetCustomer(int id)
        {
            var customer = await _customerRepo.GetCustomerByIdAsync(id);

            var data = _mapper.Map<Customer, CustomerData>(customer);

            return data;
        }

        /// <summary>
        /// Updates an existing customer according to an identifier
        /// </summary>
        /// <param name="id">Customer identifier</param>
        /// <param name="resource">Updated customer data.</param>
        /// <returns></returns>
        [HttpPut("customers/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerData resource)
        {
            if (id != resource.Id)
                return BadRequest();

            var customer = _mapper.Map<CustomerData, Customer>(resource);

            var result = await _customerRepo.UpdateCustomerAsync(customer);

            if (!result.Success)
                return BadRequest(result.Message);

            var data = _mapper.Map<Customer, CustomerData>(result.Resource);

            return Ok(data);
        }
    }
}
