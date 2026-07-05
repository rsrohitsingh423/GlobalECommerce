using Dapper;
using GlobalECommerce.Application.Orders.Interfaces;
using GlobalECommerce.Domain.Entities;
using GlobalECommerce.Infrastructure.Database;


namespace GlobalECommerce.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbConnectionFactory _factory;
        public OrderRepository(DbConnectionFactory dbConnectionFactory) 
        {
            _factory = dbConnectionFactory;
        }
        public async Task CreateAsync(Order order)
        {
            using var connection = _factory.CreateConnection();

            using var transaction = connection.BeginTransaction();

            await connection.ExecuteAsync(
                """
        INSERT INTO Orders
        (Id,OrderNumber,TotalAmount,Status,CreatedAt)

        VALUES
        (@Id,@OrderNumber,@TotalAmount,@Status,@CreatedAt)
        """,
                order,
                transaction);

            foreach (var item in order.Items)
            {
                await connection.ExecuteAsync(
                    """
            INSERT INTO OrderItems
            (Id,OrderId,ProductId,Quantity,UnitPrice)

            VALUES
            (@Id,@OrderId,@ProductId,@Quantity,@UnitPrice)
            """,
                    item,
                    transaction);
            }

            transaction.Commit();
        }

        public Task<IEnumerable<Order>> GetOrdersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
