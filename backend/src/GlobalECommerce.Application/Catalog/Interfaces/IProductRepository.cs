using GlobalECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Application.Catalog.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(Guid id);

        Task CreateAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(Guid id);
    }
}
