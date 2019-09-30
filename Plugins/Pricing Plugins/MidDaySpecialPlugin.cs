using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;




namespace GalaxyCinemas
    
{
    public class MidDaySpecialPlugin : ISpecialPlugin
    {
        
        public bool CalculateSpecial(Booking booking, ref string specialName, ref decimal specialPrice)
        {
            TimeSpan timeOfDay = booking.SessionDate.TimeOfDay;
            TimeSpan time11 = new TimeSpan(11, 0, 0);
            TimeSpan time13 = new TimeSpan(13, 0, 0);
            // If not mid-day, not applicable.
            // If movie doesn't start between 11am and 1pm
              if (timeOfDay > time11 & timeOfDay < time13)
            {
                //calculate discounted price
                decimal discountedPrice = booking.OriginalPrice * 0.8M;
                

                if (discountedPrice < booking.OriginalPrice)
                {
                    specialPrice = discountedPrice;
                    specialName = "Mid-day special";
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
