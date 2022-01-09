namespace TrupjaBooks.Data.Models
{
    public class Book_Author
    {
        public int Id { get; set; }
        // NAV PROPS za Book i Author-a
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
