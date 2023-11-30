using Catalog.Api.Entities;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task Add(Product product)
        {
            await _productRepository.Add(product);
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetProducts();
        }
    }
}
