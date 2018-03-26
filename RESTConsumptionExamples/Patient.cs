﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTConsumptionExamples
{
    public class Patient
    {
        public String healthInsuranceName { get; set; }
        public String patientBirthdate    { get; set; }
        public String patientExternalId   { get; set; }
        public String patientInitials     { get; set; }
        public String patientLastName     { get; set; }
        public String patientPolicyNumber { get; set; }
        public List<Treatment> treatments { get; set; }

        public Patient(
            string healthInsuranceName, 
            string patientBirthdate, 
            string patientExternalId, 
            string patientInitials, 
            string patientLastName, 
            string patientPolicyNumber,
            List<Treatment> treatments
            )
        {
            this.healthInsuranceName = healthInsuranceName;
            this.patientBirthdate = patientBirthdate;
            this.patientExternalId = patientExternalId;
            this.patientInitials = patientInitials;
            this.patientLastName = patientLastName;
            this.patientPolicyNumber = patientPolicyNumber;
            this.treatments = treatments;
        }

        public override String ToString()
        {
            StringBuilder text = new StringBuilder();

            text.Append("healthInsuranceName :" + healthInsuranceName);
            text.AppendLine();
            text.Append("patientBirthdate    :" + patientBirthdate);
            text.AppendLine();
            text.Append("patientExternalId   :" + patientExternalId);
            text.AppendLine();
            text.Append("patientInitials     :" + patientInitials);
            text.AppendLine();
            text.Append("patientLastName     :" + patientLastName);
            text.AppendLine();
            text.Append("patientPolicyNumber :" + patientPolicyNumber);
            text.AppendLine();
            text.Append("treatments          :");
            text.AppendLine();
            text.Append(VektisUtils.listToString<Treatment>(treatments));
            text.AppendLine();

            text.Append("---");
            text.AppendLine();

            return text.ToString();
        }
    }
}
