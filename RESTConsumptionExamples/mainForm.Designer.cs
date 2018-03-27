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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.json_TXT = new System.Windows.Forms.TextBox();
            this.prettyJSon_TXT = new System.Windows.Forms.TextBox();
            this.invoicePublicIds_CB = new System.Windows.Forms.ComboBox();
            this.testResponse_BTN = new System.Windows.Forms.Button();
            this.patientTreatments_DGV = new System.Windows.Forms.DataGridView();
            this.patientHealthInsurance_TXT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.patientBirthdate_TXT = new System.Windows.Forms.TextBox();
            this.patientPolicyNumber_TXT = new System.Windows.Forms.TextBox();
            this.patientExternalId_CB = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientTreatments_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // getInvoicePublicIds_BTN
            // 
            this.getInvoicePublicIds_BTN.Location = new System.Drawing.Point(252, 37);
            this.getInvoicePublicIds_BTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.getInvoicePublicIds_BTN.Name = "getInvoicePublicIds_BTN";
            this.getInvoicePublicIds_BTN.Size = new System.Drawing.Size(160, 24);
            this.getInvoicePublicIds_BTN.TabIndex = 0;
            this.getInvoicePublicIds_BTN.Text = "Get Invoice Public Ids";
            this.getInvoicePublicIds_BTN.UseVisualStyleBackColor = true;
            this.getInvoicePublicIds_BTN.Click += new System.EventHandler(this.getInvoicePublicIds_BTN_Click);
            // 
            // getDentalCheckerVersionResponse_BTN
            // 
            this.getDentalCheckerVersionResponse_BTN.Location = new System.Drawing.Point(836, 27);
            this.getDentalCheckerVersionResponse_BTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.label1.Location = new System.Drawing.Point(789, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "api key:";
            // 
            // apiKey_TXT
            // 
            this.apiKey_TXT.Location = new System.Drawing.Point(836, 3);
            this.apiKey_TXT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.apiKey_TXT.Name = "apiKey_TXT";
            this.apiKey_TXT.Size = new System.Drawing.Size(230, 20);
            this.apiKey_TXT.TabIndex = 4;
            // 
            // loadKey_BTN
            // 
            this.loadKey_BTN.Location = new System.Drawing.Point(1071, 2);
            this.loadKey_BTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loadKey_BTN.Name = "loadKey_BTN";
            this.loadKey_BTN.Size = new System.Drawing.Size(76, 27);
            this.loadKey_BTN.TabIndex = 5;
            this.loadKey_BTN.Text = "Load Config";
            this.loadKey_BTN.UseVisualStyleBackColor = true;
            this.loadKey_BTN.Click += new System.EventHandler(this.loadKey_BTN_Click);
            // 
            // saveKey_BTN
            // 
            this.saveKey_BTN.Location = new System.Drawing.Point(1152, 2);
            this.saveKey_BTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveKey_BTN.Name = "saveKey_BTN";
            this.saveKey_BTN.Size = new System.Drawing.Size(70, 27);
            this.saveKey_BTN.TabIndex = 6;
            this.saveKey_BTN.Text = "Save Config";
            this.saveKey_BTN.UseVisualStyleBackColor = true;
            this.saveKey_BTN.Click += new System.EventHandler(this.saveKey_BTN_Click);
            // 
            // getInvoice_BTN
            // 
            this.getInvoice_BTN.Location = new System.Drawing.Point(28, 34);
            this.getInvoice_BTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.getInvoice_BTN.Name = "getInvoice_BTN";
            this.getInvoice_BTN.Size = new System.Drawing.Size(79, 27);
            this.getInvoice_BTN.TabIndex = 7;
            this.getInvoice_BTN.Text = "Get Invoice";
            this.getInvoice_BTN.UseVisualStyleBackColor = true;
            this.getInvoice_BTN.Click += new System.EventHandler(this.getInvoice_BTN_Click);
            // 
            // invoiceNr_TXT
            // 
            this.invoiceNr_TXT.Location = new System.Drawing.Point(118, 38);
            this.invoiceNr_TXT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.invoiceNr_TXT.Name = "invoiceNr_TXT";
            this.invoiceNr_TXT.Size = new System.Drawing.Size(128, 20);
            this.invoiceNr_TXT.TabIndex = 8;
            this.invoiceNr_TXT.Text = "INV-0000000304";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(483, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "url:";
            // 
            // url_CB
            // 
            this.url_CB.FormattingEnabled = true;
            this.url_CB.Items.AddRange(new object[] {
            "http://172.30.143.132:9090/",
            "http://127.0.0.1:18081/dental-checker/",
            "http://127.0.0.1:28081/dental-checker/",
            "http://172.30.182.88:9090/"});
            this.url_CB.Location = new System.Drawing.Point(508, 3);
            this.url_CB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.url_CB.Name = "url_CB";
            this.url_CB.Size = new System.Drawing.Size(277, 21);
            this.url_CB.TabIndex = 12;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 317);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.json_TXT);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.prettyJSon_TXT);
            this.splitContainer1.Size = new System.Drawing.Size(1799, 507);
            this.splitContainer1.SplitterDistance = 439;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 13;
            // 
            // json_TXT
            // 
            this.json_TXT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.json_TXT.Font = new System.Drawing.Font("Andale Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.json_TXT.Location = new System.Drawing.Point(4, 2);
            this.json_TXT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.json_TXT.Multiline = true;
            this.json_TXT.Name = "json_TXT";
            this.json_TXT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.json_TXT.Size = new System.Drawing.Size(430, 503);
            this.json_TXT.TabIndex = 3;
            // 
            // prettyJSon_TXT
            // 
            this.prettyJSon_TXT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prettyJSon_TXT.Font = new System.Drawing.Font("Andale Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prettyJSon_TXT.Location = new System.Drawing.Point(5, 2);
            this.prettyJSon_TXT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.prettyJSon_TXT.Multiline = true;
            this.prettyJSon_TXT.Name = "prettyJSon_TXT";
            this.prettyJSon_TXT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.prettyJSon_TXT.Size = new System.Drawing.Size(1351, 503);
            this.prettyJSon_TXT.TabIndex = 14;
            // 
            // invoicePublicIds_CB
            // 
            this.invoicePublicIds_CB.FormattingEnabled = true;
            this.invoicePublicIds_CB.Items.AddRange(new object[] {
            "<empty>"});
            this.invoicePublicIds_CB.Location = new System.Drawing.Point(118, 65);
            this.invoicePublicIds_CB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.invoicePublicIds_CB.Name = "invoicePublicIds_CB";
            this.invoicePublicIds_CB.Size = new System.Drawing.Size(128, 21);
            this.invoicePublicIds_CB.TabIndex = 14;
            this.invoicePublicIds_CB.SelectedIndexChanged += new System.EventHandler(this.invoicePublicIds_CB_SelectedIndexChanged);
            this.invoicePublicIds_CB.SelectedValueChanged += new System.EventHandler(this.invoicePublicIds_CB_SelectedValueChanged);
            // 
            // testResponse_BTN
            // 
            this.testResponse_BTN.Location = new System.Drawing.Point(946, 27);
            this.testResponse_BTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.testResponse_BTN.Name = "testResponse_BTN";
            this.testResponse_BTN.Size = new System.Drawing.Size(108, 28);
            this.testResponse_BTN.TabIndex = 15;
            this.testResponse_BTN.Text = "Test Response";
            this.testResponse_BTN.UseVisualStyleBackColor = true;
            this.testResponse_BTN.Click += new System.EventHandler(this.testResponse_BTN_Click);
            // 
            // patientTreatments_DGV
            // 
            this.patientTreatments_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patientTreatments_DGV.Location = new System.Drawing.Point(252, 65);
            this.patientTreatments_DGV.Name = "patientTreatments_DGV";
            this.patientTreatments_DGV.Size = new System.Drawing.Size(1550, 247);
            this.patientTreatments_DGV.TabIndex = 16;
            // 
            // patientHealthInsurance_TXT
            // 
            this.patientHealthInsurance_TXT.Location = new System.Drawing.Point(118, 154);
            this.patientHealthInsurance_TXT.Name = "patientHealthInsurance_TXT";
            this.patientHealthInsurance_TXT.Size = new System.Drawing.Size(128, 20);
            this.patientHealthInsurance_TXT.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Health Insurance:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Birthdate:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Policy Nr:";
            // 
            // patientBirthdate_TXT
            // 
            this.patientBirthdate_TXT.Location = new System.Drawing.Point(118, 186);
            this.patientBirthdate_TXT.Name = "patientBirthdate_TXT";
            this.patientBirthdate_TXT.Size = new System.Drawing.Size(128, 20);
            this.patientBirthdate_TXT.TabIndex = 23;
            // 
            // patientPolicyNumber_TXT
            // 
            this.patientPolicyNumber_TXT.Location = new System.Drawing.Point(118, 222);
            this.patientPolicyNumber_TXT.Name = "patientPolicyNumber_TXT";
            this.patientPolicyNumber_TXT.Size = new System.Drawing.Size(128, 20);
            this.patientPolicyNumber_TXT.TabIndex = 25;
            // 
            // patientExternalId_CB
            // 
            this.patientExternalId_CB.FormattingEnabled = true;
            this.patientExternalId_CB.Items.AddRange(new object[] {
            "<empty>"});
            this.patientExternalId_CB.Location = new System.Drawing.Point(118, 98);
            this.patientExternalId_CB.Margin = new System.Windows.Forms.Padding(2);
            this.patientExternalId_CB.Name = "patientExternalId_CB";
            this.patientExternalId_CB.Size = new System.Drawing.Size(128, 21);
            this.patientExternalId_CB.TabIndex = 26;
            this.patientExternalId_CB.SelectedIndexChanged += new System.EventHandler(this.patientExternalId_CB_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Patient external ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Invoice Public ID:";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1814, 827);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.patientExternalId_CB);
            this.Controls.Add(this.patientPolicyNumber_TXT);
            this.Controls.Add(this.patientBirthdate_TXT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.patientHealthInsurance_TXT);
            this.Controls.Add(this.patientTreatments_DGV);
            this.Controls.Add(this.testResponse_BTN);
            this.Controls.Add(this.invoicePublicIds_CB);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.url_CB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.invoiceNr_TXT);
            this.Controls.Add(this.getInvoice_BTN);
            this.Controls.Add(this.saveKey_BTN);
            this.Controls.Add(this.loadKey_BTN);
            this.Controls.Add(this.apiKey_TXT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getDentalCheckerVersionResponse_BTN);
            this.Controls.Add(this.getInvoicePublicIds_BTN);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "mainForm";
            this.Text = "REST API Consumption Examples";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patientTreatments_DGV)).EndInit();
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
        private System.Windows.Forms.SplitContainer splitContainer1;
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
    }
}

