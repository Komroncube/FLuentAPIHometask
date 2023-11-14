using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FLuentAPI.Models;

public class Author
{
    private readonly ILazyLoader _loader;

    public int Id { get; set; }
    public string FullName { get; set; }
    public decimal Salary { get; set; }
    private ICollection<Book> _books;
    public ICollection<Book> Books {
        get => _loader.Load(this, ref _books);
        set => _books = value;
    }
    public Author()
    {
        
    }
    public Author(int id, string fullname, decimal salary)
    {
        Id = id;
        FullName = fullname;
        Salary = salary;
    }
    public Author(ILazyLoader loader)
    {
        _loader = loader;
    }
}
