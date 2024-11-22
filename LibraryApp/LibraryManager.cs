using System.Collections.Generic;
using System.Linq;

namespace LibraryApp
{
    public class LibraryManager : ILibraryManager
    {
        private readonly List<Book> _books = new List<Book>();

        public bool AddBook(Book book)
        {
            if (!_books.Any(b => b.Title == book.Title))
            {
                _books.Add(book);
                return true;
            }
            return false;
        }

        public bool RemoveBook(string title)
        {
            var bookFound = _books.FirstOrDefault(b => b.Title == title);
            if (bookFound != null)
            {
                _books.Remove(bookFound);
                return true;
            }
            return false;
        }

        public bool CheckBookAvailability(string title)
        {
            return _books.Any(b => b.Title == title);
        }

        public List<Book> GetAllBooks()
        {
            return new List<Book>(_books);
        }
    }
}