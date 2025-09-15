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
            var book = new Book { Title = "Test Book", Author = "Author" };

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
            var book = new Book { Title = "Test Book", Author = "Author" };
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
            var book = new Book { Title = "Test Book", Author = "Author" };
            libraryManager.AddBook(book);

            // Act
            var result = libraryManager.RemoveBook(book);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveBook_NonExistentBook_ReturnsFalse()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book { Title = "Test Book", Author = "Author" };

            // Act
            var result = libraryManager.RemoveBook(book);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckBookAvailability_ExistingBook_ReturnsTrue()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book { Title = "Test Book", Author = "Author" };
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
            var books = libraryManager.GetAllBooks();

            // Assert
            Assert.Empty(books);
        }

        [Fact]
        public void GetAllBooks_NonEmptyLibrary_ReturnsAllBooks()
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