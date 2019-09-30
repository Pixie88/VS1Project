using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Session
    {
        public int SessionID { get; set; }
        public int MovieID { get; set; }
        public DateTime SessionDate { get; set; }
        public byte CinemaNumber { get; set; }

        //question 5 - ShortFormat property
        private string _shortFormat;
        public string ShortFormat
        {
            get
            {
                return string.Format("{0:HH:mm} - Cinema {1}", SessionDate, CinemaNumber);
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException();
                _shortFormat = value;            }
        }
    }
}
