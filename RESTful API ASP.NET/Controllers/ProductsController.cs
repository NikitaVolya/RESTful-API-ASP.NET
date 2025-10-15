using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTful_API_ASP.NET.Data;
using RESTful_API_ASP.NET.DTO;
using RESTful_API_ASP.NET.Models;


namespace RESTful_API_ASP.NET.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("/api/products/{categoryId}/{productId}")]
        public async Task<ActionResult<Product>> GET(int categoryId, int productId)
        {
            Product? product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == productId && p.CategoryId == categoryId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("/api/products/search")]
        public async Task<ActionResult<IEnumerable<Product>>> Search(
            [FromQuery] string? name,
            [FromQuery] decimal? minPrice, 
            [FromQuery] decimal? maxPrice,
            [FromQuery] int? categoryId)
        {
            IEnumerable<Product> products = await _context.Products.Include(p => p.Category).ToListAsync();
            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }
            if (minPrice.HasValue)
            {
                products = products.Where(p => p.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                products = products.Where(p => p.Price <= maxPrice.Value);
            }
            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value);
            }

            return Ok(products.ToList());
        }


        [HttpPost("/api/products")]
        public async Task<IActionResult> POST([FromBody]ProductDto productData)
        {
            if (await _context.Categories.FindAsync(productData.CategoryId) == null)
            {
                return BadRequest($"Category with Id {productData.CategoryId} does not exist.");
            }

            Product product = new Product
            {
                Name = productData.Name,
                Price = productData.Price,
                CategoryId = productData.CategoryId
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
