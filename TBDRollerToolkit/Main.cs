using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TBDRoller;

namespace TBDRollerToolkit
{
    public partial class TBDRoller : Form
    {
        //Dice Roller stuff starts here
        int dieTotal = 0;
        int lowRoll;

        bool dropLowest = false;
        bool lowDropped = false;
        bool top3 = false;
        bool drop1 = false;
        bool critConfirm = false;
        bool addMods = false;
        bool strikeMod = false;

        bool reroll1 = false;

        Random die = new Random();

        List<int> dice = new List<int>();
        List<int> keepList = new List<int>();
        List<int> sortDice = new List<int>();

        static Hashtable legend = new Hashtable();
        //Dice Roller stuff ends here

        //Item Generator stuff starts here
        private static XmlDocument doc = new XmlDocument();
        private static String lastGeneration;
        //Item Generator stuff end here
        

        //G.U.I. stuff starts here
        public TBDRoller()
        {
            InitializeComponent();
            panelHome.Visible = true;
            panelRoller.Visible = false;
            panelItem.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panelRoller.Visible = false;
            panelItem.Visible = false;
        }

        private void diceRollerImg_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            panelRoller.Visible = true;
            panelItem.Visible = false;
        }

        private void ButtonRoller_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            panelRoller.Visible = true;
            panelItem.Visible = false;
        }

        private void ButtonItem_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            panelRoller.Visible = false;
            panelItem.Visible = true;
        }
        private void ButtonMap_Click(object sender, EventArgs e)
        {
            MapGenerator f2 = new MapGenerator();
            f2.ShowDialog();
        }

        private void pa_Click(object sender, EventArgs e)
        {
            Importer f3 = new Importer();
            f3.ShowDialog();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //G.U.I. stuff ends here


        //Dice Roller stuff starts here
        private void rollButton_Click(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;

            RollOutput.Text = "";
            RollOutput.SelectionColor = Color.Black;

            RollTotal.Text = "";
            dieTotal = 0;

            DiceCheck();

            RollTotal.Text = dieTotal.ToString();
        }

        private void DiceCheck()
        {
            if (!d4Input.Text.Equals(null) && int.TryParse(d4Input.Text, out int d4) == true && d4 > 0)
            {
                RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
                RollOutput.AppendText("d4: ");

                RollDice(d4, 4);
            }
            if (!d6Input.Text.Equals(null) && int.TryParse(d6Input.Text, out int d6) == true && d6 > 0)
            {
                RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
                RollOutput.AppendText("d6: ");

                RollDice(d6, 6);
            }
            if (!d8Input.Text.Equals(null) && int.TryParse(d8Input.Text, out int d8) == true && d8 > 0)
            {
                RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
                RollOutput.AppendText("d8: ");

                RollDice(d8, 8);
            }
            if (!d10Input.Text.Equals(null) && int.TryParse(d10Input.Text, out int d10) == true && d10 > 0)
            {
                RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
                RollOutput.AppendText("d10: ");

                RollDice(d10, 10);
            }
            if (!d12Input.Text.Equals(null) && int.TryParse(d12Input.Text, out int d12) == true && d12 > 0)
            {
                RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
                RollOutput.AppendText("d12: ");

                RollDice(d12, 12);
            }
            if (!d20Input.Text.Equals(null) && int.TryParse(d20Input.Text, out int d20) == true && d20 > 0)
            {
                RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
                RollOutput.AppendText("d20: ");

                RollDice(d20, 20);
            }
            if (!d100Input.Text.Equals(null) && int.TryParse(d100Input.Text, out int d100) == true && d100 > 0)
            {
                RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
                RollOutput.AppendText("d100: ");

                RollDice(d100, 100);
            }
            if (!dXInput.Text.Equals(null) && int.TryParse(dXInput.Text, out int dX) == true && !dXDie.Text.Equals(null) && int.TryParse(dXDie.Text, out int dXD) == true && dX > 0)
            {
                RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
                RollOutput.AppendText("d" + dXDie.Text + ": ");

                RollDice(dX, dXD);
            }
        }

        private void RollDice(int numRolls, int dSides)
        {
            RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Regular);

            for (int i = 0; i < numRolls; i++)

            {
                if (reroll1 == true)
                {
                    dice.Add(die.Next(1, (dSides + 1)));

                    while (dice[i] == 1)
                    {
                        dice[i] = die.Next(1, (dSides + 1));
                    }
                }
                else
                {
                    dice.Add(die.Next(1, (dSides + 1)));
                }

                dieTotal = dieTotal + dice[i];

                if (i == 0)
                {
                    lowRoll = dice[i];
                }
                else
                {
                    if (dice[i] < lowRoll)
                    {
                        lowRoll = dice[i];
                    }
                }
            }

            for (int i = 0; i < numRolls; i++)
            {
                if (dice[i] == 1)
                {
                    RollOutput.SelectionColor = Color.Red;
                    RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Bold);
                }
                else if (dice[i] == dSides)
                {
                    RollOutput.SelectionColor = Color.Green;
                    RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Bold);
                }

                if (dropLowest == true && dice[i] == lowRoll && lowDropped == false)
                {
                    RollOutput.SelectionColor = Color.Gray;
                    RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Strikeout);

                    dieTotal = dieTotal - dice[i];

                    lowDropped = true;
                }

                if (drop1 == true && dice[i] == 1)
                {
                    RollOutput.SelectionColor = Color.Gray;
                    RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Strikeout);

                    dieTotal = dieTotal - dice[i];
                }

                RollOutput.AppendText(dice[i].ToString());

                RollOutput.AppendText("  ");

                if (addMods == true)
                {
                    if (drop1 == true && dice[i] != 1)
                    {
                        strikeMod = true;
                        Mods(dSides);
                        RollOutput.AppendText("     ");
                    }
                    else if (dropLowest == true && dice[i] != lowRoll)
                    {
                        strikeMod = true;
                        Mods(dSides);
                        RollOutput.AppendText("     ");
                    }
                    else
                    {
                        Mods(dSides);
                        RollOutput.AppendText("     ");
                    }
                }

                if (critConfirm == true && dice[i] == dSides)
                {
                    ConfirmCrit(dSides);
                }

                RollOutput.SelectionColor = Color.Black;
                RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Regular);
            }

            if (addMods == false)
            {
                Mods(dSides);
            }

            RollOutput.AppendText("\n");
            lowDropped = false;
            dice.Clear();
        }

        private void Mods(int dSides)
        {
            RollOutput.SelectionColor = Color.DarkGoldenrod;
            RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Regular);

            if (dSides == 4)
            {
                if (!d4Mod.Text.Equals(null) && int.TryParse(d4Mod.Text, out int d4) == true)
                {
                    if(strikeMod == true)
                    {
                        strikeMod = false;
                    }
                    else if (d4 > 0)
                    {
                        RollOutput.AppendText("+ " + d4);
                        dieTotal = dieTotal + d4;
                    }
                    else if (d4 < 0)
                    {
                        RollOutput.AppendText("- " + Math.Abs(d4));
                        dieTotal = dieTotal + d4;
                    }
                }
            }
            else if (dSides == 6)
            {
                if (!d6Mod.Text.Equals(null) && int.TryParse(d6Mod.Text, out int d6) == true)
                {
                    if (strikeMod == true)
                    {
                        strikeMod = false;
                    }
                    else if (d6 > 0)
                    {
                        RollOutput.AppendText("+ " + d6);
                        dieTotal = dieTotal + d6;
                    }
                    else if (d6 < 0)
                    {
                        RollOutput.AppendText("- " + Math.Abs(d6));
                        dieTotal = dieTotal + d6;
                    }
                }
            }
            else if (dSides == 8)
            {
                if (!d8Mod.Text.Equals(null) && int.TryParse(d8Mod.Text, out int d8) == true)
                {
                    if (strikeMod == true)
                    {
                        strikeMod = false;
                    }
                    else if (d8 > 0)
                    {
                        RollOutput.AppendText("+ " + d8);
                        dieTotal = dieTotal + d8;
                    }
                    else if (d8 < 0)
                    {
                        RollOutput.AppendText("- " + Math.Abs(d8));
                        dieTotal = dieTotal + d8;
                    }
                }
            }
            else if (dSides == 10)
            {
                if (!d10Mod.Text.Equals(null) && int.TryParse(d10Mod.Text, out int d10) == true)
                {
                    if (strikeMod == true)
                    {
                        strikeMod = false;
                    }
                    else if (d10 > 0)
                    {
                        RollOutput.AppendText("+ " + d10);
                        dieTotal = dieTotal + d10;
                    }
                    else if (d10 < 0)
                    {
                        RollOutput.AppendText("- " + Math.Abs(d10));
                        dieTotal = dieTotal + d10;
                    }
                }
            }
            else if (dSides == 12)
            {
                if (!d12Mod.Text.Equals(null) && int.TryParse(d12Mod.Text, out int d12) == true)
                {
                    if (strikeMod == true)
                    {
                        strikeMod = false;
                    }
                    else if (d12 > 0)
                    {
                        RollOutput.AppendText("+ " + d12);
                        dieTotal = dieTotal + d12;
                    }
                    else if (d12 < 0)
                    {
                        RollOutput.AppendText("- " + Math.Abs(d12));
                        dieTotal = dieTotal + d12;
                    }
                }
            }
            else if (dSides == 20)
            {
                if (!d20Mod.Text.Equals(null) && int.TryParse(d20Mod.Text, out int d20) == true)
                {
                    if (strikeMod == true)
                    {
                        strikeMod = false;
                    }
                    else if (d20 > 0)
                    {
                        RollOutput.AppendText("+ " + d20);
                        dieTotal = dieTotal + d20;
                    }
                    else if (d20 < 0)
                    {
                        RollOutput.AppendText("- " + Math.Abs(d20));
                        dieTotal = dieTotal + d20;
                    }
                }
            }
            else if (dSides == 100)
            {
                if (!d100Mod.Text.Equals(null) && int.TryParse(d100Mod.Text, out int d100) == true)
                {
                    if (strikeMod == true)
                    {
                        strikeMod = false;
                    }
                    else if (d100 > 0)
                    {
                        RollOutput.AppendText("+ " + d100);
                        dieTotal = dieTotal + d100;
                    }
                    else if (d100 < 0)
                    {
                        RollOutput.AppendText("- " + Math.Abs(d100));
                        dieTotal = dieTotal + d100;
                    }
                }
            }
            else
            {
                if (!dXMod.Text.Equals(null) && int.TryParse(dXMod.Text, out int dX) == true)
                {
                    if (strikeMod == true)
                    {
                        strikeMod = false;
                    }
                    else if (dX > 0)
                    {
                        RollOutput.AppendText("+ " + dX);
                        dieTotal = dieTotal + dX;
                    }
                    else if (dX < 0)
                    {
                        RollOutput.AppendText("- " + Math.Abs(dX));
                        dieTotal = dieTotal + dX;
                    }
                }
            }
        }

        private void ConfirmCrit(int sides)
        {
            RollOutput.SelectionColor = Color.DarkBlue;
            RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Bold);

            RollOutput.AppendText("(" + die.Next(1, sides + 1) + ")  ");
        }

        private void dropLowestCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            if (dropLowest == false)
            {
                dropLowest = true;
            }
            else
            {
                dropLowest = false;
            }
        }

        private void drop1sCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            if (drop1 == false)
            {
                drop1 = true;
            }
            else
            {
                drop1 = false;
            }
        }

        private void reroll1sCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            if (reroll1 == false)
            {
                reroll1 = true;
            }
            else
            {
                reroll1 = false;
            }
        }

        private void addModsCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            if (addMods == false)
            {
                addMods = true;
            }
            else
            {
                addMods = false;
            }
        }

        private void critConfirmCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            if (critConfirm == false)
            {
                critConfirm = true;
            }
            else
            {
                critConfirm = false;
            }
        }
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Help f4 = new Help();
            f4.ShowDialog();
        }
        //Dice Roller stuff ends here

        //Item Generator Stuff starts here
        private void buttonParse_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (XmlNode node1 in doc.DocumentElement.ChildNodes)
                {
                    if ((node1.FirstChild.Name.Equals(comboBoxAttributes.Text)) && (node1.FirstChild.InnerText.ToLower().Contains(textBoxName.Text.ToLower())))
                    {
                        richTextBoxDisplay.Text += nodeInfoPrinter(node1);
                    }
                    else
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
            doc.Load(comboBoxFileName1.Text.Replace(' ', '_') + ".xml");
        }

        private void comboBoxFileName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            doc.Load(comboBoxFileName2.Text.Replace(' ', '_') + ".xml");
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
            doc.Load("Monster.xml");
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

            doc2.Load(fileName + ".xml");

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
            int maxNumOfMonsters = 0;

            if (difficulty >= 8)
            {
                maxNumOfMonsters = 50;
            }
            else if (difficulty >= 7)
            {
                maxNumOfMonsters = 40;
            }
            else if (difficulty >= 6)
            {
                maxNumOfMonsters = 30;
            }
            else if (difficulty >= 4)
            {
                maxNumOfMonsters = 15;
            }
            else if (difficulty >= 2)
            {
                maxNumOfMonsters = 5;
            }
            else
            {
                maxNumOfMonsters = 1;
            }

            if (numOfPlayers > 1)
            {
                maxNumOfMonsters = Convert.ToInt32(Math.Round(maxNumOfMonsters * ((double)1 + (numOfPlayers * ((double)1 / 4)))));
            }

            if (maxNumOfMonsters < 1)
            {
                maxNumOfMonsters = 1;
            }

            return maxNumOfMonsters;
        }

        private static int maxDifficulty(int difficulty, int numOfGenerations, int maxNumOfGenerations, int numOfPlayers)
        {
            int maxDifficulty = difficulty;

            if (((double)numOfGenerations / maxNumOfGenerations) >= 0.8)
            {
                maxDifficulty = Convert.ToInt32(Math.Round((double)maxDifficulty * 0.2));
            }
            else if (((double)numOfGenerations / maxNumOfGenerations) >= 0.6)
            {
                maxDifficulty = Convert.ToInt32(Math.Round((double)maxDifficulty * 0.4));
            }
            else if (((double)numOfGenerations / maxNumOfGenerations) >= 0.4)
            {
                maxDifficulty = Convert.ToInt32(Math.Round((double)maxDifficulty * 0.6));
            }
            else if (((double)numOfGenerations / maxNumOfGenerations) >= 0.2)
            {
                maxDifficulty = Convert.ToInt32(Math.Round((double)maxDifficulty * 0.8));
            }

            if (numOfPlayers > 1)
            {
                maxDifficulty = Convert.ToInt32(Math.Round(maxDifficulty * ((double)1 + (numOfPlayers * ((double)1 / 4)))));
            }

            if (maxDifficulty > 9)
            {
                maxDifficulty = 9;
            }
            else if (maxDifficulty < 1)
            {
                maxDifficulty = 1;
            }

            return maxDifficulty;
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





        //Item Generator stuff ends here

    }
}



        


