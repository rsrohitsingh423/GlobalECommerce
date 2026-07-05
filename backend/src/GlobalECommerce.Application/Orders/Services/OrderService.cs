using GlobalECommerce.Application.Catalog.Interfaces;
using GlobalECommerce.Application.Orders.DTO;
using GlobalECommerce.Application.Orders.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Application.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderResponse> CreateAsync(CreateOrderRequest request)
        {
            // Business Logic
            throw new NotImplementedException();
        }
    }
}
