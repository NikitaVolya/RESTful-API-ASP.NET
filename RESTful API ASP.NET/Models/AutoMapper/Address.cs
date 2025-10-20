using System.ComponentModel.DataAnnotations;

namespace RESTful_API_ASP.NET.Models.AutoMapper
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Street { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = null!;

        public IEnumerable<User> Users { get; set; }
    }
}
