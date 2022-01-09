using Microsoft.EntityFrameworkCore;
using TrupjaBooks.Data.Models;

namespace TrupjaBooks.Data
{
    public class AppDbContext : DbContext
    {
        //private readonly DbContextOptions _options;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // dodajemo fluentAPI konfiguraciju many-to-many veze
            // koja potiče iz Book_Author modela.
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(b => b.Book_Authors)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(b => b.Book_Authors)
                .HasForeignKey(b => b.AuthorId);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Books_Authors { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
