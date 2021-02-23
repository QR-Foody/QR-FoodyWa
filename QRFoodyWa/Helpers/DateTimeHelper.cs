using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRFoodyWa.Helpers
{
    public static class DateTimeHelper
    {
        public static bool IsValidDate(string dateStr)
        {
            try
            {
                // We need to check if the date provided is has a valid format, and if it is, the year is always different to -1
                DateTime.ParseExact(dateStr, "yyyy-MM-dd", null);
                return true;
            }
            catch (FormatException ex)
            {
                return false;
            }
            catch (Exception ex)
            {               
                return false;
            }
        }
    }
}