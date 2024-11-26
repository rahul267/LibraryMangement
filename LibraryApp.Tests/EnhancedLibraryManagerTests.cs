// Comprehensive Unit Tests for LibraryManager
using NUnit.Framework;

namespace LibraryApp.Tests
{
    [TestFixture]
    public class EnhancedLibraryManagerTests
    {
        private LibraryManager _libraryManager;

        [SetUp]
        public void Setup()
        {
            _libraryManager = new LibraryManager();
        }

        [Test]
        public void AddBook_SpecialCharactersInTitle_ReturnsTrue()
        {
            var result = _libraryManager.AddBook(new Book("TitleWith!@#$%^&*()", "Author Name"));
            Assert.IsTrue(result);
        }

        [Test]
        public void AddBook_MaximumCapacity_ThrowsException()
        {
            for (int i = 0; i < _libraryManager.Capacity; i++)
            {
                _libraryManager.AddBook(new Book("Book " + i, "Author " + i));
            }
            Assert.Throws<InvalidOperationException>(() => _libraryManager.AddBook(new Book("Extra Book", "Extra Author")));
        }

        [Test]
        public void AddBook_ConcurrentAdditions_ReturnsCorrectCount()
        {
            Parallel.For(0, 100, i =>
            {
                _libraryManager.AddBook(new Book("Book " + i, "Author " + i));
            });
            Assert.AreEqual(100, _libraryManager.CountBooks());
        }
    }
}