using System.Collections.Generic;
using System.Linq;

namespace LibraryApp
{
    public class ReservationManager : IReservationManager
    {
        private readonly List<(string bookTitle, string userID)> reservations = new List<(string bookTitle, string userID)>();

        public bool ReserveBook(string bookTitle, string userID)
        {
            if (!reservations.Any(r => r.bookTitle == bookTitle && r.userID == userID))
            {
                reservations.Add((bookTitle, userID));
                return true;
            }
            return false;
        }

        public bool CancelReservation(string bookTitle, string userID)
        {
            var reservation = reservations.FirstOrDefault(r => r.bookTitle == bookTitle && r.userID == userID);
            if (reservation != default)
            {
                reservations.Remove(reservation);
                return true;
            }
            return false;
        }

        public IEnumerable<string> GetReservedBooks(string userID)
        {
            return reservations.Where(r => r.userID == userID).Select(r => r.bookTitle);
        }
    }
}