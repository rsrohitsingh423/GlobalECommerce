using GlobalECommerce.Application.Catalog.Interfaces;
using GlobalECommerce.Application.Orders.DTO;
using GlobalECommerce.Application.Orders.Interfaces;
using GlobalECommerce.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Application.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<OrderService> _logger;
        public OrderService(
            IOrderRepository orderRepository,
            IProductRepository productRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<OrderResponse> CreateAsync(CreateOrderRequest request)
        {
            _logger.LogInformation("Starting order creation.");
            var products = (await _productRepository.GetAllAsync())
           .ToDictionary(x => x.Id);

            decimal total = 0;

            var order = new Order
            {
                OrderNumber = $"ORD-{DateTime.UtcNow:yyyyMMddHHmmss}",
                Status = "Created",
                CreatedAt = DateTime.UtcNow
            };

            foreach (var item in request.Items)
            {
                if (!products.TryGetValue(item.ProductId, out var product))
                {
                    _logger.LogWarning("Product {ProductId} not found.",item.ProductId);
                    throw new KeyNotFoundException($"Product '{item.ProductId}' not found.");
                }
                
                total += product.Price * item.Quantity;

                order.Items.Add(new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                });
            }

            order.TotalAmount = total;
            _logger.LogInformation("Order total calculated: {Total}",total);
            await _orderRepository.CreateAsync(order);
            _logger.LogInformation("Order {OrderNumber} created successfully.",order.OrderNumber);

            return new OrderResponse
            {
                OrderId = order.Id,
                OrderNumber = order.OrderNumber,
                TotalAmount = order.TotalAmount,
                Status = order.Status
            };
        }
    }
}
