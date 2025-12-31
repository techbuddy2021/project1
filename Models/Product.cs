using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Color { get; set; }
        public int Price { get; set; }

        public string? Image { get; set; }
        public int CategoryId { get; set; }
    }
}
