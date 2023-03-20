namespace ImporterAndExporter
{
    partial class ImporterExporter
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
            this.labelClient = new System.Windows.Forms.Label();
            this.labelListener = new System.Windows.Forms.Label();
            this.labelDataToSend = new System.Windows.Forms.Label();
            this.textBoxIPAddress1 = new System.Windows.Forms.TextBox();
            this.textBoxIPAddress2 = new System.Windows.Forms.TextBox();
            this.labelIPAdd1 = new System.Windows.Forms.Label();
            this.labelIPAdd2 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.comboBoxResources = new System.Windows.Forms.ComboBox();
            this.textBoxDataStatus = new System.Windows.Forms.TextBox();
            this.labelDataStatus = new System.Windows.Forms.Label();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonChangePort = new System.Windows.Forms.Button();
            this.labelPortNum = new System.Windows.Forms.Label();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.labelTip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.SuspendLayout();
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(248, 9);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(89, 13);
            this.labelClient.TabIndex = 0;
            this.labelClient.Text = "Their Information:";
            // 
            // labelListener
            // 
            this.labelListener.AutoSize = true;
            this.labelListener.Location = new System.Drawing.Point(23, 9);
            this.labelListener.Name = "labelListener";
            this.labelListener.Size = new System.Drawing.Size(87, 13);
            this.labelListener.TabIndex = 1;
            this.labelListener.Text = "Your Information:";
            // 
            // labelDataToSend
            // 
            this.labelDataToSend.AutoSize = true;
            this.labelDataToSend.Location = new System.Drawing.Point(34, 195);
            this.labelDataToSend.Name = "labelDataToSend";
            this.labelDataToSend.Size = new System.Drawing.Size(76, 13);
            this.labelDataToSend.TabIndex = 2;
            this.labelDataToSend.Text = "What to Send:";
            // 
            // textBoxIPAddress1
            // 
            this.textBoxIPAddress1.Location = new System.Drawing.Point(341, 29);
            this.textBoxIPAddress1.Name = "textBoxIPAddress1";
            this.textBoxIPAddress1.Size = new System.Drawing.Size(112, 20);
            this.textBoxIPAddress1.TabIndex = 3;
            // 
            // textBoxIPAddress2
            // 
            this.textBoxIPAddress2.Location = new System.Drawing.Point(116, 32);
            this.textBoxIPAddress2.Name = "textBoxIPAddress2";
            this.textBoxIPAddress2.ReadOnly = true;
            this.textBoxIPAddress2.Size = new System.Drawing.Size(112, 20);
            this.textBoxIPAddress2.TabIndex = 5;
            // 
            // labelIPAdd1
            // 
            this.labelIPAdd1.AutoSize = true;
            this.labelIPAdd1.Location = new System.Drawing.Point(274, 32);
            this.labelIPAdd1.Name = "labelIPAdd1";
            this.labelIPAdd1.Size = new System.Drawing.Size(61, 13);
            this.labelIPAdd1.TabIndex = 7;
            this.labelIPAdd1.Text = "IP Address:";
            // 
            // labelIPAdd2
            // 
            this.labelIPAdd2.AutoSize = true;
            this.labelIPAdd2.Location = new System.Drawing.Point(49, 35);
            this.labelIPAdd2.Name = "labelIPAdd2";
            this.labelIPAdd2.Size = new System.Drawing.Size(61, 13);
            this.labelIPAdd2.TabIndex = 9;
            this.labelIPAdd2.Text = "IP Address:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(234, 77);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(112, 23);
            this.buttonConnect.TabIndex = 11;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(172, 221);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(88, 23);
            this.buttonSend.TabIndex = 12;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(116, 79);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(112, 20);
            this.textBoxStatus.TabIndex = 13;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(13, 82);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(97, 13);
            this.labelStatus.TabIndex = 14;
            this.labelStatus.Text = "Connection Status:";
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(234, 105);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(112, 23);
            this.buttonDisconnect.TabIndex = 15;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // comboBoxResources
            // 
            this.comboBoxResources.FormattingEnabled = true;
            this.comboBoxResources.Location = new System.Drawing.Point(116, 192);
            this.comboBoxResources.Name = "comboBoxResources";
            this.comboBoxResources.Size = new System.Drawing.Size(144, 21);
            this.comboBoxResources.TabIndex = 16;
            // 
            // textBoxDataStatus
            // 
            this.textBoxDataStatus.Location = new System.Drawing.Point(343, 192);
            this.textBoxDataStatus.Name = "textBoxDataStatus";
            this.textBoxDataStatus.ReadOnly = true;
            this.textBoxDataStatus.Size = new System.Drawing.Size(121, 20);
            this.textBoxDataStatus.TabIndex = 17;
            // 
            // labelDataStatus
            // 
            this.labelDataStatus.AutoSize = true;
            this.labelDataStatus.Location = new System.Drawing.Point(271, 195);
            this.labelDataStatus.Name = "labelDataStatus";
            this.labelDataStatus.Size = new System.Drawing.Size(66, 13);
            this.labelDataStatus.TabIndex = 18;
            this.labelDataStatus.Text = "Data Status:";
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(234, 134);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(112, 23);
            this.buttonHelp.TabIndex = 19;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonChangePort
            // 
            this.buttonChangePort.Location = new System.Drawing.Point(352, 77);
            this.buttonChangePort.Name = "buttonChangePort";
            this.buttonChangePort.Size = new System.Drawing.Size(112, 23);
            this.buttonChangePort.TabIndex = 20;
            this.buttonChangePort.Text = "Change Port Num";
            this.buttonChangePort.UseVisualStyleBackColor = true;
            this.buttonChangePort.Click += new System.EventHandler(this.buttonChangePort_Click);
            // 
            // labelPortNum
            // 
            this.labelPortNum.AutoSize = true;
            this.labelPortNum.Location = new System.Drawing.Point(352, 110);
            this.labelPortNum.Name = "labelPortNum";
            this.labelPortNum.Size = new System.Drawing.Size(69, 13);
            this.labelPortNum.TabIndex = 21;
            this.labelPortNum.Text = "Port Number:";
            this.labelPortNum.Visible = false;
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(365, 126);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPort.Minimum = new decimal(new int[] {
            11000,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(88, 20);
            this.numericUpDownPort.TabIndex = 22;
            this.numericUpDownPort.Value = new decimal(new int[] {
            11000,
            0,
            0,
            0});
            this.numericUpDownPort.Visible = false;
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.Location = new System.Drawing.Point(362, 149);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(111, 13);
            this.labelTip.TabIndex = 23;
            this.labelTip.Text = "Click again to confirm.";
            this.labelTip.Visible = false;
            // 
            // ImporterExporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 254);
            this.Controls.Add(this.labelTip);
            this.Controls.Add(this.numericUpDownPort);
            this.Controls.Add(this.labelPortNum);
            this.Controls.Add(this.buttonChangePort);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.labelDataStatus);
            this.Controls.Add(this.textBoxDataStatus);
            this.Controls.Add(this.comboBoxResources);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.labelIPAdd2);
            this.Controls.Add(this.labelIPAdd1);
            this.Controls.Add(this.textBoxIPAddress2);
            this.Controls.Add(this.textBoxIPAddress1);
            this.Controls.Add(this.labelDataToSend);
            this.Controls.Add(this.labelListener);
            this.Controls.Add(this.labelClient);
            this.Name = "ImporterExporter";
            this.Text = "Importer/Exporter";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.Label labelListener;
        private System.Windows.Forms.Label labelDataToSend;
        private System.Windows.Forms.TextBox textBoxIPAddress1;
        private System.Windows.Forms.TextBox textBoxIPAddress2;
        private System.Windows.Forms.Label labelIPAdd1;
        private System.Windows.Forms.Label labelIPAdd2;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.ComboBox comboBoxResources;
        private System.Windows.Forms.TextBox textBoxDataStatus;
        private System.Windows.Forms.Label labelDataStatus;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonChangePort;
        private System.Windows.Forms.Label labelPortNum;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.Label labelTip;
    }
}

