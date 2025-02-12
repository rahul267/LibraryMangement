using System;
using Xunit;

namespace LibraryApp.Tests
{
    public class ImprovedUnitTests
    {
        [Fact]
        public void TestSimpleFineCalculator()
        {
            // Arrange
            var calculator = new SimpleFineCalculator();
            var dueDate = DateTime.Now.AddDays(-5);
            var returnDate = DateTime.Now;

            // Act
            var fine = calculator.CalculateFine(dueDate, returnDate);

            // Assert
            Assert.Equal(5, fine);
        }

        [Fact]
        public void TestUserManagerAddUser()
        {
            // Arrange
            var userManager = new UserManager();
            var user = new User { Id = 1, Name = "John Doe" };

            // Act
            userManager.AddUser(user);

            // Assert
            Assert.Contains(user, userManager.GetAllUsers());
        }

        [Fact]
        public void TestUserManagerRemoveUser()
        {
            // Arrange
            var userManager = new UserManager();
            var user = new User { Id = 1, Name = "John Doe" };
            userManager.AddUser(user);

            // Act
            userManager.RemoveUser(user.Id);

            // Assert
            Assert.DoesNotContain(user, userManager.GetAllUsers());
        }
    }
}
