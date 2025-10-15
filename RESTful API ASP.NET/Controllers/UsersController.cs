using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTful_API_ASP.NET.Data;
using RESTful_API_ASP.NET.Models;

namespace RESTful_API_ASP.NET.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // POST /api/users/{id}/activate
        [HttpPost("{id}/activate")]
        public async Task<IActionResult> ActivateUser([FromRoute] int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            return Ok(new { message = "User activated successfully", user });
        }

        [HttpPost("{id}/reset-password")]
        public async Task<IActionResult> ResetPassword([FromRoute] int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            return Ok(new { message = "Password reset successfully", userId = id });
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchUsers([FromQuery] string term)
        {
            var users = await _context.Users
                .Where(u => u.Username.Contains(term))
                .Select(u => new
                {
                    u.Id,
                    u.Username,
                    u.Email,
                })
                .ToListAsync();

            return Ok(users);
        }
    }
}
