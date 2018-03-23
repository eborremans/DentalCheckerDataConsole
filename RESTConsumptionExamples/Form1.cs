using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace RESTConsumptionExamples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getDentalCheckerVersionResponse_BTN_Click(object sender, EventArgs ex)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:28081/dental-checker/version");

            request.Method = "GET";

            // "Accept: */*" --header "CallerID: TESTING" --header "api_key: -----"
            request.Headers.Add("CallerID", "TESTING");
            String apiKey = apiKey_TXT.Text;
            request.Headers.Add("api_key", apiKey);

            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            HttpWebResponse response = null;
            try {
                response = (HttpWebResponse)request.GetResponse();
            } catch (Exception exc) {
                MessageBox.Show(exc.Message);
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

            json_TXT.Text = text.ToString();
       }
    }
}
