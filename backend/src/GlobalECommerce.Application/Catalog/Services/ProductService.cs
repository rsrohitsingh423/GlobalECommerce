using GlobalECommerce.Application.Catalog.DTO;
using GlobalECommerce.Application.Catalog.Interfaces;
using GlobalECommerce.Application.Orders.Services;
using Microsoft.Extensions.Logging;

namespace GlobalECommerce.Application.Catalog.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository repository, ILogger<ProductService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task<ProductDto> CreateAsync(CreateProductRequest request)
        {
            if (request.Price <= 0)
                throw new ArgumentException("Price must be greater than zero.");
            

            if (request.Stock < 0)
                throw new ArgumentException("Stock cannot be negative.");
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            _logger.LogInformation("Fetching all products.");
            var products = await _repository.GetAllAsync();

            _logger.LogInformation("Retrieved {Count} products.",products.Count());

            return products.Select(x => new ProductDto
            {
                Id = x.Id,

                Name = x.Name,

                Description = x.Description,

                Price = x.Price,

                ImageUrl = x.ImageUrl,

                Rating = x.Rating,

                InStock = x.InStock,

                DiscountPercentage = x.DiscountPercentage
            });
        }

        public async Task<ProductDto?> GetByIdAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                InStock = product.InStock,
                ImageUrl = product.ImageUrl,
                Rating = product.Rating,
                DiscountPercentage = product.DiscountPercentage
            };
        }

        public Task UpdateAsync(string id, UpdateProductRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
