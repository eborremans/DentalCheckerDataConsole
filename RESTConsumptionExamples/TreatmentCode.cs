using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalCheckerDataConsole
{
    public class TreatmentCode
    {
        public String code                 { get; set; } // "V73",
        public String description          { get; set; } // "drievlaksvulling amalgaam",
        public Boolean hasTechnicalCost    { get; set; } // true,
        public String validFrom            { get; set; } // "2017-01-01",
        public String validTo              { get; set; } // "2017-12-31"

        public TreatmentCode(
             String code,
             String description,
             Boolean hasTechnicalCost,
             String validFrom,
             String validTo)
        {
            this.code = code;
            this.description = description;
            this.hasTechnicalCost = hasTechnicalCost;
            this.validFrom = validFrom;
            this.validTo = validTo;
        }

        public override String ToString()
        {
            StringBuilder text = new StringBuilder();

            text.Append(base.ToString());
            text.Append("code             :" + code);
            text.AppendLine();
            text.Append("description      :" + description);
            text.AppendLine();
            text.Append("hasTechnicalCost :" + hasTechnicalCost);
            text.AppendLine();
            text.Append("validFrom        :" + validFrom);
            text.AppendLine();
            text.Append("validTo          :" + validTo);
            text.AppendLine();

            text.Append("---");
            text.AppendLine();

            return text.ToString();
        }
    }
}
