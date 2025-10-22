using System.ComponentModel.DataAnnotations;

namespace RESTful_API_ASP.NET.Models.Authorisation
{
    public class LibUserModel
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
