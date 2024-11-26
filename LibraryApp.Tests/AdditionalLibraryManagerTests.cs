using Xunit;
using LibraryApp;

namespace LibraryApp.Tests
{
    public class AdditionalLibraryManagerTests
    {
        private readonly LibraryManager _libraryManager = new LibraryManager();

        [Fact]
        public void AddBook_ThrowsException_WhenBookIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _libraryManager.AddBook(null));
        }

        [Fact]
        public void RemoveBook_ThrowsException_WhenBookDoesNotExist()
        {
            var nonExistingBook = new Book("Non-Existing Title", "Non-Existing Author");
            Assert.Throws<KeyNotFoundException>(() => _libraryManager.RemoveBook(nonExistingBook));
        }

        // Additional tests will be added here following the same pattern
    }
}