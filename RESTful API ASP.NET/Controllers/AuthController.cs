using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using RESTful_API_ASP.NET.Data;
using RESTful_API_ASP.NET.DTO;
using RESTful_API_ASP.NET.Models.Shoping;


namespace RESTful_API_ASP.NET.Controllers
{
    [Route("/api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            User? userData = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginDto.UserName);
            if (userData == null)
                return Unauthorized();

            if (loginDto.Password != "root")
                return Unauthorized();

            return Ok();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok(new { Message = "Logged out successfully" });
        }
    }
}
