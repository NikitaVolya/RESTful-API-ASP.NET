using System.ComponentModel.DataAnnotations;

namespace RESTful_API_ASP.NET.Models.Authorisation
{
    public class LibBookModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public string Genre { get; set; }
    }
}
