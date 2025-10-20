using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTful_API_ASP.NET.Models.AutoMapper
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Range(1, 100)]
        public int Age { get; set; }

        public Address Address { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }


        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
