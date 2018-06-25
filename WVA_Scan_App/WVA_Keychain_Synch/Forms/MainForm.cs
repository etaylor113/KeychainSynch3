using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WVA_Scan
{
    public partial class MainForm : Form
    {

        //===============================================================================
        //================ GLOBALS ======================================================
        //===============================================================================

        public int Status { get; set; }
        public static int ScannedItems { get; set; } = 0;
        public static Int32 Comport { get; set; }

        [DllImport("Opticon.csp2.net")]
        static extern void CallbackFunction([In, MarshalAs(UnmanagedType.LPStr)] string szDeviceId, [In, MarshalAs(UnmanagedType.LPStr)] string szSoftwareVersion, [In, MarshalAs(UnmanagedType.LPStr)] StringBuilder sbBarcodes);

        ParamInfo[] Description = {
                        new ParamInfo( "Code 39", 0x1f ),
                        new ParamInfo( "UPC", 0x09 ),
                        new ParamInfo( "Code128",  0x08),
                        new ParamInfo( "Code 39 Full ASCII", 0x36 ),
                        new ParamInfo( "UPC Supps", 0x35 ),
                        new ParamInfo( "Convert  UPC E to A", 0x29 ),
                        new ParamInfo( "Convert EAN8 to EAN13",     0x2a ),
                        new ParamInfo( "Convert EAN8 to EAN13 Type", 0x37 ),
                        new ParamInfo( "Send UPC A Check Digit",    0x2b ),
                        new ParamInfo( "Send UPC E Check Digit", 0x2c ),
                        new ParamInfo( "Code 39 Check Digit", 0x2e ),
                        new ParamInfo( "Xmit Code 39 Check Digit", 0x2d ),
                        new ParamInfo( "UPCE_ Preamble", 0x25 ),
                        new ParamInfo( "UPCA_ Preamble", 0x24 ),
                        new ParamInfo( "EAN 128", 0x34 ),
                        new ParamInfo( "Coupon Code", 0x38),
                        new ParamInfo( "I 2of5", 0x3A ),
                        new ParamInfo( "I 2of5 Check Digit", 0x41 ),
                        new ParamInfo( "Xmit I 2of5 Check Digit", 0x40 ),
                        new ParamInfo( "Convert ITF14 to EAN 13", 0x3F ),
                        new ParamInfo( "I 2of5 Length 1",0x3B ),
                        new ParamInfo( "I 2of5 Length 2",0x3C ),
                        new ParamInfo( "D 2of5", 0x39 ),
                        new ParamInfo( "D 2of5  Length 1" ,0x3D ),
                        new ParamInfo( "D 2of5  Length 2", 0x3E ),
                        new ParamInfo( "Upcean Security Level", 0x2f ),
                        new ParamInfo( "UPC/EAN Supplemental Redundancy", 0x30 ),
                        new ParamInfo( "Scanner On-Time",0x11 ),
                        new ParamInfo( "Comm Awake Time", 0x20 ),
                        new ParamInfo( "Baud Rate ",0x0d ),
                        new ParamInfo( "Baud Switch Delay", 0x1d),
                        new ParamInfo( "Reset Baud Rates", 0x1c ),
                        new ParamInfo( "Reject Redundant Barcode", 0x04 ),
                        new ParamInfo( "Host Connect Beep ", 0x0a ),
                        new ParamInfo( "Host Complete Beep", 0x0b ),
                        new ParamInfo( "Low-Battery Indication", 0x07),
                        new ParamInfo( "Auto_Clear", 0x0f),
                        new ParamInfo( "Delete_Enable",0x21),
                        new ParamInfo( "Data Protection", 0x31 ),
                        new ParamInfo( "Memory Full Indication", 0x32 ),
                        new ParamInfo( "Memory Low Indication", 0x33 ),
                        new ParamInfo( "Max Barcode Len", 0x22 ),
                        new ParamInfo( "Good Decode LED On Time", 0x1e ),
                        new ParamInfo( "Store_RTC ", 0x23 ),
                        new ParamInfo( "ASCII mode", 0x4f ),
                        new ParamInfo( "Buzzer Volume",0x02 ),
                        new ParamInfo( "Buzzer On",0x57 ),
                        new ParamInfo( "Buzzer Toggle", 0x55 ),
                        new ParamInfo( "Buzzer Auto On", 0x56 ),
                        new ParamInfo( "RSS", 0x14 ),
        };

        //===============================================================================
        //================ MAIN METHOD ==================================================
        //===============================================================================

        public MainForm()
        {
            InitializeComponent();
            SetDefaultTabColor();
            FileAction.CreateDirs();
            FileAction.CleanDirectory();
            SetupMessagesRTB();
            checkMessagesTimer.Start();
            SetAccountNumber();
            Start();   
        }

        //===============================================================================
        //================ MAIN LOOP ====================================================
        //===============================================================================

        List<Int32> Ports = new List<Int32>();

        public void CallbackFunction(Int32 nComport)
        {
            try
            {
                int iRet = -1;

                if (Opticon.csp2.DataAvailable(nComport) > 0)
                {
                    iRet = Opticon.csp2.ReadData(nComport);
                    Status = 1;
                }
                else if (Opticon.csp2.GetDSR(nComport) > 0)
                {
                    Status = 1;
                    iRet = Status = Opticon.csp2.Interrogate(nComport);
                }
                else
                {
                    Status = -1;
                }

                if (iRet >= 0)
                {
                    if (Ports.Contains(nComport) == false)
                        Ports.Add(nComport);
                }
                else
                {
                    if (Ports.Contains(nComport) == true)
                        Ports.Remove(nComport);
                }

                BeginInvoke((Action)delegate ()
                {
                    if (Ports.Count > 0)
                    {
                        tb_ScannerStatus.Text = "Connected";
                    }
                    else
                    {
                        tb_ScannerStatus.Text = "Not Connected";
                        tb_ScannedItems.Text = "";
                    }

                });

                if (iRet >= 0L)
                {
                    Int32 iCount = iRet;

                    ScannedItems = iCount;

                    BeginInvoke((Action)delegate ()
                    {
                        tb_ScannedItems.Text = ScannedItems.ToString();
                    });
                }
                else
                {
                    ScannedItems = 0;
                }

                Comport = nComport;
                Thread.Sleep(225);
                

            }
            catch (Exception error)
            {
                Error err = new Error();
                err.ReportError(error.ToString());
            }
        }

        bool Started = false;
        Opticon.csp2.csp2CallBackFunctionAll Csp2Callback = null;

        public void Start()
        {
            if (!Started)
            {
                Int32 iRet;

                StringBuilder szDLLVersion = new StringBuilder(256);
                iRet = Opticon.csp2.GetDllVersion(szDLLVersion, 100);

                Int32[] ports = new Int32[100];

                int Count = Opticon.csp2.GetOpnCompatiblePorts(ports);

                if (Csp2Callback == null)
                    Csp2Callback = new Opticon.csp2.csp2CallBackFunctionAll(CallbackFunction);

                iRet = Opticon.csp2.StartPollingAll(Csp2Callback);

                if (iRet != 0)
                {
                    return;
                }

                Started = true;
            }
            else
            {
                Opticon.csp2.EnablePolling();
            }
        }

        public void Stop()
        {
            Opticon.csp2.DisablePolling();
            Opticon.csp2.StopPolling();
        }

        //===============================================================================
        //================ HELPER METHODS ===============================================
        //===============================================================================

        private void resetAccountTab(object sender, EventArgs e)
        {
            try
            {
                string actNum = Account.GetAccountNumber();

                if (actNum != "" || actNum != null)
                {
                    tb_Actnum.Text = actNum;
                }
            }
            catch (Exception error)
            {
                Error err = new Error();
                err.ReportError(error.ToString());
            }
        }

        private void RunLink(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception error)
            {
                Error err = new Error();
                err.ReportError(error.ToString());
            }
        }

        //===============================================================================
        //================ FORM SETUP ===================================================
        //===============================================================================

        private void SetDefaultTabColor()
        {
            currentColor = Color.LightSlateGray;
        }

        private void SetupMessagesRTB()
        {
            rtb_Messages.SelectionStart = rtb_Messages.Text.Length;
            rtb_Messages.SelectionLength = 0;
            rtb_Messages.ScrollToCaret();
        }

        //===============================================================================
        //================== Scan Tab Helper Funcs ======================================
        //===============================================================================

        public string SetAccountNumber()
        {
            try
            {
                string accountNumber = File.ReadLines(Paths.DirPublicDocs + @"\WVA_Scan\ActNum\ActNum.txt").Skip(0).Take(1).First();

                if (accountNumber != "" && accountNumber != null)
                {
                    tb_Actnum.Text = (accountNumber.ToString());
                }

                return accountNumber;
            }
            catch
            {
                return "";
            }
        }

        private void ShowMessage(string message)
        {
            rtb_Messages.Text = message;
        }

        [DllImport("Opticon.csp2.net")]
        static extern void CreateOrder([In, MarshalAs(UnmanagedType.LPStr)] string deviceID, [In, MarshalAs(UnmanagedType.LPStr)] List<string> listBarcodes, [In, MarshalAs(UnmanagedType.LPStr)] Int32 Comport);

        private Order CreateOrder(string actNum)
        {
            Time dt = new Time();
            string time = dt.GetTime();
            string deviceID;

            List<string> listBarcodes = new List<string>();

            int iRet = Opticon.csp2.GetDeviceId(out deviceID, Comport);

            for (Int32 i = 0; i < ScannedItems; i++)
            {
                Opticon.csp2.BarCodeDataPacket aPacket;
                iRet = Opticon.csp2.GetPacket(out aPacket, i, Comport);
                if (aPacket.strBarData != null)
                {
                    listBarcodes.Add(aPacket.strBarData.ToString());
                }
            };

            WriteToDataLog(time, actNum, deviceID, listBarcodes);

            // Create new order from order class
            Order order = new Order()
            {
                Time = time,
                ActNumber = actNum,
                DeviceID = deviceID,
                Barcodes = listBarcodes.ToArray()
            };

            return order;
        }

        private void WriteToDataLog(string time, string accountNumber, string deviceID, List<string> listBarcodes)
        {
            // Copy order to backup data file
            FileAction.CreateScanDataDir();
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(Paths.DirPublicDocs + @"\WVA_Scan\ScanData\" + time))
            {
                writer.Write("<Date Created> " + time);
                writer.Write("\r\n<Account Number> " + accountNumber);
                writer.Write("\r\n<Scanner Id> " + deviceID);
                foreach (string barcode in listBarcodes)
                {
                    writer.Write("\r\n<Item> " + barcode);
                }
                writer.Close();
            }
        }

        //===============================================================================
        //================== Prefernces Tab Helper Funcs ================================
        //===============================================================================

        private void SetParameters(string file)
        {
            pref_progb.Value = 0;
            int counter = 0;
            Int32 nParam = 0;
            byte[] szString = new byte[100];
            Int32 nMaxLength = 1;

            rtb_Preferences.Text = "Loading...";
            tab_Preferences.Refresh();

            try
            {
                Stop();
                CallbackFunction(Comport);
                if (Status >= 0)
                {
                    foreach (ParamInfo p in Description)
                    {
                        Comport = Opticon.csp2.Init(Comport);
                        int line = Convert.ToInt32(File.ReadLines(Paths.DirProgram86 + @"/WVA Scan/WVA_Scan/Prefs/" + file).Skip(counter).Take(1).First());
                        szString[0] = (byte)line;
                        nParam = p.ParamNumber;
                        Int32 iRet = Opticon.csp2.SetParam(nParam, szString, nMaxLength);
                        counter++;
                        pref_progb.Value++;
                    }
                    if (counter == 50)
                    {
                        rtb_Preferences.Text = "Preferences Updated! You may unplug your scanner.";
                    }
                }
                else
                {
                    rtb_Preferences.Text = "Scanner not connected! Plug Scanner into USB port to change preferences.";
                }
            }
            catch (Exception e)
            {
                Cursor = Cursors.Default;
                Error err = new Error();
                err.ReportError(e.ToString());
            }
            finally
            {
                Started = false;
                Start();
                CallbackFunction(Comport);
            }
        }

        //===============================================================================
        //================ FORM EVENTS ==================================================
        //===============================================================================

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        Color currentColor = new Color();

        private void tab_Scan_Enter(object sender, EventArgs e)
        {
            Started = false;
            Start();
        }

        private void tab_Scan_Leave(object sender, EventArgs e)
        {
            Stop();
        }

        private void tab_Messages_Enter(object sender, EventArgs e)
        {
            blinkTimer.Stop();
            currentColor = Color.LightSlateGray;
            tabControl.Refresh();
        }

        private void tab_Preferences_Enter(object sender, EventArgs e)
        {
            rtb_Preferences.Text = "";
            pref_progb.Value = 0;
            radb_ScanUPC.Checked = false;
            radb_ScanOPC.Checked = false;
            radb_ScanUPC_OPC.Checked = false;
        }

        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (blinkTimer.Enabled && e.Index == 1)
            {
                e.Graphics.FillRectangle(new SolidBrush(currentColor), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.LightSlateGray), e.Bounds);
            }

            Rectangle paddedBounds = e.Bounds;
            paddedBounds.Inflate(-2, -2);

            Font font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular);
            e.Graphics.DrawString(tabControl.TabPages[e.Index].Text, font, SystemBrushes.HighlightText, paddedBounds);
        }

        //===============================================================================
        //==================== TIMERS ===================================================
        //===============================================================================

        // Flash messages tab
        private void blinkTimer_Tick(object sender, EventArgs e)
        {
            if (currentColor == Color.DeepSkyBlue)
                currentColor = Color.LightSlateGray;
            else
                currentColor = Color.DeepSkyBlue;
            tabControl.Refresh();
        }

        // Checks for messages in rtb_Messages
        private void checkMessagesTimer_Tick(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab != tab_Messages)
            {
                if (rtb_Messages.Text != "")
                {
                    blinkTimer.Start();
                }
            }          
        }

        //===============================================================================
        // ================= FORM CONTROL EVENTS ========================================
        //===============================================================================

        private void btn_CreateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                btn_CreateOrder.Enabled = false;

                int status = 1;
                status = Opticon.csp2.DataAvailable(Comport);

                if (status < 0)
                {
                    rtb_Messages.Text = "Is your scanner plugged in?";
                }
                else if (ScannedItems <= 0)
                {
                    rtb_Messages.Text = "You have not scanned any items.";
                }
                else if (ScannedItems > 0 && status >= 0)
                {
                    string actNum = Account.GetAccountNumber();

                    if (actNum != null && actNum != "" && actNum != " ")
                    {
                        rtb_Messages.Text = API.RunApi(CreateOrder(actNum));
                    }
                    else
                    {
                        rtb_Messages.Text = "You must enter your WVA account number first. Please go to Account tab to submit it.";
                    }
                }
                else
                {
                    rtb_Messages.Text = "I'm having an issue reading your scanner. If the problem persists, please call WVA Scanner support.";
                }

                btn_CreateOrder.Enabled = true;
                Cursor = Cursors.Arrow;
                tabControl.SelectedTab = tab_Messages;
            }
            catch (Exception e1)
            {
                Error err = new Error();
                err.ReportError(e1.ToString());
            }
        }

        private void btn_ReviewOrder_Click(object sender, EventArgs e)
        {
            RunLink("https://www.wewillship.com/landing.html?navTo=login");           
        }

        private void ll_SupportLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RunLink("http://support.wisvis.com");          
        }

        private void ll_PrefMoreInfoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // FIX     Need to add pdf for this onto website 
        }

        private void btn_SetActNum_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "";
                string actNum = tb_Actnum.Text.Trim();

                if (actNum.Contains("Set to:"))
                {
                    actNum = actNum.Replace("Set to:", "").Trim();
                }

                if (actNum != null && actNum != "")
                {
                    FileAction.CreateActNumFiles();

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(Paths.DirPublicDocs + @"\WVA_Scan\ActNum\ActNum.txt"))
                    {
                        file.WriteLine(actNum);
                        file.Close();
                    }

                    message = "Set to: " + actNum.ToString();
                }
                tb_Actnum.Text = (message);
            }
            catch (Exception error)
            {
                Error err = new Error();
                err.ReportError(error.ToString());
            }
        }

        private void btn_ClearMessages_Click(object sender, EventArgs e)
        {
            rtb_Messages.Text = "";
            tabControl.SelectedTab = tab_Scan;
        }

        private void btn_ChangePref_Click(object sender, EventArgs e)
        {
            btn_ChangePref.Enabled = false;
            Cursor = Cursors.WaitCursor;
            
            if (radb_ScanUPC.Checked == true)
                SetParameters("ReadUPC_Only.txt");
            else if (radb_ScanOPC.Checked == true)
                SetParameters("ReadStockOnly.txt");
            else if (radb_ScanUPC_OPC.Checked == true)
                SetParameters("ReadStock+UPC.txt"); 
            else
                rtb_Preferences.Text = "Please select a preference.";

            btn_ChangePref.Enabled = true;
            Cursor = Cursors.Default;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Launcher_Update.Init();
        }
    }

    //===============================================================================
    //================== PARAM INFO  ================================================
    //===============================================================================

    public class ParamInfo
        {
            public ParamInfo(String Par, int Num)
            {
                _Parameter = Par;
                _ParamNumber = Num;
                _ParamValue = -1;
            }

            private String _Parameter;
            public String Parameter
            {
                get { return _Parameter; }
                set { _Parameter = value; }
            }

            private int _ParamNumber;
            public int ParamNumber
            {
                get { return _ParamNumber; }
                set { _ParamNumber = value; }
            }

            private int _ParamValue;
            public int ParamValue
            {
                get { return _ParamValue; }
                set { _ParamValue = value; }
            }

        }     
    }