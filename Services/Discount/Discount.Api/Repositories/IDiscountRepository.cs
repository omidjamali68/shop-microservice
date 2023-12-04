using Discount.Api.Entities;

namespace Discount.Api.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string productsId);
        Task<bool> CreateDiscount(Coupon copoun);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string productId);
    }
}
