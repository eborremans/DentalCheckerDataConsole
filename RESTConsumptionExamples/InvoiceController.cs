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
        RequestResponseController responseRequestController = new RequestResponseController();
        
        public void getInvoice(IInvoiceView invoiceView, IInputView inputView)
        {
            // HttpWebRequest request = RequestResponseController.createInvoiceRequest(url_CB.Text, apiKey_TXT.Text, invoiceNr_TXT.Text);
            HttpWebRequest request = RequestResponseController.createInvoiceRequest(inputView.getSelectedURL(), inputView.getAPIKey(), inputView.getSelectedInvoicePublicId());
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
                // json_TXT.Text = invoice.ToString();
                invoiceView.setInvoice(invoice.ToString());
            }
            catch (Exception exc)
            {
                // json_TXT.Text = exc.Message;
                invoiceView.setInvoice(exc.Message);
            }
            // prettyJSon_TXT.Text = formattedJson;
            invoiceView.setInvoiceJSon(formattedJson);
        }

        public void getInvoicePublicIds(IInvoiceView invoiceView, IInputView inputView)
        {
            // HttpWebRequest request = RequestResponseController.createInvoicePublicIdsRequest(url_CB.Text, apiKey_TXT.Text);
            HttpWebRequest request = RequestResponseController.createInvoicePublicIdsRequest(inputView.getSelectedURL(), inputView.getAPIKey());
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
