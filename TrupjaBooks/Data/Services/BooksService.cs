using TrupjaBooks.Data.Models;
using TrupjaBooks.Data.Models.DTOs;

namespace TrupjaBooks.Data.Services
{
    public class BooksService
    {
        private readonly AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBookWithAuthors(BookDTO book)
        {
            var _book = new Book
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rating = book?.Rating ?? null,
                Genre = book.Genre,
                // jer sad imamo author id , ovo svojstvo je nepotrebno
                //Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId
            };

            _context.Books.Add(_book);
            _context.SaveChanges();

            // nakon što smo dodali knjigu u database
            // dodajemo vezu knjige i book_authors table-a
            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author
                {
                    BookId = _book.Id,
                    AuthorId = id
                };

                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }

        }

        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public BookWithAuthorsDTO GetBookById(int id)
        {
            //var book = _context.Books.Find(id);
            var _bookWithAuthors = _context.Books.Where(x => x.Id == id).Select(book => new BookWithAuthorsDTO
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rating = book.Rating.Value,
                Genre = book.Genre,
                // jer sad imamo author id , ovo svojstvo je nepotrebno
                //Author = book.Author,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(x => x.Author.Fullname).ToList()
            }).FirstOrDefault();

            return _bookWithAuthors;
        }

        public Book UpdateBookById(int id, BookDTO book)
        {
            var bookToUpdate = _context.Books.Find(id);

            if (bookToUpdate is not null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Description = book.Description;
                bookToUpdate.IsRead = book.IsRead;
                bookToUpdate.DateRead = book.IsRead ? book.DateRead.Value : null;
                bookToUpdate.Rating = book?.Rating ?? null;
                bookToUpdate.Genre = book.Genre;
                bookToUpdate.CoverUrl = book.CoverUrl;

                //_context.Books.Update(bookToUpdate);
                _context.SaveChanges();
            }
            return bookToUpdate;
        }

        public void DeleteBookById(int id)
        {
            var bookToDel = _context.Books.Find(id);
            if (bookToDel is not null)
            {
                _context.Remove(bookToDel);
                _context.SaveChanges();
            }
        }
    }
}
