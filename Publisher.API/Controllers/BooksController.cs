using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Publisher.API.Services;

namespace Publisher.API.Controllers
{
    [Route("api/[controller]")]
    public class BooksController: ControllerBase
    {
        private readonly IBookService _bookService;
        
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            var booksFromDb = _bookService.GetAllBooks();
            if (booksFromDb.Count != 0)
            {
                return Ok(booksFromDb);
            }
            return NotFound();
        }

        // GET api/books/authorName
        [HttpGet("{authorName}")]
        public IActionResult Get(string authorName)
        {
            var booksFromDb = _bookService.GetBooksByAuthor(authorName);
            if (booksFromDb.Count != 0)
            {
                return Ok(booksFromDb);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            if (_bookService.CreateBook(book))
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpDelete("{bookId}")]
        public IActionResult Delete(string bookId)
        {
            Guid id;
            Guid.TryParse(bookId, out id);
            if (_bookService.DeleteBook(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
