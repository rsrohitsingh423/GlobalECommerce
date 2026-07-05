namespace GlobalECommerce.Application.Orders.Commands.CreateOrder;
public record CreateOrderCommand(List<CreateOrderItem> Items);
public record CreateOrderItem(string ProductId,int Quantity);