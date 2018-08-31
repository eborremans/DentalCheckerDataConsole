using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DentalCheckerDataConsole
{
    public class CustomerController
    {
        private ICheckInvoiceView checkInvoiceView = null;
        private IInputView inputView = null;

        private CustomerController() { }

        public CustomerController(ICheckInvoiceView checkInvoiceView, IInputView inputView)
        {
            this.checkInvoiceView = checkInvoiceView;
            this.inputView = inputView;
        }

        public void getCustomerExternalIds()
        {
            System.Net.HttpWebRequest request = RequestResponseFactory.createCustomerExternalIdsRequest(inputView.getConfiguration().currentUrl, inputView.getConfiguration().apiKey);
            if (null == request)
            {
                return;
            }
            System.Net.HttpWebResponse response = inputView.getResponse(request);
            if (null == response)
            {
                return;
            }

            string content = string.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var sr = new System.IO.StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }

            List<String> customerExternalIdsList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<String>>(content);

            checkInvoiceView.setCustomerExternalIds(customerExternalIdsList);
        }

        public void getCustomerJSon()
        {
            System.Net.HttpWebRequest request = RequestResponseFactory.createCustomerRequest(inputView.getConfiguration().currentUrl, inputView.getConfiguration().apiKey, checkInvoiceView.getCurrentCustomerId());
            if (null == request)
            {
                return;
            }

            System.Net.HttpWebResponse response = inputView.getResponse(request);
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

            Customer customer = null;
            String formattedJson = "<No customer JSon found>";

            try
            {
                JToken jt = JToken.Parse(content);
                formattedJson = jt.ToString();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                customer = Newtonsoft.Json.JsonConvert.DeserializeObject<Customer>(content, settings);
                if (null != customer)
                {
                    checkInvoiceView.setCustomer(customer);
                    checkInvoiceView.setCustomerJSon(formattedJson);
                }
            }
            catch (Exception exc)
            {
                checkInvoiceView.setMessage(exc.Message);
            }

            return;
        }

        public void uploadInvoice(Customer customer, SimpleInvoice newInvoice)
        {
            CreateInvoiceRequest newInvoiceRequest = new CreateInvoiceRequest();
            newInvoiceRequest.invoiceData = newInvoice;

            HttpWebRequest request = RequestResponseFactory.createNewInvoiceRequest(inputView.getConfiguration().currentUrl, inputView.getConfiguration().apiKey, newInvoiceRequest);
            if (null == request)
            {
                return;
            }

            var json = JsonConvert.SerializeObject(request);
            Debug.WriteLine(json);

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

            checkInvoiceView.setMessage(content);

            if (content.StartsWith("INV"))
            {
                checkInvoiceView.setInvoicePublicId(content);
            }

        }
        public void checkInvoice(String publicInvoiceId)
        {
            HttpWebRequest request = RequestResponseFactory.checkInvoiceRequest(inputView.getConfiguration().currentUrl, inputView.getConfiguration().apiKey, publicInvoiceId);
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

            checkInvoiceView.setMessage(content);
        }
    }
}
