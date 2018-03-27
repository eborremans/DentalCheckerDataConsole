using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RESTConsumptionExamples
{
    public class ConfigurationController
    {
        IInputView inputView = null;

        private ConfigurationController() { }

        public ConfigurationController(IInputView inputView)
        {
            this.inputView = inputView;
        }

        public void setInputView(IInputView inputView)
        {
            this.inputView = inputView;
        }

        public void storeConfiguration()
        {
            // Set indent=true so resulting file is more 'human-readable'
            System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings() { Indent = true };

            // Put writer in using scope; after end of scope, file is automatically saved.
            using (XmlWriter writer = XmlTextWriter.Create("configuration.local.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                writer.WriteElementString("apiKey", inputView.getAPIKey());
                // writer.WriteElementString("url", url_TXT.Text);
                writer.WriteEndElement();
            }
        }

        public void loadConfiguration()
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

            if (apiKey != inputView.getAPIKey())
            {
                inputView.setAPIKey(apiKey);
            }
            //if (url != url_TXT.Text)
            //{
            //    url_TXT.Text = url;
            //}

        }
    }
}
