using Discount.Api.Entities;
using Discount.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Discount.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;

        public CouponsController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpGet("{productId}")]
        public async Task<Coupon> Get(string productId)
        {
            return await _discountRepository.GetDiscount(productId);
        }

        [HttpPost]
        public async Task<bool> Add(Coupon coupon)
        {
            return await _discountRepository.CreateDiscount(coupon);
        }
    }
}
