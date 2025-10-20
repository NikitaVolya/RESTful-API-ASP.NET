
namespace RESTful_API_ASP.NET.DTO.AutoMapper
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string UserName { get; set; } = null!;
        public int TotalItems { get; set; }
        public IEnumerable<string> ProductNames { get; set; } = null!;
    }
}
