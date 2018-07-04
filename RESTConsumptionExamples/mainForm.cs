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
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace RESTConsumptionExamples
{
    // Main view
    public partial class mainForm : Form, IInputView, IInvoiceView, IReferenceDataView
    {
        private const int CODE_COL_IDX = 1;

        // Controls the retrieval of invoice data
        private InvoiceController invoiceController = null; 
        // Controls the retrieval and storage of configuration data
        private ConfigurationController configurationController = null;
        // Controls test functionality
        private TestController testController = null;
        // Controls the retrieval of reference data
        private ReferenceDataController referenceDataController = null;

        // Contains the list of invoices 
        private List<String> invoicePublicIdsList = new List<String>();
        // Contains the ids of patients in the currently selected invoice
        private List<String> invoicePatientIds = new List<String>();
        // List of Patients from the currently selected invoice
        private Dictionary<String, Patient> invoicePatients = new Dictionary<String, Patient>();

        // Currently selected invoice
        private SimpleInvoice invoice = null;

        // Violations found in the currently selected invoice
        private List<String> patientViolations = new List<String>();

        List<String> refDataUrls1 { get; set; }
        List<String> refDataUrls2 { get; set; }
        
        // Upper reference data grid contents
        public List<ReferenceData> referenceData1 { get; set; }
        // Lower reference data grid contents
        public List<ReferenceData> referenceData2 { get; set; }

        // Configuration class
        private Configuration configuration = new Configuration();

        // To mark the phase where the main form is being loaded
        private bool loading = true;

        public mainForm()
        {
            InitializeComponent();
            InitializeCustom();
            invoiceController = new InvoiceController(this, this);
            configurationController = new ConfigurationController(this);
            referenceDataController = new ReferenceDataController(this, this);
            testController = new TestController(this, this);
        }

        private void InitializeCustom()
        {
            DateTime now = DateTime.Now;
            DateTime endDate = new DateTime(now.Year, now.Month, now.Day);
            // DateTime startDate = endDate.Subtract(new TimeSpan(90, 0, 0, 0));
            DateTime startDate = new DateTime(2016, 1, 1);

            startDatePicker_DTP.Value = startDate;
            endDatePicker_DTP.Value = endDate;
        }

        // Test button
        private void getDentalCheckerVersionResponse_BTN_Click(object sender, EventArgs ex)
        {
            testController.getVersionInfo();
        }

        // Retrieves the invoice based on the id in invoiceNr_TXT
        private void getInvoice_BTN_Click(object sender, EventArgs e)
        {
            invoiceController.getInvoice();
        }

        // Load de api key from the configuration file
        private void loadKey_BTN_Click(object sender, EventArgs e)
        {
            configurationController.loadConfiguration();
            if (null == codeFilter_TXT.Text) {
                codeFilter_TXT.Text = "";
            }
        }

        private void saveKey_BTN_Click(object sender, EventArgs e)
        {
            configurationController.storeConfiguration();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            loading = true;
            configurationController.loadConfiguration();

            url_CB.SelectedIndex = 0;
            year1Selection_CB.SelectedIndex = 3;
            year2Selection_CB.SelectedIndex = 3;

            getInvoice_BTN.Select();

            // startDatePicker_DTP.Value = DateTime.Now.AddDays(-31);
            // endDatePicker_DTP.Value = DateTime.Now;

            loading = false;
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


        public void setSelectedURL(String url) { url_CB.Text = url; }

        public List<String> getURLs() { return url_CB.Items.Cast<String>().ToList(); }
        public void setURLs(List<String> urls)
        {
            url_CB.Items.Clear();
            url_CB.Items.AddRange(urls.ToArray());
        }

        // ------------------ IInputView ------------------
        // getConfiguration();
        // setConfiguration(Configuration configuration);
        // getResponse(HttpWebRequest request);
        // getRefDataYear();
        // getDateRange();

        public Configuration getConfiguration()
        {

            try
            {
                configuration.apiKey = apiKey_TXT.Text;
                configuration.urls = url_CB.Items.Cast<String>().ToList();
                configuration.currentInvoiceId = invoiceNr_TXT.Text;
                configuration.currentUrl = url_CB.SelectedItem.ToString();
                configuration.refDataUrl1 = refDataURL1_CB.SelectedItem.ToString();
                configuration.refDataUrl2 = refDataURL2_CB.SelectedItem.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return null;
            }
            return configuration;
        }

        public void setConfiguration(Configuration configuration)
        {
            this.configuration = configuration;
            url_CB.DataSource = this.configuration.urls;
            apiKey_TXT.Text = this.configuration.apiKey;
            invoiceNr_TXT.Text = this.configuration.currentInvoiceId;

            refDataUrls1 = new List<String>(this.configuration.urls.ToList());
            refDataUrls2 = new List<String>(this.configuration.urls.ToList());
            refDataURL1_CB.DataSource = refDataUrls1;
            refDataURL2_CB.DataSource = refDataUrls2;

            //refDataURL1_CB.SelectedText = this.configuration.refDataUrl1;
            //refDataURL2_CB.SelectedText = this.configuration.refDataUrl2;
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
                // MessageBox.Show(exc.Message);
                return null;
            }

            return response;
        }

        public int getRefDataYear()
        {
            return yearStringToInteger(year1Selection_CB.SelectedItem.ToString());
        }

        public DateRangeRequest getDateRange()
        {
            DateRangeRequest request = new DateRangeRequest();
            request.startDate = startDatePicker_DTP.Value;
            request.endDate = endDatePicker_DTP.Value;

            return request;
        }

        // ------------------ IInvoiceView ------------------
        public void setInvoice(string invoice)
        {
            json_TXT.Text = invoice;
        }

        public void setInvoice(SimpleInvoice invoice)
        {
            this.invoice = invoice;
            if(null != invoice)
            {
                invoiceDate_TXT.Text = invoice.invoiceDate;
            }
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
            // deSerializeTest();
            MessageBox.Show("Date start: " + startDatePicker_DTP.Text);
        }

        private void apiKey_TXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadRefData_BTN_Click(object sender, EventArgs e)
        {
            loadReferenceData1();
            loadReferenceData2();
        }

        private void loadReferenceData1()
        {
            String year1 = year1Selection_CB.SelectedItem.ToString();
            referenceDataController.getReferenceData1(yearStringToInteger(year1));
        }

        private void loadReferenceData2()
        {
            String year2 = year2Selection_CB.SelectedItem.ToString();
            referenceDataController.getReferenceData2(yearStringToInteger(year2));
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

        public void setReferenceDataList1(List<ReferenceData> referenceDataList)
        {
            referenceData1 = referenceDataList;
            SortableBindingList<ReferenceData> sortableReferenceData = new SortableBindingList<ReferenceData>(referenceData1.ToList());
            referenceData1_GV.DataSource = sortableReferenceData;
            referenceData1_GV.Sort(referenceData1_GV.Columns[0], ListSortDirection.Ascending);
        }

        public void setReferenceDataList2(List<ReferenceData> referenceDataList)
        {
            referenceData2 = referenceDataList;
            SortableBindingList<ReferenceData> sortableReferenceData = new SortableBindingList<ReferenceData>(referenceData2.ToList());
            referenceData2_GV.DataSource = sortableReferenceData;
            referenceData2_GV.Sort(referenceData2_GV.Columns[0], ListSortDirection.Ascending);
        }

        private void codeFilter_TXT_TextChanged(object sender, EventArgs e)
        {
            matchWithWildCard(referenceData1_GV);
            matchWithWildCard(referenceData2_GV);
            // matchWithRegExp(referenceData1_GV);
            // matchWithRegExp(referenceData2_GV);
        }

        private void matchWithWildCard(DataGridView dataGridView)
        {
            Boolean matchFound = false;
            for (int rowCounter = 0; rowCounter < dataGridView.RowCount; rowCounter++)
            {
                if (codeFilter_TXT.Text != null && codeFilter_TXT.Text != "")
                {
                    String code = "";
                    try
                    {
                        code = (String)(dataGridView.Rows[rowCounter].Cells[CODE_COL_IDX].Value);
                        matchFound = LikeOperator.LikeString(code, codeFilter_TXT.Text, Microsoft.VisualBasic.CompareMethod.Text);
                    }
                    catch (Exception exc)
                    {
                        Debug.WriteLine("Let's swallow this exception for now (Empty grid cell?)" + exc.Message);
                    }
                    if (matchFound)
                    {
                        dataGridView.Rows[rowCounter].Visible = true;
                    }
                    else
                    {
                        try
                        {
                            dataGridView.CurrentCell = null;
                            dataGridView.Rows[rowCounter].Visible = false;
                        }
                        catch (Exception exc)
                        {
                            Debug.WriteLine("Let's swallow this exception for now (DataGridException?)" + exc.Message);
                        }
                    }
                }
            }
        }

        private void matchWithRegExp(DataGridView dataGridView)
        {
            Regex regex = null;
            try
            {
                regex = new Regex(codeFilter_TXT.Text);
            }
            catch (Exception exc)
            {
                Debug.WriteLine("Let's swallow this exception for now (RegExp pattern problem?)" + exc.Message);
                codeFilter_TXT.ForeColor = Color.Red; // Illegal regular expression
            }
            Boolean matchFound = false;
            if (null != regex)
            {
                codeFilter_TXT.ForeColor = Color.Black; // Illegal regular expression
                for (int rowCounter = 0; rowCounter < dataGridView.RowCount; rowCounter++)
                {
                    if (codeFilter_TXT.Text != null && codeFilter_TXT.Text != "")
                    {
                        try
                        {
                            matchFound = false;
                            Match match = regex.Match((String)dataGridView.Rows[rowCounter].Cells[CODE_COL_IDX].Value);
                            matchFound = match.Success;
                        }
                        catch (Exception exc)
                        {
                            Debug.WriteLine("Let's swallow this exception for now (RegExp match exception?)" + exc.Message);
                        }
                        if (matchFound)
                        {
                            dataGridView.Rows[rowCounter].Visible = true;
                        }
                        else
                        {
                            try
                            {
                                dataGridView.CurrentCell = null;
                                dataGridView.Rows[rowCounter].Visible = false;
                            }
                            catch (Exception exc)
                            {
                                Debug.WriteLine("Let's swallow this exception for now (DataGridException?)" + exc.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                codeFilter_TXT.ForeColor = Color.Red; // Illegal regular expression
            }
        }

        private void yearSelection_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loadReferenceData1();
                matchWithWildCard(referenceData1_GV);
            }
        }

        private void year2Selection_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loadReferenceData2();
                matchWithWildCard(referenceData2_GV);
            }
        }

        private void referenceDataBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

    }
}
