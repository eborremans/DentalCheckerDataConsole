using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTConsumptionExamples
{
    public class SimpleInvoice
    {
        public String invoicePublicId { get; set; }

        public String clinicAGBCode { get; set; }
        public String customerExternalId { get; set; }
        public String dcInvoicePublicId { get; set; }
        public String declarerAGBCode { get; set; }
        public String healthcareProviderName { get; set; }
        public String institutionAGBCdde { get; set; }
        public String invoiceDate { get; set; }
        public String invoiceNumber { get; set; }
        public List<Patient> patients { get; set; }

        public SimpleInvoice() { }
        public SimpleInvoice(
            string invoicePublicId,
            string clinicAGBCode, 
            string customerExternalId, 
            string dcInvoicePublicId, 
            string declarerAGBCode, 
            string healthcareProviderName, 
            string institutionAGBCdde, 
            string invoiceDate, 
            string invoiceNumber, 
            List<Patient> patients
            )
        {
            this.invoicePublicId = invoicePublicId;

            this.clinicAGBCode = clinicAGBCode;
            this.customerExternalId = customerExternalId;
            this.dcInvoicePublicId = dcInvoicePublicId;
            this.declarerAGBCode = declarerAGBCode;
            this.healthcareProviderName = healthcareProviderName;
            this.institutionAGBCdde = institutionAGBCdde;
            this.invoiceDate = invoiceDate;
            this.invoiceNumber = invoiceNumber;
            this.patients = patients;
        }

        public override String ToString()
        {
            StringBuilder text = new StringBuilder();

            text.Append("invoicePublicId        :" + invoicePublicId);
            text.AppendLine();
            text.Append("clinicAGBCode          :" + clinicAGBCode);
            text.AppendLine();
            text.Append("customerExternalId     :" + customerExternalId);
            text.AppendLine();
            text.Append("dcInvoicePublicId      :" + dcInvoicePublicId);
            text.AppendLine();
            text.Append("declarerAGBCode        :" + declarerAGBCode);
            text.AppendLine();
            text.Append("healthcareProviderName :" + healthcareProviderName);
            text.AppendLine();
            text.Append("institutionAGBCdde     :" + institutionAGBCdde);
            text.AppendLine();
            text.Append("invoiceDate            :" + invoiceDate);
            text.AppendLine();
            text.Append("invoiceNumber          :" + invoiceNumber);
            text.AppendLine();
            text.Append("patients               :");
            text.AppendLine();
            text.Append(VektisUtils.listToString<Patient>(patients));
            text.AppendLine();
            text.Append("---");
            text.AppendLine();

            return text.ToString();
        }

        public static SimpleInvoice getTestInvoice()
        {
            SimpleInvoice invoice = new SimpleInvoice();

            invoice.invoicePublicId = "invoicePublicId";
            invoice.clinicAGBCode = "clinicAGBCode";
            invoice.customerExternalId = "";
            invoice.dcInvoicePublicId = "dcInvoicePublicId";
            invoice.declarerAGBCode = "declarerAGBCode";
            invoice.healthcareProviderName = "healthcareProviderName";
            invoice.institutionAGBCdde = "institutionAGBCdde";
            DateTime now = DateTime.Now;
            invoice.invoiceDate = DateUtils.today();
            invoice.invoiceNumber = "invoiceNumber";

            invoice.patients = Patient.getTestPatients();

            return invoice;
        }

        public static SimpleInvoice getTestInvoice(Customer customer)
        {
            SimpleInvoice invoice = getTestInvoice();

            invoice.patients = Patient.getTestPatients(customer);

            return invoice;
        }
    }
}
