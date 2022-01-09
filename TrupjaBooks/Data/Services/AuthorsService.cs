using TrupjaBooks.Data.Models;
using TrupjaBooks.Data.Models.DTOs;

namespace TrupjaBooks.Data.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorDTO author)
        {
            var _author = new Author
            {
                Fullname = author.Fullname,
            };

            _context.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksDTO GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(x => x.Id == authorId)
                .Select(x => new AuthorWithBooksDTO
                {
                    Fullname = x.Fullname,
                    BookTitles = x.Book_Authors.Select(n => n.Book.Title).ToList()
                }).FirstOrDefault();

            return _author;
        }
    }
}
