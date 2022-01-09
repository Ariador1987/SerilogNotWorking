namespace TrupjaBooks.Data.Models.DTOs
{
    public class PublisherDTO
    {
        public string Name { get; set; }
    }

    public class PublisherWithBooksAndAuthorsDTO
    {
        public string Name { get; set; }
        public List<BookAuthorDTO> BookAuthors { get; set; }
    }
}
