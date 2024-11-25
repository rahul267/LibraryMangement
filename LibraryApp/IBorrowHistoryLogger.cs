using System.Collections.Generic;

namespace LibraryApp
{
    public interface IBorrowHistoryLogger
    {
        void LogBorrow(BorrowRegistry borrowRegistry);
        IEnumerable<BorrowRegistry> GetHistory();
    }
}