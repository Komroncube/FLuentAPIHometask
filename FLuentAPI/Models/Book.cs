using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FLuentAPI.Models;

public class Book
{
    private readonly ILazyLoader _loader;

    public Book() { }
    public Book(ILazyLoader loader)
    {
        _loader = loader;
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    private Author? _author;
    public Author Author {
        get => _loader.Load(this, ref _author);
        set => _author = value;
    }
}
