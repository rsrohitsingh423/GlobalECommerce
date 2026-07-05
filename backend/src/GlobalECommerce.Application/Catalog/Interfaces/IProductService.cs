using GlobalECommerce.Application.Catalog.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Application.Catalog.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();

        Task<ProductDto?> GetByIdAsync(Guid id);
        Task<ProductDto> CreateAsync(CreateProductRequest request);

        Task UpdateAsync(string id, UpdateProductRequest request);

        Task DeleteAsync(string id);
    }
}
