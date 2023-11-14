global using Microsoft.EntityFrameworkCore;
using FLuentAPI.Models;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Debug);
        optionsBuilder.UseLazyLoadingProxies();
    }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
}
