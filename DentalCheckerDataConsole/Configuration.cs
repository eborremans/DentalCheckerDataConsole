using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DentalCheckerDataConsole
{
    public class Configuration
    {
        public String apiKey { get; set; }
        // public String currentApiKey { get; set; }
        public Int32 currentUrlSelectedIndex { get; set; }
        public String currentInvoiceId { get; set; }

        public List<String> urls { get; set; }
        // public Dictionary<string, string> urlApiKeyCombinations { get; set; }
        public Int32 refDataUrl1SelectedIndex { get; set; }
        public Int32 refDataUrl2SelectedIndex { get; set; }

        public Configuration()
        {
            urls = new List<String>();
        }

        public String getCurrentUrl()
        {
            try
            {
                return urls[currentUrlSelectedIndex];
            }
            catch (Exception e)
            {
                return urls[0];
            }
        }

        public String getRefDataUrl(int nr)
        {
            try
            {
                return urls[nr == 1 ? refDataUrl1SelectedIndex : refDataUrl2SelectedIndex];
            }
            catch(Exception e)
            {
                return urls[0];
            }
        }
        public override String ToString()
        {
            StringBuilder text = new StringBuilder();

            text.Append("Apikey            : " + apiKey);
            text.AppendLine();
            text.Append("current url       : " + getCurrentUrl());
            text.AppendLine();
            text.Append("Current invoice Id: " + currentInvoiceId);
            text.AppendLine();
            int counter = 0;
            foreach(String url in urls)
            {
                text.Append("url " + counter++ + " : " + url);
                text.AppendLine();
            }
            text.Append("refdata url 1     : " + getRefDataUrl(1));
            text.AppendLine();
            text.Append("refdata url 2     : " + getRefDataUrl(2));
            text.AppendLine();

            return text.ToString();
        }
    }
}
