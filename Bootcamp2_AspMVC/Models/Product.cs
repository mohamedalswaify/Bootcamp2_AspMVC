﻿using System.ComponentModel.DataAnnotations;

namespace Bootcamp2_AspMVC.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public string Category { get; set; }

        public int Qty { get; set; }    

        public string? Description { get; set; }
    }
}
