using System;
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

namespace ImporterAndExporter
{
    public partial class ImporterExporter : Form
    {
        private static List<List<String>> resources = new List<List<String>>();

        private static Thread listener;
        private static Socket sendSocket;
        private static IPAddress targetIpAdd;
        private static IPEndPoint socketEndPoint;
        private static UdpClient client;
        private static IPEndPoint threadEndPoint;
        private static string dataToSend;
        private static string receivedData;
        private static byte[] receivedBytes;
        private static int portNum = 12000;
        private static bool sendingData = false;

        public ImporterExporter()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gatherResources();
            textBoxIPAddress2.Text = localIpAddressFinder();
            textBoxStatus.Text = "Not Connected";
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Find all of the resources
                gatherResources();

                // Gather information
                targetIpAdd = IPAddress.Parse(textBoxIPAddress1.Text);
                int port = Convert.ToInt32(portNum);

                // Set up Sender connection
                sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socketEndPoint = new IPEndPoint(targetIpAdd, port);

                // Starts the Listener
                client = new UdpClient(portNum);
                threadEndPoint = new IPEndPoint(IPAddress.Parse(localIpAddressFinder()), portNum);
                listener = new Thread(receiver);
                sendingData = true;
                listener.Start();

                textBoxStatus.Text = "Connected";
                textBoxDataStatus.Text = "No Resources Received/Sent";
            }
            catch (Exception failedConnection)
            {
                textBoxStatus.Text = "Failed";
                textBoxDataStatus.Text = "";

                MessageBox.Show("ERROR: Connection Failed.\r\n\r\nCheck your inputs and " 
                    + "internet connection, and then, try again.");
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Stops the listener
                sendingData = false;
                client.Close();
                client = null;
                threadEndPoint = null;

                // Closes out and terminates the socket
                sendSocket.Close();
                sendSocket = null;
                socketEndPoint = null;
                saveResources();

                // Notify the user
                textBoxStatus.Text = "Disconnected";
                textBoxDataStatus.Text = "";
            }
            catch
            {
                MessageBox.Show("ERROR: There is no connection to terminate.");
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Solutions:\r\n" 
                + "- Can't connect:\r\n"
                + "\t- Make sure you have a workable internet connection.\r\n"
                + "\t- Try changing the port number. The port number selected may\r\n"
                + "\t  already be in use by another program. NOTE: If this works,\r\n"
                + "\t  run task manager and make sure that only one\r\n"
                + "\t  XmlImporterExporter is running.\r\n"
                + "- Connected but not receiving resources:\r\n"
                + "\t- Make sure the port number utilized by both you and your\r\n"
                + "\t  fellow player is the same. If not, your machine might be\r\n"
                + "\t  recieving information from them, but the application\r\n"
                + "\t  might not.\r\n");
        }

        private void buttonChangePort_Click(object sender, EventArgs e)
        {
            if (labelPortNum.Visible == false)
            {
                labelPortNum.Visible = true;
                labelTip.Visible = true;

                numericUpDownPort.Value = portNum;
                numericUpDownPort.Visible = true;
            }
            else
            {
                labelPortNum.Visible = false;
                numericUpDownPort.Visible = false;
                labelTip.Visible = false;

                portNum = Convert.ToInt32(numericUpDownPort.Value);
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            List<String> resourceToBeSent = new List<String>();
            for (int i = 0; i < resources.Count; i++)
            {
                if (resources[i][0].Substring(6).Equals(comboBoxResources.Text))
                {
                    resourceToBeSent = resources[i];
                }
            }

            dataToSend = "";

            for (int i = 0; i < resourceToBeSent.Count; i++)
            {
                dataToSend += resourceToBeSent[i] + " ";
            }
            
            dataSender();
        }

        private void gatherResources()
        {
            comboBoxResources.Items.Clear();
            resources.Clear();

            StreamReader sr = new StreamReader("resources.txt");
            List<String> resourceInfo = new List<String>();
            
            while (!(sr.EndOfStream))
            {
                resourceInfo.Add(sr.ReadLine());
            }

            sr.Close();
            
            int i = 0;
            int j = -1;
            while (i < resourceInfo.Count)
            {
                if ((!(resourceInfo[i].Equals(""))) && (resourceInfo[i].Substring(0, 4).Equals("Name")))
                {
                    resources.Add(new List<string>());
                    j++;

                    resources[j].Add(resourceInfo[i]);
                }
                else
                {
                    resources[j].Add(resourceInfo[i]);
                }

                i++;
            }

            i = 0;
            while (i < resources.Count)
            {
                comboBoxResources.Items.Add(resources[i].ElementAt(0).Substring(6));
                i++;
            }
        }

        private void receiver()
        {
            try
            {
                while (sendingData)
                {
                    receivedBytes = client.Receive(ref threadEndPoint);
                    receivedData = Encoding.ASCII.GetString(receivedBytes, 0, receivedBytes.Length);

                    if (!(receivedData.Equals("")))
                    {
                        resources.Add(dataParserAndSplitter(receivedData));
                        
                        saveResources();
                        gatherResources();
                        textBoxDataStatus.Text = "Resources Received";
                    }
                }
            }
            catch
            {
            }
        }

        private void dataSender()
        {
            byte[] sendBuffer = Encoding.ASCII.GetBytes(dataToSend);
            try
            {
                sendSocket.SendTo(sendBuffer, socketEndPoint);
                
                textBoxDataStatus.Text = "Resources Sent";
            }
            catch
            {
            }
        }

        private static String localIpAddressFinder()
        {
            string myIpAddress = "";

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            for (int i = 0; i < localIP.Length; i++)
            {
                if (localIP[i].AddressFamily.Equals(AddressFamily.InterNetwork))
                {
                    myIpAddress = localIP[i].ToString();
                }
            }

            return myIpAddress;
        }

        private static List<String> dataParserAndSplitter(string dataReceived)
        {
            List<String> receivedResource = new List<String>();
            string[] dataSplitUp = dataReceived.Split(' ');

            int i = 0;
            int j = -1;
            while (i < dataSplitUp.Length)
            {
                if ((!(dataSplitUp[i].Equals(""))) && (dataSplitUp[i].Contains(":")))
                {
                    j++;
                    receivedResource.Add(dataSplitUp[i]);
                }
                else if ((dataSplitUp[i].Equals("")) && (i == (dataSplitUp.Length - 1)))
                {
                    j++;
                    receivedResource.Add(dataSplitUp[i]);
                }
                else
                {
                    receivedResource[j] += " " + dataSplitUp[i];
                }

                i++;
            }

            return receivedResource;
        }

        private void saveResources()
        {
            StreamWriter sw = new StreamWriter("resources.txt");

            for (int i = 0; i < resources.Count; i++)
            {
                for (int j = 0; j < resources[i].Count; j++)
                {
                    sw.WriteLine(resources[i].ElementAt(j));
                }
            }

            sw.Close();
        }
    }
}

/*
 * Sources:
 * 1. The code for finding the system's IP address in the localIpAddressFinder() method is inspired by code written 
 *      by code factory 2016 on 1/22/2017. The code was published in a video on Youtube at the link below:
 *      https://www.youtube.com/watch?v=LdkNMv7tFgs
 */
