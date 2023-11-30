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
                    Id = "6568366671259bc9814ec3ed",
                    Category = "Computers",
                    Description = "Some Text",
                    ImageFile = "Image1",
                    Name = "Asus Laptop",
                    Price = 470.00M,
                    Summary = "No Summary"
                  },
                new Product
                {
                    Id = "6568366671259bc9814ec3ee",
                    Category = "Computers",
                    Description = "Some Other Text",
                    ImageFile = "Image2",
                    Name = "HP Laptop",
                    Price = 240.00M,
                    Summary = "With Summary"
                  }
            };
        }
    }
}
