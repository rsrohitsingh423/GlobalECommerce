using GlobalECommerce.Application.Orders.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Application.Orders.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateAsync(CreateOrderRequest request);
    }
}
