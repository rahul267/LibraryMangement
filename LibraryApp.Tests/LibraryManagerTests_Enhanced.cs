// Unit Tests for LibraryManager class
using NUnit.Framework;

namespace LibraryApp.Tests {
    [TestFixture]
    public class LibraryManagerTests_Enhanced {
        private LibraryManager _libraryManager;

        [SetUp]
        public void Setup() {
            _libraryManager = new LibraryManager();
        }

        [Test]
        public void AddBook_Fails_WhenAddingDuplicateBook() {
            // Arrange
            var book = new Book("Test Book", "Author", 2021);
            _libraryManager.AddBook(book);

            // Act
            var result = _libraryManager.AddBook(book);

            // Assert
            Assert.IsFalse(result, "Should fail when adding a duplicate book.");
        }

        [Test]
        public void RemoveBook_Fails_WhenBookDoesNotExist() {
            // Arrange
            var bookId = 999; // Assuming this ID does not exist

            // Act
            var result = _libraryManager.RemoveBook(bookId);

            // Assert
            Assert.IsFalse(result, "Should fail when trying to remove a non-existent book.");
        }

        [Test]
        public void AddBook_Fails_WhenBookIsNull() {
            // Act
            var result = _libraryManager.AddBook(null);

            // Assert
            Assert.IsFalse(result, "Should fail when adding a null book.");
        }
    }
}