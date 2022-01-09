namespace TrupjaBooks.Data.Models.DTOs
{
    // zasebni viewmodel za Book_Author
    public class BookAuthorDTO
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
    }
}
