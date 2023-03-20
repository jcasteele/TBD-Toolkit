namespace TBDRollerToolkit
{
    partial class Importer
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
            this.labelDataStatus = new System.Windows.Forms.Label();
            this.textBoxDataStatus = new System.Windows.Forms.TextBox();
            this.comboBoxResources = new System.Windows.Forms.ComboBox();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelPortNum2 = new System.Windows.Forms.Label();
            this.labelIPAdd2 = new System.Windows.Forms.Label();
            this.labelPortNum1 = new System.Windows.Forms.Label();
            this.labelIPAdd1 = new System.Windows.Forms.Label();
            this.textBoxPortNum2 = new System.Windows.Forms.TextBox();
            this.textBoxIPAddress2 = new System.Windows.Forms.TextBox();
            this.textBoxPortNum1 = new System.Windows.Forms.TextBox();
            this.textBoxIPAddress1 = new System.Windows.Forms.TextBox();
            this.labelDataToSend = new System.Windows.Forms.Label();
            this.labelListener = new System.Windows.Forms.Label();
            this.labelClient = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDataStatus
            // 
            this.labelDataStatus.AutoSize = true;
            this.labelDataStatus.Location = new System.Drawing.Point(257, 228);
            this.labelDataStatus.Name = "labelDataStatus";
            this.labelDataStatus.Size = new System.Drawing.Size(66, 13);
            this.labelDataStatus.TabIndex = 37;
            this.labelDataStatus.Text = "Data Status:";
            // 
            // textBoxDataStatus
            // 
            this.textBoxDataStatus.Location = new System.Drawing.Point(329, 225);
            this.textBoxDataStatus.Name = "textBoxDataStatus";
            this.textBoxDataStatus.ReadOnly = true;
            this.textBoxDataStatus.Size = new System.Drawing.Size(121, 20);
            this.textBoxDataStatus.TabIndex = 36;
            // 
            // comboBoxResources
            // 
            this.comboBoxResources.FormattingEnabled = true;
            this.comboBoxResources.Location = new System.Drawing.Point(103, 225);
            this.comboBoxResources.Name = "comboBoxResources";
            this.comboBoxResources.Size = new System.Drawing.Size(144, 21);
            this.comboBoxResources.TabIndex = 35;
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(103, 175);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(112, 23);
            this.buttonDisconnect.TabIndex = 34;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(-1, 123);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(97, 13);
            this.labelStatus.TabIndex = 33;
            this.labelStatus.Text = "Connection Status:";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(103, 119);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(112, 20);
            this.textBoxStatus.TabIndex = 32;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(158, 254);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(88, 23);
            this.buttonSend.TabIndex = 31;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(103, 145);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(112, 23);
            this.buttonConnect.TabIndex = 30;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelPortNum2
            // 
            this.labelPortNum2.AutoSize = true;
            this.labelPortNum2.Location = new System.Drawing.Point(254, 84);
            this.labelPortNum2.Name = "labelPortNum2";
            this.labelPortNum2.Size = new System.Drawing.Size(69, 13);
            this.labelPortNum2.TabIndex = 29;
            this.labelPortNum2.Text = "Port Number:";
            // 
            // labelIPAdd2
            // 
            this.labelIPAdd2.AutoSize = true;
            this.labelIPAdd2.Location = new System.Drawing.Point(35, 84);
            this.labelIPAdd2.Name = "labelIPAdd2";
            this.labelIPAdd2.Size = new System.Drawing.Size(61, 13);
            this.labelIPAdd2.TabIndex = 28;
            this.labelIPAdd2.Text = "IP Address:";
            // 
            // labelPortNum1
            // 
            this.labelPortNum1.AutoSize = true;
            this.labelPortNum1.Location = new System.Drawing.Point(254, 30);
            this.labelPortNum1.Name = "labelPortNum1";
            this.labelPortNum1.Size = new System.Drawing.Size(69, 13);
            this.labelPortNum1.TabIndex = 27;
            this.labelPortNum1.Text = "Port Number:";
            // 
            // labelIPAdd1
            // 
            this.labelIPAdd1.AutoSize = true;
            this.labelIPAdd1.Location = new System.Drawing.Point(35, 30);
            this.labelIPAdd1.Name = "labelIPAdd1";
            this.labelIPAdd1.Size = new System.Drawing.Size(61, 13);
            this.labelIPAdd1.TabIndex = 26;
            this.labelIPAdd1.Text = "IP Address:";
            // 
            // textBoxPortNum2
            // 
            this.textBoxPortNum2.Location = new System.Drawing.Point(329, 81);
            this.textBoxPortNum2.Name = "textBoxPortNum2";
            this.textBoxPortNum2.Size = new System.Drawing.Size(88, 20);
            this.textBoxPortNum2.TabIndex = 25;
            // 
            // textBoxIPAddress2
            // 
            this.textBoxIPAddress2.Location = new System.Drawing.Point(103, 81);
            this.textBoxIPAddress2.Name = "textBoxIPAddress2";
            this.textBoxIPAddress2.ReadOnly = true;
            this.textBoxIPAddress2.Size = new System.Drawing.Size(112, 20);
            this.textBoxIPAddress2.TabIndex = 24;
            // 
            // textBoxPortNum1
            // 
            this.textBoxPortNum1.Location = new System.Drawing.Point(329, 28);
            this.textBoxPortNum1.Name = "textBoxPortNum1";
            this.textBoxPortNum1.Size = new System.Drawing.Size(88, 20);
            this.textBoxPortNum1.TabIndex = 23;
            // 
            // textBoxIPAddress1
            // 
            this.textBoxIPAddress1.Location = new System.Drawing.Point(103, 28);
            this.textBoxIPAddress1.Name = "textBoxIPAddress1";
            this.textBoxIPAddress1.Size = new System.Drawing.Size(112, 20);
            this.textBoxIPAddress1.TabIndex = 22;
            // 
            // labelDataToSend
            // 
            this.labelDataToSend.AutoSize = true;
            this.labelDataToSend.Location = new System.Drawing.Point(20, 228);
            this.labelDataToSend.Name = "labelDataToSend";
            this.labelDataToSend.Size = new System.Drawing.Size(76, 13);
            this.labelDataToSend.TabIndex = 21;
            this.labelDataToSend.Text = "What to Send:";
            // 
            // labelListener
            // 
            this.labelListener.AutoSize = true;
            this.labelListener.Location = new System.Drawing.Point(10, 58);
            this.labelListener.Name = "labelListener";
            this.labelListener.Size = new System.Drawing.Size(87, 13);
            this.labelListener.TabIndex = 20;
            this.labelListener.Text = "Your Information:";
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(10, 7);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(89, 13);
            this.labelClient.TabIndex = 19;
            this.labelClient.Text = "Their Information:";
            // 
            // Importer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 288);
            this.Controls.Add(this.labelDataStatus);
            this.Controls.Add(this.textBoxDataStatus);
            this.Controls.Add(this.comboBoxResources);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.labelPortNum2);
            this.Controls.Add(this.labelIPAdd2);
            this.Controls.Add(this.labelPortNum1);
            this.Controls.Add(this.labelIPAdd1);
            this.Controls.Add(this.textBoxPortNum2);
            this.Controls.Add(this.textBoxIPAddress2);
            this.Controls.Add(this.textBoxPortNum1);
            this.Controls.Add(this.textBoxIPAddress1);
            this.Controls.Add(this.labelDataToSend);
            this.Controls.Add(this.labelListener);
            this.Controls.Add(this.labelClient);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Importer";
            this.Text = "Importer/Exporter";
            this.Load += new System.EventHandler(this.Importer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDataStatus;
        private System.Windows.Forms.TextBox textBoxDataStatus;
        private System.Windows.Forms.ComboBox comboBoxResources;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelPortNum2;
        private System.Windows.Forms.Label labelIPAdd2;
        private System.Windows.Forms.Label labelPortNum1;
        private System.Windows.Forms.Label labelIPAdd1;
        private System.Windows.Forms.TextBox textBoxPortNum2;
        private System.Windows.Forms.TextBox textBoxIPAddress2;
        private System.Windows.Forms.TextBox textBoxPortNum1;
        private System.Windows.Forms.TextBox textBoxIPAddress1;
        private System.Windows.Forms.Label labelDataToSend;
        private System.Windows.Forms.Label labelListener;
        private System.Windows.Forms.Label labelClient;
    }
}