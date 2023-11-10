global using Microsoft.EntityFrameworkCore;
using FLuentAPI.Models;
using Microsoft.Identity.Client;
using System.Reflection;

namespace FLuentAPI.DataContext;

public class BookstoreDBContext : DbContext
{
    public BookstoreDBContext(DbContextOptions<BookstoreDBContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetCallingAssembly());
    }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
