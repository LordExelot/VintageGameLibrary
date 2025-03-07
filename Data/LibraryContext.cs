using VintageGameLibrary.Models;
using VintageGameLibrary;
using Microsoft.EntityFrameworkCore;

namespace VintageGameLibrary.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() { }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

    }
}