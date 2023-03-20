namespace TBDRoller
{
    partial class MapGenerator
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
            this.form2Close = new System.Windows.Forms.Button();
            this.form2Gen = new System.Windows.Forms.Button();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.form2Save = new System.Windows.Forms.Button();
            this.mapSave = new System.Windows.Forms.SaveFileDialog();
            this.mapView = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.form2Print = new System.Windows.Forms.Button();
            this.mapPrintDialog = new System.Windows.Forms.PrintDialog();
            this.mapPrint = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.mapView)).BeginInit();
            this.SuspendLayout();
            // 
            // form2Close
            // 
            this.form2Close.Location = new System.Drawing.Point(847, 584);
            this.form2Close.Name = "form2Close";
            this.form2Close.Size = new System.Drawing.Size(75, 23);
            this.form2Close.TabIndex = 1;
            this.form2Close.Text = "Close";
            this.form2Close.UseVisualStyleBackColor = true;
            this.form2Close.Click += new System.EventHandler(this.form2Close_Click);
            // 
            // form2Gen
            // 
            this.form2Gen.Location = new System.Drawing.Point(847, 49);
            this.form2Gen.Name = "form2Gen";
            this.form2Gen.Size = new System.Drawing.Size(75, 23);
            this.form2Gen.TabIndex = 3;
            this.form2Gen.Text = "New Map";
            this.form2Gen.UseVisualStyleBackColor = true;
            this.form2Gen.Click += new System.EventHandler(this.form2Gen_Click);
            // 
            // mapPanel
            // 
            this.mapPanel.Location = new System.Drawing.Point(0, 0);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(200, 100);
            this.mapPanel.TabIndex = 0;
            // 
            // form2Save
            // 
            this.form2Save.Location = new System.Drawing.Point(847, 78);
            this.form2Save.Name = "form2Save";
            this.form2Save.Size = new System.Drawing.Size(75, 23);
            this.form2Save.TabIndex = 5;
            this.form2Save.Text = "Save Map";
            this.form2Save.UseVisualStyleBackColor = true;
            this.form2Save.Click += new System.EventHandler(this.form2Save_Click);
            // 
            // mapView
            // 
            this.mapView.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.mapView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mapView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapView.Location = new System.Drawing.Point(2, 2);
            this.mapView.Name = "mapView";
            this.mapView.Size = new System.Drawing.Size(805, 605);
            this.mapView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mapView.TabIndex = 4;
            this.mapView.TabStop = false;
            this.mapView.WaitOnLoad = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Dungeon"});
            this.comboBox1.Location = new System.Drawing.Point(825, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "Dungeon";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(856, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Map Type";
            // 
            // form2Print
            // 
            this.form2Print.Location = new System.Drawing.Point(847, 108);
            this.form2Print.Name = "form2Print";
            this.form2Print.Size = new System.Drawing.Size(75, 23);
            this.form2Print.TabIndex = 8;
            this.form2Print.Text = "Print Map";
            this.form2Print.UseVisualStyleBackColor = true;
            this.form2Print.Click += new System.EventHandler(this.form2Print_Click);
            // 
            // mapPrintDialog
            // 
            this.mapPrintDialog.UseEXDialog = true;
            // 
            // MapGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 623);
            this.Controls.Add(this.form2Print);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.form2Save);
            this.Controls.Add(this.mapView);
            this.Controls.Add(this.form2Gen);
            this.Controls.Add(this.form2Close);
            this.Name = "MapGenerator";
            this.Text = "Map Generator";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button form2Close;
        private System.Windows.Forms.Button form2Gen;
        private System.Windows.Forms.PictureBox mapView;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.Button form2Save;
        private System.Windows.Forms.SaveFileDialog mapSave;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button form2Print;
        private System.Windows.Forms.PrintDialog mapPrintDialog;
        private System.Drawing.Printing.PrintDocument mapPrint;
    }
}