using Discount.Grpc.Protos;

namespace Basket.Api.GrpcDiscount
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _client;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient client)
        {
            _client = client;
        }

        public async Task<CouponModel> GetDiscount(string productId)
        {
            return await _client.GetByProductIdAsync(new GetDiscountByIdRequest
            {
                Id = productId
            });
        }
    }
}
