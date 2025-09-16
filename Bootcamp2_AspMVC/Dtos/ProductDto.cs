﻿namespace Bootcamp2_AspMVC.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string uid { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}
