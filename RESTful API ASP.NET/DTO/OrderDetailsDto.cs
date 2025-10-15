using RESTful_API_ASP.NET.Models.Shoping;

namespace RESTful_API_ASP.NET.DTO
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public User? User { get; set; }
        public Shop? Shop { get; set; }
    }
}
