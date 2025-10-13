

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RESTful_API_ASP.NET.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class ComputerGame
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public decimal Price { get; set; }
    }
}
