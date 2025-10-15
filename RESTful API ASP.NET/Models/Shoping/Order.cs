using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RESTful_API_ASP.NET.Models.Shoping
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be greater than zero.")]
        public decimal TotalAmount { get; set; }

        [Required]
        [JsonIgnore]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [JsonIgnore]
        public int ShopId { get; set; }

        public Shop Shop { get; set; }
    }
}
