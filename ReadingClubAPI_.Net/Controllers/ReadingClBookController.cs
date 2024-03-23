using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadingClubSPI_.Net.BusinessReadClBookLayer.Models.ReadingClBook;
using ReadingClubSPI_.Net.DataReadClBookLayer.Models;
using ReadingClubSPI_.Net.Services.Services.Contracts;

namespace ReadingClubSPI_.Net.Controllers
{
    /// <summary>
    /// Controller for managing books.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReadingClBookController : ControllerBase
    {
        private readonly IReadingClBookService _ReadingClBookService;

        public ReadingClBookController(IReadingClBookService bookService)
        {
            _ReadingClBookService = bookService;
        }

        /// <summary>
        /// Get all books.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReadingClBook>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var books = _ReadingClBookService.GetAll();
            return Ok(books);
        }

        /// <summary>
        /// Get a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book.</param>
        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadingClBook), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var book = _ReadingClBookService.GetById(id);
            return Ok(book);
        }

        /// <summary>
        /// Get a book by its ISBN.
        /// </summary>
        /// <param name="isbn">The ISBN of the book.</param>
        [AllowAnonymous]
        [HttpGet("{isbn}")]
        [ProducesResponseType(typeof(ReadingClBook), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetByIsbn(string isbn)
        {
            var book = _ReadingClBookService.GetByIsbn(isbn);
            return Ok(book);
        }

        /// <summary>
        /// Create a new book.
        /// </summary>
        /// <param name="book">The book to create.</param>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(ReadingClBook), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        public IActionResult Create([FromBody] CreateReadingClBook? book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            var createdReadingClBook = _ReadingClBookService.Create(book);
            return CreatedAtAction(nameof(GetById), new { id = createdReadingClBook.Id }, createdReadingClBook);
        }

        /// <summary>
        /// Update an existing book.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="book">The updated book data.</param>
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ReadingClBook), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Update(int id, [FromBody] UpdateReadingClBook? book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            var updatedBook = _ReadingClBookService.Update(id, book);
            return Ok(updatedBook);
        }

        /// <summary>
        /// Delete a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ReadingClBook), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedBook = _ReadingClBookService.Delete(id);
            return Ok(deletedBook);
        }
    }
}