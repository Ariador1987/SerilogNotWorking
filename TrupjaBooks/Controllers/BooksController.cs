using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrupjaBooks.Data.Models;
using TrupjaBooks.Data.Models.DTOs;
using TrupjaBooks.Data.Services;

namespace TrupjaBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody] BookDTO book)
        {
            _booksService.AddBookWithAuthors(book);
            return StatusCode(201, book);
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var books = _booksService.GetBooks();
            return StatusCode(200, books);
        }

        //[Route("get-book-by-id")]
        [HttpGet("get-book-by-id/{id:int}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return StatusCode(200, book);
        }

        [HttpPut("update-book-by-id/{id:int}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookDTO book)
        {
            var updatedBook = _booksService.UpdateBookById(id, book);
            return StatusCode(200, updatedBook);
        }

        [HttpDelete("delete-book-by-id/{id:int}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return StatusCode(204);
        }
    }
}
