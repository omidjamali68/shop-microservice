using Basket.Api.Entities;

namespace Basket.Api.Repositories
{
    public interface IBasketRepository
    {
        Task<Order?> GetOrder(string userName);
        Task<Order> AddOrUpdate(Order order);
        Task Delete(string userName);
    }
}
