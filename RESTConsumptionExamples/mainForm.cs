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
using System.Globalization;

namespace RESTConsumptionExamples
{
    // Main view
    public partial class mainForm : Form, IInputView, IInvoiceView, IReferenceDataView, ICheckInvoiceView
    {
        public enum TreatmentGridColumns : int { CODE = 0, DESCRIPTION = 1}

        private const int CODE_RULE_COL_IDX = 0;
        private const int CODE_COL_IDX = 1;

        // Controls the retrieval of invoice data
        private InvoiceController invoiceController = null;
        // Controls the retrieval of customer data
        private CustomerController customerController = null;
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

        // Currently selected customer
        private Customer customer = null;
        private Patient newInvoicePatient = null; // Customer and patient are always same person

        // Invoice to be uploaded and checked
        private SimpleInvoice newInvoice = null;
        // Check declaration grid input treatments
        public List<Treatment> inputTreatments { get; set; }
        // Treatment codes
        public List<TreatmentCode> treatmentCodes { get; set; }

        public Dictionary<String, TreatmentCode> treatmentDescriptions = new Dictionary<String, TreatmentCode>();

        DateTimePicker gridView_DTP = new DateTimePicker();
        Rectangle gridViewDTPRectangle;

        Boolean dontProcessTextChanged = false;

        public mainForm()
        {
            InitializeComponent();
            InitializeCustom();
            invoiceController = new InvoiceController(this, this);
            customerController = new CustomerController(this, this);
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
            startDatePicker_DTP.Format = DateTimePickerFormat.Custom;
            startDatePicker_DTP.CustomFormat = "yyyy-MM-dd";
            endDatePicker_DTP.Value = endDate;
            endDatePicker_DTP.Format = DateTimePickerFormat.Custom;
            endDatePicker_DTP.CustomFormat = "yyyy-MM-dd";

            referenceData1_GV.MultiSelect = true;
            referenceData1_GV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            invoiceTreatments_GV.Controls.Add(gridView_DTP);
            gridView_DTP.Visible = false;
            gridView_DTP.Format = DateTimePickerFormat.Custom;
            gridView_DTP.CustomFormat = "yyyy-MM-dd";
            gridView_DTP.TextChanged += new EventHandler(gridView_TextChanged);

            newInvoiceDate_DTP.Value = endDate;
            newInvoiceDate_DTP.Format = DateTimePickerFormat.Custom;
            newInvoiceDate_DTP.CustomFormat = "yyyy-MM-dd";
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
            catch (WebException exc)
            {
                // MessageBox.Show(exc.Message);

                if (exc.Status == WebExceptionStatus.ProtocolError)
                {
                    Console.WriteLine("Status Code : {0}", ((HttpWebResponse)exc.Response).StatusCode);
                    Console.WriteLine("Status Description : {0}", ((HttpWebResponse)exc.Response).StatusDescription);

                    using (Stream responseStream = exc.Response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader responseReader = new StreamReader(responseStream))
                            {
                                String content = responseReader.ReadToEnd();
                                JToken jt = JToken.Parse(content);
                                string formattedJson = jt.ToString();
                                //RestErrorResponse errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<RestErrorResponse>(content);
                                checkInvoiceMessage_TXT.Text = formattedJson;
                            }
                        }
                    }
                }
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
            String selectedPatientId = patientExternalId_CB.SelectedItem.ToString();
            Patient selectedPatient = invoicePatients[selectedPatientId];

            Debug.WriteLine("Code: " + selectedPatient.treatments[0].code);
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
            reselectWithFilters();
        }

        private void loadReferenceData2()
        {
            String year2 = year2Selection_CB.SelectedItem.ToString();
            referenceDataController.getReferenceData2(yearStringToInteger(year2));
            reselectWithFilters();
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
            reselectWithFilters();
        }

        private void reselectWithFilters()
        {
            matchWithWildCard(referenceData1_GV);
            matchWithWildCard(referenceData2_GV);
            hiliteWithWildCard(referenceData1_GV);
            hiliteWithWildCard(referenceData2_GV);
            // matchWithRegExp(referenceData1_GV);
            // matchWithRegExp(referenceData2_GV);
        }

