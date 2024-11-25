using System.Collections.Generic;

namespace LibraryApp
{
    public class BorrowHistoryLogger : IBorrowHistoryLogger
    {
        private readonly List<BorrowRegistry> history = new List<BorrowRegistry>();

        public void LogBorrow(BorrowRegistry borrowRegistry)
        {
            history.Add(borrowRegistry);
        }

        public IEnumerable<BorrowRegistry> GetHistory()
        {
            return history;
        }
    }
}