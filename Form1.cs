using Microsoft.VisualBasic.Logging;
using System.Configuration;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System;
using System.Text;

namespace Switch_Controller
{
    public partial class Form1 : Form
    {
        private bool offline = true;
        private static Socket socket;
        //private static USBBot usb;


        private static readonly Encoding Encoder = Encoding.UTF8;
        private static byte[] Encode(string command, bool addrn = true) => Encoder.GetBytes(addrn ? command + "\r\n" : command);
        private static byte[] X() => Encode("click X");
        private static byte[] pX() => Encode("press X");
        private static byte[] rX() => Encode("release X");
        private static byte[] Y() => Encode("click Y");
        private static byte[] pY() => Encode("press Y");
        private static byte[] rY() => Encode("release Y");
        private static byte[] A() => Encode("click A");
        private static byte[] pA() => Encode("press A");
        private static byte[] rA() => Encode("release A");
        private static byte[] B() => Encode("click B");
        private static byte[] pB() => Encode("press B");
        private static byte[] rB() => Encode("release B");

        private static byte[] L() => Encode("click L");
        private static byte[] R() => Encode("click R");
        private static byte[] ZL() => Encode("click ZL");
        private static byte[] ZR() => Encode("click ZR");

        private static byte[] PLUS() => Encode("click PLUS");
        private static byte[] MINUS() => Encode("click MINUS");

        private static byte[] Home() => Encode("click HOME");
        private static byte[] Capture() => Encode("click CAPTURE");

        private static byte[] Up() => Encode("click DUP");
        private static byte[] Right() => Encode("click DRIGHT");
        private static byte[] Down() => Encode("click DDOWN");
        private static byte[] Left() => Encode("click DLEFT");

        private static byte[] LSTICK() => Encode("click LSTICK");
        private static byte[] RSTICK() => Encode("click RSTICK");


        private static byte[] pL() => Encode("press L");
        private static byte[] rL() => Encode("release L");
        private static byte[] Detach() => Encode("detachController");

        private static byte[] LstickTR() => Encode("setStick LEFT 0x7FFF 0x7FFF");
        private static byte[] LstickTL() => Encode("setStick LEFT -0x8000 0x7FFF");
        private static byte[] LstickBR() => Encode("setStick LEFT 0x7FFF -0x8000");
        private static byte[] LstickBL() => Encode("setStick LEFT -0x8000 -0x8000");
        private static byte[] LstickU() => Encode("setStick LEFT 0x0 0x7FFF");
        private static byte[] LstickL() => Encode("setStick LEFT -0x8000 0x0");
        private static byte[] LstickD() => Encode("setStick LEFT 0x0 -0x8000");
        private static byte[] LstickR() => Encode("setStick LEFT 0x7FFF 0x0");
        private static byte[] ResetLeft() => Encode("setStick LEFT 0 0");
        private static byte[] RstickU() => Encode("setStick RIGHT 0x0 0x7FFF");
        private static byte[] RstickL() => Encode("setStick RIGHT -0x8000 0x0");
        private static byte[] RstickD() => Encode("setStick RIGHT 0x0 -0x8000");
        private static byte[] RstickR() => Encode("setStick RIGHT 0x7FFF 0x0");
        private static byte[] ResetRight() => Encode("setStick RIGHT 0 0");

        public static void SendString(Socket socket, byte[] buffer, int offset = 0, int size = 0, int timeout = 100)
        {
            int startTickCount = Environment.TickCount;
            int sent = 0;  // how many bytes is already sent
            if (size == 0)
                for (int i = offset; i < buffer.Length; i++)
                    if (buffer[i] == 0xA)
                    {
                        size = i + 1 - offset;
                        break;
                    }
            if (size == 0) size = buffer.Length - offset;
            do
            {
                if (Environment.TickCount > startTickCount + timeout)
                    throw new Exception("Timeout.");
                try
                {
                    sent += socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        // socket buffer is probably full, wait and try again
                        //Thread.Sleep(10);
                    }
                    else
                        throw;  // any serious error occurr
                }
            } while (sent < size);
        }


