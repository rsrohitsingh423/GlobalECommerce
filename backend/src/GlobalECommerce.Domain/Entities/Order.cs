using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Domain.Entities
{
    public class Order
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string OrderNumber { get; set; } = "";

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "Created";

        public DateTime CreatedAt { get; set; }

        public List<OrderItem> Items { get; set; } = [];
    }
}
