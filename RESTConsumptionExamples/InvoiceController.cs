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
            getInvoiceJSon();
            getCustomerMessage();
        }

        public void getInvoiceJSon()
        {
            HttpWebRequest request = RequestResponseFactory.createInvoiceRequest(inputView.getConfiguration().currentUrl, inputView.getConfiguration().apiKey, inputView.getConfiguration().currentInvoiceId);
            if (null == request)
            {
                return;
            }

            HttpWebResponse response = inputView.getResponse(request);
            if (null == response)
            {
                return;
            }

            String content = String.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }

            SimpleInvoice invoice = null;
            String formattedJson = "<No JSon found>";

            try
            {
                JToken jt = JToken.Parse(content);
                formattedJson = jt.ToString();

                invoice = Newtonsoft.Json.JsonConvert.DeserializeObject<SimpleInvoice>(content);
                if (null != invoice)
                {
                    invoiceView.setInvoicePatients(invoice.patients);
                    invoiceView.setInvoice(invoice.ToString());
                    invoiceView.setInvoiceJSon(formattedJson);
                }
            }
            catch (Exception exc)
            {
                invoiceView.setInvoice(exc.Message);
            }

            return;
        }

        public void getCustomerMessage()
        {
            HttpWebRequest request = RequestResponseFactory.createCustomerMessageRequest(inputView.getConfiguration().currentUrl, inputView.getConfiguration().apiKey, inputView.getConfiguration().currentInvoiceId);
            if (null == request)
            {
                return;
            }

            HttpWebResponse response = inputView.getResponse(request);
            if (null == response)
            {
                return;
            }

            String content = String.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }

            if (null != content)
            {
                invoiceView.setCustomerMessage(content);
            }

            return;
        }

        public void getInvoicePublicIds()
        {
            HttpWebRequest request = RequestResponseFactory.createInvoicePublicIdsRequest(inputView.getConfiguration().currentUrl, inputView.getConfiguration().apiKey);
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
