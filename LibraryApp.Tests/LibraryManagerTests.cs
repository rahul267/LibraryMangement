using Xunit;
using LibraryApp;

namespace LibraryApp.Tests
{
    public class LibraryManagerTests
    {
        [Fact]
        public void AddBook_ShouldReturnFalse_WhenBookAlreadyExists()
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
        public void RemoveBook_ShouldReturnTrue_WhenBookExists()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book { Title = "Test Book" };
            libraryManager.AddBook(book);

            // Act
            var result = libraryManager.RemoveBook(book.Title);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(book, libraryManager.GetAllBooks());
        }

        [Fact]
        public void CheckBookAvailability_ShouldReturnTrue_WhenBookExists()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book { Title = "Test Book" };
            libraryManager.AddBook(book);

            // Act
            var result = libraryManager.CheckBookAvailability(book.Title);

            // Assert
            Assert.True(result);
        }
    }
}