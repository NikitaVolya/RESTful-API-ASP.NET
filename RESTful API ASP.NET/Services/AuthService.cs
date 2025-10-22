using Microsoft.EntityFrameworkCore;
using RESTful_API_ASP.NET.Data;
using RESTful_API_ASP.NET.Models.Authorisation;
using System.Security.Cryptography;
using System.Text;

namespace RESTful_API_ASP.NET.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<LibUserModel?> ValidateUserAsync(string username, string password)
        {
            var hash = HashPassword(password);
            return await _context.LibUsers
                    .FirstOrDefaultAsync(u => u.Username == username && u.Password == hash);
        }

        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
