using Microsoft.EntityFrameworkCore;
using RESTful_API_ASP.NET.Models;
using RESTful_API_ASP.NET.Models.Authorisation;
using RESTful_API_ASP.NET.Models.Shoping;


namespace RESTful_API_ASP.NET.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ComputerGame> ComputerGames { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        // AutoMapper models
        public DbSet<Models.AutoMapper.User> AutoMapperUsers { get; set; }
        public DbSet<Models.AutoMapper.Address> AutoMapperAddresses { get; set; }
        public DbSet<Models.AutoMapper.Order> AutoMapperOrders { get; set; }
        public DbSet<Models.AutoMapper.OrderItem> AutoMapperOrderItems { get; set; }

        // Shoping models
        public DbSet<User> Users { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Order> Orders { get; set; }


        // Library models for JWT authentication Home Work
        public DbSet<LibUserModel> LibUsers { get; set; }
        public DbSet<LibBookModel> LibBooks { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Models.AutoMapper.User>()
                .HasOne(u => u.Address)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.AddressId);

            modelBuilder.Entity<Models.AutoMapper.Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Models.AutoMapper.Order>()
                .HasMany(o => o.Items)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            // Shoping relationships
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Shop)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.ShopId);
        }
    }
}
