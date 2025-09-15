using LibraryApp;
using Xunit;
using System.Collections.Generic;

namespace LibraryApp.Tests
{
    public class LibraryManagerTests
    {
        [Fact]
        public void AddBook_NewBook_ReturnsTrue()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book { Title = "Test Book" };

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
            var book = new Book { Title = "Test Book" };
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
            var book = new Book { Title = "Test Book" };
            libraryManager.AddBook(book);

            // Act
            var result = libraryManager.RemoveBook("Test Book");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveBook_NonExistentBook_ReturnsFalse()
        {
            // Arrange
            var libraryManager = new LibraryManager();

            // Act
            var result = libraryManager.RemoveBook("Non-Existent Book");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckBookAvailability_ExistingBook_ReturnsTrue()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book { Title = "Test Book" };
            libraryManager.AddBook(book);

            // Act
            var result = libraryManager.CheckBookAvailability("Test Book");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckBookAvailability_NonExistentBook_ReturnsFalse()
        {
            // Arrange
            var libraryManager = new LibraryManager();

            // Act
            var result = libraryManager.CheckBookAvailability("Non-Existent Book");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetAllBooks_EmptyLibrary_ReturnsEmptyList()
        {
            // Arrange
            var libraryManager = new LibraryManager();

            // Act
            var result = libraryManager.GetAllBooks();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetAllBooks_NonEmptyLibrary_ReturnsAllBooks()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book1 = new Book { Title = "Book 1" };
            var book2 = new Book { Title = "Book 2" };
            libraryManager.AddBook(book1);
            libraryManager.AddBook(book2);

            // Act
            var result = libraryManager.GetAllBooks();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(book1, result);
            Assert.Contains(book2, result);
        }
    }
}