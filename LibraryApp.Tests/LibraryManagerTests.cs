using Xunit;
using LibraryApp;

public class LibraryManagerTests
{
    private LibraryManager _libraryManager;
    private Book _book;

    public LibraryManagerTests()
    {
        _libraryManager = new LibraryManager();
        _book = new Book { Title = "Test Book", Author = "Author", ISBN = "123-456" };
    }

    [Fact]
    public void AddBook_WithNonExistingBook_ReturnsTrue()
    {
        // Arrange
        bool expected = true;

        // Act
        bool result = _libraryManager.AddBook(_book);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void AddBook_WithExistingBook_ReturnsFalse()
    {
        // Arrange
        _libraryManager.AddBook(_book);
        bool expected = false;

        // Act
        bool result = _libraryManager.AddBook(_book);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void RemoveBook_WithExistingBook_ReturnsTrue()
    {
        // Arrange
        _libraryManager.AddBook(_book);
        bool expected = true;

        // Act
        bool result = _libraryManager.RemoveBook(_book.Title);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void RemoveBook_WithNonExistingBook_ReturnsFalse()
    {
        // Arrange
        bool expected = false;

        // Act
        bool result = _libraryManager.RemoveBook("Non Existing Title");

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CheckBookAvailability_WithAvailableBook_ReturnsTrue()
    {
        // Arrange
        _libraryManager.AddBook(_book);
        bool expected = true;

        // Act
        bool result = _libraryManager.CheckBookAvailability(_book.Title);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CheckBookAvailability_WithNonAvailableBook_ReturnsFalse()
    {
        // Arrange
        bool expected = false;

        // Act
        bool result = _libraryManager.CheckBookAvailability("Non Existing Title");

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetAllBooks_ReturnsCorrectNumberOfBooks()
    {
        // Arrange
        _libraryManager.AddBook(_book);
        int expected = 1;

        // Act
        var result = _libraryManager.GetAllBooks();

        // Assert
        Assert.Equal(expected, result.Count);
    }
}