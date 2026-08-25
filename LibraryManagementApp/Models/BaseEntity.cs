namespace LibraryManagementApp.Models;

public class BaseEntity
{
    public int Id { get; }
    private static int _id = 0;

    public BaseEntity()
    {
        _id++;
        Id = _id;
    }
}
