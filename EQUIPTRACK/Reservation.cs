using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIPTRACK
{
    internal class Reservation
    {
        public int ReservationID { get; set; }
        public int UserID { get; set; }
        public int EquipmentID { get; set; }
        public DateTime ReservedDate { get; set; }
    }
}
