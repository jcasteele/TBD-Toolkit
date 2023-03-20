namespace RandomGenerator
{
    partial class DataFileParser
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
            this.numericUpDownIdNum = new System.Windows.Forms.NumericUpDown();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelIdNum = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelOR = new System.Windows.Forms.Label();
            this.richTextBoxDisplay = new System.Windows.Forms.RichTextBox();
            this.buttonParse = new System.Windows.Forms.Button();
            this.comboBoxFileName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIdNum)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownIdNum
            // 
            this.numericUpDownIdNum.Location = new System.Drawing.Point(90, 85);
            this.numericUpDownIdNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownIdNum.Name = "numericUpDownIdNum";
            this.numericUpDownIdNum.Size = new System.Drawing.Size(43, 20);
            this.numericUpDownIdNum.TabIndex = 2;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(90, 143);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(134, 20);
            this.textBoxName.TabIndex = 3;
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(23, 31);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(64, 13);
            this.labelFile.TabIndex = 4;
            this.labelFile.Text = "In Data File:";
            // 
            // labelIdNum
            // 
            this.labelIdNum.AutoSize = true;
            this.labelIdNum.Location = new System.Drawing.Point(23, 87);
            this.labelIdNum.Name = "labelIdNum";
            this.labelIdNum.Size = new System.Drawing.Size(61, 13);
            this.labelIdNum.TabIndex = 6;
            this.labelIdNum.Text = "ID Number:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(23, 146);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "Name:";
            // 
            // labelOR
            // 
            this.labelOR.AutoSize = true;
            this.labelOR.Location = new System.Drawing.Point(23, 116);
            this.labelOR.Name = "labelOR";
            this.labelOR.Size = new System.Drawing.Size(23, 13);
            this.labelOR.TabIndex = 8;
            this.labelOR.Text = "OR";
            // 
            // richTextBoxDisplay
            // 
            this.richTextBoxDisplay.Location = new System.Drawing.Point(247, 18);
            this.richTextBoxDisplay.Name = "richTextBoxDisplay";
            this.richTextBoxDisplay.Size = new System.Drawing.Size(289, 211);
            this.richTextBoxDisplay.TabIndex = 9;
            this.richTextBoxDisplay.Text = "";
            // 
            // buttonParse
            // 
            this.buttonParse.Location = new System.Drawing.Point(90, 169);
            this.buttonParse.Name = "buttonParse";
            this.buttonParse.Size = new System.Drawing.Size(93, 27);
            this.buttonParse.TabIndex = 11;
            this.buttonParse.Text = "Run Parser";
            this.buttonParse.UseVisualStyleBackColor = true;
            this.buttonParse.Click += new System.EventHandler(this.buttonParse_Click);
            // 
            // comboBoxFileName
            // 
            this.comboBoxFileName.FormattingEnabled = true;
            this.comboBoxFileName.Items.AddRange(new object[] {
            "Armor",
            "Armor_Material",
            "Armor_Type",
            "Item",
            "Item_Type",
            "Location",
            "Monster",
            "Monster_Type",
            "NPC",
            "Profession",
            "Scale",
            "Service",
            "Weapon",
            "Weapon_Type"});
            this.comboBoxFileName.Location = new System.Drawing.Point(90, 28);
            this.comboBoxFileName.Name = "comboBoxFileName";
            this.comboBoxFileName.Size = new System.Drawing.Size(134, 21);
            this.comboBoxFileName.TabIndex = 12;
            this.comboBoxFileName.SelectedIndexChanged += new System.EventHandler(this.comboBoxFileName_SelectedIndexChanged);
            // 
            // RandomGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 241);
            this.Controls.Add(this.comboBoxFileName);
            this.Controls.Add(this.buttonParse);
            this.Controls.Add(this.richTextBoxDisplay);
            this.Controls.Add(this.labelOR);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelIdNum);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.numericUpDownIdNum);
            this.Name = "RandomGenerator";
            this.Text = "Data File Parser";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIdNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDownIdNum;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelIdNum;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelOR;
        private System.Windows.Forms.RichTextBox richTextBoxDisplay;
        private System.Windows.Forms.Button buttonParse;
        private System.Windows.Forms.ComboBox comboBoxFileName;
    }
}

