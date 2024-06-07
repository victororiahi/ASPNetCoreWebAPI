using ASPNetCoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreWebAPI.Data
{
    public class BookRepoContext : DbContext
    {
        public BookRepoContext(DbContextOptions<BookRepoContext> options): base(options)
        {
                
        }

        public DbSet<Book> Books { get; set; }
    }
}
