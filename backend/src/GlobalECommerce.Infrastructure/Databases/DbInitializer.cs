using Dapper;

namespace GlobalECommerce.Infrastructure.Database;

public class DbInitializer
{
    private readonly DbConnectionFactory _factory;

    public DbInitializer(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task InitializeAsync()
    {
        using var connection = _factory.CreateConnection();

        await connection.ExecuteAsync("""
        CREATE TABLE IF NOT EXISTS Products
        (
            Id TEXT PRIMARY KEY,
            Name TEXT NOT NULL,
            Description TEXT,
            Price REAL,
            Category TEXT,
            Stock INTEGER,
            ImageUrl TEXT,
            CreatedAt TEXT
        );
        """);
        await connection.ExecuteAsync("CREATE TABLE IF NOT EXISTS Orders (     Id TEXT PRIMARY KEY,     OrderNumber TEXT,     TotalAmount REAL,     Status TEXT,     CreatedAt TEXT );");
        await connection.ExecuteAsync("CREATE TABLE IF NOT EXISTS OrderItems (     Id TEXT PRIMARY KEY,     OrderId TEXT,     ProductId TEXT,     Quantity INTEGER,     UnitPrice REAL );");
    }
}