

namespace LibraryManagementApp.Models;

public class Book : BaseEntity
{
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public int PageCount { get; set; }
    public bool IsDeleted { get; set; } = false;

    public Book(string name, string authorName, int pageCount)
    {
        Name = name;
        AuthorName = authorName;
        PageCount = pageCount;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Name : {Name} | AuthorName : {AuthorName} | PageCount : {PageCount}");
    }
}
