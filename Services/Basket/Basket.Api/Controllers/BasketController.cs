using Basket.Api.Entities;
using Basket.Api.GrpcDiscount;
using Basket.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly DiscountGrpcService _discountGrpcService;

        public BasketController(IBasketRepository basketRepository, DiscountGrpcService discountGrpcService)
        {
            _basketRepository = basketRepository;
            _discountGrpcService = discountGrpcService;
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
            foreach (var item in order.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductId);
                item.Price -= coupon.Amount;
            }

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
