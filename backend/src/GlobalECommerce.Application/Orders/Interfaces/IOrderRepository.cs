using GlobalECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Application.Orders.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order);

        Task<IEnumerable<Order>> GetOrdersAsync();
    }
}
