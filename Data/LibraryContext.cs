using LibraryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Ebook> Ebooks { get; set; }
        public DbSet<PhysicalBook> PhysicalBooks { get; set; }
    }
}
