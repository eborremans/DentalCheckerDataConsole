using System;
using System.Collections.Generic;
using System.Collections;
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
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Diagnostics;

namespace RESTConsumptionExamples
{
    public partial class mainForm : Form, IInputView, IInvoiceView, IReferenceDataView
    {
        private InvoiceController invoiceController = null;
        private ConfigurationController configurationController = null;
        private TestController testController = null;
        private ReferenceDataController referenceDataController = null;

        private List<String> invoicePublicIdsList = new List<String>();
        private List<String> invoicePatientIds = new List<String>();
        private Dictionary<String, Patient> invoicePatients = new Dictionary<String, Patient>();

        private SimpleInvoice invoice = null;

        private List<String> patientViolations = new List<String>();

        private Configuration configuration = new Configuration();
        
        public mainForm()
        {
            InitializeComponent();
            invoiceController = new InvoiceController(this, this);
            configurationController = new ConfigurationController(this);
            referenceDataController = new ReferenceDataController(this, this);
            testController = new TestController(this, this);
        }

        private void getDentalCheckerVersionResponse_BTN_Click(object sender, EventArgs ex)
        {
            testController.getVersionInfo();
        }

        private void getInvoice_BTN_Click(object sender, EventArgs e)
        {
            invoiceController.getInvoice();
        }

        private void loadKey_BTN_Click(object sender, EventArgs e)
        {
            configurationController.loadConfiguration();
        }

        private void saveKey_BTN_Click(object sender, EventArgs e)
        {
            configurationController.storeConfiguration();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            configurationController.loadConfiguration();

            url_CB.SelectedIndex = 0;
            yearSelection_CB.SelectedIndex = 3;

            getInvoice_BTN.Select();
        }

        private void invoicePublicIds_CB_SelectedValueChanged(object sender, EventArgs e)
        {
            invoiceNr_TXT.Text = invoicePublicIds_CB.SelectedItem.ToString();
        }

        private void invoicePublicIds_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            invoiceController.getInvoice();
        }

        private void getInvoicePublicIds_BTN_Click(object sender, EventArgs e)
        {
            invoiceController.getInvoicePublicIds();
        }

        // ------------------ IInputView ------------------
        public string getAPIKey()
        {
            return apiKey_TXT.Text;
        }

        public void setAPIKey(String apiKey)
        {
            apiKey_TXT.Text = apiKey;
        }

        public string getSelectedURL()
        {
            return url_CB.Text;
        }

        public Configuration getConfiguration() {

            configuration.apiKey = apiKey_TXT.Text;
            configuration.urls = url_CB.Items.Cast<String>().ToList();
            configuration.currentInvoiceId = invoiceNr_TXT.Text;
            configuration.currentUrl = url_CB.SelectedItem.ToString();

            return configuration;
        }

        public void setConfiguration(Configuration configuration)
        {
            this.configuration = configuration;
            url_CB.DataSource = this.configuration.urls;
            apiKey_TXT.Text = this.configuration.apiKey;
            invoiceNr_TXT.Text = this.configuration.currentInvoiceId;
        }

        public void setSelectedURL(String url) { url_CB.Text = url; }

        public List<String> getURLs() { return url_CB.Items.Cast<String>().ToList(); }
        public void setURLs(List<String> urls)
        {
            url_CB.Items.Clear();
            url_CB.Items.AddRange(urls.ToArray());
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

        // ------------------ IInvoiceView ------------------
        public void setInvoice(string invoice)
        {
            json_TXT.Text = invoice;
        }

        public void setInvoice(SimpleInvoice invoice)
        {
            this.invoice = invoice;
        }

        public String getInvoiceString()
        {
            return json_TXT.Text;
        }

        public void setInvoicePublicIds(List<String> invoicePublicIds)
        {
            invoicePublicIds_CB.DataSource = invoicePublicIds;
        }

        public void setInvoiceJSon(String invoiceJSon)
        {
            prettyJSon_TXT.Text = invoiceJSon;
        }

        public void setCustomerMessage(String customerMessage)
        {
            checkReportRenderer_WB.DocumentText = customerMessage;
        }

        public void setInvoicePatients(List<Patient> patients)
        {
            invoicePatients = new Dictionary<string, Patient>();
            invoicePatientIds = new List<String>();
            foreach (Patient patient in patients) {
                invoicePatients.Add(patient.patientExternalId, patient);
                invoicePatientIds.Add(patient.patientExternalId);
            }
            patientExternalId_CB.DataSource = invoicePatientIds;
        }

        public void setInvoiceSelectedPatient(Patient patient)
        {
            if (null != patient)
            {
                patientHealthInsurance_TXT.Text = patient.healthInsuranceName;
                patientBirthdate_TXT.Text = patient.patientBirthdate;
                patientPolicyNumber_TXT.Text = patient.patientPolicyNumber;
            }
        }

        private void patientExternalId_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedPatientId = patientExternalId_CB.SelectedItem.ToString();
            Patient selectedPatient = invoicePatients[selectedPatientId];
            if (null != selectedPatient) { 
                setInvoiceSelectedPatient(selectedPatient);
                setInvoiceSelectedPatientTreatments(selectedPatient.treatments);
            }
        }

        public void setInvoiceSelectedPatientTreatments(List<Treatment> treatments)
        {
            patientTreatments_DGV.DataSource = treatments;
            List<String> allViolations = new List<String>();
            foreach(Treatment treatment in treatments)
            {
                List<Violation> treatmentViolations = treatment.violations;
                foreach(Violation violation in treatmentViolations)
                {
                    violation.treatmentRef = treatment.code + "-" + treatment.referenceNumber;
                    allViolations.Add(violation.ToString());
                }
            }
            setPatientViolations(allViolations);
        }

        public void setPatientViolations(List<String> violations)
        {
            patientViolations = violations;
            patientViolations_LB.DataSource = patientViolations;
        }

        private void testResponse_BTN_Click(object sender, EventArgs e)
        {
            serializeTest();
        }

        public void serializeTest()
        {
            Configuration c = new Configuration();

            c.apiKey = "the apikey";
            c.urls = new List<String>();

            c.urls.Add("http://url1");
            c.urls.Add("http://url2");

            XmlSerializer ser = new XmlSerializer(typeof(Configuration));

            using (FileStream fs = new FileStream(@"sertest.xml", FileMode.Create))
            {
                ser.Serialize(fs, c);
            }
        }

        public void deSerializeTest()
        {
            Configuration c = new Configuration();

            XmlSerializer ser = new XmlSerializer(typeof(Configuration));

            using (FileStream fs = new FileStream(@"sertest.xml", FileMode.Open))
            {
                c = (Configuration)ser.Deserialize(fs);
            }
            Debug.WriteLine(c.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deSerializeTest();
        }

        private void apiKey_TXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadRefData_BTN_Click(object sender, EventArgs e)
        {
            String year = yearSelection_CB.SelectedItem.ToString();
            referenceDataController.getReferenceData(yearStringToInteger(year));
        }

        private int yearStringToInteger(String yearString)
        {
            int year = 2018;
            if (!int.TryParse(yearString, out year))
            {
                MessageBox.Show("Hey, we need an int over here. Defaulting to 2018");
            }
            return year;
        }

        public int getRefDataYear()
        {
            return yearStringToInteger(yearSelection_CB.SelectedItem.ToString());
        }

        public void setReferenceDataList(List<ReferenceData> referenceDataList)
        {
            referenceData_GV.DataSource = referenceDataList;
        }
    }
}
