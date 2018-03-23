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
using System.Xml;
using System.Xml.Linq;

namespace RESTConsumptionExamples
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private HttpWebRequest createVersionRequest(String apiKey)
        {
            return createRequest("http://127.0.0.1:28081/dental-checker/version", "TESTING", apiKey);
        }

        private HttpWebRequest createTreatmentListRequest(String apiKey)
        {
            return createRequest("http://127.0.0.1:28081/dental-checker/performancecodes", "", apiKey);
        }

        private HttpWebRequest createInvoiceRequest(String apiKey, String invoicePublicID)
        {
            return createRequest("http://127.0.0.1:28081/dental-checker/invoices/" + invoicePublicID, "", apiKey);
        }

        private HttpWebRequest createRequest(String url, String callerID, String apiKey)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("CallerID", callerID);
            request.Headers.Add("api_key", apiKey);

            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            return request;
        }

        private void getDentalCheckerVersionResponse_BTN_Click(object sender, EventArgs ex)
        {
            HttpWebRequest request = createVersionRequest(apiKey_TXT.Text);

            HttpWebResponse response = getResponse(request);

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

            json_TXT.Text = text.ToString();
        }

        private void getTestResponse_BTN_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = createTreatmentListRequest(apiKey_TXT.Text);

            HttpWebResponse response = getResponse(request);
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

            List<SimpleReferenceData> refdataList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SimpleReferenceData>>(content);

            json_TXT.Text = VektisUtils.listToString<SimpleReferenceData>(refdataList);
        }

        private HttpWebResponse getResponse(HttpWebRequest request)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return null;
            }

            return response;
        }

        private void storeApiKey()
        {
            string text1 = apiKey_TXT.Text;
            //string text2 = /* get value of textbox */;
            //string text3 = /* get value of textbox */;

            // Set indent=true so resulting file is more 'human-readable'
            System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings() { Indent = true };

            // Put writer in using scope; after end of scope, file is automatically saved.
            using (XmlWriter writer = XmlTextWriter.Create("apikey.key", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                writer.WriteElementString("apiKey", text1);
                //writer.WriteElementString("text2", text2);
                //writer.WriteElementString("text3", text3);
                writer.WriteEndElement();
            }
        }

        private void loadApiKey()
        {
            String apiKey = "<no key found>";

            try
            {
                using (XmlReader reader = XmlReader.Create("apikey.key"))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            if (reader.ReadToDescendant("apiKey"))
                            {
                                reader.Read();
                                apiKey = reader.Value;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            if (apiKey != apiKey_TXT.Text)
            {
                apiKey_TXT.Text = apiKey;
            }
        }

        private void loadKey_BTN_Click(object sender, EventArgs e)
        {
            loadApiKey();
        }

        private void saveKey_BTN_Click(object sender, EventArgs e)
        {
            storeApiKey();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            getInvoice_BTN.Select();
            loadApiKey();
        }

        private void getInvoice_BTN_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = createInvoiceRequest(apiKey_TXT.Text, invoiceNr_TXT.Text);

            HttpWebResponse response = getResponse(request);
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

            SimpleInvoice invoice = Newtonsoft.Json.JsonConvert.DeserializeObject<SimpleInvoice>(content);

            json_TXT.Text = invoice.ToString();

            JToken jt = JToken.Parse(content);
            string formattedJson = jt.ToString();
            prettyJSon_TXT.Text = formattedJson;
        }
    }
}
