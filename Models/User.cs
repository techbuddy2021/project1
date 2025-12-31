using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public required string name { get; set; }
        [Required]
        public string? email { get; set; }

        [Required]
        public int phone { get; set; } 
    }
}
