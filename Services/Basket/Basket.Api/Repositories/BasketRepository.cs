using Basket.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Api.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task Delete(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

        public async Task<Order?> GetOrder(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);

            if (string.IsNullOrEmpty(basket))
                return null;

            return JsonConvert.DeserializeObject<Order?>(basket);
        }

        public async Task<Order> AddOrUpdate(Order order)
        {
            await _redisCache.SetStringAsync(order.UserName, JsonConvert.SerializeObject(order));

            return await GetOrder(order.UserName);
        }
    }
}
