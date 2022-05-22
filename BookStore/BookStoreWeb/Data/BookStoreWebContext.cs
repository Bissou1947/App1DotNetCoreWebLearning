using Microsoft.EntityFrameworkCore;

namespace BookStoreWeb.Data
{
    public class BookStoreWebContext: DbContext
    {
        public BookStoreWebContext(DbContextOptions<BookStoreWebContext> options):
            base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
