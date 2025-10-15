using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RESTful_API_ASP.NET.Models.Shoping
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string? Location { get; set; }

        [JsonIgnore]
        public IEnumerable<Order> Orders { get; set; }
    }
}
