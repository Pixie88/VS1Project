using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using Common;

namespace GalaxyCinemas
{
    public class TuesdaySpecialPlugin : ISpecialPlugin
    {
        

        public bool CalculateSpecial(Booking booking, ref string specialName, ref decimal specialPrice)
        {
            DateTime dt = booking.SessionDate;
            // If not Tuesday, not applicable.
            if (dt.DayOfWeek == DayOfWeek.Tuesday)
            {
                //calculate base unit price
                decimal basePrice = (booking.OriginalPrice / booking.Quantity);
                //calculate discounted prices
                decimal discountedPrice = 0;
                if (booking.Quantity <= 5)
                {
                    discountedPrice = 11 * booking.Quantity;
                }
                else
                {

                    decimal extraTickets = booking.Quantity - 5;
                    discountedPrice = (11 * 5) + (extraTickets * basePrice);
                }
                //If discount is applicable, set specialName and specialPrice to our name and price
                if (discountedPrice < booking.OriginalPrice)
                {
                    specialPrice = discountedPrice;
                    specialName = "Tuesday Special";
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
           else
            {
                return false;
            }           

            
        }
    }
}
