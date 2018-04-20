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
      
        public int ReadBarcodes { get; set; } = 0;
        public bool DataSend { get; set; }
        private string TxtReader { get; set; }
        public int Status { get; set; }

        public static Int32 ComCheck { get; set; }
        public static bool ClearData { get; set; }
        public static string AccountNumber { get; set; } 
        public static string DeviceID { get; set; }
        public static string SWVersion { get; set; }
        public static List<string> Barcodes = new List<string>();   

        [DllImport("Opticon.csp2.net")]
        static extern void SetParameters([In, MarshalAs(UnmanagedType.LPStr)] string szString);

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
            CheckAccountNumber();
            FileLogic.CleanDirectory();
            Start();
        }

        // ===============================================================================================================================================================
        //                        MAIN LOOP
        // ===============================================================================================================================================================

        public void CallbackFunction(Int32 nComport)
        {
            int iRet = -1;
            try
            {
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

                    if (DataSend == true)
                    {
                        try
                        {                     
                            if (AccountNumber != null && AccountNumber != "")
                            {                          
                                string strTime = GetTime();

                                string szDeviceId;
                                iRet = Opticon.csp2.GetDeviceId(out szDeviceId, nComport);
                                DeviceID = szDeviceId;
                                                       
                                StringBuilder sbBarcodes = new StringBuilder(1000);
                                for (Int32 i = 0; i < ReadBarcodes; i++)
                                {
                                    Opticon.csp2.BarCodeDataPacket aPacket;
                                    iRet = Opticon.csp2.GetPacket(out aPacket, i, nComport);
                                    if (aPacket.strBarData != null)
                                    {                                      
                                        sbBarcodes.AppendLine(String.Format(aPacket.strBarData));
                                        Barcodes.Add(aPacket.strBarData.ToString());
                                    }
                                };                              

                                // Copy order to backup data file
                                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(Path.DirPublicDocs + @"\WVA_Scan\ScanData\" + strTime))
                                {
                                    writer.Write("<Date Created> " + strTime);
                                    writer.Write("\r\n<Account Number> " + AccountNumber);
                                    writer.Write("\r\n<Scanner Id> " + szDeviceId);
                                    writer.Write("\r\n" + sbBarcodes);
                                    writer.Close();
                                }
                            }
                        }
                        catch (Exception e1)
                        {
                            Errors.PrintToLog(e1.ToString());
                        }

                        DataSend = false;
                        return;

                    }
                    if (ClearData == true)
                    {
                        if (Opticon.csp2.ClearData(nComport) != 0)
                        {
                            string error = "Erasing Failed!";                           
                            Errors.PrintToLog(error);
                        }
                        ReadBarcodes = 0;
                        ClearData = false;
                    }
                }
                else
                {
                    ReadBarcodes = 0;
                }
                Thread.Sleep(500);
            }
            catch { }
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
            }
            catch (Exception e)
            {
                Errors.PrintToLog(e.ToString());
            }
        }

        // ===============================================================================================================================================================
        //                        HELPER METHODS
        // ===============================================================================================================================================================

        public static string GetTime()
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            return time.ToString();
        }

        private void CheckAccountNumber()
        {
            try
            {
                AccountNumber = File.ReadLines(Path.DirPublicDocs + @"\WVA_Scan\ActNum\ActNum.txt").Skip(0).Take(1).First();

                if (AccountNumber != "")
                    AccountTextBox.Text = (AccountNumber.ToString());
            }
            catch { }
        }

        private void SetParameters()
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
                        int line = Convert.ToInt32(File.ReadLines(Path.DirProgram86 + @"/WVA Scan/WVA_Scan/Config/Prefs/" + TxtReader).Skip(counter).Take(1).First());
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
            catch (System.AccessViolationException e)
            {
                this.Cursor = Cursors.Arrow;
                Errors.PrintToLog(e.ToString());
            }
            PrefPB.Value = 0;
            Started = false;
            Start();
            CallbackFunction(ComCheck);
        }

        private void resetProgressBar(object sender, EventArgs e)
        {
            setActPB.Value = 0;
            if (AccountNumber != "" || AccountNumber != null)
                AccountTextBox.Text = AccountNumber;
        }

        // ===============================================================================================================================================================
        //                        FORM CONTROLS
        // ===============================================================================================================================================================

        public void SetAccountNumberBtn(object sender, EventArgs e)
        {
            try
            {
                setActPB.Value = 0;
                CheckAccountNumber();
                setActPB.Value += 25;
                Thread.Sleep(150);

                if (AccountNumber != "")
                {
                    AccountTextBox.Text = (AccountNumber.ToString());                 
                    setActPB.Value += 25;
                    Thread.Sleep(150);

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(Path.DirPublicDocs + @"\WVA_Scan\ActNum\ActNum.txt"))
                    {
                        file.WriteLine(AccountNumber);
                        file.Close();
                    }
                    setActPB.Value += 50;
                    Thread.Sleep(250);
                    AccountTextBox.Text = ("Updated to: " + AccountNumber.ToString());
                }
            }
            catch (Exception e1)
            {
                Errors.PrintToLog(e1.ToString());
            }
        }

        private void SendData_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                sendData.Enabled = false;
                DataSend = true;
                Stop();
                CallbackFunction(ComCheck);

                if (ReadBarcodes <= 0)
                {
                    var noScan = new NoScanned();
                    if (Application.OpenForms.OfType<NoScanned>().Count() == 1)
                        Application.OpenForms.OfType<NoScanned>().First().Close();
                    noScan.ShowDialog();
                }
                else
                {
                    if (AccountNumber != null && AccountNumber != "")
                    {
                        API.RunApi();
                    }
                    else
                    {
                        var anef = new ActNumErrorForm();
                        if (Application.OpenForms.OfType<ActNumErrorForm>().Count() == 1)
                            Application.OpenForms.OfType<ActNumErrorForm>().First().Close();
                        anef.ShowDialog();
                    }
                }

                Started = false;
                Start();
                CallbackFunction(ComCheck);

                sendData.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception e1)
            {
                Errors.PrintToLog(e1.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            TxtReader = "ReadUPC_Only.txt";
            SetParameters();
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            TxtReader = "ReadStockOnly.txt";
            SetParameters();
            button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            TxtReader = "ReadStock+UPC.txt";
            SetParameters();
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
                Errors.PrintToLog(e1.ToString());
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

