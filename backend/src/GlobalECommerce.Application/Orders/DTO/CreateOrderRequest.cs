using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Application.Orders.DTO
{
    public class CreateOrderRequest
    {
        public List<CreateOrderItemRequest> Items { get; set; } = [];
    }

    //public class CreateOrderItemRequest
    //{
    //    public string ProductId { get; set; } = "";

    //    public int Quantity { get; set; }
    //}
}
