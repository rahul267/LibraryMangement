using Xunit;
using Moq;
using System.Collections.Generic;

namespace LibraryApp.Tests
{
    public class UserManagerTests
    {
        [Fact]
        public void AddUser_UserDoesNotExist_AddsUserSuccessfully()
        {
            // Arrange
            var userManager = new UserManager();
            var user = new UserAccount { UserID = "123", Name = "Test User" };

            // Act
            var result = userManager.AddUser(user);

            // Assert
            Assert.True(result);
            Assert.Contains(user, userManager.GetAllUsers());
        }

        [Fact]
        public void AddUser_UserAlreadyExists_ReturnsFalse()
        {
            // Arrange
            var userManager = new UserManager();
            var user = new UserAccount { UserID = "123", Name = "Test User" };
            userManager.AddUser(user);

            // Act
            var result = userManager.AddUser(user);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveUser_UserExists_RemovesUserSuccessfully()
        {
            // Arrange
            var userManager = new UserManager();
            var user = new UserAccount { UserID = "123", Name = "Test User" };
            userManager.AddUser(user);

            // Act
            var result = userManager.RemoveUser(user.UserID);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(user, userManager.GetAllUsers());
        }

        [Fact]
        public void RemoveUser_UserDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var userManager = new UserManager();

            // Act
            var result = userManager.RemoveUser("Non-Existent User");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetUser_UserExists_ReturnsUser()
        {
            // Arrange
            var userManager = new UserManager();
            var user = new UserAccount { UserID = "123", Name = "Test User" };
            userManager.AddUser(user);

            // Act
            var retrievedUser = userManager.GetUser(user.UserID);

            // Assert
            Assert.Equal(user, retrievedUser);
        }

        [Fact]
        public void GetUser_UserDoesNotExist_ReturnsNull()
        {
            // Arrange
            var userManager = new UserManager();

            // Act
            var retrievedUser = userManager.GetUser("Non-Existent User");

            // Assert
            Assert.Null(retrievedUser);
        }

        [Fact]
        public void GetAllUsers_NoUsersAdded_ReturnsEmptyList()
        {
            // Arrange
            var userManager = new UserManager();

            // Act
            var users = userManager.GetAllUsers();

            // Assert
            Assert.Empty(users);
        }

        [Fact]
        public void GetAllUsers_UsersAdded_ReturnsAllUsers()
        {
            // Arrange
            var userManager = new UserManager();
            var user1 = new UserAccount { UserID = "123", Name = "User 1" };
            var user2 = new UserAccount { UserID = "456", Name = "User 2" };
            userManager.AddUser(user1);
            userManager.AddUser(user2);

            // Act
            var users = userManager.GetAllUsers();

            // Assert
            Assert.Contains(user1, users);
            Assert.Contains(user2, users);
        }
    }
}