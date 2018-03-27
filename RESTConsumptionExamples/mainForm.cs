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
using System.Collections;
using System.Xml;
using System.Xml.Linq;

namespace RESTConsumptionExamples
{
    public partial class mainForm : Form, IInputView, IInvoiceView
    {
        private InvoiceController invoiceController = null;
        private ConfigurationController configurationController = null;
        private TestController testController = null;

        private List<String> invoicePublicIdsList = new List<String>();
        private List<String> invoicePatientIds = new List<String>();
        private Dictionary<String, Patient> invoicePatients = new Dictionary<String, Patient>();

        private SimpleInvoice invoice = null;

        public mainForm()
        {
            InitializeComponent();
            invoiceController = new InvoiceController(this, this);
            configurationController = new ConfigurationController(this);
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
            url_CB.SelectedIndex = 0;

            getInvoice_BTN.Select();

            configurationController.loadConfiguration();
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

        private void testResponse_BTN_Click(object sender, EventArgs e)
        {

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

        public string getSelectedInvoicePublicId()
        {
            return invoiceNr_TXT.Text;
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

        public void setInvoicePublicIds(List<string> invoicePublicIds)
        {
            invoicePublicIds_CB.DataSource = invoicePublicIds;
        }

        public void setInvoiceJSon(string invoiceJSon)
        {
            prettyJSon_TXT.Text = invoiceJSon;
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
        }
    }
}
