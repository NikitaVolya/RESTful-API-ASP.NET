using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTful_API_ASP.NET.Data;
using RESTful_API_ASP.NET.DTO.Authorisation;
using RESTful_API_ASP.NET.Models.Authorisation;

namespace RESTful_API_ASP.NET.Controllers.Authorisation
{
    [Route("api/[controller]")]
    public class LibBooksController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LibBooksController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("books")]
        [Authorize]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _context.LibBooks.ToListAsync();
            return Ok(books);
        }

        [HttpPost("books")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBook([FromBody] LibBookDto book)
        {
            LibBookModel bookModel = _mapper.Map<LibBookModel>(book);

            _context.LibBooks.Add(bookModel);
            await _context.SaveChangesAsync();
            return Ok(bookModel);
        }

        [HttpPut("books/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBook([FromBody] LibBookDto bookDto, [FromRoute] int id)
        {
            var existingBook = await _context.LibBooks.FindAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            _mapper.Map(bookDto, existingBook);
            _context.LibBooks.Update(existingBook);
            await _context.SaveChangesAsync();
            return Ok(existingBook);
        }

        [HttpDelete("books/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            var book = await _context.LibBooks.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _context.LibBooks.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
