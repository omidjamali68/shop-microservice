using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly ILogger<DiscountService> _logger;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository discountRepository, ILogger<DiscountService> logger, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public override async Task<CouponModel> GetByProductId(GetDiscountByIdRequest request, ServerCallContext context)
        {
            var coupon = await _discountRepository.GetDiscount(request.Id);

            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound,
                    $"Discount with productId {request.Id} not found"));
            }

            _logger.LogInformation("Discount is Retrived for Product Name");            

            return _mapper.Map<CouponModel>(coupon);
        }

        public override async Task<AddDiscountResponse> Add(AddDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);
            await _discountRepository.CreateDiscount(coupon);

            _logger.LogInformation($"Discount is successfully created for product {coupon.ProductId}.");

            return new AddDiscountResponse { Id = coupon.Id };
        }

    }
}
