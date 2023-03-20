namespace RandomGenerator
{
    partial class RandomGenerator
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
            this.comboBoxFileName1 = new System.Windows.Forms.ComboBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.richTextBoxDisplay = new System.Windows.Forms.RichTextBox();
            this.labelFile1 = new System.Windows.Forms.Label();
            this.numericUpDownNumOfGenerations = new System.Windows.Forms.NumericUpDown();
            this.comboBoxFileName2 = new System.Windows.Forms.ComboBox();
            this.buttonParse = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelFile2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelAttribute = new System.Windows.Forms.Label();
            this.comboBoxAttributes = new System.Windows.Forms.ComboBox();
            this.panelSearchPanel = new System.Windows.Forms.Panel();
            this.labelSearch = new System.Windows.Forms.Label();
            this.panelGenerator = new System.Windows.Forms.Panel();
            this.labelNumOfGens = new System.Windows.Forms.Label();
            this.buttonRedo = new System.Windows.Forms.Button();
            this.labelGenerator = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.panelEncounterGen = new System.Windows.Forms.Panel();
            this.buttonRedoEncounter = new System.Windows.Forms.Button();
            this.buttonGenEncounter = new System.Windows.Forms.Button();
            this.labelDifficulty = new System.Windows.Forms.Label();
            this.labelNumOfPlayers = new System.Windows.Forms.Label();
            this.numericUpDownDifficulty = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNumOfPlayers = new System.Windows.Forms.NumericUpDown();
            this.labelRandEncounterGen = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumOfGenerations)).BeginInit();
            this.panelSearchPanel.SuspendLayout();
            this.panelGenerator.SuspendLayout();
            this.panelEncounterGen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDifficulty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumOfPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxFileName1
            // 
            this.comboBoxFileName1.FormattingEnabled = true;
            this.comboBoxFileName1.Items.AddRange(new object[] {
            "Armor",
            "Armor Material",
            "Armor Type",
            "Item",
            "Item Type",
            "Location",
            "Monster",
            "Monster Type",
            "NPC",
            "Profession",
            "Scale",
            "Service",
            "Weapon",
            "Weapon Type"});
            this.comboBoxFileName1.Location = new System.Drawing.Point(75, 18);
            this.comboBoxFileName1.Name = "comboBoxFileName1";
            this.comboBoxFileName1.Size = new System.Drawing.Size(134, 21);
            this.comboBoxFileName1.TabIndex = 26;
            this.comboBoxFileName1.SelectedIndexChanged += new System.EventHandler(this.comboBoxFileName1_SelectedIndexChanged);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(75, 71);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(85, 27);
            this.buttonGenerate.TabIndex = 25;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // richTextBoxDisplay
            // 
            this.richTextBoxDisplay.Location = new System.Drawing.Point(270, 117);
            this.richTextBoxDisplay.Name = "richTextBoxDisplay";
            this.richTextBoxDisplay.Size = new System.Drawing.Size(267, 253);
            this.richTextBoxDisplay.TabIndex = 24;
            this.richTextBoxDisplay.Text = "";
            // 
            // labelFile1
            // 
            this.labelFile1.AutoSize = true;
            this.labelFile1.Location = new System.Drawing.Point(11, 23);
            this.labelFile1.Name = "labelFile1";
            this.labelFile1.Size = new System.Drawing.Size(26, 13);
            this.labelFile1.TabIndex = 23;
            this.labelFile1.Text = "File:";
            // 
            // numericUpDownNumOfGenerations
            // 
            this.numericUpDownNumOfGenerations.Location = new System.Drawing.Point(75, 45);
            this.numericUpDownNumOfGenerations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumOfGenerations.Name = "numericUpDownNumOfGenerations";
            this.numericUpDownNumOfGenerations.Size = new System.Drawing.Size(43, 20);
            this.numericUpDownNumOfGenerations.TabIndex = 27;
            this.numericUpDownNumOfGenerations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxFileName2
            // 
            this.comboBoxFileName2.FormattingEnabled = true;
            this.comboBoxFileName2.Items.AddRange(new object[] {
            "Armor",
            "Armor Material",
            "Armor Type",
            "Item",
            "Item Type",
            "Location",
            "Monster",
            "Monster Type",
            "NPC",
            "Profession",
            "Scale",
            "Service",
            "Weapon",
            "Weapon Type"});
            this.comboBoxFileName2.Location = new System.Drawing.Point(89, 24);
            this.comboBoxFileName2.Name = "comboBoxFileName2";
            this.comboBoxFileName2.Size = new System.Drawing.Size(134, 21);
            this.comboBoxFileName2.TabIndex = 35;
            this.comboBoxFileName2.SelectedIndexChanged += new System.EventHandler(this.comboBoxFileName2_SelectedIndexChanged);
            // 
            // buttonParse
            // 
            this.buttonParse.Location = new System.Drawing.Point(89, 104);
            this.buttonParse.Name = "buttonParse";
            this.buttonParse.Size = new System.Drawing.Size(93, 27);
            this.buttonParse.TabIndex = 34;
            this.buttonParse.Text = "Run Parser";
            this.buttonParse.UseVisualStyleBackColor = true;
            this.buttonParse.Click += new System.EventHandler(this.buttonParse_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(22, 81);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 32;
            this.labelName.Text = "Name:";
            // 
            // labelFile2
            // 
            this.labelFile2.AutoSize = true;
            this.labelFile2.Location = new System.Drawing.Point(22, 27);
            this.labelFile2.Name = "labelFile2";
            this.labelFile2.Size = new System.Drawing.Size(26, 13);
            this.labelFile2.TabIndex = 30;
            this.labelFile2.Text = "File:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(89, 78);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(134, 20);
            this.textBoxName.TabIndex = 29;
            // 
            // labelAttribute
            // 
            this.labelAttribute.AutoSize = true;
            this.labelAttribute.Location = new System.Drawing.Point(22, 54);
            this.labelAttribute.Name = "labelAttribute";
            this.labelAttribute.Size = new System.Drawing.Size(49, 13);
            this.labelAttribute.TabIndex = 37;
            this.labelAttribute.Text = "Attribute:";
            // 
            // comboBoxAttributes
            // 
            this.comboBoxAttributes.FormattingEnabled = true;
            this.comboBoxAttributes.Location = new System.Drawing.Point(89, 51);
            this.comboBoxAttributes.Name = "comboBoxAttributes";
            this.comboBoxAttributes.Size = new System.Drawing.Size(134, 21);
            this.comboBoxAttributes.TabIndex = 38;
            // 
            // panelSearchPanel
            // 
            this.panelSearchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearchPanel.Controls.Add(this.labelSearch);
            this.panelSearchPanel.Controls.Add(this.comboBoxAttributes);
            this.panelSearchPanel.Controls.Add(this.textBoxName);
            this.panelSearchPanel.Controls.Add(this.labelAttribute);
            this.panelSearchPanel.Controls.Add(this.labelFile2);
            this.panelSearchPanel.Controls.Add(this.comboBoxFileName2);
            this.panelSearchPanel.Controls.Add(this.labelName);
            this.panelSearchPanel.Controls.Add(this.buttonParse);
            this.panelSearchPanel.Location = new System.Drawing.Point(12, 157);
            this.panelSearchPanel.Name = "panelSearchPanel";
            this.panelSearchPanel.Size = new System.Drawing.Size(251, 144);
            this.panelSearchPanel.TabIndex = 39;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(3, 0);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(44, 13);
            this.labelSearch.TabIndex = 39;
            this.labelSearch.Text = "Search:";
            // 
            // panelGenerator
            // 
            this.panelGenerator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGenerator.Controls.Add(this.labelNumOfGens);
            this.panelGenerator.Controls.Add(this.buttonRedo);
            this.panelGenerator.Controls.Add(this.labelGenerator);
            this.panelGenerator.Controls.Add(this.numericUpDownNumOfGenerations);
            this.panelGenerator.Controls.Add(this.comboBoxFileName1);
            this.panelGenerator.Controls.Add(this.buttonGenerate);
            this.panelGenerator.Controls.Add(this.labelFile1);
            this.panelGenerator.Location = new System.Drawing.Point(12, 12);
            this.panelGenerator.Name = "panelGenerator";
            this.panelGenerator.Size = new System.Drawing.Size(251, 139);
            this.panelGenerator.TabIndex = 40;
            // 
            // labelNumOfGens
            // 
            this.labelNumOfGens.AutoSize = true;
            this.labelNumOfGens.Location = new System.Drawing.Point(11, 47);
            this.labelNumOfGens.Name = "labelNumOfGens";
            this.labelNumOfGens.Size = new System.Drawing.Size(60, 13);
            this.labelNumOfGens.TabIndex = 30;
            this.labelNumOfGens.Text = "How many:";
            // 
            // buttonRedo
            // 
            this.buttonRedo.Location = new System.Drawing.Point(75, 104);
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Size = new System.Drawing.Size(85, 27);
            this.buttonRedo.TabIndex = 29;
            this.buttonRedo.Text = "Redo";
            this.buttonRedo.UseVisualStyleBackColor = true;
            this.buttonRedo.Click += new System.EventHandler(this.buttonRedo_Click);
            // 
            // labelGenerator
            // 
            this.labelGenerator.AutoSize = true;
            this.labelGenerator.Location = new System.Drawing.Point(3, 0);
            this.labelGenerator.Name = "labelGenerator";
            this.labelGenerator.Size = new System.Drawing.Size(57, 13);
            this.labelGenerator.TabIndex = 28;
            this.labelGenerator.Text = "Generator:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(142, 308);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(121, 28);
            this.buttonSave.TabIndex = 31;
            this.buttonSave.Text = "Save Output";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(142, 342);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(121, 28);
            this.buttonClear.TabIndex = 41;
            this.buttonClear.Text = "Clear Output";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // panelEncounterGen
            // 
            this.panelEncounterGen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEncounterGen.Controls.Add(this.buttonRedoEncounter);
            this.panelEncounterGen.Controls.Add(this.buttonGenEncounter);
            this.panelEncounterGen.Controls.Add(this.labelDifficulty);
            this.panelEncounterGen.Controls.Add(this.labelNumOfPlayers);
            this.panelEncounterGen.Controls.Add(this.numericUpDownDifficulty);
            this.panelEncounterGen.Controls.Add(this.numericUpDownNumOfPlayers);
            this.panelEncounterGen.Controls.Add(this.labelRandEncounterGen);
            this.panelEncounterGen.Location = new System.Drawing.Point(270, 13);
            this.panelEncounterGen.Name = "panelEncounterGen";
            this.panelEncounterGen.Size = new System.Drawing.Size(267, 98);
            this.panelEncounterGen.TabIndex = 42;
            // 
            // buttonRedoEncounter
            // 
            this.buttonRedoEncounter.Location = new System.Drawing.Point(161, 55);
            this.buttonRedoEncounter.Name = "buttonRedoEncounter";
            this.buttonRedoEncounter.Size = new System.Drawing.Size(85, 27);
            this.buttonRedoEncounter.TabIndex = 36;
            this.buttonRedoEncounter.Text = "Redo";
            this.buttonRedoEncounter.UseVisualStyleBackColor = true;
            this.buttonRedoEncounter.Click += new System.EventHandler(this.buttonRedoEncounter_Click);
            // 
            // buttonGenEncounter
            // 
            this.buttonGenEncounter.Location = new System.Drawing.Point(161, 22);
            this.buttonGenEncounter.Name = "buttonGenEncounter";
            this.buttonGenEncounter.Size = new System.Drawing.Size(85, 27);
            this.buttonGenEncounter.TabIndex = 35;
            this.buttonGenEncounter.Text = "Generate";
            this.buttonGenEncounter.UseVisualStyleBackColor = true;
            this.buttonGenEncounter.Click += new System.EventHandler(this.buttonGenEncounter_Click);
            // 
            // labelDifficulty
            // 
            this.labelDifficulty.AutoSize = true;
            this.labelDifficulty.Location = new System.Drawing.Point(16, 50);
            this.labelDifficulty.Name = "labelDifficulty";
            this.labelDifficulty.Size = new System.Drawing.Size(80, 13);
            this.labelDifficulty.TabIndex = 32;
            this.labelDifficulty.Text = "Difficulty (1 - 9):";
            // 
            // labelNumOfPlayers
            // 
            this.labelNumOfPlayers.AutoSize = true;
            this.labelNumOfPlayers.Location = new System.Drawing.Point(16, 24);
            this.labelNumOfPlayers.Name = "labelNumOfPlayers";
            this.labelNumOfPlayers.Size = new System.Drawing.Size(96, 13);
            this.labelNumOfPlayers.TabIndex = 31;
            this.labelNumOfPlayers.Text = "Number of Players:";
            // 
            // numericUpDownDifficulty
            // 
            this.numericUpDownDifficulty.Location = new System.Drawing.Point(118, 48);
            this.numericUpDownDifficulty.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownDifficulty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDifficulty.Name = "numericUpDownDifficulty";
            this.numericUpDownDifficulty.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownDifficulty.TabIndex = 30;
            this.numericUpDownDifficulty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownNumOfPlayers
            // 
            this.numericUpDownNumOfPlayers.Location = new System.Drawing.Point(118, 22);
            this.numericUpDownNumOfPlayers.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownNumOfPlayers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumOfPlayers.Name = "numericUpDownNumOfPlayers";
            this.numericUpDownNumOfPlayers.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownNumOfPlayers.TabIndex = 29;
            this.numericUpDownNumOfPlayers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelRandEncounterGen
            // 
            this.labelRandEncounterGen.AutoSize = true;
            this.labelRandEncounterGen.Location = new System.Drawing.Point(3, 0);
            this.labelRandEncounterGen.Name = "labelRandEncounterGen";
            this.labelRandEncounterGen.Size = new System.Drawing.Size(152, 13);
            this.labelRandEncounterGen.TabIndex = 28;
            this.labelRandEncounterGen.Text = "Random Encounter Generator:";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(12, 308);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(121, 28);
            this.buttonOpen.TabIndex = 43;
            this.buttonOpen.Text = "Open Output";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // RandomGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 380);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.panelEncounterGen);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.panelGenerator);
            this.Controls.Add(this.panelSearchPanel);
            this.Controls.Add(this.richTextBoxDisplay);
            this.Name = "RandomGenerator";
            this.Text = "Random Generator";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumOfGenerations)).EndInit();
            this.panelSearchPanel.ResumeLayout(false);
            this.panelSearchPanel.PerformLayout();
            this.panelGenerator.ResumeLayout(false);
            this.panelGenerator.PerformLayout();
            this.panelEncounterGen.ResumeLayout(false);
            this.panelEncounterGen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDifficulty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumOfPlayers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxFileName1;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.RichTextBox richTextBoxDisplay;
        private System.Windows.Forms.Label labelFile1;
        private System.Windows.Forms.NumericUpDown numericUpDownNumOfGenerations;
        private System.Windows.Forms.ComboBox comboBoxFileName2;
        private System.Windows.Forms.Button buttonParse;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelFile2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelAttribute;
        private System.Windows.Forms.ComboBox comboBoxAttributes;
        private System.Windows.Forms.Panel panelSearchPanel;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Panel panelGenerator;
        private System.Windows.Forms.Label labelGenerator;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelNumOfGens;
        private System.Windows.Forms.Button buttonRedo;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panelEncounterGen;
        private System.Windows.Forms.Label labelRandEncounterGen;
        private System.Windows.Forms.Button buttonRedoEncounter;
        private System.Windows.Forms.Button buttonGenEncounter;
        private System.Windows.Forms.Label labelDifficulty;
        private System.Windows.Forms.Label labelNumOfPlayers;
        private System.Windows.Forms.NumericUpDown numericUpDownDifficulty;
        private System.Windows.Forms.NumericUpDown numericUpDownNumOfPlayers;
        private System.Windows.Forms.Button buttonOpen;
    }
}