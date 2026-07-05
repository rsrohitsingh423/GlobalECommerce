using Dapper;

namespace GlobalECommerce.Infrastructure.Database;

public class SeedData
{
    private readonly DbConnectionFactory _factory;

    public SeedData(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task SeedAsync()
    {
        using var connection = _factory.CreateConnection();

        var count = await connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM Products");

        if (count > 0)
            return;

        await connection.ExecuteAsync("""
INSERT INTO Products
(Id,Name,Description,Price,Category,Stock,ImageUrl,CreatedAt)

VALUES

(@Id,@Name,@Description,@Price,@Category,@Stock,@ImageUrl,@CreatedAt)
""",

new[]
{
new
{
Id=Guid.NewGuid(),
Name="iPhone 16",
Description="Apple flagship phone",
Price=89999,
Category="Mobiles",
Stock=20,
ImageUrl="iphone.jpg",
CreatedAt=DateTime.UtcNow
},
new
{
Id=Guid.NewGuid(),
Name="MacBook Pro",
Description="M4 Pro",
Price=199999,
Category="Laptops",
Stock=10,
ImageUrl="macbook.jpg",
CreatedAt=DateTime.UtcNow
},
new
{
Id=Guid.NewGuid(),
Name="Sony Headphones",
Description="Noise Cancelling",
Price=29999,
Category="Audio",
Stock=15,
ImageUrl="sony.jpg",
CreatedAt=DateTime.UtcNow
}
});
    }
}