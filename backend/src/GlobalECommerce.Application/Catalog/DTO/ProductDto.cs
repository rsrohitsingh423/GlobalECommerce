using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Application.Catalog.DTO
{
    public class ProductDto
    {
        public string Id { get; set; } = "";

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = "";

        public double Rating { get; set; }

        public bool InStock { get; set; }

        public int DiscountPercentage { get; set; }
    }
}
