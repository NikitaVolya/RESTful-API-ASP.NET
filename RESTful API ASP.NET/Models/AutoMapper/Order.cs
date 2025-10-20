using System.ComponentModel.DataAnnotations;

namespace RESTful_API_ASP.NET.Models.AutoMapper
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }
    }
}
