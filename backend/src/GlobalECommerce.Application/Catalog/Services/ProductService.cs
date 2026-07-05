using GlobalECommerce.Application.Catalog.DTO;
using GlobalECommerce.Application.Catalog.Interfaces;

namespace GlobalECommerce.Application.Catalog.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
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
            var products = await _repository.GetAllAsync();

            return products.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Category = x.Category,
                Stock = x.Stock,
                ImageUrl = x.ImageUrl
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
                Category = product.Category,
                Stock = product.Stock,
                ImageUrl = product.ImageUrl
            };
        }

        public Task UpdateAsync(string id, UpdateProductRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
