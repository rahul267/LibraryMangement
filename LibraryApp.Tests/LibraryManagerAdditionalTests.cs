using Xunit;
using LibraryApp;

namespace LibraryApp.Tests
{
    public class LibraryManagerAdditionalTests
    {
        private readonly LibraryManager _libraryManager = new LibraryManager();

        [Fact]
        public void AddBook_ThrowsArgumentException_WhenBookTitleIsEmpty()
        {
            var book = new Book("", "Sample Author");
            Assert.Throws<ArgumentException>(() => _libraryManager.AddBook(book));
        }

        [Fact]
        public void RemoveBook_ThrowsInvalidOperationException_WhenBookNotInLibrary()
        {
            var book = a Book("Nonexistent Book", "Unknown Author");
            Assert.Throws<InvalidOperationException>(() => _libraryManager.RemoveBook(book));
        }

        // Additional tests can be added here following the same pattern
    }
}