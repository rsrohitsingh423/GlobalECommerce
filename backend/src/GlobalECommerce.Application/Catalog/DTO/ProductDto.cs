using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Application.Catalog.DTO
{
    public class ProductDto
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Category { get; set; } = string.Empty;

        public int Stock { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}
