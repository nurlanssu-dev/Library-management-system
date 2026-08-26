
using Utils.Exceptions;

namespace LibraryManagementApp.Models;

public class Library : BaseEntity
{
    public int BookLimit { get; set; }
    private List<Book> Books { get; set; } = new();

    public Library(int bookLimit)
    {
        BookLimit = bookLimit;
    }
    public void AddBook(Book book)
    {
        int activeBookCount = 0;
        foreach (Book item in Books)
        {
            if (item.Name == book.Name && item.IsDeleted == false)
            {
                throw new AlreadyExistsException("Eyni adda kitab var");
            }
            if (item.IsDeleted)
            {
                activeBookCount++;
            }
            if (activeBookCount > BookLimit)
            {
                throw new CapacityLimitException("Limit asilib");
            }
        }
        Books.Add(book);
    }

    public Book? GetBookById(int? id)
    {
        if (id == null)
        {
            throw new NullReferenceException("Id nulldur.");
        }

        foreach (Book book in Books)
        {
            if (book.Id == id && book.IsDeleted == false)
            {
                return book;
            }
        }

        return null;
    }
    public List<Book> GetAllBooks()
    {
        List<Book> allBooks = new List<Book>();

        foreach (Book book in Books)
        {
            allBooks.Add(book);
        }

        return allBooks;
    }
    public void DeleteBookById(int? id)
    {
        if (id == null)
        {
            throw new NullReferenceException("Id nulldur.");
        }
        foreach (Book item in Books)
        {
            if (item.Id == id && item.IsDeleted == false)
            {
                item.IsDeleted = true;
                return;
            }
        }
        throw new NotFoundException("Book tapilmadi.");
    }
    public void EditBookName(int? id, string newName)
    {
        if (id == null)
        {
            throw new NullReferenceException("id nulldur");
        }
        foreach (Book item in Books)
        {
            if (item.Id == id)
            {
                item.Name = newName;
                return;
            }
        }
        throw new NotFoundException("uygun kitab tapilmadi");
    }
    public List<Book> FilterByPageCount(int minPageCount, int maxPageCount)
    {
        List<Book> filteredBooks = new List<Book>();

        foreach (Book item in Books)
        {
            if (item.PageCount >= minPageCount &&
                item.PageCount <= maxPageCount &&
                item.IsDeleted == false)
            {
                filteredBooks.Add(item);
            }
        }

        return filteredBooks;
    }
}
