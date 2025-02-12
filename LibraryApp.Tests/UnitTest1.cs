namespace LibraryApp.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var libraryManager = new LibraryManager();
        var book = new Book { Title = "Test Book" };

        // Act
        var result = libraryManager.AddBook(book);

        // Assert
        Assert.True(result);
        Assert.Contains(book, libraryManager.GetAllBooks());
    }
}
