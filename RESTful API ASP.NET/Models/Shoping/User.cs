using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RESTful_API_ASP.NET.Models.Shoping
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [JsonIgnore]
        public IEnumerable<Order> Orders { get; set; }
    }
}
