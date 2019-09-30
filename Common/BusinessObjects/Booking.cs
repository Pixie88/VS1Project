using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Booking
    {
        public int BookingNumber { get; set; }
        public int SessionID { get; set; }
        public DateTime SessionDate { get; set; }
        public int Quantity { get; set; }
        public string Special { get; set; }
        public decimal Discount { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal FinalPrice { get; set; }


    }
}
