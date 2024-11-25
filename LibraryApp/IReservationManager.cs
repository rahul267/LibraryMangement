using System.Collections.Generic;

namespace LibraryApp
{
    public interface IReservationManager
    {
        bool ReserveBook(string bookTitle, string userID);
        bool CancelReservation(string bookTitle, string userID);
        IEnumerable<string> GetReservedBooks(string userID);
    }
}