using Catalog.Api.Entities;

namespace Catalog.Api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task Add(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string id);
    }
}
