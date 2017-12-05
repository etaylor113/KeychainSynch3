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

namespace WVA_Keychain_Synch
{
    public partial class MainForm : Form
    {
        public static Int32 ComCheck { get; set; }
        public int ReadBarcodes { get; set; } = 0;
        public bool DataSend { get; set; }
        private string TxtReader { get; set; }
        public static bool ClearData { get; set; }
        public string AccountNumber { get; set; }
        public string Error { get; set; }
        List<object> data = new List<object>();

        [DllImport("Opticon.csp2.net")]
        static extern void SetParameters([In, MarshalAs(UnmanagedType.LPArray)] byte[] szString);

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

        public void CallbackFunction(Int32 nComport)
        {
                int iRet = -1;

                if (Opticon.csp2.DataAvailable(nComport) > 0)
                {
                
                    iRet = Opticon.csp2.ReadData(nComport);
                }
                else if (Opticon.csp2.GetDSR(nComport) > 0)
                {
                    iRet = Opticon.csp2.Interrogate(nComport);
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
                        labelConnected.Text = "Connected on COM " + nComport;
                    }
                    else
                    {
                        labelConnected.Text = "Not Connected";
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
                                string dirAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                                string ErrorFileName = (dirAppData + @"\WVA_Keychain_Synch\ErrorLog\ErrorLog.txt");

                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(dirAppData + @"\WVA_Keychain_Synch\Data.txt"))
                                {
                                    data.Clear();
                              
                                    if (File.Exists(ErrorFileName))
                                    {
                                        string DirErrorLog = (ErrorFileName);
                                        string[] readErrorLog = File.ReadAllLines(DirErrorLog);

                                        foreach (var line in readErrorLog)
                                        {
                                            if (line != "")
                                                data.Add("<Error> " + line);
                                        }
                                        File.Delete(ErrorFileName);
                                    }

                                
                                    string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                                    data.Add(time);

                                    data.Add(AccountNumber);

                                    string szDeviceId;
                                    iRet = Opticon.csp2.GetDeviceId(out szDeviceId, nComport);
                                    data.Add(szDeviceId);

                                    StringBuilder szSoftwareVersion = new StringBuilder(256);
                                    Opticon.csp2.GetSwVersion(szSoftwareVersion, 256, nComport);
                                    data.Add(szSoftwareVersion.ToString());

                                    StringBuilder sbBarcodes = new StringBuilder(1000);
                                    for (Int32 i = 0; i < ReadBarcodes; i++)
                                    {
                                        Opticon.csp2.BarCodeDataPacket aPacket;
                                        iRet = Opticon.csp2.GetPacket(out aPacket, i, nComport);
                                        if (aPacket.strBarData != null)
                                        {                                       
                                            data.Add(aPacket.strBarData.ToString());
                                            sbBarcodes.AppendLine(String.Format("<Item>" + "\t" + aPacket.strBarData));
                                        }
                                    };

                                    using (System.IO.StreamWriter writer =
                                           new System.IO.StreamWriter(dirAppData + @"\WVA_Keychain_Synch\ScannerData\" + time))
                                    {
                                        writer.Write("<Date Created> " + time);
                                        writer.Write("\r\n<Account Number> " + AccountNumber);
                                        writer.Write("\r\n<Scanner Id> " + szDeviceId);
                                        writer.Write("\r\n<Software Version> " + szSoftwareVersion);
                                        writer.Write("\r\n" + sbBarcodes);

                                        writer.Close();
                                    }
                                file.Close();
                                }
                            }
                        }
                        catch (Exception e1)
                        {
                            Error = e1.ToString();
                            Error += "(Location: CallBack() :DataSend Block)";
                            PrintToErrorLog();
                        }

                    DataSend = false;
                    return;
                }
                    if (ClearData == true)
                    {
                        if (Opticon.csp2.ClearData(nComport) != 0)
                        {
                            Error = "Erasing Failed!";
                            Error += "(Location: CallBack() :ClearData Block)";
                            PrintToErrorLog();
                        }
                        ReadBarcodes = 0;
                        ClearData = false;
                    }
                }
            Thread.Sleep(1000);                          
        }

        public MainForm()
        {           
            InitializeComponent();
            BindObjsToBkrd();
            Start();            
            CreateDirs();
            CheckAccountNumber();
            CleanDirectory();
        }

        private void BindObjsToBkrd()
        { 
            try
            {
                var pos = labelContact.Location;
                pos = backdrop.PointToClient(pos);
                labelContact.Parent = backdrop;
                labelContact.Location = pos;
                labelContact.BackColor = Color.Transparent;

                var pos1 = LLContact.Location;
                pos = backdrop.PointToClient(pos1);
                LLContact.Parent = backdrop;
                LLContact.Location = pos1;
                LLContact.BackColor = Color.Transparent;

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
                Error = e.ToString();
                Error += "(Location: BindObjsToBkrd)";
                PrintToErrorLog();
            }
        }

        public void PrintToErrorLog()
        {
            try
            {
                string dirAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string DirErrorLog = (dirAppData + @"\WVA_Keychain_Synch\ErrorLog\");

                if (!Directory.Exists(DirErrorLog))
                    Directory.CreateDirectory(DirErrorLog);

                if (!File.Exists(dirAppData + @"\WVA_Keychain_Synch\ErrorLog\ErrorLog.txt"))
                    File.Create(dirAppData + @"\WVA_Keychain_Synch\ErrorLog\ErrorLog.txt");

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(dirAppData + @"\WVA_Keychain_Synch\ErrorLog\ErrorLog.txt"))
                {
                    writer.Write(Error);
                    writer.Close();
                }

                Error = "";
            }
            catch{};
        }

        private void CreateDirs()
        {
            try
            {
                string dirAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string DirErrorLog = (dirAppData + @"\WVA_Keychain_Synch\ErrorLog\");
                string DirScannerData = (dirAppData + @"\WVA_Keychain_Synch\ScannerData\");
                var DirAccountNumber = (dirAppData + @"\WVA_Keychain_Synch\AccountNumber\");
            
                try
                {
                    if (Directory.Exists(DirErrorLog) == false)
                        Directory.CreateDirectory(DirErrorLog);
                }
                catch (Exception e1)
                {
                    Error = e1.ToString();
                    Error += "(Location: CreateDirs() :e1)";
                    PrintToErrorLog();
                }

                try
                {
                    if (Directory.Exists(DirScannerData) == false)
                        Directory.CreateDirectory(DirScannerData);
                }
                catch (Exception e2)
                {
                    Error = e2.ToString();
                    Error += "(Location: CreateDirs() :e2)";
                    PrintToErrorLog();
                }

                try
                {
                    if (Directory.Exists(DirAccountNumber) == false)
                    {
                        Directory.CreateDirectory(DirAccountNumber);
                        if (Directory.Exists(DirAccountNumber))
                        {
                            var file = File.Create(dirAppData + @"\WVA_Keychain_Synch\AccountNumber\AccountNumber.txt");
                            file.Close();
                        }
                    }                                                            
                }
                catch (Exception e3)
                {
                    Error = e3.ToString();
                    Error += "(Location: CreateDirs() :e3)";
                    PrintToErrorLog();
                }
            }
            catch (Exception e4)
            {
                Error = e4.ToString();
                Error += "(Location: CreateDirs() :e4)";
                PrintToErrorLog();
            }
        }

        private void CheckAccountNumber()
        {
            try
            {
                string dirAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                 
                AccountNumber = File.ReadLines(dirAppData + @"\WVA_Keychain_Synch\AccountNumber\AccountNumber.txt").Skip(0).Take(1).First();
                
                if (AccountNumber != "" )
                    AccountTextBox.Text = ("Set to: " + AccountNumber);
            }
            catch{}
        }

        private void CleanDirectory()
        {
            try
            {
                string dirAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string[] files = Directory.GetFiles(dirAppData + @"\WVA_Keychain_Synch\ScannerData\");

                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);

                    if (fi.CreationTime < DateTime.Now.AddDays(-30))
                    {
                        fi.Delete();
                    }      
                }
            }
            catch(Exception e)
            {
                Error = e.ToString();
                Error += "(Location: CleanDirectory())";
                PrintToErrorLog();
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
        }        

        private void SendData_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                sendData.Enabled = false;
                DataSend = true;
                
                Thread.Sleep(500);
                Start();
                CallbackFunction(ComCheck);

                if (AccountNumber != null && AccountNumber != "")
                {
                    Stop();
                    RunApi();
                }
                else
                {
                    var anef = new ActNumErrorForm();
                    if (Application.OpenForms.OfType<ActNumErrorForm>().Count() == 1)
                        Application.OpenForms.OfType<ActNumErrorForm>().First().Close();
                    anef.ShowDialog();
                }   
           
                sendData.Enabled = true;
                this.Cursor = Cursors.Arrow;

                Start();
                CallbackFunction(ComCheck);
            }
            catch (Exception e1)
            {
                Error = e1.ToString();
                Error += "(Location: SendDataClick())";
                PrintToErrorLog();
            }
        }

        public void RunApi()
        {
            try
            {
                string MessageFromApi = "";
                var json = JsonConvert.SerializeObject(data);
          
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ws2-qa.wisvis.com/aws/scanner/final.rb");
                request.Method = "POST";

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                Byte[] byteArray = encoding.GetBytes(json);

                request.ContentLength = byteArray.Length;
                request.ContentType = @"application/json";

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    MessageFromApi = reader.ReadToEnd();
                    if (MessageFromApi == "Able to connect to remote server but File Send was not successful\nNo Response")
                    {
                        MessageForm.Response = "There was an error downloading scanner. Be sure you are connected to the internet and your scanner is plugged in. If the problem persists, please call WVA Scanner Support. ";
                        MessageForm message = new MessageForm();
                        message.ShowDialog();
                        return;
                    }
                                   
                    reader.Close();
                }

                response.Close();

                if ((((HttpWebResponse)response).StatusDescription) == "OK")
                {
                    ClearData = true;

                    MessageForm.Response = MessageFromApi;
                    MessageForm message = new MessageForm();
                    message.ShowDialog();
                }
                else
                {
                    MessageForm.Response = "There was an error downloading \nscanner. Be sure you are connected \nto the internet. If the problem persists, \nplease call WVA Scanner Support. ";
                    MessageForm message = new MessageForm();
                    message.ShowDialog();
                }                              
            }
            catch (Exception e)
            {     
                MessageForm.Response = "There was an error downloading \nscanner. Be sure you are connected \nto the internet. If the problem persists, \nplease call WVA Scanner Support. ";
                MessageForm message = new MessageForm();
                message.ShowDialog();

                Error = e.ToString();
                Error += "(Location: RunApi())";
                PrintToErrorLog();
            }
        }
        
        private void SetParameters()
        {
            Stop();
            PrefPB.Value = 0;
            int counter = 0;
            Int32 nParam = 0;
            byte[] szString = new byte[100];
            Int32 nMaxLength = 1;

            try
            {
                foreach (ParamInfo p in Description)
                {
                        ComCheck = Opticon.csp2.Init(ComCheck);
                        int line = Convert.ToInt32(File.ReadLines(@"../../WVA_Keychain_Synch/TextDocs/" + TxtReader).Skip(counter).Take(1).First());
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
            }
            catch (System.AccessViolationException e)
            {
                Error = e.ToString();
                Error += "(Location: SetParameters)";
                PrintToErrorLog();
            }
            PrefPB.Value = 0;
            Start();         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TxtReader = "ReadUPC_Only.txt";
            SetParameters();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TxtReader = "ReadStockOnly.txt";
            SetParameters();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TxtReader = "ReadStock+UPC.txt";
            SetParameters();
        }
                
        private void LLContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.wisvis.com");
            }
            catch (Exception e1)
            {
                Error = e1.ToString();
                Error += "(Location: LLContact_LinkClicked())";
                PrintToErrorLog();
            }
        }

        private void LLViewCart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.wisvis.com");
            }
            catch (Exception e1)
            {
                Error = e1.ToString();
                Error += "(Location: LLViewCart_LinkClicked())";
                PrintToErrorLog();
            }
        }

        private void SetAccountNumberBtn(object sender, EventArgs e)
         {
            try
            {
                AccountNumber = AccountTextBox.Text;

                if (AccountNumber != "")
                {
                    if (AccountNumber.Contains("Set to: "))
                        AccountNumber = AccountNumber.Remove(0, 8);

                    if (AccountNumber.Contains("Set to:"))
                        AccountNumber = AccountNumber.Remove(0, 7);

                    string dirAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(dirAppData + @"\WVA_Keychain_Synch\AccountNumber\AccountNumber.txt"))
                    {
                        file.WriteLine(AccountNumber);
                        file.Close();
                    }

                    AccountTextBox.Text = ("Set to: " + AccountNumber);
                }
            }
            catch (Exception e1)
            {
                Error = e1.ToString();
                Error += "(Location: SetAccountNumberBtn())";
                PrintToErrorLog();
            }
        }      
    }

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

