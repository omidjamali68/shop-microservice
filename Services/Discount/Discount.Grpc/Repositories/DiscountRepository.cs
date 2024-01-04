using Dapper;
using Discount.Grpc.Entities;
using Npgsql;

namespace Discount.Grpc.Repositories
{
    public class DiscountRepository : IDiscountRepository 
    {
        private NpgsqlConnection npgsqlConnection;

        public DiscountRepository(IConfiguration configuration)
        {
            npgsqlConnection = new NpgsqlConnection(
                configuration.GetValue<string>("PostgresSettings:ConnectionStrings"));
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            var affected = await npgsqlConnection.ExecuteAsync(
                "INSERT INTO Coupons (Id, ProductId, Description, Amount) "+
                "VALUES (@Id, @ProductId, @Description, @Amount)",
                new {Id = coupon.Id, ProductId = coupon.ProductId, Description = coupon.Description, Amount = coupon.Amount});

            return affected > 0;
        }

        public Task<bool> DeleteDiscount(string productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Coupon> GetDiscount(string productId)
        {            
            var coupon = await npgsqlConnection.QueryFirstOrDefaultAsync<Coupon>
                ("SELECT * FROM Coupons WHERE ProductId = @ProductId", new {ProductId = productId});

            return coupon ?? new Coupon();
        }

        public Task<bool> UpdateDiscount(Coupon coupon)
        {
            throw new NotImplementedException();
        }
    }
}
