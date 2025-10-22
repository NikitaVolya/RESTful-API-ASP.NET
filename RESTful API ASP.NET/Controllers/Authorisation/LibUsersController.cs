using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RESTful_API_ASP.NET.Data;
using RESTful_API_ASP.NET.Models.Authorisation;
using RESTful_API_ASP.NET.DTO.Authorisation;
using RESTful_API_ASP.NET.Services;
using System.Threading.Tasks;


namespace RESTful_API_ASP.NET.Controllers.Authorisation
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibUsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LibUsersController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LibUserLoginDto model) { 

            LibUserModel? userValidated = await new AuthService(_context)
                .ValidateUserAsync(model.Username, model.Password);

            if (userValidated == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("Це_дуже_секретний_ключ");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userValidated.Username),
                    new Claim(ClaimTypes.Role, userValidated.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] LibUserDto model)
        {
            if (model.Role != "Admin" && model.Role != "User")
            {
                return BadRequest("Invalide role.");
            }

            var existingUser = _context.LibUsers
                .FirstOrDefault(u => u.Username == model.Username);
            if (existingUser != null)
            {
                return BadRequest("Username already exists.");
            }
            var newUser = new LibUserModel
            {
                Username = model.Username,
                Password = new AuthService(_context).HashPassword(model.Password),
                Role = model.Role
            };
            _context.LibUsers.Add(newUser);
            _context.SaveChanges();
            return Ok("User registered successfully.");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("secret")]
        public IActionResult SecretData()
        {
            return Ok("This is a secret message for Admins only!");
        }
    }
}
