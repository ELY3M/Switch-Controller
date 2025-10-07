using System.Configuration;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;

namespace Switch_Controller
{
    public partial class Form1 : Form
    {
        private static bool offline = true;
        private static Socket socket;

        bool L_StickUp;
        bool L_StickRight;
        bool L_StickLeft;
        bool L_StickDown;
        bool resetted = true;
        private MovingDirection currentDirection = MovingDirection.Null;


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

            if (offline)
            {
                MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                return;
            }
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

        public static void ClickA()
        {
            SendString(socket, A());
        }

        public static void PressA()
        {
            SendString(socket, pA());
        }

        public static void ReleaseA()
        {
            SendString(socket, rA());
        }

        public static void ClickB()
        {
            SendString(socket, B());
        }

        public static void PressB()
        {
            SendString(socket, pB());
        }

        public static void ReleaseB()
        {
            SendString(socket, rB());
        }

        public static void ClickX()
        {
            SendString(socket, X());
        }

        public static void PressX()
        {
            SendString(socket, pX());
        }

        public static void ReleaseX()
        {
            SendString(socket, rX());
        }

        public static void ClickY()
        {
            SendString(socket, Y());
        }

        public static void PressY()
        {
            SendString(socket, pY());
        }

        public static void ReleaseY()
        {
            SendString(socket, rY());
        }

        public static void ClickL()
        {
            SendString(socket, L());
        }
        public static void ClickR()
        {
            SendString(socket, R());
        }
        public static void ClickZL()
        {
            SendString(socket, ZL());
        }
        public static void ClickZR()
        {
            SendString(socket, ZR());
        }

        public static void ClickPLUS()
        {
            SendString(socket, PLUS());
        }
        public static void ClickMINUS()
        {
            SendString(socket, MINUS());
        }

        public static void ClickHOME()
        {
            SendString(socket, Home());
        }
        public static void ClickCAPTURE()
        {
            SendString(socket, Capture());
        }

        public static void ClickUp()
        {
            SendString(socket, Up());
        }
        public static void ClickLeft()
        {
            SendString(socket, Left());
        }
        public static void ClickDown()
        {
            SendString(socket, Down());
        }
        public static void ClickRight()
        {
            SendString(socket, Right());
        }

        public static void ClickRightStick()
        {
            SendString(socket, RSTICK());
        }
        public static void ClickLeftStick()
        {
            SendString(socket, LSTICK());
        }

        public static void PressL()
        {
            SendString(socket, pL());
        }
        public static void ReleaseL()
        {
            SendString(socket, rL());
        }

        public static void LstickTopRight()
        {
            SendString(socket, LstickTR());
        }
        public static void LstickTopLeft()
        {
            SendString(socket, LstickTL());
        }
        public static void LstickBottomRight()
        {
            SendString(socket, LstickBR());
        }
        public static void LstickBottomLeft()
        {
            SendString(socket, LstickBL());
        }

        public static void LstickUp()
        {
            SendString(socket, LstickU());
        }
        public static void LstickLeft()
        {
            SendString(socket, LstickL());
        }
        public static void LstickDown()
        {
            SendString(socket, LstickD());
        }
        public static void LstickRight()
        {
            SendString(socket, LstickR());
        }
        public static void ResetLeftStick()
        {
            SendString(socket, ResetLeft());
        }

        public static void RstickUp()
        {
            SendString(socket, RstickU());
        }
        public static void RstickLeft()
        {
            SendString(socket, RstickL());
        }
        public static void RstickDown()
        {
            SendString(socket, RstickD());
        }
        public static void RstickRight()
        {
            SendString(socket, RstickR());
        }
        public static void ResetRightStick()
        {
            SendString(socket, ResetRight());
        }

