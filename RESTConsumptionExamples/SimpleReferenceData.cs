using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalCheckerDataConsole
{
    public class SimpleReferenceData : SimpleTreatment
    {
        public Boolean hasTechnicalCost { get; set; }
        public String  validFrom        { get; set; }
        public String  validTo          { get; set; }

        public SimpleReferenceData(
            string code, 
            string description, 
            string addendum,
            bool   hasTechnicalCost, 
            string validFrom, 
            string validTo) : base(code, description, addendum)
        {
            this.hasTechnicalCost = hasTechnicalCost;
            this.validFrom = validFrom;
            this.validTo = validTo;
        }

        public override String ToString()
        {
            StringBuilder text = new StringBuilder();

            text.Append(base.ToString());
            text.Append("hasTechnicalCost  :" + hasTechnicalCost);
            text.AppendLine();
            text.Append("validFrom         :" + validFrom);
            text.AppendLine();
            text.Append("validTo           :" + validTo);
            text.AppendLine();

            return text.ToString();
        }
    }
}
