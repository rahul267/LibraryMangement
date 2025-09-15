using System.Collections.Generic;
using LibraryApp;
using Xunit;

namespace LibraryApp.Tests
{
    public class UserManagerTests
    {
        [Fact]
        public void AddUser_NewUser_ReturnsTrue()
        {
            // Arrange
            var userManager = new UserManager();
            var user = new UserAccount("User1", "Test User");

            // Act
            var result = userManager.AddUser(user);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddUser_DuplicateUser_ReturnsFalse()
        {
            // Arrange
            var userManager = new UserManager();
            var user = new UserAccount("User1", "Test User");
            userManager.AddUser(user);

            // Act
            var result = userManager.AddUser(user);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveUser_ExistingUser_ReturnsTrue()
        {
            // Arrange
            var userManager = new UserManager();
            var user = new UserAccount("User1", "Test User");
            userManager.AddUser(user);

            // Act
            var result = userManager.RemoveUser("User1");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveUser_NonExistingUser_ReturnsFalse()
        {
            // Arrange
            var userManager = new UserManager();

            // Act
            var result = userManager.RemoveUser("NonexistentUser");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetUser_ExistingUser_ReturnsUser()
        {
            // Arrange
            var userManager = new UserManager();
            var user = new UserAccount("User1", "Test User");
            userManager.AddUser(user);

            // Act
            var retrievedUser = userManager.GetUser("User1");

            // Assert
            Assert.NotNull(retrievedUser);
            Assert.Equal("User1", retrievedUser.UserID);
            Assert.Equal("Test User", retrievedUser.Name);
        }

        [Fact]
        public void GetUser_NonExistingUser_ReturnsNull()
        {
            // Arrange
            var userManager = new UserManager();

            // Act
            var retrievedUser = userManager.GetUser("NonexistentUser");

            // Assert
            Assert.Null(retrievedUser);
        }

        [Fact]
        public void GetAllUsers_ReturnsAllUsers()
        {
            // Arrange
            var userManager = new UserManager();
            var user1 = new UserAccount("User1", "Test User 1");
            var user2 = new UserAccount("User2", "Test User 2");
            userManager.AddUser(user1);
            userManager.AddUser(user2);

            // Act
            var users = userManager.GetAllUsers();

            // Assert
            Assert.Equal(2, users.Count);
            Assert.Contains(user1, users);
            Assert.Contains(user2, users);
        }
    }
}