using LibraryManagementAPI.Data;
using LibraryManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicalBookController : ControllerBase
    {
        private readonly LibraryContext _context;

        public PhysicalBookController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhysicalBook>>> GetPhysicalBooks()
        {
            return await _context.PhysicalBooks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhysicalBook>> GetPhysicalBook(int id)
        {
            var book = await _context.PhysicalBooks.FindAsync(id);
            if (book == null) return NotFound();
            return book;
        }

        [HttpPost]
        public async Task<ActionResult<PhysicalBook>> PostPhysicalBook(PhysicalBook book)
        {
            _context.PhysicalBooks.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPhysicalBook), new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhysicalBook(int id)
        {
            var book = await _context.PhysicalBooks.FindAsync(id);
            if (book == null) return NotFound();

            _context.PhysicalBooks.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
