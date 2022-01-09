namespace TrupjaBooks.Data.Models.DTOs
{
    public class AuthorDTO
    {
        public string Fullname { get; set; }
    }

    public class AuthorWithBooksDTO
    {
        public string Fullname { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
