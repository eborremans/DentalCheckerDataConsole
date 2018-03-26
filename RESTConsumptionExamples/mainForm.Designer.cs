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
            this.getTestResponse_BTN = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // getTestResponse_BTN
            // 
            this.getTestResponse_BTN.Location = new System.Drawing.Point(484, 1);
            this.getTestResponse_BTN.Name = "getTestResponse_BTN";
            this.getTestResponse_BTN.Size = new System.Drawing.Size(144, 34);
            this.getTestResponse_BTN.TabIndex = 0;
            this.getTestResponse_BTN.Text = "Test Response";
            this.getTestResponse_BTN.UseVisualStyleBackColor = true;
            this.getTestResponse_BTN.Click += new System.EventHandler(this.getTestResponse_BTN_Click);
            // 
            // getDentalCheckerVersionResponse_BTN
            // 
            this.getDentalCheckerVersionResponse_BTN.Location = new System.Drawing.Point(7, 1);
            this.getDentalCheckerVersionResponse_BTN.Name = "getDentalCheckerVersionResponse_BTN";
            this.getDentalCheckerVersionResponse_BTN.Size = new System.Drawing.Size(142, 34);
            this.getDentalCheckerVersionResponse_BTN.TabIndex = 1;
            this.getDentalCheckerVersionResponse_BTN.Text = "DENTIC Response";
            this.getDentalCheckerVersionResponse_BTN.UseVisualStyleBackColor = true;
            this.getDentalCheckerVersionResponse_BTN.Click += new System.EventHandler(this.getDentalCheckerVersionResponse_BTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1052, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "api key:";
            // 
            // apiKey_TXT
            // 
            this.apiKey_TXT.Location = new System.Drawing.Point(1115, 4);
            this.apiKey_TXT.Name = "apiKey_TXT";
            this.apiKey_TXT.Size = new System.Drawing.Size(306, 22);
            this.apiKey_TXT.TabIndex = 4;
            // 
            // loadKey_BTN
            // 
            this.loadKey_BTN.Location = new System.Drawing.Point(1428, 2);
            this.loadKey_BTN.Name = "loadKey_BTN";
            this.loadKey_BTN.Size = new System.Drawing.Size(102, 33);
            this.loadKey_BTN.TabIndex = 5;
            this.loadKey_BTN.Text = "Load Config";
            this.loadKey_BTN.UseVisualStyleBackColor = true;
            this.loadKey_BTN.Click += new System.EventHandler(this.loadKey_BTN_Click);
            // 
            // saveKey_BTN
            // 
            this.saveKey_BTN.Location = new System.Drawing.Point(1536, 2);
            this.saveKey_BTN.Name = "saveKey_BTN";
            this.saveKey_BTN.Size = new System.Drawing.Size(94, 33);
            this.saveKey_BTN.TabIndex = 6;
            this.saveKey_BTN.Text = "Save Config";
            this.saveKey_BTN.UseVisualStyleBackColor = true;
            this.saveKey_BTN.Click += new System.EventHandler(this.saveKey_BTN_Click);
            // 
            // getInvoice_BTN
            // 
            this.getInvoice_BTN.Location = new System.Drawing.Point(155, 2);
            this.getInvoice_BTN.Name = "getInvoice_BTN";
            this.getInvoice_BTN.Size = new System.Drawing.Size(105, 33);
            this.getInvoice_BTN.TabIndex = 7;
            this.getInvoice_BTN.Text = "Get Invoice";
            this.getInvoice_BTN.UseVisualStyleBackColor = true;
            this.getInvoice_BTN.Click += new System.EventHandler(this.getInvoice_BTN_Click);
            // 
            // invoiceNr_TXT
            // 
            this.invoiceNr_TXT.Location = new System.Drawing.Point(266, 4);
            this.invoiceNr_TXT.Name = "invoiceNr_TXT";
            this.invoiceNr_TXT.Size = new System.Drawing.Size(212, 22);
            this.invoiceNr_TXT.TabIndex = 8;
            this.invoiceNr_TXT.Text = "INV-0000000304";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(644, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "url:";
            // 
            // url_CB
            // 
            this.url_CB.FormattingEnabled = true;
            this.url_CB.Items.AddRange(new object[] {
            "http://127.0.0.1:18081/dental-checker/",
            "http://127.0.0.1:28081/dental-checker/",
            "http://172.30.182.88:9090/"});
            this.url_CB.Location = new System.Drawing.Point(678, 4);
            this.url_CB.Name = "url_CB";
            this.url_CB.Size = new System.Drawing.Size(368, 24);
            this.url_CB.TabIndex = 12;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(7, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.json_TXT);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.prettyJSon_TXT);
            this.splitContainer1.Size = new System.Drawing.Size(1887, 973);
            this.splitContainer1.SplitterDistance = 461;
            this.splitContainer1.TabIndex = 13;
            // 
            // json_TXT
            // 
            this.json_TXT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.json_TXT.Font = new System.Drawing.Font("Andale Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.json_TXT.Location = new System.Drawing.Point(5, 3);
            this.json_TXT.Multiline = true;
            this.json_TXT.Name = "json_TXT";
            this.json_TXT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.json_TXT.Size = new System.Drawing.Size(448, 967);
            this.json_TXT.TabIndex = 3;
            // 
            // prettyJSon_TXT
            // 
            this.prettyJSon_TXT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prettyJSon_TXT.Font = new System.Drawing.Font("Andale Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prettyJSon_TXT.Location = new System.Drawing.Point(7, 3);
            this.prettyJSon_TXT.Multiline = true;
            this.prettyJSon_TXT.Name = "prettyJSon_TXT";
            this.prettyJSon_TXT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.prettyJSon_TXT.Size = new System.Drawing.Size(1412, 967);
            this.prettyJSon_TXT.TabIndex = 14;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1906, 1018);
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
            this.Controls.Add(this.getTestResponse_BTN);
            this.Name = "mainForm";
            this.Text = "REST API Consumption Examples";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getTestResponse_BTN;
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
    }
}

