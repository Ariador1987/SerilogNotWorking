namespace TrupjaBooks.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        // NAV PROPS
        // Author => Book = Many-to-many, tako da moramo dodati join table.
        /* 
            Kako je odnos Book i Authora many to many veza nećemo dodavati
            navigacijsko svojstvo Book već join table-a tj Book_Author
         */
        public List<Book_Author> Book_Authors { get; set; }
    }
}
