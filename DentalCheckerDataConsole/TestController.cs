using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DentalCheckerDataConsole
{
    public class TestController
    {
        private IInputView inputView = null;
        private IInvoiceView invoiceView = null;

        private TestController()
        {
        }

        public TestController(IInvoiceView invoiceView, IInputView inputView)
        {
            this.invoiceView = invoiceView;
            this.inputView = inputView;
        }

        public void getVersionInfo()
        {
            HttpWebRequest request = RequestResponseFactory.createVersionRequest(inputView.getConfiguration().getCurrentUrl(), inputView.getConfiguration().apiKey);
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

            Hashtable t = Newtonsoft.Json.JsonConvert.DeserializeObject<Hashtable>(content);

            StringBuilder text = new StringBuilder();
            foreach (DictionaryEntry pair in t)
            {
                text.Append(pair.Key + ": " + pair.Value);
                text.AppendLine();
            }

            invoiceView.setInvoice(text.ToString());
        }
    }
}
