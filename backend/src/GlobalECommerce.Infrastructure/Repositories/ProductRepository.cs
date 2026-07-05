using Dapper;
using GlobalECommerce.Application.Catalog.Interfaces;
using GlobalECommerce.Domain.Entities;
using GlobalECommerce.Infrastructure.Database;

namespace GlobalECommerce.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DbConnectionFactory _factory;

    public ProductRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        using var connection = _factory.CreateConnection();

        return await connection.QueryAsync<Product>(
            "SELECT Id, Name, Description, Price, Category, Stock, ImageUrl, CreatedAt FROM Products");
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        using var connection = _factory.CreateConnection();

        return await connection.QuerySingleOrDefaultAsync<Product>(
            "SELECT Id, Name, Description, Price, Category, Stock, ImageUrl, CreatedAt FROM FROM Products WHERE Id=@id",
            new { id });
    }

    public async Task CreateAsync(Product product)
    {
        using var connection = _factory.CreateConnection();

        await connection.ExecuteAsync("""
INSERT INTO Products
VALUES
(@Id,@Name,@Description,@Price,@Category,@Stock,@ImageUrl,@CreatedAt)
""", product);
    }

    public async Task UpdateAsync(Product product)
    {
        using var connection = _factory.CreateConnection();

        await connection.ExecuteAsync("""
UPDATE Products
SET
Name=@Name,
Description=@Description,
Price=@Price,
Category=@Category,
Stock=@Stock,
ImageUrl=@ImageUrl
WHERE Id=@Id
""", product);
    }

    public async Task DeleteAsync(Guid id)
    {
        using var connection = _factory.CreateConnection();

        await connection.ExecuteAsync(
            "DELETE FROM Products WHERE Id=@id",
            new { id });
    }
}