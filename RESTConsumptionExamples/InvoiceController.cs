using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RESTConsumptionExamples
{
    public class InvoiceController
    {
        private IInputView inputView = null;
        private IInvoiceView invoiceView = null;

        RequestResponseController responseRequestController = new RequestResponseController();

        private InvoiceController()
        {
        }

        public InvoiceController(IInvoiceView invoiceView, IInputView inputView)
        {
            this.invoiceView = invoiceView;
            this.inputView = inputView;
        }

        public void getInvoice()
        {
            // HttpWebRequest request = RequestResponseController.createInvoiceRequest(inputView.getSelectedURL(), inputView.getAPIKey(), inputView.getSelectedInvoicePublicId());
            HttpWebRequest request = RequestResponseController.createInvoiceRequest(inputView.getConfiguration().currentUrl, inputView.getConfiguration().apiKey, inputView.getConfiguration().currentInvoiceId);
            if (null == request)
            {
                return;
            }

            HttpWebResponse response = inputView.getResponse(request);
            if (null == response)
            {
                return;
            }

            string content = string.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }

            SimpleInvoice invoice = null;
            string formattedJson = "";

            try
            {
                JToken jt = JToken.Parse(content);
                formattedJson = jt.ToString();

                invoice = Newtonsoft.Json.JsonConvert.DeserializeObject<SimpleInvoice>(content);
                if (null != invoice) {
                    invoiceView.setInvoicePatients(invoice.patients);
                    invoiceView.setInvoice(invoice.ToString());
                }
            }
            catch (Exception exc)
            {
                invoiceView.setInvoice(exc.Message);
            }
            invoiceView.setInvoiceJSon(formattedJson);
        }

        public void getInvoicePublicIds()
        {
            HttpWebRequest request = RequestResponseController.createInvoicePublicIdsRequest(inputView.getConfiguration().currentUrl, inputView.getConfiguration().apiKey);
            if (null == request)
            {
                return;
            }
            HttpWebResponse response = inputView.getResponse(request);
            if (null == response)
            {
                return;
            }

            string content = string.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }

            List<String> invoicePublicIdsList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<String>>(content);

            invoiceView.setInvoicePublicIds(invoicePublicIdsList);
        }

    }
}
