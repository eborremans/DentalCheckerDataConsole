using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

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

        public void loadConfiguration()
        {
            Configuration configuration = new Configuration();

            XmlSerializer ser = new XmlSerializer(typeof(Configuration));

            try {
                using (FileStream fs = new FileStream(@"configuration.local.xml", FileMode.Open))
                {
                    configuration = (Configuration)ser.Deserialize(fs);
                }
            } catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            inputView.setConfiguration(configuration);

            Debug.WriteLine("Configuration loaded:");
            Debug.WriteLine(configuration.ToString());
        }

        public void storeConfiguration()
        {
            Configuration configuration = new Configuration();

            configuration = inputView.getConfiguration();

            XmlSerializer ser = new XmlSerializer(typeof(Configuration));

            try
            {
                using (FileStream fs = new FileStream(@"configuration.local.xml", FileMode.OpenOrCreate))
                {
                    ser.Serialize(fs, configuration);
                }
            } catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            Debug.WriteLine("Configuration saved:");
            Debug.WriteLine(configuration.ToString());
        }

    }
}
