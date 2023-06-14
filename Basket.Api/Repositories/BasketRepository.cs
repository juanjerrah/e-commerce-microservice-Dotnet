using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.Api.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task DeleteCart(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart?> GetCart(string userName)
        {
            var cart = await _redisCache.GetStringAsync(userName);

            return !string.IsNullOrEmpty(cart) ? JsonSerializer.Deserialize<Cart>(cart) : null;
        }

        public async Task<Cart?> UpdateCart(Cart cart)
        {
            await _redisCache.SetStringAsync(cart.UserName, JsonSerializer.Serialize(cart));

            return await GetCart(cart.UserName);
        }
    }
}
