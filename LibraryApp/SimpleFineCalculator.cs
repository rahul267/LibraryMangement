using System;

namespace LibraryApp
{
    public class SimpleFineCalculator : IFineCalculator
    {
        private const decimal DailyFine = 0.50m; // Fine per day overdue

        public decimal CalculateFine(BorrowRegistry borrow)
        {
            if (!borrow.ReturnDate.HasValue)
            {
                var daysOverdue = (DateTime.Now - borrow.BorrowDate.AddDays(30)).Days; // Assuming 30 days loan period
                if (daysOverdue > 0)
                {
                    return daysOverdue * DailyFine;
                }
            }
            return 0;
        }
    }
}