using LibraryManagementAPI.Data;
using LibraryManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EbookController : ControllerBase
    {
        private readonly LibraryContext _context;

        public EbookController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ebook>>> GetEbooks()
        {
            return await _context.Ebooks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ebook>> GetEbook(int id)
        {
            var ebook = await _context.Ebooks.FindAsync(id);
            if (ebook == null) return NotFound();
            return ebook;
        }

        [HttpPost]
        public async Task<ActionResult<Ebook>> PostEbook(Ebook ebook)
        {
            _context.Ebooks.Add(ebook);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEbook), new { id = ebook.Id }, ebook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEbook(int id)
        {
            var ebook = await _context.Ebooks.FindAsync(id);
            if (ebook == null) return NotFound();

            _context.Ebooks.Remove(ebook);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
