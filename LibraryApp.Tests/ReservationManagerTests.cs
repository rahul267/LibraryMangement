using Xunit;
using Moq;
using System.Collections.Generic;

namespace LibraryApp.Tests
{
    public class ReservationManagerTests
    {
        [Fact]
        public void ReserveBook_BookNotReserved_ReservesBookSuccessfully()
        {
            // Arrange
            var reservationManager = new ReservationManager();
            var bookTitle = "Test Book";
            var userID = "123";

            // Act
            var result = reservationManager.ReserveBook(bookTitle, userID);

            // Assert
            Assert.True(result);
            Assert.Contains(bookTitle, reservationManager.GetReservedBooks(userID));
        }

        [Fact]
        public void ReserveBook_BookAlreadyReservedBySameUser_ReturnsFalse()
        {
            // Arrange
            var reservationManager = new ReservationManager();
            var bookTitle = "Test Book";
            var userID = "123";
            reservationManager.ReserveBook(bookTitle, userID);

            // Act
            var result = reservationManager.ReserveBook(bookTitle, userID);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CancelReservation_ReservationExists_CancelsReservationSuccessfully()
        {
            // Arrange
            var reservationManager = new ReservationManager();
            var bookTitle = "Test Book";
            var userID = "123";
            reservationManager.ReserveBook(bookTitle, userID);

            // Act
            var result = reservationManager.CancelReservation(bookTitle, userID);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(bookTitle, reservationManager.GetReservedBooks(userID));
        }

        [Fact]
        public void CancelReservation_ReservationDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var reservationManager = new ReservationManager();
            var bookTitle = "Non-Existent Book";
            var userID = "123";

            // Act
            var result = reservationManager.CancelReservation(bookTitle, userID);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetReservedBooks_UserHasReservations_ReturnsReservedBooks()
        {
            // Arrange
            var reservationManager = new ReservationManager();
            var bookTitle1 = "Book 1";
            var bookTitle2 = "Book 2";
            var userID = "123";
            reservationManager.ReserveBook(bookTitle1, userID);
            reservationManager.ReserveBook(bookTitle2, userID);

            // Act
            var reservedBooks = reservationManager.GetReservedBooks(userID);

            // Assert
            Assert.Contains(bookTitle1, reservedBooks);
            Assert.Contains(bookTitle2, reservedBooks);
        }

        [Fact]
        public void GetReservedBooks_UserHasNoReservations_ReturnsEmptyList()
        {
            // Arrange
            var reservationManager = new ReservationManager();
            var userID = "123";

            // Act
            var reservedBooks = reservationManager.GetReservedBooks(userID);

            // Assert
            Assert.Empty(reservedBooks);
        }
    }
}