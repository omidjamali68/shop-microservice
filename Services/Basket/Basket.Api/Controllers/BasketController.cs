using Basket.Api.Entities;
using Basket.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<Order>> GetBasket(string userName)
        {
            var basket = await _basketRepository.GetOrder(userName);
            return Ok(basket ?? new Order(userName));
        }

        [HttpPost]
        public async Task<ActionResult<Order>> AddOrUpdate([FromBody] Order order)
        {
            return Ok(await _basketRepository.AddOrUpdate(order));
        }

        [HttpDelete("{userName}")]
        public async Task<ActionResult> Delete(string userName)
        {
            await _basketRepository.Delete(userName);
            return Ok();
        }
    }
}
