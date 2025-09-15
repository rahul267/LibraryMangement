using Xunit;
using LibraryApp;

namespace LibraryApp.Tests
{
    public class BorrowRegistryTests
    {
        [Fact]
        public void BorrowRegistry_Creation_SetsPropertiesCorrectly()
        {
            var borrowDate = DateTime.Now;
            var registry = new BorrowRegistry("Book Title", "User123", borrowDate);

            Assert.Equal("Book Title", registry.BookTitle);
            Assert.Equal("User123", registry.UserID);
            Assert.Equal(borrowDate, registry.BorrowDate);
            Assert.Null(registry.ReturnDate);
        }

        [Fact]
        public void BorrowRegistry_UpdateReturnDate_SetsReturnDateCorrectly()
        {
            var borrowDate = DateTime.Now;
            var registry = new BorrowRegistry("Book Title", "User123", borrowDate);

            var returnDate = DateTime.Now.AddDays(7);
            registry.ReturnDate = returnDate;

            Assert.Equal(returnDate, registry.ReturnDate);
        }
    }
}