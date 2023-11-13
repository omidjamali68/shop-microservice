using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    public class CatalogSeedData
    {
        public static void SeedData(IMongoCollection<Product> products)
        {
            if (!products.Find(x => true).Any())
            {
                products.InsertMany(GetSeedProducts());
            }
        }

        private static IEnumerable<Product> GetSeedProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    Name = "Mouse",
                    Price = 10000,
                },
                new Product
                {
                    Name = "Keyboard",
                    Price = 20000,
                }
            };
        }
    }
}
