using System.Text.RegularExpressions;
using TrupjaBooks.Data.Models;
using TrupjaBooks.Data.Models.DTOs;
using TrupjaBooks.Data.Paging;
using TrupjaBooks.Exceptions;

namespace TrupjaBooks.Data.Services
{
    public class PublisherService
    {
        private readonly AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public Publisher AddPublisher(PublisherDTO publisher)
        {
            // korištenje privatne metode koju smo definirali na dnu servisa
            if (StringStartsWithNumber(publisher.Name))
                throw new PublisherNameException("Name starts with number", publisher.Name);

            var _publisher = new Publisher
            {
                Name = publisher.Name,
            };

            _context.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherById(int id) => _context.Publishers.Find(id);

        public PublisherWithBooksAndAuthorsDTO GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers
                .Where(x => x.Id == publisherId)
                .Select(x => new PublisherWithBooksAndAuthorsDTO
                {
                    Name = x.Name,
                    BookAuthors = x.Books.Select(x => new BookAuthorDTO
                    {
                        BookName = x.Title,
                        BookAuthors = x.Book_Authors.Select(x => x.Author.Fullname).ToList()
                    }).ToList()
                }).FirstOrDefault();

            return _publisherData;
        }

        public IList<Publisher> GetAllPublishers(string? sortBy, string? searchString, int? pageNumber)
        {
            var allPublishers = _context.Publishers
                .OrderBy(x => x.Name)
                .ToList();

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc":
                        allPublishers = allPublishers.OrderByDescending(x => x.Name).ToList();
                        break;
                    default:
                        break;
                }
            }
            
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                allPublishers = allPublishers.Where(x => x.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            // Paging 
            // CONST pagesize
            int PAGE_SIZE = 5;
            allPublishers = PaginatedList<Publisher>.Create(allPublishers.AsQueryable(), pageNumber ?? 1, PAGE_SIZE);

            return allPublishers;
        } 


        public void DeletePublisherById(int id)
        {
            var publisher = _context.Publishers.Find(id);

            if (publisher is not null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"The publisher with id: {id} does not exist");
            }
        }

        private bool StringStartsWithNumber(string name)
        {
            // Import namespace
            if (Regex.IsMatch(name, @"^\d"))
                return true;

            return false;
        }
    }
}
