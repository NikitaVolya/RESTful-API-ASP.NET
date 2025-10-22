namespace RESTful_API_ASP.NET.DTO.Authorisation
{
    public class LibBookDto
    {
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int PublishedYear { get; set; }
        public string Genre { get; set; } = null!;
    }
}
