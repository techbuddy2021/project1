
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public required string CategoryDescription { get; set; }
    }
}
