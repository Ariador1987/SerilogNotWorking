namespace TrupjaBooks.Data.Models.DTOs
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int Rating { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        // dodajemo 2 nova svojstva koja predstavljaju novu shemu
        public int PublisherId { get; set; }
        public List<int> AuthorIds { get; set; }
    }

    public class BookWithAuthorsDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rating { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        // dodajemo 2 nova svojstva koja predstavljaju novu shemu
        public string PublisherName { get; set; }
        public List<string> AuthorNames { get; set; }
    }
}
