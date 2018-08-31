using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalCheckerDataConsole
{
    public class InputTreatment : SimpleTreatment
    {
        public String          date              { get; set; }
        public Decimal         declaredAmount    { get; set; }
        public String          dentalElementCode { get; set; }
        public Int16           nrOfTreatments    { get; set; }
        public Decimal         tariffAmount      { get; set; }
        public Int16?           typeOfTreatment   { get; set; }
        public Decimal         calculatedAmount  { get; set; }

        public InputTreatment(
            string code,
            string description,
            string addendum,
            decimal calculatedAmount, 
            string date, 
            decimal declaredAmount, 
            string dentalElementCode, 
            short nrOfTreatments, 
            decimal tariffAmount, 
            Int16? typeOfTreatment) : base(code, description, addendum)
        {
            this.calculatedAmount = calculatedAmount;
            this.date = date;
            this.declaredAmount = declaredAmount;
            this.dentalElementCode = dentalElementCode;
            this.nrOfTreatments = nrOfTreatments;
            this.tariffAmount = tariffAmount;
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
            text.Append("tariffAmount      :" + tariffAmount     );
            text.AppendLine();
            text.Append("typeOfTreatment   :" + typeOfTreatment  );
            text.AppendLine();
            text.Append("calculatedAmount  :" + calculatedAmount );
            text.AppendLine();

            text.Append("---");
            text.AppendLine();

            return text.ToString();
        }
    }
}
