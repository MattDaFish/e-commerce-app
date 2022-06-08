using AutoMapper;
using JustSports.Core.Entities;
using JustSports.Core.Interfaces;
using JustSports.WebApi.Helpers;
using JustSports.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustSports.WebApi.Controllers
{
    [Route(RouteMetadata.VERSION_1)]
    public class AccountsController : BaseController
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IMapper _mapper;

        private readonly IAccountRepository _accountRepo;

        public AccountsController(ILogger<AccountsController> logger, IMapper mapper, IAccountRepository accountRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _accountRepo = accountRepository;
        }

        /// <summary>
        /// Registers a new customer account
        /// </summary>
        /// <param name="accountSignup"></param>
        /// <returns></returns>
        [HttpPost("accounts/sign-up")]
        public async Task<IActionResult> SignUpAsync([FromBody] AccountSignup accountSignup)
        {
            var customer = _mapper.Map<AccountSignup, Customer>(accountSignup);

            var result = await _accountRepo.RegisterCustomerAccountAsync(customer);

            if (!result.Success)
                return BadRequest(result.Message);

            var data = _mapper.Map<Customer, AccountSignupResponse>(result.Resource);

            return Ok(data);
        }

        /// <summary>
        /// Initiates the authentication flow as a customer
        /// </summary>
        /// <param name="authenticateAccount"></param>
        /// <returns></returns>
        [HttpPost("accounts/authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticateAccount authenticateAccount)
        {
            var customer = _mapper.Map<AuthenticateAccount, Customer>(authenticateAccount);

            var result = await _accountRepo.AuthenticateCustomerAccountAsync(customer);

            var data = _mapper.Map<Customer, AuthenticateAccount>(result);

            return Ok(data);
        }

    }
}
