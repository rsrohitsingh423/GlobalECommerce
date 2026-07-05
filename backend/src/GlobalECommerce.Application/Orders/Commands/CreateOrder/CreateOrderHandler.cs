using GlobalECommerce.Application.Catalog.Interfaces;
using GlobalECommerce.Application.Orders.DTO;
using GlobalECommerce.Application.Orders.Interfaces;
using GlobalECommerce.Domain.Entities;


namespace GlobalECommerce.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public CreateOrderHandler(
        IProductRepository productRepository,
        IOrderRepository orderRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    public async Task<OrderResponse> Handle(CreateOrderRequest request)
    {
        throw new NotImplementedException();
        //var products = (await _productRepository.GetAllAsync())
        //    .ToDictionary(x => x.Id);

        //decimal total = 0;

        //var order = new Order
        //{
        //    OrderNumber = $"ORD-{DateTime.UtcNow:yyyyMMddHHmmss}",
        //    Status = "Created",
        //    CreatedAt = DateTime.UtcNow
        //};

        //foreach (var item in request.Items)
        //{
        //    if (!products.TryGetValue(item.ProductId, out var product))
        //        throw new Exception($"Product {item.ProductId} not found.");

        //    if (item.Quantity <= 0)
        //        throw new Exception("Quantity should be greater than zero.");

        //    total += product.Price * item.Quantity;

        //    order.Items.Add(new OrderItem
        //    {
        //        OrderId = order.Id,
        //        ProductId = product.Id,
        //        Quantity = item.Quantity,
        //        UnitPrice = product.Price
        //    });
        //}

        //order.TotalAmount = total;

        //await _orderRepository.CreateAsync(order);

        //return new OrderResponse
        //{
        //    OrderId = order.Id,
        //    OrderNumber = order.OrderNumber,
        //    TotalAmount = order.TotalAmount,
        //    Status = order.Status
        //};
    }
}