using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTConsumptionExamples
{
    public class Customer
    {
        String customerBirthdate { get; set; }   // "1970-01-01",
        String customerEmail { get; set; }       // "someone@bh.nl",
        String customerExternalId { get; set; }  // "10000-username",
        String customerInitials { get; set; }    // ": "D.J.",
        String customerLastName { get; set; }    // ": "van der Burmann"

        public Customer(
            String customerBirthdate,
            String customerEmail,
            String customerExternalId,
            String customerInitials,
            String customerLastName)
        {
            this.customerBirthdate = customerBirthdate;
            this.customerEmail = customerEmail;
            this.customerExternalId = customerExternalId;
            this.customerInitials = customerInitials;
            this.customerLastName = customerLastName;
        }

        public override String ToString()
        {
            StringBuilder text = new StringBuilder();

            text.Append("customerBirthdate  :" + customerBirthdate);
            text.AppendLine();
            text.Append("customerEmail      :" + customerEmail);
            text.AppendLine();
            text.Append("customerExternalId :" + customerExternalId);
            text.AppendLine();
            text.Append("customerInitials   :" + customerInitials);
            text.AppendLine();
            text.Append("customerLastName   :" + customerLastName);
            text.AppendLine();

            text.Append("---");
            text.AppendLine();

            return text.ToString();
        }

    }
}
