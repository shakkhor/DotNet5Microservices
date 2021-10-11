using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task<bool> EmptyCart(string userId)
        {
            await _redisCache.RemoveAsync(userId);
            return true;
        }

        public async Task<ShoppingCart> GetShoppingCart(string userId)
        {
            var basket = await _redisCache.GetStringAsync(userId);

            if(!string.IsNullOrEmpty(basket))
            {
                return JsonConvert.DeserializeObject<ShoppingCart>(basket);
            }

            return new ShoppingCart();
        }

        public async Task<ShoppingCart> UpdateShoppingCart(ShoppingCart shoppingCart)
        {
           await _redisCache.SetStringAsync(shoppingCart.UserId, JsonConvert.SerializeObject(shoppingCart));

            return await GetShoppingCart(shoppingCart.UserId);
        }
    }
}
