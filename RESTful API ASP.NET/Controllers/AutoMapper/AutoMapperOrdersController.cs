using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTful_API_ASP.NET.Data;
using RESTful_API_ASP.NET.Models.AutoMapper;
using RESTful_API_ASP.NET.DTO.AutoMapper;


namespace RESTful_API_ASP.NET.Controllers.AutoMapper
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoMapperOrdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _profile;

        public AutoMapperOrdersController(AppDbContext context, IMapper orderProfile) {
            _context = context;
            _profile = orderProfile;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Order> orders = await _context.AutoMapperOrders
                .Include(o => o.User)
                .Include(o => o.Items)
                .ToListAsync();
            var ordersDto = _profile.Map<List<OrderDto>>(orders);

            return Ok(ordersDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrderDto orderDto)
        {
            Order order = _profile.Map<Order>(orderDto);

            User? existingUser = await _context.AutoMapperUsers
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Name == order.User.Name);

            if (existingUser == null)
                return BadRequest("User does not exist");

            order.User = null;
            order.UserId = existingUser.Id;

            await _context.AddAsync(order);
            await _context.SaveChangesAsync();

            OrderDto result = _profile.Map<OrderDto>(order);

            return Ok(result);
        }
    }
}
