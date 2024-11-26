using Xunit;

namespace LibraryApp.Tests
{
    public class LibraryManagerTests
    {
        [Fact]
        public void BorrowBook_WithValidBook_ShouldUpdateRegistry()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book("Book1", "Author1", 2021);

            // Act
            var result = libraryManager.BorrowBook(book, "User1");

            // Assert
            Assert.True(result);
            Assert.Contains(book, libraryManager.BorrowRegistry);
        }

        [Fact]
        public void ReturnBook_WithValidBook_ShouldRemoveFromRegistry()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book("Book1", "Author1", 2021);
            libraryManager.BorrowBook(book, "User1");

            // Act
            var result = libraryManager.ReturnBook(book);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(book, libraryManager.BorrowRegistry);
        }

        [Fact]
        public void ReserveBook_WhenAvailable_ShouldSucceed()
        {
            // Arrange
            var libraryManager = new LibraryManager();
            var book = new Book("Book1", "Author1", 2021);

            // Act
            var result = libraryManager.ReserveBook(book, "User1");

            // Assert
            Assert.True(result);
            Assert.Contains(book, libraryManager.ReservationRegistry);
        }
    }
}