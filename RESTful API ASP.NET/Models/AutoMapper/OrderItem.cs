using System.ComponentModel.DataAnnotations;

namespace RESTful_API_ASP.NET.Models.AutoMapper
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } = null!;

        [Required]
        [Range(1, 30, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
