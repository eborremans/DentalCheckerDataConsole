using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RESTConsumptionExamples
{
    public class Configuration
    {
        public String apiKey { get; set; }
        public String currentUrl { get; set; }
        public String currentInvoiceId { get; set; }

        public List<String> urls { get; set; }
        public String refDataUrl1 { get; set; }
        public String refDataUrl2 { get; set; }

        public Configuration()
        {
            urls = new List<String>();
        }

        public override String ToString()
        {
            StringBuilder text = new StringBuilder();

            text.Append("Apikey            : " + apiKey);
            text.AppendLine();
            text.Append("current url       : " + currentUrl);
            text.AppendLine();
            text.Append("Current invoice Id: " + currentInvoiceId);
            text.AppendLine();
            int counter = 0;
            foreach(String url in urls)
            {
                text.Append("url " + counter++ + " : " + url);
                text.AppendLine();
            }
            text.Append("refdata url 1     : " + refDataUrl1);
            text.AppendLine();
            text.Append("refdata url 2     : " + refDataUrl2);
            text.AppendLine();

            return text.ToString();
        }
    }
}
