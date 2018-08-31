using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalCheckerDataConsole
{
    public class Violation
    {   
        public String treatmentRef { get; set; }
        public String message { get; set; }

        public override String ToString()
        {
            return treatmentRef + " -> " + message;
        }
    }
}
