using Discount.Api.Entities;

namespace Discount.Api.Repositories
{
    public class DiscountRepository : IDiscountRepository 
    {
        public Task<bool> CreateDiscount(Coupon copoun)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDiscount(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<Coupon> GetDiscount(string productsId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDiscount(Coupon coupon)
        {
            throw new NotImplementedException();
        }
    }
}
