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
            this.json_TXT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.apiKey_TXT = new System.Windows.Forms.TextBox();
            this.loadKey_BTN = new System.Windows.Forms.Button();
            this.saveKey_BTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // getTestResponse_BTN
            // 
            this.getTestResponse_BTN.Location = new System.Drawing.Point(183, 1);
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
            this.getDentalCheckerVersionResponse_BTN.Size = new System.Drawing.Size(170, 34);
            this.getDentalCheckerVersionResponse_BTN.TabIndex = 1;
            this.getDentalCheckerVersionResponse_BTN.Text = "DENTIC Response";
            this.getDentalCheckerVersionResponse_BTN.UseVisualStyleBackColor = true;
            this.getDentalCheckerVersionResponse_BTN.Click += new System.EventHandler(this.getDentalCheckerVersionResponse_BTN_Click);
            // 
            // json_TXT
            // 
            this.json_TXT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.json_TXT.Location = new System.Drawing.Point(7, 41);
            this.json_TXT.Multiline = true;
            this.json_TXT.Name = "json_TXT";
            this.json_TXT.Size = new System.Drawing.Size(1187, 973);
            this.json_TXT.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(488, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "api key:";
            // 
            // apiKey_TXT
            // 
            this.apiKey_TXT.Location = new System.Drawing.Point(551, 4);
            this.apiKey_TXT.Name = "apiKey_TXT";
            this.apiKey_TXT.Size = new System.Drawing.Size(306, 22);
            this.apiKey_TXT.TabIndex = 4;
            // 
            // loadKey_BTN
            // 
            this.loadKey_BTN.Location = new System.Drawing.Point(864, 2);
            this.loadKey_BTN.Name = "loadKey_BTN";
            this.loadKey_BTN.Size = new System.Drawing.Size(89, 33);
            this.loadKey_BTN.TabIndex = 5;
            this.loadKey_BTN.Text = "Load Key";
            this.loadKey_BTN.UseVisualStyleBackColor = true;
            this.loadKey_BTN.Click += new System.EventHandler(this.loadKey_BTN_Click);
            // 
            // saveKey_BTN
            // 
            this.saveKey_BTN.Location = new System.Drawing.Point(959, 2);
            this.saveKey_BTN.Name = "saveKey_BTN";
            this.saveKey_BTN.Size = new System.Drawing.Size(87, 33);
            this.saveKey_BTN.TabIndex = 6;
            this.saveKey_BTN.Text = "Save Key";
            this.saveKey_BTN.UseVisualStyleBackColor = true;
            this.saveKey_BTN.Click += new System.EventHandler(this.saveKey_BTN_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 1018);
            this.Controls.Add(this.saveKey_BTN);
            this.Controls.Add(this.loadKey_BTN);
            this.Controls.Add(this.apiKey_TXT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.json_TXT);
            this.Controls.Add(this.getDentalCheckerVersionResponse_BTN);
            this.Controls.Add(this.getTestResponse_BTN);
            this.Name = "mainForm";
            this.Text = "REST API Consumption Examples";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getTestResponse_BTN;
        private System.Windows.Forms.Button getDentalCheckerVersionResponse_BTN;
        private System.Windows.Forms.TextBox json_TXT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox apiKey_TXT;
        private System.Windows.Forms.Button loadKey_BTN;
        private System.Windows.Forms.Button saveKey_BTN;
    }
}

