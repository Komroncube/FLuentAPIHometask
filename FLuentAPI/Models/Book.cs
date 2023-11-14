using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FLuentAPI.Models;

public class Book
{
    public Book() { }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
}
