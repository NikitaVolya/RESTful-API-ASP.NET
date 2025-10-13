using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTful_API_ASP.NET.Data;
using RESTful_API_ASP.NET.Models;


namespace RESTful_API_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerGamesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComputerGamesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComputerGame>>> Get()
        {
            return Ok(await _context.ComputerGames.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComputerGame>> GetById(int id)
        {

            var computerGame = await _context.ComputerGames
                .FirstOrDefaultAsync(m => m.Id == id);

            if (computerGame == null)
            {
                return NotFound();
            }

            return Ok(computerGame);
        }

        [HttpPost]
        public async Task<ActionResult<ComputerGame>> Post(ComputerGame computerGame)
        {
            _context.ComputerGames.Add(computerGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = computerGame.Id }, computerGame);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ComputerGame computerGame)
        {
            if (id != computerGame.Id)
            {
                return BadRequest();
            }
            _context.Update(computerGame);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.ComputerGames.FirstOrDefaultAsync(cg => cg.Id == id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var computerGame = await _context.ComputerGames.FirstOrDefaultAsync(cg => cg.Id == id);
            if (computerGame == null)
            {
                return NotFound();
            }
            _context.ComputerGames.Remove(computerGame);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
