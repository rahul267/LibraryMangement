using System.Collections.Generic;
using LibraryApp;
using Xunit;

namespace LibraryApp.Tests
{
    public class LibraryManagerTests
    {
        [Fact]
        public void AddBook_NewBook_ReturnsTrue()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book("Test Title", "Test Author");

            // Act
            var result = libraryManager.AddBook(book);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddBook_DuplicateBook_ReturnsFalse()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book("Test Title", "Test Author");
            libraryManager.AddBook(book);

            // Act
            var result = libraryManager.AddBook(book);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveBook_ExistingBook_ReturnsTrue()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book("Test Title", "Test Author");
            libraryManager.AddBook(book);

            // Act
            var result = libraryManager.RemoveBook("Test Title");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveBook_NonExistingBook_ReturnsFalse()
        {
            // Arrange
            var libraryManager = new LibraryManager();

            // Act
            var result = libraryManager.RemoveBook("Nonexistent Title");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckBookAvailability_ExistingBook_ReturnsTrue()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book("Test Title", "Test Author");
            libraryManager.AddBook(book);

            // Act
            var result = libraryManager.CheckBookAvailability("Test Title");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckBookAvailability_NonExistingBook_ReturnsFalse()
        {
            // Arrange
            var libraryManager = new LibraryManager();

            // Act
            var result = libraryManager.CheckBookAvailability("Nonexistent Title");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetAllBooks_ReturnsAllBooks()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book1 = new Book("Title1", "Author1");
            var book2 = new Book("Title2", "Author2");
            libraryManager.AddBook(book1);
            libraryManager.AddBook(book2);

            // Act
            var books = libraryManager.GetAllBooks();

            // Assert
            Assert.Equal(2, books.Count);
            Assert.Contains(book1, books);
            Assert.Contains(book2, books);
        }
    }
}