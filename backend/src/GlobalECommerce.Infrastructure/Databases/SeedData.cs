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
        //await connection.ExecuteAsync("INSERT INTO Products (Id, Name, Description, Price, ImageUrl, Rating, InStock, DiscountPercentage) VALUES\r\n('P001','Apple iPhone 16 Pro','256GB Natural Titanium',129999,'https://picsum.photos/300?1'),\r\n\r\n('P002','Samsung Galaxy S25 Ultra','512GB Titanium Black',124999,'https://picsum.photos/300?2'),\r\n\r\n('P003','Apple MacBook Air M4','13-inch 16GB RAM',139999,'https://picsum.photos/300?3'),\r\n\r\n('P004','Dell XPS 15','Intel Core Ultra 7, 32GB RAM',189999,'https://picsum.photos/300?4'),\r\n\r\n('P005','Sony WH-1000XM5','Wireless Noise Cancelling Headphones',29999,'https://picsum.photos/300?5'),\r\n\r\n('P006','Apple Watch Series 10','GPS + Cellular',54999,'https://picsum.photos/300?6'),\r\n\r\n('P007','Samsung Galaxy Tab S10','12.4-inch AMOLED',72999,'https://picsum.photos/300?7'),\r\n\r\n('P008','Logitech MX Master 3S','Wireless Productivity Mouse',9999,'https://picsum.photos/300?8'),\r\n\r\n('P009','Sony PlayStation 5 Slim','Disc Edition',54999,'https://picsum.photos/300?9'),\r\n\r\n('P010','LG UltraGear 32\" Monitor','4K IPS Gaming Monitor',45999,'https://picsum.photos/300?10');");
        await connection.ExecuteAsync("INSERT INTO Products (Id, Name, Description, Price, ImageUrl, Rating, InStock, DiscountPercentage) VALUES" +
                "\r\n('P001','Apple iPhone 16 Pro','256GB Natural Titanium',129999,'https://picsum.photos/300?1',4.8, true, 15)," +
            "\r\n\r\n('P002','Samsung Galaxy S25 Ultra','512GB Titanium Black',124999,'https://picsum.photos/300?2',4.5,true, 12)," +
            "\r\n\r\n('P003','Apple MacBook Air M4','13-inch 16GB RAM',139999,'https://picsum.photos/300?3',4.6,true,13)," +
            "\r\n\r\n('P004','Dell XPS 15','Intel Core Ultra 7, 32GB RAM',189999,'https://picsum.photos/300?4',4.2,true,16)," +
            "\r\n\r\n('P005','Sony WH-1000XM5','Wireless Noise Cancelling Headphones',29999,'https://picsum.photos/300?5',4.9,true,12)," +
            "\r\n\r\n('P006','Apple Watch Series 10','GPS + Cellular',54999,'https://picsum.photos/300?6',4.7,true,12)," +
            "\r\n\r\n('P007','Samsung Galaxy Tab S10','12.4-inch AMOLED',72999,'https://picsum.photos/300?7',4.9,true,10)," +
            "\r\n\r\n('P008','Logitech MX Master 3S','Wireless Productivity Mouse',9999,'https://picsum.photos/300?8',5.3,true,19)," +
            "\r\n\r\n('P009','Sony PlayStation 5 Slim','Disc Edition',54999,'https://picsum.photos/300?9',4.9,true,18)," +
            "\r\n\r\n('P010','LG UltraGear 32\" Monitor','4K IPS Gaming Monitor',45999,'https://picsum.photos/300?10',4.9,false,10);");
        //        await connection.ExecuteAsync("""
        //INSERT INTO Products
        //(Id,Name,Description,Price,Category,Stock,ImageUrl,CreatedAt)

        //VALUES

        //(@Id,@Name,@Description,@Price,@Category,@Stock,@ImageUrl,@CreatedAt)
        //""",

        //new[]
        //{
        //new
        //{
        //Id=Guid.NewGuid(),
        //Name="iPhone 16",
        //Description="Apple flagship phone",
        //Price=89999,
        //Category="Mobiles",
        //Stock=20,
        //ImageUrl="iphone.jpg",
        //CreatedAt=DateTime.UtcNow
        //},
        //new
        //{
        //Id=Guid.NewGuid(),
        //Name="MacBook Pro",
        //Description="M4 Pro",
        //Price=199999,
        //Category="Laptops",
        //Stock=10,
        //ImageUrl="macbook.jpg",
        //CreatedAt=DateTime.UtcNow
        //},
        //new
        //{
        //Id=Guid.NewGuid(),
        //Name="Sony Headphones",
        //Description="Noise Cancelling",
        //Price=29999,
        //Category="Audio",
        //Stock=15,
        //ImageUrl="sony.jpg",
        //CreatedAt=DateTime.UtcNow
        //}
        //});
    }
}