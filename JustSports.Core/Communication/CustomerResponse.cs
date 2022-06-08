using JustSports.Core.Entities;

namespace JustSports.Core.Communication
{
    public class CustomerResponse : BaseResponse<Customer>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="customer">Saved customer.</param>
        /// <returns>Response.</returns>
        public CustomerResponse(Customer customer) : base(customer) { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CustomerResponse(string message) : base(message) { }
    }
}