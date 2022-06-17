using JustSports.Core.Entities.BasketAggregate;

namespace JustSports.Core.Communication
{
    public class BasketResponse : ServiceResponse<Basket>
    {
        public BasketResponse(Basket basket) : base(basket) { }

        public BasketResponse(string message) : base(message) { }
    }
}