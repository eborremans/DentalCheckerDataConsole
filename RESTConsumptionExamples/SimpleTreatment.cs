using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTConsumptionExamples
{
    public class SimpleTreatment
    {
        public String code { get; set; }
        public String description { get; set; }

        public SimpleTreatment(string code, string description)
        {
            this.code = code;
            this.description = description;
        }

        public override String ToString()
        {
            StringBuilder text = new StringBuilder();

            text.Append("code              :" + code);
            text.AppendLine();             
            text.Append("description       :" + description);
            text.AppendLine();             

            return text.ToString();
        }
    }
}
