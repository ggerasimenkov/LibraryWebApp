using Microsoft.EntityFrameworkCore;
using LibraryWebApp.Models;

namespace LibraryWebApp.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        // Набор сущностей "Books", маппится на таблицу в базе (или в InMemory-хранилище)
        public DbSet<Book> Books { get; set; }
    }
}