        /* 
         * Method that shows only the rows that match the wildcard
         */
        private void matchWithWildCard(DataGridView dataGridView)
        {
            Boolean matchFound = false;

            Debug.WriteLine("Updating " + dataGridView.RowCount + " grid rows");
            //if (dataGridView.RowCount > 0)
            //{
            //    dataGridView.Rows[0].Visible = true;
            //    dataGridView.FirstDisplayedScrollingRowIndex = 0;
            //}
            for (int rowCounter = 0; rowCounter < dataGridView.RowCount - 1; rowCounter++)
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
                        Debug.WriteLine("Let's swallow this exception for now, code: " + code + " (Empty grid cell?)" + exc.Message);
                        Debug.WriteLine("RowCounter: " + rowCounter);
                    }
                    // Reset the selected rows because hiliteWithWildCard will be called to reestablish selected rows
                    dataGridView.Rows[rowCounter].Selected = false;
                    if (matchFound)
                    {
                        dataGridView.Rows[rowCounter].Visible = true;
                    }
                    else
                    {
                        try
                        {
                            // Hide a row if it is not matching the filter anymore
                            dataGridView.CurrentCell = null;
                            dataGridView.Rows[rowCounter].Visible = false;
                            dataGridView.Rows[rowCounter].Selected = false;
                        }
                        catch (Exception exc)
                        {
                            Debug.WriteLine("Let's swallow this exception for now, code: " + code + " (DataGridException?)" + exc.Message);
                            Debug.WriteLine("RowCounter: " + rowCounter);
                        }
                    }
                }
            }
        }

        private void findCodeFilter_TXT_TextChanged(object sender, EventArgs e)
        {
            hiliteWithWildCard(referenceData1_GV);
            hiliteWithWildCard(referenceData2_GV);
        }

        /* 
         * Method that select the rows that match the wildcard and moves the cursor 
         * to the first selected row in the grid
         */
        private void hiliteWithWildCard(DataGridView dataGridView)
        {
            Boolean matchFound = false;
            Boolean rowsSelected = false;
            int firstVisibleIndex = -1;
            Debug.WriteLine("Updating " + dataGridView.RowCount + " grid rows");
            for (int rowCounter = 0; rowCounter < dataGridView.RowCount - 1; rowCounter++)
            {
                if (dataGridView.Rows[rowCounter].Visible) // Can only select rows that are actually visible
                {
                    if(firstVisibleIndex == -1)
                    {
                        // Determine the first visible row as determined by the matchWithWildCard method
                        firstVisibleIndex = rowCounter;
                    }
                    if (findCodeFilter_TXT.Text != null && findCodeFilter_TXT.Text != "")
                    {
                        String codeRule = "";
                        try
                        {
                            codeRule = (String)(dataGridView.Rows[rowCounter].Cells[CODE_RULE_COL_IDX].Value);
                            matchFound = LikeOperator.LikeString(codeRule, findCodeFilter_TXT.Text, Microsoft.VisualBasic.CompareMethod.Text);
                        }
                        catch (Exception exc)
                        {
                            Debug.WriteLine("Let's swallow this exception for now (Empty grid cell?)" + exc.Message);
                        }
                        if (matchFound)
                        {
                            dataGridView.Rows[rowCounter].Selected = true;
                            Debug.WriteLine("Selected row " + codeRule);
                            // Determine if at least one row is selected
                            rowsSelected = dataGridView.Rows[rowCounter].Visible;
                        }
                        else
                        {
                            try
                            {
                                // Unselect a row if it is not matching the filter anymore
                                dataGridView.CurrentCell = null;
                                dataGridView.Rows[rowCounter].Selected = false;
                            }
                            catch (Exception exc)
                            {
                                Debug.WriteLine("Let's swallow this exception for now (DataGridException?)" + exc.Message);
                            }
                        }
                    }                    
                }
            }
            if (rowsSelected)
            {
                // For some reason the selected rows are ordered from high index to low
                Debug.WriteLine("First selected row (" + (String)(dataGridView.SelectedRows[dataGridView.SelectedRows.Count - 1].Cells[CODE_RULE_COL_IDX].Value) + "): " + dataGridView.SelectedRows[dataGridView.SelectedRows.Count - 1].Index);
                int firstSelectedRowIndex = dataGridView.SelectedRows[dataGridView.SelectedRows.Count - 1].Index;
                int distanceFromFirstVisibleRow = firstSelectedRowIndex - firstVisibleIndex;

                // FirstDisplayedScrollingRowIndex is the index of the first actually visible row in the grid 
                // Note that this does not necessarily match the Visible property of the row, which is used to determine if the 
                // row is appearing in the scrollable area of the grid
                // Show up to 5 leading rows if possible 
                int firstDisplayedIndex = dataGridView.SelectedRows[dataGridView.SelectedRows.Count - 1].Index - (Math.Min(5, distanceFromFirstVisibleRow));
                dataGridView.FirstDisplayedScrollingRowIndex = firstDisplayedIndex;
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

        private void codeFilter_TXT_MouseClick(object sender, MouseEventArgs e)
        {
            codeFilter_TXT.SelectAll();
        }

        private void findCodeFilter_TXT_MouseClick(object sender, MouseEventArgs e)
        {
            findCodeFilter_TXT.SelectAll();
        }

        private void getCustomerExternalIds_BTN_Click(object sender, EventArgs e)
        {
            customerController.getCustomerExternalIds();
        }

        public void setCustomerExternalIds(List<string> customerExternalIds)
        {
            customerExternalIds_CB.DataSource = customerExternalIds;
        }

        // ------------------ ICheckInvoiceView ------------------

        public void setInvoicePublicId(String invoicePublicId)
        {
            newInvoice.invoicePublicId = invoicePublicId;
            updateNewInvoiceView();
        }

        public void setCustomer(Customer customer)
        {
            this.customer = customer;
            if(null != this.customer)
            {
                newInvoicePatient = new Patient(customer);
                newInvoicePatient.patientPolicyNumber = "patientPolicyNumber";
                newInvoicePatient.healthInsuranceName = "healthInsuranceName";
                SimpleInvoice customerInvoice = SimpleInvoice.getTestInvoice(customer);
                customerInvoice.customerExternalId = customer.customerExternalId;

                setCustomerInvoice(customerInvoice);

                inputTreatments = new List<Treatment>();
                // Treatment newTreatment = Treatment.getTestTreatment();
                // Treatment newTreatment = Treatment.getDefaultInputTreatment(today());
                // inputTreatments.Add(newTreatment);
                invoiceTreatments_GV.DataSource = new BindingList < Treatment > (inputTreatments);
            }
        }

        public void uploadInvoice()
        {
            newInvoicePatient.treatments = inputTreatments;
            newInvoice.patients = new List<Patient>();
            newInvoice.patients.Add(newInvoicePatient);
            customerController.uploadInvoice(customer, newInvoice);
        }

        public void checkInvoice(string invoiceId)
        {
            throw new NotImplementedException();
        }

        public void setCustomerInvoice(SimpleInvoice invoice)
        {
            newInvoice = invoice;

            updateNewInvoiceView();
        }

        private void updateNewInvoiceView()
        {
            dontProcessTextChanged = true;
            newInvoicePublicId_TXT.Text = newInvoice.invoicePublicId;
            clinicAGBCode_TXT.Text = newInvoice.clinicAGBCode;
            customerExternalId_TXT.Text = newInvoice.customerExternalId;
            newDcInvoicePublicId_TXT.Text = newInvoice.dcInvoicePublicId;
            declarerAGBCode_TXT.Text = newInvoice.declarerAGBCode;
            healthcareProviderName_TXT.Text = newInvoice.healthcareProviderName;
            institutionAGBCdde_TXT.Text = newInvoice.institutionAGBCdde;
            newInvoiceDate_DTP.Value = DateTime.ParseExact(newInvoice.invoiceDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            newInvoiceNumber_TXT.Text = newInvoice.invoiceNumber;
            dontProcessTextChanged = false;
        }

        private void updateNewInvoice()
        {
            if (!dontProcessTextChanged) { 
                newInvoice.invoicePublicId = newInvoicePublicId_TXT.Text;
                newInvoice.clinicAGBCode = clinicAGBCode_TXT.Text;
                newInvoice.customerExternalId = customerExternalId_TXT.Text;
                newInvoice.dcInvoicePublicId = newDcInvoicePublicId_TXT.Text;
                newInvoice.declarerAGBCode = declarerAGBCode_TXT.Text;
                newInvoice.healthcareProviderName = healthcareProviderName_TXT.Text;
                newInvoice.institutionAGBCdde = institutionAGBCdde_TXT.Text;
                newInvoice.invoiceDate = DateUtils.dateTimeToString(newInvoiceDate_DTP.Value);
                newInvoice.invoiceNumber = newInvoiceNumber_TXT.Text;
            }
        }

        public string getCurrentCustomerId()
        {
            return customerExternalIds_CB.SelectedItem.ToString();
        }

        public void setMessage(String message)
        {
            checkInvoiceMessage_TXT.Text = message;
        }

        public void setCustomerJSon(String json)
        {
            customerJSon_TXT.Text = json;
        }

        private void customerExternalIds_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            customerController.getCustomerJSon();
            if (treatmentCodes.Count == 0) // url changed
            { 
                referenceDataController.getTreatmentCodes();
            }
        }

        private void invoiceTreatments_GV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch (invoiceTreatments_GV.Columns[e.ColumnIndex].Name)
            {
                case "dateColumn":
                    gridView_DTP.Visible = false;
                    break;
            }

            if (null != inputTreatments && inputTreatments.Count > 0) {
                if (e.ColumnIndex == (int)TreatmentGridColumns.CODE)
                {
                    Treatment editedTreatment = inputTreatments[e.RowIndex];
                    if (treatmentDescriptions.ContainsKey(editedTreatment.code)) {
                        TreatmentCode treatmentCode = treatmentDescriptions[editedTreatment.code];
                        if (null != treatmentCode)
                        {
                            editedTreatment.description = treatmentCode.description;
                            Debug.WriteLine("Set description for " + editedTreatment.code + " to " + editedTreatment.description);
                        }
                    }
                }
           }
        }

        public void setTreatmentCodes(List<TreatmentCode> treatmentCodes)
        {
            this.treatmentCodes = treatmentCodes;
            treatmentCodes_TXT.Text = "";

            foreach (TreatmentCode treatmentCode in treatmentCodes)
            {
                if (!treatmentDescriptions.ContainsKey(treatmentCode.code)) { 
                    treatmentDescriptions[treatmentCode.code] = treatmentCode;
                    treatmentCodes_TXT.AppendText(treatmentCode.code + " : " + treatmentCode.description + "\n");
                }
            }
        }

        private void url_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            treatmentCodes = new List<TreatmentCode>();
            treatmentDescriptions = new Dictionary<string, TreatmentCode>();
        }

        private void invoiceTreatments_GV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch(invoiceTreatments_GV.Columns[e.ColumnIndex].Name)
            {
                case "dateColumn":
                    gridViewDTPRectangle = invoiceTreatments_GV.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    gridView_DTP.Size = new Size(gridViewDTPRectangle.Width, gridViewDTPRectangle.Height);
                    gridView_DTP.Location = new Point(gridViewDTPRectangle.X, gridViewDTPRectangle.Y);
                    gridView_DTP.Visible = true;
                    break;
            }
        }

        private void gridView_TextChanged(object sender, EventArgs e)
        {
            invoiceTreatments_GV.CurrentCell.Value = gridView_DTP.Text.ToString();
        }

        private void invoiceTreatments_GV_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            gridView_DTP.Visible = false;
        }

        private void invoiceTreatments_GV_Scroll(object sender, ScrollEventArgs e)
        {
            gridView_DTP.Visible = false;
        }

        private void invoiceTreatments_GV_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            String previousDate = "";

            Treatment newTreatment = null;

            if (null != inputTreatments && inputTreatments.Count > 0 && inputTreatments.Count >= e.Row.Index) { 
                if (e.Row.Index - 2 >= 0) {
                    previousDate = inputTreatments[e.Row.Index - 2].date;
                    newTreatment = Treatment.getDefaultInputTreatment(previousDate);
                } else
                {
                    newTreatment = Treatment.getDefaultInputTreatment(DateUtils.today());
                }
                inputTreatments[e.Row.Index - 1] = newTreatment;
            }

            Debug.WriteLine("User added row: row index: " + e.Row.Index + ", Treatment Count:" + (null != inputTreatments ? inputTreatments.Count.ToString() : "null"));

            if (null != inputTreatments && inputTreatments.Count > 0 && inputTreatments.Count >= e.Row.Index)
            {
                Debug.WriteLine(inputTreatments[e.Row.Index - 1].ToString());
            }
        }

        private void invoiceTreatments_GV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Debug.WriteLine("Added row     : row index: " + e.RowIndex + ", Treatment Count:" + (null != inputTreatments ? inputTreatments.Count.ToString() : "null"));
        }

        private void uploadInvoice_BTN_Click(object sender, EventArgs e)
        {
            uploadInvoice();
        }

        private void newInvoicePublicId_TXT_TextChanged(object sender, EventArgs e)
        {
            updateNewInvoice();
        }

        private void clinicAGBCode_TXT_TextChanged(object sender, EventArgs e)
        {
            updateNewInvoice();
        }

        private void newDcInvoicePublicId_TXT_TextChanged(object sender, EventArgs e)
        {
            updateNewInvoice();
        }

        private void declarerAGBCode_TXT_TextChanged(object sender, EventArgs e)
        {
            updateNewInvoice();
        }

        private void healthcareProviderName_TXT_TextChanged(object sender, EventArgs e)
        {
            updateNewInvoice();
        }

        private void institutionAGBCdde_TXT_TextChanged(object sender, EventArgs e)
        {
            updateNewInvoice();
        }

        private void newInvoiceNumber_TXT_TextChanged(object sender, EventArgs e)
        {
            updateNewInvoice();
        }

        private void createTestTreatments_BTN_Click(object sender, EventArgs e)
        {
            Treatment treatment1 = Treatment.getTestTreatment();
            treatment1.code = "V94";
            treatment1.dentalElementCode = "23";
            treatment1.calculatedAmount = 25;
            Treatment treatment2 = Treatment.getTestTreatment();
            treatment2.code = "V93";
            treatment2.dentalElementCode = "23";
            treatment2.calculatedAmount = 26;

            if(null == inputTreatments)
            {
                inputTreatments = new List<Treatment>();
            }
            inputTreatments.Add(treatment1);
            inputTreatments.Add(treatment2);

            invoiceTreatments_GV.DataSource = new BindingList<Treatment>(inputTreatments);

            invoiceTreatments_GV.Invalidate();
            invoiceTreatments_GV.Update();
        }
    }
}
