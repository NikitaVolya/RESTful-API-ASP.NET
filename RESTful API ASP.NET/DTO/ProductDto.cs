using System.ComponentModel.DataAnnotations;

namespace RESTful_API_ASP.NET.DTO
{
    public class ProductDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
