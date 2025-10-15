using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RESTful_API_ASP.NET.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [JsonIgnore]
        public IEnumerable<Product> Products { get; set; }
    }
}
