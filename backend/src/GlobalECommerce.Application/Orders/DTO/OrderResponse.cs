using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Application.Orders.DTO
{
    public class OrderResponse
    {
        public string OrderId { get; set; } = "";

        public string OrderNumber { get; set; } = "";

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "";
    }
}
