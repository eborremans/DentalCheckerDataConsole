using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalCheckerDataConsole
{
    public class DateUtils
    {
        public static String today()
        {
            return dateTimeToString(DateTime.Now);
        }

        public static String dateTimeToString(DateTime dateTime)
        {
            String str = dateTime.Year + "-" + dateTime.Month.ToString("00.#") + "-" + dateTime.Day.ToString("00.#");

            return str;
        }

    }
}
