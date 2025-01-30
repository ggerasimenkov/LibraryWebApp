using LibraryWebApp.Data;
using LibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookApiController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BookApiController(LibraryContext context)
        {
            _context = context;
            if (!_context.Books.Any())
            {
                _context.Books.AddRange(
                    new Book { Title = "Сияние", Author = "Стивен Кинг", Year = 1977 },
                    new Book { Title = "Война и Мир", Author = "Лев Толстой", Year = 1869 },
                    new Book { Title = "Мастер и Маргарита", Author = "М.А. Булгаков", Year = 1940 }
                );
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBook(int id, [FromBody] Book book)
        {
            if (id != book.Id) return BadRequest();

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }
    }
}
