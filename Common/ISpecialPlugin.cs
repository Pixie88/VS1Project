using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface ISpecialPlugin
    {
         bool CalculateSpecial(Booking booking, ref string specialName, ref decimal specialPrice);
      
    }
}
