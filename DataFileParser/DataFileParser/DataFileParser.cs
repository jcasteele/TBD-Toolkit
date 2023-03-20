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
    public partial class DataFileParser : Form
    {
        private static XmlDocument doc = new XmlDocument();

        public DataFileParser()
        {
            InitializeComponent();
        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            richTextBoxDisplay.Text = "";
            try
            {
                if ((numericUpDownIdNum.Value > 0) && (textBoxName.Text.Equals("")))
                {
                    XmlNode node = doc.DocumentElement.ChildNodes
                        .Item(Convert.ToInt32(numericUpDownIdNum.Value) - 1);

                    richTextBoxDisplay.Text += nodeInfoPrinter(node);
                }
                else
                {
                    foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                    {
                        if (node.FirstChild.InnerText.Contains(textBoxName.Text))
                        {
                            richTextBoxDisplay.Text += nodeInfoPrinter(node);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBoxDisplay.Text += "Invalid Search Item. Check your inputs and try again.\n\n";
            }
        }

        private void comboBoxFileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            doc.Load(comboBoxFileName.Text.ToLower() + ".xml");

            int nodeCount = 0;
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                nodeCount++;
            }

            numericUpDownIdNum.Maximum = nodeCount;
        }

        private static String returnValueName(XmlAttributeCollection attributes, string idNum)
        {
            XmlDocument doc2 = new XmlDocument();
            String fileName = "";
            String valueName = "";

            foreach (XmlAttribute attribute in attributes)
            {
                if (attribute.Value.Equals("scale_level") || attribute.Value.Equals("armor_type") ||
                    attribute.Value.Equals("armor_material") || attribute.Value.Equals("item_type") ||
                    attribute.Value.Equals("monster_type") || attribute.Value.Equals("profession") ||
                    attribute.Value.Equals("weapon_type"))
                {
                    fileName = attribute.Value;
                }
            }

            if (fileName.Equals("scale_level"))
            {
                fileName = "scale";
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
                if (attribute.Value.Equals("scale_level") || attribute.Value.Equals("armor_type") || 
                    attribute.Value.Equals("armor_material") || attribute.Value.Equals("item_type") || 
                    attribute.Value.Equals("monster_type") || attribute.Value.Equals("profession") || 
                    attribute.Value.Equals("weapon_type"))
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
    }
}