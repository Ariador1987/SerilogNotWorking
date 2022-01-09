using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrupjaBooks.Data.Models.DTOs;
using TrupjaBooks.Data.Services;

namespace TrupjaBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody]AuthorDTO author)
        {
            _authorsService.AddAuthor(author);
            return StatusCode(201);
        }

        [HttpGet("get-author-with-books-by-id/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var author = _authorsService.GetAuthorWithBooks(id);
            return StatusCode(200, author);
        }
    }
}
