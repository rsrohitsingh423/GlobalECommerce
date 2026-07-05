using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Application.Orders.DTO
{
    public class CreateOrderItemRequest
    {
        public string ProductId { get; set; } = "";

        public int Quantity { get; set; }
    }
}
