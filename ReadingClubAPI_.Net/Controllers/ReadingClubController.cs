using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadingClubAPI_.Net.Data;
using ReadingClubAPI_.Net.Entities;

namespace ReadingClubAPI_.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingClubController : ControllerBase
    {
        private readonly DataContext _context;

        public ReadingClubController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReadingClub>>> GetAllBooks()
        {
            var books = await _context.ReadingClubs.ToListAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReadingClub>>> GetBooks(int id)
        {
            var book = await _context.ReadingClubs.FindAsync(id);
            if (book is null)
                return NotFound("Book not found.");

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<List<ReadingClub>>> AddBooks([FromBody]ReadingClub book)
        {
            _context.ReadingClubs.Add(book);
            await _context.SaveChangesAsync();

            return Ok(await GetAllBooks());
        }

        [HttpPut]
        public async Task<ActionResult<List<ReadingClub>>> UpdateBook(ReadingClub updateBook)
        {
            var dbBook = await _context.ReadingClubs.FindAsync(updateBook.Id);
            if (dbBook is null)
                return NotFound("Book not found.");

            dbBook.Name = updateBook.Name;
            dbBook.FirstName = updateBook.FirstName;
            dbBook.LastName = updateBook.LastName;
            dbBook.Place = updateBook.Place;

            await _context.SaveChangesAsync();

            return Ok(await GetAllBooks());
        }

        [HttpDelete]
        public async Task<ActionResult<List<ReadingClub>>> UpdateBook(int id)
        {
            var dbBook = await _context.ReadingClubs.FindAsync(id);
            if (dbBook is null)
                return NotFound("Book not found.");

            _context.ReadingClubs.Remove(dbBook);
            await _context.SaveChangesAsync();

            return Ok(await GetAllBooks());
        }
    }
}
