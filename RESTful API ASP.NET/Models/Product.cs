using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RESTful_API_ASP.NET.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [JsonIgnore]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
