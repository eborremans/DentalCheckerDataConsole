using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTConsumptionExamples
{
    public interface IInvoiceView
    {
        void setInvoice(String invoice);

        void setInvoicePublicIds(List<String> invoicePublicIds);
        void setInvoice(SimpleInvoice invoice);
        void setInvoiceJSon(String invoiceJSon);

        void setInvoicePatients(List<Patient> patients);
        void setInvoiceSelectedPatient(Patient patient);
        void setInvoiceSelectedPatientTreatments(List<Treatment> treatments);
    }
}
