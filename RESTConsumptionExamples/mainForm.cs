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
        private InvoiceController invoiceController = new InvoiceController();

        public mainForm()
        {
            InitializeComponent();
        }


        private void getDentalCheckerVersionResponse_BTN_Click(object sender, EventArgs ex)
        {
            HttpWebRequest request = RequestResponseController.createVersionRequest(url_CB.Text, apiKey_TXT.Text);
            if (null == request)
            {
                return;
            }
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

        private void getInvoice_BTN_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = RequestResponseController.createInvoiceRequest(url_CB.Text, apiKey_TXT.Text, invoiceNr_TXT.Text);
            if (null == request)
            {
                return;
            }

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

        private void getTestResponse_BTN_Click(object sender, EventArgs e)
        {
            // HttpWebRequest request = RequestResponseController.createTreatmentListRequest(url_CB.Text, apiKey_TXT.Text);
            HttpWebRequest request = RequestResponseController.createInvoicePublicIdsRequest(url_CB.Text, apiKey_TXT.Text);
            if (null == request)
            {
                return;
            }
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

            // List<SimpleReferenceData> refdataList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SimpleReferenceData>>(content);
            List<String> invoicePublicIdsList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<String>>(content);

            StringBuilder invoicePublicIds = new StringBuilder();

            foreach (String invoicePublicId in invoicePublicIdsList)
            {
                invoicePublicIds.Append(invoicePublicId);
                invoicePublicIds.AppendLine();
            }

            json_TXT.Text = invoicePublicIds.ToString();
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

        private void storeConfiguration()
        {
            // Set indent=true so resulting file is more 'human-readable'
            System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings() { Indent = true };

            // Put writer in using scope; after end of scope, file is automatically saved.
            using (XmlWriter writer = XmlTextWriter.Create("configuration.local.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                writer.WriteElementString("apiKey", apiKey_TXT.Text);
                // writer.WriteElementString("url", url_TXT.Text);
                writer.WriteEndElement();
            }
        }

        private void loadConfiguration()
        {
            String apiKey = "<no api key found>";
            //  String url = "<no url found>";

            try
            {
                using (XmlReader reader = XmlReader.Create("configuration.local.xml"))
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
                            //if (reader.ReadToDescendant("url"))
                            //{
                            //    reader.Read();
                            //    url = reader.Value;
                            //    break;
                            //}
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
            //if (url != url_TXT.Text)
            //{
            //    url_TXT.Text = url;
            //}
        }

        private void loadKey_BTN_Click(object sender, EventArgs e)
        {
            loadConfiguration();
        }

        private void saveKey_BTN_Click(object sender, EventArgs e)
        {
            storeConfiguration();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            url_CB.SelectedIndex = 0;
            getInvoice_BTN.Select();
            loadConfiguration();
        }

    }
}
