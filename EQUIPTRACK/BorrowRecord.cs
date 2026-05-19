using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIPTRACK
{
    internal class BorrowRecord
    {
        public int BorrowID { get; set; }
        public int UserID { get; set; }
        public int EquipmentID { get; set; }
        public int quantity { get; set; }
        public DateTime Borrowtime { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? Returntime { get; set; }
        public string status { get; set; }

        // Check if overdue
        public bool IsOverdue() => Returntime == null && DueDate < DateTime.Now;
    }
}
