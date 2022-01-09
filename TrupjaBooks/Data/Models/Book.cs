namespace TrupjaBooks.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rating { get; set; }
        //public string Author { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }

        // NAV PROPERTIES
        // Knjiga može imati samo jednog publishera
        public int? PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        // dodali smo listu Book_Authors-a u taj model, te je moramo dodati i ovdje da joj imamo kako pristupiti in-memory
        // istu smo listu dodali i u Authors table.
        public List<Book_Author> Book_Authors { get; set; }

    }
}