        public static void DetachController()
        {
            SendString(socket, Detach());
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

                            //start controller timer//  
                            controllertimer.Start();



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
        /*
                private void XBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    ClickX();
                }

                private void ABtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    ClickA();
                }

                private void BBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    ClickB();
                }

                private void YBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    ClickY();
                }

                private void LstickLEFTBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    //ClickLeft;
                }

                private void LstickRIGHTBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, LstickR());
                }

                private void LstickDOWNBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, LstickD());
                }

                private void LstickUPBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, LstickU());
                }

                private void LeftStickBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, LSTICK());
                }

                private void DleftBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, Left());
                }

                private void DrightBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, Right());
                }

                private void DupBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, Up());
                }

                private void DdownBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, Down());
                }

                private void ZLBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, ZL());
                }

                private void LBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, L());
                }

                private void minusBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, MINUS());
                }

                private void caputureBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, Capture());
                }

                private void RBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, R());
                }

                private void ZRBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, ZR());
                }

                private void plusBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, PLUS());
                }

                private void HomeBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, Home());
                }


                private void DetachBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, Detach());
                }

                private void RstickLEFTBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, RstickL());
                }

                private void RstickRIGHTBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, RstickR());
                }

                private void RstickUPBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, RstickU());
                }

                private void RstickDOWNBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, RstickD());
                }

                private void RightStickBtn_Click(object sender, EventArgs e)
                {
                    if (offline)
                    {
                        MessageBox.Show("You are offline! Please connect to Sys-botbase first.");
                        return;
                    }
                    SendString(socket, RSTICK());
                }

        */

        public enum MovingDirection
        {
            Up,
            Down,
            Left,
            Right,
            UpRight,
            UpLeft,
            DownRight,
            DownLeft,
            Null
        }

        private void LstickMouseUp(object sender, MouseEventArgs e)
        {
            L_StickUp = false;
            L_StickRight = false;
            L_StickLeft = false;
            L_StickDown = false;
        }

        private void LstickUPBtn_MouseDown(object sender, MouseEventArgs e)
        {
            L_StickUp = true;
            //LstickUp();
        }

        private void LstickRIGHTBtn_MouseDown(object sender, MouseEventArgs e)
        {
            L_StickRight = true;
            //LstickRight();
        }

        private void LstickDOWNBtn_MouseDown(object sender, MouseEventArgs e)
        {
            L_StickDown = true;
            //LstickDown();
        }

        private void LstickLEFTBtn_MouseDown(object sender, MouseEventArgs e)
        {
            L_StickLeft = true;
            //LstickLeft();

        }

        private void XBtn_Click(object sender, EventArgs e)
        {

            ClickX();
        }

        private void ABtn_Click(object sender, EventArgs e)
        {
            ClickA();
        }

        private void BBtn_Click(object sender, EventArgs e)
        {
            ClickB();
        }

        private void YBtn_Click(object sender, EventArgs e)
        {
            ClickY();
        }
        private void LeftStickBtn_Click(object sender, EventArgs e)
        {
            ClickLeftStick();
        }

        private void RightStickBtn_Click(object sender, EventArgs e)
        {
            ClickRightStick();
        }

        private void DupBtn_Click(object sender, EventArgs e)
        {
            ClickUp();
        }

        private void DrightBtn_Click(object sender, EventArgs e)
        {
            ClickRight();
        }

        private void DdownBtn_Click(object sender, EventArgs e)
        {
            ClickDown();
        }

        private void DleftBtn_Click(object sender, EventArgs e)
        {
            ClickLeft();
        }

        private void LBtn_Click(object sender, EventArgs e)
        {
            ClickL();
        }

        private void RBtn_Click(object sender, EventArgs e)
        {
            ClickR();
        }

        private void ZLBtn_Click(object sender, EventArgs e)
        {
            ClickZL();
        }

        private void ZRBtn_Click(object sender, EventArgs e)
        {
            ClickZR();
        }

        private void minusBtn_Click(object sender, EventArgs e)
        {
            ClickMINUS();
        }

        private void plusBtn_Click(object sender, EventArgs e)
        {
            ClickPLUS();
        }

        private void caputureBtn_Click(object sender, EventArgs e)
        {
            ClickCAPTURE();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            ClickHOME();
        }


        private void RstickMouseUp(object sender, MouseEventArgs e)
        {
            ResetRightStick();
        }

        private void RstickUPBtn_MouseDown(object sender, MouseEventArgs e)
        {
            RstickUp();
        }

        private void RstickRIGHTBtn_MouseDown(object sender, MouseEventArgs e)
        {
            RstickRight();
        }

        private void RstickDOWNBtn_MouseDown(object sender, MouseEventArgs e)
        {
            RstickDown();
        }

        private void RstickLEFTBtn_MouseDown(object sender, MouseEventArgs e)
        {
            RstickLeft();
        }


        private void DetachBtn_Click(object sender, EventArgs e)
        {
            DetachController();
        }




        private void ControllerTimer_Tick(object sender, EventArgs e)
        {
            if (!L_StickUp && !L_StickDown && !L_StickLeft && !L_StickRight)
            {
                if (!resetted)
                {
                    currentDirection = MovingDirection.Null;
                    resetted = true;
                    //Debug.Print("Reset Stick");
                    ResetLeftStick();
                }
            }
            /*
            else if (W && D)
            {
                if (currentDirection != MovingDirection.UpRight)
                {
                    currentDirection = MovingDirection.UpRight;
                    resetted = false;
                    //Debug.Print("TopRight");
                    Controller.LstickTopRight();
                }
            }
            else if (W && A)
            {
                if (currentDirection != MovingDirection.UpLeft)
                {
                    currentDirection = MovingDirection.UpLeft;
                    resetted = false;
                    //Debug.Print("TopLeft");
                    Controller.LstickTopLeft();
                }
            }
            */
            else if (L_StickUp)
            {
                if (currentDirection != MovingDirection.Up)
                {
                    currentDirection = MovingDirection.Up;
                    resetted = false;
                    //Debug.Print("Up");
                    LstickUp();
                }
            }
            /*
            else if (S && D)
            {
                if (currentDirection != MovingDirection.DownRight)
                {
                    currentDirection = MovingDirection.DownRight;
                    resetted = false;
                    //Debug.Print("BottomRight");
                    Controller.LstickBottomRight();
                }
            }
            else if (S && A)
            {
                if (currentDirection != MovingDirection.DownLeft)
                {
                    currentDirection = MovingDirection.DownLeft;
                    resetted = false;
                    //Debug.Print("BottomLeft");
                    Controller.LstickBottomLeft();
                }
            }
            */

            else if (L_StickDown)
            {
                if (currentDirection != MovingDirection.Down)
                {
                    currentDirection = MovingDirection.Down;
                    resetted = false;
                    //Debug.Print("Down");
                    LstickDown();
                }
            }
            else if (L_StickLeft)
            {
                if (currentDirection != MovingDirection.Left)
                {
                    currentDirection = MovingDirection.Left;
                    resetted = false;
                    //Debug.Print("Left");
                    LstickLeft();
                }
            }
            else if (L_StickRight)
            {
                if (currentDirection != MovingDirection.Right)
                {
                    currentDirection = MovingDirection.Right;
                    resetted = false;
                    //Debug.Print("Right");
                    LstickRight();
                }
            }

/*
            if (I)
            {
                if (!holdingI)
                {
                    holdingI = true;
                    //Debug.Print("Press X");
                    Controller.PressX();
                }
            }
            else if (!I)
            {
                if (holdingI)
                {
                    holdingI = false;
                    //Debug.Print("Release X");
                    Controller.ReleaseX();
                }
            }

            if (J)
            {
                if (!holdingJ)
                {
                    holdingJ = true;
                    //Debug.Print("Press Y");
                    Controller.PressY();
                }
            }
            else if (!J)
            {
                if (holdingJ)
                {
                    holdingJ = false;
                    //Debug.Print("Release Y");
                    Controller.ReleaseY();
                }
            }

            if (K)
            {
                if (!holdingK)
                {
                    holdingK = true;
                    //Debug.Print("Press B");
                    Controller.PressB();
                }
            }
            else if (!K)
            {
                if (holdingK)
                {
                    holdingK = false;
                    //Debug.Print("Release B");
                    Controller.ReleaseB();
                }
            }

            if (L)
            {
                if (!holdingL)
                {
                    holdingL = true;
                    //Debug.Print("Press A");
                    Controller.PressA();
                }
            }
            else if (!L)
            {
                if (holdingL)
                {
                    holdingL = false;
                    //Debug.Print("Release A");
                    Controller.ReleaseA();
                }
            }
*/

        }



    }

















}
