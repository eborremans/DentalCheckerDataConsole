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
    public partial class mainForm : Form, IInputView, IInvoiceView
    {
        private InvoiceController invoiceController = new InvoiceController();
        List<String> invoicePublicIdsList = new List<String>();
        SimpleInvoice invoice = null;

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
            getInvoice();
        }

        private void getInvoice()
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

            SimpleInvoice invoice = null;
            string formattedJson = "";

            try
            {
                JToken jt = JToken.Parse(content);
                formattedJson = jt.ToString();

                invoice = Newtonsoft.Json.JsonConvert.DeserializeObject<SimpleInvoice>(content);
                json_TXT.Text = invoice.ToString();
            }
            catch (Exception exc)
            {
                json_TXT.Text = exc.Message;
            }
            prettyJSon_TXT.Text = formattedJson;
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

            invoicePublicIds_CB.DataSource = invoicePublicIdsList;
            //if (invoicePublicIdsList.Count > 0)
            //{ 
            //    invoicePublicIds_CB.DisplayMember = invoicePublicIdsList[0];
            //} else
            //{
            //    invoicePublicIds_CB.DisplayMember = "<empty>";
            //}

            getInvoice_BTN.Select();
            loadConfiguration();
        }

        private void invoicePublicIds_CB_SelectedValueChanged(object sender, EventArgs e)
        {
            invoiceNr_TXT.Text = invoicePublicIds_CB.SelectedItem.ToString();
        }

        private void invoicePublicIds_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            invoiceController.getInvoice(this, this);
        }

        private void getInvoicePublicIds_BTN_Click(object sender, EventArgs e)
        {
            invoiceController.getInvoicePublicIds(this, this);
        }

        private void testResponse_BTN_Click(object sender, EventArgs e)
        {

        }

        public string getAPIKey()
        {
            return apiKey_TXT.Text;
        }

        public string getSelectedURL()
        {
            return url_CB.Text;
        }

        public string getSelectedInvoicePublicId()
        {
            return invoicePublicIds_CB.Text;
        }

        public HttpWebResponse getResponse(HttpWebRequest request)
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

        public void setInvoice(string invoice)
        {
            json_TXT.Text = invoice;
        }

        public void setInvoice(SimpleInvoice invoice)
        {
            this.invoice = invoice;
        }

        public void setInvoicePublicIds(List<string> invoicePublicIds)
        {
            invoicePublicIds_CB.DataSource = invoicePublicIds;
        }

        public void setInvoiceJSon(string invoiceJSon)
        {
            prettyJSon_TXT.Text = invoiceJSon;
        }
    }
}
