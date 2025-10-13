using Microsoft.EntityFrameworkCore;
using RESTful_API_ASP.NET.Models;

namespace RESTful_API_ASP.NET.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ComputerGame> ComputerGames { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
