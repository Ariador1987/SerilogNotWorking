namespace TrupjaBooks.Exceptions
{
    // da bi smo mogli kreirati Exception moramo je naslijediti iz bazne klase Exception
    public class PublisherNameException : Exception
    {
        public string PublisherName { get; set; }

        // kreiramo CTOR za bacat exception - BAZNI CTOR
        public PublisherNameException()
        {

        }

        // da bi imalo custom CTOR moramo imat osnovni, u ovom CTOR-u primamo exception koji proslijeđujemo u baznu klasu
        public PublisherNameException(string message) : base(message)
        {

        }

        public PublisherNameException(string message, Exception inner) : base(message, inner)
        {

        }

        // ovdje u BAZNI konstruktor proslijeđujemo samo message
        public PublisherNameException(string message, string publisherName) : this(message)
        {
            this.PublisherName = publisherName;
        }
    }
}