        public Form1()
        {
            InitializeComponent();

            //load up saved ip address.  
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath.Replace(".exe", ".dll"));
            ipaddress.Text = ConfigurationManager.AppSettings["ipaddress"];


        }

        private void Connect_Click(object sender, EventArgs e)
        {

            ///MessageBox.Show("Ip Address is: "+ipaddress.Text);

            string ipPattern = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

            if (!Regex.IsMatch(ipaddress.Text, ipPattern))
            {
                MessageBox.Show("Not Valid Ip Address!");
                return;
            }

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ep = new(IPAddress.Parse(ipaddress.Text), 6000);

            if (socket.Connected == false)
            {
                new Thread(() =>
                {

                    Thread.CurrentThread.IsBackground = true;

                    IAsyncResult result = socket.BeginConnect(ep, null, null);
                    bool conSucceded = result.AsyncWaitHandle.WaitOne(3000, true);


                    if (conSucceded)
                    {
                        try
                        {
                            socket.EndConnect(result);
                        }
                        catch
                        {

                            if (MessageBox.Show("Sys-botbase not responding. Details?", "Error Code : 5318008 - Missing Sys-botbase Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                MessageBox.Show("You have successfully started a connection!\n" +
                                                    "However, Sys-botbase is not responding...\n" +
                                                    " \n" +
                                                    "1) \n" +
                                                    "Check that your Switch is running in CFW mode.\n" +
                                                    "On your Switch, go to [ System Settings ] -> [ System ]\n" +
                                                    "Under [ System Update ], check [ Current version: ] and make sure you have [ AMS ] in it.\n" +
                                                    " \n" +
                                                    "2) \n" +
                                                    "Check that you are connecting to the correct IP address.\n" +
                                                    "On your Switch, go to [ System Settings ] -> [ Internet ]\n" +
                                                    "Check the [ IP Address ] under [ Connection Status ]\n" +
                                                    " \n" +
                                                    "3) \n" +
                                                    "Sys-botbase might have crashed.\n" +
                                                    "Please try holding down the power button and restart your Switch.\n" +
                                                    " \n" +
                                                    "4) \n" +
                                                    "Check that you have the latest version of Sys-botbase installed.\n" +
                                                    "You can get the latest version at \n        https://github.com/olliz0r/sys-botbase/releases \n" +
                                                    "Double-check your installation and make sure that the folder \n [ 430000000000000B ] can be located at [ SD: \\ atmosphere \\ contents \\ ] .\n" +
                                                    " \n" +
                                                    "5) \n" +
                                                    "When your Switch is booting up, \n" +
                                                    "Check that the LED of the [🏠 Home button] on your Joy-Con is lighting up.\n" +
                                                    " \n" +
                                                    "https://github.com/MyShiLingStar/ACNHPokerCore/wiki/Connection-Troubleshooting#where-are-you-my-socket-6000"
                                                    , "Where are you, my socket 6000?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            return;
                        }

                        Invoke((MethodInvoker)delegate
                        {
                            ///IPAddressInputBackground.BackColor = Color.Green;

                            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath.Replace(".exe", ".dll"));
                            config.AppSettings.Settings["ipaddress"].Value = ipaddress.Text;
                            config.Save(ConfigurationSaveMode.Minimal);


                            MessageBox.Show("Connection Succeeded : " + ipaddress.Text);
                            ///

                            offline = false;
                            //need to connect to sysbotbase for switch control//









                        });

                        ///MyLog.LogEvent("MainForm", "Data Reading Ended");
                    }
                    else
                    {
                        socket.Close();
                        socket = null;
                        MessageBox.Show("Unable to connect to the Sys-botbase server.\n" +
                                        "Please double check your IP address and Sys-botbase installation.\n" +
                                        " \n" +
                                        "You might also need to disable your firewall or antivirus temporary to allow outgoing connection."
                                        , "Unable to establish connection!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }).Start();
            }
        }

        private void capturebutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, Capture());
        }

        private void homebutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, Home());

        }

        private void plusbutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, PLUS());
        }

        private void negbutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, MINUS());
        }

        private void Xbutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, X());
        }

        private void Ybutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, Y());
        }

        private void Abutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, A());
        }

        private void Bbutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, B());

        }

        private void UPbutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, Up());
        }
        private void DOWNbutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, Down());
        }
        private void LEFTbutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, Left());
        }

        private void RIGHTbutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, Right());
        }

        private void Lbutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, L());
        }

        private void ZLbutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, ZL());
        }

        private void Rbutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, R());
        }

        private void ZRbutton_Click(object sender, EventArgs e)
        {
            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
            SendString(socket, ZR());
        }
    }

















}
