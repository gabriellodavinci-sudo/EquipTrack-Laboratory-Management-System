using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIPTRACK
{
    internal class Penalty
    {
        public int PenaltyID { get; set; }
        public int BorrowID { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } // "Unpaid", "Paid"

        // Optional: calculate based on days overdue
        public void CalculatePenalty(DateTime dueDate)
        {
            int daysLate = (DateTime.Now - dueDate).Days;
            Amount = daysLate > 0 ? daysLate * 10 : 0; // Example: 10 per day
        }
    }
}
