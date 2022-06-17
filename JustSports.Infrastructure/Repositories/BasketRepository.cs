using Infrastructure.Data;
using JustSports.Core.Communication;
using JustSports.Core.Entities.BasketAggregate;
using JustSports.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JustSports.Infrastructure.Repositories
{
    public class BasketRepository : BaseRepository, IBasketRepository
    {
        public BasketRepository(JustSportsDBContext context) : base(context)
        {
        }

        public async Task<Basket> GetBasketByCustomerIdAsync(int customerId)
        {
            var basket = await _context.Baskets
                .Include(x => x.BasketItems)
                .Where(x => x.IsDeleted == false && x.CustomerId == customerId)
                .FirstOrDefaultAsync();

            if (basket == null)
                basket = new Basket(customerId);

            return basket;

        }

        public async Task<BasketResponse> CreateOrUpdateBasketAsync(Basket basket)
        {
            if (basket.Id == 0)
                basket.Id = await CreateBasketForCustomer(basket.CustomerId);

            var itemToAdd = basket.BasketItems.FirstOrDefault();

            if (itemToAdd != null)
            {
                await AddOrUpdateBasketItem(basket.Id, itemToAdd);

                await _context.SaveChangesAsync();
            }

            var updatedBasket = await _context.Baskets.FindAsync(basket.Id);

            return new BasketResponse(updatedBasket);
        }

        private async Task<long> CreateBasketForCustomer(int customerId)
        {
            //### Return basket if found
            var basketExists = await _context.Baskets
                .Where(x => x.IsDeleted == false && x.CustomerId == customerId)
                .FirstOrDefaultAsync();

            if (basketExists != null)
                return basketExists.Id;

            //### Create new basket
            var basket = new Basket(customerId);

            await _context.Baskets.AddAsync(basket);
            await _context.SaveChangesAsync();

            return basket.Id;
        }

        private async Task AddOrUpdateBasketItem(long basketId, BasketItem itemToAdd)
        {
            //### Return basket if found
            var basketItem = await _context.BasketItems
                .Where(x => x.BasketId == basketId && x.ProductId == itemToAdd.ProductId)
                .FirstOrDefaultAsync();

            if (basketItem != null)
            {
                basketItem.Quantity += 1;
            }
            else
            {
                basketItem = new BasketItem(basketId, itemToAdd.ProductId, itemToAdd.PurchasePrice, 1);
                
                await _context.BasketItems.AddAsync(basketItem);

            }

            //return basketItem;
        }

        public async Task<BasketResponse> DeleteBasketAsync(long id)
        {
            var basket = await _context.Baskets.FindAsync(id);

            if (basket == null)
                return new BasketResponse("Basket not found.");

            //### Remove any basket items
            //_context.BasketItems.RemoveRange(basket.BasketItems);
            //_context.Baskets.Remove(basket);

            basket.IsDeleted = true;

            await _context.SaveChangesAsync();

            return new BasketResponse(basket);
        }

    }
}