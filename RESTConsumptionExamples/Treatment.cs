using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTConsumptionExamples
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
        public Int16           typeOfTreatment   { get; set; }
        public Decimal         calculatedAmount  { get; set; }
        public List<Violation> violations        { get; set; }

        public Treatment(
            string code,
            string description,
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
            short typeOfTreatment) : base(code, description)
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
    }
}
