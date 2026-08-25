namespace LibraryManagementApp.Models;

public class Library : BaseEntity
{
    public int BookLimit { get; set; }
    private List<Book> Books { get; set; } = new();

    public Library(int bookLimit)
    {
        BookLimit = bookLimit;
    }
}
