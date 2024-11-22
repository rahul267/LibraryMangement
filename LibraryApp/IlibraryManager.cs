using System.Collections.Generic;

namespace LibraryApp
{
    public interface ILibraryManager
    {
        bool AddBook(Book book);
        bool RemoveBook(string title);
        bool CheckBookAvailability(string title);
        List<Book> GetAllBooks();
    }
}