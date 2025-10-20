using System.ComponentModel.DataAnnotations;

namespace RESTful_API_ASP.NET.DTO.AutoMapper
{
    public class UserDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 100)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public AddressDto Address { get; set; } = null!;
    }
}
