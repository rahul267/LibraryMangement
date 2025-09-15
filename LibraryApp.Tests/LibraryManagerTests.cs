using Xunit;
using LibraryApp;
using System;

namespace LibraryApp.Tests
{
    public class LibraryManagerTests
    {
        private readonly LibraryManager _libraryManager = new LibraryManager();

        [Fact]
        public void AddBook_ReturnsTrue_WhenNewBookAdded()
        {
            var book = new Book("Sample Book Title", "Sample Author");
            var result = _libraryManager.AddBook(book);
            Assert.True(result);
        }

        [Fact]
        public void AddBook_ReturnsFalse_WhenAddingDuplicateBook()
        {
            var book = new Book("Duplicate Book Title", "Author");
            _libraryManager.AddBook(book);
            var result = _libraryManager.AddBook(book);
            Assert.False(result);
        }

        [Fact]
        public void RemoveBook_ReturnsTrue_WhenExistingBookRemoved()
        {
            var book = new Book("Sample Book Title", "Sample Author");
            _libraryManager.AddBook(book);
            var result = _libraryManager.RemoveBook(book.Title);
            Assert.True(result);
        }

        [Fact]
        public void RemoveBook_ReturnsFalse_WhenBookDoesNotExist()
        {
            var result = _libraryManager.RemoveBook("Nonexistent Book Title");
            Assert.False(result);
        }

        [Fact]
        public void CheckBookAvailability_ReturnsTrue_WhenBookExists()
        {
            var book = new Book("Existing Book Title", "Existing Author");
            _libraryManager.AddBook(book);
            var result = _libraryManager.CheckBookAvailability(book.Title);
            Assert.True(result);
        }

        [Fact]
        public void CheckBookAvailability_ReturnsFalse_WhenBookDoesNotExist()
        {
            var result = _libraryManager.CheckBookAvailability("Nonexistent Book Title");
            Assert.False(result);
        }

        [Fact]
        public void GetAllBooks_ReturnsCorrectCount_WhenBooksAdded()
        {
            _libraryManager.AddBook(new Book("Book 1", "Author 1"));
            _libraryManager.AddBook(new Book("Book 2", "Author 2"));
            var books = _libraryManager.GetAllBooks();
            Assert.Equal(2, books.Count);
        }

        [Fact]
        public void AddBook_ThrowsArgumentNullException_WhenBookIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _libraryManager.AddBook(null));
        }

        [Fact]
        public void RemoveBook_ThrowsArgumentNullException_WhenTitleIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _libraryManager.RemoveBook(null));
        }

        [Fact]
        public void RemoveBook_ThrowsArgumentException_WhenTitleIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => _libraryManager.RemoveBook(string.Empty));
        }
    }
}