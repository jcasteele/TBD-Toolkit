using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RandomGenerator
{
    public partial class RandomGenerator : Form
    {
        private static XmlDocument doc = new XmlDocument();
        private static String lastGeneration;

        public RandomGenerator()
        {
            InitializeComponent();
        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (XmlNode node1 in doc.DocumentElement.ChildNodes)
                {
                    foreach (XmlNode node2 in node1.ChildNodes)
                    {
                        if ((node2.Name.Equals(comboBoxAttributes.Text)) && (hasValueName(node2.Attributes)))
                        {
                            if (returnValueName(node2.Attributes, node2.InnerText).ToLower().Contains(textBoxName.Text.ToLower()))
                            {
                                richTextBoxDisplay.Text += nodeInfoPrinter(node1);
                            }
                        }
                        else if ((node2.Name.Equals(comboBoxAttributes.Text)) && (node2.InnerText.ToLower().Contains(textBoxName.Text.ToLower())))
                        {
                            richTextBoxDisplay.Text += nodeInfoPrinter(node1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBoxDisplay.Text += "Invalid Search Item. Check your inputs and try again.\n\n";
            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                randomGenerator();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Please select a File from which"
                    + "\r\nto generate entries.");
            }
        }

        private void buttonRedo_Click(object sender, EventArgs e)
        {
            try
            {
                int originalLength = richTextBoxDisplay.Text.Length - lastGeneration.Length;
                richTextBoxDisplay.Text = richTextBoxDisplay.Text.Substring(0, originalLength);

                randomGenerator();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Please select a File from which"
                    + "\r\nto generate entries.");
            }
        }

        private void buttonGenEncounter_Click(object sender, EventArgs e)
        {
            encounterGenerator();
        }

        private void buttonRedoEncounter_Click(object sender, EventArgs e)
        {
            int originalLength = richTextBoxDisplay.Text.Length - lastGeneration.Length;
            richTextBoxDisplay.Text = richTextBoxDisplay.Text.Substring(0, originalLength);

            encounterGenerator();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("resources.txt");

            richTextBoxDisplay.Text = "";
            while (!(sr.EndOfStream))
            {
                richTextBoxDisplay.Text += Convert.ToChar(sr.Read());
            }

            sr.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("resources.txt");

            for (int i = 0; i < richTextBoxDisplay.Text.Length; i++)
            {
                sw.Write(richTextBoxDisplay.Text[i]);
            }

            sw.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBoxDisplay.Text = "";
        }

        private void comboBoxFileName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            doc.Load("Data\\" + comboBoxFileName1.Text.Replace(' ', '_') + ".xml");
        }

        private void comboBoxFileName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            doc.Load("Data\\" + comboBoxFileName2.Text.Replace(' ', '_') + ".xml");
            comboBoxAttributes.Items.Clear();
            
            foreach (XmlNode node in doc.DocumentElement.FirstChild.ChildNodes)
            {
                comboBoxAttributes.Items.Add(node.Name);
            }
        }

        private void randomGenerator()
        {
            lastGeneration = "";
            Random randomNum = new Random();
            int numOfGenerations = Convert.ToInt32(numericUpDownNumOfGenerations.Value);

            int i = 0;
            while (i < numOfGenerations)
            {
                XmlNode node = doc.DocumentElement.ChildNodes
                    .Item(randomNum.Next() % doc.DocumentElement.ChildNodes.Count);

                richTextBoxDisplay.Text += nodeInfoPrinter(node);
                lastGeneration += nodeInfoPrinter(node);

                i++;
            }
        }

        private void encounterGenerator()
        {
            doc.Load("Data\\Monster.xml");
            lastGeneration = "";
            Random randomNum = new Random();
            int maxNumOfGenerations = maxGenerations(Convert.ToInt32(numericUpDownNumOfPlayers.Value), Convert.ToInt32(numericUpDownDifficulty.Value));
            int numOfGenerations = (randomNum.Next() % maxNumOfGenerations) + 1;
            int maxMonsterDifficulty = maxDifficulty(Convert.ToInt32(numericUpDownDifficulty.Value), numOfGenerations, maxNumOfGenerations, Convert.ToInt32(numericUpDownNumOfPlayers.Value));

            int i = 0;
            while (i < numOfGenerations)
            {
                XmlNode node = doc.DocumentElement.ChildNodes
                    .Item(randomNum.Next() % doc.DocumentElement.ChildNodes.Count);
                string monsterInfo = nodeInfoPrinter(node);

                if (acceptableMonster(monsterInfo, maxMonsterDifficulty))
                {
                    richTextBoxDisplay.Text += monsterInfo;
                    lastGeneration += monsterInfo;
                }
                else
                {
                    i--;
                }
                

                i++;
            }
        }

        private static String returnValueName(XmlAttributeCollection attributes, string idNum)
        {
            XmlDocument doc2 = new XmlDocument();
            String fileName = "";
            String valueName = "";

            foreach (XmlAttribute attribute in attributes)
            {
                if (attribute.Value.Equals("Scale_Level") || attribute.Value.Equals("Armor_Type") ||
                    attribute.Value.Equals("Armor_Material") || attribute.Value.Equals("Item_Type") ||
                    attribute.Value.Equals("Monster_Type") || attribute.Value.Equals("Profession") ||
                    attribute.Value.Equals("Weapon_Type"))
                {
                    fileName = attribute.Value;
                }
            }

            if (fileName.Equals("Scale_Level"))
            {
                fileName = "Scale";
            }

            doc2.Load("Data\\" + fileName + ".xml");

            if (!(idNum.Equals("")))
            {
                valueName = doc2.DocumentElement.ChildNodes.Item(Convert.ToInt32(idNum) - 1)
                    .FirstChild.InnerText;
            }
            else
            {
                valueName = idNum;
            }

            return valueName;
        }

        private static bool hasValueName(XmlAttributeCollection attributes)
        {
            bool hasValueName = false;

            foreach (XmlAttribute attribute in attributes)
            {
                if (attribute.Value.Equals("Scale_Level") || attribute.Value.Equals("Armor_Type") ||
                    attribute.Value.Equals("Armor_Material") || attribute.Value.Equals("Item_Type") ||
                    attribute.Value.Equals("Monster_Type") || attribute.Value.Equals("Profession") ||
                    attribute.Value.Equals("Weapon_Type"))
                {
                    hasValueName = true;
                }
            }

            return hasValueName;
        }

        private static String nodeInfoPrinter(XmlNode node)
        {
            String nodeInfo = "";

            foreach (XmlNode node1 in node.ChildNodes)
            {
                if (node1.ChildNodes.Count > 1)
                {
                    foreach (XmlNode node2 in node1.ChildNodes)
                    {
                        nodeInfo += node1.Name + ", " + node2.Name + ": ";
                        if (hasValueName(node2.Attributes))
                        {
                            nodeInfo += returnValueName(node2.Attributes, node2.InnerText) + "\n";
                        }
                        else
                        {
                            nodeInfo += node2.InnerText + "\n";
                        }
                    }
                }
                else
                {
                    nodeInfo += node1.Name + ": ";
                    if (hasValueName(node1.Attributes))
                    {
                        nodeInfo += returnValueName(node1.Attributes, node1.InnerText) + "\n";
                    }
                    else
                    {
                        nodeInfo += node1.InnerText + "\n";
                    }
                }
            }
            nodeInfo += "\n";

            return nodeInfo;
        }

        private static int maxGenerations(int numOfPlayers, int difficulty)
        {
            double x1 = Math.Pow(Convert.ToDouble(difficulty), (4.0 / 3));
            double x2 = Math.Pow(Convert.ToDouble(difficulty), (2.0 / 3));
            double maxNumOfMonsters = Math.Ceiling(x1 - x2) + 1;

            maxNumOfMonsters *= Math.Pow(((Convert.ToDouble(numOfPlayers) - 1) / 3), (2.0 / 3)) + 1;

            return Convert.ToInt32(Math.Round(maxNumOfMonsters));
        }

        private static int maxDifficulty(int difficulty, int numOfGenerations, int maxNumOfGenerations, int numOfPlayers)
        {
            double maxDifficulty = difficulty * (1 - (Convert.ToDouble(numOfGenerations) / maxNumOfGenerations));

            maxDifficulty *= Math.Pow(((Convert.ToDouble(numOfPlayers) - 1) / 3), (2.0 / 3)) + 1;

            if (maxDifficulty > 9)
            {
                maxDifficulty = 9;
            }
            else if (maxDifficulty < 1)
            {
                maxDifficulty = 1;
            }

            return Convert.ToInt32(Math.Round(maxDifficulty));
        }

        private static bool acceptableMonster(string monsterInfo, int maxDifficulty)
        {
            bool acceptable = false;
            string[] monsterInfoSplit = monsterInfo.Split(':');
            int monsterDifficulty = Convert.ToInt32(monsterInfoSplit[3][1].ToString());

            if (maxDifficulty >= monsterDifficulty)
            {
                acceptable = true;
            }

            return acceptable;
        }
    }
}
