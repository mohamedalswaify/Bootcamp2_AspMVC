using System.ComponentModel.DataAnnotations;

namespace Bootcamp2_AspMVC.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public int Qty { get; set; }    

        public string? Description { get; set; }
    }
}
