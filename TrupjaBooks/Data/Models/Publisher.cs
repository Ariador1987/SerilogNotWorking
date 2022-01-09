namespace TrupjaBooks.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // NAV PROPERTIES
        // ovdje je u pitanju 1-to-many veza Publishera i Knjiga, zato publisher ima svojstvo kolekcije knjiga
        public List<Book> Books { get; set; }
    }
}
