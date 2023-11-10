namespace FLuentAPI.Models;

public class Author
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public decimal Salary { get; set; }
    public ICollection<Book> Books { get; set; }
    public Author()
    {
        
    }
    public Author(int id, string fullname, decimal salary)
    {
        Id = id;
        FullName = fullname;
        Salary = salary;
    }
}
