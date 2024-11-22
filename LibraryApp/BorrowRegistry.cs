using System;

namespace LibraryApp
{
    public class BorrowRegistry
    {
        public string BookTitle { get; set; }
        public string UserID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public BorrowRegistry(string bookTitle, string userID, DateTime borrowDate)
        {
            BookTitle = bookTitle;
            UserID = userID;
            BorrowDate = borrowDate;
            ReturnDate = null;
        }
    }
}