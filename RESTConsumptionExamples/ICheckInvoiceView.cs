using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTConsumptionExamples
{
    public interface ICheckInvoiceView
    {
        void setCustomerExternalIds(List<String> customerExternalIds);
        void setCustomer(Customer customer);
        void setCustomerJSon(String json);
        void setCustomerInvoice(SimpleInvoice invoice);
        void setInvoicePublicId(String invoicePublicId);

        void setMessage(String message);

        String getCurrentCustomerId();

        void uploadInvoice();
        void checkInvoice(String invoiceId);
    }
}
