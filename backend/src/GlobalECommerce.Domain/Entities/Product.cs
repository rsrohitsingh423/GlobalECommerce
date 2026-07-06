using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Domain.Entities
{
    public class Product
    {
        public string Id { get; set; } = String.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Category { get; set; } = string.Empty;

        public int Stock { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public double Rating { get; set; }

        public bool InStock { get; set; }

        public int DiscountPercentage { get; set; }
    }
}
