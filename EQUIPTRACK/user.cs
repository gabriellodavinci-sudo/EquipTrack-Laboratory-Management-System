using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIPTRACK
{
    internal class user
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Role { get; set; } // "Admin" or "Borrower"

        // Optional: simple login check method
        public bool IsAdmin() => Role == "Admin";
    }
}
