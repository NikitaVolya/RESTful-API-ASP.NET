using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTful_API_ASP.NET.Data;
using RESTful_API_ASP.NET.DTO;
using RESTful_API_ASP.NET.Models.Shoping;


namespace RESTful_API_ASP.NET.Controllers
{
    [ApiController]
    [Route("api/shops")]
    public class OrdersController : Controller
    {

        private readonly AppDbContext _context;

        public OrdersController(Data.AppDbContext context)
        {
            _context = context;
        }


        [Route("{shopId}/users/{userId}/orders/{orderId}")]
        [HttpGet]
        public async Task<IActionResult> GET([FromRoute]int shopId, [FromRoute] int userId, [FromRoute] int orderId, [FromQuery] bool includeDetails)
        {
            var orders = _context.Orders
                .Where(o => o.ShopId == shopId && o.UserId == userId && o.Id == orderId)
                .Include(o => o.User)
                .Include(o => o.Shop)
                .ToList();

            var result = from order in orders
                         select new OrderDetailsDto
                         {
                             Id = order.Id,
                             OrderDate = order.OrderDate,
                             TotalAmount = order.TotalAmount,
                             User = includeDetails ? order.User : null,
                             Shop = includeDetails ? order.Shop: null
                         };
            return Ok(result);
        }
    }
}
