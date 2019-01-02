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

namespace DentalCheckerDataConsole
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

        private void createDefaultConfigurationFile()
        {
            File.Copy(@"configuration.xml", @"configuration.local.xml");
        }
        public void loadConfiguration()
        {
            Configuration configuration = new Configuration();

            XmlSerializer ser = new XmlSerializer(typeof(Configuration));

            try
            {
                if (!File.Exists(@"configuration.local.xml"))
                { 
                    createDefaultConfigurationFile();
                }
                using (FileStream fs = new FileStream(@"configuration.local.xml", FileMode.Open))
                {
                    configuration = (Configuration)ser.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
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
                    fs.SetLength(0);
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
