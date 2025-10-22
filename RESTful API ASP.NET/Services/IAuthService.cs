using RESTful_API_ASP.NET.Models.Authorisation;


namespace RESTful_API_ASP.NET.Services
{
    public interface IAuthService
    {
        Task<LibUserModel?> ValidateUserAsync(string username, string password);
        string HashPassword(string password);
    }
}
