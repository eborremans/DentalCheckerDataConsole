namespace RESTConsumptionExamples
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.getInvoicePublicIds_BTN = new System.Windows.Forms.Button();
            this.getDentalCheckerVersionResponse_BTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.apiKey_TXT = new System.Windows.Forms.TextBox();
            this.loadKey_BTN = new System.Windows.Forms.Button();
            this.saveKey_BTN = new System.Windows.Forms.Button();
            this.getInvoice_BTN = new System.Windows.Forms.Button();
            this.invoiceNr_TXT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.url_CB = new System.Windows.Forms.ComboBox();
            this.configurationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.urlsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jsonSplitContainer_SPLT = new System.Windows.Forms.SplitContainer();
            this.json_TXT = new System.Windows.Forms.TextBox();
            this.prettyJSon_TXT = new System.Windows.Forms.TextBox();
            this.invoicePublicIds_CB = new System.Windows.Forms.ComboBox();
            this.testResponse_BTN = new System.Windows.Forms.Button();
            this.patientTreatments_DGV = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dentalElementCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tariffAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.declaredAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculatedAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrOfTreatmentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.therapistAGBCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeOfTreatmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treatmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patientHealthInsurance_TXT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.patientBirthdate_TXT = new System.Windows.Forms.TextBox();
            this.patientPolicyNumber_TXT = new System.Windows.Forms.TextBox();
            this.patientExternalId_CB = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mainSplitContainer_SPLT = new System.Windows.Forms.SplitContainer();
            this.treatmentsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.checkResultSplitContainer_SPLT = new System.Windows.Forms.SplitContainer();
            this.patientViolations_LB = new System.Windows.Forms.ListBox();
            this.violationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkReportRenderer_WB = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jsonSplitContainer_SPLT)).BeginInit();
            this.jsonSplitContainer_SPLT.Panel1.SuspendLayout();
            this.jsonSplitContainer_SPLT.Panel2.SuspendLayout();
            this.jsonSplitContainer_SPLT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientTreatments_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer_SPLT)).BeginInit();
            this.mainSplitContainer_SPLT.Panel1.SuspendLayout();
            this.mainSplitContainer_SPLT.Panel2.SuspendLayout();
            this.mainSplitContainer_SPLT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentsSplitContainer)).BeginInit();
            this.treatmentsSplitContainer.Panel1.SuspendLayout();
            this.treatmentsSplitContainer.Panel2.SuspendLayout();
            this.treatmentsSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkResultSplitContainer_SPLT)).BeginInit();
            this.checkResultSplitContainer_SPLT.Panel1.SuspendLayout();
            this.checkResultSplitContainer_SPLT.Panel2.SuspendLayout();
            this.checkResultSplitContainer_SPLT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.violationsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // getInvoicePublicIds_BTN
            // 
            this.getInvoicePublicIds_BTN.Location = new System.Drawing.Point(246, 12);
            this.getInvoicePublicIds_BTN.Margin = new System.Windows.Forms.Padding(2);
            this.getInvoicePublicIds_BTN.Name = "getInvoicePublicIds_BTN";
            this.getInvoicePublicIds_BTN.Size = new System.Drawing.Size(160, 24);
            this.getInvoicePublicIds_BTN.TabIndex = 0;
            this.getInvoicePublicIds_BTN.Text = "Get Invoice Public Ids";
            this.getInvoicePublicIds_BTN.UseVisualStyleBackColor = true;
            this.getInvoicePublicIds_BTN.Click += new System.EventHandler(this.getInvoicePublicIds_BTN_Click);
            // 
            // getDentalCheckerVersionResponse_BTN
            // 
            this.getDentalCheckerVersionResponse_BTN.Location = new System.Drawing.Point(1011, 2);
            this.getDentalCheckerVersionResponse_BTN.Margin = new System.Windows.Forms.Padding(2);
            this.getDentalCheckerVersionResponse_BTN.Name = "getDentalCheckerVersionResponse_BTN";
            this.getDentalCheckerVersionResponse_BTN.Size = new System.Drawing.Size(106, 28);
            this.getDentalCheckerVersionResponse_BTN.TabIndex = 1;
            this.getDentalCheckerVersionResponse_BTN.Text = "DENTIC Response";
            this.getDentalCheckerVersionResponse_BTN.UseVisualStyleBackColor = true;
            this.getDentalCheckerVersionResponse_BTN.Click += new System.EventHandler(this.getDentalCheckerVersionResponse_BTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "api key:";
            // 
            // apiKey_TXT
            // 
            this.apiKey_TXT.Location = new System.Drawing.Point(357, 2);
            this.apiKey_TXT.Margin = new System.Windows.Forms.Padding(2);
            this.apiKey_TXT.Name = "apiKey_TXT";
            this.apiKey_TXT.Size = new System.Drawing.Size(230, 20);
            this.apiKey_TXT.TabIndex = 4;
            // 
            // loadKey_BTN
            // 
            this.loadKey_BTN.Location = new System.Drawing.Point(592, 1);
            this.loadKey_BTN.Margin = new System.Windows.Forms.Padding(2);
            this.loadKey_BTN.Name = "loadKey_BTN";
            this.loadKey_BTN.Size = new System.Drawing.Size(76, 27);
            this.loadKey_BTN.TabIndex = 5;
            this.loadKey_BTN.Text = "Load Config";
            this.loadKey_BTN.UseVisualStyleBackColor = true;
            this.loadKey_BTN.Click += new System.EventHandler(this.loadKey_BTN_Click);
            // 
            // saveKey_BTN
            // 
            this.saveKey_BTN.Location = new System.Drawing.Point(673, 1);
            this.saveKey_BTN.Margin = new System.Windows.Forms.Padding(2);
            this.saveKey_BTN.Name = "saveKey_BTN";
            this.saveKey_BTN.Size = new System.Drawing.Size(78, 27);
            this.saveKey_BTN.TabIndex = 6;
            this.saveKey_BTN.Text = "Save Config";
            this.saveKey_BTN.UseVisualStyleBackColor = true;
            this.saveKey_BTN.Click += new System.EventHandler(this.saveKey_BTN_Click);
            // 
            // getInvoice_BTN
            // 
            this.getInvoice_BTN.Location = new System.Drawing.Point(22, 9);
            this.getInvoice_BTN.Margin = new System.Windows.Forms.Padding(2);
            this.getInvoice_BTN.Name = "getInvoice_BTN";
            this.getInvoice_BTN.Size = new System.Drawing.Size(79, 27);
            this.getInvoice_BTN.TabIndex = 7;
            this.getInvoice_BTN.Text = "Get Invoice";
            this.getInvoice_BTN.UseVisualStyleBackColor = true;
            this.getInvoice_BTN.Click += new System.EventHandler(this.getInvoice_BTN_Click);
            // 
            // invoiceNr_TXT
            // 
            this.invoiceNr_TXT.Location = new System.Drawing.Point(112, 13);
            this.invoiceNr_TXT.Margin = new System.Windows.Forms.Padding(2);
            this.invoiceNr_TXT.Name = "invoiceNr_TXT";
            this.invoiceNr_TXT.Size = new System.Drawing.Size(128, 20);
            this.invoiceNr_TXT.TabIndex = 8;
            this.invoiceNr_TXT.Text = "INV-0000000304";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "url:";
            // 
            // url_CB
            // 
            this.url_CB.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.configurationBindingSource, "currentUrl", true));
            this.url_CB.DataSource = this.urlsBindingSource;
            this.url_CB.FormattingEnabled = true;
            this.url_CB.Location = new System.Drawing.Point(29, 2);
            this.url_CB.Margin = new System.Windows.Forms.Padding(2);
            this.url_CB.Name = "url_CB";
            this.url_CB.Size = new System.Drawing.Size(277, 21);
            this.url_CB.TabIndex = 12;
            // 
            // configurationBindingSource
            // 
            this.configurationBindingSource.DataSource = typeof(RESTConsumptionExamples.Configuration);
            // 
            // urlsBindingSource
            // 
            this.urlsBindingSource.DataMember = "urls";
            this.urlsBindingSource.DataSource = this.configurationBindingSource;
            // 
            // jsonSplitContainer_SPLT
            // 
            this.jsonSplitContainer_SPLT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jsonSplitContainer_SPLT.Location = new System.Drawing.Point(0, 0);
            this.jsonSplitContainer_SPLT.Margin = new System.Windows.Forms.Padding(2);
            this.jsonSplitContainer_SPLT.Name = "jsonSplitContainer_SPLT";
            // 
            // jsonSplitContainer_SPLT.Panel1
            // 
            this.jsonSplitContainer_SPLT.Panel1.Controls.Add(this.json_TXT);
            // 
            // jsonSplitContainer_SPLT.Panel2
            // 
            this.jsonSplitContainer_SPLT.Panel2.Controls.Add(this.prettyJSon_TXT);
            this.jsonSplitContainer_SPLT.Size = new System.Drawing.Size(1581, 214);
            this.jsonSplitContainer_SPLT.SplitterDistance = 409;
            this.jsonSplitContainer_SPLT.SplitterWidth = 3;
            this.jsonSplitContainer_SPLT.TabIndex = 13;
            // 
            // json_TXT
            // 
            this.json_TXT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.json_TXT.Font = new System.Drawing.Font("Andale Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.json_TXT.Location = new System.Drawing.Point(4, 2);
            this.json_TXT.Margin = new System.Windows.Forms.Padding(2);
            this.json_TXT.Multiline = true;
            this.json_TXT.Name = "json_TXT";
            this.json_TXT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.json_TXT.Size = new System.Drawing.Size(403, 211);
            this.json_TXT.TabIndex = 3;
            // 
            // prettyJSon_TXT
            // 
            this.prettyJSon_TXT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prettyJSon_TXT.Font = new System.Drawing.Font("Andale Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prettyJSon_TXT.Location = new System.Drawing.Point(2, 2);
            this.prettyJSon_TXT.Margin = new System.Windows.Forms.Padding(2);
            this.prettyJSon_TXT.Multiline = true;
            this.prettyJSon_TXT.Name = "prettyJSon_TXT";
            this.prettyJSon_TXT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.prettyJSon_TXT.Size = new System.Drawing.Size(1168, 210);
            this.prettyJSon_TXT.TabIndex = 14;
            // 
            // invoicePublicIds_CB
            // 
            this.invoicePublicIds_CB.FormattingEnabled = true;
            this.invoicePublicIds_CB.Items.AddRange(new object[] {
            "<empty>"});
            this.invoicePublicIds_CB.Location = new System.Drawing.Point(112, 40);
            this.invoicePublicIds_CB.Margin = new System.Windows.Forms.Padding(2);
            this.invoicePublicIds_CB.Name = "invoicePublicIds_CB";
            this.invoicePublicIds_CB.Size = new System.Drawing.Size(128, 21);
            this.invoicePublicIds_CB.TabIndex = 14;
            this.invoicePublicIds_CB.SelectedIndexChanged += new System.EventHandler(this.invoicePublicIds_CB_SelectedIndexChanged);
            this.invoicePublicIds_CB.SelectedValueChanged += new System.EventHandler(this.invoicePublicIds_CB_SelectedValueChanged);
            // 
            // testResponse_BTN
            // 
            this.testResponse_BTN.Location = new System.Drawing.Point(1121, 2);
            this.testResponse_BTN.Margin = new System.Windows.Forms.Padding(2);
            this.testResponse_BTN.Name = "testResponse_BTN";
            this.testResponse_BTN.Size = new System.Drawing.Size(108, 28);
            this.testResponse_BTN.TabIndex = 15;
            this.testResponse_BTN.Text = "Test Save";
            this.testResponse_BTN.UseVisualStyleBackColor = true;
            this.testResponse_BTN.Click += new System.EventHandler(this.testResponse_BTN_Click);
            // 
            // patientTreatments_DGV
            // 
            this.patientTreatments_DGV.AllowUserToAddRows = false;
            this.patientTreatments_DGV.AllowUserToDeleteRows = false;
            this.patientTreatments_DGV.AllowUserToOrderColumns = true;
            this.patientTreatments_DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patientTreatments_DGV.AutoGenerateColumns = false;
            this.patientTreatments_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patientTreatments_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.dentalElementCodeDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.tariffAmountDataGridViewTextBoxColumn,
            this.declaredAmountDataGridViewTextBoxColumn,
            this.calculatedAmountDataGridViewTextBoxColumn,
            this.nrOfTreatmentsDataGridViewTextBoxColumn,
            this.referenceNumberDataGridViewTextBoxColumn,
            this.therapistAGBCodeDataGridViewTextBoxColumn,
            this.typeOfTreatmentDataGridViewTextBoxColumn});
            this.patientTreatments_DGV.DataSource = this.treatmentBindingSource;
            this.patientTreatments_DGV.Location = new System.Drawing.Point(411, 9);
            this.patientTreatments_DGV.Name = "patientTreatments_DGV";
            this.patientTreatments_DGV.ReadOnly = true;
            this.patientTreatments_DGV.Size = new System.Drawing.Size(1191, 265);
            this.patientTreatments_DGV.TabIndex = 16;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dentalElementCodeDataGridViewTextBoxColumn
            // 
            this.dentalElementCodeDataGridViewTextBoxColumn.DataPropertyName = "dentalElementCode";
            this.dentalElementCodeDataGridViewTextBoxColumn.HeaderText = "dentalElementCode";
            this.dentalElementCodeDataGridViewTextBoxColumn.Name = "dentalElementCodeDataGridViewTextBoxColumn";
            this.dentalElementCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tariffAmountDataGridViewTextBoxColumn
            // 
            this.tariffAmountDataGridViewTextBoxColumn.DataPropertyName = "tariffAmount";
            this.tariffAmountDataGridViewTextBoxColumn.HeaderText = "tariffAmount";
            this.tariffAmountDataGridViewTextBoxColumn.Name = "tariffAmountDataGridViewTextBoxColumn";
            this.tariffAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // declaredAmountDataGridViewTextBoxColumn
            // 
            this.declaredAmountDataGridViewTextBoxColumn.DataPropertyName = "declaredAmount";
            this.declaredAmountDataGridViewTextBoxColumn.HeaderText = "declaredAmount";
            this.declaredAmountDataGridViewTextBoxColumn.Name = "declaredAmountDataGridViewTextBoxColumn";
            this.declaredAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // calculatedAmountDataGridViewTextBoxColumn
            // 
            this.calculatedAmountDataGridViewTextBoxColumn.DataPropertyName = "calculatedAmount";
            this.calculatedAmountDataGridViewTextBoxColumn.HeaderText = "calculatedAmount";
            this.calculatedAmountDataGridViewTextBoxColumn.Name = "calculatedAmountDataGridViewTextBoxColumn";
            this.calculatedAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrOfTreatmentsDataGridViewTextBoxColumn
            // 
            this.nrOfTreatmentsDataGridViewTextBoxColumn.DataPropertyName = "nrOfTreatments";
            this.nrOfTreatmentsDataGridViewTextBoxColumn.HeaderText = "nrOfTreatments";
            this.nrOfTreatmentsDataGridViewTextBoxColumn.Name = "nrOfTreatmentsDataGridViewTextBoxColumn";
            this.nrOfTreatmentsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // referenceNumberDataGridViewTextBoxColumn
            // 
            this.referenceNumberDataGridViewTextBoxColumn.DataPropertyName = "referenceNumber";
            this.referenceNumberDataGridViewTextBoxColumn.HeaderText = "referenceNumber";
            this.referenceNumberDataGridViewTextBoxColumn.Name = "referenceNumberDataGridViewTextBoxColumn";
            this.referenceNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // therapistAGBCodeDataGridViewTextBoxColumn
            // 
            this.therapistAGBCodeDataGridViewTextBoxColumn.DataPropertyName = "therapistAGBCode";
            this.therapistAGBCodeDataGridViewTextBoxColumn.HeaderText = "therapistAGBCode";
            this.therapistAGBCodeDataGridViewTextBoxColumn.Name = "therapistAGBCodeDataGridViewTextBoxColumn";
            this.therapistAGBCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeOfTreatmentDataGridViewTextBoxColumn
            // 
            this.typeOfTreatmentDataGridViewTextBoxColumn.DataPropertyName = "typeOfTreatment";
            this.typeOfTreatmentDataGridViewTextBoxColumn.HeaderText = "typeOfTreatment";
            this.typeOfTreatmentDataGridViewTextBoxColumn.Name = "typeOfTreatmentDataGridViewTextBoxColumn";
            this.typeOfTreatmentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // treatmentBindingSource
            // 
            this.treatmentBindingSource.DataSource = typeof(RESTConsumptionExamples.Treatment);
            // 
            // patientHealthInsurance_TXT
            // 
            this.patientHealthInsurance_TXT.Location = new System.Drawing.Point(112, 105);
            this.patientHealthInsurance_TXT.Name = "patientHealthInsurance_TXT";
            this.patientHealthInsurance_TXT.Size = new System.Drawing.Size(128, 20);
            this.patientHealthInsurance_TXT.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Health Insurance:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Birthdate:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Policy Nr:";
            // 
            // patientBirthdate_TXT
            // 
            this.patientBirthdate_TXT.Location = new System.Drawing.Point(112, 137);
            this.patientBirthdate_TXT.Name = "patientBirthdate_TXT";
            this.patientBirthdate_TXT.Size = new System.Drawing.Size(128, 20);
            this.patientBirthdate_TXT.TabIndex = 23;
            // 
            // patientPolicyNumber_TXT
            // 
            this.patientPolicyNumber_TXT.Location = new System.Drawing.Point(112, 173);
            this.patientPolicyNumber_TXT.Name = "patientPolicyNumber_TXT";
            this.patientPolicyNumber_TXT.Size = new System.Drawing.Size(128, 20);
            this.patientPolicyNumber_TXT.TabIndex = 25;
            // 
            // patientExternalId_CB
            // 
            this.patientExternalId_CB.FormattingEnabled = true;
            this.patientExternalId_CB.Items.AddRange(new object[] {
            "<empty>"});
            this.patientExternalId_CB.Location = new System.Drawing.Point(112, 73);
            this.patientExternalId_CB.Margin = new System.Windows.Forms.Padding(2);
            this.patientExternalId_CB.Name = "patientExternalId_CB";
            this.patientExternalId_CB.Size = new System.Drawing.Size(128, 21);
            this.patientExternalId_CB.TabIndex = 26;
            this.patientExternalId_CB.SelectedIndexChanged += new System.EventHandler(this.patientExternalId_CB_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Patient external ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Invoice Public ID:";
            // 
            // mainSplitContainer_SPLT
            // 
            this.mainSplitContainer_SPLT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainSplitContainer_SPLT.Location = new System.Drawing.Point(3, 60);
            this.mainSplitContainer_SPLT.Name = "mainSplitContainer_SPLT";
            this.mainSplitContainer_SPLT.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitContainer_SPLT.Panel1
            // 
            this.mainSplitContainer_SPLT.Panel1.Controls.Add(this.treatmentsSplitContainer);
            // 
            // mainSplitContainer_SPLT.Panel2
            // 
            this.mainSplitContainer_SPLT.Panel2.Controls.Add(this.jsonSplitContainer_SPLT);
            this.mainSplitContainer_SPLT.Size = new System.Drawing.Size(1581, 862);
            this.mainSplitContainer_SPLT.SplitterDistance = 644;
            this.mainSplitContainer_SPLT.TabIndex = 29;
            // 
            // treatmentsSplitContainer
            // 
            this.treatmentsSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treatmentsSplitContainer.Location = new System.Drawing.Point(4, 3);
            this.treatmentsSplitContainer.Name = "treatmentsSplitContainer";
            this.treatmentsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // treatmentsSplitContainer.Panel1
            // 
            this.treatmentsSplitContainer.Panel1.Controls.Add(this.patientTreatments_DGV);
            this.treatmentsSplitContainer.Panel1.Controls.Add(this.label5);
            this.treatmentsSplitContainer.Panel1.Controls.Add(this.getInvoice_BTN);
            this.treatmentsSplitContainer.Panel1.Controls.Add(this.label6);
            this.treatmentsSplitContainer.Panel1.Controls.Add(this.getInvoicePublicIds_BTN);
            this.treatmentsSplitContainer.Panel1.Controls.Add(this.patientExternalId_CB);
            this.treatmentsSplitContainer.Panel1.Controls.Add(this.invoiceNr_TXT);
            this.treatmentsSplitContainer.Panel1.Controls.Add(this.patientPolicyNumber_TXT);
            this.treatmentsSplitContainer.Panel1.Controls.Add(this.invoicePublicIds_CB);
            this.treatmentsSplitContainer.Panel1.Controls.Add(this.patientBirthdate_TXT);
            this.treatmentsSplitContainer.Panel1.Controls.Add(this.patientHealthInsurance_TXT);
            this.treatmentsSplitContainer.Panel1.Controls.Add(this.label7);
            this.treatmentsSplitContainer.Panel1.Controls.Add(this.label3);
            this.treatmentsSplitContainer.Panel1.Controls.Add(this.label4);
            // 
            // treatmentsSplitContainer.Panel2
            // 
            this.treatmentsSplitContainer.Panel2.Controls.Add(this.checkResultSplitContainer_SPLT);
            this.treatmentsSplitContainer.Size = new System.Drawing.Size(1590, 638);
            this.treatmentsSplitContainer.SplitterDistance = 274;
            this.treatmentsSplitContainer.TabIndex = 17;
            // 
            // checkResultSplitContainer_SPLT
            // 
            this.checkResultSplitContainer_SPLT.Location = new System.Drawing.Point(0, 0);
            this.checkResultSplitContainer_SPLT.Name = "checkResultSplitContainer_SPLT";
            // 
            // checkResultSplitContainer_SPLT.Panel1
            // 
            this.checkResultSplitContainer_SPLT.Panel1.Controls.Add(this.patientViolations_LB);
            // 
            // checkResultSplitContainer_SPLT.Panel2
            // 
            this.checkResultSplitContainer_SPLT.Panel2.Controls.Add(this.checkReportRenderer_WB);
            this.checkResultSplitContainer_SPLT.Size = new System.Drawing.Size(1578, 360);
            this.checkResultSplitContainer_SPLT.SplitterDistance = 525;
            this.checkResultSplitContainer_SPLT.TabIndex = 2;
            // 
            // patientViolations_LB
            // 
            this.patientViolations_LB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patientViolations_LB.DataSource = this.violationsBindingSource;
            this.patientViolations_LB.FormattingEnabled = true;
            this.patientViolations_LB.Location = new System.Drawing.Point(0, 0);
            this.patientViolations_LB.Name = "patientViolations_LB";
            this.patientViolations_LB.Size = new System.Drawing.Size(522, 355);
            this.patientViolations_LB.TabIndex = 0;
            // 
            // violationsBindingSource
            // 
            this.violationsBindingSource.DataMember = "violations";
            this.violationsBindingSource.DataSource = this.treatmentBindingSource;
            // 
            // checkReportRenderer_WB
            // 
            this.checkReportRenderer_WB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkReportRenderer_WB.Location = new System.Drawing.Point(0, 0);
            this.checkReportRenderer_WB.MinimumSize = new System.Drawing.Size(20, 20);
            this.checkReportRenderer_WB.Name = "checkReportRenderer_WB";
            this.checkReportRenderer_WB.Size = new System.Drawing.Size(1049, 360);
            this.checkReportRenderer_WB.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1233, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 28);
            this.button1.TabIndex = 30;
            this.button1.Text = "Test Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1596, 926);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mainSplitContainer_SPLT);
            this.Controls.Add(this.testResponse_BTN);
            this.Controls.Add(this.url_CB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saveKey_BTN);
            this.Controls.Add(this.loadKey_BTN);
            this.Controls.Add(this.apiKey_TXT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getDentalCheckerVersionResponse_BTN);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mainForm";
            this.Text = "REST API Consumption Examples";
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlsBindingSource)).EndInit();
            this.jsonSplitContainer_SPLT.Panel1.ResumeLayout(false);
            this.jsonSplitContainer_SPLT.Panel1.PerformLayout();
            this.jsonSplitContainer_SPLT.Panel2.ResumeLayout(false);
            this.jsonSplitContainer_SPLT.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jsonSplitContainer_SPLT)).EndInit();
            this.jsonSplitContainer_SPLT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patientTreatments_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource)).EndInit();
            this.mainSplitContainer_SPLT.Panel1.ResumeLayout(false);
            this.mainSplitContainer_SPLT.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer_SPLT)).EndInit();
            this.mainSplitContainer_SPLT.ResumeLayout(false);
            this.treatmentsSplitContainer.Panel1.ResumeLayout(false);
            this.treatmentsSplitContainer.Panel1.PerformLayout();
            this.treatmentsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treatmentsSplitContainer)).EndInit();
            this.treatmentsSplitContainer.ResumeLayout(false);
            this.checkResultSplitContainer_SPLT.Panel1.ResumeLayout(false);
            this.checkResultSplitContainer_SPLT.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkResultSplitContainer_SPLT)).EndInit();
            this.checkResultSplitContainer_SPLT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.violationsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getInvoicePublicIds_BTN;
        private System.Windows.Forms.Button getDentalCheckerVersionResponse_BTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox apiKey_TXT;
        private System.Windows.Forms.Button loadKey_BTN;
        private System.Windows.Forms.Button saveKey_BTN;
        private System.Windows.Forms.Button getInvoice_BTN;
        private System.Windows.Forms.TextBox invoiceNr_TXT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox url_CB;
        private System.Windows.Forms.SplitContainer jsonSplitContainer_SPLT;
        private System.Windows.Forms.TextBox json_TXT;
        private System.Windows.Forms.TextBox prettyJSon_TXT;
        private System.Windows.Forms.ComboBox invoicePublicIds_CB;
        private System.Windows.Forms.Button testResponse_BTN;
        private System.Windows.Forms.DataGridView patientTreatments_DGV;
        private System.Windows.Forms.TextBox patientHealthInsurance_TXT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox patientBirthdate_TXT;
        private System.Windows.Forms.TextBox patientPolicyNumber_TXT;
        private System.Windows.Forms.ComboBox patientExternalId_CB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dentalElementCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tariffAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn declaredAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calculatedAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrOfTreatmentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn therapistAGBCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeOfTreatmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource treatmentBindingSource;
        private System.Windows.Forms.SplitContainer mainSplitContainer_SPLT;
        private System.Windows.Forms.SplitContainer treatmentsSplitContainer;
        private System.Windows.Forms.ListBox patientViolations_LB;
        private System.Windows.Forms.BindingSource violationsBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource configurationBindingSource;
        private System.Windows.Forms.BindingSource urlsBindingSource;
        private System.Windows.Forms.WebBrowser checkReportRenderer_WB;
        private System.Windows.Forms.SplitContainer checkResultSplitContainer_SPLT;
    }
}

