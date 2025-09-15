using Xunit;
using Moq;
using System.Collections.Generic;

namespace LibraryApp.Tests
{
    public class LibraryManagerTests
    {
        [Fact]
        public void AddBook_BookDoesNotExist_AddsBookSuccessfully()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book { Title = "Test Book", Author = "Test Author" };

            // Act
            var result = libraryManager.AddBook(book);

            // Assert
            Assert.True(result);
            Assert.Contains(book, libraryManager.GetAllBooks());
        }

        [Fact]
        public void AddBook_BookAlreadyExists_ReturnsFalse()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book { Title = "Test Book", Author = "Test Author" };
            libraryManager.AddBook(book);

            // Act
            var result = libraryManager.AddBook(book);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveBook_BookExists_RemovesBookSuccessfully()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book { Title = "Test Book", Author = "Test Author" };
            libraryManager.AddBook(book);

            // Act
            var result = libraryManager.RemoveBook(book.Title);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(book, libraryManager.GetAllBooks());
        }

        [Fact]
        public void RemoveBook_BookDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var libraryManager = new LibraryManager();

            // Act
            var result = libraryManager.RemoveBook("Non-Existent Book");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckBookAvailability_BookExists_ReturnsTrue()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book { Title = "Test Book", Author = "Test Author" };
            libraryManager.AddBook(book);

            // Act
            var result = libraryManager.CheckBookAvailability(book.Title);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckBookAvailability_BookDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var libraryManager = new LibraryManager();

            // Act
            var result = libraryManager.CheckBookAvailability("Non-Existent Book");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetAllBooks_NoBooksAdded_ReturnsEmptyList()
        {
            // Arrange
            var libraryManager = new LibraryManager();

            // Act
            var books = libraryManager.GetAllBooks();

            // Assert
            Assert.Empty(books);
        }

        [Fact]
        public void GetAllBooks_BooksAdded_ReturnsAllBooks()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book1 = new Book { Title = "Book 1", Author = "Author 1" };
            var book2 = new Book { Title = "Book 2", Author = "Author 2" };
            libraryManager.AddBook(book1);
            libraryManager.AddBook(book2);

            // Act
            var books = libraryManager.GetAllBooks();

            // Assert
            Assert.Contains(book1, books);
            Assert.Contains(book2, books);
        }
    }
}