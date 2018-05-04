using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Runtime.InteropServices;   
using System.Reflection;

namespace WVA_Scan
{
    public partial class MainForm : Form
    {
        // ===============================================================================================================================================================
        //                        GLOBALS
        // ===============================================================================================================================================================
      
        
        public int Status { get; set; }

        public static Int32 ComCheck { get; set; }
        public static int ReadBarcodes { get; set; } = 0; 

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

        List<Int32> Ports = new List<Int32>();

        // ===============================================================================================================================================================
        //                        MAIN METHOD
        // ===============================================================================================================================================================

        public MainForm()
        {        
            InitializeComponent();
            BindObjsToBkrd();
            FileLogic.CreateDirs();
            GetAccountNumber();
            FileLogic.CleanDirectory();
            Start();
        }

        // ===============================================================================================================================================================
        //                        MAIN LOOP
        // ===============================================================================================================================================================

        public void CallbackFunction(Int32 nComport)
        {           
            try
            {
                int iRet = -1;

                if ( Opticon.csp2.DataAvailable(nComport) > 0)
                {
                    iRet = Opticon.csp2.ReadData(nComport);
                    Status = 1;
                }
                else if (Opticon.csp2.GetDSR(nComport) > 0)
                {
                    Status = 1; 
                    iRet = Opticon.csp2.Interrogate(nComport);
                    Status = Opticon.csp2.Interrogate(nComport);
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

                ComCheck = nComport;
     
                BeginInvoke((Action)delegate ()
                {
                    if (Ports.Count > 0)
                    {
                        labelConnected.Text = "Connected on COM " + nComport;
                        
                    }
                    else
                    {
                        labelConnected.Text = "Not Connected";
                        labelNumBarcodes.Text = "Not Connected";
                    }
                });

                if (iRet >= 0L)
                {
                    Int32 iCount = iRet;

                    ReadBarcodes = iCount;

                    BeginInvoke((Action)delegate ()
                    {
                        labelNumBarcodes.Text = ReadBarcodes.ToString();
                    });                                   
                }
                else
                {
                    ReadBarcodes = 0;
                }
                Thread.Sleep(333);
            }
            catch (Exception error)
            {
                Errors.ReportError(error.ToString());
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
                if (iRet < 0)
                {
                    Trace.WriteLine(String.Format(" Fail {0} ", iRet));
                }
                else
                {
                    Trace.WriteLine(String.Format("DLL Version = {0}", szDLLVersion));
                }

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

        // ===============================================================================================================================================================
        //                        FORM SETUP
        // ===============================================================================================================================================================

        private void BindObjsToBkrd()
        { 
            try
            {
                var pos2 = labelContactNum.Location;
                pos2 = backdrop.PointToClient(pos2);
                labelContactNum.Parent = backdrop;
                labelContactNum.Location = pos2;
                labelContactNum.BackColor = Color.Transparent;

                var pos3 = LLViewCart.Location;
                pos3 = logoTab2.PointToClient(pos3);
                LLViewCart.Parent = logoTab2;
                LLViewCart.Location = pos3;
                LLViewCart.BackColor = Color.Transparent;
        
                var pos5 = labelBarcodes.Location;
                pos5 = logoTab1.PointToClient(pos5);
                labelBarcodes.Parent = logoTab1;
                labelBarcodes.Location = pos5;
                labelBarcodes.BackColor = Color.Transparent;

                var pos6 = labelNumBarcodes.Location;
                pos6 = logoTab1.PointToClient(pos6);
                labelNumBarcodes.Parent = logoTab1;
                labelNumBarcodes.Location = pos6;
                labelNumBarcodes.BackColor = Color.White;

                var pos7 = labelConnected.Location;
                pos7 = logoTab1.PointToClient(pos7);
                labelConnected.Parent = logoTab1;
                labelConnected.Location = pos7;
                labelConnected.BackColor = Color.White;

                var pos8 = labelStatusHead.Location;
                pos8 = logoTab1.PointToClient(pos8);
                labelStatusHead.Parent = logoTab1;
                labelStatusHead.Location = pos8;
                labelStatusHead.BackColor = Color.Transparent;

                var pos9 = sendData.Location;
                pos9 = logoTab1.PointToClient(pos9);
                sendData.Parent = logoTab1;
                sendData.Location = pos9;
                sendData.BackColor = Color.White;
            
                var pos10 = sendData.Location;
                pos10 = AccountLabel.PointToClient(pos10);
                AccountLabel.Parent = logoTab2;
                AccountLabel.Location = pos10;
                AccountLabel.BackColor = Color.Transparent;

                var pos11 = warningLabel.Location;
                pos11 = logoTab1.PointToClient(pos11);
                warningLabel.Parent = logoTab1;
                warningLabel.Location = pos11;
                warningLabel.BackColor = Color.Transparent;
            }
            catch (Exception e)
            {
                Errors.ReportError(e.ToString());
            }
        }

        // ===============================================================================================================================================================
        //                        HELPER METHODS
        // ===============================================================================================================================================================

        public static string GetTime()
        {
            try
            {
                string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                return time.ToString();
            }
            catch (Exception error)
            {               
                Errors.ReportError(error.ToString());
                return "TIME ERROR!";
            }
        }

        public static string GetAccountNumber()
        {
            try
            {
                string accountNumber = File.ReadLines(Path.DirPublicDocs + @"\WVA_Scan\ActNum\ActNum.txt").Skip(0).Take(1).First();

                if (accountNumber != "" && accountNumber != null)
                {
                    AccountTextBox.Text = (accountNumber.ToString());
                }

                return accountNumber;
            }
            catch
            {
                return "";
            }
        }      

        private void SetParameters(string file)
        {
            PrefPB.Value = 0;
            int counter = 0;
            Int32 nParam = 0;
            byte[] szString = new byte[100];
            Int32 nMaxLength = 1;

            try
            {
                Stop();
                CallbackFunction(ComCheck);
                if (Status >= 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    foreach (ParamInfo p in Description)
                    {
                        ComCheck = Opticon.csp2.Init(ComCheck);
                        int line = Convert.ToInt32(File.ReadLines(Path.DirProgram86 + @"/WVA Scan/WVA_Scan/Config/Prefs/" + file).Skip(counter).Take(1).First());
                        szString[0] = (byte)line;
                        nParam = p.ParamNumber;
                        Int32 iRet = Opticon.csp2.SetParam(nParam, szString, nMaxLength);
                        counter++;
                        PrefPB.Value++;
                    }
                    if (counter == 50)
                    {
                        var prefComp = new PrefCompleted();
                        if (Application.OpenForms.OfType<MessageForm>().Count() == 1)
                            Application.OpenForms.OfType<MessageForm>().First().Close();
                        prefComp.ShowDialog();
                    }
                    this.Cursor = Cursors.Arrow;
                }
                else
                {
                    NoScanned noScanned = new NoScanned();
                    noScanned.label1.Text = "Scanner not connected! Plug Scanner into USB port to change preferences.";
                    noScanned.ShowDialog();
                }
            }
            catch (Exception e)
            {
                this.Cursor = Cursors.Arrow;
                Errors.ReportError(e.ToString());
            }
            finally
            {
                PrefPB.Value = 0;
                Started = false;
                Start();
                CallbackFunction(ComCheck);
            }      
        }

        private void resetProgressBar(object sender, EventArgs e)
        {
            try
            {
                setActPB.Value = 0;

                string actNum = GetAccountNumber();

                if (actNum != "" || actNum != null)
                {
                    AccountTextBox.Text = actNum;
                }                
            } 
            catch (Exception error)
            {
                Errors.ReportError(error.ToString());
            }
        }

        // ===============================================================================================================================================================
        //                        FORM CONTROLS
        // ===============================================================================================================================================================

        public static void SetAccountNumberBtn(object sender, EventArgs e)
        {
            try
            {
                string message = "";
                setActPB.Value = 0;

                string actNum = AccountTextBox.Text.Trim();

                if (actNum.Contains("Updated to:"))
                {
                    actNum = actNum.Replace("Updated to:","").Trim();
                }
                    
                if (actNum != null && actNum != "")
                {                  
                    setActPB.Value += 25;
                    Thread.Sleep(125);
                    setActPB.Value += 25;
                    Thread.Sleep(125);

                    FileLogic.CreateActNumFiles();

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(Path.DirPublicDocs + @"\WVA_Scan\ActNum\ActNum.txt"))
                    {
                        file.WriteLine(actNum);
                        file.Close();
                    }

                    message = "Updated to: " + actNum.ToString();

                    setActPB.Value += 50;
                    Thread.Sleep(250);
                }
                AccountTextBox.Text = (message);        
            }
            catch (Exception e1)
            {
                Errors.ReportError(e1.ToString());
            }
        }

        private void SendData_Click(object sender, EventArgs e)
        {
            try
            {
                // Create loading cursor
                this.Cursor = Cursors.WaitCursor;
                // Disable Download scanner button
                sendData.Enabled = false;

                if (ReadBarcodes <= 0)
                {
                    var noScan = new NoScanned();
                    if (Application.OpenForms.OfType<NoScanned>().Count() == 1)
                        Application.OpenForms.OfType<NoScanned>().First().Close();
                    noScan.ShowDialog();
                }
                else
                {
                    string actNum = GetAccountNumber();

                    if (actNum != null && actNum != "" && actNum != " ")
                    {
                        API.RunApi(CreateOrder(actNum));
                    }
                    else
                    {
                        var anef = new ActNumErrorForm();
                        if (Application.OpenForms.OfType<ActNumErrorForm>().Count() == 1)
                            Application.OpenForms.OfType<ActNumErrorForm>().First().Close();
                        anef.ShowDialog();
                    }
                }

                Start();
                CallbackFunction(ComCheck);

                // Enable Download scanner button
                sendData.Enabled = true;
                // Turn cursor back to original state
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception e1)
            {
                Errors.ReportError(e1.ToString());
            }
        }

        [DllImport("Opticon.csp2.net")]
        static extern void CreateOrder([In, MarshalAs(UnmanagedType.LPStr)] string deviceID, [In, MarshalAs(UnmanagedType.LPStr)] List<string> listBarcodes);

        private Order CreateOrder(string actNum)
        {
            string time = GetTime();
            string deviceID;

            List<string> listBarcodes = new List<string>();

            int iRet = Opticon.csp2.GetDeviceId(out deviceID, ComCheck);

            for (Int32 i = 0; i < ReadBarcodes; i++)
            {
                Opticon.csp2.BarCodeDataPacket aPacket;
                iRet = Opticon.csp2.GetPacket(out aPacket, i, ComCheck);
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
            FileLogic.CreateScanDataDir();
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(Path.DirPublicDocs + @"\WVA_Scan\ScanData\" + time))
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

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            SetParameters("ReadUPC_Only.txt");
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            SetParameters("ReadStockOnly.txt");
            button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            SetParameters("ReadStock+UPC.txt");
            button4.Enabled = true;
        }

        private void LLViewCart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            try
            {
                System.Diagnostics.Process.Start("https://www.wewillship.com/landing.html?navTo=login");
            }
            catch (Exception e1)
            {
                Errors.ReportError(e1.ToString());
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Launcher_Update.Init();
        }
    }

    // ===============================================================================================================================================================
    //                        PARAMINFO CLASS
    // ===============================================================================================================================================================

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

