using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIPTRACK
{
    internal class equipment
    {
        public int EquipmentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Quantity_total { get; set; }
        public string Quantity_available {  get; set; }
        public string Status { get; set; }

    }
}
