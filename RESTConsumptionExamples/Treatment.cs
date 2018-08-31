using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalCheckerDataConsole
{
    public class Treatment : SimpleTreatment
    {
        public String          date              { get; set; }
        public Decimal         declaredAmount    { get; set; }
        public String          dentalElementCode { get; set; }
        public Int16           nrOfTreatments    { get; set; }
        public String          referenceNumber   { get; set; }
        public Decimal         tariffAmount      { get; set; }
        public String          therapistAGBCode  { get; set; }
        public Int16?          typeOfTreatment   { get; set; }
        public Decimal         calculatedAmount  { get; set; }
        public List<Violation> violations        { get; set; }

        public Treatment() : base("", "", "") { }

        public Treatment(
            string code,
            string description,
            string addendum,
            bool hasTechnicalCost,
            string validFrom,
            string validTo,
            decimal calculatedAmount, 
            string date, 
            decimal declaredAmount, 
            string dentalElementCode, 
            short nrOfTreatments, 
            string referenceNumber, 
            decimal tariffAmount, 
            string therapistAGBCode,
            Int16? typeOfTreatment) : base(code, description, addendum)
        {
            this.calculatedAmount = calculatedAmount;
            this.date = date;
            this.declaredAmount = declaredAmount;
            this.dentalElementCode = dentalElementCode;
            this.nrOfTreatments = nrOfTreatments;
            this.referenceNumber = referenceNumber;
            this.tariffAmount = tariffAmount;
            this.therapistAGBCode = therapistAGBCode;
            this.typeOfTreatment = typeOfTreatment;
        }

        public override String ToString()
        {
            StringBuilder text = new StringBuilder();

            text.Append(base.ToString());
            text.Append("date              :" + date             );
            text.AppendLine();
            text.Append("declaredAmount    :" + declaredAmount   );
            text.AppendLine();
            text.Append("dentalElementCode :" + dentalElementCode);
            text.AppendLine();
            text.Append("nrOfTreatments    :" + nrOfTreatments   );
            text.AppendLine();
            text.Append("referenceNumber   :" + referenceNumber  );
            text.AppendLine();
            text.Append("tariffAmount      :" + tariffAmount     );
            text.AppendLine();
            text.Append("therapistAGBCode  :" + therapistAGBCode );
            text.AppendLine();
            text.Append("typeOfTreatment   :" + typeOfTreatment  );
            text.AppendLine();
            text.Append("calculatedAmount  :" + calculatedAmount );
            text.AppendLine();
            text.Append(VektisUtils.listToString<Violation>(violations));
            text.AppendLine();

            text.Append("---");
            text.AppendLine();

            return text.ToString();
        }

        public static List<Treatment> getTestTreatments() {
            List<Treatment> treatments = new List<Treatment>();
            treatments.Add(getTestTreatment());

            return treatments;
        }

        public static Treatment getTestTreatment()
        {
            Treatment treatment = new Treatment();

            treatment.code = "B10";
            treatment.description = "Uitleg voor het geven van een roesje (lachgas)";
            treatment.addendum = "Bedoeld voor uitleg in de eerste zitting. Eenmalig in rekening te brengen bij eerste zitting";

            treatment.tariffAmount = new decimal(27.63);
            treatment.calculatedAmount = treatment.tariffAmount;
            treatment.date = "2018-01-01";
            treatment.declaredAmount = treatment.tariffAmount;
            treatment.dentalElementCode = "23";
            treatment.nrOfTreatments = 1;
            treatment.referenceNumber = "referenceNumber";
            treatment.therapistAGBCode = "therapistAGBCode";
            treatment.typeOfTreatment = 1;


            return treatment;
        }

        public static Treatment getDefaultInputTreatment(String previousTreatmentDate)
        {
            Treatment treatment = new Treatment();


            treatment.date = previousTreatmentDate;
            treatment.nrOfTreatments = 1;
            treatment.referenceNumber = "referenceNumber";
            treatment.typeOfTreatment = 1;


            return treatment;
        }
    }
}
