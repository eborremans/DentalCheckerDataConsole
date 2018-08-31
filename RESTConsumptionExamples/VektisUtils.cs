using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalCheckerDataConsole
{
    public class VektisUtils
    {
        public static String listToString<T>(List<T> objects)
        {
            StringBuilder text = new StringBuilder();

            if (null != objects)
            {
                foreach (T obj in objects)
                {
                    text.Append(obj.ToString());
                    text.AppendLine();
                }
            }

            return text.ToString();
        }
    }
}
