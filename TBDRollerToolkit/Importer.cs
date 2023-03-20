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

namespace TBDRollerToolkit
{
    public partial class Importer : Form
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
        private static int locPort;
        private static bool sendingData = false;

        public Importer()
        {
            InitializeComponent();
        }

        private void Importer_Load(object sender, EventArgs e)
        {
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
                locPort = Convert.ToInt32(textBoxPortNum2.Text);
                targetIpAdd = IPAddress.Parse(textBoxIPAddress1.Text);
                int port = Convert.ToInt32(textBoxPortNum1.Text);

                // Set up Sender connection
                sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socketEndPoint = new IPEndPoint(targetIpAdd, port);

                // Starts the Listener
                client = new UdpClient(locPort);
                threadEndPoint = new IPEndPoint(IPAddress.Parse(localIpAddressFinder()), locPort);
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

        private void buttonSend_Click(object sender, EventArgs e)
        {
            List<String> resourceToBeSent = new List<String>();
            for (int i = 0; i < resources.Count; i++)
            {
                if (resources[i][0].Contains(comboBoxResources.Text))
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
                if ((!(resourceInfo[i].Equals(""))) && (resourceInfo[i].Substring(0, 4).Equals("name")))
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
