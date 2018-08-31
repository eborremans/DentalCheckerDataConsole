using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalCheckerDataConsole
{
    public interface IInvoiceView
    {
        void setInvoice(String invoice);
        String getInvoiceString();

        void setInvoicePublicIds(List<String> invoicePublicIds);
        void setInvoice(SimpleInvoice invoice);
        void setInvoiceJSon(String invoiceJSon);
        void setCustomerMessage(String customerMessage);

        void setInvoicePatients(List<Patient> patients);
        void setInvoiceSelectedPatient(Patient patient);
        void setInvoiceSelectedPatientTreatments(List<Treatment> treatments);

        void setPatientViolations(List<String> violations);
    }
}
